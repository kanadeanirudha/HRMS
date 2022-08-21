using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationStudyCentreMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int AccBalsheetMstID

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
        public int HoID
        {
            get;
            set;
        }
        public int CoID
        {
            get;
            set;
        }
        public int RoID
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
        public int CityID
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
        public DateTime CentreEstablishmentDatetime
        {
            get;
            set;
        }
        public int OrganisationanisationID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int CentreLoginNumber
        {
            get;
            set;
        }
        public string InstituteCode
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
