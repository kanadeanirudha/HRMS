using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractMachineMasterViewModel : ISaleContractMachineMasterViewModel
    {

        public SaleContractMachineMasterViewModel()
        {
            SaleContractMachineMasterDTO = new SaleContractMachineMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
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

        public SaleContractMachineMaster SaleContractMachineMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.ID > 0) ? SaleContractMachineMasterDTO.ID : new int();
            }
            set
            {
                SaleContractMachineMasterDTO.ID = value;
            }
        }

        [Display(Name = "Machine Name")]
        [Required(ErrorMessage = "Machine Name Required")]
        public string Name
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.Name : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.Name = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.ItemNumber > 0) ? SaleContractMachineMasterDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractMachineMasterDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Serial Number Code")]
        [Required(ErrorMessage = "Serial Number Required")]
        public string SerialNumber
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.SerialNumber : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.SerialNumber = value;
            }
        }
        [Display(Name = "Purchase Date")]
        public string PurchaseDate
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.PurchaseDate : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.PurchaseDate = value;
            }
        }
        [Display(Name = "Next Maintance Date")]
        public string NextMaintanceDate
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.NextMaintanceDate : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.NextMaintanceDate = value;
            }
        }
        [Display(Name = "Centre Name")]
        [Required(ErrorMessage = "Centre Name Required")]
        public string CentreCode
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "Is Enguage")]
        public bool IsEnguage
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.IsEnguage : false;
            }
            set
            {
                SaleContractMachineMasterDTO.IsEnguage = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerID
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.CustomerID > 0) ? SaleContractMachineMasterDTO.CustomerID : new Int32();
            }
            set
            {
                SaleContractMachineMasterDTO.CustomerID = value;
            }
        }
        [Display(Name = "Location")]
        public Int32 LocationID
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.LocationID > 0) ? SaleContractMachineMasterDTO.LocationID : new Int32();
            }
            set
            {
                SaleContractMachineMasterDTO.LocationID = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerName
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.CustomerName : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.CustomerName = value;
            }
        }
        [Display(Name = "Location")]
        public string LocationName
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.LocationName : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.LocationName = value;
            }
        }
        [Display(Name = "Machine Type")]
        public byte MachineType
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.MachineType > 0) ? SaleContractMachineMasterDTO.MachineType : new byte();
            }
            set
            {
                SaleContractMachineMasterDTO.MachineType = value;
            }
        }
        [Display(Name = "Machine Use For")]
        public string MachineUseFor
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.MachineUseFor : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.MachineUseFor = value;
            }
        }
        [Display(Name = "Model Number")]
        public string ModelNumber
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.ModelNumber : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.ModelNumber = value;
            }
        }
        [Display(Name = "Make By")]
        public string MakeBy
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.MakeBy : string.Empty;
            }
            set
            {
                SaleContractMachineMasterDTO.MakeBy = value;
            }
        }
        [Display(Name = "Purchase Cost")]
        [Required(ErrorMessage = "Purchase Cost Required")]
        public decimal PurchaseCost
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.PurchaseCost : new decimal();
            }
            set
            {
                SaleContractMachineMasterDTO.PurchaseCost = value;
            }
        }
        
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.IsDeleted : false;
            }
            set
            {
                SaleContractMachineMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.CreatedBy > 0) ? SaleContractMachineMasterDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractMachineMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractMachineMasterDTO != null) ? SaleContractMachineMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.ModifiedBy > 0) ? SaleContractMachineMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractMachineMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.ModifiedDate.HasValue) ? SaleContractMachineMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.DeletedBy > 0) ? SaleContractMachineMasterDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractMachineMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractMachineMasterDTO != null && SaleContractMachineMasterDTO.DeletedDate.HasValue) ? SaleContractMachineMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

