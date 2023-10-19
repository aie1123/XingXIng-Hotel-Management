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
    public class RoomRemarksBO
    {
        #region 用户反馈信息 列表
        public IResult GetRoomRemarksList()
        {
            var list = new RoomRemarksDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 用户反馈信息 取单条记录
        /// <summary>
        /// 用户反馈信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetRoomRemarksInfo(int remarksID)
        {
            var record = new RoomRemarksDataDAO().GetInfo(remarksID);
            return new DataResult(record);
        }
        #endregion
        #region 用户反馈信息 保存
        public bool SaveRoomRemarksInfo(dynamic data)
        {
            int remarksID = data.RemarksID ?? 0;
            var result = 0;
            if (remarksID > 0)
            {
                var record = new RoomRemarksDataDAO().GetInfo(remarksID);
                record.RoomType = data.RoomType;
                record.RoomNumber = data.RoomNumber;
                record.Remarks = data.Remarks;
                result = new RoomRemarksDataDAO().Update(record);
            }
            else if (remarksID == 0)
            {
                var roomremarks = new RoomRemarksData()
                {
                    RoomType = data.RoomType,
                    RoomNumber = data.RoomNumber,
                    Remarks = data.Remarks,
            };
                result = new RoomRemarksDataDAO().Insert(roomremarks);
            }
            return result > 0;
        }
        #endregion
        #region 用户反馈信息 删除
        public IResult DeleteRoomRemarksInfo(int remarksID)
        {
            var res = new RoomRemarksDataDAO().Delete(remarksID);
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
