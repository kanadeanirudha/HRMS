using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
  public  class OrganisationBranchDetailsBaseViewModel : IOrganisationBranchDetailsBaseViewModel
    {
        public OrganisationBranchDetailsBaseViewModel()
        {
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();       
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        }

        public OrganisationBranchDetails OrganisationBranchDetailsDTO
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
        public string BranchDescription
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


  }
  public class OrganisationBranchDetailsViewModel : IOrganisationBranchDetailsViewModel
    {

     public OrganisationBranchDetailsViewModel()
        {
           OrganisationBranchDetailsDTO = new OrganisationBranchDetails();
        }

        public OrganisationBranchDetails OrganisationBranchDetailsDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.ID > 0) ? OrganisationBranchDetailsDTO.ID : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.ID = value;
            }
        }
        public int BranchDetailID
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.BranchDetailID > 0) ? OrganisationBranchDetailsDTO.BranchDetailID : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.BranchDetailID = value;
            }
        }

      [Display(Name = "Branch Description")]
        public int BranchID
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.BranchID : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.BranchID = value;
            }
        }
      public int SelectedStreamID
      {
          get
          {
              return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.SelectedStreamID : new int();
          }
          set
          {
              OrganisationBranchDetailsDTO.SelectedStreamID = value;
          }
      }

        [Display(Name = "DisplayName_BranchDescription")]
        public string BranchDescription
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.BranchDescription : string.Empty;
            }
            set
            {
                OrganisationBranchDetailsDTO.BranchDescription = value;
            }
        }

          [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationBranchDetailsDTO.CentreCode = value;
            }
        }

           [Display(Name = "DisplayName_CentreName", ResourceType = typeof(Resources))]
          public string CentreName
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.CentreName : string.Empty;
              }
              set
              {
                  OrganisationBranchDetailsDTO.CentreName = value;
              }
          }

          [Display(Name = "DisplayName_PresentIntake", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PresentIntakeRequired")]
          public int PresentIntake
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.PresentIntake : new int();
              }
              set
              {
                  OrganisationBranchDetailsDTO.PresentIntake = value;
              }
          }

         [Display(Name = "DisplayName_IntroductionYear", ResourceType = typeof(AMS.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_IntroductionYearRequired")]
          public int IntroductionYear
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.IntroductionYear : new int();
              }
              set
              {
                  OrganisationBranchDetailsDTO.IntroductionYear = value;
              }
          }

          public bool StatusFlag
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.StatusFlag : false;
              }
              set
              {
                  OrganisationBranchDetailsDTO.StatusFlag = value;
              }
          }

          [Display(Name = "DisplayName_StreamID", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreamIDRequired")]
          public int StreamID
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.StreamID : new int();
              }
              set
              {
                  OrganisationBranchDetailsDTO.StreamID = value;
              }
          }

          [Display(Name = "DisplayName_DteCode", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DteCodeRequired")]
          public string DteCode
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.DteCode : string.Empty;
              }
              set
              {
                  OrganisationBranchDetailsDTO.DteCode = value;
              }
          }

          [Display(Name = "DisplayName_BranchPrintingSequence", ResourceType = typeof(AMS.Common.Resources))]
          public int BranchPrintingSequence
          {
              get
              {
                  return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.BranchPrintingSequence : new int();
              }
              set
              {
                  OrganisationBranchDetailsDTO.BranchPrintingSequence = value;
              }
          }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.IsDeleted: false;
            }
            set
            {
                OrganisationBranchDetailsDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.CreatedBy > 0) ? OrganisationBranchDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null) ? OrganisationBranchDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.ModifiedBy.HasValue) ? OrganisationBranchDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.ModifiedDate.HasValue) ? OrganisationBranchDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.DeletedBy.HasValue) ? OrganisationBranchDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationBranchDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationBranchDetailsDTO != null && OrganisationBranchDetailsDTO.DeletedDate.HasValue) ? OrganisationBranchDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationBranchDetailsDTO.DeletedDate = value;
            }
        }
        public string SelectedCategoryID
        {
            get;
            set;
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

        public string errorMessage { get; set; }
    }
}
