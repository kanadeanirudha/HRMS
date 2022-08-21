using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveDeductRuleExceptionForCentreViewModel : ILeaveDeductRuleExceptionForCentreViewModel
    {

        public LeaveDeductRuleExceptionForCentreViewModel()
        {
            LeaveDeductRuleExceptionForCentreDTO = new LeaveDeductRuleExceptionForCentre();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public LeaveDeductRuleExceptionForCentre LeaveDeductRuleExceptionForCentreDTO
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        //-------------------------------------Leave Master Property-------------------//

        public int LeaveMasterID
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveMasterID = value;
            }
        }

        public string LeaveCode
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.LeaveType != "") ? LeaveDeductRuleExceptionForCentreDTO.LeaveType : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveType = value;
            }
        }

        public string LeaveDescription
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.LeaveDescription != "") ? LeaveDeductRuleExceptionForCentreDTO.LeaveDescription : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveDescription = value;
            }
        }

        public bool IsCarryForwardForNextYear
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.IsCarryForwardForNextYear : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.IsCarryForwardForNextYear = value;
            }
        }

        public bool IsEnCash
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.IsEnCash : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.IsEnCash = value;
            }
        }

        public bool AttendanceNeeded
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.AttendanceNeeded : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.AttendanceNeeded = value;
            }
        }

        public bool DocumentsNeeded
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.DocumentsNeeded : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.DocumentsNeeded = value;
            }
        }

        public bool HalfDayFlag
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.HalfDayFlag : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.HalfDayFlag = value;
            }
        }

        public bool LossOfPay
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.LossOfPay : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LossOfPay = value;
            }
        }

        public bool NoCredit
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.NoCredit : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.NoCredit = value;
            }
        }

        public bool MinServiceRequire
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.MinServiceRequire : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.MinServiceRequire = value;
            }
        }

        public bool OnDuty
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.OnDuty : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.OnDuty = value;
            }
        }

        public string LeaveType
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.LeaveType != "") ? LeaveDeductRuleExceptionForCentreDTO.LeaveType : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveType = value;
            }
        }

        public bool IsPostedOnce
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.IsPostedOnce : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.IsPostedOnce = value;
            }
        }


        //-----------------------------------------LeaveDeductRule---------------------//

        public int LeaveDeductRuleID
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleID > 0) ? LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleID : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleID = value;
            }
        }


        public Int16 PrioritySequenceNumber
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.PrioritySequenceNumber : new Int16();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.PrioritySequenceNumber = value;
            }
        }
        public int PriorityLeaveMasterID
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.PriorityLeaveMasterID : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.PriorityLeaveMasterID = value;
            }
        }

        //----------------------------------LeaveDeductRuleExceptionForCentre-----------------//

        public int LeaveDeductRuleExceptionForCentreID
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleExceptionForCentreID > 0) ? LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleExceptionForCentreID : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.LeaveDeductRuleExceptionForCentreID = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.CentreCode = value;
            }
        }
              
        //-----------------------------Common Property-----------------------------------//
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.IsDeleted : false;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.CreatedBy > 0) ? LeaveDeductRuleExceptionForCentreDTO.CreatedBy : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null) ? LeaveDeductRuleExceptionForCentreDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.ModifiedBy.HasValue) ? LeaveDeductRuleExceptionForCentreDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.ModifiedDate.HasValue) ? LeaveDeductRuleExceptionForCentreDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.DeletedBy.HasValue) ? LeaveDeductRuleExceptionForCentreDTO.DeletedBy : new int();
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.DeletedDate.HasValue) ? LeaveDeductRuleExceptionForCentreDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.DeletedDate = value;
            }
        }

        //-----------------------------------Extra Property--------------------------------------//
        public string CentreName
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.CentreName != "") ? LeaveDeductRuleExceptionForCentreDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.CentreName = value;
            }
        }

        public string HoCoRoScFlag
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.HoCoRoScFlag != "") ? LeaveDeductRuleExceptionForCentreDTO.HoCoRoScFlag : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.HoCoRoScFlag = value;
            }
        }

        public string PriorityLeaveDescription
        {
            get
            {
                return (LeaveDeductRuleExceptionForCentreDTO != null && LeaveDeductRuleExceptionForCentreDTO.PriorityLeaveDescription != "") ? LeaveDeductRuleExceptionForCentreDTO.PriorityLeaveDescription : string.Empty;
            }
            set
            {
                LeaveDeductRuleExceptionForCentreDTO.PriorityLeaveDescription = value;
            }
        }

        public string errorMessage { get; set; }
    }
}

