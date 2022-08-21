using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OrganisationCentrewiseSessionViewModel : IOrganisationCentrewiseSessionViewModel
    {

        public OrganisationCentrewiseSessionViewModel()
        {
            OrganisationCentrewiseSessionDTO = new OrganisationCentrewiseSession();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();   
        }

        public OrganisationCentrewiseSession OrganisationCentrewiseSessionDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null && OrganisationCentrewiseSessionDTO.ID > 0) ? OrganisationCentrewiseSessionDTO.ID : new int();
            }
            set
            {
                OrganisationCentrewiseSessionDTO.ID = value;
            }
        }

        public int SessionID
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.SessionID : new int();
            }
            set
            {
                OrganisationCentrewiseSessionDTO.SessionID = value;
            }
        }
        [Required(ErrorMessage = "Please select Session Name")]
        [Display(Name = "Session Name")]
        public string SessionName
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.SessionName : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.SessionName = value;
            }
        }
        [Required(ErrorMessage = "Please select Session From Date")]
        [Display(Name = "Session From Date")]
        public string SessionFromDate
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.SessionFromDate : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.SessionFromDate = value;
            }
        }
        [Required(ErrorMessage = "Please select Session Upto Date")]
        [Display(Name = "Session Upto Date")]
        public string SessionUptoDate
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.SessionUptoDate : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.SessionUptoDate = value;
            }
        }
        [Display(Name = "Active Session Type")]
        public string ActiveSessionType
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.ActiveSessionType : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.ActiveSessionType = value;
            }
        }
        [Display(Name = "Active Session Flag")]
        public string ActiveSessionFlag
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.ActiveSessionFlag : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.ActiveSessionFlag = value;
            }
        }
        public String CentreCode
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.CentreName = value;
            }
        }
        public string LockStatus
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.LockStatus : string.Empty;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.LockStatus = value;
            }
        }
        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.IsActive : false;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.IsDeleted : false;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null && OrganisationCentrewiseSessionDTO.CreatedBy > 0) ? OrganisationCentrewiseSessionDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationCentrewiseSessionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationCentrewiseSessionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationCentrewiseSessionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OrganisationCentrewiseSessionDTO != null) ? OrganisationCentrewiseSessionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationCentrewiseSessionDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

