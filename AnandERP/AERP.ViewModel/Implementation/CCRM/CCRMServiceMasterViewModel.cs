using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMServiceMasterViewModel :ICCRMServiceMasterViewModel
    {
        public CCRMServiceMasterViewModel()
        {
            CCRMServiceMasterDTO = new CCRMServiceMaster();
        }
        public CCRMServiceMaster CCRMServiceMasterDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.ID > 0) ? CCRMServiceMasterDTO.ID : new Int32();
            }
            set
            {
                CCRMServiceMasterDTO.ID = value;
            }
        }
        [Display(Name = "Service Details")]
       // [Required(ErrorMessage = "Action Code Required")]
        public string ServiceDetails
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.ServiceDetails : string.Empty;
            }
            set
            {
                CCRMServiceMasterDTO.ServiceDetails = value;
            }
        }
        [Display(Name = "Service Description")]
        // [Required(ErrorMessage = "Action Code Required")]
        public string ServiceDescription
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.ServiceDescription : string.Empty;
            }
            set
            {
                CCRMServiceMasterDTO.ServiceDescription = value;
            }
        }
        [Display(Name = "Call Charges")]
        // [Required(ErrorMessage = "Action Code Required")]
        public decimal CallCharges
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.CallCharges : new decimal();
            }
            set
            {
                CCRMServiceMasterDTO.CallCharges = value;
            }
        }
        [Display(Name = "Service Type")]
        // [Required(ErrorMessage = "Action Code Required")]
        public byte ServiceType
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.ServiceType : new byte();
            }
            set
            {
                CCRMServiceMasterDTO.ServiceType = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.CreatedBy > 0) ? CCRMServiceMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMServiceMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMServiceMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMServiceMasterDTO != null) ? CCRMServiceMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.ModifiedBy.HasValue) ? CCRMServiceMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMServiceMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.ModifiedDate.HasValue) ? CCRMServiceMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.DeletedBy.HasValue) ? CCRMServiceMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMServiceMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMServiceMasterDTO != null && CCRMServiceMasterDTO.DeletedDate.HasValue) ? CCRMServiceMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMServiceMasterDTO.DeletedDate = value;
            }
        }
    }
}
