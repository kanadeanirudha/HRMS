using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationBranchDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int PresentIntake
        {
            get;
            set;
        }
        public int IntroductionYear
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string DteCode
        {
            get;
            set;
        }
        public int BranchPrintingSequence
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
        public string SearchType
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection  { get; set; }
    }
}
