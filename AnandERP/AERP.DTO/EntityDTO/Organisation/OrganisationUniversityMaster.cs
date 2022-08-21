using System;
using AMS.Base.DTO;
namespace AMS.DTO
{
    public class OrganisationUniversityMaster : BaseDTO
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
        public string UniversityName 
        { 
            get; 
            set; 
        }

        //This is a temprary varibale to store combination of ID and UniversityName of Dropdownlistfor binding purpose
        public string universityID
        {
            get;
            set;
        }

        public string universityName
        {
            get;
            set;
        }

        public int StudyCentreUniversityApplicableID
        {

            get;
            set;
        }
        //
        public string EstablishmentCode 
        { 
            get; 
            set; 
        }
        public string UniversityFoundationDatetime { get; set; }
        public string UniversityFounderMember { get; set; }
        public string UniversityAddress1 { get; set; }
        public string UniversityAddress2 { get; set; }
        public string PlotNumber { get; set; }
        public string StreetNumber { get; set; }
        public int CityID { get; set; }
        public string Pincode { get; set; }
        public string FaxNumber { get; set; }
        public string PhoneNumberOffice { get; set; }
        public string Extention { get; set; }
        public string CellPhone { get; set; }
        public string EmailID { get; set; }
        public string Url { get; set; }
        public string OfficeComment { get; set; }
        public string MissionStatement { get; set; }
        public bool DefaultFlag { get; set; }
        public string UniversityReportPath { get; set; }
        public string UniversityShortName { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }

        public bool universityFlag
        {
            get;
            set;

        }
        public string errorMessage { get; set; }
    }
}
