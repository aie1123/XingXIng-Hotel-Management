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
        #region 分页列表
        /// <summary>
        /// 分页列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="orderBy">排序规则</param>
        /// <param name="whereClause">条件语句</param>
        /// <returns>分页列表</returns>
        public PagedList<dynamic> GetPagingRoomtypeList(int pageIndex, int pageSize, string whereClause = null)
        {
            pageIndex--;
            string where = $@"where RoomtypeData.RoomTypeID > 0 {whereClause}";
            string orderBy = "RoomtypeData.RoomTypeID DESC";
            var startItem = pageIndex * pageSize + 1;
            var endItem = (pageIndex + 1) * pageSize;
            var selFields = $@"RoomTypeID, RoomType, RoomSize, RoomImage, RoomInfo, RoomPrice";
            var tabSql = $" RoomtypeData  {where}";
            var sql = $@"SELECT COUNT(RoomtypeData.RoomTypeID) FROM {tabSql}
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
    }
}

