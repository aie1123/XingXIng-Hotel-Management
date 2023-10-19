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
        #region 分页列表
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="whereClause">条件语句</param>
        /// <returns>分页列表</returns>
        public PagedList<dynamic> GetStudentList(int pageIndex, int pageSize, string whereClause = null)
        {
            pageIndex--;
            string where = $@"where StudentData.StudentDataID > 0 {whereClause}";
            string orderBy = "StudentData.StudentDataID DESC";
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;
            var selFields = $@"StudentDataID, StudentNo, StudentState, StudentName, StudentMobile, StudentGrade, StudentMajor, StudentSex, StudentNative, RegDateTime";
            var tabSql = $" StudentData  {where}";
            var sql = $@"SELECT COUNT(StudentData.StudentDataID) FROM {tabSql}
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, {selFields} 
    FROM {tabSql}) AS result          
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<dynamic>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<dynamic>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<dynamic>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion

        #region 获取总数
        public int GetStudentCount()
        {
            var sql = "SELECT count(*) as StudentCount FROM StudentData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<int>(sql);
                return model;
            }
        }
        #endregion
        #region 获取分析 年龄
        public List<dynamic> GetAnalysisStudentSex()
        {
            var sql = "SELECT StudentSex as '性别', COUNT(*) AS '数量' FROM StudentData GROUP BY StudentSex";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.Query<dynamic>(sql);
                return model.ToList();
            }
        }
        #endregion
        #region 获取分析 年级
        public List<dynamic> GetAnalysisStudentGrade()
        {
            var sql = "SELECT CONVERT(varchar(10), StudentGrade) + '级' AS '年级', COUNT(*) AS '数量' FROM StudentData GROUP BY StudentGrade";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.Query<dynamic>(sql);
                return model.ToList();
            }
        }
        #endregion
        #region 获取分析 籍贯
        public List<dynamic> GetAnalysisStudentNative()
        {
            var sql = "SELECT StudentNative as '籍贯', COUNT(*) AS '数量' FROM StudentData GROUP BY StudentNative";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.Query<dynamic>(sql);
                return model.ToList();
            }
        }
        #endregion
    }
}

