using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// RoomData
	/// </summary>
    [Serializable]
	public class RoomData
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
		/// UserID
        /// </summary>
        [FieldName("UserID")]		
		public int? UserID
		{
			get;
			set;
		}
        
        public RoomData Clone()
        {
            return (RoomData)this.MemberwiseClone();
        }
        
        public RoomData()
        {
            RoomNumber = string.Empty;
            RoomType = string.Empty;
            RoomState = string.Empty;
        }
	}
}
