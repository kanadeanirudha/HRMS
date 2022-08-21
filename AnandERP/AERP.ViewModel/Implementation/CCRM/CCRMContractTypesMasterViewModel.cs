using AERP.Common;
using AERP.DTO;
using AERP.Base.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
   public class CCRMContractTypesMasterViewModel
    {
        public CCRMContractTypesMasterViewModel()
        {
            CCRMContractTypesMasterDTO = new CCRMContractTypesMaster();
            GetGeneralCategoryMasterList = new List<GeneralItemCategoryMaster>();
        }
        public CCRMContractTypesMaster CCRMContractTypesMasterDTO
        {
            get;
            set;
        }
        public List<GeneralItemCategoryMaster> GetGeneralCategoryMasterList { get; set; }
        public IEnumerable<SelectListItem> ListGeneralCategoryMasterItems
        {
            get
            {
                return new SelectList(GetGeneralCategoryMasterList, "ID", "ItemCategoryCode");
            }
        }
        public List<CCRMContractTypesMaster> GeneralCategoryMasterList
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.ID > 0) ? CCRMContractTypesMasterDTO.ID : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.ID = value;
            }
        }
        public int CCRMContractTypeDetailsID
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.CCRMContractTypeDetailsID > 0) ? CCRMContractTypesMasterDTO.CCRMContractTypeDetailsID : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.CCRMContractTypeDetailsID = value;
            }
        }
        [Display(Name = "Contract Code")]
       [Required(ErrorMessage = "Contract Code Required")]
        public string ContractCode
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.ContractCode : string.Empty;
            }
            set
            {
                CCRMContractTypesMasterDTO.ContractCode = value;
            }
        }
        [Display(Name = "Contract Name")]
        [Required(ErrorMessage = "Contract Name Required")]
        public string ContractName
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.ContractName : string.Empty;
            }
            set
            {
                CCRMContractTypesMasterDTO.ContractName = value;
            }
        }
        [Display(Name = "Contract Type")]
        [Required(ErrorMessage = "Contract Type Required")]
        public byte ContractType
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.ContractType : new byte();
            }
            set
            {
                CCRMContractTypesMasterDTO.ContractType = value;
            }
        }
        public bool IsSpares
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.IsSpares : new bool();
            }
            set
            {
                CCRMContractTypesMasterDTO.IsSpares = value;
            }
        }
        public bool IsConsumables
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.IsConsumables : new bool();
            }
            set
            {
                CCRMContractTypesMasterDTO.IsConsumables = value;
            }
        }
        public bool ISService
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.ISService : new bool();
            }
            set
            {
                CCRMContractTypesMasterDTO.ISService = value;
            }
        }
        public bool IsRentMachine
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.IsRentMachine : new bool();
            }
            set
            {
                CCRMContractTypesMasterDTO.IsRentMachine = value;
            }
        }
        public int ItemCategoryMasterID
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.ItemCategoryMasterID > 0) ? CCRMContractTypesMasterDTO.ItemCategoryMasterID : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.ItemCategoryMasterID = value;
            }
        }
        public string ItemCategoryCode
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                CCRMContractTypesMasterDTO.ItemCategoryCode = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.CreatedBy > 0) ? CCRMContractTypesMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMContractTypesMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMContractTypesMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.ModifiedBy.HasValue) ? CCRMContractTypesMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.ModifiedDate.HasValue) ? CCRMContractTypesMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMContractTypesMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.DeletedBy.HasValue) ? CCRMContractTypesMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMContractTypesMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null && CCRMContractTypesMasterDTO.DeletedDate.HasValue) ? CCRMContractTypesMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMContractTypesMasterDTO.DeletedDate = value;
            }
        }
        public string SelectedCategoryMasterIDs
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.SelectedCategoryMasterIDs : string.Empty;
            }
            set
            {
                CCRMContractTypesMasterDTO.SelectedCategoryMasterIDs = value;
            }
        }
        public string StatusFlag
        {
            get
            {
                return (CCRMContractTypesMasterDTO != null) ? CCRMContractTypesMasterDTO.StatusFlag :string.Empty;
            }
            set
            {
                CCRMContractTypesMasterDTO.StatusFlag = value;
            }
        }

    }
}
