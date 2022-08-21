using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveDeductRuleExceptionForCentre : BaseDTO
    {
        //-------------------------------------Leave Master Property-------------------//
        public int LeaveMasterID { get; set; }
        public string LeaveCode { get; set; }
        public string LeaveDescription { get; set; }
        public bool IsCarryForwardForNextYear { get; set; }
        public bool IsEnCash { get; set; }
        public bool AttendanceNeeded { get; set; }
        public bool DocumentsNeeded { get; set; }
        public bool HalfDayFlag { get; set; }
        public bool LossOfPay { get; set; }
        public bool NoCredit { get; set; }
        public bool MinServiceRequire { get; set; }
        public bool OnDuty { get; set; }
        public string LeaveType { get; set; }
        public bool IsPostedOnce { get; set; }

        //-----------------------------------------LeaveDeductRule---------------------//
        public int LeaveDeductRuleID { get; set; }
        public Int16 PrioritySequenceNumber { get; set; }
        public int PriorityLeaveMasterID { get; set; }


        //----------------------------------LeaveDeductRuleExceptionForCentre-----------------//

        public int LeaveDeductRuleExceptionForCentreID { get; set; }        
        public string CentreCode { get; set; }


        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }

        //------------------------Extra Property--------------------
        public string CentreName { get; set; }
        public string HoCoRoScFlag { get; set; }
        public string PriorityLeaveDescription { get; set; }
     
    }
}
