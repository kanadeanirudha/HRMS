using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractJobWorkItemViewModel : ISaleContractJobWorkItemViewModel
    {

        public SaleContractJobWorkItemViewModel()
        {
            SaleContractJobWorkItemDTO = new SaleContractJobWorkItem();
        }
        
        public SaleContractJobWorkItem SaleContractJobWorkItemDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.ID > 0) ? SaleContractJobWorkItemDTO.ID : new int();
            }
            set
            {
                SaleContractJobWorkItemDTO.ID = value;
            }
        }

        [Display(Name = "Job Work Item Name")]
        [Required(ErrorMessage = "Job Work Item Name Required")]
        public string Name
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null) ? SaleContractJobWorkItemDTO.Name : string.Empty;
            }
            set
            {
                SaleContractJobWorkItemDTO.Name = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.ItemNumber > 0) ? SaleContractJobWorkItemDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractJobWorkItemDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null) ? SaleContractJobWorkItemDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractJobWorkItemDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Rate")]
        [Required(ErrorMessage = "Job Work Item Rate Required")]
        public decimal Rate
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.Rate > 0) ? SaleContractJobWorkItemDTO.Rate : new decimal();
            }
            set
            {
                SaleContractJobWorkItemDTO.Rate = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null) ? SaleContractJobWorkItemDTO.IsDeleted : false;
            }
            set
            {
                SaleContractJobWorkItemDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.CreatedBy > 0) ? SaleContractJobWorkItemDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractJobWorkItemDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null) ? SaleContractJobWorkItemDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkItemDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.ModifiedBy > 0) ? SaleContractJobWorkItemDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractJobWorkItemDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.ModifiedDate.HasValue) ? SaleContractJobWorkItemDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkItemDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.DeletedBy > 0) ? SaleContractJobWorkItemDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractJobWorkItemDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractJobWorkItemDTO != null && SaleContractJobWorkItemDTO.DeletedDate.HasValue) ? SaleContractJobWorkItemDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractJobWorkItemDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

