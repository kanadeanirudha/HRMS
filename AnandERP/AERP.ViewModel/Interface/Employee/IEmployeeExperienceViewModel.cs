using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
   public interface IEmployeeExperienceViewModel
    {
        EmployeeExperience EmployeeExperienceDTO
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
          string ExperienceFromYear
         {
             get;
             set;
         }
          string ExperienceToYear
         {
             get;
             set;
         }
          Int16 ExperienceInMonth
         {
             get;
             set;
         }
          string PreviousOrganisationanisationName
         {
             get;
             set;
         }
          string PreviousOrganisationnisationAddress
         {
             get;
             set;
         }
          string Designation
         {
             get;
             set;
         }
          string Remarks
         {
             get;
             set;
         }
          int GeneralExperienceTypeMasterID
         {
             get;
             set;
         }
          string GeneralExperienceType
         {
             get;
             set;
         }
          string LastPayDrawnPayScale
         {
             get;
             set;
         }
          string NatureOfAppointment
         {
             get;
             set;
         }
          int GeneralJobStatusID
         {
             get;
             set;
         }
          string GeneralJobStatus
         {
             get;
             set;
         }
          string AppointmentOrderNumber
         {
             get;
             set;
         }
          string AppointmentOrderDateTime
         {
             get;
             set;
         }
          string UniversityApprovalNumber
         {
             get;
             set;
         }
          string UniversityApprovalDateTime
         {
             get;
             set;
         }
          int GeneralBoardUniversityID
         {
             get;
             set;
         }
          string GeneralBoardUniversityName
         {
             get;
             set;
         }
          string SubjectForApproval
         {
             get;
             set;
         }
          string UniversityApprovalType
         {
             get;
             set;
         }
          Int16 MonthOfApproval
         {
             get;
             set;
         }
          Int16 YearOfApproval
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
          int ModifiedBy
         {
             get;
             set;
         }
          DateTime ModifiedDate
         {
             get;
             set;
         }
          int DeletedBy
         {
             get;
             set;
         }
          DateTime DeletedDate
         {
             get;
             set;
         }
          string errorMessage { get; set; }
    }
}
