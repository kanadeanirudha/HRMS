using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class OrganisationSectionDetailsBaseViewModel : IOrganisationSectionDetailsBaseViewModel
    {

        public OrganisationSectionDetailsBaseViewModel()
        {
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrgSectionDetails = new List<OrganisationSectionDetails>();
            ListOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();

        }

        public OrganisationSectionDetails OrganisationSectionDetailsDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<OrganisationSectionDetails> ListOrgSectionDetails
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

        public IEnumerable<SelectListItem> ListOrgSectionDetailsItems
        {
            get
            {
                return new SelectList(ListOrgSectionDetails, "ID", "CourseYearDescriptions");
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
    public class OrganisationSectionDetailsViewModel : IOrganisationSectionDetailsViewModel
    {

        public OrganisationSectionDetailsViewModel()
        {
            OrganisationSectionDetailsDTO = new OrganisationSectionDetails();
            //OrganisationSemesterMasterList = new List<OrganisationSemesterMaster>();
            ListOrgSectionDetails = new List<OrganisationSectionDetails>();
        }

        public OrganisationSectionDetails OrganisationSectionDetailsDTO { get; set; }

        public int ID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.ID > 0) ? OrganisationSectionDetailsDTO.ID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.ID = value;
            }
        }
        public int StreamID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.StreamID > 0) ? OrganisationSectionDetailsDTO.StreamID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.StreamID = value;
            }
        }

        [Display(Name = "DisplayName_StreamDescriptions", ResourceType = typeof(AMS.Common.Resources))]
        public string StreamDescriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.StreamDescriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.StreamDescriptions = value;
            }
        }

        [Display(Name = "Branch Description")]
        public int BranchID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.BranchID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.BranchID = value;
            }
        }

        [Display(Name = "DisplayName_BranchDescriptions", ResourceType = typeof(AMS.Common.Resources))]
        public string BranchDescriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.BranchDescriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.BranchDescriptions = value;
            }
        }

        public string CourseYearDescriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CourseYearDescriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.CourseYearDescriptions = value;
            }
        }

        [Display(Name = "Standard")]
        public int StandardID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.StandardID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.StandardID = value;
            }
        }

        [Display(Name = "DisplayName_StandardDescriptions", ResourceType = typeof(AMS.Common.Resources))]
        public string StandardDescriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.StandardDescriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.StandardDescriptions = value;
            }
        }
        public int StandardNumber
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.StandardNumber : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.StandardNumber = value;
            }
        }
        //public int CourseYearID
        //{
        //    get
        //    {
        //        return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CourseYearID : new int();
        //    }
        //    set
        //    {
        //        OrganisationSectionDetailsDTO.CourseYearID = value;
        //    }
        //}


        [Display(Name = "Medium")]
        public int MediumID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.MediumID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.MediumID = value;
            }
        }

        [Display(Name = "DisplayName_MediumDescription", ResourceType = typeof(AMS.Common.Resources))]
        public string MediumDescription
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.MediumDescription : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.MediumDescription = value;
            }
        }
        [Display(Name = "Duration")]
        public int Duration
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.Duration : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.Duration = value;
            }
        }

        [Display(Name = "selectItemSemesterIDs")]
        //public string selectItemSemesterIDs
        // {
        //     get
        //     {
        //         return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.selectItemSemesterIDs : string.Empty;
        //     }
        //     set
        //     {
        //         OrganisationSectionDetailsDTO.selectItemSemesterIDs = value;
        //     }
        // }

        public string Descriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.Descriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.Descriptions = value;
            }
        }

        [Display(Name = "DisplayName_SelectedDescriptions", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SelectedDescriptionsRequired")]
        public string SelectedDescriptions
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SelectedDescriptions : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.SelectedDescriptions = value;
            }
        }

        public int SectionID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SectionID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.SectionID = value;
            }
        }
        //[Display(Name = "SemesterIDs")]
        //public string SemesterIDs
        //{
        //    get
        //    {
        //        return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SemesterIDs : string.Empty;
        //    }
        //    set
        //    {
        //        OrganisationSectionDetailsDTO.SemesterIDs = value;
        //    }
        //}

        [Display(Name = "DisplayName_SectionActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool SectionActive
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SectionActive : false;
            }
            set
            {
                OrganisationSectionDetailsDTO.SectionActive = value;
            }
        }

        public bool StatusFlag
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.StatusFlag : false;
            }
            set
            {
                OrganisationSectionDetailsDTO.StatusFlag = value;
            }
        }

        [Display(Name = "DisplayName_SectionCapacity", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionCapacityRequired")]
        public int SectionCapacity
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SectionCapacity : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.SectionCapacity = value;
            }
        }

        [Display(Name = "DisplayName_ExamApplicable", ResourceType = typeof(AMS.Common.Resources))]
        public string ExamApplicable
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.ExamApplicable : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.ExamApplicable = value;
            }
        }

        [Display(Name = "DisplayName_NextSectionDetailID", ResourceType = typeof(AMS.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_NextSectionDetailID")]
        public string NextSectionDetailID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.NextSectionDetailID : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.NextSectionDetailID = value;
            }
        }

        [Display(Name = "DisplayName_ExamPattern", ResourceType = typeof(AMS.Common.Resources))]
        public string ExamPattern
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.ExamPattern : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.ExamPattern = value;
            }
        }
        [Display(Name = "Number Of Semester")]
        public int NumberOfSemester
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.NumberOfSemester : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.NumberOfSemester = value;
            }
        }

        [Display(Name = "DisplayName_SectionDetailCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SectionDetailCodeRequired")]
        public string SectionDetailCode
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.SectionDetailCode : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.SectionDetailCode = value;
            }
        }

        [Display(Name = "DisplayName_DegreeName", ResourceType = typeof(AMS.Common.Resources))]
        public string DegreeName
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.DegreeName : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.DegreeName = value;
            }
        }

        public int BranchDetID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.BranchDetID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.BranchDetID = value;
            }
        }
        public int CourseStartDetID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CourseStartDetID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.CourseStartDetID = value;
            }
        }


        public int CourseYearDetailID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CourseYearDetailID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.CourseYearDetailID = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CentreCode : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.CentreCode = value;
            }
        }
        public int UniversityID
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.UniversityID > 0) ? OrganisationSectionDetailsDTO.UniversityID : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.UniversityID = value;
            }
        }
        [Display(Name = "DisplayName_OrgShiftCode", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_OrgShiftCodeRequired")]
        public string OrgShiftCode
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.OrgShiftCode : string.Empty;
            }
            set
            {
                OrganisationSectionDetailsDTO.OrgShiftCode = value;
            }
        }


        public bool ActualExamPattern
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.ActualExamPattern : false;
            }
            set
            {
                OrganisationSectionDetailsDTO.ActualExamPattern = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.IsDeleted : false;
            }
            set
            {
                OrganisationSectionDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.CreatedBy > 0) ? OrganisationSectionDetailsDTO.CreatedBy : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.ModifiedBy.HasValue) ? OrganisationSectionDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.ModifiedDate.HasValue) ? OrganisationSectionDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.DeletedBy.HasValue) ? OrganisationSectionDetailsDTO.DeletedBy : new int();
            }
            set
            {
                OrganisationSectionDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null && OrganisationSectionDetailsDTO.DeletedDate.HasValue) ? OrganisationSectionDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrganisationSectionDetailsDTO.DeletedDate = value;
            }
        }

        [Display(Name = "DisplayName_IsFinalCourseYear", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_IsFinalCourseYear")]
        public bool IsFinalCourseYear
        {
            get
            {
                return (OrganisationSectionDetailsDTO != null) ? OrganisationSectionDetailsDTO.IsFinalCourseYear : false;
            }
            set
            {
                OrganisationSectionDetailsDTO.IsFinalCourseYear = value;
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
        public List<OrganisationSectionDetails> ListOrgSectionDetails
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrgSectionDetailsItems
        {
            get
            {
                return new SelectList(ListOrgSectionDetails, "ID", "CourseYearDescriptions");
            }
        }
        public string errorMessage { get; set; }

    }
}
