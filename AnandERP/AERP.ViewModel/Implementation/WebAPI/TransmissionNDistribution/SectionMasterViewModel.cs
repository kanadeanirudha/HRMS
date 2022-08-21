using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class SectionMasterViewModel
    {
        public SectionMasterViewModel()
        {
            SectionMasterDTO = new SectionMaster();
        }

        public SectionMaster SectionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.ID > 0) ? SectionMasterDTO.ID : new int();
            }
            set
            {
                SectionMasterDTO.ID = value;
            }
        }

        public string SectionCode
        {
            get
            {
                return (SectionMasterDTO != null) ? SectionMasterDTO.SectionCode : string.Empty;
            }
            set
            {
                SectionMasterDTO.SectionCode = value;
            }
        }

        public string Title
        {
            get
            {
                return (SectionMasterDTO != null) ? SectionMasterDTO.Title : string.Empty;
            }
            set
            {
                SectionMasterDTO.Title = value;
            }
        }

        public string CategoryDescription
        {
            get
            {
                return (SectionMasterDTO != null) ? SectionMasterDTO.CategoryDescription : string.Empty;
            }
            set
            {
                SectionMasterDTO.CategoryDescription = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SectionMasterDTO != null) ? SectionMasterDTO.IsDeleted : false;
            }
            set
            {
                SectionMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.CreatedBy > 0) ? SectionMasterDTO.CreatedBy : new int();
            }
            set
            {
                SectionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SectionMasterDTO != null) ? SectionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SectionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.ModifiedBy > 0) ? SectionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                SectionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.ModifiedDate.HasValue) ? SectionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SectionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.DeletedBy > 0) ? SectionMasterDTO.DeletedBy : new int();
            }
            set
            {
                SectionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SectionMasterDTO != null && SectionMasterDTO.DeletedDate.HasValue) ? SectionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SectionMasterDTO.DeletedDate = value;
            }
        }

    }
}
