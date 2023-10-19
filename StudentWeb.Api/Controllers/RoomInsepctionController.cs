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
    public class RoomInsepctionController : ApiController
    {
        RoomInsepctionBO _roomInsepctionBO = new RoomInsepctionBO();
        #region 客房巡查信息 分页列表
        /// <summary>
        /// 客房巡查信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]  
        public IHttpActionResult GetPagingRoomInsepctionList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetRoomInsepctionListWhereC(model.condidate);
                var result = _roomInsepctionBO.GetPagingRoomInsepctionList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetRoomInsepctionListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.roomNumber);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and RoomNumber like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 客房巡查信息 客房巡查列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetRoomInsepctionList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new RoomInsepctionBO().GetRoomInsepctionList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 客房巡查信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetRoomInsepctionInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roominsepctionID = model.RoominsepctionID ?? "";
            if (string.IsNullOrEmpty(roominsepctionID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _roomInsepctionBO.GetRoomInsepctionInfo(Convert.ToInt16(roominsepctionID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 客房巡查信息 保存
        /// <summary>
        /// 客房巡查信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveRoomInsepctionInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _roomInsepctionBO.SaveRoomInsepctionInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 客房巡查信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteRoomInsepctionInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roominsepctionID = model.RoominsepctionID ?? "";
            if (string.IsNullOrEmpty(roominsepctionID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _roomInsepctionBO.DeleteRoomInsepctionInfo(Convert.ToInt16(roominsepctionID));
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
