using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StudentWeb.DAL;
using StudentWeb.Model;
using StudentWeb.Common;
using System.Security.Cryptography;
using System.Web;

namespace StudentWeb.BLL
{
    public class UserBO
    {

        #region 用户信息 登录
        public IResult Login(string useraccount, string userpassword)
        {
            var list = new UserDataDAO().GetList();
            var userList = list.Where(item => item.UserAccount == useraccount).ToList();//取对应用户名列表
            if (userList.Count < 1)//如该用户记录不存在
            {
                return new Result(ResultCode.Fail, "用户名不存在");
            }
            if (userList[0].UserPassword != userpassword)//判断密码
            {
                return new Result(ResultCode.Fail, "密码错误");
            }
            //创建token
            var dic = new Dictionary<string, object>();
            dic.Add("UserPassword", userList[0].UserPassword);
            string token = Jwt.Create(dic);
            //向前端返回token信息
            dynamic result = new
            {
                token
            };
            return new DataResult<dynamic>(result, ResultCode.Success, msg: "登录成功");
            //return new Result(ResultCode.Success, "登录成功");
        }
        #endregion

        #region 用户信息 分页列表
        /// <summary>
        /// 用户信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingUserList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new UserDataDAO().GetPagingUserList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion

        #region 用户信息 用户列表
        public IResult GetUserList()
        {
            var list = new UserDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion

        #region 用户信息 保存
        public bool SaveUserInfo(dynamic data)
        {
            int userID = data.UserID ?? 0;
            var result = 0;
            if (userID > 0)
            {
                var record = new UserDataDAO().GetInfo(userID);
                record.UserName = data.UserName;
                record.UserPassword = data.UserPassword;
                record.UserPhone = data.UserPhone;
                record.UserGender = data.UserGender;
                record.UserAvatar = data.UserAvatar ?? "";
                result = new UserDataDAO().Update(record);
            }
            else if (userID == 0)
            {
                var user = new UserData()
                {
                    UserAccount = data.UserAccount,
                    UserGender = data.UserGender,
                    UserName = data.UserName,
                    UserPassword = data.UserPassword,
                    UserPhone = data.UserPhone,
                    UserAvatar = data.UserAvatar ?? "",
                };
                result = new UserDataDAO().Insert(user);
            }
            return result > 0;
        }
        #endregion

        #region 用户信息 管理员保存
        public bool SaveUserInfoByAdmin(dynamic data)
        {
            int userID = data.UserID ?? 0;
            var result = 0;
            if (userID > 0)
            {
                var record = new UserDataDAO().GetInfo(userID);
                record.UserAccount = data.UserAccount;
                record.UserGender = data.UserGender;
                record.UserName = data.UserName;
                record.UserPassword = data.UserPassword;
                record.UserPhone = data.UserPhone;
                record.UserAvatar = data.UserAvatar ?? "";
                result = new UserDataDAO().Update(record);
            }
            else if (userID == 0)
            {
                var user = new UserData()
                {
                    UserAccount = data.UserAccount,
                    UserGender = data.UserGender,
                    UserName = data.UserName,
                    UserPassword = data.UserPassword,
                    UserPhone = data.UserPhone,
                    UserAvatar = data.UserAvatar ?? "",
                };
                result = new UserDataDAO().Insert(user);
            }
            return result > 0;
        }
        #endregion

        #region 用户信息 注册
        public bool UserRegister(dynamic data)
        {
            var result = 0;
            var user = new UserData()
            {
                UserAccount = data.UserAccount,
                UserGender = data.UserGender,
                UserName = data.UserName,
                UserPassword = data.UserPassword,
                UserPhone = data.UserPhone,
                UserAvatar = data.UserAvatar ?? "",
            };
            result = new UserDataDAO().Insert(user);
            return result > 0;
        }
        #endregion

        #region 用户信息 删除
        public IResult DeleteUserInfo(int userID)
        {
            var res = new UserDataDAO().Delete(userID);
            if (res > 0)
            {
                return new DataResult(ResultCode.Success);
            }
            else
            {
                return new DataResult(ResultCode.Fail);
            }
        }
        #endregion

        #region 用户信息 取单条记录
        public IResult GetUserInfo(int userDataID)
        {
            var record = new UserDataDAO().GetInfo(userDataID);
            return new DataResult(record);
        }
        #endregion

        #region 用户信息 头像上传
        public DataResult UploadFile(HttpFileCollection files)
        {
            var res = new DataResult(null, ResultCode.Fail);
            try
            {
                var file = files["file"];
                if (file != null)
                {
                    //byte[] buffer;
                    if(file.ContentLength > 1048576 * 10) //10MB
                    {
                        return new DataResult(null, ResultCode.Fail, "文件超出大小限制");
                    }
                    var fileFolder = "/Images/"; //存放图片的文件夹
                    var filePath = HttpContext.Current.Server.MapPath(fileFolder); //存放图片的完整文件夹
                    if(!Directory.Exists(filePath)) //判断文件夹是否存在，如不存在则新创建
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileExt = Path.GetExtension(file.FileName); //取文件扩展名
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExt; //生成随机文件名
                    var fullPath = Path.Combine(filePath,fileName); //完整路径（文件夹+文件名）
                    file.SaveAs(fullPath); //保存
                    var url = fileFolder + fileName; //图片URL地址
                    res = new DataResult(new { url });
                }
                else
                {
                    res = new DataResult(null, ResultCode.Fail);
                }
            }
            catch(Exception ex)
            {
                res = new DataResult(null, ResultCode.Fail, ex.Message);
            }
            return res;
        }
        #endregion


    }
}

