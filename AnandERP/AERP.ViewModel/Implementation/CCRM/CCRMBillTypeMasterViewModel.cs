using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace AERP.ViewModel
{
   public class CCRMBillTypeMasterViewModel :ICCRMBillTypeMasterViewModel
    {
        public CCRMBillTypeMasterViewModel()
        {
            CCRMBillTypeMasterDTO = new CCRMBillTypeMaster();
        }
        public CCRMBillTypeMaster CCRMBillTypeMasterDTO
        {
            get;
            set;
        }
        public Int16 ID
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.ID > 0) ? CCRMBillTypeMasterDTO.ID : new Int16();
            }
            set
            {
                CCRMBillTypeMasterDTO.ID = value;
            }
        }
        [Display(Name = "Bill Type Name")]
        [Required(ErrorMessage = "Bill Type Name Required")]
        public string BillTypeName
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null) ? CCRMBillTypeMasterDTO.BillTypeName : string.Empty;
            }
            set
            {
                CCRMBillTypeMasterDTO.BillTypeName = value;
            }
        }
        [Display(Name = "Bill Prefix")]
        [Required(ErrorMessage = "Bill Prefix Required")]
        public string BillPrefix
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null) ? CCRMBillTypeMasterDTO.BillPrefix : string.Empty;
            }
            set
            {
                CCRMBillTypeMasterDTO.BillPrefix = value;
            }
        }
        [Display(Name = "Bill Type")]
        //[Required(ErrorMessage = "Action Desciption Required")]
        public byte BillType
        {

            get
            {
                return (CCRMBillTypeMasterDTO != null) ? CCRMBillTypeMasterDTO.BillType : new byte();
            }
            set
            {
                CCRMBillTypeMasterDTO.BillType = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.CreatedBy > 0) ? CCRMBillTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMBillTypeMasterDTO.CreatedBy = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null) ? CCRMBillTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMBillTypeMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null) ? CCRMBillTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMBillTypeMasterDTO.CreatedDate = value;
            }
        }
        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.ModifiedBy.HasValue) ? CCRMBillTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMBillTypeMasterDTO.ModifiedBy = value;
            }
        }
        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.ModifiedDate.HasValue) ? CCRMBillTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMBillTypeMasterDTO.ModifiedDate = value;
            }
        }
        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.DeletedBy.HasValue) ? CCRMBillTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMBillTypeMasterDTO.DeletedBy = value;
            }
        }
        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMBillTypeMasterDTO != null && CCRMBillTypeMasterDTO.DeletedDate.HasValue) ? CCRMBillTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMBillTypeMasterDTO.DeletedDate = value;
            }
        }
    }
}
