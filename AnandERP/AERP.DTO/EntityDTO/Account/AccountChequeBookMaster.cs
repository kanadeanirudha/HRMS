using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountChequeBookMaster : BaseDTO
    {
        public int ID 
        { 
            get; 
            set; 
        }
        public Nullable<Int16> AccountID
        {
            get;
            set;
        }
        public string AccountCode
        {
            get;
            set;
        }
        public string AccountName
        {
            get;
            set;
        }
        public Nullable<int> ChequeFromNo
        {
            get;
            set;
        }
        public Nullable<int> ChequeToNo
        {
            get;
            set;
        }
        public Nullable<Int16> TotalNoCheque
        {
            get;
            set;
        }
        public Nullable<bool> ActiveFlag
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public Nullable<Int16> AccBalsheetMstID
        {
            get;
            set;
        }
        public Nullable<bool> StatusFlag
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        public Nullable<int> DeletedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
