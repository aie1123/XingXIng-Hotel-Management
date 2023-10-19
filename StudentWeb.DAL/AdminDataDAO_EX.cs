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
	/// AdminData的数据操作类
	/// </summary>
	public partial class AdminDataDAO : IAdminDataDAO
	{
        #region 获取房间表预定表入住表列表
        /// <summary>
        /// 获取房间表预定表入住表列表
        /// </summary>
        /// <returns>实体列表</returns>
        public List<RoomOrderCheckinData> GetRoomOrderCheckinList()
        {
            var sql = "SELECT * FROM RoomData,OrderData,CheckinData WHERE RoomData.RoomNumber=OrderData.RoomNumber AND " +
                "RoomData.RoomNumber=CheckinData.RoomNumber AND RoomData.RoomState=CheckinData.RoomState AND " +
                "RoomData.RoomID=CheckinData.RoomID AND OrderData.OrderID=CheckinData.OrderID AND " +
                "OrderData.CheckinDate=CheckinData.CheckinDate AND OrderData.LeaveDate=CheckinData.LeaveDate";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var q = conn.Query<RoomOrderCheckinData>(sql);
                return q.ToList();
            }
        }
        #endregion
        #region 获取单条记录 通过AdminName
        /// <summary>
        /// 获取单条记录 通过AdminName
        /// </summary>
        /// <param name="adminname">adminname</param>
        /// <returns>实体</returns>
        public AdminData GetInfoByAdminName(string adminname)
        {
            var sql = "SELECT * FROM AdminData WHERE AdminName = @AdminName";
            using (var conn = ConnectionFactory.CreateConnection())
            {
                var model = conn.QueryFirstOrDefault<AdminData>(sql, new { AdminName = adminname });
                return model;
            }
        }
        #endregion
    }
}

