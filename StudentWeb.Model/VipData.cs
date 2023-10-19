using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// VipData
	/// </summary>
    [Serializable]
	public class VipData
	{
		/// <summary>
		/// VipID
        /// </summary>
        [FieldName("VipID")]		
		public int VipID
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipAccount
        /// </summary>
        [FieldName("VipAccount")]		
		public string VipAccount
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipName
        /// </summary>
        [FieldName("VipName")]		
		public string VipName
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipGender
        /// </summary>
        [FieldName("VipGender")]		
		public string VipGender
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipPassword
        /// </summary>
        [FieldName("VipPassword")]		
		public string VipPassword
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipPhone
        /// </summary>
        [FieldName("VipPhone")]		
		public string VipPhone
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipPPID
        /// </summary>
        [FieldName("VipPPID")]		
		public string VipPPID
		{
			get;
			set;
		}
        
		/// <summary>
		/// VipEmail
        /// </summary>
        [FieldName("VipEmail")]		
		public string VipEmail
		{
			get;
			set;
		}
        
        public VipData Clone()
        {
            return (VipData)this.MemberwiseClone();
        }
        
        public VipData()
        {
            VipAccount = string.Empty;
            VipName = string.Empty;
            VipGender = string.Empty;
            VipPassword = string.Empty;
            VipPhone = string.Empty;
            VipPPID = string.Empty;
            VipEmail = string.Empty;
        }
	}
}
