using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationStudyCentreMaster : BaseDTO
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
        public string HoCoRoScFlag
        {
            get;
            set;
        }
        public Nullable<int> HoID
        {
            get;
            set;
        }
        public Nullable<int> CoID
        {
            get;
            set;
        }
        public Nullable<int> RoID
        {
            get;
            set;
        }
        public int HoCount
        {
            get;
            set;
        }
        public string CentreSpecialization
        {
            get;
            set;
        }
        public string CentreAddress
        {
            get;
            set;
        }
        public string PlotNo
        {
            get;
            set;
        }
        public string StreetName
        {
            get;
            set;
        }
        public Nullable<int> CityID
        {
            get;
            set;
        }
        public string Pincode
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
        public string CellPhone
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string PhoneNumberOffice
        {
            get;
            set;
        }
        public string CentreEstablishmentDatetime
        {
            get;
            set;
        }
        public Nullable<int> OrganisationID
        {
            get;
            set;
        }
        public Nullable<int> UniversityID
        {
            get;
            set;
        }
        public Nullable<int> CentreLoginNumber
        {
            get;
            set;
        }
        public string InstituteCode
        {
            get;
            set;
        }
        public string TimeZone
        {
            get;
            set;
        }
        public decimal Latitude
        {
            get;
            set;
        }
        public decimal Longitude
        {
            get;
            set;
        }

        public decimal CampusArea
        {
            get;
            set;
        }
        public string UserType
        {
            get;
            set;
        }
        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> ModifiedDate
        {
            get;
            set;
        }
        public Nullable<int> DeletedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> DeletedDate
        {
            get;
            set;
        }

        public bool universityStatusFlag
        {
            get;
            set;
        }
        public string IDs
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string ScopeIdentity { get; set; }

        public string PrintingLine1 { get; set; }
        public string PrintingLine2 { get; set; }
        public string PrintingLine3 { get; set; }
        public string PrintingLine4 { get; set; }
        public byte[] Logo { get; set; }

        public int TimeZoneID
        {
            get;
            set;
        }
        public string UTCoffset { get; set; }
    }
}
