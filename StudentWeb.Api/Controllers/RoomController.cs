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
    public class RoomController : ApiController
    {
        RoomBO _roomBO = new RoomBO();

        #region 房间信息 分页列表
        /// <summary>
        /// 房间信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingRoomList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetRoomListWhereC(model.condidate);
                var result = _roomBO.GetPagingRoomList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetRoomListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.roomType);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and RoomType like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 房间信息 房间列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetRoomList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new RoomBO().GetRoomList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetRoomInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomID = model.RoomID ?? "";
            if (string.IsNullOrEmpty(roomID))
            {
                return Json(new Result(ResultCode.Fail, "房间ID不能为空"));
            }
            try
            {
                var result = _roomBO.GetRoomInfo(Convert.ToInt16(roomID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间信息 保存
        /// <summary>
        /// 房间信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveRoomInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _roomBO.SaveRoomInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteRoomInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomID = model.RoomID ?? "";
            if (string.IsNullOrEmpty(roomID))
            {
                return Json(new Result(ResultCode.Fail, "房间ID不能为空"));
            }
            try
            {
                var result = _roomBO.DeleteRoomInfo(Convert.ToInt16(roomID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间信息 根据房间状态筛选
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetRoomStateInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomState = model.RoomState ?? "";
            if (string.IsNullOrEmpty(roomState))
            {
                return Json(new Result(ResultCode.Fail, "房间状态不能为空"));
            }
            try
            {
                var result = _roomBO.GetRoomStateInfo(Convert.ToString(roomState));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间信息 根据房型返回可预定信息
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetOrderbleRoomInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomType = model.RoomType ?? "";
            if (string.IsNullOrEmpty(roomType))
            {
                return Json(new Result(ResultCode.Fail, "房型不能为空"));
            }
            try
            {
                var result = _roomBO.GetOrderbleRoomInfo(Convert.ToString(roomType));
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
