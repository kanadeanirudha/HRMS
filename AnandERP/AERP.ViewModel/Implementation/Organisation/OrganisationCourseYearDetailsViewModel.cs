using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
  public  class OrganisationCourseYearDetailsBaseViewModel : IOrganisationCourseYearDetailsBaseViewModel
    {
  
       public OrganisationCourseYearDetailsBaseViewModel()
        {
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();       
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
          
        }

        public OrganisationCourseYearDetails OrganisationCourseYearDetailsDTO
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

        public List<OrganisationCourseYearDetails> ListApplicableSemester
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
  public class OrganisationCourseYearDetailsViewModel : IOrganisationCourseYearDetailsViewModel
    {

     public OrganisationCourseYearDetailsViewModel()
        {
           OrganisationCourseYearDetailsDTO = new OrganisationCourseYearDetails();
           if (OrganisationSemesterMasterList == null)
           {
               OrganisationSemesterMasterList = new List<OrganisationCourseYearDetails>();
           }
          // OrganisationSemesterMasterList = new List<OrganisationSemesterMaster>();
        }

        public OrganisationCourseYearDetails OrganisationCourseYearDetailsDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.ID > 0) ? OrganisationCourseYearDetailsDTO.ID : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_StreamID", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StreamIDRequired")]
        public int StreamID
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.StreamID > 0) ? OrganisationCourseYearDetailsDTO.StreamID : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.StreamID = value;
            }
        }

      [Display(Name = "Branch Description")]
        public int BranchID
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.BranchID : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.BranchID = value;
            }
        }
      [Display(Name = "DisplayName_BranchDescription")]
      public string BranchDescription
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.BranchDescription : string.Empty;
          }
          set
          {
              OrganisationCourseYearDetailsDTO.BranchDescription = value;
          }
      }

      public string CourseDescription
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CourseDescription : string.Empty;
          }
          set
          {
              OrganisationCourseYearDetailsDTO.CourseDescription = value;
          }
      }

      [Display(Name = "DisplayName_StandardID", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_StandardIDRequired")]
      public int StandardID
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.StandardID : new int();
          }
          set
          {
              OrganisationCourseYearDetailsDTO.StandardID = value;
          }
      }
      [Display(Name = "Standard")]
      public int StandardNumber
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.StandardNumber : new int();
          }
          set
          {
              OrganisationCourseYearDetailsDTO.StandardNumber = value;
          }
      }

      [Display(Name = "Branch Description")]
      public int BranchDetailID
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.BranchDetailID : new int();
          }
          set
          {
              OrganisationCourseYearDetailsDTO.BranchDetailID = value;
          }
      }
      public int CourseYearID
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CourseYearID : new int();
          }
          set
          {
              OrganisationCourseYearDetailsDTO.CourseYearID = value;
          }
      }


      [Display(Name = "DisplayName_MediumID", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MediumIDRequired")]
      public int MediumID
      {
          get
          {
              return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.MediumID : new int();
          }
          set
          {
              OrganisationCourseYearDetailsDTO.MediumID = value;
          }
      }

      [Display(Name = "DisplayName_Duration", ResourceType = typeof(AMS.Common.Resources))]
      [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DurationRequired")]
       public int Duration
       {
           get
           {
               return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.Duration : new int();
           }
           set
           {
               OrganisationCourseYearDetailsDTO.Duration = value;
           }
       }

        [Display(Name = "Semester")]
       public string selectItemSemesterIDs
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.selectItemSemesterIDs : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.selectItemSemesterIDs = value;
            }
        }

        [Display(Name = "DisplayName_CourseYearStdDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CourseYearStdDescriptionRequired")]
        public string Description
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.Description : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.Description = value;
            }
        }


        [Display(Name = "Semester")]
        public string SemesterIDs
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.SemesterIDs : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.SemesterIDs = value;
            }
        }
        public bool BranchActive
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.BranchActive : false;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.BranchActive = value;
            }
        }

          [Display(Name = "DisplayName_SectionCapacity", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionCapacityRequired")]
        public int SectionCapacity
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.SectionCapacity : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.SectionCapacity = value;
            }
        }

              [Display(Name = "DisplayName_ExamApplicable", ResourceType = typeof(AMS.Common.Resources))]
        public string ExamApplicable
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.ExamApplicable : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.ExamApplicable = value;
            }
        }
     
          [Display(Name = "Next Course Year Detail")]
        public string NextCourseYearDetailID
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.NextCourseYearDetailID : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.NextCourseYearDetailID = value;
            }
        }

          [Display(Name = "DisplayName_ExamPattern", ResourceType = typeof(AMS.Common.Resources))]
          //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExamPatternRequired")]
          public string ExamPattern
          {
              get
              {
                  return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.ExamPattern : string.Empty;
              }
              set
              {
                  OrganisationCourseYearDetailsDTO.ExamPattern = value;
              }
          }

          [Display(Name = "Number Of Semester")]
          public int NumberOfSemester
          {
              get
              {
                  return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.NumberOfSemester : new int();
              }
              set
              {
                  OrganisationCourseYearDetailsDTO.NumberOfSemester = value;
              }
          }

          [Display(Name = "DisplayName_CourseYearCode", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CourseYearCodeRequired")]
          public string CourseYearCode
          {
              get
              {
                  return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CourseYearCode : string.Empty;
              }
              set
              {
                  OrganisationCourseYearDetailsDTO.CourseYearCode = value;
              }
          }

          [Display(Name = "DisplayName_DegreeName", ResourceType = typeof(AMS.Common.Resources))]
          [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DegreeNameRequired")]
          public string DegreeName
          {
              get
              {
                  return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.DegreeName : string.Empty;
              }
              set
              {
                  OrganisationCourseYearDetailsDTO.DegreeName = value;
              }
          }

                [Display(Name = "DisplayName_SemesterApplicable", ResourceType = typeof(AMS.Common.Resources))]
          public string SemesterApplicable { get; set; }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.IsDeleted: false;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.CreatedBy > 0) ? OrganisationCourseYearDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.ModifiedBy.HasValue) ? OrganisationCourseYearDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.ModifiedDate.HasValue) ? OrganisationCourseYearDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.DeletedBy.HasValue) ? OrganisationCourseYearDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationCourseYearDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null && OrganisationCourseYearDetailsDTO.DeletedDate.HasValue) ? OrganisationCourseYearDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.DeletedDate = value;
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
        public bool StatusFlag
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.StatusFlag : false;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(Resources))]
        public string CentreName
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.CentreName : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.CentreName = value;
            }
        }
        //public int SelectedStreamID
        //{
        //    get
        //    {
        //        return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.SelectedStreamID : new int();
        //    }
        //    set
        //    {
        //        OrganisationCourseYearDetailsDTO.SelectedStreamID = value;
        //    }
        //}
        public IEnumerable<SelectListItem> OrganisationSemesterMasterListItems
        {
            get
            {
                return new SelectList(OrganisationSemesterMasterList, "ID", "OrgSemesterName","selected");
            }
        }

        public List<OrganisationCourseYearDetails> OrganisationSemesterMasterList
        {
            get;
            set;
        }

       
        public string semesterSelected
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.semesterSelected : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.semesterSelected = value;
            }
        }
        public string StreamDescription
        {
            get
            {
                return (OrganisationCourseYearDetailsDTO != null) ? OrganisationCourseYearDetailsDTO.StreamDescription : string.Empty;
            }
            set
            {
                OrganisationCourseYearDetailsDTO.StreamDescription = value;
            }
        }
        public string errorMessage { get; set; }


    }
}
