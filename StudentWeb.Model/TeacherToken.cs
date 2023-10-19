using System;
using StudentWeb.Common;

namespace StudentWeb.Model
{
	/// <summary>
	/// TeacherToken
	/// </summary>
    [Serializable]
	public class TeacherToken
	{
		/// <summary>
		/// TeacherTokenID
        /// </summary>
        [FieldName("TeacherTokenID")]		
		public int TeacherTokenID
		{
			get;
			set;
		}
        
		/// <summary>
		/// TeacherDataID
        /// </summary>
        [FieldName("TeacherDataID")]		
		public int? TeacherDataID
		{
			get;
			set;
		}
        
		/// <summary>
		/// Token
        /// </summary>
        [FieldName("Token")]		
		public string Token
		{
			get;
			set;
		}
        
		/// <summary>
		/// ValidDateTime
        /// </summary>
        [FieldName("ValidDateTime")]		
		public DateTime ValidDateTime
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
        
        public TeacherToken Clone()
        {
            return (TeacherToken)this.MemberwiseClone();
        }
        
        public TeacherToken()
        {
            Token = string.Empty;
            ValidDateTime = ConvertHelper.DefaultDate;
            RegDateTime = ConvertHelper.DefaultDate;
        }
	}
}
