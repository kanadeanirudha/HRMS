using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeContactDetails : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int ContactID
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
        public int ContactLocationID
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
        public string CountryName
        {
            get;
            set;
        }
        public string RegionName
        {
            get;
            set;
        }
        public string CityName
        {
            get;
            set;
        }
        public string Location
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }       
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
