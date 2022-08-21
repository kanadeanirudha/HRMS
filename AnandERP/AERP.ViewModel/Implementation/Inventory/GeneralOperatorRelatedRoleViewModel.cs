using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
    public class GeneralOperatorRelatedRoleViewModel : IGeneralOperatorRelatedRoleViewModel
    {

        public GeneralOperatorRelatedRoleViewModel()
        {
            GeneralOperatorRelatedRoleDTO = new GeneralOperatorRelatedRole();
            CRMAdmineRoleCodelist = new List<GeneralOperatorRelatedRole>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<GeneralOperatorRelatedRole> CRMAdmineRoleCodelist
        {
            get;
            set;
        }

        public GeneralOperatorRelatedRole GeneralOperatorRelatedRoleDTO
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
        public Int16 ID
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null && GeneralOperatorRelatedRoleDTO.ID > 0) ? GeneralOperatorRelatedRoleDTO.ID : new Int16();
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.ID = value;
            }
        }

        [Display(Name = "Role Code")]
        [Required(ErrorMessage = "Role code should be specified")]
        public int AdminRoleMasterID
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null && GeneralOperatorRelatedRoleDTO.AdminRoleMasterID > 0) ? GeneralOperatorRelatedRoleDTO.AdminRoleMasterID : new int();
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.AdminRoleMasterID = value;
            }
        }
        public string SelectedCentreCode
        {


            get;
            set;

        }
        public bool IsActive
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.IsActive : false;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.IsActive = value;
            }
        }

        [Display(Name = "Role Code")]
        public string AdminRoleCode
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.AdminRoleCode : String.Empty;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.AdminRoleCode = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.CentreCode : String.Empty;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.CentreCode = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.IsDeleted : false;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null && GeneralOperatorRelatedRoleDTO.CreatedBy > 0) ? GeneralOperatorRelatedRoleDTO.CreatedBy : new int();
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null && GeneralOperatorRelatedRoleDTO.ModifiedBy.HasValue) ? GeneralOperatorRelatedRoleDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null && GeneralOperatorRelatedRoleDTO.ModifiedDate.HasValue) ? GeneralOperatorRelatedRoleDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.DeletedBy : new int();
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralOperatorRelatedRoleDTO != null) ? GeneralOperatorRelatedRoleDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralOperatorRelatedRoleDTO.DeletedDate = value;
            }
        }

        [Required(ErrorMessage = "Select Call Type")]
        public string CallType
        {
            get;
            set;
        }


        public string errorMessage { get; set; }




    }
}

