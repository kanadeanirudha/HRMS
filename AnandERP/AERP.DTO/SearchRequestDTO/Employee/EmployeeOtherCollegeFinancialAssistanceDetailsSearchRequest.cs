using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest : Request
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
        public string FundingAgency
        {
            get;
            set;
        }
        public string DateOfGrantReceived
        {
            get;
            set;
        }
        public decimal AmountOfGrant
        {
            get;
            set;
        }
        public string PurposeOfGrant
        {
            get;
            set;
        }
        public string Remarks
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
    }
}
