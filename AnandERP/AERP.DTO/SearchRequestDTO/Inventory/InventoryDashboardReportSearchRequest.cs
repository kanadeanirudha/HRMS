using AERP.Base.DTO;
namespace AERP.DTO
{
    public class InventoryDashboardReportSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get; set;
        }
        public int AdminRoleID
        {
            get; set;
        }
    }
}
