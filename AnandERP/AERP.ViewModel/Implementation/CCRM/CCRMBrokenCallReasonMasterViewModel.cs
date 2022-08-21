using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
  public  class CCRMBrokenCallReasonMasterViewModel :ICCRMBrokenCallReasonMasterViewModel
    {
        public CCRMBrokenCallReasonMasterViewModel()
        {
            CCRMBrokenCallReasonMasterDTO = new CCRMBrokenCallReasonMaster();
        }
        public CCRMBrokenCallReasonMaster CCRMBrokenCallReasonMasterDTO
        {
            get;
            set;
        }
        public byte ID
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.ID > 0) ? CCRMBrokenCallReasonMasterDTO.ID : new byte();
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.ID = value;
            }
        }
        [Display(Name = "Reason Code")]
       // [Required(ErrorMessage = "Reason Code Required")]
        public string ReasonCode
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.ReasonCode : string.Empty;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.ReasonCode = value;
            }
        }
        [Display(Name = "Reason Description")]
        //[Required(ErrorMessage = "Reason Description Required")]
        public string ReasonDescription
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.ReasonDescription : string.Empty;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.ReasonDescription = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.CreatedBy > 0) ? CCRMBrokenCallReasonMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.ModifiedBy.HasValue) ? CCRMBrokenCallReasonMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.ModifiedDate.HasValue) ? CCRMBrokenCallReasonMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.DeletedBy.HasValue) ? CCRMBrokenCallReasonMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.DeletedDate.HasValue) ? CCRMBrokenCallReasonMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.VersionNumber = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null && CCRMBrokenCallReasonMasterDTO.LastSyncDate.HasValue) ? CCRMBrokenCallReasonMasterDTO.LastSyncDate : null;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (CCRMBrokenCallReasonMasterDTO != null) ? CCRMBrokenCallReasonMasterDTO.Entity : string.Empty;
            }
            set
            {
                CCRMBrokenCallReasonMasterDTO.Entity = value;
            }
        }
    }
}
