using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public class GeneralRegionMasterBaseViewModel : IGeneralRegionMasterBaseViewModel
    {
        public GeneralRegionMasterBaseViewModel()
        {
            ListGeneralRegionMaster = new List<GeneralRegionMaster>();

            ListGeneralCountryMaster = new List<GeneralCountryMaster>();

        }

        public List<GeneralRegionMaster> ListGeneralRegionMaster
        {
            get;
            set;
        }

        public List<GeneralCountryMaster> ListGeneralCountryMaster
        {
            get;
            set;
        }

        public string SelectedCountryID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralCountryMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCountryMaster, "CountryCode", "Description");
            }
        }

    }


    public class GeneralRegionMasterViewModel : IGeneralRegionMasterViewModel
    {

        public GeneralRegionMasterViewModel()
        {
            GeneralRegionMasterDTO = new GeneralRegionMaster();
        }

        public GeneralRegionMaster GeneralRegionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.ID > 0) ? GeneralRegionMasterDTO.ID : new int();
            }
            set
            {
                GeneralRegionMasterDTO.ID = value;
            }
        }

        [Display(Name = "Country Name")]
        public Nullable<int> CountryID
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.CountryID > 0) ? GeneralRegionMasterDTO.CountryID : new int();
            }
            set
            {
                GeneralRegionMasterDTO.CountryID = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.CountryCode : string.Empty;
            }
            set
            {
                GeneralRegionMasterDTO.CountryCode = value;
            }
        }

        [Display(Name = "State Name")]
        [Required(ErrorMessage = "State Name Required")]
        public string RegionName
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.RegionName : string.Empty;
            }
            set
            {
                GeneralRegionMasterDTO.RegionName = value;
            }
        }

        [Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.CountryName : string.Empty;
            }
            set
            {
                GeneralRegionMasterDTO.CountryName = value;
            }
        }

        [Display(Name = "Short Name")]
        [Required(ErrorMessage = "Short Name Required")]
        public string ShortName
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.ShortName : string.Empty;
            }
            set
            {
                GeneralRegionMasterDTO.ShortName = value;
            }
        }

        [Display(Name = "Default Flag")]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralRegionMasterDTO.DefaultFlag = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralRegionMasterDTO.IsDeleted = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralRegionMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.CreatedBy > 0) ? GeneralRegionMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralRegionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralRegionMasterDTO != null) ? GeneralRegionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralRegionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.ModifiedBy.HasValue) ? GeneralRegionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralRegionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.ModifiedDate.HasValue) ? GeneralRegionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralRegionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.DeletedBy.HasValue) ? GeneralRegionMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralRegionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.DeletedDate.HasValue) ? GeneralRegionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralRegionMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "Country Name Required")]
        public string SelectedCountryID
        {
            get;
            set;
        }
        [Display(Name = "Tin Number")]
        [Required(ErrorMessage = "Tin Number Required")]
        public int TinNumber
        {
            get
            {
                return (GeneralRegionMasterDTO != null && GeneralRegionMasterDTO.TinNumber > 0) ? GeneralRegionMasterDTO.TinNumber : new int();
            }
            set
            {
                GeneralRegionMasterDTO.TinNumber = value;
            }
        }

    }
}
