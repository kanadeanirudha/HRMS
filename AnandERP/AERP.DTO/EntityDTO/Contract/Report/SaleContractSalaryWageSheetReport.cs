using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractSalaryWageSheetReport : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }

        public string CentreName
        {
            get; set;
        }
        public string EmployeeName
        {
            get; set;
        }
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
        public byte ReportType { get; set; }
        public string errorMessage { get; set; }
        public Int64 SaleContractMasterID { get; set; }
        public string ContractNumber { get; set; }
        public Int64 SaleContractBillingSpanID { get; set; }
        public string SaleContractBillingSpanName { get; set; }
        public decimal NetAmount { get; set; }
      public string SaleContractEmployeeMasterName { get; set; }
        public decimal ActualBasicAmount { get; set; }
        public decimal ActualDA { get; set; }
        public decimal ActualHRA { get; set; }
        public decimal ActualConveyance { get; set; }
        public decimal ActualEducation { get; set; }
        public decimal ActualWashing { get; set; }
        public decimal ActualGrossAmount { get; set; }
        public decimal DaysInMonth { get; set; }
        public decimal TotalWeeklyOffDays { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal TotalAttendance { get; set; }
        public decimal AdjustedBasicAmount { get; set; }
        public decimal EDA { get; set; }
        public decimal EHRA { get; set; }
        public decimal EConveyance { get; set; }
        public decimal EEducation { get; set; }
        public decimal ESICGrossAmount { get; set; }
        public decimal EWashing { get; set; }
        public decimal Bonus { get; set; }
        public decimal LWW { get; set; }
        public decimal GrossForESICCal { get; set; }
        public decimal EPF { get; set; }
        public decimal EESIC { get; set; }
        public decimal Canteen { get; set; }
        public decimal PT { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal OTRate { get; set; }
        public decimal SingleOvertimeHours { get; set; }
        public decimal DoubleOvertimeHours { get; set; }
        public decimal GrossOTWages { get; set; }
        public decimal NetOTWagesPayable { get; set; }
        public decimal TotalWagesPaybleBeforeDeduction { get; set; }
        public decimal EmployerPF { get; set; }
        public decimal EmployerESIC { get; set; }
        public decimal Insurance { get; set; }
        public decimal MLWF { get; set; }
        public decimal UAS { get; set; }
        public decimal TotalSalary { get; set; }
        public decimal ManagementFees { get; set; }
        public decimal ServiceCharges { get; set; }
        public decimal MobileCharges { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
