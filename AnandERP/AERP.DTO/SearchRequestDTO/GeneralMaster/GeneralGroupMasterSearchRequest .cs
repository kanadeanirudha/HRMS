using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
    public class GeneralGroupMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string GroupName
        {
            get;
            set;
        }
        public string GroupDependentObject
        {
            get;
            set;
        }
        public int JobProfileID
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
