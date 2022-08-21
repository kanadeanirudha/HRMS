using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
  public  class CCRMCalenderMaster:BaseDTO
    {
        public Int32 ID { get; set; }

        public string Date { get; set; }
        public string HolidayDesc { get; set; }
        public string CalenderYear { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public bool AllSundays { get; set; }
        public bool AllSaturday { get; set; }
        public string SATSUNDate { get; set; }
        public string Day { get; set; }
    }
}
