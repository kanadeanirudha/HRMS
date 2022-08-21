using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class PFChallanRemittance : BaseDTO
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
        public string FirstJoiningDate
        {
            get; set;
        }
        public char GenderCode
        {
            get; set;
        }
        public string MonthName
        {
            get; set;
        }
        public string Birthdate
        {
            get; set;
        }

        public decimal WorkersShare
        {
            get; set;
        }

        public decimal Acc01
        {
            get; set;
        }

        public decimal Acc10
        {
            get; set;
        }

        public decimal Acc21
        {
            get; set;
        }

        public string CentreAdress
        {
            get; set;
        }
        public decimal Acc02 { get; set; }
        public decimal Acc22 { get; set; }
        public decimal TotalAmountRemited { get; set; }
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
        public string UploadString { get; set; }
        public string ReferenceNumber { get; set; }
        public string TransactionDate { get; set; }
        public string ChallanRemmittanceDate { get; set; }
        public byte PaymentMode { get; set; }
        public decimal TotalWagesAmount { get; set; }
        public decimal TotalNotAgedWagesAmount { get; set; }
        public Int32 TotalEmployeeCount { get; set; }
        public Int32 TotalEmployeeCountNotAged { get; set; }
        public string PFAmountInWords { get; set; }
    }
}
