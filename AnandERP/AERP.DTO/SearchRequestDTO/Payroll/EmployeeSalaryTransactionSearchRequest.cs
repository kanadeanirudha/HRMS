using AERP.Base.DTO;

namespace AERP.DTO
{
    public class EmployeeSalaryTransactionSearchRequest : Request
    {
        public long ID
        {
            get;
            set;
        }
        public long SaleContractBillingSpanID
        {
            get; set;
        }
        public long SaleContractMasterID
        {
            get; set;
        }
        public int EmployeeMasterID
        {
            get;set;
        }
        public int SaleContractManPowerItemID
        {
            get;set;
        }
        public string SearchWord
        {
            get; set;
        }
        public bool IsActive
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
        public string CenterCode { get; set; }
        public int DepartmentMasterID { get; set; }
        public short EmployeeSalarySpanID { get; set; }
        public long EmployeeSalaryRulesID { get; set; }
    }
}
