using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// StudentData
	/// </summary>
    [Serializable]
	public class StudentData
	{
		/// <summary>
		/// StudentDataID
        /// </summary>
        [FieldName("StudentDataID")]		
		public int StudentDataID
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentNo
        /// </summary>
        [FieldName("StudentNo")]		
		public string StudentNo
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentState
        /// </summary>
        [FieldName("StudentState")]		
		public int? StudentState
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentName
        /// </summary>
        [FieldName("StudentName")]		
		public string StudentName
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentMobile
        /// </summary>
        [FieldName("StudentMobile")]		
		public string StudentMobile
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentGrade
        /// </summary>
        [FieldName("StudentGrade")]		
		public int? StudentGrade
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentMajor
        /// </summary>
        [FieldName("StudentMajor")]		
		public string StudentMajor
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentClass
        /// </summary>
        [FieldName("StudentClass")]		
		public string StudentClass
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentSex
        /// </summary>
        [FieldName("StudentSex")]		
		public string StudentSex
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentNative
        /// </summary>
        [FieldName("StudentNative")]		
		public string StudentNative
		{
			get;
			set;
		}
        
		/// <summary>
		/// StudentBirthday
        /// </summary>
        [FieldName("StudentBirthday")]		
		public DateTime StudentBirthday
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
        
        public StudentData Clone()
        {
            return (StudentData)this.MemberwiseClone();
        }
        
        public StudentData()
        {
            StudentNo = string.Empty;
            StudentName = string.Empty;
            StudentMobile = string.Empty;
            StudentMajor = string.Empty;
            StudentClass = string.Empty;
            StudentSex = string.Empty;
            StudentNative = string.Empty;
            StudentBirthday = ConvertHelper.DefaultDate;
            RegDateTime = ConvertHelper.DefaultDate;
            EditDateTime = ConvertHelper.DefaultDate;
        }
	}
}
