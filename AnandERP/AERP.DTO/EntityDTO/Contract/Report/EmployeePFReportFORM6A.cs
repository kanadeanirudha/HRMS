using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class EmployeePFReportFORM6A : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string FromDate
        {
            get; set;
        }
        public string UptoDate
        {
            get; set;
        }
        public string CentreName
        {
            get; set;
        }
        public string EmployeeName
        {
            get; set;
        }
        public string EmployeeFathersFullName
        {
            get; set;
        }
        public string PFAccountNmber
        {
            get; set;
        }
        public string MonthYear
        {
            get; set;
        }
        public decimal TotalAmountOfWages
        {
            get; set;
        }

        public decimal TotalWorkersShareEPF
        {
            get; set;
        }

        public decimal TotalEmployersShareEPF
        {
            get; set;
        }

        public decimal TotalEmployersShareEPS
        {
            get; set;
        }

        public string CentreAdress
        {
            get; set;
        }
        public decimal RateOfContribution { get; set; }
        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public int SaleContractEmployeeMasterID { get; set; }
        public string SaleContractEmployeeMasterName { get; set; }
        public int AccountSessionID { get; set; }
    }
}
