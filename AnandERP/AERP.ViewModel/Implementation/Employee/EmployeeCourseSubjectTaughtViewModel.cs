using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AMS.ViewModel
{
    public class EmployeeCourseSubjectTaughtViewModel : IEmployeeCourseSubjectTaughtViewModel
    {

        public EmployeeCourseSubjectTaughtViewModel()
        {
            EmployeeCourseSubjectTaughtDTO = new EmployeeCourseSubjectTaught();
        }

        public EmployeeCourseSubjectTaught EmployeeCourseSubjectTaughtDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.ID > 0) ? EmployeeCourseSubjectTaughtDTO.ID : new int();
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.EmployeeID = value;
            }
        }


        [Display(Name = "DisplayName_SubjectName", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_SubjectNameRequired")]
        public string SubjectName
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.SubjectName : string.Empty;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.SubjectName = value;
            }
        }

        [Display(Name = "DisplayName_SubjectCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_SubjectCodeRequired")]
        public string SubjectCode
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.SubjectCode : string.Empty;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.SubjectCode = value;
            }
        }

       
        public bool IsActive
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.IsActive : false;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.IsActive = value;
            }
        }
       

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.IsDeleted : false;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.CreatedBy > 0) ? EmployeeCourseSubjectTaughtDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null) ? EmployeeCourseSubjectTaughtDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.ModifiedBy.HasValue) ? EmployeeCourseSubjectTaughtDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.ModifiedDate.HasValue) ? EmployeeCourseSubjectTaughtDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.DeletedBy.HasValue) ? EmployeeCourseSubjectTaughtDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeCourseSubjectTaughtDTO != null && EmployeeCourseSubjectTaughtDTO.DeletedDate.HasValue) ? EmployeeCourseSubjectTaughtDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeCourseSubjectTaughtDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

