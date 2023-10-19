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
	/// RoomInsepctionData的数据操作类
	/// </summary>
	public partial class RoomInsepctionDataDAO : IRoomInsepctionDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="roomInsepctionData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(RoomInsepctionData roomInsepctionData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomInsepctionData(RoomNumber, Satisfaction, Problems) VALUES (@RoomNumber, @Satisfaction, @Problems);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var roominsepctionID = conn.Query<int>(sql, roomInsepctionData, trans).Single();
                roomInsepctionData.RoominsepctionID = roominsepctionID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var roominsepctionID = conn.Query<int>(sql, roomInsepctionData).Single();
                roomInsepctionData.RoominsepctionID = roominsepctionID;
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
        public int Insert(List<RoomInsepctionData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomInsepctionData(RoomNumber, Satisfaction, Problems) VALUES (@RoomNumber, @Satisfaction, @Problems)";
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
		/// <param name="roomInsepctionData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(RoomInsepctionData roomInsepctionData, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomInsepctionData SET RoomNumber = @RoomNumber, Satisfaction = @Satisfaction, Problems = @Problems WHERE RoominsepctionID = @RoominsepctionID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomInsepctionData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomInsepctionData);
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
        public int Update(List<RoomInsepctionData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomInsepctionData SET RoomNumber = @RoomNumber, Satisfaction = @Satisfaction, Problems = @Problems WHERE RoominsepctionID = @RoominsepctionID";
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
		/// <param name="roominsepctionID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int roominsepctionID, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomInsepctionData WHERE RoominsepctionID = @RoominsepctionID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { RoominsepctionID = roominsepctionID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { RoominsepctionID = roominsepctionID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="roomInsepctionData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(RoomInsepctionData roomInsepctionData, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomInsepctionData WHERE RoominsepctionID = @RoominsepctionID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomInsepctionData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomInsepctionData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="roominsepctionID">主键</param>
		/// <returns>实体</returns>
        public RoomInsepctionData GetInfo(int roominsepctionID)
        {
            var sql = "SELECT * FROM RoomInsepctionData WHERE RoominsepctionID = @RoominsepctionID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<RoomInsepctionData>(sql, new { RoominsepctionID = roominsepctionID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<RoomInsepctionData> GetList()
        {
            var sql = "SELECT * FROM RoomInsepctionData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomInsepctionData>(sql);
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
        public PagedList<RoomInsepctionData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "RoominsepctionID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(RoominsepctionID) FROM RoomInsepctionData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM RoomInsepctionData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<RoomInsepctionData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<RoomInsepctionData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<RoomInsepctionData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// RoomInsepctionData的数据操作类
		/// </summary>
		public RoomInsepctionDataDAO()
		{
		}
        #endregion
	}
}

