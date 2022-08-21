using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
  public  class CCRMMachineFamilyMasterViewModel :ICCRMMachineFamilyMasterViewModel
    {
        public CCRMMachineFamilyMasterViewModel()
        {
            CCRMMachineFamilyMasterDTO = new CCRMMachineFamilyMaster();
        }
        public CCRMMachineFamilyMaster CCRMMachineFamilyMasterDTO
        {
            get;
            set;
        }
        public Int16 ID
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.ID > 0) ? CCRMMachineFamilyMasterDTO.ID : new Int16();
            }
            set
            {
                CCRMMachineFamilyMasterDTO.ID = value;
            }
        }
        [Display(Name = "Machine Family Name")]
        [Required(ErrorMessage = "Machine Family Name Required")]
        public string MachineFamilyName
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null) ? CCRMMachineFamilyMasterDTO.MachineFamilyName : string.Empty;
            }
            set
            {
                CCRMMachineFamilyMasterDTO.MachineFamilyName = value;
            }
        }
        public Nullable<int> CreatedBy
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.CreatedBy > 0) ? CCRMMachineFamilyMasterDTO.CreatedBy : new int();
            }
            set
            {
                CCRMMachineFamilyMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null) ? CCRMMachineFamilyMasterDTO.IsDeleted : false;
            }
            set
            {
                CCRMMachineFamilyMasterDTO.IsDeleted = value;
            }
        }
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null) ? CCRMMachineFamilyMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineFamilyMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.ModifiedBy.HasValue) ? CCRMMachineFamilyMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMMachineFamilyMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.ModifiedDate.HasValue) ? CCRMMachineFamilyMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineFamilyMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.DeletedBy.HasValue) ? CCRMMachineFamilyMasterDTO.DeletedBy : new int();
            }
            set
            {
                CCRMMachineFamilyMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (CCRMMachineFamilyMasterDTO != null && CCRMMachineFamilyMasterDTO.DeletedDate.HasValue) ? CCRMMachineFamilyMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                CCRMMachineFamilyMasterDTO.DeletedDate = value;
            }
        }
    }
}
