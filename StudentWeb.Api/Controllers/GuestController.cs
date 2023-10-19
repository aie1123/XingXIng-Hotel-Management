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
    public class GuestController : ApiController
    {
        GuestBO _guestBO = new GuestBO();
        #region 住客信息 分页列表
        /// <summary>
        /// 住客信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingGuestList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetGuestListWhereC(model.condidate);
                var result = _guestBO.GetPagingGuestList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetGuestListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.guestName);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and GuestName like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 住客信息 住客列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetGuestList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new GuestBO().GetGuestList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 住客信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetGuestInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string guestID = model.GuestID ?? "";
            if (string.IsNullOrEmpty(guestID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _guestBO.GetGuestInfo(Convert.ToInt16(guestID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 住客信息 保存
        /// <summary>
        /// 住客信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveGuestInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _guestBO.SaveGuestInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 住客信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteGuestInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string guestID = model.GuestID ?? "";
            if (string.IsNullOrEmpty(guestID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _guestBO.DeleteGuestInfo(Convert.ToInt16(guestID));
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
