using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationElectiveGrpMasterViewModel
    {
        OrganisationElectiveGrpMaster OrganisationElectiveGrpMasterDTO
        {
            get;
            set;
        }

         int ID { get; set; }
         string GroupShortCode { get; set; }
         string GroupName { get; set; }
         int SubjectRuleGrpNumber { get; set; }
         bool GroupCompulsoryFlag { get; set; }
         int NoOfSubGroups { get; set; }
         int NoOfCompulsorySubGrp { get; set; }
         int NoOfSubGrpSubjectSelect { get; set; }
         //string ElectiveCommonGroup { get; set; }
         bool IsDeleted { get; set; }
         int CreatedBy { get; set; }
         DateTime CreatedDate { get; set; }
         int? ModifiedBy { get; set; }
         DateTime? ModifiedDate { get; set; }
         int? DeletedBy { get; set; }
         DateTime? DeletedDate { get; set; }

      
    }
    interface IOrganisationElectiveGrpMasterBaseViewModel
    {

        List<OrganisationElectiveGrpMaster> ListOrganisationElectiveGrpMaster
        {
            get;
            set;
        }
    }
}

