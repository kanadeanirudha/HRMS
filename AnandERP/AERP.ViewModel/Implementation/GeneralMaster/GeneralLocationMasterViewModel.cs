using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralLocationMasterBaseViewModel : IGeneralLocationMasterBaseViewModel
    {
        public GeneralLocationMasterBaseViewModel()
        {
            ListGeneralLocationMaster = new List<GeneralLocationMaster>();

            ListGeneralCountryMaster = new List<GeneralCountryMaster>();

            ListGeneralRegionMaster = new List<GeneralRegionMaster>();

            ListGeneralCityMaster = new List<GeneralCityMaster>();

        }

        public List<GeneralLocationMaster> ListGeneralLocationMaster
        {
            get;
            set;
        }

        public List<GeneralCountryMaster> ListGeneralCountryMaster
        {
            get;
            set;
        }

        public List<GeneralRegionMaster> ListGeneralRegionMaster
        {
            get;
            set;
        }

        public List<GeneralCityMaster> ListGeneralCityMaster
        {
            get;
            set;
        }

        public string SelectedCountryID
        {
            get;
            set;
        }

        public string SelectedRegionID
        {
            get;
            set;
        }

        public string SelectedCityID
        {
            get;
            set;
        }


        public IEnumerable<SelectListItem> ListGeneralRegionMasterItems
        {
            get
            {
                return new SelectList(ListGeneralRegionMaster, "RegionID", "RegionName");
            }
        }

        public IEnumerable<SelectListItem> ListGeneralCityMasterItems
        {
            get
            {
                return new SelectList(ListGeneralRegionMaster, "CityID", "Description");
            }
        }

    }


    public class GeneralLocationMasterViewModel : IGeneralLocationMasterViewModel
    {

        public GeneralLocationMasterViewModel()
        {
            GeneralLocationMasterDTO = new GeneralLocationMaster();
        }

        public GeneralLocationMaster GeneralLocationMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.ID > 0) ? GeneralLocationMasterDTO.ID : new int();
            }
            set
            {
                GeneralLocationMasterDTO.ID = value;
            }
        }
        public int CountryID
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.CountryID > 0) ? GeneralLocationMasterDTO.CountryID : new int();
            }
            set
            {
                GeneralLocationMasterDTO.CountryID = value;
            }
        }
        public int RegionID
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.RegionID > 0) ? GeneralLocationMasterDTO.RegionID : new int();
            }
            set
            {
                GeneralLocationMasterDTO.RegionID = value;
            }
        }

        public int CityID
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.CityID > 0) ? GeneralLocationMasterDTO.CityID : new int();
            }
            set
            {
                GeneralLocationMasterDTO.CityID = value;
            }
        }


        [Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.CountryName : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.CountryName = value;
            }
        }


        [Display(Name = "State Name")]
        public string RegionName
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.RegionName  : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.RegionName = value;
            }
        }


        [Display(Name = "City Name")]
        public string Description
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.Description = value;
            }
        }


        [Display(Name = "Location Address")]
        [Required(ErrorMessage ="Location Address Required")]
        public string LocationAddress
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.LocationAddress : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.LocationAddress = value;
            }
        }

        [Display(Name = "Post Code")]
        [Required(ErrorMessage ="Post Code Required")]
        public string PostCode
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.PostCode : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.PostCode = value;
            }
        }

        [Display(Name = "Latitude")]
        public string Latitude
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.Latitude : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.Latitude = value;
            }
        }

        [Display(Name = "Longitude")]
        public string Longitude
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.Longitude : string.Empty;
            }
            set
            {
                GeneralLocationMasterDTO.Longitude = value;
            }
        }

        [Display(Name = "Default Flag")]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.DefaultFlag : false;
            }
            set
            {
                GeneralLocationMasterDTO.DefaultFlag = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralLocationMasterDTO.IsDeleted = value;
            }
        }

        public bool IsUserDefined
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralLocationMasterDTO.IsUserDefined = value;
            }
        }
        
        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.CreatedBy > 0) ? GeneralLocationMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralLocationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralLocationMasterDTO != null) ? GeneralLocationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralLocationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.ModifiedBy.HasValue) ? GeneralLocationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralLocationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.ModifiedDate.HasValue) ? GeneralLocationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralLocationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.DeletedBy.HasValue) ? GeneralLocationMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralLocationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralLocationMasterDTO != null && GeneralLocationMasterDTO.DeletedDate.HasValue) ? GeneralLocationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralLocationMasterDTO.DeletedDate = value;
            }
        }

        [Display(Name = "Country Name")]
        [Required(ErrorMessage ="Country Required")]
        public string SelectedCountryID
        {
            get;
            set;
        }

        [Display(Name = "State Name")]
        [Required(ErrorMessage ="State Required")]
        public string SelectedRegionID
        {
            get;
            set;
        }

        [Display(Name = "City Name")]
        [Required(ErrorMessage ="City Required")]
        public string SelectedCityID
        {
            get;
            set;
        }
    }
}
