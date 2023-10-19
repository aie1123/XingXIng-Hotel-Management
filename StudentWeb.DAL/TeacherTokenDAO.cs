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
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="teacherToken">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(TeacherToken teacherToken, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO TeacherToken(TeacherDataID, Token, ValidDateTime, RegDateTime) VALUES (@TeacherDataID, @Token, @ValidDateTime, @RegDateTime);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var teacherTokenID = conn.Query<int>(sql, teacherToken, trans).Single();
                teacherToken.TeacherTokenID = teacherTokenID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var teacherTokenID = conn.Query<int>(sql, teacherToken).Single();
                teacherToken.TeacherTokenID = teacherTokenID;
                var result = 1;
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 添加多条记录
        /// <summary>
		/// 添加多条记录
		/// </summary>
		/// <param name="list">列表</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(List<TeacherToken> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO TeacherToken(TeacherDataID, Token, ValidDateTime, RegDateTime) VALUES (@TeacherDataID, @Token, @ValidDateTime, @RegDateTime)";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, list, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, list);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 编辑单条记录
        /// <summary>
		/// 编辑单条记录
		/// </summary>
		/// <param name="teacherToken">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(TeacherToken teacherToken, IDbTransaction trans = null)
        {
            var sql = "UPDATE TeacherToken SET TeacherDataID = @TeacherDataID, Token = @Token, ValidDateTime = @ValidDateTime, RegDateTime = @RegDateTime WHERE TeacherTokenID = @TeacherTokenID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, teacherToken, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, teacherToken);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 编辑多条记录
        /// <summary>
		/// 编辑多条记录
		/// </summary>
		/// <param name="list">实体列表</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(List<TeacherToken> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE TeacherToken SET TeacherDataID = @TeacherDataID, Token = @Token, ValidDateTime = @ValidDateTime, RegDateTime = @RegDateTime WHERE TeacherTokenID = @TeacherTokenID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, list, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, list);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="teacherTokenID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int teacherTokenID, IDbTransaction trans = null)
        {
            var sql = "DELETE TeacherToken WHERE TeacherTokenID = @TeacherTokenID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { TeacherTokenID = teacherTokenID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { TeacherTokenID = teacherTokenID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="teacherToken">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(TeacherToken teacherToken, IDbTransaction trans = null)
        {
            var sql = "DELETE TeacherToken WHERE TeacherTokenID = @TeacherTokenID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, teacherToken, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, teacherToken);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="teacherTokenID">主键</param>
		/// <returns>实体</returns>
        public TeacherToken GetInfo(int teacherTokenID)
        {
            var sql = "SELECT * FROM TeacherToken WHERE TeacherTokenID = @TeacherTokenID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<TeacherToken>(sql, new { TeacherTokenID = teacherTokenID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<TeacherToken> GetList()
        {
            var sql = "SELECT * FROM TeacherToken";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<TeacherToken>(sql);
                return q.ToList();
            }
        }
        #endregion
        #region 分页列表
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="whereClause">条件语句</param>
        /// <returns>分页列表</returns>
        public PagedList<TeacherToken> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "TeacherTokenID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(TeacherTokenID) FROM TeacherToken {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM TeacherToken
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<TeacherToken>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<TeacherToken>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<TeacherToken>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// TeacherToken的数据操作类
		/// </summary>
		public TeacherTokenDAO()
		{
		}
        #endregion
	}
}

