using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public interface ILeaveMasterViewModel
    {
        LeaveMaster LeaveMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string LeaveCode
        {
            get;
            set;
        }
        string LeaveDescription
        {
            get;
            set;
        }
        bool IsCarryForwardForNextYear
        {
            get;
            set;
        }
        bool IsEnCash
        {
            get;
            set;
        }
        bool AttendanceNeeded
        {
            get;
            set;
        }
        bool DocumentsNeeded
        {
            get;
            set;
        }
        bool HalfDayFlag
        {
            get;
            set;
        }
        bool LossOfPay
        {
            get;
            set;
        }
        bool NoCredit
        {
            get;
            set;
        }
        bool MinServiceRequire
        {
            get;
            set;
        }
        bool OnDuty
        {
            get;
            set;
        }
        bool IsPostedOnce
        {
            get;
            set;
        }
        string LeaveType
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
