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
    public class RoomtypeController : ApiController
    {
        RoomtypeBO _roomtypeBO = new RoomtypeBO();

        #region 房间类型信息 分页列表
        /// <summary>
        /// 房间类型信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingRoomtypeList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetRoomtypeListWhereC(model.condidate);
                var result = _roomtypeBO.GetPagingRoomtypeList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetRoomtypeListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.roomType);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and RoomType like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 房间类型信息 房间类型列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetRoomtypeList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new RoomtypeBO().GetRoomtypeList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间类型信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetRoomtypeInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomtypeID = model.RoomTypeID ?? "";
            if (string.IsNullOrEmpty(roomtypeID))
            {
                return Json(new Result(ResultCode.Fail, "房间类型ID不能为空"));
            }
            try
            {
                var result = _roomtypeBO.GetRoomtypeInfo(Convert.ToInt16(roomtypeID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间类型信息 保存
        /// <summary>
        /// 房间类型信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveRoomtypeInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _roomtypeBO.SaveRoomtypeInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间类型信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteRoomtypeInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string roomtypeID = model.RoomTypeID ?? "";
            if (string.IsNullOrEmpty(roomtypeID))
            {
                return Json(new Result(ResultCode.Fail, "房间类型ID不能为空"));
            }
            try
            {
                var result = _roomtypeBO.DeleteRoomtypeInfo(Convert.ToInt16(roomtypeID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 房间类型信息 图片上传
        public IHttpActionResult UploadFile()
        {
            var res = _roomtypeBO.UploadFile(HttpContext.Current.Request.Files);
            return Json(res);

        }
        #endregion
    }
}
