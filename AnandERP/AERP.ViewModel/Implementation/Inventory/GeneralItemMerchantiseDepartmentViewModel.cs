using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralItemMerchantiseDepartmentViewModel : IGeneralItemMerchantiseDepartmentViewModel
    {

        public GeneralItemMerchantiseDepartmentViewModel()
        {
            GeneralItemMerchantiseDepartmentDTO = new GeneralItemMerchantiseDepartment();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
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
                return new SelectList(ListGetAdminRoleApplicableCentre, "GroupCode", "CentreName");
            }
        }
        public string SelectedGroupCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }
        public GeneralItemMerchantiseDepartment GeneralItemMerchantiseDepartmentDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null && GeneralItemMerchantiseDepartmentDTO.ID > 0) ? GeneralItemMerchantiseDepartmentDTO.ID : new Int16();
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Department Name should not be blank.")]
        [Display(Name = "Merchandise Department Name")]
        public string MerchantiseDepartmentName
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentName : string.Empty;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentName = value;
            }
        }

        [Required(ErrorMessage = "Merchandise Department Code should not be blank.")]
        [Display(Name = "Merchandise Department Code")]
        public string MerchantiseDepartmentCode
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentCode : string.Empty;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.MerchantiseDepartmentCode = value;
            }
        }
        public Int16 MarchandiseGroupID
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null && GeneralItemMerchantiseDepartmentDTO.MarchandiseGroupID > 0) ? GeneralItemMerchantiseDepartmentDTO.MarchandiseGroupID : new Int16();
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.MarchandiseGroupID = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null && GeneralItemMerchantiseDepartmentDTO.CreatedBy > 0) ? GeneralItemMerchantiseDepartmentDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMerchantiseDepartmentDTO != null) ? GeneralItemMerchantiseDepartmentDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMerchantiseDepartmentDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

