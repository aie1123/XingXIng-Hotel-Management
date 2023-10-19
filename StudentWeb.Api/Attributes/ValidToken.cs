using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using StudentWeb.BLL;
using StudentWeb.Common;
using System.Net.Http;
using System.Net;

namespace StudentWeb.Api
{
    /// <summary>
    /// token有效性检测
    /// </summary>
    public class ValidTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            var Jwt = new Jwt();
            var token = context.ActionArguments["token"]?.ToString();
            if (string.IsNullOrEmpty(token))
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.OK, new Result(ResultCode.Fail, "Token不能为空"));
            }
            else
            {
                bool result = Jwt.Check(token);
                if (!result)
                {
                    context.Response = context.Request.CreateResponse(HttpStatusCode.OK, new Result(ResultCode.Fail, "Token不存在或已失效，请重新登录!"));
                }
            }
            base.OnActionExecuting(context);
        }
    }
}