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
    public class RoomRemarksController : ApiController
    {
        RoomRemarksBO _roomRemarksBO = new RoomRemarksBO();
        #region 用户反馈信息 列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetRoomRemarksList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new RoomRemarksBO().GetRoomRemarksList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 用户反馈信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetRoomRemarksInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string remarksID = model.RemarksID ?? "";
            if (string.IsNullOrEmpty(remarksID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _roomRemarksBO.GetRoomRemarksInfo(Convert.ToInt16(remarksID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 用户反馈信息 保存
        /// <summary>
        /// 用户反馈信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveRoomRemarksInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _roomRemarksBO.SaveRoomRemarksInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 用户反馈信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteRoomRemarksInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string remarksID = model.RemarksID ?? "";
            if (string.IsNullOrEmpty(remarksID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _roomRemarksBO.DeleteRoomRemarksInfo(Convert.ToInt16(remarksID));
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
