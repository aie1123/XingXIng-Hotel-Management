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
    public class TeacherController : ApiController
    {
        TeacherBO _teacherBO = new TeacherBO();

        #region 用户 登录
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login([FromBody]JObject obj)
        {
            dynamic model = obj;
            string userMobile = model.userMobile ?? "";
            string userPassword = model.userPassword ?? "";
            if (string.IsNullOrEmpty(userMobile) || string.IsNullOrEmpty(userPassword))
            {
                return Json(new Result(ResultCode.Fail, "用户名或密码不能为空"));
            }
            try
            {
                var result = _teacherBO.Login(userMobile, userPassword);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 教师信息 分页列表
        /// <summary>
        /// 教师信息 分页列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetTeacherList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetTeacherListWhereC(model.condidate);
                var result = _teacherBO.GetTeacherList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetTeacherListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.tabkey);
            if (!string.IsNullOrEmpty(tmp) && tmp != "all") { wc += $" and (TeacherState={tmp})"; }
            tmp = ConvertHelper.DynamicToString(qc.teacherName);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and TeacherName like '%{tmp}%'"; }
            tmp = ConvertHelper.DynamicToString(qc.userMobile);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and UserMobile like '%{tmp}%'"; }
            tmp = ConvertHelper.DynamicToString(qc.teacherDuty);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and TeacherDuty like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 教师信息 单条记录
        /// <summary>
        /// 教师信息 单条记录
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetTeacherInfo(string token, int teacherDataID)
        {
            try
            {
                var result = _teacherBO.GetTeacherInfo(teacherDataID);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 教师信息 保存
        /// <summary>
        /// 教师信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveTeacherInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var user = _teacherBO.GetTeacherInfo(token);
                var result = _teacherBO.SaveTeacherInfo(model, user.TeacherDataID);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
    }
}
