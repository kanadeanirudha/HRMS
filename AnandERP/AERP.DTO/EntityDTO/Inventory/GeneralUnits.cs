using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralUnits : BaseDTO
	{
		public Int16 ID
		{
			get;
			set;
		}
        public int GeneralUnitsStorageLocationID
        {
			get;
			set;
		}
        public string LogoPathName
        {
            get;
            set;
        }
        public string LogoName
        {
            get;
            set;
        }
        public string UnitName
		{
			get;
			set;
		}
        public Int16 GeneralUnitTypeID
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
        
        public int DepartmentID
        {
            get;
            set;
        }
        public string LocationAddress
		{
			get;
			set;
		}
        public string DepartmentName
        {
            get;
            set;
        }
        public int CityId
        {
            get;
            set;
        }
        public string CityName
        {
            get;
            set;
        }
        public string LocationName
        {
            get;
            set;
        }
        public int InventoryLocationMasterID
        {
            get;
            set;
        }
        //Feilds from GeneralUnitType//
        public string UnitType
        {
            get;
            set;
        }
        public Int16 Relatedwith
        {
            get;
            set;
        }
        public string RelatedwithUnitType
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
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}
        public string errorMessage { get; set; }
        public string ListingDate { get; set; }
        public string DeListingDate { get; set; }

        public bool IsDefaultUnit
        {
            get;
            set;
        }

        //Units details field
        public bool IsCityName
        {
            get;
            set;
        }
        public bool IsAddress
        {
            get;
            set;
        }
        public bool isGreeting
        {
            get;
            set;
        }
        public bool IsUrl
        {
            get;
            set;
        }
        public bool IsEmailID
        {
            get;
            set;
        }
        public bool IsFaxNumber
        {
            get;
            set;
        }
        public bool IsTelephoneNumber
        {
            get;
            set;
        }
        public bool IsPincode
        {
            get;
            set;
        }
        public bool IsLogoPath
        {
            get;
            set;
        }
        public bool IsFooter
        {
            get;
            set;
        }
        public string Greeting
        {
            get;
            set;
        }
        public string DisplayIcon
        {
            get;
            set;
        }
        public string Url
        {
            get;
            set;
        }

        public string FaxNumber
        {
            get;
            set;
        }
        public string TelephoneNumber
        {
            get;
            set;
        }
        public string Pincode
        {
            get;
            set;
        }
        public string LogoPath
        {
            get;
            set;
        }
        public string Footer
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }
        public string SelectedDomainIDs
        {
            get;set;
        }
        public string  UnitIDwithCentreCode
        {
            get; set;
        }

    }
}
