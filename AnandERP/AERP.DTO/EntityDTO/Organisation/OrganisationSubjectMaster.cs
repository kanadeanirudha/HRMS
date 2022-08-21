using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubjectMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string SubjectCode
        {
            get;
            set;
        }
        public string Descriptions
        {
            get;
            set;
        }
        public string SubjectIntroYear
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
        public int LanguageID
        {
            get;
            set;
        }
        public string PaperCode
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
