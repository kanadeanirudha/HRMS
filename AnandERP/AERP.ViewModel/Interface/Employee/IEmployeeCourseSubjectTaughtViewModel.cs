using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEmployeeCourseSubjectTaughtViewModel
    {
        EmployeeCourseSubjectTaught EmployeeCourseSubjectTaughtDTO
        {
            get;
            set;
        }
       int EmployeeID
        {
            get;
            set;
        }
        string SubjectName
        {
            get;
            set;
        }
       string SubjectCode
        {
            get;
            set;
        }
       bool IsActive
        {
            get;
            set;
        }
         bool IsDeleted
        {
            get;
            set;
        }
       int CreatedBy
        {
            get;
            set;
        }
        DateTime CreatedDate
        {
            get;
            set;
        }
        int? ModifiedBy
        {
            get;
            set;
        }
       DateTime? ModifiedDate
        {
            get;
            set;
        }
       int? DeletedBy
        {
            get;
            set;
        }
        DateTime? DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}

