using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralTimeSlotMasterSearchRequest : Request
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string FromTime
        {
            get;
            set;
        }
        public string ToTime
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
        public string SearchWord
        {
            get;
            set;
        }
    }
}
