using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
  public  class CCRMServiceCallTypesViewModel :ICCRMServiceCallTypesViewModel
    {
        public CCRMServiceCallTypesViewModel()
        {
            CCRMServiceCallTypesDTO = new CCRMServiceCallTypes();
        }
        public CCRMServiceCallTypes CCRMServiceCallTypesDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.ID > 0) ? CCRMServiceCallTypesDTO.ID : new byte();
            }
            set
            {
                CCRMServiceCallTypesDTO.ID = value;
            }
        }
        [Display(Name = "Call Type Code")]
        [Required(ErrorMessage = "Call Type Code Required")]
        public string CallTypeCode
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.CallTypeCode : string.Empty;
            }
            set
            {
                CCRMServiceCallTypesDTO.CallTypeCode = value;
            }
        }
        [Display(Name = "Call Type Name")]
        [Required(ErrorMessage = "Call Type Name Required")]
        public string CallTypeName
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.CallTypeName : string.Empty;
            }
            set
            {
                CCRMServiceCallTypesDTO.CallTypeName = value;
            }
        }
        [Display(Name = "IS Calculate Responce Time")]
        public bool ISCalculateResponceTime
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.ISCalculateResponceTime : false;
            }
            set
            {
                CCRMServiceCallTypesDTO.ISCalculateResponceTime = value;
            }
        }
        [Display(Name = "IS PM Call")]
        public bool ISPMCall
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.ISPMCall : false;
            }
            set
            {
                CCRMServiceCallTypesDTO.ISPMCall = value;
            }
        }
        [Display(Name = "IS Service Report Required")]
        public bool ISServiceReportRequired
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.ISServiceReportRequired : false;
            }
            set
            {
                CCRMServiceCallTypesDTO.ISServiceReportRequired = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.CreatedBy > 0) ? CCRMServiceCallTypesDTO.CreatedBy : new int();
            }
            set
            {
                CCRMServiceCallTypesDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.IsDeleted : false;
            }
            set
            {
                CCRMServiceCallTypesDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceCallTypesDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.ModifiedBy.HasValue) ? CCRMServiceCallTypesDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMServiceCallTypesDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.ModifiedDate.HasValue) ? CCRMServiceCallTypesDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceCallTypesDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.DeletedBy.HasValue) ? CCRMServiceCallTypesDTO.DeletedBy : new int();
            }
            set
            {
                CCRMServiceCallTypesDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.DeletedDate.HasValue) ? CCRMServiceCallTypesDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceCallTypesDTO.DeletedDate = value;
            }
        }
        public string VersionNumber
        {

            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMServiceCallTypesDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null && CCRMServiceCallTypesDTO.LastSyncDate.HasValue) ? CCRMServiceCallTypesDTO.LastSyncDate : null;
            }
            set
            {
                CCRMServiceCallTypesDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMServiceCallTypesDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (CCRMServiceCallTypesDTO != null) ? CCRMServiceCallTypesDTO.Entity : string.Empty;
            }
            set
            {
                CCRMServiceCallTypesDTO.Entity = value;
            }
        }
    }
}
