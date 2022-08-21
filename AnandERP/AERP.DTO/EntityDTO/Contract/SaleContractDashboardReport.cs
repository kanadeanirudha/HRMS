using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractDashboardReport : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string TotalInvoiceAmountList { get; set; }
        public string InvoiceMonth { get; set; }
        public string CentreList { get; set; }
        public Int32 EmployeeID { get; set; }
        public Int32 AdminRoleID { get; set; }
        public string ReportList { get; set; }
        public string ReportCount { get; set; }
        public string DataFor { get; set; }
    }
}
