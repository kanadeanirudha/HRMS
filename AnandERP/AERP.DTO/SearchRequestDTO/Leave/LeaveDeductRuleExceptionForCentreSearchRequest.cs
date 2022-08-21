using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveDeductRuleExceptionForCentreSearchRequest : Request
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

        //----------------------------------Common Proprty-----------------------------//
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<DateTime> DeletedDate { get; set; }

        //-----------------------------Extra proprty----------------------------//
        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }


        public string CentreName { get; set; }
    }
}
