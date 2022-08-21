using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralLeaveDocumentSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string DocumentName
        {
            get;
            set;
        }
        public string DocumentType
        {
            get;
            set;
        }
        public string DocumentDescription
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
        
    }
}
