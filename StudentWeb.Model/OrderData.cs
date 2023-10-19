using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// OrderData
	/// </summary>
    [Serializable]
	public class OrderData
	{
		/// <summary>
		/// OrderID
        /// </summary>
        [FieldName("OrderID")]		
		public int OrderID
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
		/// UserID
        /// </summary>
        [FieldName("UserID")]		
		public int? UserID
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
		/// ArriveTime
        /// </summary>
        [FieldName("ArriveTime")]		
		public DateTime ArriveTime
		{
			get;
			set;
		}
        
		/// <summary>
		/// OrderState
        /// </summary>
        [FieldName("OrderState")]		
		public string OrderState
		{
			get;
			set;
		}
        
        public OrderData Clone()
        {
            return (OrderData)this.MemberwiseClone();
        }
        
        public OrderData()
        {
            RoomNumber = string.Empty;
            CheckinDate = ConvertHelper.DefaultDate;
            LeaveDate = ConvertHelper.DefaultDate;
            ArriveTime = ConvertHelper.DefaultDate;
            OrderState = string.Empty;
        }
	}
}
