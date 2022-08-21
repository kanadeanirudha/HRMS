using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralPolicyRulesSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int AccBalsheetMstID { get; set; }
        public string PolicyCode
        {
            get;
            set;
        }
        public string PolicyApplicableStatus
        {
            get;
            set;
        }
        public string centreCode
        {
            get;
            set;
        }
        public bool IsDeleted
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

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
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
    }
}
