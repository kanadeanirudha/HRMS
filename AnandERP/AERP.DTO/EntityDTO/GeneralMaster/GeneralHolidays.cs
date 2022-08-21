using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralHolidays : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }

        public TimeSpan CheckInTime
        {
            get;
            set;
        }
        public TimeSpan CheckOutTime
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool IsFixHoliday
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
