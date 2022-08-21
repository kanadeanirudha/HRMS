using AERP.Base.DTO;
namespace AERP.DTO
{
    public class MISReportSearchRequest : Request
    {
        public string CentreCode
        {
            get;
            set;
        }
        public string MonthName
        {
            get;
            set;
        }
        public string MonthYear
        {
            get;
            set;
        }
        public int SaleContractEmployeeMasterID
        {
            get;
            set;
        }

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
    }
}
