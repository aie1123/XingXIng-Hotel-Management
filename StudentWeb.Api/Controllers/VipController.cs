using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentWeb.BLL;
using System.Web;
using Newtonsoft.Json.Linq;
using StudentWeb.Common;

namespace StudentWeb.Api.Controllers
{
    public class VipController : ApiController
    {
        VipBO _vipBO = new VipBO();

        #region VIP信息 登录
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject obj)
        {
            dynamic model = obj;
            string vipaccount = model.VipAccount ?? "";
            string vippassword = model.VipPassword ?? "";
            if (string.IsNullOrEmpty(vipaccount) || string.IsNullOrEmpty(vippassword))
            {
                return Json(new Result(ResultCode.Fail, "帐户名或密码不能为空"));
            }
            try
            {
                // 1, todo 验证用户名密码正确
                var result = _vipBO.Login(vipaccount, vippassword);
                //2,//在token中加入用户id,创建token
                var dic = new Dictionary<string, object>();
                dic.Add("VipID", model.VipID);
                string token = Jwt.Create(dic);
                //验证token是否正确是否过期
                var isChecked = Jwt.Check(token);
                if (isChecked)
                {
                    return Json(result);
                }
                else
                {
                    return Json(new Result(ResultCode.Fail, "token已过期"));
                }
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region VIP信息 分页列表
        /// <summary>
        /// VIP信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult GetPagingVipList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetVipListWhereC(model.condidate);
                var result = _vipBO.GetPagingVipList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetVipListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.vipName);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and VipName like '%{tmp}%'"; }
            return wc;
        }
        #endregion

        #region VIP信息 VIP列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetVipList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new VipBO().GetVipList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region VIP信息 保存
        /// <summary>
        /// VIP信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveVipInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _vipBO.SaveVipInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region VIP信息 管理员保存
        /// <summary>
        /// VIP信息 管理员保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveVipInfoByAdmin(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _vipBO.SaveVipInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region VIP信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteVipInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string vipID = model.VipID ?? "";
            if (string.IsNullOrEmpty(vipID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _vipBO.DeleteVipInfo(Convert.ToInt16(vipID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region VIP信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetVipInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string vipID = model.VipID ?? "";
            if (string.IsNullOrEmpty(vipID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _vipBO.GetVipInfo(Convert.ToInt16(vipID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
    }
}
