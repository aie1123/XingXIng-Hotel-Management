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
	/// RoomData的数据操作类
	/// </summary>
	public partial class RoomDataDAO : IRoomDataDAO
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
        public PagedList<dynamic> GetPagingRoomList(int pageIndex, int pageSize, string whereClause = null)
        {
            pageIndex--;
            string where = $@"where RoomData.RoomID > 0 {whereClause}";
            string orderBy = "RoomData.RoomID DESC";
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;
            var selFields = $@"RoomID, RoomNumber, RoomType, RoomPrice, RoomState, UserID";
            var tabSql = $" RoomData  {where}";
            var sql = $@"SELECT COUNT(RoomData.RoomID) FROM {tabSql}
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
        #region 根据房间状态筛选
        /// <summary>
        /// 根据房间状态筛选
        /// </summary>
        /// <param name="roomState"></param>
        /// <returns>实体</returns>
        public List<RoomData> GetRoomStateInfo(string roomState)
        {
            var sql = "SELECT * FROM RoomData WHERE RoomState = @RoomState";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomData>(sql, new { RoomState = roomState });
                return q.ToList();
            }
        }
        #endregion
        #region 根据房型返回可预定房间信息
        /// <summary>
        /// 根据房型返回可预定房间信息
        /// </summary>
        /// <param name="roomType"></param>
        /// <returns>实体</returns>
        public List<RoomData> GetOrderbleRoomInfo(string roomType)
        {
            var sql = "SELECT * FROM RoomData WHERE RoomType = @RoomType and RoomState = '空闲'";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomData>(sql, new { RoomType = roomType });
                return q.ToList();
            }
        }
        #endregion
    }
}

