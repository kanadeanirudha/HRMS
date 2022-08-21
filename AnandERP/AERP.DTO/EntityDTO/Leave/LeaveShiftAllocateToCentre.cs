using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveShiftAllocateToCentre : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int ShiftID
        {
            get;
            set;
        }
        public string ShiftDesc
        {
            get;
            set;
        }
        public string CentreName
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public bool Status { get; set; }
        public bool IsShiftIsLocked { get; set; }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}

