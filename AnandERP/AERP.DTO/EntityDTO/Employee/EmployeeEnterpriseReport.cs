using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeEnterpriseReport : BaseDTO
    {

        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
        public int TotalEmployeeInDepartment
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string DeptShortCode
        {
            get;
            set;
        }
        public int DepartmentCount
        {
            get;
            set;
        }
        public int TotalEmployeeInCentre
        {
            get;
            set;
        }
        public string AcademicNonAcademic
        {
            get;
            set;
        }
        public int FacultyCount
        {
            get;
            set;
        }
        public int DoctorateCount
        {
            get;
            set;
        }
        public int PostGraduationCount
        {
            get;
            set;
        }
        public decimal ExperinceInMonthCount
        {
            get;
            set;
        }
        public int SpecializationCount
        {
            get;
            set;
        }
        public int SpecialResearchArea
        {
            get;
            set;
        }
        public int PaperPresentCount_Journal_International
        {
            get;
            set;
        }
        public int PaperPresentCount_CoAuthor_Journal_International
        {
            get;
            set;
        }
        public int PaperPresentCount_MainAuthor_Journal_International
        {
            get;
            set;
        }
        public int PaperPresentCount_Journal_National
        {
            get;
            set;
        }
        public int PaperPresentCount_CoAuthor_Journal_National
        {
            get;
            set;
        }
        public int PaperPresentCount_MainAuthor_Journal_National
        {
            get;
            set;
        }
        public int PaperPresentCount_Conference_International
        {
            get;
            set;
        }
        public int PaperPresentCount_CoAuthor_Conference_International
        {
            get;
            set;
        }
        public int PaperPresentCount_MainAuthor_Conference_International
        {
            get;
            set;
        }
        public int PaperPresentCount_Conference_National
        {
            get;
            set;
        }
        public int PaperPresentCount_CoAuthor_Conference_National
        {
            get;
            set;
        }
        public int PaperPresentCount_MainAuthor_Conference_National
        {
            get;
            set;
        }
        public int JournalPaperCount
        {
            get;
            set;
        }
        public int MainAuthorCount
        {
            get;
            set;
        }
        public int CoAuthorCount
        {
            get;
            set;
        }
        public int ConferenceCount
        {
            get;
            set;
        }
        public int PublishedBookCount
        {
            get;
            set;
        }
        public int SynopsisCount
        {
            get;
            set;
        }
        public int ProjectCount
        {
            get;
            set;
        }
        public int ElectedBodyMemberCount
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }

        
        public decimal AverageRanking
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }
    }
}
