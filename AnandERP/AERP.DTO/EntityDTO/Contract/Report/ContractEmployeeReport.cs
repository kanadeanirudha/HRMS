using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ContractEmployeeReport : BaseDTO
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
        public string CentreName
        {
            get; set;
        }
        public string CentreCode
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
        public string ReasonForLeft
        {
            get;set;
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
        public Int32 SaleContractEmployeeMasterID { get; set; }
        public string SaleContractEmployeeMasterName { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public string Narration { get; set; }
    }
}
