using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// AdminData
	/// </summary>
    [Serializable]
	public class AdminData
	{
		/// <summary>
		/// AdminID
        /// </summary>
        [FieldName("AdminID")]		
		public int AdminID
		{
			get;
			set;
		}
        
		/// <summary>
		/// AdminName
        /// </summary>
        [FieldName("AdminName")]		
		public string AdminName
		{
			get;
			set;
		}
        
		/// <summary>
		/// AdminPassword
        /// </summary>
        [FieldName("AdminPassword")]		
		public string AdminPassword
		{
			get;
			set;
		}
        
		/// <summary>
		/// ADminNumber
        /// </summary>
        [FieldName("ADminNumber")]		
		public string ADminNumber
		{
			get;
			set;
		}
        
        public AdminData Clone()
        {
            return (AdminData)this.MemberwiseClone();
        }
        
        public AdminData()
        {
            AdminName = string.Empty;
            AdminPassword = string.Empty;
            ADminNumber = string.Empty;
        }
	}
}
