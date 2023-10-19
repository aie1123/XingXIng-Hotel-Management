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
using System.Configuration;

namespace StudentWeb.Api.Controllers
{
    public class SmsController : ApiController
    {
        #region GetSms 注册短信验证码
        /// <summary>
        /// 注册短信验证码
        /// </summary>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetSmsRegister(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                string[] sms = ConfigurationManager.ConnectionStrings["SmsToken"].ConnectionString.Split(',');
                string id = sms[0];
                string smstoken = sms[1];
                string mobile = model.mobile ?? "";
                string url = "https://api.kfd.pub/student/SmsRegister";
                string postData = $@"id={id}&smstoken={smstoken}&mobile={mobile}";
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

        #region SmsReset 找回密码短信验证码
        /// <summary>
        /// 找回密码短信验证码
        /// </summary>
        [HttpPost]
        [ValidToken]
        public IHttpActionResult GetSmsReset(string token, [FromBody]JObject obj)
        {
            dynamic model = obj;
            if (model == null) return Json(new Result(ResultCode.Fail, "缺少参数"));
            try
            {
                string[] sms = ConfigurationManager.ConnectionStrings["SmsToken"].ConnectionString.Split(',');
                string id = sms[0];
                string smstoken = sms[1];
                string mobile = model.mobile ?? "";
                string url = "https://api.kfd.pub/student/SmsReset";
                string postData = $@"id={id}&smstoken={smstoken}&mobile={mobile}";
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
