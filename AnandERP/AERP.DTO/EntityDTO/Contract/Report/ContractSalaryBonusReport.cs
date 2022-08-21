using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ContractSalaryBonusReport : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string Title
        {
            get; set;
        }
        public string FirstName
        {
            get; set;
        }
        public string MiddleName
        {
            get; set;
        }
        public string LastName
        {
            get; set;
        }
        public string EmployeeName
        {
            get; set;
        }
        public string EmployeeCode
        {
            get; set;
        }
        public string FirstJoiningDate
        {
            get; set;
        }
        public string FromDate
        {
            get; set;
        }
        public string UptoDate
        {
            get; set;
        }
        public bool IsLeft
        {
            get; set;
        }
        public string LastLeftDate
        {
            get; set;
        }
        public string GenderCode
        {
            get; set;
        }
        public string ESINumber
        {
            get; set;
        }
        public string ProvidentFundNumber
        {
            get; set;

        }
        public string UANNumber
        {
            get; set;
        }
        public string BankName
        {
            get; set;
        }
        public string BankACNumber
        {
            get; set;
        }
        public string BankIFSICode
        {
            get; set;
        }
        public string Birthdate
        {
            get; set;
        }
        public string ZoneName
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
        public string errorMessage { get; set; }
        public byte BankMasterID { get; set; }
        public string ReportType { get; set; }
        public string ReportTypeDisplay { get; set; }
        public decimal SalaryAmount { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal TotalAttendance { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerMasterName { get; set; }
        public string CustomerBranchMasterName { get; set; }
        public Int32 CustomerMasterID { get; set; }
        public byte CustomerType { get; set; }
        public Int32 CustomerBranchMasterID { get; set; }
        public string SearchFor { get; set; }
        public string SearchForDisplay { get; set; }
        public string SearchForXML { get; set; }
        public Int64 SaleContractMasterID { get; set; }
        public string ContractNumber { get; set; }
        public bool IsRemovalForAdjustment { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryMonthName { get; set; }
        public string SalaryYear { get; set; }
        public Int32 AccountSessionID { get; set; }
        public string Granularity { get; set; }
    }
}
