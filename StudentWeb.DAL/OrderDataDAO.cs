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
	/// OrderData的数据操作类
	/// </summary>
	public partial class OrderDataDAO : IOrderDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="orderData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(OrderData orderData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO OrderData(RoomNumber, UserID, CheckinDate, LeaveDate, ArriveTime, OrderState) VALUES (@RoomNumber, @UserID, @CheckinDate, @LeaveDate, @ArriveTime, @OrderState);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var orderID = conn.Query<int>(sql, orderData, trans).Single();
                orderData.OrderID = orderID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var orderID = conn.Query<int>(sql, orderData).Single();
                orderData.OrderID = orderID;
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
        public int Insert(List<OrderData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO OrderData(RoomNumber, UserID, CheckinDate, LeaveDate, ArriveTime, OrderState) VALUES (@RoomNumber, @UserID, @CheckinDate, @LeaveDate, @ArriveTime, @OrderState)";
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
		/// <param name="orderData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(OrderData orderData, IDbTransaction trans = null)
        {
            var sql = "UPDATE OrderData SET RoomNumber = @RoomNumber, UserID = @UserID, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, ArriveTime = @ArriveTime, OrderState = @OrderState WHERE OrderID = @OrderID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, orderData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, orderData);
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
        public int Update(List<OrderData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE OrderData SET RoomNumber = @RoomNumber, UserID = @UserID, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, ArriveTime = @ArriveTime, OrderState = @OrderState WHERE OrderID = @OrderID";
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
		/// <param name="orderID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int orderID, IDbTransaction trans = null)
        {
            var sql = "DELETE OrderData WHERE OrderID = @OrderID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { OrderID = orderID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { OrderID = orderID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="orderData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(OrderData orderData, IDbTransaction trans = null)
        {
            var sql = "DELETE OrderData WHERE OrderID = @OrderID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, orderData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, orderData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="orderID">主键</param>
		/// <returns>实体</returns>
        public OrderData GetInfo(int orderID)
        {
            var sql = "SELECT * FROM OrderData WHERE OrderID = @OrderID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<OrderData>(sql, new { OrderID = orderID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<OrderData> GetList()
        {
            var sql = "SELECT * FROM OrderData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<OrderData>(sql);
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
        public PagedList<OrderData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "OrderID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(OrderID) FROM OrderData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM OrderData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<OrderData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<OrderData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<OrderData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// OrderData的数据操作类
		/// </summary>
		public OrderDataDAO()
		{
		}
        #endregion
	}
}

