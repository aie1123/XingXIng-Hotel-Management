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
    public class RoomInsepctionBO
    {
        #region 客房巡查信息 分页列表
        /// <summary>
        /// 客房巡查信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingRoomInsepctionList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new RoomInsepctionDataDAO().GetPagingRoomInsepctionList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 客房巡查信息 客房巡查列表
        public IResult GetRoomInsepctionList()
        {
            var list = new RoomInsepctionDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 客房巡查信息 取单条记录
        /// <summary>
        /// 客房巡查信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetRoomInsepctionInfo(int roominsepctionID)
        {
            var record = new RoomInsepctionDataDAO().GetInfo(roominsepctionID);
            return new DataResult(record);
        }
        #endregion
        #region 客房巡查信息 保存
        public bool SaveRoomInsepctionInfo(dynamic data)
        {
            int roominsepctionID = data.RoominsepctionID ?? 0;
            var result = 0;
            if (roominsepctionID > 0)
            {
                var record = new RoomInsepctionDataDAO().GetInfo(roominsepctionID);
                record.RoomNumber = data.RoomNumber;
                record.Satisfaction = data.Satisfaction;
                record.Problems = data.Problems;
                result = new RoomInsepctionDataDAO().Update(record);
            }
            else if (roominsepctionID == 0)
            {
                var roominsepction = new RoomInsepctionData()
                {
                    RoomNumber = data.RoomNumber,
                    Satisfaction = data.Satisfaction,
                    Problems = data.Problems,
            };
                result = new RoomInsepctionDataDAO().Insert(roominsepction);
            }
            return result > 0;
        }
        #endregion
        #region 客房巡查信息 删除
        public IResult DeleteRoomInsepctionInfo(int roominsepctionID)
        {
            var res = new RoomInsepctionDataDAO().Delete(roominsepctionID);
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
