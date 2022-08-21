using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeDependentsViewModel : IEmployeeDependentsViewModel
    {

        public EmployeeDependentsViewModel()
        {
            EmployeeDependentsDTO = new EmployeeDependents();
        }

        public EmployeeDependents EmployeeDependentsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.ID > 0) ? EmployeeDependentsDTO.ID : new int();
            }
            set
            {
                EmployeeDependentsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeDependentsDTO.EmployeeID = value;
            }
        }

        public int SequenceNumber
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.SequenceNumber : new int();
            }
            set
            {
                EmployeeDependentsDTO.SequenceNumber = value;
            }
        }


        [Display(Name = "DisplayName_NameTitle", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_NameTitleRequired")]
        public string NameTitle
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.NameTitle : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.NameTitle = value;
            }
        }

        [Display(Name = "DisplayName_DependentName", ResourceType = typeof(Resources))]
     //   [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DependentNameRequired")]
        public string DependentName
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.DependentName : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.DependentName = value;
            }
        }


        [Display(Name = "DisplayName_Address1", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string Address1
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.Address1 : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.Address1 = value;
            }
        }

        [Display(Name = "DisplayName_GenderCode", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_Address1Required")]
        public string GenderCode
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.GenderCode : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.GenderCode = value;
            }
        }



        [Display(Name = "DisplayName_Address2", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_Address2Required")]
        public string Address2
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.Address2 : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.Address2 = value;
            }
        }

        [Display(Name = "DisplayName_CountryID", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CountryIDRequired")]
        public int CountryID
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.CountryID > 0) ? EmployeeDependentsDTO.CountryID : new int();
            }
            set
            {
                EmployeeDependentsDTO.CountryID = value;
            }
        }


        [Display(Name = "DisplayName_RegionID", ResourceType = typeof(Resources))]
      //  [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_RegionIDRequired")]
        public int RegionID
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.RegionID > 0) ? EmployeeDependentsDTO.RegionID : new int();
            }
            set
            {
                EmployeeDependentsDTO.RegionID = value;
            }
        }


        [Display(Name = "DisplayName_CityID", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CityIDRequired")]
        public int CityID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.CityID : new int();
            }
            set
            {
                EmployeeDependentsDTO.CityID = value;
            }
        }


        [Display(Name = "DisplayName_PhoneNumber", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PhoneNumberRequired")]
        public string PhoneNumber
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.PhoneNumber : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.PhoneNumber = value;
            }
        }

        [Display(Name = "DisplayName_MobileNumber", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        public string MobileNumber
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.MobileNumber : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.MobileNumber = value;
            }
        }


        [Display(Name = "DisplayName_EmployeeDependentQualification", ResourceType = typeof(Resources))]
    //    [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeDependentQualificationRequired")]
        public string EmployeeDependentQualification
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.EmployeeDependentQualification : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.EmployeeDependentQualification = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeDependentDesignation", ResourceType = typeof(Resources))]
   //     [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeDependentDesignationRequired")]
        public string EmployeeDependentDesignation
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.EmployeeDependentDesignation : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.EmployeeDependentDesignation = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeDependentDesignation", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeDependentDesignationRequired")]
        public string RelationshipType
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.RelationshipType : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.RelationshipType = value;
            }
        }



        [Display(Name = "DisplayName_GotAnyMedal", ResourceType = typeof(Resources))]
        public bool GotAnyMedal
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.GotAnyMedal : false;
            }
            set
            {
                EmployeeDependentsDTO.GotAnyMedal = value;
            }
        }

        [Display(Name = "DisplayName_MedalReceivedDate", ResourceType = typeof(Resources))]
       // //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MedalReceivedDateRequired")]
        public string MedalReceivedDate
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.MedalReceivedDate : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.MedalReceivedDate = value;
            }
        }

        [Display(Name = "DisplayName_MedalDescription", ResourceType = typeof(Resources))]
        ////[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MedalDescriptionRequired")]
        public string MedalDescription
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.MedalDescription : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.MedalDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsScholarshipReceived", ResourceType = typeof(Resources))]
        public bool IsScholarshipReceived
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.IsScholarshipReceived : false;
            }
            set
            {
                EmployeeDependentsDTO.IsScholarshipReceived = value;
            }
        }

         [Display(Name = "DisplayName_ScholarshipAmount", ResourceType = typeof(Resources))]
        public decimal  ScholarshipAmount
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.ScholarshipAmount : new decimal();
            }
            set
            {
                EmployeeDependentsDTO.ScholarshipAmount = value;
            }
        }


        [Display(Name = "DisplayName_ScholarshipStartDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipStartDateRequired")]
        public string ScholarshipStartDate
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.ScholarshipStartDate : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.ScholarshipStartDate = value;
            }
        }

        [Display(Name = "DisplayName_ScholarshipUptoDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipUptoDateRequired")]
        public string ScholarshipUptoDate
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.ScholarshipUptoDate : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.ScholarshipUptoDate = value;
            }
        }



        [Display(Name = "DisplayName_ScholarshipDescription", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipDescriptionRequired")]
        public string ScholarshipDescription
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.ScholarshipDescription : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.ScholarshipDescription = value;
            }
        }


        [Display(Name = "DisplayName_Hobbies", ResourceType = typeof(Resources))]
        ////[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_HobbiesRequired")]
        public string Hobbies
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.Hobbies : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.Hobbies = value;
            }
        }


        [Display(Name = "DisplayName_CurriculumActivity", ResourceType = typeof(Resources))]
        ////[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CurriculumActivityRequired")]
        public string CurriculumActivity
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.CurriculumActivity : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.CurriculumActivity = value;
            }
        }

        [Display(Name = "DisplayName_DateofBirth", ResourceType = typeof(Resources))]
      //  [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateofBirthRequired")]
        public string DateOfBirth
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.DateOfBirth : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.DateOfBirth = value;
            }
        }

        [Display(Name = "DisplayName_PlaceOfBirth", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PlaceOfBirthRequired")]
        public string PlaceOfBirth
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.PlaceOfBirth : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.PlaceOfBirth = value;
            }
        }



        [Display(Name = "DisplayName_GeneralRelationshipTypeMasterID", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_GeneralRelationshipTypeMasterIDRequired")]
        public int GeneralRelationshipTypeMasterID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.GeneralRelationshipTypeMasterID : new int();
            }
            set
            {
                EmployeeDependentsDTO.GeneralRelationshipTypeMasterID = value;
            }
        }

        [Display(Name = "DisplayName_MotherTongueID", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MotherTongueIDRequired")]
        public int MotherTongueID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.MotherTongueID : new int();
            }
            set
            {
                EmployeeDependentsDTO.MotherTongueID = value;
            }
        }

        [Display(Name = "DisplayName_LanguageKnown", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_LanguageKnownRequired")]
        public string LanguageKnown
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.LanguageKnown : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.LanguageKnown = value;
            }
        }

        [Display(Name = "DisplayName_NationalityID", ResourceType = typeof(Resources))]
      //  [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_NationalityIDRequired")]
        public int NationalityID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.NationalityID : new int();
            }
            set
            {
                EmployeeDependentsDTO.NationalityID = value;
            }
        }

        [Display(Name = "DisplayName_ReligionID", ResourceType = typeof(Resources))]
      //  [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ReligionIDRequired")]
        public int ReligionID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.ReligionID : new int();
            }
            set
            {
                EmployeeDependentsDTO.ReligionID = value;
            }
        }

        [Display(Name = "DisplayName_CasteID", ResourceType = typeof(Resources))]
       // [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CasteIDRequired")]
        public int CasteID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.CasteID : new int();
            }
            set
            {
                EmployeeDependentsDTO.CasteID = value;
            }
        }

        public int SubCasteID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.SubCasteID : new int();
            }
            set
            {
                EmployeeDependentsDTO.SubCasteID = value;
            }
        }

        [Display(Name = "DisplayName_CategoryID", ResourceType = typeof(Resources))]
     //   [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_CategoryIDRequired")]
        public int CategoryID
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.CategoryID : new int();
            }
            set
            {
                EmployeeDependentsDTO.CategoryID = value;
            }
        }

        [Display(Name = "DisplayName_WeddingAnniversaryDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_WeddingAnniversaryDateRequired")]
        public string WeddingAnniversaryDate
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.WeddingAnniversaryDate : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.WeddingAnniversaryDate = value;
            }
        }

        [Display(Name = "Adhar Card Number")]
        public string AdharCardNumber
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.AdharCardNumber : string.Empty;
            }
            set
            {
                EmployeeDependentsDTO.AdharCardNumber = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.IsActive : false;
            }
            set
            {
                EmployeeDependentsDTO.IsActive = value;
            }
        }
        [Display(Name = "Is Nominee")]
        public bool IsNominee
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.IsNominee : false;
            }
            set
            {
                EmployeeDependentsDTO.IsNominee = value;
            }
        }




        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeDependentsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.CreatedBy > 0) ? EmployeeDependentsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeDependentsDTO.CreatedBy = value;
            }
        }



        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeDependentsDTO != null) ? EmployeeDependentsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeDependentsDTO.CreatedDate = value;
            }
        }
       

       

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.ModifiedBy.HasValue) ? EmployeeDependentsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeDependentsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.ModifiedDate.HasValue) ? EmployeeDependentsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeDependentsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.DeletedBy.HasValue) ? EmployeeDependentsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeDependentsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeDependentsDTO != null && EmployeeDependentsDTO.DeletedDate.HasValue) ? EmployeeDependentsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeDependentsDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

