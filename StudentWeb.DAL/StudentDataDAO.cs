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
	/// StudentData的数据操作类
	/// </summary>
	public partial class StudentDataDAO : IStudentDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="studentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(StudentData studentData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO StudentData(StudentNo, StudentState, StudentName, StudentMobile, StudentGrade, StudentMajor, StudentClass, StudentSex, StudentNative, StudentBirthday, RegDateTime, RegUserID, EditDateTime, EditUserID) VALUES (@StudentNo, @StudentState, @StudentName, @StudentMobile, @StudentGrade, @StudentMajor, @StudentClass, @StudentSex, @StudentNative, @StudentBirthday, @RegDateTime, @RegUserID, @EditDateTime, @EditUserID);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var studentDataID = conn.Query<int>(sql, studentData, trans).Single();
                studentData.StudentDataID = studentDataID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var studentDataID = conn.Query<int>(sql, studentData).Single();
                studentData.StudentDataID = studentDataID;
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
        public int Insert(List<StudentData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO StudentData(StudentNo, StudentState, StudentName, StudentMobile, StudentGrade, StudentMajor, StudentClass, StudentSex, StudentNative, StudentBirthday, RegDateTime, RegUserID, EditDateTime, EditUserID) VALUES (@StudentNo, @StudentState, @StudentName, @StudentMobile, @StudentGrade, @StudentMajor, @StudentClass, @StudentSex, @StudentNative, @StudentBirthday, @RegDateTime, @RegUserID, @EditDateTime, @EditUserID)";
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
		/// <param name="studentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(StudentData studentData, IDbTransaction trans = null)
        {
            var sql = "UPDATE StudentData SET StudentNo = @StudentNo, StudentState = @StudentState, StudentName = @StudentName, StudentMobile = @StudentMobile, StudentGrade = @StudentGrade, StudentMajor = @StudentMajor, StudentClass = @StudentClass, StudentSex = @StudentSex, StudentNative = @StudentNative, StudentBirthday = @StudentBirthday, RegDateTime = @RegDateTime, RegUserID = @RegUserID, EditDateTime = @EditDateTime, EditUserID = @EditUserID WHERE StudentDataID = @StudentDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, studentData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, studentData);
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
        public int Update(List<StudentData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE StudentData SET StudentNo = @StudentNo, StudentState = @StudentState, StudentName = @StudentName, StudentMobile = @StudentMobile, StudentGrade = @StudentGrade, StudentMajor = @StudentMajor, StudentClass = @StudentClass, StudentSex = @StudentSex, StudentNative = @StudentNative, StudentBirthday = @StudentBirthday, RegDateTime = @RegDateTime, RegUserID = @RegUserID, EditDateTime = @EditDateTime, EditUserID = @EditUserID WHERE StudentDataID = @StudentDataID";
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
		/// <param name="studentDataID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int studentDataID, IDbTransaction trans = null)
        {
            var sql = "DELETE StudentData WHERE StudentDataID = @StudentDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { StudentDataID = studentDataID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { StudentDataID = studentDataID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="studentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(StudentData studentData, IDbTransaction trans = null)
        {
            var sql = "DELETE StudentData WHERE StudentDataID = @StudentDataID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, studentData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, studentData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="studentDataID">主键</param>
		/// <returns>实体</returns>
        public StudentData GetInfo(int studentDataID)
        {
            var sql = "SELECT * FROM StudentData WHERE StudentDataID = @StudentDataID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<StudentData>(sql, new { StudentDataID = studentDataID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<StudentData> GetList()
        {
            var sql = "SELECT * FROM StudentData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<StudentData>(sql);
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
        public PagedList<StudentData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "StudentDataID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(StudentDataID) FROM StudentData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM StudentData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<StudentData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<StudentData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<StudentData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// StudentData的数据操作类
		/// </summary>
		public StudentDataDAO()
		{
		}
        #endregion
	}
}

