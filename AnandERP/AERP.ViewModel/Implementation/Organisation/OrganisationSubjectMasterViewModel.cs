using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class OrganisationSubjectMasterBaseViewModel : IOrganisationSubjectMasterBaseViewModel
    {
        public OrganisationSubjectMasterBaseViewModel()
        {
            ListOrganisationSubjectMaster = new List<OrganisationSubjectMaster>();

            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();

            ListGeneralLanguageMaster = new List<GeneralLanguageMaster>();

        }

        public List<OrganisationSubjectMaster> ListOrganisationSubjectMaster
        {
            get;
            set;
        }

        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public List<GeneralLanguageMaster> ListGeneralLanguageMaster
        {
            get;
            set;
        }

        //public string SelectedUniversityID
        //{
        //    get;
        //    set;
        //}

        public string SelectedLanguageID
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGeneralRegionMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationUniversityMaster, "UniversityID", "UniversityName");
            }
        }

        public IEnumerable<SelectListItem> ListGeneralCityMasterItems
        {
            get
            {
                return new SelectList(ListGeneralLanguageMaster, "LanguageID", "LanguageName");
            }
        }

    }


    public class OrganisationSubjectMasterViewModel : IOrganisationSubjectMasterViewModel
    {

        public OrganisationSubjectMasterViewModel()
        {
            OrganisationSubjectMasterDTO = new OrganisationSubjectMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public OrganisationSubjectMaster OrganisationSubjectMasterDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<OrganisationUniversityMaster> ListOrganisationUniversityMaster
        {
            get;
            set;
        }

        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string SelectedUniversityID
        {
            get;
            set;
        }
      
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationUnivesitytMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationUniversityMaster, "ID", "UniversityName");
            }

        }
        public int ID
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.ID > 0) ? OrganisationSubjectMasterDTO.ID : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_UniversityID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UniversityIDRequired")]
        public int UniversityID
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.UniversityID > 0) ? OrganisationSubjectMasterDTO.UniversityID : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.UniversityID = value;
            }
        }
        [Display(Name = "DisplayName_LanguageID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_LanguageIDRequired")]
        public int LanguageID
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.LanguageID > 0) ? OrganisationSubjectMasterDTO.LanguageID : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.LanguageID = value;
            }
        }
        [Display(Name = "DisplayName_SubjectDescriptions", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectDescriptionsRequired")]
        public string Descriptions
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.Descriptions : string.Empty;
            }
            set
            {
                OrganisationSubjectMasterDTO.Descriptions = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationSubjectMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_SubjectCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectCodeRequired")]
        public string SubjectCode
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.SubjectCode  : string.Empty;
            }
            set
            {
                OrganisationSubjectMasterDTO.SubjectCode = value;
            }
        }

        [Display(Name = "DisplayName_SubjectIntroYear", ResourceType = typeof(AMS.Common.Resources))]
       //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SubjectIntroYearRequired")]
        public string SubjectIntroYear
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.SubjectIntroYear : string.Empty;
            }
            set
            {
                OrganisationSubjectMasterDTO.SubjectIntroYear = value;
            }
        }


        [Display(Name = "DisplayName_PaperCode", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PaperCodeRequired")]
        public string PaperCode
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.PaperCode : string.Empty;
            }
            set
            {
                OrganisationSubjectMasterDTO.PaperCode = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSubjectMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.CreatedBy > 0) ? OrganisationSubjectMasterDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null) ? OrganisationSubjectMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.ModifiedBy.HasValue) ? OrganisationSubjectMasterDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.ModifiedDate.HasValue) ? OrganisationSubjectMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.DeletedBy.HasValue) ? OrganisationSubjectMasterDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSubjectMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSubjectMasterDTO != null && OrganisationSubjectMasterDTO.DeletedDate.HasValue) ? OrganisationSubjectMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSubjectMasterDTO.DeletedDate = value;
            }
        }

        public string CentreCodeWithName
        {
            get;
            set;
        }

        public string UniversityIDWithName
        {
            get;
            set;
        }

        public string SelectedLanguageID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
