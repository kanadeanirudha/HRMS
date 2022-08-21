using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralTaskReportingDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int StageSequenceNumber { get; set; }
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
        public string CentreCode { get; set; }
        public string TableName { get; set; }
        public string PrimaryKey { get; set; }
        public string DisplayField { get; set; }
        public string PrimaryKeyValue { get; set; }
        public int NumberOfApprovalStages { get; set; }
        public int GeneralTaskReportingDetailsID { get; set; }
        public bool IsCreateStageDetails { get; set; }
        public int EmployeeID { get; set; }
    }
}
