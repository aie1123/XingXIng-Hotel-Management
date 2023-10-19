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
    public class OrderBO
    {
        #region 订单信息 分页列表
        /// <summary>
        /// 订单信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingOrderList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new OrderDataDAO().GetPagingOrderList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 订单信息 订单列表
        public IResult GetOrderList()
        {
            var list = new OrderDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 订单信息 取单条记录
        /// <summary>
        /// 订单信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetOrderInfo(int orderID)
        {
            var record = new OrderDataDAO().GetInfo(orderID);
            return new DataResult(record);
        }
        #endregion
        #region 订单信息 保存
        public bool SaveOrderInfo(dynamic data)
        {
            int orderID = data.OrderID ?? 0;
            var result = 0;
            if (orderID > 0)
            {
                var record = new OrderDataDAO().GetInfo(orderID);
                record.RoomNumber = data.RoomNumber;
                record.UserID = data.UserID;
                record.CheckinDate = data.CheckinDate;
                record.LeaveDate = data.LeaveDate;
                record.ArriveTime = data.ArriveTime;
                record.OrderState = data.OrderState;
                result = new OrderDataDAO().Update(record);
            }
            else if (orderID == 0)
            {
                var order = new OrderData()
                {
                    RoomNumber = data.RoomNumber,
                    UserID = data.UserID,
                    CheckinDate = data.CheckinDate,
                    LeaveDate = data.LeaveDate,
                    ArriveTime = data.ArriveTime,
                    OrderState = data.OrderState,
                };
                result = new OrderDataDAO().Insert(order);
            }
            return result > 0;
        }
        #endregion
        #region 订单信息 预定房间
        public bool OrderRoom(dynamic data)
        {
            var result = 0;
            var roomNumber = data.RoomNUmber;
            var order = new OrderData()
            {
                RoomNumber = data.RoomNumber,
                UserID = data.UserID,
                CheckinDate = data.CheckinDate,
                LeaveDate = data.LeaveDate,
                ArriveTime = data.ArriveTime,
                OrderState = "已预订",
            };
            result = new OrderDataDAO().Insert(order);
            return result > 0;
        }
        #endregion
        #region 订单信息 删除
        public IResult DeleteOrderInfo(int orderID)
        {
            var res = new OrderDataDAO().Delete(orderID);
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
    }
}
