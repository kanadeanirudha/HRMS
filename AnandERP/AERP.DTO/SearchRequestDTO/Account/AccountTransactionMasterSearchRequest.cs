using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class AccountTransactionMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SearchWord { get; set; }
        public string TransactionType { get; set; }
        public int AccountId { get; set; }
        public string PersonType { get; set; }
        public string TransactionTypeCode { get; set; }
        public bool IsActive
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public string SortOrder
        {
            get;
            set;
        }

        public string SortBy
        {
            get;
            set;
        }

        public int StartRow
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }
        public Int16 AccBalsheetMstID { get; set; }
        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string errorMessage { get; set; }
        public Int16 AccSessionID { get; set; }
        public string ScopeIdentity
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int PersonID
        {
            get;
            set;
        }
        public int TaskNotificationMasterID
        {
            get;
            set;
        }
        public int AccBalanceSheetID
        {
            get;
            set;
        }  
    }
}
