using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AERP.ViewModel
{
    public interface ILeaveDeductRuleExceptionForCentreViewModel
    {
        LeaveDeductRuleExceptionForCentre LeaveDeductRuleExceptionForCentreDTO { get; set; }

        //-------------------------------------Leave Master Property-------------------//

        int LeaveMasterID { get; set; }
        string LeaveCode { get; set; }
        string LeaveDescription { get; set; }
        bool IsCarryForwardForNextYear { get; set; }
        bool IsEnCash { get; set; }
        bool AttendanceNeeded { get; set; }
        bool DocumentsNeeded { get; set; }
        bool HalfDayFlag { get; set; }
        bool LossOfPay { get; set; }
        bool NoCredit { get; set; }
        bool MinServiceRequire { get; set; }
        bool OnDuty { get; set; }
        string LeaveType { get; set; }
        bool IsPostedOnce { get; set; }


        //-----------------------------------------LeaveDeductRule---------------------//
        int LeaveDeductRuleID { get; set; }
        Int16 PrioritySequenceNumber { get; set; }
        int PriorityLeaveMasterID { get; set; }


        //----------------------------------LeaveDeductRuleExceptionForCentre-----------------//

        int LeaveDeductRuleExceptionForCentreID { get; set; }
        string CentreCode { get; set; }
        
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }

        //-------------------------------Extra Property----------------------------------//
        string errorMessage { get; set; }
        string CentreName { get; set; }
    }
}