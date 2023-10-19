using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// PaymentData
	/// </summary>
    [Serializable]
	public class PaymentData
	{
		/// <summary>
		/// PaymentID
        /// </summary>
        [FieldName("PaymentID")]		
		public int PaymentID
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
		/// RoomType
        /// </summary>
        [FieldName("RoomType")]		
		public string RoomType
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomPrice
        /// </summary>
        [FieldName("RoomPrice")]		
		public double RoomPrice
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
        
		/// <summary>
		/// GuestPPID
        /// </summary>
        [FieldName("GuestPPID")]		
		public string GuestPPID
		{
			get;
			set;
		}
        
		/// <summary>
		/// GuestName
        /// </summary>
        [FieldName("GuestName")]		
		public string GuestName
		{
			get;
			set;
		}
        
		/// <summary>
		/// GuestPhone
        /// </summary>
        [FieldName("GuestPhone")]		
		public string GuestPhone
		{
			get;
			set;
		}
        
		/// <summary>
		/// GuestRemarks
        /// </summary>
        [FieldName("GuestRemarks")]		
		public string GuestRemarks
		{
			get;
			set;
		}
        
		/// <summary>
		/// PaymentAmount
        /// </summary>
        [FieldName("PaymentAmount")]		
		public double PaymentAmount
		{
			get;
			set;
		}
        
		/// <summary>
		/// PaymentDate
        /// </summary>
        [FieldName("PaymentDate")]		
		public DateTime PaymentDate
		{
			get;
			set;
		}
        
		/// <summary>
		/// PaymentMethod
        /// </summary>
        [FieldName("PaymentMethod")]		
		public string PaymentMethod
		{
			get;
			set;
		}
        
        public PaymentData Clone()
        {
            return (PaymentData)this.MemberwiseClone();
        }
        
        public PaymentData()
        {
            RoomNumber = string.Empty;
            RoomType = string.Empty;
            RoomState = string.Empty;
            CheckinDate = ConvertHelper.DefaultDate;
            LeaveDate = ConvertHelper.DefaultDate;
            ArriveTime = ConvertHelper.DefaultDate;
            OrderState = string.Empty;
            GuestPPID = string.Empty;
            GuestName = string.Empty;
            GuestPhone = string.Empty;
            GuestRemarks = string.Empty;
            PaymentDate = ConvertHelper.DefaultDate;
            PaymentMethod = string.Empty;
        }
	}
}
