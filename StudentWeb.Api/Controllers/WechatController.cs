using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentWeb.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentWeb.Common;

namespace StudentWeb.Api.Controllers
{
    public class WechatController : ApiController
    {
        #region GetNativePay 扫码支付
        /// <summary>
        /// 扫码支付
        /// </summary>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetNativePay(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                decimal price = model.price ?? 1;
                string paynote = model.paynote ?? "";
                string url = "https://api.kfd.pub/Wechat/GetNativePayUrl?code=U8LhuC&token=a7494c3cf5974be28b020022092f79f0";
                string postData = $@"price={price}&paynote={paynote}";
                var result = SendPost(url, postData);
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region JudgePayState 判断支付状态
        [HttpPost]
        [ValidToken]
        public IHttpActionResult JudgePayState(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                int payid = model.payid ?? 0;
                string url = "https://api.kfd.pub/Wechat/JudgePayState?code=U8LhuC&token=a7494c3cf5974be28b020022092f79f0";
                string postData = $@"payid={payid}";
                var result = SendPost(url, postData);
                var res = JsonConvert.DeserializeObject<dynamic>(result);
                return Json(res);
            }
            catch (Exception ex)
            {
                return Json(new Result(ResultCode.Fail, ex.Message));
            }
        }
        #endregion

        #region SendPost
        public static string SendPost(string url, string postData, string method = "POST")
        {
            string webpageContent = string.Empty;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = method;
                webRequest.ContentType = "application/x-www-form-urlencoded";
                if (method == "POST")
                {
                    webRequest.ContentLength = byteArray.Length;
                }

                using (Stream webpageStream = webRequest.GetRequestStream())
                {
                    webpageStream.Write(byteArray, 0, byteArray.Length);
                }

                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                    {
                        webpageContent = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                webpageContent = ex.ToString();
            }
            return webpageContent;
        }
        #endregion
    }
}
