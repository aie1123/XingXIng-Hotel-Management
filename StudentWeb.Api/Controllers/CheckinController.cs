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
    public class CheckinController : ApiController
    {
        CheckinBO _checkinBO = new CheckinBO();
        #region 入住信息 分页列表
        /// <summary>
        /// 入住信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingCheckinList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetCheckinListWhereC(model.condidate);
                var result = _checkinBO.GetPagingCheckinList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetCheckinListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.roomNumber);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and RoomNumber like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 入住信息 入住列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetCheckinList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new CheckinBO().GetCheckinList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 入住信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetCheckinInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string checkinID = model.CheckinID ?? "";
            if (string.IsNullOrEmpty(checkinID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _checkinBO.GetCheckinInfo(Convert.ToInt16(checkinID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 入住信息 保存
        /// <summary>
        /// 入住信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveCheckinInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _checkinBO.SaveCheckinInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 入住信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteCheckinInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string checkinID = model.CheckinID ?? "";
            if (string.IsNullOrEmpty(checkinID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _checkinBO.DeleteCheckinInfo(Convert.ToInt16(checkinID));
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
