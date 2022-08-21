using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{

    public class OrganisationElectiveGrpMasterBaseViewModel : IOrganisationElectiveGrpMasterBaseViewModel
    {
        public OrganisationElectiveGrpMasterBaseViewModel()
        {
            ListOrganisationElectiveGrpMaster = new List<OrganisationElectiveGrpMaster>();

        }

        public List<OrganisationElectiveGrpMaster> ListOrganisationElectiveGrpMaster
        {
            get;
            set;
        }
                   

    }


    public class OrganisationElectiveGrpMasterViewModel : IOrganisationElectiveGrpMasterViewModel
    {

        public OrganisationElectiveGrpMasterViewModel()
        {
            OrganisationElectiveGrpMasterDTO = new OrganisationElectiveGrpMaster();
        }

        public OrganisationElectiveGrpMaster OrganisationElectiveGrpMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.ID > 0) ? OrganisationElectiveGrpMasterDTO.ID : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.ID = value;
            }
        }

        public int SubjectRuleGrpNumber
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.SubjectRuleGrpNumber > 0) ? OrganisationElectiveGrpMasterDTO.SubjectRuleGrpNumber : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.SubjectRuleGrpNumber = value;
            }
        }

        public int NoOfSubGroups
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.NoOfSubGroups > 0) ? OrganisationElectiveGrpMasterDTO.NoOfSubGroups : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.NoOfSubGroups = value;
            }
        }

        public int NoOfCompulsorySubGrp
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.NoOfCompulsorySubGrp > 0) ? OrganisationElectiveGrpMasterDTO.NoOfCompulsorySubGrp : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.NoOfCompulsorySubGrp = value;
            }
        }
        public int NoOfSubGrpSubjectSelect
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.NoOfSubGrpSubjectSelect > 0) ? OrganisationElectiveGrpMasterDTO.NoOfSubGrpSubjectSelect : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.NoOfSubGrpSubjectSelect = value;
            }
        }
        [Display(Name = "Group Name")]
        public string GroupName
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null) ? OrganisationElectiveGrpMasterDTO.GroupName : string.Empty;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.GroupName = value;
            }
        }

        [Display(Name = "GroupShortCode")]
        public string GroupShortCode
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null) ? OrganisationElectiveGrpMasterDTO.GroupShortCode : string.Empty;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.GroupShortCode = value;
            }
        }

     

        public bool GroupCompulsoryFlag
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null) ? OrganisationElectiveGrpMasterDTO.GroupCompulsoryFlag : false;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.GroupCompulsoryFlag = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null) ? OrganisationElectiveGrpMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.CreatedBy > 0) ? OrganisationElectiveGrpMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null) ? OrganisationElectiveGrpMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.ModifiedBy.HasValue) ? OrganisationElectiveGrpMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.ModifiedDate.HasValue) ? OrganisationElectiveGrpMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.DeletedBy.HasValue) ? OrganisationElectiveGrpMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationElectiveGrpMasterDTO != null && OrganisationElectiveGrpMasterDTO.DeletedDate.HasValue) ? OrganisationElectiveGrpMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationElectiveGrpMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedDivisionID
        {
            get;
            set;
        }
    }
}