using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;


namespace StudentWeb.Common
{
    public class ConvertHelper
    {
        public static readonly DateTime DefaultDate = new DateTime(1900, 1, 1);

        public static int ToInt(string getValue)
        {
            int returnValue;
            int.TryParse(getValue, out returnValue);
            return returnValue;
        }
        public static int ToInt(object getValue)
        {
            return getValue != null ? ToInt(getValue.ToString()) : 0;
        }
        public static string DynamicToString(dynamic dyn, int Length = 999999) //转换动态对象的元素为字符型
        {
            if (dyn == null) return string.Empty;
            string res = dyn.ToString();
            res = res.Trim();
            if (res.Length > Length) res = res.Substring(0, Length);
            return res;
        }

        //private static DateTime ToDateTime(string getDatetime)
        //{
        //    DateTime returnDateTime;
        //    bool sucess = DateTime.TryParse(getDatetime, out returnDateTime);
        //    if (sucess)
        //    {
        //        return returnDateTime;
        //    }
        //    return DefaultDate;
        //}

        //public static DateTime ToDateTime(object getValue)
        //{
        //    return ToDateTime(getValue.ToString());
        //}





        //public static bool ToBool(string getValue)
        //{
        //    bool retValue;
        //    bool.TryParse(getValue, out retValue);
        //    return retValue;
        //}

        //public static bool ToBool(object getValue)
        //{
        //    return ToBool(getValue.ToString());
        //}

        //public static string ListStrToStrings(List<string> list, char splitchar = '、')
        //{
        //    if (list == null || list.Count == 0) return string.Empty;
        //    var r = string.Empty;
        //    list.ForEach(lt =>
        //    {
        //        r += splitchar + lt;
        //    });
        //    return r.TrimStart(splitchar);
        //}

        //public static int DynamicToInt(dynamic dyn) //转换动态对象的元素为整型
        //{
        //    if (dyn == null) return -1;
        //    string tId = dyn.ToString();
        //    return !string.IsNullOrEmpty(tId) ? (int)Convert.ToDouble(tId) : -1;
        //}

        //public static string DyndateToString(dynamic dDate, int Length = 19)//转换动态型日期为字符型
        //{
        //    if (dDate == null) return string.Empty;
        //    DateTime dt;
        //    try
        //    {
        //        dt = dDate;
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //    if (dt == DefaultDate) return string.Empty;
        //    return dt.ToString("yyyy-MM-dd HH:mm:ss").Substring(0, Length);
        //}



        //public static string DynintarrayToString(dynamic iArray, int everyLen = 999) //转换动态整型对象的元素为逗号字符串
        //{
        //    if (iArray == null) return "";
        //    var result = "";
        //    List<int> temList = iArray.ToObject<List<int>>();
        //    if (temList != null && temList.Count > 0)
        //    {
        //        temList.ForEach(x =>
        //        {
        //            var xs = x.ToString();
        //            result += "," + (xs.Length > everyLen ? xs.Substring(0, everyLen) : xs);
        //        });
        //        result = result.TrimStart(',');
        //    }
        //    return result;
        //}
        //public static string Substr(string str, int Length, int startIndex = 0)
        //{
        //    if (startIndex >= 0 && str.Length > Length) return str.Substring(startIndex, Length);
        //    else return str;
        //}

        //public static bool DynamicToBoolean(dynamic dyn)//将整型动态范围转换为List<int>
        //{
        //    return dyn ?? false;
        //}


        //public static string DynStrArray2String(dynamic sArray)
        //{
        //    if (sArray == null) return "";
        //    List<string> sList = sArray.ToObject<List<string>>();
        //    var tStr = "";
        //    if (sList != null)
        //    {
        //        sList.ForEach(s =>
        //        {
        //            tStr += ",'" + s + "'";
        //        });
        //    }
        //    return tStr.TrimStart(',');
        //}

        //public static List<int> DynintrangeToList(dynamic iArray)//将整型动态范围转换为List<int>
        //{
        //    if (iArray != null)
        //    {
        //        return iArray.ToObject<List<int>>();
        //    }
        //    return null;
        //}

        //public static List<dynamic> DynrangeToList(dynamic dArray)//将动态数组转换为List<dynamic>
        //{
        //    if (dArray != null)
        //    {
        //        return dArray.ToObject<List<dynamic>>();
        //    }
        //    return null;
        //}


        //public static DateTime DynamicToDatetime(dynamic dyn)
        //{
        //    if (dyn == null) return DefaultDate;
        //    string sDate = dyn.ToString();
        //    if (string.IsNullOrEmpty(sDate)) return DefaultDate;
        //    DateTime dt = dyn;
        //    return dt;
        //}

        //public static bool DynintToBoolean(dynamic dyn)
        //{
        //    if (dyn == null || dyn <= 0) return false;
        //    return true;
        //}

        //public static string ListintToString(List<int> iList) //转换整型列表的元素为逗号字符串
        //{
        //    var result = "";
        //    if (iList != null && iList.Count > 0)
        //    {
        //        iList.ForEach(x =>
        //        {
        //            result += "," + x;
        //        });
        //        result = result.TrimStart(',');
        //    }
        //    return result;
        //}

        // public static int StringToInt(string str) //将字符串前端数字转换为数
        //{
        //    var r=Regex.Match(str, @"^\d*").Groups[0].Value;
        //    if (string.IsNullOrEmpty(r)) return 0;
        //    return Convert.ToInt32(r);
        //}

        //public static string StrToInStr(string str)//将形如"A,B,C"转换成"'A','B','C'"字符串
        //{
        //    var result = "";
        //    string[] strArray = str.Split(',');
        //    foreach(var s in strArray)
        //    {
        //        result += $",'{s}'";
        //    }
        //    return result.TrimStart(',');
        //}
    }
}
