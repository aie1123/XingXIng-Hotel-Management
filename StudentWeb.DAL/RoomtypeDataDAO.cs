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
	/// RoomtypeData的数据操作类
	/// </summary>
	public partial class RoomtypeDataDAO : IRoomtypeDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="roomtypeData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(RoomtypeData roomtypeData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomtypeData(RoomType, RoomSize, RoomImage, RoomInfo, RoomPrice) VALUES (@RoomType, @RoomSize, @RoomImage, @RoomInfo, @RoomPrice);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var roomTypeID = conn.Query<int>(sql, roomtypeData, trans).Single();
                roomtypeData.RoomTypeID = roomTypeID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var roomTypeID = conn.Query<int>(sql, roomtypeData).Single();
                roomtypeData.RoomTypeID = roomTypeID;
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
        public int Insert(List<RoomtypeData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO RoomtypeData(RoomType, RoomSize, RoomImage, RoomInfo, RoomPrice) VALUES (@RoomType, @RoomSize, @RoomImage, @RoomInfo, @RoomPrice)";
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
		/// <param name="roomtypeData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(RoomtypeData roomtypeData, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomtypeData SET RoomType = @RoomType, RoomSize = @RoomSize, RoomImage = @RoomImage, RoomInfo = @RoomInfo, RoomPrice = @RoomPrice WHERE RoomTypeID = @RoomTypeID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomtypeData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomtypeData);
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
        public int Update(List<RoomtypeData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE RoomtypeData SET RoomType = @RoomType, RoomSize = @RoomSize, RoomImage = @RoomImage, RoomInfo = @RoomInfo, RoomPrice = @RoomPrice WHERE RoomTypeID = @RoomTypeID";
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
		/// <param name="roomTypeID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int roomTypeID, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomtypeData WHERE RoomTypeID = @RoomTypeID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { RoomTypeID = roomTypeID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { RoomTypeID = roomTypeID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="roomtypeData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(RoomtypeData roomtypeData, IDbTransaction trans = null)
        {
            var sql = "DELETE RoomtypeData WHERE RoomTypeID = @RoomTypeID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, roomtypeData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, roomtypeData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="roomTypeID">主键</param>
		/// <returns>实体</returns>
        public RoomtypeData GetInfo(int roomTypeID)
        {
            var sql = "SELECT * FROM RoomtypeData WHERE RoomTypeID = @RoomTypeID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<RoomtypeData>(sql, new { RoomTypeID = roomTypeID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<RoomtypeData> GetList()
        {
            var sql = "SELECT * FROM RoomtypeData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomtypeData>(sql);
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
        public PagedList<RoomtypeData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "RoomTypeID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(RoomTypeID) FROM RoomtypeData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM RoomtypeData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<RoomtypeData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<RoomtypeData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<RoomtypeData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// RoomtypeData的数据操作类
		/// </summary>
		public RoomtypeDataDAO()
		{
		}
        #endregion
	}
}

