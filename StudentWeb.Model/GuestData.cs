using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// GuestData
	/// </summary>
    [Serializable]
	public class GuestData
	{
		/// <summary>
		/// GuestID
        /// </summary>
        [FieldName("GuestID")]		
		public int GuestID
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
		/// GuestGender
        /// </summary>
        [FieldName("GuestGender")]		
		public string GuestGender
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
        
        public GuestData Clone()
        {
            return (GuestData)this.MemberwiseClone();
        }
        
        public GuestData()
        {
            GuestPPID = string.Empty;
            GuestName = string.Empty;
            GuestGender = string.Empty;
            GuestPhone = string.Empty;
            GuestRemarks = string.Empty;
        }
	}
}
