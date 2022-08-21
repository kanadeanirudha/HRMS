using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeeChildrenDetailsViewModel
    {
        EmployeeChildrenDetails EmployeeChildrenDetailsDTO
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
         int TitleMasterID
        {
            get;
            set;
        }
         string NameTitle
        {
            get;
            set;
        }
         string ChildName
        {
            get;
            set;
        }
       string GenderCode
         {
             get;
             set;
         }
         string ChildQualification
        {
            get;
            set;
        }
         string ChildDateOfBirth
        {
            get;
            set;
        }
         string Hobby
        {
            get;
            set;
        }
         string Sports
        {
            get;
            set;
        }
         string CurriculamActivity
        {
            get;
            set;
        }
         bool GotAnyMedal
        {
            get;
            set;
        }
         string MedalReceivedDate
        {
            get;
            set;
        }
         string MedalDescription
        {
            get;
            set;
        }
         bool IsScholarshipReceived
        {
            get;
            set;
        }
         decimal ScholarshipAmount
        {
            get;
            set;
        }
         string ScholarshipStartDate
        {
            get;
            set;
        }
         string ScholarshipUptoDate
        {
            get;
            set;
        }
         string ScholarshipDescription
        {
            get;
            set;
        }
         string IdentityMarks
        {
            get;
            set;
        }
         string Profession
        {
            get;
            set;
        }
         string Height
        {
            get;
            set;
        }
         string Weight
        {
            get;
            set;
        }
         string ChildrenRelation
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
