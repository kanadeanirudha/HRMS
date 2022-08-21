using System;
using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralRequestMasterSearchRequest : Request
    {
        public Int32 ID
        {
            get;
            set;
        }
        public string RequestCode { get; set; }
        public string MenuCode    { get; set; }
       
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

        public int RowLength
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
        public int StatusFlag { get; set; }
    }

}
