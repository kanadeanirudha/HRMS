using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AddCentreOpeningBalanceForInventoryViewModel : IAddCentreOpeningBalanceForInventoryViewModel
    {

        public AddCentreOpeningBalanceForInventoryViewModel()
        {
            AddCentreOpeningBalanceForInventoryDTO = new AddCentreOpeningBalanceForInventory();
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
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public string SelectedCentreCode
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
        public AddCentreOpeningBalanceForInventory AddCentreOpeningBalanceForInventoryDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null && AddCentreOpeningBalanceForInventoryDTO.ID > 0) ? AddCentreOpeningBalanceForInventoryDTO.ID : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.ID = value;
            }
        }

       
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.ItemDescription : string.Empty;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.ItemDescription = value;
            }
        }
        
        [Required(ErrorMessage = "Centre Code should not be blank.")]
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.CentreCode : string.Empty;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.CentreCode = value;
            }
        }
        public int FinanacialYearID
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null && AddCentreOpeningBalanceForInventoryDTO.FinanacialYearID > 0) ? AddCentreOpeningBalanceForInventoryDTO.FinanacialYearID : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.FinanacialYearID = value;
            }
        }

        public int InventoryLocationMasterID
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null && AddCentreOpeningBalanceForInventoryDTO.InventoryLocationMasterID > 0) ? AddCentreOpeningBalanceForInventoryDTO.InventoryLocationMasterID : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.InventoryLocationMasterID = value;
            }
        }


      
        [Required(ErrorMessage = " Sub Location Name should not be blank.")]
        [Display(Name = "Sub Location Name")]
        public string LocationName
        {

            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.LocationName : string.Empty;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.LocationName = value;
            }
        }
       
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.IsDeleted : false;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null && AddCentreOpeningBalanceForInventoryDTO.CreatedBy > 0) ? AddCentreOpeningBalanceForInventoryDTO.CreatedBy : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.ModifiedBy : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.DeletedBy : new int();
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        public string EntityLevel { get; set; }
       

        
        public string SelectedDomainIDs
        {
            get; set;
        }
        public string XMLstring
        {

            get
            {
                return (AddCentreOpeningBalanceForInventoryDTO != null) ? AddCentreOpeningBalanceForInventoryDTO.XMLstring : string.Empty;
            }
            set
            {
                AddCentreOpeningBalanceForInventoryDTO.XMLstring = value;
            }
        }
    }
}

