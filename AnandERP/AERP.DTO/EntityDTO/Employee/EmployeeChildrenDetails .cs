using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeChildrenDetails : BaseDTO
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
        public int TitleMasterID
        {
            get;
            set;
        }
        public string NameTitle
        {
            get;
            set;
        }
        public string ChildName
        {
            get;
            set;
        }

        public string GenderCode
        {
            get;
            set;
        }
        public string ChildQualification
        {
            get;
            set;
        }
        public string ChildDateOfBirth
        {
            get;
            set;
        }
        public string Hobby
        {
            get;
            set;
        }
        public string Sports
        {
            get;
            set;
        }
        public string CurriculamActivity
        {
            get;
            set;
        }
        public bool GotAnyMedal
        {
            get;
            set;
        }
        public string MedalReceivedDate
        {
            get;
            set;
        }
        public string MedalDescription
        {
            get;
            set;
        }
        public bool IsScholarshipReceived
        {
            get;
            set;
        }
        public decimal ScholarshipAmount
        {
            get;
            set;
        }
        public string ScholarshipStartDate
        {
            get;
            set;
        }
        public string ScholarshipUptoDate
        {
            get;
            set;
        }
        public string ScholarshipDescription
        {
            get;
            set;
        }
        public string IdentityMarks
        {
            get;
            set;
        }
        public string Profession
        {
            get;
            set;
        }
        public string Height
        {
            get;
            set;
        }
        public string Weight
        {
            get;
            set;
        }
        public string ChildrenRelation
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
        public string errorMessage { get; set; }
    }
}
