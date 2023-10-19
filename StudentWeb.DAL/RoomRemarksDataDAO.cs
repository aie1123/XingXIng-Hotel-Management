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
	/// RoomRemarksData的数据操作类
	/// </summary>
	public partial class RoomRemarksDataDAO : IRoomRemarksDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="roomRemarksData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(RoomRemarksData roomRemarksData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomRemarksData(RoomType, RoomNumber, Remarks) VALUES (@RoomType, @RoomNumber, @Remarks);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var remarksID = conn.Query<int>(sql, roomRemarksData, trans).Single();
                roomRemarksData.RemarksID = remarksID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var remarksID = conn.Query<int>(sql, roomRemarksData).Single();
                roomRemarksData.RemarksID = remarksID;
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
        public int Insert(List<RoomRemarksData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomRemarksData(RoomType, RoomNumber, Remarks) VALUES (@RoomType, @RoomNumber, @Remarks)";
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
		/// <param name="roomRemarksData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(RoomRemarksData roomRemarksData, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomRemarksData SET RoomType = @RoomType, RoomNumber = @RoomNumber, Remarks = @Remarks WHERE RemarksID = @RemarksID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomRemarksData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomRemarksData);
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
        public int Update(List<RoomRemarksData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomRemarksData SET RoomType = @RoomType, RoomNumber = @RoomNumber, Remarks = @Remarks WHERE RemarksID = @RemarksID";
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
		/// <param name="remarksID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int remarksID, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomRemarksData WHERE RemarksID = @RemarksID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { RemarksID = remarksID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { RemarksID = remarksID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="roomRemarksData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(RoomRemarksData roomRemarksData, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomRemarksData WHERE RemarksID = @RemarksID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomRemarksData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomRemarksData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="remarksID">主键</param>
		/// <returns>实体</returns>
        public RoomRemarksData GetInfo(int remarksID)
        {
            var sql = "SELECT * FROM RoomRemarksData WHERE RemarksID = @RemarksID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<RoomRemarksData>(sql, new { RemarksID = remarksID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<RoomRemarksData> GetList()
        {
            var sql = "SELECT * FROM RoomRemarksData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomRemarksData>(sql);
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
        public PagedList<RoomRemarksData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "RemarksID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(RemarksID) FROM RoomRemarksData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM RoomRemarksData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<RoomRemarksData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<RoomRemarksData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<RoomRemarksData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// RoomRemarksData的数据操作类
		/// </summary>
		public RoomRemarksDataDAO()
		{
		}
        #endregion
	}
}

