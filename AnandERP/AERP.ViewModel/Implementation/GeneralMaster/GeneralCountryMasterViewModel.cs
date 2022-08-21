using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralCountryMasterViewModel : IGeneralCountryMasterViewModel
    {

        public GeneralCountryMasterViewModel()
        {
            GeneralCountryMasterDTO = new GeneralCountryMaster();
        }

        public GeneralCountryMaster GeneralCountryMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ID > 0) ? GeneralCountryMasterDTO.ID : new int();
            }
            set
            {
                GeneralCountryMasterDTO.ID = value;
            }
        }

        [Display(Name = "Sequence No")]
        [Required(ErrorMessage = "Sequence No Required")]
        public Nullable<int> SeqNo
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.SeqNo > 0) ? GeneralCountryMasterDTO.SeqNo : new int();
            }
            set
            {
                GeneralCountryMasterDTO.SeqNo = value;
            }
        }
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public string CountryName
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.CountryName : string.Empty;
            }
            set
            {
                GeneralCountryMasterDTO.CountryName = value;
            }
        }

        [Display(Name = "Country Code")]
        [Required(ErrorMessage = "Contry Code Required")]
        public string ContryCode
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.ContryCode : string.Empty;
            }
            set
            {
                GeneralCountryMasterDTO.ContryCode = value;
            }
        }

        [Display(Name = "Default Flag")]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralCountryMasterDTO.DefaultFlag = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralCountryMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralCountryMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.CreatedBy > 0) ? GeneralCountryMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null) ? GeneralCountryMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ModifiedBy.HasValue) ? GeneralCountryMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.ModifiedDate.HasValue) ? GeneralCountryMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.DeletedBy.HasValue) ? GeneralCountryMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCountryMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralCountryMasterDTO != null && GeneralCountryMasterDTO.DeletedDate.HasValue) ? GeneralCountryMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCountryMasterDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

