using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeePrizesWonDetailsSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public int GeneralLevelMasterID
        {
            get;
            set;
        }
        public string PrizeName
        {
            get;
            set;
        }
        public string PrizeGivenBy
        {
            get;
            set;
        }
        public string PrizeReceivingDate
        {
            get;
            set;
        }
        public string PrizeIssuingAuthority
        {
            get;
            set;
        }
        public string Remark
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
