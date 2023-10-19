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
	/// TeacherData的数据操作类
	/// </summary>
	public partial class TeacherDataDAO : ITeacherDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="teacherData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(TeacherData teacherData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO TeacherData(TeacherState, UserMobile, UserPassword, UserSalt, TeacherName, TeacherSex, TeacherDuty, RegDateTime, RegUserID, EditDateTime, EditUserID) VALUES (@TeacherState, @UserMobile, @UserPassword, @UserSalt, @TeacherName, @TeacherSex, @TeacherDuty, @RegDateTime, @RegUserID, @EditDateTime, @EditUserID);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var teacherDataID = conn.Query<int>(sql, teacherData, trans).Single();
                teacherData.TeacherDataID = teacherDataID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var teacherDataID = conn.Query<int>(sql, teacherData).Single();
                teacherData.TeacherDataID = teacherDataID;
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
        public int Insert(List<TeacherData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO TeacherData(TeacherState, UserMobile, UserPassword, UserSalt, TeacherName, TeacherSex, TeacherDuty, RegDateTime, RegUserID, EditDateTime, EditUserID) VALUES (@TeacherState, @UserMobile, @UserPassword, @UserSalt, @TeacherName, @TeacherSex, @TeacherDuty, @RegDateTime, @RegUserID, @EditDateTime, @EditUserID)";
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
		/// <param name="teacherData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(TeacherData teacherData, IDbTransaction trans = null)
        {
            var sql = "UPDATE TeacherData SET TeacherState = @TeacherState, UserMobile = @UserMobile, UserPassword = @UserPassword, UserSalt = @UserSalt, TeacherName = @TeacherName, TeacherSex = @TeacherSex, TeacherDuty = @TeacherDuty, RegDateTime = @RegDateTime, RegUserID = @RegUserID, EditDateTime = @EditDateTime, EditUserID = @EditUserID WHERE TeacherDataID = @TeacherDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, teacherData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, teacherData);
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
        public int Update(List<TeacherData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE TeacherData SET TeacherState = @TeacherState, UserMobile = @UserMobile, UserPassword = @UserPassword, UserSalt = @UserSalt, TeacherName = @TeacherName, TeacherSex = @TeacherSex, TeacherDuty = @TeacherDuty, RegDateTime = @RegDateTime, RegUserID = @RegUserID, EditDateTime = @EditDateTime, EditUserID = @EditUserID WHERE TeacherDataID = @TeacherDataID";
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
		/// <param name="teacherDataID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int teacherDataID, IDbTransaction trans = null)
        {
            var sql = "DELETE TeacherData WHERE TeacherDataID = @TeacherDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { TeacherDataID = teacherDataID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { TeacherDataID = teacherDataID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="teacherData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(TeacherData teacherData, IDbTransaction trans = null)
        {
            var sql = "DELETE TeacherData WHERE TeacherDataID = @TeacherDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, teacherData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, teacherData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="teacherDataID">主键</param>
		/// <returns>实体</returns>
        public TeacherData GetInfo(int teacherDataID)
        {
            var sql = "SELECT * FROM TeacherData WHERE TeacherDataID = @TeacherDataID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<TeacherData>(sql, new { TeacherDataID = teacherDataID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<TeacherData> GetList()
        {
            var sql = "SELECT * FROM TeacherData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<TeacherData>(sql);
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
        public PagedList<TeacherData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "TeacherDataID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(TeacherDataID) FROM TeacherData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM TeacherData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<TeacherData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<TeacherData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<TeacherData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// TeacherData的数据操作类
		/// </summary>
		public TeacherDataDAO()
		{
		}
        #endregion
	}
}

