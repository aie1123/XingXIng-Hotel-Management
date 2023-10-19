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

    public class UserController : ApiController
    {
        UserBO _userBO = new UserBO();

        #region 用户信息 登录
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject obj)
        {
            dynamic model = obj;
            string useraccount = model.UserAccount ?? "";
            string userpassword = model.UserPassword ?? "";
            if (string.IsNullOrEmpty(useraccount) || string.IsNullOrEmpty(userpassword))
            {
                return Json(new Result(ResultCode.Fail, "帐户名或密码不能为空"));
            }
            try
            {
                // 1, todo 验证用户名密码正确
                var result = _userBO.Login(useraccount, userpassword);
                //2,//在token中加入用户id,创建token
                var dic = new Dictionary<string, object>();
                dic.Add("UserID", model.UserID);
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

        #region 用户信息 分页列表
        /// <summary>
        /// 用户信息 分页列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingUserList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetUserListWhereC(model.condidate);
                var result = _userBO.GetPagingUserList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetUserListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.userName);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and UserName like '%{tmp}%'"; }
            return wc;
        }
        #endregion

        #region 用户信息 用户列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetUserList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new UserBO().GetUserList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 保存
        /// <summary>
        /// 用户信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveUserInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _userBO.SaveUserInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 管理员保存
        /// <summary>
        /// 用户信息 管理员保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveUserInfoByAdmin(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _userBO.SaveUserInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 注册
        [HttpPost]
        public IHttpActionResult UserRegister([FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _userBO.UserRegister(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteUserInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string userID = model.UserID ?? "";
            if (string.IsNullOrEmpty(userID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _userBO.DeleteUserInfo(Convert.ToInt16(userID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetUserInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string userID = model.UserID ?? "";
            if (string.IsNullOrEmpty(userID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _userBO.GetUserInfo(Convert.ToInt16(userID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 用户信息 头像上传
        public IHttpActionResult UploadFile() {
            var res = _userBO.UploadFile(HttpContext.Current.Request.Files);
            return Json(res);
        }
        #endregion

    }
}
