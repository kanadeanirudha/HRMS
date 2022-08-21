using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMLocationTypeMasterViewModel : ICCRMLocationTypeMasterViewModel
    {
        public CCRMLocationTypeMasterViewModel()
        {
            CCRMLocationTypeMasterDTO = new CCRMLocationTypeMaster();
        }
        public CCRMLocationTypeMaster CCRMLocationTypeMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.ID > 0) ? CCRMLocationTypeMasterDTO.ID : new byte();
            }
            set
            {
                CCRMLocationTypeMasterDTO.ID = value;
            }
        }
        [Display(Name = "Location Type Code")]
        [Required(ErrorMessage = "Location Type Code Required")]
        public string LocationTypeCode
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.LocationTypeCode : string.Empty;
            }
            set
            {
                CCRMLocationTypeMasterDTO.LocationTypeCode = value;
            }
        }
        [Display(Name = "Location Type")]
        //[Required(ErrorMessage = "Location TypeRequired")]
        public byte  LocationType
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.LocationType : new byte();
            }
            set
            {
                CCRMLocationTypeMasterDTO.LocationType = value;
            }
        }
        [Display(Name = "Location Type Desc")]
        //[Required(ErrorMessage = "Location Type Code Required")]
        public string LocationTypeDesc
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.LocationTypeDesc : string.Empty;
            }
            set
            {
                CCRMLocationTypeMasterDTO.LocationTypeDesc = value;
            }
        }
        [Display(Name = "Response Time")]
        [Required(ErrorMessage = "Response Time Required")]
        public decimal ResponseTime
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.ResponseTime : new decimal();
            }
            set
            {
                CCRMLocationTypeMasterDTO.ResponseTime = value;
            }
        }
        [Display(Name = "Response Unit")]
        [Required(ErrorMessage = "Response Unit Required")]
        public string ResponseUnit
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.ResponseUnit : string.Empty;
            }
            set
            {
                CCRMLocationTypeMasterDTO.ResponseUnit = value;
            }
        }
        [Display(Name = "Call Charges")]
        [Required(ErrorMessage = "Call Charges Required")]
        public decimal CallCharges
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.CallCharges : new decimal();
            }
            set
            {
                CCRMLocationTypeMasterDTO.CallCharges = value;
            }
        }
        [Display(Name = "Distance")]
        [Required(ErrorMessage = "Distance Required")]
        public decimal Distance
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.Distance : new decimal();
            }
            set
            {
                CCRMLocationTypeMasterDTO.Distance = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.CreatedBy > 0) ? CCRMLocationTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMLocationTypeMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMLocationTypeMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null) ? CCRMLocationTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMLocationTypeMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.ModifiedBy.HasValue) ? CCRMLocationTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMLocationTypeMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.ModifiedDate.HasValue) ? CCRMLocationTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMLocationTypeMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.DeletedBy.HasValue) ? CCRMLocationTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMLocationTypeMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMLocationTypeMasterDTO != null && CCRMLocationTypeMasterDTO.DeletedDate.HasValue) ? CCRMLocationTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMLocationTypeMasterDTO.DeletedDate = value;
            }
        }
    }
}
