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
    public class PaymentBO
    {
        #region 结帐信息 分页列表
        /// <summary>
        /// 结帐信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingPaymentList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new PaymentDataDAO().GetPagingPaymentList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 结帐信息  入住列表
        public IResult GetPaymentList()
        {
            var list = new PaymentDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 结帐信息 取单条记录
        /// <summary>
        /// 结帐信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetPaymentInfo(int paymentID)
        {
            var record = new PaymentDataDAO().GetInfo(paymentID);
            return new DataResult(record);
        }
        #endregion
        #region 结帐信息 保存
        public bool SavePaymentInfo(dynamic data)
        {
            int paymentID = data.PaymentID ?? 0;
            var result = 0;
            if (paymentID > 0)
            {
                var record = new PaymentDataDAO().GetInfo(paymentID);
                record.RoomNumber= data.RoomNumber;
                record.RoomType = data.RoomType;
                record.RoomPrice = data.RoomPrice;
                record.RoomState = data.RoomState;
                record.CheckinDate = data.CheckinDate;
                record.LeaveDate = data.LeaveDate;
                record.ArriveTime = data.ArriveTime;
                record.OrderState = data.OrderState;
                record.GuestPPID = data.GuestPPID;
                record.GuestName = data.GuestName;
                record.GuestPhone = data.GuestPhone;
                record.GuestRemarks = data.GuestRemarks;
                record.PaymentAmount = data.PaymentAmount;
                record.PaymentDate = data.PaymentDate;
                record.PaymentMethod = data.PaymentMethod;
                result = new PaymentDataDAO().Update(record);
            }
            else if (paymentID == 0)
            {
                var payment = new PaymentData()
                {
                    RoomNumber = data.RoomNumber,
                    RoomType = data.RoomType,
                    RoomPrice = data.RoomPrice,
                    RoomState = data.RoomState,
                    CheckinDate = data.CheckinDate,
                    LeaveDate = data.LeaveDate,
                    ArriveTime = data.ArriveTime,
                    OrderState = data.OrderState,
                    GuestPPID = data.GuestPPID,
                    GuestName = data.GuestName,
                    GuestPhone = data.GuestPhone,
                    GuestRemarks = data.GuestRemarks,
                    PaymentAmount = data.PaymentAmount,
                    PaymentDate = DateTime.Now,
                    PaymentMethod = data.PaymentMethod
            };
                result = new PaymentDataDAO().Insert(payment);
            }
            return result > 0;
        }
        #endregion
        #region 结帐信息 删除
        public IResult DeletePaymentInfo(int paymentID)
        {
            var res = new PaymentDataDAO().Delete(paymentID);
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
