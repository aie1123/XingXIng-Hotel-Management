using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWeb.DAL;
using StudentWeb.Model;
using StudentWeb.Common;

namespace StudentWeb.BLL
{
    public class AdminBO
    {
        #region 管理员信息 登录
        public IResult Login(string adminname, string adminpassword)
        {
            var list = new AdminDataDAO().GetList();
            var admin = new AdminDataDAO().GetInfoByAdminName(adminname);
            if (admin == null)//如该用户记录不存在
            {
                return new Result(ResultCode.Fail, "用户名不存在");
            }
            if (admin.AdminPassword != adminpassword)//判断密码
            {
                return new Result(ResultCode.Fail, "密码错误");
            }
            //创建token
            var dic = new Dictionary<string, object>();
            dic.Add("AdminPassword", admin.AdminPassword);
            string token = Jwt.Create(dic);
            //向前端返回token信息
            dynamic result = new
            {
                token
            };
            return new DataResult<dynamic>(result,ResultCode.Success, msg: "登录成功");
            //return new Result(ResultCode.Success, "登录成功");
        }
        #endregion
        #region 管理员信息 列表
        public IResult GetAdminList()
        {
            var list = new AdminDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 管理员信息 保存
        public bool SaveAdminInfo(dynamic data)
        {
            int adminID = data.AdminID ?? 0;
            var result = 0;
            if (adminID > 0)
            {
                var record = new AdminDataDAO().GetInfo(adminID);
                record.AdminName = data.AdminName;
                record.AdminPassword = data.AdminPassword;
                result = new AdminDataDAO().Update(record);
            }
            else if (adminID == 0)
            {
                var admin = new AdminData()
                {
                    AdminName = data.AdminName,
                    AdminPassword = data.AdminPassword,
            };
                result = new AdminDataDAO().Insert(admin);
            }
            return result > 0;
        }
        #endregion
        #region 管理员信息  三表联查
        public IResult GetRoomOrderCheckinList()
        {

            var list = new AdminDataDAO().GetRoomOrderCheckinList();
            return new DataResult(list);
        }
        #endregion

    }
}
