using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentWeb.BLL;
using Newtonsoft.Json.Linq;
using StudentWeb.Common;

namespace StudentWeb.Api.Controllers
{
    public class AdminController : ApiController
    {
        AdminBO _adminBO = new AdminBO();
        #region 管理员 登录
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject obj)
        {
            dynamic model = obj;
            string username = model.AdminName ?? "";
            string password = model.AdminPassword ?? "";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return Json(new Result(ResultCode.Fail, "用户名或密码不能为空"));
            }
            try
            {
                var result = _adminBO.Login(username, password);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 管理员 列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetAdminList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new AdminBO().GetAdminList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 管理员 保存
        /// <summary>
        /// 管理员 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveAdminInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _adminBO.SaveAdminInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 管理员 三表联查
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetRoomOrderCheckinList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new AdminBO().GetRoomOrderCheckinList();
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
