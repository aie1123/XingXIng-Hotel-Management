using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentWeb.DAL;
using StudentWeb.Model;
using StudentWeb.Common;

namespace StudentWeb.BLL
{
    public class StudentBO
    {

        #region 学生信息 分页列表
        /// <summary>
        /// 学生信息 分页列表
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="wc"></param>
        /// <returns></returns>
        public IResult GetStudentList(int pageIndex, int pageSize, string wc = null)
        {
            var list = new StudentDataDAO().GetStudentList(pageIndex, pageSize, wc);
            return new DataResult<PagedList<dynamic>>(list);
        }
        #endregion
        #region 学生信息 单条记录
        /// <summary>
        /// 学生信息 单条记录
        /// </summary>
        /// <param name="studentDataID"></param>
        /// <returns></returns>
        public IResult GetStudentInfo(int studentDataID)
        {
            var res = new StudentDataDAO().GetInfo(studentDataID);
            return new DataResult<StudentData>(res);
        }
        #endregion
        #region 学生信息 保存
        public bool SaveStudentInfo(dynamic data, int userid)
        {
            int studentID = data.StudentDataID ?? 0;
            var result = 0;
            if (studentID > 0)
            {
                var record = new StudentDataDAO().GetInfo(studentID);
                record.StudentState = data.StudentState;
                record.StudentMobile = data.StudentMobile;
                record.StudentGrade = data.StudentGrade;
                record.StudentMajor = data.StudentMajor;
                record.StudentClass = data.StudentClass ?? "";
                record.StudentSex = data.StudentSex;
                record.StudentNative = data.StudentNative;
                record.StudentBirthday = data.StudentBirthday ?? ConvertHelper.DefaultDate;
                record.EditDateTime = DateTime.Now;
                record.EditUserID = userid;
                result = new StudentDataDAO().Update(record);
            }
            else if (studentID == 0)
            {
                var student = new StudentData()
                {
                    StudentNo = data.StudentNo,
                    StudentState = data.StudentState,
                    StudentName = data.StudentName,
                    StudentMobile = data.StudentMobile,
                    StudentGrade = data.StudentGrade,
                    StudentMajor = data.StudentMajor,
                    StudentClass = data.StudentClass ?? "",
                    StudentSex = data.StudentSex,
                    StudentNative = data.StudentNative,
                    StudentBirthday = data.StudentBirthday ?? ConvertHelper.DefaultDate,
                    RegDateTime = DateTime.Now,
                    RegUserID = userid,
                    EditDateTime = DateTime.Now,
                    EditUserID = userid,
                };
                result = new StudentDataDAO().Insert(student);
            }
            return result > 0;
        }
        #endregion

        #region 学生统计 总数
        public IResult GetStudentCount()
        {
            var res = new StudentDataDAO().GetStudentCount();
            return new DataResult<int>(res);
        }
        #endregion
        #region 学生统计 性别
        public IResult GetAnalysisStudentSex()
        {
            var res = new StudentDataDAO().GetAnalysisStudentSex();
            return new DataResult<List<dynamic>>(res);
        }
        #endregion
        #region 学生统计 年级
        public IResult GetAnalysisStudentGrade()
        {
            var res = new StudentDataDAO().GetAnalysisStudentGrade();
            return new DataResult<List<dynamic>>(res);
        }
        #endregion
        #region 学生统计 籍贯
        public IResult GetAnalysisStudentNative()
        {
            var res = new StudentDataDAO().GetAnalysisStudentNative();
            return new DataResult<List<dynamic>>(res);
        }
        #endregion
    }
}
