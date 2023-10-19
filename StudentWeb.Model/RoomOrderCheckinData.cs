using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// RoomData
	/// </summary>
    [Serializable]
	public class RoomOrderCheckinData
    {
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
		/// OrderID
        /// </summary>
        [FieldName("OrderID")]
        public int OrderID
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
        public TimeSpan ArriveTime
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
        /// CheckinID
        /// </summary>
        [FieldName("CheckinID")]
        public int CheckinID
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

        public RoomOrderCheckinData Clone()
        {
            return (RoomOrderCheckinData)this.MemberwiseClone();
        }
        
        public RoomOrderCheckinData()
        {
            RoomNumber = string.Empty;
            RoomType = string.Empty;
            RoomState = string.Empty;
            CheckinDate = ConvertHelper.DefaultDate;
            LeaveDate = ConvertHelper.DefaultDate;
            OrderState = string.Empty;
        }
	}
}
