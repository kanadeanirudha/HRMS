using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMCalenderMasterViewModel:ICCRMCalenderMasterViewModel
    {
        public CCRMCalenderMasterViewModel()
        {
            CCRMCalenderMasterDTO = new CCRMCalenderMaster();
        }
        public CCRMCalenderMaster CCRMCalenderMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.ID > 0) ? CCRMCalenderMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMCalenderMasterDTO.ID = value;
            }
        }
        [Display(Name = "Date")]
        //[Required(ErrorMessage = "Bank Name Required")]
        public string Date
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.Date : string.Empty;
            }
            set
            {
                CCRMCalenderMasterDTO.Date = value;
            }
        }
        [Display(Name = "Holiday Desc")]
        //[Required(ErrorMessage = "Bank Name Required")]
        public string HolidayDesc
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.HolidayDesc : string.Empty;
            }
            set
            {
                CCRMCalenderMasterDTO.HolidayDesc = value;
            }
        }
        [Display(Name = "Calender Year")]
        //[Required(ErrorMessage = "Bank Name Required")]
        public string CalenderYear
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.CalenderYear : string.Empty;
            }
            set
            {
                CCRMCalenderMasterDTO.CalenderYear = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.CreatedBy > 0) ? CCRMCalenderMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCalenderMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMCalenderMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCalenderMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.ModifiedBy.HasValue) ? CCRMCalenderMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCalenderMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.ModifiedDate.HasValue) ? CCRMCalenderMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCalenderMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.DeletedBy.HasValue) ? CCRMCalenderMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCalenderMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCalenderMasterDTO != null && CCRMCalenderMasterDTO.DeletedDate.HasValue) ? CCRMCalenderMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCalenderMasterDTO.DeletedDate = value;
            }
        }
        [Display(Name = "All Sundays")]
        //[Required(ErrorMessage = "Bank Name Required")]
        public bool AllSundays
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.AllSundays : new bool();
            }
            set
            {
                CCRMCalenderMasterDTO.AllSundays = value;
            }
        }
        [Display(Name = "All Saturday")]
        //[Required(ErrorMessage = "Bank Name Required")]
        public bool AllSaturday
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.AllSaturday : new bool();
            }
            set
            {
                CCRMCalenderMasterDTO.AllSaturday = value;
            }
        }
        public string SATSUNDate
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.SATSUNDate : string.Empty;
            }
            set
            {
                CCRMCalenderMasterDTO.SATSUNDate = value;
            }
        }
        public string Day
        {
            get
            {
                return (CCRMCalenderMasterDTO != null) ? CCRMCalenderMasterDTO.Day : string.Empty;
            }
            set
            {
                CCRMCalenderMasterDTO.Day = value;
            }
        }
    }
}
