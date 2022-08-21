using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class CCRMSymptomMasterViewModel :ICCRMSymptomMasterViewModel
    {

        public CCRMSymptomMasterViewModel()
        {
            CCRMSymptomMasterDTO = new CCRMSymptomMaster();

        }

        public CCRMSymptomMaster CCRMSymptomMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.ID > 0) ? CCRMSymptomMasterDTO.ID : new int();
            }
            set
            {
                CCRMSymptomMasterDTO.ID = value;
            }
        }
        
        public int CCRMSymptomMasterID
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.CCRMSymptomMasterID > 0) ? CCRMSymptomMasterDTO.CCRMSymptomMasterID : new int();
            }
            set
            {
                CCRMSymptomMasterDTO.CCRMSymptomMasterID = value;
            }
        }
        [Required(ErrorMessage = "symtom Name should not be blank.")]
        [Display(Name = "Symptom Type Title")]
        public string SymptomTypeTitle
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomTypeTitle : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomTypeTitle = value;
            }
        }
        [Display(Name = "Symptom Type Code")]
        [Required(ErrorMessage = "symtom Code should not be blank.")]
        public string SymptomTypeCode
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomTypeCode : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomTypeCode = value;
            }
        }
        //[Required(ErrorMessage = "Symptom Type Description Name should not be blank.")]
        [Display(Name = "Symptom Type Description")]
        public string SymptomTypeDescription
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomTypeDescription : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomTypeDescription = value;
            }
        }

        [Required(ErrorMessage = "Symptom Name should not be blank.")]
        [Display(Name = "Symptom Title")]
        public string SymptomTitle

        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomTitle : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomTitle = value;
            }
        }
        [Required(ErrorMessage = "Symptom Code  should not be blank.")]
        [Display(Name = "Symptom Code")]
        public string SymptomCode

        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomCode : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomCode = value;
            }
        }
        //[Required(ErrorMessage = "Symptom DescriptionName should not be blank.")]
        [Display(Name = "Symptom Description")]
        public string SymptomDescription

        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SymptomDescription : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SymptomDescription = value;
            }
        }

        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.CreatedBy > 0) ? CCRMSymptomMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMSymptomMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMSymptomMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMSymptomMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.ModifiedBy.HasValue) ? CCRMSymptomMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMSymptomMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.ModifiedDate.HasValue) ? CCRMSymptomMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMSymptomMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.DeletedBy.HasValue) ? CCRMSymptomMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMSymptomMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.DeletedDate.HasValue) ? CCRMSymptomMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMSymptomMasterDTO.DeletedDate = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMSymptomMasterDTO != null && CCRMSymptomMasterDTO.LastSyncDate.HasValue) ? CCRMSymptomMasterDTO.LastSyncDate :null;
            }
            set
            {
                CCRMSymptomMasterDTO.LastSyncDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string SyncType
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.SyncType = value;
            }
        }
        public string VersionNumber
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.VersionNumber = value;
            }
        }

        public string Entity
        {
            get
            {
                return (CCRMSymptomMasterDTO != null) ? CCRMSymptomMasterDTO.Entity : string.Empty;
            }
            set
            {
                CCRMSymptomMasterDTO.Entity = value;
            }
        }
    }
}

