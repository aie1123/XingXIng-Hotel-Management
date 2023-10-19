using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// RoomtypeData
	/// </summary>
    [Serializable]
	public class RoomtypeData
	{
		/// <summary>
		/// RoomTypeID
        /// </summary>
        [FieldName("RoomTypeID")]		
		public int RoomTypeID
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
		/// RoomSize
        /// </summary>
        [FieldName("RoomSize")]		
		public int? RoomSize
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomImage
        /// </summary>
        [FieldName("RoomImage")]		
		public string RoomImage
		{
			get;
			set;
		}
        
		/// <summary>
		/// RoomInfo
        /// </summary>
        [FieldName("RoomInfo")]		
		public string RoomInfo
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
        
        public RoomtypeData Clone()
        {
            return (RoomtypeData)this.MemberwiseClone();
        }
        
        public RoomtypeData()
        {
            RoomType = string.Empty;
            RoomImage = string.Empty;
            RoomInfo = string.Empty;
        }
	}
}
