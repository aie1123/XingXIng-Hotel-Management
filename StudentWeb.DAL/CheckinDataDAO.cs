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
	/// CheckinData的数据操作类
	/// </summary>
	public partial class CheckinDataDAO : ICheckinDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="checkinData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(CheckinData checkinData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO CheckinData(RoomNumber, CheckinDate, LeaveDate, DayCount, RoomID, RoomState, OrderID) VALUES (@RoomNumber, @CheckinDate, @LeaveDate, @DayCount, @RoomID, @RoomState, @OrderID);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var checkinID = conn.Query<int>(sql, checkinData, trans).Single();
                checkinData.CheckinID = checkinID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var checkinID = conn.Query<int>(sql, checkinData).Single();
                checkinData.CheckinID = checkinID;
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
        public int Insert(List<CheckinData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO CheckinData(RoomNumber, CheckinDate, LeaveDate, DayCount, RoomID, RoomState, OrderID) VALUES (@RoomNumber, @CheckinDate, @LeaveDate, @DayCount, @RoomID, @RoomState, @OrderID)";
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
		/// <param name="checkinData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(CheckinData checkinData, IDbTransaction trans = null)
        {
            var sql = "UPDATE CheckinData SET RoomNumber = @RoomNumber, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, DayCount = @DayCount, RoomID = @RoomID, RoomState = @RoomState, OrderID = @OrderID WHERE CheckinID = @CheckinID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, checkinData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, checkinData);
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
        public int Update(List<CheckinData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE CheckinData SET RoomNumber = @RoomNumber, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, DayCount = @DayCount, RoomID = @RoomID, RoomState = @RoomState, OrderID = @OrderID WHERE CheckinID = @CheckinID";
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
		/// <param name="checkinID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int checkinID, IDbTransaction trans = null)
        {
            var sql = "DELETE CheckinData WHERE CheckinID = @CheckinID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { CheckinID = checkinID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { CheckinID = checkinID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="checkinData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(CheckinData checkinData, IDbTransaction trans = null)
        {
            var sql = "DELETE CheckinData WHERE CheckinID = @CheckinID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, checkinData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, checkinData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="checkinID">主键</param>
		/// <returns>实体</returns>
        public CheckinData GetInfo(int checkinID)
        {
            var sql = "SELECT * FROM CheckinData WHERE CheckinID = @CheckinID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<CheckinData>(sql, new { CheckinID = checkinID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<CheckinData> GetList()
        {
            var sql = "SELECT * FROM CheckinData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<CheckinData>(sql);
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
        public PagedList<CheckinData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "CheckinID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(CheckinID) FROM CheckinData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM CheckinData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<CheckinData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<CheckinData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<CheckinData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// CheckinData的数据操作类
		/// </summary>
		public CheckinDataDAO()
		{
		}
        #endregion
	}
}

