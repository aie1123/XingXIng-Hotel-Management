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
    public class CheckinBO
    {
        #region 入住信息 分页列表
        /// <summary>
        /// 入住信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingCheckinList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new CheckinDataDAO().GetPagingCheckinList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 入住信息  入住列表
        public IResult GetCheckinList()
        {
            var list = new CheckinDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 入住信息 取单条记录
        /// <summary>
        /// 入住信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetCheckinInfo(int checkinID)
        {
            var record = new CheckinDataDAO().GetInfo(checkinID);
            return new DataResult(record);
        }
        #endregion
        #region 入住信息 保存
        public bool SaveCheckinInfo(dynamic data)
        {
            int checkinID = data.CheckinID ?? 0;
            var result = 0;
            if (checkinID > 0)
            {
                var record = new CheckinDataDAO().GetInfo(checkinID);
                record.RoomNumber = data.RoomNumber;
                record.CheckinDate = data.CheckinDate;
                record.LeaveDate = data.LeaveDate;
                record.DayCount = data.DayCount;
                record.RoomID = data.RoomID;
                record.RoomState = data.RoomState;
                record.OrderID = data.OrderID;
                result = new CheckinDataDAO().Update(record);
            }
            else if (checkinID == 0)
            {
                var checkin = new CheckinData()
                {
                    RoomNumber = data.RoomNumber,
                    CheckinDate = data.CheckinDate,
                    LeaveDate = data.LeaveDate,
                    DayCount = data.DayCount,
                    RoomID = data.RoomID,
                    RoomState = data.RoomState,
                    OrderID = data.OrderID,
            };
                result = new CheckinDataDAO().Insert(checkin);
            }
            return result > 0;
        }
        #endregion
        #region 入住信息 删除
        public IResult DeleteCheckinInfo(int checkinID)
        {
            var res = new CheckinDataDAO().Delete(checkinID);
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
