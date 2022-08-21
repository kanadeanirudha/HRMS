using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public interface IEmployeeServiceDetailsViewModelViewModel
    {
        EmployeeServiceDetails EmployeeServiceDetailsDTO
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

         string EmployeeCode
         {
             get;
             set;
         }

         string EmployeeName
         {
             get;
             set;
         }

         int SequenceNumber
        {
            get;
            set;
        }
         string OrderNumber
        {
            get;
            set;
        }
         string AcceptedByEmployee
        {
            get;
            set;
        }
         string PromotionDemotionFlag
        {
            get;
            set;
        }
          string PromotionDemotionDate
        {
            get;
            set;
        }
          string PreviousPromotionDemotionDate
        {
            get;
            set;
        }
         int EmployeeDesignationMasterID
        {
            get;
            set;
        }
         string CentreCode
         {
             get;
             set;
         }
         int DepartmentID
        {
            get;
            set;
        }
         string OldCentreCode
         {
             get;
             set;
         }
         string OldDepartmentName
         {
             get;
             set;
         }
          string ChargeTakingDate
        {
            get;
            set;
        }
         int OldDesignationID
        {
            get;
            set;
        }
         int OldDepartmentID
        {
            get;
            set;
        }
          string CollegeApprovalDate
        {
            get;
            set;
        }
          string UniversityApprovalDate
        {
            get;
            set;
        }
         string CollegeApprovalNumber
        {
            get;
            set;
        }
         string UniversityApprovalNumber
        {
            get;
            set;
        }
         string NatureOfDuty
        {
            get;
            set;
        }
         decimal BasicAmount
        {
            get;
            set;
        }
         string ApprovedBy
        {
            get;
            set;
        }
         decimal NewGrade
        {
            get;
            set;
        }
         int NewPayscaleID
        {
            get;
            set;
        }
         string NatureOfAppointment
        {
            get;
            set;
        }
         string UniversityApprovalType
        {
            get;
            set;
        }
         int GeneralBoardUniversityID
        {
            get;
            set;
        }
         string SubjectForApproval
        {
            get;
            set;
        }
          string GrantedPromotionDate
        {
            get;
            set;
        }
         int GrantedPromotionDesignationID
        {
            get;
            set;
        }
         string GrantedPromotionLevel
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
