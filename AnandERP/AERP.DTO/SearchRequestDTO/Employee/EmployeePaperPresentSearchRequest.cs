using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeePaperPresentSearchRequest : Request
    {


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
        public DateTime EmployeeYear
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
        public DateTime EmployeeCoferenceDateFrom
        {
            get;
            set;
        }
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
        public DateTime PublishDate
        {
            get;
            set;
        }
        public string EmployeeProceedingPageNumber
        {
            get;
            set;
        }
        public string EmployeeConferenceProceeding
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }

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
