using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationStudyCentrePrintingFormatSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }

        public string CentrePrintingLine
        {
            get;
            set;
        }
        public string PrintingLine1
        {
            get;
            set;
        }
        public string PrintingLine2
        {
            get;
            set;
        }
        public string PrintingLine3
        {
            get;
            set;
        }
        public string PrintingLine4
        {
            get;
            set;
        }
        public string  Logo
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

        public bool StatusFlag
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
