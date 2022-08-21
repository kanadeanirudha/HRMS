using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSectionDetails : BaseDTO
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
        public string StreamDescriptions
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string BranchDescriptions
        {
            get;
            set;
        }
        public int StandardID
        {
            get;
            set;
        }
        public string StandardDescriptions
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
        public string MediumDescription
        {
            get;
            set;
        }
        public int Duration
        {
            get;
            set;
        }
        public string Descriptions
        {
            get;
            set;
        }

        public string SelectedDescriptions
        {
            get;
            set;
        }
        public int SectionID
        {
            get;
            set;
        }
        public bool SectionActive
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
        public string NextSectionDetailID
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
        public string SectionDetailCode
        {
            get;
            set;
        }
        public string DegreeName
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int BranchDetID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int CourseStartDetID
        {
            get;
            set;
        }
        public bool ActualExamPattern
        {
            get;
            set;
        }
        public string OrgShiftCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsFinalCourseYear
        {
            get;
            set;
        }
        public bool StatusFlag
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
        public string CourseYearDescriptions
        {
            get;
            set;
        }
        public bool IsFinalYear
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
