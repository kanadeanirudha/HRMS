using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string EstablishmentCode
        {
            get;
            set;
        }
        public string OrgName
        {
            get;
            set;
        }
        public DateTime FoundationDatetime
        {
            get;
            set;
        }
        public string FounderMember
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }
        public string PlotNumber
        {
            get;
            set;
        }
        public string StreetNumber
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public int Pincode
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }
        public string OfficeComment
        {
            get;
            set;
        }
        public string MissionStatement
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string OfficePhone1
        {
            get;
            set;
        }
        public string OfficePhone2
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
