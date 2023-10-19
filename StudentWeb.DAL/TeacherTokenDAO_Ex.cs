using Dapper;
using StudentWeb.IDAL;
using StudentWeb.Model;
using StudentWeb.Common;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StudentWeb.DAL
{
	/// <summary>
	/// TeacherToken的数据操作类
	/// </summary>
	public partial class TeacherTokenDAO : ITeacherTokenDAO
	{
        #region 获取单条记录 通过UserMobile
        /// <summary>
		/// 获取单条记录 通过UserMobile
		/// </summary>
		/// <param name="mobile">mobile</param>
		/// <returns>实体</returns>
        public TeacherData GetInfoByMobile(string mobile)
        {
            var sql = "SELECT * FROM TeacherData WHERE UserMobile = @UserMobile";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<TeacherData>(sql, new { UserMobile = mobile });
                return model;
            }
        }
        #endregion

        #region 获取单条记录 通过Token
        /// <summary>
		/// 获取单条记录 通过Token
		/// </summary>
		/// <param name="token">token</param>
		/// <returns>实体</returns>
        public TeacherToken GetInfoByToken(string token)
        {
            var sql = "SELECT * FROM TeacherToken WHERE Token = @Token";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<TeacherToken>(sql, new { Token = token });
                return model;
            }
        }
        #endregion
	}
}

