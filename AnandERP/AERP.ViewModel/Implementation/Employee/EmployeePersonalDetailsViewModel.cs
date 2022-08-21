using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeePersonalDetailsViewModel
    {
        public EmployeePersonalDetailsViewModel()
        {
            EmployeePersonalDetailsDTO = new EmployeePersonalDetails();
        }

        public EmployeePersonalDetails EmployeePersonalDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.ID > 0) ? EmployeePersonalDetailsDTO.ID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.EmployeeID > 0) ? EmployeePersonalDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.EmployeeID = value;
            }
        }
        [Display(Name = "DisplayName_PlaceOfBirth", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PlaceOfBirthRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string PlaceOfBirth
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.PlaceOfBirth : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.PlaceOfBirth = value;
            }
        }

        public int ReligionID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.ReligionID > 0) ? EmployeePersonalDetailsDTO.ReligionID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.ReligionID = value;
            }
        }

        public int CategoryID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.CategoryID > 0) ? EmployeePersonalDetailsDTO.CategoryID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.CategoryID = value;
            }
        }

        public int CasteID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.CasteID > 0) ? EmployeePersonalDetailsDTO.CasteID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.CasteID = value;
            }
        }

        public int SubCasteID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.SubCasteID > 0) ? EmployeePersonalDetailsDTO.SubCasteID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.SubCasteID = value;
            }
        }

        [Display(Name = "DisplayName_Hobby", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_HobbyRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string Hobby
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.Hobby : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.Hobby = value;
            }
        }

        [Display(Name = "Got Any Medal?")]
        public bool GotAnyMedal
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.GotAnyMedal : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.GotAnyMedal = value;
            }
        }

        [Display(Name = "Got Any Scholarship?")]
        public bool GotAnyScholarship
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.GotAnyScholarship : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.GotAnyScholarship = value;
            }
        }

        [Display(Name = "DisplayName_IdentifacationMark", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_IdentifacationMarkRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string IdentifacationMark
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.IdentifacationMark : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.IdentifacationMark = value;
            }
        }

        [Display(Name = "DisplayName_BloodGroup", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BloodGroupRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string BloodGroup
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.BloodGroup : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.BloodGroup = value;
            }
        }


        [Display(Name = "DisplayName_Allergy", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AllergyRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string Allergy
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.Allergy : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.Allergy = value;
            }
        }

        [Display(Name = "DisplayName_CreditCardNumber", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CreditCardNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CreditCardNumber
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.CreditCardNumber : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.CreditCardNumber = value;
            }
        }

        [Display(Name = "DisplayName_ControlHead", ResourceType = typeof(AERP.Common.Resources))]
        //   [Display(Name = "ControlHead")]
        public bool ControlHead
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.ControlHead : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.ControlHead = value;
            }
        }

        [Display(Name = "DisplayName_BankAccountCodek", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankAccountCodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string BankAccountCode
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.BankAccountCode : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.BankAccountCode = value;
            }
        }

        public int MotherTongueID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.MotherTongueID > 0) ? EmployeePersonalDetailsDTO.MotherTongueID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.MotherTongueID = value;
            }
        }

        [Display(Name = "DisplayName_BankCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_BankCodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string BankCode
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.BankCode : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.BankCode = value;
            }
        }

        [Display(Name = "DisplayName_SelectionCasteCategory", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectionCasteCategoryRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string SelectionCasteCategory
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.SelectionCasteCategory : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.SelectionCasteCategory = value;
            }
        }

        [Display(Name = "DisplayName_AddressType", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_AddressTypeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string AddressType
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.AddressType : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.AddressType = value;
            }
        }


        //[Display(Name = "DisplayName_EmployeeAddress1", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeAddress1Required")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeAddress1
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.EmployeeAddress1 : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.EmployeeAddress1 = value;
            }
        }

        //[Display(Name = "DisplayName_EmployeeAddress2", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeAddress2Required")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string EmployeeAddress2
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.EmployeeAddress2 : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.EmployeeAddress2 = value;
            }
        }

        ////[Display(Name = "DisplayName_PlotNumber", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PlotNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string PlotNumber
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.PlotNumber : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.PlotNumber = value;
            }
        }

        //[Display(Name = "DisplayName_StreetName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreetNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string StreetName
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.StreetName : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.StreetName = value;
            }
        }

        public int CountryID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.CountryID > 0) ? EmployeePersonalDetailsDTO.CountryID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.CountryID = value;
            }
        }

        public int RegionID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.RegionID > 0) ? EmployeePersonalDetailsDTO.RegionID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.RegionID = value;
            }
        }

        public int CityID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.CityID > 0) ? EmployeePersonalDetailsDTO.CityID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.CityID = value;
            }
        }

        public int LocationID
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.LocationID > 0) ? EmployeePersonalDetailsDTO.LocationID : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.LocationID = value;
            }
        }

        //[Display(Name = "DisplayName_CountryName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CountryNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string CountryName
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.CountryName : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.CountryName = value;
            }
        }

        //[Display(Name = "DisplayName_CityName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "City Name")]
        public string RegionName
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.RegionName : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.RegionName = value;
            }
        }

        //[Display(Name = "DisplayName_CityName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "City Name")]
        public string CityName
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.CityName : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.CityName = value;
            }
        }

        //[Display(Name = "DisplayName_Location", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CityNameRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "City Name")]
        public string Location
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.Location : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.Location = value;
            }
        }

        //[Display(Name = "DisplayName_Pincode", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PincodeRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string Pincode
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.Pincode : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.Pincode = value;
            }
        }

        //[Display(Name = "DisplayName_TelephoneNumber", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TelephoneNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string TelephoneNumber
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.TelephoneNumber : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.TelephoneNumber = value;
            }
        }

        //[Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(AERP.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        //[Required(ErrorMessage = "Country name should not be blank.")]
        //[Display(Name = "Country Name")]
        public string MobileNumber
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.MobileNumber : string.Empty;
            }
            set
            {
                EmployeePersonalDetailsDTO.MobileNumber = value;
            }
        }

      //  [Display(Name = "CurrentAddressFlag")]
        [Display(Name = "DisplayName_CurrentAddressFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool CurrentAddressFlag
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.CurrentAddressFlag : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.CurrentAddressFlag = value;
            }
        }

       [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeePersonalDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.CreatedBy > 0) ? EmployeePersonalDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null) ? EmployeePersonalDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePersonalDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.ModifiedBy.HasValue) ? EmployeePersonalDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.ModifiedDate.HasValue) ? EmployeePersonalDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePersonalDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.DeletedBy.HasValue) ? EmployeePersonalDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePersonalDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePersonalDetailsDTO != null && EmployeePersonalDetailsDTO.DeletedDate.HasValue) ? EmployeePersonalDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePersonalDetailsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

