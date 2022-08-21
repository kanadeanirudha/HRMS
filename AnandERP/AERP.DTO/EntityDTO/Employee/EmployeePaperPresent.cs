using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeePaperPresent : BaseDTO
    {
        //---------------------------------------EmployeePaperPresent Properties------------------------------------//
        public int ID
        {
            get;
            set;
        }
        public string PaperTopic
        {
            get;
            set;
        }
        public string JournalName
        {
            get;
            set;
        }
        public string JournalVolumeNumber
        {
            get;
            set;
        }
        public string JournalPageNumber
        {
            get;
            set;
        }
        public string EmployeeYear
        {
            get;
            set;
        }
        public string PaperType
        {
            get;
            set;
        }
        public int GeneralLevelMasterID
        {
            get;
            set;
        }
        public string GeneralLevel
        { 
            get; 
            set; 
        }
        public string EmployeeBookReview
        {
            get;
            set;
        }
        public string EmployeeArticleReview
        {
            get;
            set;
        }
        public string PublishMedium
        {
            get;
            set;
        }
        public string EmployeeConferenceDateFrom
        {
            get;
            set;
        }
        public string EmployeeConferenceDateTo { get; set; }
        public string ConferenceName
        {
            get;
            set;
        }
        public string EmployeeConferenceVenue
        {
            get;
            set;
        }
        public string PublishDate
        {
            get;
            set;
        }
        public string EmployeeProceedingPageNumber
        {
            get;
            set;
        }
        public string SelfGroupPresenter
        {
            get;
            set;
        }
        public string EmployeeConferenceProceeding
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


        //---------------------------------------EmployeePaperPresent Properties------------------------------------//
        public int EmployeePaperPresenterID
        {
            get;
            set;
        }
        public int EmployeePaperPresentID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeParticipationRole
        {
            get;
            set;
        }
    }
}
