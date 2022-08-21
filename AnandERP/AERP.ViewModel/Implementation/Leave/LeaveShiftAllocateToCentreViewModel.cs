using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveShiftAllocateToCentreViewModel : ILeaveShiftAllocateToCentreViewModel
    {
        public LeaveShiftAllocateToCentreViewModel()
        {
            LeaveShiftAllocateToCentreDTO = new LeaveShiftAllocateToCentre();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
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

        public LeaveShiftAllocateToCentre LeaveShiftAllocateToCentreDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null && LeaveShiftAllocateToCentreDTO.ID > 0) ? LeaveShiftAllocateToCentreDTO.ID : new int();
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.ID = value;
            }
        }
        public int ShiftID
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null && LeaveShiftAllocateToCentreDTO.ShiftID > 0) ? LeaveShiftAllocateToCentreDTO.ShiftID : new int();
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.ShiftID = value;
            }
        }
        public string ShiftDesc
        {
            get;
            set;
        }
        [Display(Name = "Centre")]
        public string CentreName
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.CentreName = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.CentreCode = value;
            }
        }
        public bool Status
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.Status : false;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.Status = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.IsDeleted : false;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null && LeaveShiftAllocateToCentreDTO.CreatedBy > 0) ? LeaveShiftAllocateToCentreDTO.CreatedBy : new int();
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null && LeaveShiftAllocateToCentreDTO.ModifiedBy > 0) ? LeaveShiftAllocateToCentreDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null && LeaveShiftAllocateToCentreDTO.DeletedBy > 0) ? LeaveShiftAllocateToCentreDTO.DeletedBy : new int();
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveShiftAllocateToCentreDTO != null) ? LeaveShiftAllocateToCentreDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveShiftAllocateToCentreDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }
    }
}
