using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StudentWeb.DAL;
using StudentWeb.Model;
using StudentWeb.Common;
using System.Security.Cryptography;
using System.Web;

namespace StudentWeb.BLL
{
    public class RoomtypeBO
    {
        #region 房间类型信息 分页列表
        /// <summary>
        /// 房间类型信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetPagingRoomtypeList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new RoomtypeDataDAO().GetPagingRoomtypeList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 房间类型信息 房间类型列表
        public IResult GetRoomtypeList()
        {
            var list = new RoomtypeDataDAO().GetList();
            return new DataResult(list);
        }
        #endregion
        #region 房间类型信息 取单条记录
        /// <summary>
        /// 房间类型信息 取单条记录
        /// </summary>
        /// <returns></returns>
        public IResult GetRoomtypeInfo(int roomtypeID)
        {
            var record = new RoomtypeDataDAO().GetInfo(roomtypeID);
            return new DataResult(record);
        }
        #endregion
        #region 房间类型信息 保存
        public bool SaveRoomtypeInfo(dynamic data)
        {
            int roomtypeID = data.RoomTypeID ?? 0;
            var result = 0;
            if (roomtypeID > 0)
            {
                var record = new RoomtypeDataDAO().GetInfo(roomtypeID);
                record.RoomType = data.RoomType;
                record.RoomSize = data.RoomSize;
                record.RoomImage = data.RoomImage ?? "";
                record.RoomInfo = data.RoomInfo;
                record.RoomPrice = data.RoomPrice;
                result = new RoomtypeDataDAO().Update(record);
            }
            else if (roomtypeID == 0)
            {
                var roomtype = new RoomtypeData()
                {
                    RoomType = data.RoomType,
                    RoomSize = data.RoomSize,
                    RoomImage = data.RoomImage ?? "",
                    RoomInfo = data.RoomInfo,
                    RoomPrice = data.RoomPrice,
            };
                result = new RoomtypeDataDAO().Insert(roomtype);
            }
            return result > 0;
        }
        #endregion
        #region 房间类型信息 删除
        public IResult DeleteRoomtypeInfo(int roomtyppeID)
        {
            var res = new RoomtypeDataDAO().Delete(roomtyppeID);
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
        #region 房间类型信息 图片上传
        public DataResult UploadFile(HttpFileCollection files)
        {
            var res = new DataResult(null, ResultCode.Fail);
            try
            {
                var file = files["file"];
                if (file != null)
                {
                    //byte[] buffer;
                    if (file.ContentLength > 1048576 * 10) //10MB
                    {
                        return new DataResult(null, ResultCode.Fail, "文件超出大小限制");
                    }
                    var fileFolder = "/Images/"; //存放图片的文件夹
                    var filePath = HttpContext.Current.Server.MapPath(fileFolder); //存放图片的完整文件夹
                    if (!Directory.Exists(filePath)) //判断文件夹是否存在，如不存在则新创建
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string fileExt = Path.GetExtension(file.FileName); //取文件扩展名
                    var fileName = Guid.NewGuid().ToString().Replace("-", "") + fileExt; //生成随机文件名
                    var fullPath = Path.Combine(filePath, fileName); //完整路径（文件夹+文件名）
                    file.SaveAs(fullPath); //保存
                    var url = fileFolder + fileName; //图片URL地址
                    res = new DataResult(new { url });
                }
                else
                {
                    res = new DataResult(null, ResultCode.Fail);
                }
            }
            catch (Exception ex)
            {
                res = new DataResult(null, ResultCode.Fail, ex.Message);
            }
            return res;
        }
        #endregion
    }
}
