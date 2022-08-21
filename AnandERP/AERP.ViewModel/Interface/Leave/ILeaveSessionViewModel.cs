using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public interface ILeaveSessionViewModel
    {
        LeaveSession LeaveSessionDTO
        {
            get;
            set;
        }
        int LeaveSessionID
        {
            get;
            set;
        }

         string LeaveSessionName
        {
            get;
            set;
        }
         string LeaveSessionFromDate
        {
            get;
            set;
        }
         string LeaveSessionUptoDate
        {
            get;
            set;
        }
         bool IsSessionLocked
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         string CentreName
        {
            get;
            set;
        }
         bool IsCurrentLeaveSession
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
         DateTime ModifiedDate
        {
            get;
            set;
        }
         int? DeletedBy
        {
            get;
            set;
        }
         DateTime DeletedDate
        {
            get;
            set;
        }
         List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
         {
             get;
             set;
         }


        ////------------------------Leave Session Details--------------------------////

         int LeaveSessionDetailsID
        {
            get;
            set;
        }
         int JobProfileID
        {
            get;
            set;
        }
         string JobProfileDescription
         {
             get;
             set;
         }
         string JobStatusCode
        {
            get;
            set;
        }
         string JobStatusDescription
         {
             get;
             set;
         }
         string EntityLevel
        {
            get;
            set;
        }
         int Mode
         {
             get;
             set;
         }
         string SelectedIDs
         {
             get;
             set;
         }
    }
}
