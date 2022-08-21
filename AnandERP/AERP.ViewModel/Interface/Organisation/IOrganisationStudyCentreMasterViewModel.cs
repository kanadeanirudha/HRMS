using System;
using AERP.DTO;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IOrganisationStudyCentreMasterViewModel
    {
        OrganisationStudyCentreMaster OrganisationStudyCentreMasterDTO { get; set; }
        int ID { get; set; }
        string CentreCode { get; set; }
        string CentreName { get; set; }
        string HoCoRoScFlag { get; set; }
        Nullable<int> HoID { get; set; }
        Nullable<int> CoID { get; set; }
        Nullable<int> RoID { get; set; }
        string CentreSpecialization { get; set; }
        string CentreAddress { get; set; }
        string PlotNo { get; set; }
        string StreetName { get; set; }
        Nullable<int> CityID { get; set; }
        string Pincode { get; set; }
        string EmailID { get; set; }
        string Url { get; set; }
        string CellPhone { get; set; }
        string FaxNumber { get; set; }
        string PhoneNumberOffice { get; set; }
        string UserType
        {
            get;
            set;
        }
        string TimeZone 
        {
            get;
            set;
        }
        decimal Latitude 
        {
            get;
            set;
        }
        decimal Longitude 
        {
            get;
            set;
        }
        decimal CampusArea
        {
            get;
            set;
        }
        
        string CentreEstablishmentDatetime { get; set; }
        Nullable<int> OrganisationID { get; set; }
        Nullable<int> UniversityID { get; set; }
        Nullable<int> CentreLoginNumber { get; set; }
        string InstituteCode { get; set; }
        Nullable<bool> IsDeleted { get; set; }
        Nullable<int> CreatedBy { get; set; }
        Nullable<DateTime> CreatedDate { get; set; }
        Nullable<int> ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedDate { get; set; }
        Nullable<int> DeletedBy { get; set; }
        Nullable<DateTime> DeletedDate { get; set; }
    }

    public interface IOrganisationStudyCentreMasterBaseViewModel
    {
        List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
    }
}