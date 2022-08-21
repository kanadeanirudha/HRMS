using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IOrganisationMasterViewModel
    {

         int ID { get; set; }
         string EstablishmentCode { get; set; }
         string OrgName { get; set; }
         string FoundationDatetime { get; set; }
         string FounderMember { get; set; }
         string Address1 { get; set; }
         string Address2 { get; set; }
         string PlotNumber { get; set; }
         string StreetNumber { get; set; }
         int LocationID { get; set; }
         string Pincode { get; set; }
         string EmailID { get; set; }
         string Url { get; set; }
         string OfficeComment { get; set; }
         string MissionStatement { get; set; }
         string MobileNumber { get; set; }
         string FaxNumber { get; set; }
         string OfficePhone1 { get; set; }
         string OfficePhone2 { get; set; }
          int TotalRecordsFound
         {
             get;
             set;
         }
         bool IsDeleted { get; set; }
         int CreatedBy { get; set; }
         System.DateTime CreatedDate { get; set; }
         int? ModifiedBy { get; set; }
         System.DateTime? ModifiedDate { get; set; }
         int? DeletedBy { get; set; }
         System.DateTime? DeletedDate { get; set; }
    }

     interface IOrganisationMasterBaseViewModel
    {
        List<OrganisationMaster> ListOrganisationMaster
        {
            get;
            set;
        }
    }
}
