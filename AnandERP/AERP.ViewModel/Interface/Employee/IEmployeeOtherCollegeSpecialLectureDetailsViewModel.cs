using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeeOtherCollegeSpecialLectureDetailsViewModel
    {
        EmployeeOtherCollegeSpecialLectureDetails EmployeeOtherCollegeSpecialLectureDetailsDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int EmployeeID
        {
            get;
            set;
        }
         string InstituteName
        {
            get;
            set;
        }
         string InstituteAddress
        {
            get;
            set;
        }
         string TopicOfLecture
        {
            get;
            set;
        }
         string DateOfLectureDelivered
        {
            get;
            set;
        }
        string Remarks
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
    }
}
