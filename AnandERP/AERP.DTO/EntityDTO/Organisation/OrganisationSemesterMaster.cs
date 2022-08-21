using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSemesterMaster : BaseDTO
    {
        public int ID
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
        public string SemesterCode
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsUserDefined { get; set; }
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
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int CourseYearSemesterID
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
