using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
   public  interface IOrganisationUniversityMasterViewModel
    {

        OrganisationUniversityMaster OrganisationUniversityMasterDTO
         {
            get;
            set;
          }
          int ID { get; set; }
          string UniversityName { get; set; }
          string EstablishmentCode { get; set; }
          string UniversityFoundationDatetime { get; set; }
          string UniversityFounderMember { get; set; }
          string UniversityAddress1 { get; set; }
          string UniversityAddress2 { get; set; }
          string PlotNumber { get; set; }
          string StreetNumber { get; set; }
          int CityID { get; set; }
          string Pincode { get; set; }
          string FaxNumber { get; set; }
          string PhoneNumberOffice { get; set; }
          string Extention { get; set; }
          string CellPhone { get; set; }
          string EmailID { get; set; }
          string Url { get; set; }
          string OfficeComment { get; set; }
          string MissionStatement { get; set; }
          bool DefaultFlag { get; set; }
          string UniversityReportPath { get; set; }
          string UniversityShortName { get; set; }
          Nullable<bool>IsDeleted { get; set; }
          Nullable<int> CreatedBy { get; set; }
          Nullable<System.DateTime> CreatedDate { get; set; }
          Nullable<int> ModifiedBy { get; set; }
          Nullable<System.DateTime> ModifiedDate { get; set; }
          Nullable<int> DeletedBy { get; set; }
          Nullable<System.DateTime> DeletedDate { get; set; }
    }
   public interface IOrganisationUniversityMasterBaseViewModel
   {

       List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
       {
           get;
           set;
       }
   }
}
