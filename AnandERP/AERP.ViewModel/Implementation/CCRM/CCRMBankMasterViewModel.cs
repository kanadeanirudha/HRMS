using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
   public class CCRMBankMasterViewModel : ICCRMBankMasterViewModel
    {
        public CCRMBankMasterViewModel()
        {
            CCRMBankMasterDTO = new CCRMBankMaster();
        }
        public CCRMBankMaster CCRMBankMasterDTO
        {
            get;
            set;
        }
        public Int16 ID
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.ID > 0) ? CCRMBankMasterDTO.ID : new byte();
            }
            set
            {
                CCRMBankMasterDTO.ID = value;
            }
        }
        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Bank Name Required")]
        public string BankName
        {
            get
            {
                return (CCRMBankMasterDTO != null) ? CCRMBankMasterDTO.BankName : string.Empty;
            }
            set
            {
                CCRMBankMasterDTO.BankName = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.CreatedBy > 0) ? CCRMBankMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMBankMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMBankMasterDTO != null) ? CCRMBankMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMBankMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMBankMasterDTO != null) ? CCRMBankMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMBankMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.ModifiedBy.HasValue) ? CCRMBankMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMBankMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.ModifiedDate.HasValue) ? CCRMBankMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMBankMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.DeletedBy.HasValue) ? CCRMBankMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMBankMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMBankMasterDTO != null && CCRMBankMasterDTO.DeletedDate.HasValue) ? CCRMBankMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMBankMasterDTO.DeletedDate = value;
            }
        }
    }
}
