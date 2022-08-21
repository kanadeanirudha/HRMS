using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class InventoryLocationMasterViewModel : IInventoryLocationMasterViewModel
    {

        public InventoryLocationMasterViewModel()
        {
            InventoryLocationMasterDTO = new InventoryLocationMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
               ListInventoryLocationMaster = new List<InventoryLocationMaster>();
 
        }


        public InventoryLocationMaster InventoryLocationMasterDTO
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
         public List<InventoryLocationMaster> ListInventoryLocationMaster { get; set; }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
           

        public int ID
        {
            get
            {
                return (InventoryLocationMasterDTO != null && InventoryLocationMasterDTO.ID > 0) ? InventoryLocationMasterDTO.ID : new int();
            }
            set
            {
                InventoryLocationMasterDTO.ID = value;
            }
        }
        public string CentreName
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {


            get;
            set;

        }
        [Required(ErrorMessage = "Location ID should not be blank.")]
        [Display(Name = " Location ID")]
        public int IssueFromLocationID
        {

            get
            {
                return (InventoryLocationMasterDTO != null && InventoryLocationMasterDTO.IssueFromLocationID > 0) ? InventoryLocationMasterDTO.IssueFromLocationID : new int();
            }
            set
            {
                InventoryLocationMasterDTO.IssueFromLocationID = value;
            }
        }

        [Display(Name = "Balancesheet ID")]
        public int AccBalanceSheetID
        {
            get
            {
                return (InventoryLocationMasterDTO != null && InventoryLocationMasterDTO.AccBalanceSheetID > 0) ? InventoryLocationMasterDTO.AccBalanceSheetID : new int();
            }
            set
            {
                InventoryLocationMasterDTO.AccBalanceSheetID = value;
            }
        }

        [Required(ErrorMessage = "Location Name Should Not be Blank")]
        [Display(Name = "Location Name ")]
        public string LocationName
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.LocationName : string.Empty;
            }
            set
            {
                InventoryLocationMasterDTO.LocationName = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryLocationMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryLocationMasterDTO != null && InventoryLocationMasterDTO.CreatedBy > 0) ? InventoryLocationMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryLocationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryLocationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryLocationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryLocationMasterDTO != null) ? InventoryLocationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryLocationMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

