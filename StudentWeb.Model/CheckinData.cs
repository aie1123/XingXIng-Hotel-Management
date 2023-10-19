using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// CheckinData
	/// </summary>
    [Serializable]
	public class CheckinData
	{
		/// <summary>
		/// CheckinID
        /// </summary>
        [FieldName("CheckinID")]		
		public int CheckinID
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
		/// CheckinDate
        /// </summary>
        [FieldName("CheckinDate")]		
		public DateTime CheckinDate
		{
			get;
			set;
		}
        
		/// <summary>
		/// LeaveDate
        /// </summary>
        [FieldName("LeaveDate")]		
		public DateTime LeaveDate
		{
			get;
			set;
		}
        
		/// <summary>
		/// DayCount
        /// </summary>
        [FieldName("DayCount")]		
		public int? DayCount
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomID
        /// </summary>
        [FieldName("RoomID")]		
		public int RoomID
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomState
        /// </summary>
        [FieldName("RoomState")]		
		public string RoomState
		{
			get;
			set;
		}
        
		/// <summary>
		/// OrderID
        /// </summary>
        [FieldName("OrderID")]		
		public int OrderID
		{
			get;
			set;
		}
        
        public CheckinData Clone()
        {
            return (CheckinData)this.MemberwiseClone();
        }
        
        public CheckinData()
        {
            RoomNumber = string.Empty;
            CheckinDate = ConvertHelper.DefaultDate;
            LeaveDate = ConvertHelper.DefaultDate;
            RoomState = string.Empty;
        }
	}
}
