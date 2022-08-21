using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountTransactionTypeMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string TransactionTypeCode
        {
            get;
            set;
        }
        public string TransactionTypeName
        {
            get;
            set;
        }
        public bool IsActive
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
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
        public int AccBalsheetMstID
        {
            get;
            set;
        }
        public int AccSessionID
        {
            get;
            set;
        }
    }
}
