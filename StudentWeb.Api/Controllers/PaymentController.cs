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
    public class PaymentController : ApiController
    {
        PaymentBO _paymentBO = new PaymentBO();
        #region 结帐信息 分页列表
        /// <summary>
        /// 结帐信息 分页列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPagingPaymentList(string token,[FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int pageIndex = model.page_index ?? 0;
                int pageSize = model.page_size ?? 0;
                if (pageIndex < 1 || pageSize < 1) return Json(new Result(ResultCode.Fail, "参数错误"));
                var wc = _GetPaymentListWhereC(model.condidate);
                var result = _paymentBO.GetPagingPaymentList(pageIndex, pageSize, wc);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        private string _GetPaymentListWhereC(dynamic qc)
        {
            var wc = string.Empty;
            if (qc == null) return wc;
            string tmp = "";
            tmp = ConvertHelper.DynamicToString(qc.paymentID);
            if (!string.IsNullOrEmpty(tmp)) { wc += $" and PaymentID like '%{tmp}%'"; }
            return wc;
        }
        #endregion
        #region 结帐信息 结帐列表
        [HttpGet]
        [ValidToken]
        public IHttpActionResult GetPaymentList(string token,[FromBody]JObject obj)
        {
            try
            {
                var result = new PaymentBO().GetPaymentList();
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 结帐信息 单条记录
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetPaymentInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string paymentID = model.PaymentID ?? "";
            if (string.IsNullOrEmpty(paymentID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _paymentBO.GetPaymentInfo(Convert.ToInt16(paymentID));
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 结帐信息 保存
        /// <summary>
        /// 结帐信息 保存
        /// </summary>
        /// <param name="token"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidToken]  
        public IHttpActionResult SavePaymentInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                var result = _paymentBO.SavePaymentInfo(model);
                return result ? Json(new Result()) : Json(new Result(ResultCode.Fail, "保存失败"));
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion
        #region 结帐信息 删除
        [HttpPost]
        [ValidToken]
        public IHttpActionResult DeletePaymentInfo(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            string paymentID = model.PaymentID ?? "";
            if (string.IsNullOrEmpty(paymentID))
            {
                return Json(new Result(ResultCode.Fail, "ID不能为空"));
            }
            try
            {
                var result = _paymentBO.DeletePaymentInfo(Convert.ToInt16(paymentID));
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
