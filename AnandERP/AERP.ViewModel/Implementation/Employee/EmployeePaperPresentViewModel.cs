using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeePaperPresentViewModel
    {

        public EmployeePaperPresentViewModel()
        {
            EmployeePaperPresentDTO = new EmployeePaperPresent();
        }

        public EmployeePaperPresent EmployeePaperPresentDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.ID > 0) ? EmployeePaperPresentDTO.ID : new int();
            }
            set
            {
                EmployeePaperPresentDTO.ID = value;
            }
        }


        [Display(Name = "DisplayName_PaperTopic", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PaperTopicRequired")]
        public string PaperTopic
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.PaperTopic : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.PaperTopic = value;
            }
        }

        [Display(Name = "DisplayName_JournalName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JournalNameRequired")]
        public string JournalName
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.JournalName : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.JournalName = value;
            }
        }

        [Display(Name = "DisplayName_JournalVolumeNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JournalVolumeNumberRequired")]
        public string JournalVolumeNumber
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.JournalVolumeNumber : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.JournalVolumeNumber = value;
            }
        }

        [Display(Name = "DisplayName_JournalPageNumber", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_JournalPageNumberRequired")]
        public string JournalPageNumber
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.JournalPageNumber : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.JournalPageNumber = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeYear", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeYearRequired")]
        public string EmployeeYear
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeYear : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeYear = value;
            }
        }


        [Display(Name = "DisplayName_PaperType", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PaperTypeRequired")]
        public string PaperType
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.PaperType : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.PaperType = value;
            }
        }

        [Display(Name = "DisplayName_GeneralLevelMasterIDForPprPresent", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralLevelMasterIDForPprPresentRequired")]
        public int GeneralLevelMasterIDForPprPresent
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.GeneralLevelMasterID > 0) ? EmployeePaperPresentDTO.GeneralLevelMasterID : new int();
            }
            set
            {
                EmployeePaperPresentDTO.GeneralLevelMasterID = value;
            }
        }

        [Display(Name = "DisplayName_GeneralLevel", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_GeneralLevelRequired")]
        public string GeneralLevel
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.GeneralLevel : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.GeneralLevel = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeBookReview", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeBookReviewRequired")]
        public string EmployeeBookReview
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeBookReview : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeBookReview = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeArticleReview", ResourceType = typeof(AMS.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeArticleReviewRequired")]
        public string EmployeeArticleReview
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeArticleReview : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeArticleReview = value;
            }
        }

        [Display(Name = "DisplayName_PublishMedium", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PublishMediumRequired")]
        public string PublishMedium
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.PublishMedium : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.PublishMedium = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeConferenceDateFrom", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeConferenceDateFromRequired")]
        public string EmployeeConferenceDateFrom
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeConferenceDateFrom : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeConferenceDateFrom = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeConferenceDateTo", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeConferenceDateToRequired")]
        public string EmployeeConferenceDateTo
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeConferenceDateTo : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeConferenceDateTo = value;
            }
        }

        [Display(Name = "DisplayName_ConferenceName", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ConferenceNameRequired")]
        public string ConferenceName
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.ConferenceName : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.ConferenceName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeConferenceVenue", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeConferenceVenueRequired")]
        public string EmployeeConferenceVenue
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeConferenceVenue : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeConferenceVenue = value;
            }
        }

        [Display(Name = "DisplayName_PublishDate", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PublishDateRequired")]
        public string PublishDate
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.PublishDate : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.PublishDate = value;
            }
        }
        [Display(Name = "DisplayName_SelfGroupPresenter", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelfGroupPresenter")]
        public string SelfGroupPresenter
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.SelfGroupPresenter : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.SelfGroupPresenter = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeProceedingPageNumber", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeProceedingPageNumberRequired")]
        public string EmployeeProceedingPageNumber
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeProceedingPageNumber : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeProceedingPageNumber = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeConferenceProceeding", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeConferenceProceedingRequired")]
        public string EmployeeConferenceProceeding
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeConferenceProceeding : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeConferenceProceeding = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.IsActive : false;
            }
            set
            {
                EmployeePaperPresentDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.IsDeleted : false;
            }
            set
            {
                EmployeePaperPresentDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.CreatedBy > 0) ? EmployeePaperPresentDTO.CreatedBy : new int();
            }
            set
            {
                EmployeePaperPresentDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeePaperPresentDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.ModifiedBy.HasValue) ? EmployeePaperPresentDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeePaperPresentDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.ModifiedDate.HasValue) ? EmployeePaperPresentDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeePaperPresentDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.DeletedBy.HasValue) ? EmployeePaperPresentDTO.DeletedBy : new int();
            }
            set
            {
                EmployeePaperPresentDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.DeletedDate.HasValue) ? EmployeePaperPresentDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeePaperPresentDTO.DeletedDate = value;
            }
        }

        public string SelectedCountryID
        {
            get;
            set;
        }
        public string errorMessage { get; set; }



        [Display(Name = "EmployeePaperPresenterID")]
        public int EmployeePaperPresenterID
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.EmployeePaperPresenterID > 0) ? EmployeePaperPresentDTO.EmployeePaperPresenterID : new int();
            }
            set
            {
                EmployeePaperPresentDTO.EmployeePaperPresenterID = value;
            }
        }

        [Display(Name = "EmployeePaperPresentID")]
        public int EmployeePaperPresentID
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.EmployeePaperPresentID > 0) ? EmployeePaperPresentDTO.EmployeePaperPresentID : new int();
            }
            set
            {
                EmployeePaperPresentDTO.EmployeePaperPresentID = value;
            }
        }

        [Display(Name = "EmployeeID")]
        public int EmployeeID
        {
            get
            {
                return (EmployeePaperPresentDTO != null && EmployeePaperPresentDTO.EmployeeID > 0) ? EmployeePaperPresentDTO.EmployeeID : new int();
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeParticipationRole", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeParticipationRoleRequired")]
        public string EmployeeParticipationRole
        {
            get
            {
                return (EmployeePaperPresentDTO != null) ? EmployeePaperPresentDTO.EmployeeParticipationRole : string.Empty;
            }
            set
            {
                EmployeePaperPresentDTO.EmployeeParticipationRole = value;
            }
        }


    }
}
