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
    public class OrderController : ApiController
    {
        OrderBO _orderBO = new OrderBO();
        #region 订单信息 分页列表
        /// <summary>
        /// 订单信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingOrderList(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetOrderListWhereC(model.condidate);
                var result = _orderBO.GetPagingOrderList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetOrderListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.orderID);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and OrderID like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 订单信息 订单列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetOrderList(string token, [FromBody]JObject obj)
        {
            try
            {
                var result = new OrderBO().GetOrderList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 订单信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetOrderInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string orderID = model.OrderID ?? "";
            if (string.IsNullOrEmpty(orderID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _orderBO.GetOrderInfo(Convert.ToInt16(orderID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 订单信息 保存
        /// <summary>
        /// 订单信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken] 
        public IHttpActionResult SaveOrderInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _orderBO.SaveOrderInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 订单信息 预定房间
        /// <summary>
        /// 订单信息 预定房间
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult OrderRoom(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _orderBO.OrderRoom(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "预定失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 订单信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeleteOrderInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string orderID = model.OrderID ?? "";
            if (string.IsNullOrEmpty(orderID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _orderBO.DeleteOrderInfo(Convert.ToInt16(orderID));
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
