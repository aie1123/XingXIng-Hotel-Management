using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWeb.DAL;
using StudentWeb.Model;
using StudentWeb.Common;
using System.Security.Cryptography;

namespace StudentWeb.BLL
{
    public class RoomBO
    {
        #region 房间信息 分页列表
        /// <summary>
        /// 房间信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingRoomList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new RoomDataDAO().GetPagingRoomList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 房间信息 房间列表
        public IResult GetRoomList()
        {
            var list = new RoomDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 房间信息 取单条记录
        /// <summary>
        /// 房间信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetRoomInfo(int roomID)
        {
            var record = new RoomDataDAO().GetInfo(roomID);
            return new DataResult(record);
        }
        #endregion
        #region 房间信息 保存
        public bool SaveRoomInfo(dynamic data)
        {
            int roomID = data.RoomID ?? 0;
            var result = 0;
            if (roomID > 0)
            {
                var record = new RoomDataDAO().GetInfo(roomID);
                record.RoomNumber = data.RoomNumber;
                record.RoomType = data.RoomType;
                record.RoomPrice = data.RoomPrice;
                record.RoomState = data.RoomState;
                record.UserID = data.UserID;
                result = new RoomDataDAO().Update(record);
            }
            else if (roomID == 0)
            {
                var room = new RoomData()
                {
                    RoomNumber = data.RoomNumber,
                    RoomType = data.RoomType,
                    RoomPrice = data.RoomPrice,
                    RoomState = data.RoomState,
                    UserID = data.UserID,
                };
                result = new RoomDataDAO().Insert(room);
            }
            return result > 0;
        }
        #endregion
        #region 房间信息 删除
        public IResult DeleteRoomInfo(int roomID)
        {
            var res = new RoomDataDAO().Delete(roomID);
            if (res > 0)
            {
                return new DataResult(ResultCode.Success);
            }
            else
            {
                return new DataResult(ResultCode.Fail);
            }
        }
        #endregion
        #region 房间信息 根据房间状态筛选
        /// <summary>
        /// 房间信息 根据房间状态筛选
        /// </summary>
        /// <returns></returns>
        public IResult GetRoomStateInfo(string roomState)
        {
            var record = new RoomDataDAO().GetRoomStateInfo(roomState);
            return new DataResult(record);
        }
        #endregion
        #region 房间信息 根据房型返回可预定房间信息
        /// <summary>
        /// 房间信息 根据房型返回可预定房间信息
        /// </summary>
        /// <returns></returns>
        public IResult GetOrderbleRoomInfo(string roomType)
        {
            var record = new RoomDataDAO().GetOrderbleRoomInfo(roomType);
            return new DataResult(record);
        }
        #endregion
    }
}
