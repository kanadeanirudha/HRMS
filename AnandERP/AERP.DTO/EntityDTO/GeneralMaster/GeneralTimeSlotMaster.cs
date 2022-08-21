using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralTimeSlotMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string FromTime
        {
            get;
            set;
        }
        public string ToTime
        {
            get;
            set;
        }
        public string TimeSlot
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
        //Feilds from GeneralTimezoneMaster
        public int TimeZoneID
        {
            get;
            set;
        }
        public string TimeZone
        {
            get;
            set;
        }
        public string  UTCoffset
        {
            get;
            set;
        }

    }
}
