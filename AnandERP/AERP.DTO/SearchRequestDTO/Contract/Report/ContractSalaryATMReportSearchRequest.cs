using AERP.Base.DTO;
namespace AERP.DTO
{
    public class ContractSalaryATMReportSearchRequest : Request
    {
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public byte ReportType { get; set; }

        public string SearchWord
        {
            get;
            set;
        }
        public string SearchFor
        {
            get;
            set;
        }
        public string SearchForDisplay { get; set; }
        public string SearchForXML { get; set; }
        public bool IsRemovalForAdjustment { get; set; }
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
        public string UnitCode
        {
            get;
            set;
        }
        public byte BankMasterID { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        public string BankName { get; set; }
    }
}
