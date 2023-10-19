using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// TeacherData
	/// </summary>
    [Serializable]
	public class TeacherData
	{
		/// <summary>
		/// TeacherDataID
        /// </summary>
        [FieldName("TeacherDataID")]		
		public int TeacherDataID
		{
			get;
			set;
		}
        
		/// <summary>
		/// TeacherState
        /// </summary>
        [FieldName("TeacherState")]		
		public int? TeacherState
		{
			get;
			set;
		}
        
		/// <summary>
		/// UserMobile
        /// </summary>
        [FieldName("UserMobile")]		
		public string UserMobile
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
		/// UserSalt
        /// </summary>
        [FieldName("UserSalt")]		
		public string UserSalt
		{
			get;
			set;
		}
        
		/// <summary>
		/// TeacherName
        /// </summary>
        [FieldName("TeacherName")]		
		public string TeacherName
		{
			get;
			set;
		}
        
		/// <summary>
		/// TeacherSex
        /// </summary>
        [FieldName("TeacherSex")]		
		public string TeacherSex
		{
			get;
			set;
		}
        
		/// <summary>
		/// TeacherDuty
        /// </summary>
        [FieldName("TeacherDuty")]		
		public string TeacherDuty
		{
			get;
			set;
		}
        
		/// <summary>
		/// RegDateTime
        /// </summary>
        [FieldName("RegDateTime")]		
		public DateTime RegDateTime
		{
			get;
			set;
		}
        
		/// <summary>
		/// RegUserID
        /// </summary>
        [FieldName("RegUserID")]		
		public int? RegUserID
		{
			get;
			set;
		}
        
		/// <summary>
		/// EditDateTime
        /// </summary>
        [FieldName("EditDateTime")]		
		public DateTime EditDateTime
		{
			get;
			set;
		}
        
		/// <summary>
		/// EditUserID
        /// </summary>
        [FieldName("EditUserID")]		
		public int? EditUserID
		{
			get;
			set;
		}
        
        public TeacherData Clone()
        {
            return (TeacherData)this.MemberwiseClone();
        }
        
        public TeacherData()
        {
            UserMobile = string.Empty;
            UserPassword = string.Empty;
            UserSalt = string.Empty;
            TeacherName = string.Empty;
            TeacherSex = string.Empty;
            TeacherDuty = string.Empty;
            RegDateTime = ConvertHelper.DefaultDate;
            EditDateTime = ConvertHelper.DefaultDate;
        }
	}
}
