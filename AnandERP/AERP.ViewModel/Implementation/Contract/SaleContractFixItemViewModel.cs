using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractFixItemViewModel : ISaleContractFixItemViewModel
    {

        public SaleContractFixItemViewModel()
        {
            SaleContractFixItemDTO = new SaleContractFixItem();
        }
        
        public SaleContractFixItem SaleContractFixItemDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.ID > 0) ? SaleContractFixItemDTO.ID : new int();
            }
            set
            {
                SaleContractFixItemDTO.ID = value;
            }
        }

        [Display(Name = "Job Work Item Name")]
        [Required(ErrorMessage = "Job Work Item Name Required")]
        public string Name
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.Name : string.Empty;
            }
            set
            {
                SaleContractFixItemDTO.Name = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.ItemNumber > 0) ? SaleContractFixItemDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractFixItemDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractFixItemDTO.ItemDescription = value;
            }
        }
        [Display(Name = "Man Power Item")]
        [Required(ErrorMessage = "Man Power Item Required")]
        public Int32 SaleContractManPowerItemID
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.SaleContractManPowerItemID > 0) ? SaleContractFixItemDTO.SaleContractManPowerItemID : new Int32();
            }
            set
            {
                SaleContractFixItemDTO.SaleContractManPowerItemID = value;
            }
        }

        [Display(Name = "Man Power Item")]
        public string SaleContractManPowerItemName
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.SaleContractManPowerItemName : string.Empty;
            }
            set
            {
                SaleContractFixItemDTO.SaleContractManPowerItemName = value;
            }
        }
        [Display(Name= "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                SaleContractFixItemDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Name")]
        public Int32 CustomerMasterID
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.CustomerMasterID > 0) ? SaleContractFixItemDTO.CustomerMasterID : new Int32();
            }
            set
            {
                SaleContractFixItemDTO.CustomerMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public Int32 CustomerBranchMasterID
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.CustomerBranchMasterID > 0) ? SaleContractFixItemDTO.CustomerBranchMasterID : new Int32();
            }
            set
            {
                SaleContractFixItemDTO.CustomerBranchMasterID = value;
            }
        }
        [Display(Name = "Customer Branch")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                SaleContractFixItemDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.IsDeleted : false;
            }
            set
            {
                SaleContractFixItemDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.CreatedBy > 0) ? SaleContractFixItemDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractFixItemDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractFixItemDTO != null) ? SaleContractFixItemDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixItemDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.ModifiedBy > 0) ? SaleContractFixItemDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractFixItemDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.ModifiedDate.HasValue) ? SaleContractFixItemDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixItemDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.DeletedBy > 0) ? SaleContractFixItemDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractFixItemDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractFixItemDTO != null && SaleContractFixItemDTO.DeletedDate.HasValue) ? SaleContractFixItemDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractFixItemDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

