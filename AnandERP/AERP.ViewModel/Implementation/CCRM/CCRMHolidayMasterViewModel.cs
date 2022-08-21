using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
  public  class CCRMHolidayMasterViewModel:ICCRMHolidayMasterViewModel
    {
        public CCRMHolidayMasterViewModel()
        {
            CCRMHolidayMasterDTO = new CCRMHolidayMaster();
        }
        public CCRMHolidayMaster CCRMHolidayMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.ID > 0) ? CCRMHolidayMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMHolidayMasterDTO.ID = value;
            }
        }
        [Display(Name = "Holiday Desc")]
       // [Required(ErrorMessage = "Bank Name Required")]
        public string HolidayDesc
        {
            get
            {
                return (CCRMHolidayMasterDTO != null) ? CCRMHolidayMasterDTO.HolidayDesc : string.Empty;
            }
            set
            {
                CCRMHolidayMasterDTO.HolidayDesc = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.CreatedBy > 0) ? CCRMHolidayMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMHolidayMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMHolidayMasterDTO != null) ? CCRMHolidayMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMHolidayMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMHolidayMasterDTO != null) ? CCRMHolidayMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMHolidayMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.ModifiedBy.HasValue) ? CCRMHolidayMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMHolidayMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.ModifiedDate.HasValue) ? CCRMHolidayMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMHolidayMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.DeletedBy.HasValue) ? CCRMHolidayMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMHolidayMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMHolidayMasterDTO != null && CCRMHolidayMasterDTO.DeletedDate.HasValue) ? CCRMHolidayMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMHolidayMasterDTO.DeletedDate = value;
            }
        }
    }
}
