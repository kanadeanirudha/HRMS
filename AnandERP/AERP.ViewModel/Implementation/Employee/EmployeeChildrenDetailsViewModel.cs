using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeChildrenDetailsViewModel : IEmployeeChildrenDetailsViewModel
    {

        public EmployeeChildrenDetailsViewModel()
        {
            EmployeeChildrenDetailsDTO = new EmployeeChildrenDetails();
        }

        public EmployeeChildrenDetails EmployeeChildrenDetailsDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.ID > 0) ? EmployeeChildrenDetailsDTO.ID : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.EmployeeID = value;
            }
        }

        public int TitleMasterID
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.TitleMasterID : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.TitleMasterID = value;
            }
        }


        [Display(Name = "DisplayName_Title", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TitleRequired")]
        public string NameTitle
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.NameTitle : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.NameTitle = value;
            }
        }

        [Display(Name = "DisplayName_ChildName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ChildNameRequired")]
        public string ChildName
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ChildName : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ChildName = value;
            }
        }

        [Display(Name = "DisplayName_GenderCode", ResourceType = typeof(Resources))]
        public string GenderCode
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.GenderCode : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.GenderCode = value;
            }
        }



        [Display(Name = "DisplayName_ChildQualification", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ChildQualificationRequired")]
        public string ChildQualification
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ChildQualification : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ChildQualification = value;
            }
        }

        [Display(Name = "DisplayName_ChildDateOfBirth", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ChildDateOfBirthRequired")]
        public string ChildDateOfBirth
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ChildDateOfBirth : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ChildDateOfBirth = value;
            }
        }



        [Display(Name = "DisplayName_Hobby", ResourceType = typeof(Resources))]
        ////[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_Address2Required")]
        public string Hobby
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.Hobby : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.Hobby = value;
            }
        }




        [Display(Name = "DisplayName_Sports", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PhoneNumberRequired")]
        public string Sports
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.Sports : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.Sports = value;
            }
        }

        [Display(Name = "DisplayName_CurriculumActivity", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MobileNumberRequired")]
        public string CurriculamActivity
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.CurriculamActivity : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.CurriculamActivity = value;
            }
        }




        [Display(Name = "DisplayName_GotAnyMedal", ResourceType = typeof(Resources))]
        public bool GotAnyMedal
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.GotAnyMedal : false;
            }
            set
            {
                EmployeeChildrenDetailsDTO.GotAnyMedal = value;
            }
        }

        [Display(Name = "DisplayName_MedalReceivedDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MedalReceivedDateRequired")]
        public string MedalReceivedDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.MedalReceivedDate : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.MedalReceivedDate = value;
            }
        }

        [Display(Name = "DisplayName_MedalDescription", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MedalDescriptionRequired")]
        public string MedalDescription
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.MedalDescription : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.MedalDescription = value;
            }
        }

        [Display(Name = "DisplayName_IsScholarshipReceived", ResourceType = typeof(Resources))]
        public bool IsScholarshipReceived
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.IsScholarshipReceived : false;
            }
            set
            {
                EmployeeChildrenDetailsDTO.IsScholarshipReceived = value;
            }
        }

        [Display(Name = "DisplayName_ScholarshipAmount", ResourceType = typeof(Resources))]
        public decimal ScholarshipAmount
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ScholarshipAmount : new decimal();
            }
            set
            {
                EmployeeChildrenDetailsDTO.ScholarshipAmount = value;
            }
        }


        [Display(Name = "DisplayName_ScholarshipStartDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipStartDateRequired")]
        public string ScholarshipStartDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ScholarshipStartDate : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ScholarshipStartDate = value;
            }
        }

        [Display(Name = "DisplayName_ScholarshipUptoDate", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipUptoDateRequired")]
        public string ScholarshipUptoDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ScholarshipUptoDate : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ScholarshipUptoDate = value;
            }
        }



        [Display(Name = "DisplayName_ScholarshipDescription", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ScholarshipDescriptionRequired")]
        public string ScholarshipDescription
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ScholarshipDescription : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ScholarshipDescription = value;
            }
        }


        [Display(Name = "DisplayName_IdentityMarks", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_IdentityMarksRequired")]
        public string IdentityMarks
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.IdentityMarks : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.IdentityMarks = value;
            }
        }


        [Display(Name = "DisplayName_Profession", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ProfessionRequired")]
        public string Profession
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.Profession : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.Profession = value;
            }
        }

        [Display(Name = "DisplayName_Height", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_DateofBirthRequired")]
        public string Height
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.Height : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.Height = value;
            }
        }

        [Display(Name = "DisplayName_Weight", ResourceType = typeof(Resources))]
        //[Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_PlaceOfBirthRequired")]
        public string Weight
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.Weight : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.Weight = value;
            }
        }


        [Display(Name = "DisplayName_ChildrenRelation", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_ChildrenRelationRequired")]
        public string ChildrenRelation
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.ChildrenRelation : string.Empty;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ChildrenRelation = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.IsActive : false;
            }
            set
            {
                EmployeeChildrenDetailsDTO.IsActive = value;
            }
        }






        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.IsDeleted : false;
            }
            set
            {
                EmployeeChildrenDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.CreatedBy > 0) ? EmployeeChildrenDetailsDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.CreatedBy = value;
            }
        }



        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null) ? EmployeeChildrenDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeChildrenDetailsDTO.CreatedDate = value;
            }
        }




        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.ModifiedBy.HasValue) ? EmployeeChildrenDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.ModifiedDate.HasValue) ? EmployeeChildrenDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeChildrenDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.DeletedBy.HasValue) ? EmployeeChildrenDetailsDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeChildrenDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeChildrenDetailsDTO != null && EmployeeChildrenDetailsDTO.DeletedDate.HasValue) ? EmployeeChildrenDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeChildrenDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

