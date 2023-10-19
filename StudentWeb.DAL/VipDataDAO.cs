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
	/// VipData的数据操作类
	/// </summary>
	public partial class VipDataDAO : IVipDataDAO
	{
        #region 添加单条记录
        /// <summary>
		/// 添加单条记录
		/// </summary>
		/// <param name="vipData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Insert(VipData vipData, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO VipData(VipAccount, VipName, VipGender, VipPassword, VipPhone, VipPPID, VipEmail) VALUES (@VipAccount, @VipName, @VipGender, @VipPassword, @VipPhone, @VipPPID, @VipEmail);SELECT CAST(SCOPE_IDENTITY() AS int)";

            if (trans != null)
            {
                var conn = trans.Connection;
                var vipID = conn.Query<int>(sql, vipData, trans).Single();
                vipData.VipID = vipID;
                var result = 1;
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                var vipID = conn.Query<int>(sql, vipData).Single();
                vipData.VipID = vipID;
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
        public int Insert(List<VipData> list, IDbTransaction trans = null)
        {
            var sql = "INSERT INTO VipData(VipAccount, VipName, VipGender, VipPassword, VipPhone, VipPPID, VipEmail) VALUES (@VipAccount, @VipName, @VipGender, @VipPassword, @VipPhone, @VipPPID, @VipEmail)";
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
		/// <param name="vipData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Update(VipData vipData, IDbTransaction trans = null)
        {
            var sql = "UPDATE VipData SET VipAccount = @VipAccount, VipName = @VipName, VipGender = @VipGender, VipPassword = @VipPassword, VipPhone = @VipPhone, VipPPID = @VipPPID, VipEmail = @VipEmail WHERE VipID = @VipID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, vipData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, vipData);
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
        public int Update(List<VipData> list, IDbTransaction trans = null)
        {
            var sql = "UPDATE VipData SET VipAccount = @VipAccount, VipName = @VipName, VipGender = @VipGender, VipPassword = @VipPassword, VipPhone = @VipPhone, VipPPID = @VipPPID, VipEmail = @VipEmail WHERE VipID = @VipID";
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
		/// <param name="vipID">主键</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(int vipID, IDbTransaction trans = null)
        {
            var sql = "DELETE VipData WHERE VipID = @VipID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, new { VipID = vipID }, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, new { VipID = vipID });
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 删除单条记录
        /// <summary>
		/// 删除单条记录
		/// </summary>
		/// <param name="vipData">实体</param>
        /// <param name="trans">事务</param>
		/// <returns>影响行数</returns>
        public int Delete(VipData vipData, IDbTransaction trans = null)
        {
            var sql = "DELETE VipData WHERE VipID = @VipID";
            var result = 0;
            if (trans != null)
            {
                var conn = trans.Connection;
                result = conn.Execute(sql, vipData, trans);
                return result;
            }
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                result = conn.Execute(sql, vipData);
                conn.Close();
                return result;
            }
        }
        #endregion
        #region 获取单条记录
        /// <summary>
		/// 获取单条记录
		/// </summary>
		/// <param name="vipID">主键</param>
		/// <returns>实体</returns>
        public VipData GetInfo(int vipID)
        {
            var sql = "SELECT * FROM VipData WHERE VipID = @VipID";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<VipData>(sql, new { VipID = vipID });
                return model;
            }
        }
        #endregion
        #region 获取全部记录列表
        /// <summary>
		/// 获取全部记录列表
		/// </summary>
		/// <returns>实体列表</returns>
        public List<VipData> GetList()
        {
            var sql = "SELECT * FROM VipData";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<VipData>(sql);
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
        public PagedList<VipData> GetList(int pageIndex, int pageSize, string whereClause = null, string orderBy = null)
        {
            pageIndex--;
            if (!string.IsNullOrEmpty(whereClause))
            {
                whereClause = " WHERE " + whereClause;
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                orderBy = "VipID DESC";
            }
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;

            var sql = $@"SELECT COUNT(VipID) FROM VipData {whereClause} 
SELECT *
FROM(SELECT ROW_NUMBER() OVER(ORDER BY {orderBy}) AS RowNum, *
          FROM VipData
          {whereClause}
        ) AS result
WHERE RowNum >= {startItem}
    AND RowNum <= {endItem}
ORDER BY RowNum";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                conn.Open();
                int count = 0;
                var list = new List<VipData>();
                using (var q = conn.QueryMultiple(sql))
                {
                    count = q.Read<int>().Single();
                    list = q.Read<VipData>().ToList();
                }
                conn.Close();

                var pagedList = new PagedList<VipData>(list, pageIndex, pageSize, count);
                return pagedList;
            }
        }
        #endregion
        #region 数据操作类
		/// <summary>
		/// VipData的数据操作类
		/// </summary>
		public VipDataDAO()
		{
		}
        #endregion
	}
}

