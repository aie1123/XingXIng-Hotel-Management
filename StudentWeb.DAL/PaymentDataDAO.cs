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
	/// PaymentData的数据操作类
	/// </summary>
	public partial class PaymentDataDAO : IPaymentDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="paymentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(PaymentData paymentData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO PaymentData(RoomNumber, RoomType, RoomPrice, RoomState, CheckinDate, LeaveDate, ArriveTime, OrderState, GuestPPID, GuestName, GuestPhone, GuestRemarks, PaymentAmount, PaymentDate, PaymentMethod) VALUES (@RoomNumber, @RoomType, @RoomPrice, @RoomState, @CheckinDate, @LeaveDate, @ArriveTime, @OrderState, @GuestPPID, @GuestName, @GuestPhone, @GuestRemarks, @PaymentAmount, @PaymentDate, @PaymentMethod);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var paymentID = conn.Query<int>(sql, paymentData, trans).Single();
                paymentData.PaymentID = paymentID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var paymentID = conn.Query<int>(sql, paymentData).Single();
                paymentData.PaymentID = paymentID;
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
        public int Insert(List<PaymentData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO PaymentData(RoomNumber, RoomType, RoomPrice, RoomState, CheckinDate, LeaveDate, ArriveTime, OrderState, GuestPPID, GuestName, GuestPhone, GuestRemarks, PaymentAmount, PaymentDate, PaymentMethod) VALUES (@RoomNumber, @RoomType, @RoomPrice, @RoomState, @CheckinDate, @LeaveDate, @ArriveTime, @OrderState, @GuestPPID, @GuestName, @GuestPhone, @GuestRemarks, @PaymentAmount, @PaymentDate, @PaymentMethod)";
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
		/// <param name="paymentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(PaymentData paymentData, IDbTransaction trans = null)
        {
            var sql = "UPDATE PaymentData SET RoomNumber = @RoomNumber, RoomType = @RoomType, RoomPrice = @RoomPrice, RoomState = @RoomState, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, ArriveTime = @ArriveTime, OrderState = @OrderState, GuestPPID = @GuestPPID, GuestName = @GuestName, GuestPhone = @GuestPhone, GuestRemarks = @GuestRemarks, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, PaymentMethod = @PaymentMethod WHERE PaymentID = @PaymentID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, paymentData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, paymentData);
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
        public int Update(List<PaymentData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE PaymentData SET RoomNumber = @RoomNumber, RoomType = @RoomType, RoomPrice = @RoomPrice, RoomState = @RoomState, CheckinDate = @CheckinDate, LeaveDate = @LeaveDate, ArriveTime = @ArriveTime, OrderState = @OrderState, GuestPPID = @GuestPPID, GuestName = @GuestName, GuestPhone = @GuestPhone, GuestRemarks = @GuestRemarks, PaymentAmount = @PaymentAmount, PaymentDate = @PaymentDate, PaymentMethod = @PaymentMethod WHERE PaymentID = @PaymentID";
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
		/// <param name="paymentID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int paymentID, IDbTransaction trans = null)
        {
            var sql = "DELETE PaymentData WHERE PaymentID = @PaymentID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { PaymentID = paymentID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { PaymentID = paymentID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="paymentData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(PaymentData paymentData, IDbTransaction trans = null)
        {
            var sql = "DELETE PaymentData WHERE PaymentID = @PaymentID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, paymentData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, paymentData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="paymentID">主键</param>
		/// <returns>实体</returns>
        public PaymentData GetInfo(int paymentID)
        {
            var sql = "SELECT * FROM PaymentData WHERE PaymentID = @PaymentID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<PaymentData>(sql, new { PaymentID = paymentID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<PaymentData> GetList()
        {
            var sql = "SELECT * FROM PaymentData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<PaymentData>(sql);
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
        public PagedList<PaymentData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "PaymentID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(PaymentID) FROM PaymentData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM PaymentData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<PaymentData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<PaymentData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<PaymentData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// PaymentData的数据操作类
		/// </summary>
		public PaymentDataDAO()
		{
		}
        #endregion
	}
}

