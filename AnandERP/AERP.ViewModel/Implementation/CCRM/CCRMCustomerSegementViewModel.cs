using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
namespace AERP.ViewModel
{
    public class CCRMCustomerSegementViewModel : ICCRMCustomerSegementViewModel
    {
        public CCRMCustomerSegementViewModel()
        {
            CCRMCustomerSegementDTO = new CCRMCustomerSegement();
        }
        public CCRMCustomerSegement CCRMCustomerSegementDTO
        {
            get;
            set;
        }
        public byte ID
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.ID > 0) ? CCRMCustomerSegementDTO.ID : new byte();
            }
            set
            {
                CCRMCustomerSegementDTO.ID = value;
            }
        }
        [Display(Name = "Segement Name")]
        [Required(ErrorMessage = "Segement Name Required")]
        public string SegementName
        {
            get
            {
                return (CCRMCustomerSegementDTO != null) ? CCRMCustomerSegementDTO.SegementName : string.Empty;
            }
            set
            {
                CCRMCustomerSegementDTO.SegementName = value;
            }
        }
      

        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.CreatedBy > 0) ? CCRMCustomerSegementDTO.CreatedBy : new int();
            }
            set
            {
                CCRMCustomerSegementDTO.CreatedBy = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMCustomerSegementDTO != null) ? CCRMCustomerSegementDTO.IsDeleted : false;
            }
            set
            {
                CCRMCustomerSegementDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMCustomerSegementDTO != null) ? CCRMCustomerSegementDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMCustomerSegementDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.ModifiedBy.HasValue) ? CCRMCustomerSegementDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMCustomerSegementDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.ModifiedDate.HasValue) ? CCRMCustomerSegementDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMCustomerSegementDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.DeletedBy.HasValue) ? CCRMCustomerSegementDTO.DeletedBy : new int();
            }
            set
            {
                CCRMCustomerSegementDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMCustomerSegementDTO != null && CCRMCustomerSegementDTO.DeletedDate.HasValue) ? CCRMCustomerSegementDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMCustomerSegementDTO.DeletedDate = value;
            }
        }
    }
}
