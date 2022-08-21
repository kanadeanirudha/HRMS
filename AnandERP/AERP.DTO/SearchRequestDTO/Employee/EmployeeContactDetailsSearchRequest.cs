using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeContactDetailsSearchRequest : Request
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
        public string AddressType
        {
            get;
            set;
        }
        public string EmployeeAddress1
        {
            get;
            set;
        }
        public string EmployeeAddress2
        {
            get;
            set;
        }
        public string PlotNumber
        {
            get;
            set;
        }
        public string StreetName
        {
            get;
            set;
        }
        public int CountryID
        {
            get;
            set;
        }
        public int RegionID
        {
            get;
            set;
        }
        public int CityID
        {
            get;
            set;
        }
        public int LocationID
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string TelephoneNumber
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public bool CurrentAddressFlag
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
