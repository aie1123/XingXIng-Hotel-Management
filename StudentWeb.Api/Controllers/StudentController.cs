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
    public class StudentController : ApiController
    {
        StudentBO _studentBO = new StudentBO();

        #region 学生信息 分页列表
        /// <summary>
        /// 学生信息 分页列表
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetStudentList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetStudentListWhereC(model.condidate);
                var result = _studentBO.GetStudentList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetStudentListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.tabkey);
            if (!string.IsNullOrEmpty(tmp) && tmp != "all") { wc += $" and (StudentState={tmp})"; }
            tmp = ConvertHelper.DynamicToString(qc.studentName);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and StudentName like '%{tmp}%'"; }
            tmp = ConvertHelper.DynamicToString(qc.studentMobile);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and StudentMobile like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 学生信息 单条记录
        /// <summary>
        /// 学生信息 单条记录
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetStudentInfo(string token, int studentDataID)
        {
            try
            {
                var result = _studentBO.GetStudentInfo(studentDataID);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 学生信息 保存
        /// <summary>
        /// 学生信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult SaveStudentInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var user = new TeacherBO().GetTeacherInfo(token);
                var result = _studentBO.SaveStudentInfo(model, user.TeacherDataID);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region 学生统计 总数
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetStudentCount(string token)
        {
            try
            {
                var result = _studentBO.GetStudentCount();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 学生统计 性别
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetAnalysisStudentSex(string token)
        {
            try
            {
                var result = _studentBO.GetAnalysisStudentSex();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 学生统计 年级
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetAnalysisStudentGrade(string token)
        {
            try
            {
                var result = _studentBO.GetAnalysisStudentGrade();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 学生统计 籍贯
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetAnalysisStudentNative(string token)
        {
            try
            {
                var result = _studentBO.GetAnalysisStudentNative();
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
