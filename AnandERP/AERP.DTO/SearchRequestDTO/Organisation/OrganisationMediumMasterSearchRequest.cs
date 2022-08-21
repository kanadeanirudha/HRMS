using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationMediumMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string CodeShortCode
        {
            get;
            set;
        }
        public string PrintShortCode
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
