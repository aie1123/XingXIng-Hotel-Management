using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// RoomInsepctionData
	/// </summary>
    [Serializable]
	public class RoomInsepctionData
	{
		/// <summary>
		/// RoominsepctionID
        /// </summary>
        [FieldName("RoominsepctionID")]		
		public int RoominsepctionID
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
		/// Satisfaction
        /// </summary>
        [FieldName("Satisfaction")]		
		public string Satisfaction
		{
			get;
			set;
		}
        
		/// <summary>
		/// Problems
        /// </summary>
        [FieldName("Problems")]		
		public string Problems
		{
			get;
			set;
		}
        
        public RoomInsepctionData Clone()
        {
            return (RoomInsepctionData)this.MemberwiseClone();
        }
        
        public RoomInsepctionData()
        {
            RoomNumber = string.Empty;
            Satisfaction = string.Empty;
            Problems = string.Empty;
        }
	}
}
