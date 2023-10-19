using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentWeb.BLL
{
    public enum ResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 0,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = -1,
    }
    public class Result : IResult
    {
        /// <summary>
        /// 错误代码（0为成功）
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 错误消息（成功时为成功消息）
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }     

        public Result(ResultCode code = ResultCode.Success, string msg = "")
        {
            Code = (int)code;
            Msg = msg;
        }
    }

    public class DataResult<T> : IResult
    {
        /// <summary>
        /// 错误代码（0为成功）
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 错误消息（成功时为成功消息）
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 返回内容
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; }

        public DataResult(T t, ResultCode code = ResultCode.Success, string msg = "")
        {
            Code = (int)code;
            Msg = msg;
            Data = t;
        }
    }

    public class DataResult : IResult
    {
        /// <summary>
        /// 错误代码（0为成功）
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// 错误消息（成功时为成功消息）
        /// </summary>
        [JsonProperty("msg")]
        public string Msg { get; set; }

        /// <summary>
        /// 返回内容
        /// </summary>
        [JsonProperty("data")]
        public dynamic Data { get; set; }

        public DataResult(dynamic data, ResultCode code = ResultCode.Success, string msg = "")
        {
            Code = (int)code;
            Msg = msg;
            Data = data;
        }
    }

    public interface IResult
    {
        int Code { get; set; }

        string Msg { get; set; }
    }
}