using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralCityMasterBaseViewModel : IGeneralCityMasterBaseViewModel
    {
        public GeneralCityMasterBaseViewModel()
        {
            ListGeneralCityMaster = new List<GeneralCityMaster>();

            ListGeneralRegionMaster = new List<GeneralRegionMaster>();
            ListGeneralCountryMaster = new List<GeneralCountryMaster>();
        }

        public List<GeneralCityMaster> ListGeneralCityMaster
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
                return new SelectList(ListGeneralCountryMaster, "CountryCode", "CountryName");
            }
        }

        public List<GeneralRegionMaster> ListGeneralRegionMaster
        {
            get;
            set;
        }

        public string SelectedRegionID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralRegionMasterItems
        {
            get
            {
                return new SelectList(ListGeneralRegionMaster, "RegionCode", "RegionName");
            }
        }

    }





    public class GeneralCityMasterViewModel : IGeneralCityMasterViewModel
    {

        public GeneralCityMasterViewModel()
        {
            GeneralCityMasterDTO = new GeneralCityMaster();
        }

        public GeneralCityMaster GeneralCityMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.ID > 0) ? GeneralCityMasterDTO.ID : new int();
            }
            set
            {
                GeneralCityMasterDTO.ID = value;
            }
        }
        [Display(Name = "State Name")]
        [Required(ErrorMessage ="State Name Required")]
        public Nullable<int> RegionID
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.RegionID > 0) ? GeneralCityMasterDTO.RegionID : new int();
            }
            set
            {
                GeneralCityMasterDTO.RegionID = value;
            }
        }
        public string RegionName
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.RegionName : string.Empty;
            }
            set
            {
                GeneralCityMasterDTO.RegionName = value;
            }
        }
        public string RegionCode
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.RegionCode : string.Empty;
            }
            set
            {
                GeneralCityMasterDTO.RegionCode = value;
            }
        }
        public Nullable<int> CountryID
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.CountryID > 0) ? GeneralCityMasterDTO.CountryID : new int();
            }
            set
            {
                GeneralCityMasterDTO.CountryID = value;
            }
        }

        public string CountryName
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.CountryName : string.Empty;
            }
            set
            {
                GeneralCityMasterDTO.CountryName = value;
            }
        }
        public string CountryCode
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.CountryCode : string.Empty;
            }
            set
            {
                GeneralCityMasterDTO.CountryCode = value;
            }
        }


        [Display(Name = "Description")]
        [Required(ErrorMessage ="Description Required")]
        public string Description
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralCityMasterDTO.Description = value;
            }
        }

        [Display(Name = "DisplayName_MakeitDefault", ResourceType = typeof(AERP.Common.Resources))]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralCityMasterDTO.DefaultFlag = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralCityMasterDTO.IsDeleted = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralCityMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.CreatedBy > 0) ? GeneralCityMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralCityMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralCityMasterDTO != null) ? GeneralCityMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralCityMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.ModifiedBy.HasValue) ? GeneralCityMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralCityMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.ModifiedDate.HasValue) ? GeneralCityMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralCityMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.DeletedBy.HasValue) ? GeneralCityMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralCityMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralCityMasterDTO != null && GeneralCityMasterDTO.DeletedDate.HasValue) ? GeneralCityMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralCityMasterDTO.DeletedDate = value;
            }
        }
        [Required(ErrorMessage = "Country should not be blank.")]
        [Display(Name = "Country")]
        public string SelectedCountryID
        {
            get;
            set;
        }
        [Display(Name = "State Name")]
        [Required(ErrorMessage ="State Name Required")]
        public string SelectedRegionID
        {
            get;
            set;
        }
    }
}
