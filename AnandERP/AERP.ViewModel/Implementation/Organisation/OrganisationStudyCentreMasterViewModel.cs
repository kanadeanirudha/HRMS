using System;
using AERP.Common;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AERP.ViewModel
{

    public class OrganisationStudyCentreMasterBaseViewModel : IOrganisationStudyCentreMasterBaseViewModel
    {
        public OrganisationStudyCentreMasterBaseViewModel()
        {
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();

            ListGeneralCityMaster = new List<GeneralCityMaster>();

            ListOrganisationMaster = new List<OrganisationMaster>();

            //ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }

        public List<GeneralCityMaster> ListGeneralCityMaster
        {
            get;
            set;
        }

        public List<OrganisationMaster> ListOrganisationMaster
        {
            get;
            set;
        }

        //public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        //{
        //    get;
        //    set;
        //}

        public string SelectedCityID
        {
            get;
            set;
        }

        public string SelectedOrganisationID
        {
            get;
            set;
        }

        public string SelectedUniversityID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralCityMasterItems
        {
            get
            {
                return new SelectList(ListGeneralCityMaster, "ID", "Description");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationMaster, "ID", "OrgName");
            }
        }
    }

    public class OrganisationStudyCentreMasterViewModel : IOrganisationStudyCentreMasterViewModel
    {
        public OrganisationStudyCentreMasterViewModel()
        {
            OrganisationStudyCentreMasterDTO = new OrganisationStudyCentreMaster();
            //OrganisationUniversityMasterDTO = new OrganisationUniversityMaster();
        }
        public OrganisationStudyCentreMaster OrganisationStudyCentreMasterDTO { get; set; }
        
        //public OrganisationUniversityMaster OrganisationUniversityMasterDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.ID > 0) ? OrganisationStudyCentreMasterDTO.ID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ID = value;
            }
        }
        
        [Display(Name = "Centre Code")]
        [Required(ErrorMessage ="Centre Code Required")]
        public string CentreCode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        [Required(ErrorMessage ="Centre Name Required")]
        public string CentreName
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreName = value;
            }
        }
        [Display(Name = "Office Type")]
        [Required(ErrorMessage ="Office Type Required")]

        public string HoCoRoScFlag
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.HoCoRoScFlag : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.HoCoRoScFlag = value;
            }
        }

        [Display(Name = "HoID")]
        public Nullable<int> HoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.HoID > 0) ? OrganisationStudyCentreMasterDTO.HoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.HoID = value;
            }
        }


        [Display(Name = "CoID")]
        public Nullable<int> CoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CoID > 0) ? OrganisationStudyCentreMasterDTO.CoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CoID = value;
            }
        }
        [Display(Name = "Office Belong To")]
        public Nullable<int> RoID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.RoID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.RoID = value;
            }
        }

        [Display(Name = "Centre Specialization")]
        public string CentreSpecialization
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreSpecialization : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreSpecialization = value;
            }
        }

        [Display(Name = "Address")]
        [Required(ErrorMessage ="Address Required")]
        public string CentreAddress
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreAddress : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreAddress = value;
            }
        }

        [Display(Name = "Plot No")]
        public string PlotNo
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.PlotNo : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.PlotNo = value;
            }
        }
        [Display(Name = "Street Name")]
        public string StreetName
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.StreetName : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.StreetName = value;
            }
        }

        [Display(Name = "City")]
        public Nullable<int> CityID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CityID > 0) ? OrganisationStudyCentreMasterDTO.CityID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CityID = value;
            }
        }
        [Display(Name = "Pincode")]
        [Required(ErrorMessage ="Pincode Required")]
        public string Pincode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.Pincode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Pincode = value;
            }
        }
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,3})$", ErrorMessage = "Please enter a valid email id.")]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage ="Email Address Required")]
        public string EmailID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.EmailID : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.EmailID = value;
            }
        }
        
        [Display(Name = "Url")]
        [Required(ErrorMessage ="Url Required")]
        public string Url
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.Url : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Url = value;
            }
        }
         [Display(Name = "Mobile Number")]
        public string CellPhone
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CellPhone : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CellPhone = value;
            }
        }
        
        [Display(Name = "Fax Number")]
        public string FaxNumber
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.FaxNumber : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.FaxNumber = value;
            }
        }
        [Display(Name = "Phone Number Office")]
        [Required(ErrorMessage ="Phone Number Office Required")]
        public string PhoneNumberOffice
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.PhoneNumberOffice : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.PhoneNumberOffice = value;
            }
        }
        
        [Display(Name = "Centre Establishment Date")]
        public string CentreEstablishmentDatetime
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime = value;
            }
        }
        
        [Display(Name = "Organisation")]
        public Nullable<int> OrganisationID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.OrganisationID > 0) ? OrganisationStudyCentreMasterDTO.OrganisationID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.OrganisationID = value;
            }
        }
        
        [Display(Name = "University Name")]
        public Nullable<int> UniversityID
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.UniversityID > 0) ? OrganisationStudyCentreMasterDTO.UniversityID : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.UniversityID = value;
            }
        }
        
        [Display(Name = "Centre Login Number")]
        public Nullable<int> CentreLoginNumber
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CentreLoginNumber > 0) ? OrganisationStudyCentreMasterDTO.CentreLoginNumber : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CentreLoginNumber = value;
            }
        }
        
        [Display(Name = "Institute Code")]
        public string InstituteCode
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.InstituteCode : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.InstituteCode = value;
            }
        }
        
        [Display(Name = "TimeZone")]
        [Required(ErrorMessage ="Timezone Required")]
        public string TimeZone
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.TimeZone : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.TimeZone = value;
            }
        }
        [Display(Name = "Latitude")]
        [Required(ErrorMessage ="Latitude Required")]
        
        public decimal Latitude
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.Latitude > 0) ? OrganisationStudyCentreMasterDTO.Latitude : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Latitude = value;
            }
        }
        [Display(Name = "Longitude")]
        [Required(ErrorMessage ="Longitude Required")]
        public decimal Longitude 
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.Longitude > 0) ? OrganisationStudyCentreMasterDTO.Longitude : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.Longitude = value;
            }
        } 
        [Display(Name = "Campus Area")]
        [Required(ErrorMessage ="Campus Area Required")]
        public decimal CampusArea 
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CampusArea > 0) ? OrganisationStudyCentreMasterDTO.CampusArea : new decimal();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CampusArea = value;
            }
        }
        [Display(Name = "User Type")]
        public string UserType
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.UserType : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.UserType = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.CreatedBy > 0) ? OrganisationStudyCentreMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CreatedBy = value;
            }
        }


        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.CreatedDate = value;
            }
        }


        [Display(Name = "ModifiedBy")]
        public Nullable<int> ModifiedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.ModifiedBy > 0) ? OrganisationStudyCentreMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ModifiedBy = value;
            }
        }


        [Display(Name = "ModifiedDate")]
        public Nullable<DateTime> ModifiedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.ModifiedDate = value;
            }
        }


        [Display(Name = "DeletedBy")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null && OrganisationStudyCentreMasterDTO.DeletedBy > 0) ? OrganisationStudyCentreMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationStudyCentreMasterDTO.DeletedBy = value;
            }
        }


        [Display(Name = "DeletedDate")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.DeletedDate = value;
            }
        }
        public string IDs
        {
            get
            {
                return (OrganisationStudyCentreMasterDTO != null) ? OrganisationStudyCentreMasterDTO.IDs : string.Empty;
            }
            set
            {
                OrganisationStudyCentreMasterDTO.IDs = value;
            }
        }
        [Display(Name = "City")]
        [Required(ErrorMessage ="City Required")]
        public string SelectedCityID
        {
            get;
            set;
        }
        [Display(Name = "Organisation Name")]
        [Required(ErrorMessage ="Organisation Required")]
        public string SelectedOrganisationID
        {
            get;
            set;
        }

        public string SelectedUniversityID
        {
            get;
            set;
        }
        //public List<OrganisationUniversityMaster> OrganisationUniversityMasterList
        //{
        //    get;
        //    set;
        //}
        //public IEnumerable<SelectListItem> OrganisationUniversityMasterListItems
        //{
        //    get
        //    {
        //        return new SelectList(OrganisationUniversityMasterList, "ID", "Description");
        //    }
        //}


    }
}
