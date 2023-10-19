using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// RoomRemarksData
	/// </summary>
    [Serializable]
	public class RoomRemarksData
	{
		/// <summary>
		/// RemarksID
        /// </summary>
        [FieldName("RemarksID")]		
		public int RemarksID
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomType
        /// </summary>
        [FieldName("RoomType")]		
		public string RoomType
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomNumber
        /// </summary>
        [FieldName("RoomNumber")]		
		public string RoomNumber
		{
			get;
			set;
		}
        
		/// <summary>
		/// Remarks
        /// </summary>
        [FieldName("Remarks")]		
		public string Remarks
		{
			get;
			set;
		}
        
        public RoomRemarksData Clone()
        {
            return (RoomRemarksData)this.MemberwiseClone();
        }
        
        public RoomRemarksData()
        {
            RoomType = string.Empty;
            RoomNumber = string.Empty;
            Remarks = string.Empty;
        }
	}
}
