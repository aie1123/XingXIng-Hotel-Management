using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// UserData
	/// </summary>
    [Serializable]
	public class UserData
	{
		/// <summary>
		/// UserID
        /// </summary>
        [FieldName("UserID")]		
		public int UserID
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserAccount
        /// </summary>
        [FieldName("UserAccount")]		
		public string UserAccount
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserGender
        /// </summary>
        [FieldName("UserGender")]		
		public string UserGender
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserName
        /// </summary>
        [FieldName("UserName")]		
		public string UserName
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserPassword
        /// </summary>
        [FieldName("UserPassword")]		
		public string UserPassword
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserPhone
        /// </summary>
        [FieldName("UserPhone")]		
		public string UserPhone
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserAvatar
        /// </summary>
        [FieldName("UserAvatar")]		
		public string UserAvatar
		{
			get;
			set;
		}
        
        public UserData Clone()
        {
            return (UserData)this.MemberwiseClone();
        }
        
        public UserData()
        {
            UserAccount = string.Empty;
            UserGender = string.Empty;
            UserName = string.Empty;
            UserPassword = string.Empty;
            UserPhone = string.Empty;
            UserAvatar = string.Empty;
        }
	}
}
