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
    public class GuestBO
    {
        #region 住客信息 分页列表
        /// <summary>
        /// 住客信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingGuestList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new GuestDataDAO().GetPagingGuestList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 住客信息 住客列表
        public IResult GetGuestList()
        {
            var list = new GuestDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 住客信息 取单条记录
        /// <summary>
        /// 住客信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetGuestInfo(int guestID)
        {
            var record = new GuestDataDAO().GetInfo(guestID);
            return new DataResult(record);
        }
        #endregion
        #region 住客信息 保存
        public bool SaveGuestInfo(dynamic data)
        {
            int guestID = data.GuestID ?? 0;
            var result = 0;
            if (guestID > 0)
            {
                var record = new GuestDataDAO().GetInfo(guestID);
                record.GuestPPID = data.GuestPPID;
                record.GuestName = data.GuestName;
                record.GuestGender = data.GuestGender;
                record.GuestPhone = data.GuestPhone;
                record.GuestRemarks = data.GuestRemarks;
                result = new GuestDataDAO().Update(record);
            }
            else if (guestID == 0)
            {
                var guest = new GuestData()
                {
                    GuestPPID = data.GuestPPID,
                    GuestName = data.GuestName,
                    GuestGender = data.GuestGender,
                    GuestPhone = data.GuestPhone,
                    GuestRemarks = data.GuestRemarks,
            };
                result = new GuestDataDAO().Insert(guest);
            }
            return result > 0;
        }
        #endregion
        #region 住客信息 删除
        public IResult DeleteGuestInfo(int guestID)
        {
            var res = new GuestDataDAO().Delete(guestID);
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
