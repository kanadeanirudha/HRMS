using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface IEmployeeQualificationViewModel
    {
        EmployeeQualification EmployeeQualificationDTO
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
         string FromYear
        {
            get;
            set;
        }
         string UptoYear
        {
            get;
            set;
        }
         string YearOfPassing
        {
            get;
            set;
        }
         string PassingDivision
        {
            get;
            set;
        }
         byte NoOfAttempts
        {
            get;
            set;
        }
         string NameOfInstitution
        {
            get;
            set;
        }

         int EducationTypeID
        {
            get;
            set;
        }
         int EducationID
        {
            get;
            set;
        }
         string EducationYear
        {
            get;
            set;
        }
         int BoardUniversityID
        {
            get;
            set;
        }
         double AggregatePercentage
        {
            get;
            set;
        }
         double FinalYearPercentage
        {
            get;
            set;
        }
         byte Rank
        {
            get;
            set;
        }
         string Remark
        {
            get;
            set;
        }
         string SpecailisationIn
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
    }
}
