using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationCourseYearDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public int StandardID
        {
            get;
            set;
        }
        public int BranchDetailID
        {
            get;
            set;
        }
        public int StandardNumber
        {
            get;
            set;
        }
        public int MediumID
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public string selectItemSemesterIDs
        {
            get;
            set;
        }
         public string Description
        {
            get;
            set;
        }
        public string SemesterIDs
        {
            get;
            set;
        }
        public bool BranchActive
        {
            get;
            set;
        }
        public int SectionCapacity
        {
            get;
            set;
        }
        public string ExamApplicable
        {
            get;
            set;
        }
        public string NextCourseYearDetailID
        {
            get;
            set;
        }
        public string ExamPattern
        {
            get;
            set;
        }
        public int NumberOfSemester
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
        public string DegreeName
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string BranchDescription
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
        public int UniversityID
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public string CourseDescription
        {
            get;
            set;
        }
        public int CourseYearID
        {
            get;
            set;
        }
        public string courseYearID
        {
            get;
            set;
        }
        public string OrgSemesterName
        {
            get;
            set;
        }
        public string SemesterType
        {
            get;
            set;
        }
        public bool SemesterStatusFlag
        {
            get;
            set;
        }

        public string semesterSelected
        {
            get;
            set;
        }
        public int CourseYearSemesterID
        {
            get;
            set;
        }
        public string SemesterApplicable { get; set; }
        public string StreamDescription { get; set; }
    }
}
