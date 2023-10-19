using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace StudentWeb.BLL

{

    public class Jwt

    {

        //参考自 阮一峰 jwt介绍  http://www.ruanyifeng.com/blog/2018/07/json_web_token-tutorial.html
        public static string SALT = "OXpcRP8jmCfMKumY";
        /// <summary>
        ///
        /// </summary>
        /// <param name="ExraPayload">额外的信息</param>
        /// <returns></returns>
        public static string Create(Dictionary<string, object> ExraPayload)

        {

            var Header = new Dictionary<string, string>();
            Header.Add("tp", "MD5");
            var Payload = new Dictionary<string, object>();
            //JWT 规定了7个官方字段，供选用。
            Payload.Add("iss", "signByHotelWeb"); //颁发人
            Payload.Add("jti", Guid.NewGuid().ToString()); //jwt的id
            Payload.Add("exp", System.DateTime.Now.AddMinutes(1440));//过期时间
            Payload.Add("nbf", System.DateTime.Now);//生效时间
            Payload.Add("iat", System.DateTime.Now);//签发时间
            Payload.Add("sub", "Hotel");//主题
            Payload.Add("aud", "Everyone");//受
            foreach (var item in ExraPayload)
            {
                if (Payload.ContainsKey(item.Key))
                {
                    throw new Exception($"{item.Key}键值已被占用 不能使用 ");
                }
                else
                {
                    Payload.Add(item.Key, item.Value);
                }
            }
            string base64Header = Base64Url(Newtonsoft.Json.JsonConvert.SerializeObject(Header));
            string base64Payload = Base64Url(Newtonsoft.Json.JsonConvert.SerializeObject(Payload));
            string tmp = base64Header + "." + base64Payload;
            string sign = Md5(tmp + SALT);//加盐，重要
            return base64Header + "." + base64Payload + "." + sign;
        }
        //校验是否合法，是否过期
        public static bool Check(string token)
        {
            string base64Header = token.Split('.')[0];
            string base64Payload = token.Split('.')[1];
            string sign = token.Split('.')[2];
            string tmp = base64Header + "." + base64Payload;
            var signCheck = Md5(base64Header + "." + base64Payload + SALT);
            if (signCheck != sign)
            {
                return false;
            }
            var dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(Base64UrlDecode(base64Payload));
            if (Convert.ToDateTime(dic["exp"]) < System.DateTime.Now)
            {
                //过期了
                return false;
            }
            return true;
        }
        //校验是否合法，是否过期
        public static Dictionary<string, object> GetPayLoad(string token)
        {
            string base64Payload = token.Split('.')[1];
            var dic = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(Base64UrlDecode(base64Payload));
            return dic;
        }
        public static string Base64Url(string input)
        {
            //JWT 作为一个令牌（token），有些场合可能会放到 URL（比如 api.example.com/?token=xxx）。
            //Base64 有三个字符+、/和=，在 URL 里面有特殊含义，所以要被替换掉：=被省略、+替换成-，/替换成_ 。
            string output = "";
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            try
            {
                output = Convert.ToBase64String(bytes).Replace('+', '-').Replace('/', '_').TrimEnd('=');
            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }
        public static string Base64UrlDecode(string input)
        {
            string output = "";
            input = input.Replace('-', '+').Replace('_', '/');
            switch (input.Length % 4)
            {
                case 2:
                    input += "==";
                    break;
                case 3:
                    input += "=";
                    break;
            }
            byte[] bytes = Convert.FromBase64String(input);
            try
            {
                output = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                output = input;
            }
            return output;
        }
        public static string Md5(string input, int bit = 16)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(input));
            StringBuilder tmp = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                tmp.Append(i.ToString("x2"));
            }
            if (bit == 16)
                return tmp.ToString().Substring(8, 16);
            else
            if (bit == 32) return tmp.ToString();//默认情况
            else return string.Empty;
        }
    }
}