using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMActionMasterViewModel :ICCRMActionMasterViewModel
    {
        public CCRMActionMasterViewModel()
        {
            CCRMActionMasterDTO = new CCRMActionMaster();
        }
        public CCRMActionMaster CCRMActionMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.ID > 0) ? CCRMActionMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMActionMasterDTO.ID = value;
            }
        }
        [Display(Name = "Action Code")]
        [Required(ErrorMessage = "Action Code Required")]
        public string ActionCode
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.ActionCode : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.ActionCode = value;
            }
        }
        [Display(Name = "Action Title")]
        [Required(ErrorMessage = "Action Title Required")]
        public string ActionTitle
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.ActionTitle : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.ActionTitle = value;
            }
        }
        [Display(Name = "Action Desciption")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public string ActionDesciption
        {

            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.ActionDesciption : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.ActionDesciption = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.CreatedBy > 0) ? CCRMActionMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMActionMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMActionMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMActionMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.ModifiedBy.HasValue) ? CCRMActionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMActionMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.ModifiedDate.HasValue) ? CCRMActionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMActionMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.DeletedBy.HasValue) ? CCRMActionMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMActionMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.DeletedDate.HasValue) ? CCRMActionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMActionMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMActionMasterDTO != null && CCRMActionMasterDTO.LastSyncDate.HasValue) ? CCRMActionMasterDTO.LastSyncDate : null;
            }
            set
            {
                CCRMActionMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (CCRMActionMasterDTO != null) ? CCRMActionMasterDTO.Entity : string.Empty;
            }
            set
            {
                CCRMActionMasterDTO.Entity = value;
            }
        }
    }
}
