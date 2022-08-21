using AERP.Base.DTO;

namespace AERP.DTO
{
    public class SaleContractDashboardReportSearchRequest : Request
    {
        public long ID
        {
            get;
            set;
        }
        public int EmployeeID { get; set; }
        public int AdminRoleID { get; set; }
    }
}
