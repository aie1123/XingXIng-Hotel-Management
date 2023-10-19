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
    public class VipBO
    {
        #region VIP信息 登录
        public IResult Login(string vipaccount, string vippassword)
        {
            var list = new VipDataDAO().GetList();
            var vipList = list.Where(item => item.VipAccount == vipaccount).ToList();//取对应用户名列表
            if (vipList.Count < 1)//如该用户记录不存在
            {
                return new Result(ResultCode.Fail, "用户名不存在");
            }
            if (vipList[0].VipPassword != vippassword)//判断密码
            {
                return new Result(ResultCode.Fail, "密码错误");
            }
            //创建token
            var dic = new Dictionary<string, object>();
            dic.Add("VipPassword", vipList[0].VipPassword);
            string token = Jwt.Create(dic);
            //验证token是否正确是否过期
            var isChecked = Jwt.Check(token);
            if (isChecked)
            {
                //向前端返回用户信息
                dynamic result = new
                {
                    vipList[0].VipID,
                    vipList[0].VipAccount,
                    vipList[0].VipPassword,
                    Token = token,
                };
                return new DataResult<dynamic>(result, ResultCode.Success, msg: "登录成功");
                //return new Result(ResultCode.Success, "登录成功");
            }
            else
            {
                return new Result(ResultCode.Fail, "token已过期");
            }
        }
        #endregion

        #region VIP信息 分页列表
        /// <summary>
        /// VIP信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingVipList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new VipDataDAO().GetPagingVipList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion

        #region VIP信息 VIP列表
        public IResult GetVipList()
        {
            var list = new VipDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion

        #region VIP信息 保存
        public bool SaveVipInfo(dynamic data)
        {
            int vipID = data.VipID ?? 0;
            var result = 0;
            if (vipID > 0)
            {
                var record = new VipDataDAO().GetInfo(vipID);
                record.VipName = data.VipName;
                record.VipGender = data.VipGender;
                record.VipPassword = data.VipPassword;
                record.VipPhone = data.VipPhone;
                record.VipEmail = data.VipEmail;
                result = new VipDataDAO().Update(record);
            }
            else if (vipID == 0)
            {
                var vip = new VipData()
                {
                    VipAccount = data.VipAccount,
                    VipName = data.VipName,
                    VipGender = data.VipGender,
                    VipPassword = data.VipPassword,
                    VipPhone = data.VipPhone,
                    VipPPID = data.VipPPID,
                    VipEmail = data.VipEmail,
            };
                result = new VipDataDAO().Insert(vip);
            }
            return result > 0;
        }
        #endregion

        #region VIP信息 管理员保存
        public bool SaveVipInfoByAdmin(dynamic data)
        {
            int vipID = data.UserID ?? 0;
            var result = 0;
            if (vipID > 0)
            {
                var record = new VipDataDAO().GetInfo(vipID);
                record.VipAccount = data.VipAccount;
                record.VipName = data.VipName;
                record.VipGender = data.VipGender;
                record.VipPassword = data.VipPassword;
                record.VipPhone = data.VipPhone;
                record.VipPPID = data.VipPPID;
                record.VipEmail = data.VipEmail;
                result = new VipDataDAO().Update(record);
            }
            else if (vipID == 0)
            {
                var vip = new VipData()
                {
                    VipAccount = data.VipAccount,
                    VipName = data.VipName,
                    VipGender = data.VipGender,
                    VipPassword = data.VipPassword,
                    VipPhone = data.VipPhone,
                    VipPPID = data.VipPPID,
                    VipEmail = data.VipEmail,
                };
                result = new VipDataDAO().Insert(vip);
            }
            return result > 0;
        }
        #endregion

        #region VIP信息 删除
        public IResult DeleteVipInfo(int vipID)
        {
            var res = new VipDataDAO().Delete(vipID);
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

        #region VIP信息 取单条记录
        public IResult GetVipInfo(int vipID)
        {
            var record = new VipDataDAO().GetInfo(vipID);
            return new DataResult(record);
        }
        #endregion
    }
}
