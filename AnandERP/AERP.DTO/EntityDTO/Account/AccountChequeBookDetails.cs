using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountChequeBookDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int ChequeBookID
        {
            get;
            set;
        }
        public int ChequeNo
        {
            get;
            set;
        }
        public DateTime ChequeDatetime
        {
            get;
            set;
        }
        public decimal ChequeAmount
        {
            get;
            set;
        }
        public int TransactionSubID
        {
            get;
            set;
        }
        public DateTime TransactionDatetime
        {
            get;
            set;
        }
        public string ChequeStatus
        {
            get;
            set;
        }
        public string ChequeDescription
        {
            get;
            set;
        }
        public string CanceledBy
        {
            get;
            set;
        }
     
        public string CentreCode
        {
            get;
            set;
        }
        public bool IsActive
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
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public string errorMessage
        { 
            get; 
            set; 
        }
        public string AccountName
        { 
            get; 
            set; 
        }
        public Int16 AccountID 
        { 
            get; 
            set; 
        }
        public int ChequeNumber { get; set; }

     
    }
}
