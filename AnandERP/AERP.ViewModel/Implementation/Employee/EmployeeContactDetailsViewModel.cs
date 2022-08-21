using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeContactDetailsViewModel
    {
        public EmployeeContactDetailsViewModel()
        {
            EmployeeContactDetailsDTO = new EmployeeContactDetails();
        }
        public EmployeeContactDetails EmployeeContactDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ID > 0) ? EmployeeContactDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ID = value;
            }
        }

        public int ContactID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ContactID > 0) ? EmployeeContactDetailsDTO.ContactID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ContactID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.EmployeeID > 0) ? EmployeeContactDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeID = value;
            }
        }

        [Display(Name = "Address Type")]
        [Required(ErrorMessage ="Address Type Required")]
        public string AddressType
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.AddressType : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.AddressType = value;
            }
        }
        [Display(Name = "Employee Address1")]
        [Required(ErrorMessage ="Employee Address1 Required")]
        public string EmployeeAddress1
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.EmployeeAddress1 : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeAddress1 = value;
            }
        }

        [Display(Name = "Employee Address2")]
        public string EmployeeAddress2
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.EmployeeAddress2 : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.EmployeeAddress2 = value;
            }
        }

        [Display(Name = "Plot Number")]
        public string PlotNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.PlotNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.PlotNumber = value;
            }
        }

        [Display(Name = "Street Name")]
        public string StreetName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.StreetName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.StreetName = value;
            }
        }

        [Display(Name = "Country")]
        [Required(ErrorMessage ="Country Required")]
        public int CountryID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CountryID > 0) ? EmployeeContactDetailsDTO.CountryID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CountryID = value;
            }
        }

        [Display(Name = "Region")]
        [Required(ErrorMessage ="Region Required")]
        public int RegionID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.RegionID > 0) ? EmployeeContactDetailsDTO.RegionID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.RegionID = value;
            }
        }

        [Display(Name = "City")]
        [Required(ErrorMessage ="City Required")]
        public int CityID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CityID > 0) ? EmployeeContactDetailsDTO.CityID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CityID = value;
            }
        }

        [Display(Name = "Location")]
        public int ContactLocationID
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.ContactLocationID : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ContactLocationID = value;
            }
        }

        [Display(Name = "Pincode")]
        public string Pincode
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.Pincode : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.Pincode = value;
            }
        }

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.TelephoneNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.TelephoneNumber = value;
            }
        }

        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.MobileNumber : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.MobileNumber = value;
            }
        }

         [Display(Name = "Current Address")]
        public bool CurrentAddressFlag
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CurrentAddressFlag : false;
            }
            set
            {
                EmployeeContactDetailsDTO.CurrentAddressFlag = value;
            }
        }

        [Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CountryName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.CountryName = value;
            }
        }

        [Display(Name = "Region Name")]
        public string RegionName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.RegionName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.RegionName = value;
            }
        }

        [Display(Name = "City Name")]
        public string CityName
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CityName : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.CityName = value;
            }
        }

        [Display(Name = "Location")]
        //[Required(ErrorMessage ="Location Required")]
        public string Location
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.Location : string.Empty;
            }
            set
            {
                EmployeeContactDetailsDTO.Location = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeContactDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.CreatedBy > 0) ? EmployeeContactDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null) ? EmployeeContactDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ModifiedBy.HasValue) ? EmployeeContactDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.ModifiedDate.HasValue) ? EmployeeContactDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.DeletedBy.HasValue) ? EmployeeContactDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeContactDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeContactDetailsDTO != null && EmployeeContactDetailsDTO.DeletedDate.HasValue) ? EmployeeContactDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeContactDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}
