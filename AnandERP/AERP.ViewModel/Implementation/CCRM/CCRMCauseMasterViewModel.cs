using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
  public  class CCRMCauseMasterViewModel :ICCRMCauseMasterViewModel
    {
        public CCRMCauseMasterViewModel()
        {
            CCRMCauseMasterDTO = new CCRMCauseMaster();

        }
        public CCRMCauseMaster CCRMCauseMasterDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.ID > 0) ? CCRMCauseMasterDTO.ID : new int();
            }
            set
            {
                CCRMCauseMasterDTO.ID = value;
            }
        }

        public int CCRMCauseMasterID
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.CCRMCauseMasterID > 0) ? CCRMCauseMasterDTO.CCRMCauseMasterID : new int();
            }
            set
            {
                CCRMCauseMasterDTO.CCRMCauseMasterID = value;
            }
        }
        [Required(ErrorMessage = "Cause Type Title should not be blank.")]
        [Display(Name = "Cause Type Title")]
        public string CauseTypeTitle
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseTypeTitle : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseTypeTitle = value;
            }
        }
        [Display(Name = "Cause Type Code")]
        [Required(ErrorMessage = "Cause Type Code should not be blank.")]
        public string CauseTypeCode
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseTypeCode : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseTypeCode = value;
            }
        }

       // [Required(ErrorMessage = "Cause Type Description Name should not be blank.")]
        [Display(Name = "Cause Type Description")]
        public string CauseTypeDescription
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseTypeDescription : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseTypeDescription = value;
            }
        }
        [Required(ErrorMessage = "Cause Title should not be blank.")]
        [Display(Name = "Cause Title")]
        public string CauseTitle

        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseTitle : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseTitle = value;
            }
        }
        [Required(ErrorMessage = "Cause Code Name should not be blank.")]
        [Display(Name = "Cause Code")]
        public string CauseCode

        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseCode : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseCode = value;
            }
        }
        //[Required(ErrorMessage = "Cause Description should not be blank.")]
        [Display(Name = "Cause Description")]
        public string CauseDescription

        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CauseDescription : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.CauseDescription = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.CreatedBy > 0) ? CCRMCauseMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCauseMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMCauseMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCauseMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.ModifiedBy.HasValue) ? CCRMCauseMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCauseMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.ModifiedDate.HasValue) ? CCRMCauseMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCauseMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.DeletedBy.HasValue) ? CCRMCauseMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCauseMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.DeletedDate.HasValue) ? CCRMCauseMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCauseMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }

        public string VersionNumber
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.VersionNumber = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMCauseMasterDTO != null && CCRMCauseMasterDTO.LastSyncDate.HasValue) ? CCRMCauseMasterDTO.LastSyncDate : null;
            }
            set
            {
                CCRMCauseMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.SyncType = value;
            }
        }

        public string Entity
        {
            get
            {
                return (CCRMCauseMasterDTO != null) ? CCRMCauseMasterDTO.Entity : string.Empty;
            }
            set
            {
                CCRMCauseMasterDTO.Entity = value;
            }
        }
    }
}
