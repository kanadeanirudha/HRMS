using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class GeneralCounterPOSAndPosOperatorViewModel : IGeneralCounterPOSAndPosOperatorViewModel
    {

        public GeneralCounterPOSAndPosOperatorViewModel()
        {
            GeneralCounterPOSAndPosOperatorDTO = new GeneralCounterPOSAndPosOperator();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
            }
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
        public GeneralCounterPOSAndPosOperator GeneralCounterPOSAndPosOperatorDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null && GeneralCounterPOSAndPosOperatorDTO.ID > 0) ? GeneralCounterPOSAndPosOperatorDTO.ID : new Int16();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.ID = value;
            }
        }
        [Required(ErrorMessage = "Store should not be blank.")]
        [Display(Name = "Store")]
        public Int16 GeneralUnitsID
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null && GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsID > 0) ? GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsID = value;
            }
        }
        [Required(ErrorMessage = "Store should not be blank.")]
        [Display(Name = "Store")]
        public string GeneralUnitsName
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsName : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralUnitsName = value;
            }
        }
        [Required(ErrorMessage = "Counter Name should not be blank.")]
        [Display(Name = "Counter Name")]
        public Int16 GeneralCounterMasterId
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null && GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterId > 0) ? GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterId : new Int16();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterId = value;
            }
        }

        public string GeneralCounterMasterName
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterName : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralCounterMasterName = value;
            }
        }
        [Required(ErrorMessage = "POS Name should not be blank.")]
        [Display(Name = "POS Name")]
        public Int16 GeneralPOSMasterId
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null && GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterId > 0) ? GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterId : new Int16();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterId = value;
            }
        }

        public string GeneralPOSMasterDeviceCode
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterDeviceCode : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.GeneralPOSMasterDeviceCode = value;
            }
        }
        [Required(ErrorMessage = "From Date should not be blank.")]
        [Display(Name = "From Date")]
        public string DateFrom
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.DateFrom : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.DateFrom = value;
            }
        }
        
        [Display(Name = "Upto Date")]
        public string DateUpto
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.DateUpto : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.DateUpto = value;
            }
        }
        [Display(Name = "Is Current")]
        public bool IsCurrent
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.IsCurrent : false;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.IsCurrent = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.IsDeleted : false;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null && GeneralCounterPOSAndPosOperatorDTO.CreatedBy > 0) ? GeneralCounterPOSAndPosOperatorDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public string CentreCode
        {
            get
            {
                return (GeneralCounterPOSAndPosOperatorDTO != null) ? GeneralCounterPOSAndPosOperatorDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralCounterPOSAndPosOperatorDTO.CentreCode = value;
            }
        }

    }
}

