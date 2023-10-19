using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWeb.DAL;
using StudentWeb.Model;
using System.Security.Cryptography;

namespace StudentWeb.BLL
{
    public class TeacherBO
    {
        #region 用户 登录
        /// <summary>
        /// 用户 登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public IResult Login(string userMobile, string userPassword)
        {
            var teacher = new TeacherTokenDAO().GetInfoByMobile(userMobile);
            if (teacher == null)
            {
                return new Result(ResultCode.Fail, "用户名不存在");
            }
            if (teacher.TeacherState != 1)
            {
                return new Result(ResultCode.Fail, "教师状态有误");
            }
            if (teacher.UserPassword != Sha256Encrypt(teacher.UserSalt, userPassword))
            {
                return new Result(ResultCode.Fail, "密码不正确");
            }
            //登录成功后，生成Token
            string token = Guid.NewGuid().ToString("N");
            TeacherToken teacherToken = new TeacherToken
            {
                TeacherDataID = teacher.TeacherDataID,
                Token = token,
                ValidDateTime = DateTime.Now.AddDays(7),
                RegDateTime = DateTime.Now,
            };
            new TeacherTokenDAO().Insert(teacherToken);
            //向前端返回用户信息
            dynamic result = new
            {
                TeacherDataID = teacher.TeacherDataID,
                UserMobile = teacher.UserMobile,
                TeacherName = teacher.TeacherName,
                Token = token,
            };
            return new DataResult<dynamic>(result);
        }
        private static string Sha256Encrypt(string salt, string password)
        {
            SHA256Managed sha256 = new SHA256Managed();
            UTF8Encoding utf8Encode = new UTF8Encoding();
            byte[] hashData = sha256.ComputeHash(utf8Encode.GetBytes(salt + password));
            Console.WriteLine(hashData);
            sha256.Clear();
            return Convert.ToBase64String(hashData);
        }
        #endregion

        #region 教师信息 分页列表
        public IResult GetTeacherList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new TeacherDataDAO().GetTeacherList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 教师信息 单条记录
        /// <summary>
        /// 教师信息 单条记录
        /// </summary>
        /// <param name="teacherDataID"></param>
        /// <returns></returns>
        public IResult GetTeacherInfo(int teacherDataID)
        {
            var res = new TeacherDataDAO().GetInfo(teacherDataID);
            return new DataResult<TeacherData>(res);
        }
        #endregion
        #region 教师信息 通过Token找
        /// <summary>
        /// 教师信息 通过Token找
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public TeacherData GetTeacherInfo(string token)
        {
            TeacherToken tokendata = new TeacherTokenDAO().GetInfoByToken(token);
            int teacherDataID = (int)tokendata.TeacherDataID;
            var teacher = new TeacherDataDAO().GetInfo(teacherDataID);
            return teacher;
        }
        #endregion
        #region 教师信息 保存
        public bool SaveTeacherInfo(dynamic data, int userid)
        {
            int teacherID = data.TeacherDataID ?? 0;
            var result = 0;
            if (teacherID > 0)
            {
                var record = new TeacherDataDAO().GetInfo(teacherID);
                record.TeacherState = data.TeacherState;
                record.TeacherSex = data.TeacherSex;
                record.TeacherDuty = data.TeacherDuty;
                record.EditDateTime = DateTime.Now;
                record.EditUserID = userid;
                result = new TeacherDataDAO().Update(record);
            }
            else if (teacherID == 0)
            {
                string salt = Guid.NewGuid().ToString("N").Substring(0, 6);
                string pwd = data.UserPassword;
                var teacher = new TeacherData()
                {
                    TeacherState = data.TeacherState,
                    UserMobile = data.UserMobile,
                    UserPassword = Sha256Encrypt(salt, pwd),
                    UserSalt = salt,
                    TeacherName = data.TeacherName,
                    TeacherSex = data.TeacherSex,
                    TeacherDuty = data.TeacherDuty,
                    RegDateTime = DateTime.Now,
                    RegUserID = userid,
                    EditDateTime = DateTime.Now,
                    EditUserID = userid,
                };
                result = new TeacherDataDAO().Insert(teacher);
            }
            return result > 0;
        }
        #endregion

        #region 教师Token 判断token有效性
        /// <summary>
        /// 教师Token 判断token有效性
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool JudgeTokenValid(string token)
        {
            bool result = false;
            var res = new TeacherTokenDAO().GetInfoByToken(token);
            if (res != null)
            {
                if (res.ValidDateTime >= DateTime.Now)
                {
                    result = true;
                }
            }
            return result;
        }
        #endregion
        
    }
}
