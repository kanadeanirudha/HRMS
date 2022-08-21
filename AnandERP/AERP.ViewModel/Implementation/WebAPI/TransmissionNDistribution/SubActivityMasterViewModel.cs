using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class SubActivityMasterViewModel
    {
        public SubActivityMasterViewModel()
        {
            SubActivitymasterDTO = new SubActivitymaster();
        }

        public SubActivitymaster SubActivitymasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.ID > 0) ? SubActivitymasterDTO.ID : new int();
            }
            set
            {
                SubActivitymasterDTO.ID = value;
            }
        }

        public string SubActivity
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.SubActivity : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.SubActivity = value;
            }
        }

        public string SubActivityCode
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.SubActivityCode : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.SubActivityCode = value;
            }
        }

        public string SubActivityDescription
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.SubActivityDescription : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.SubActivityDescription = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.IsDeleted : false;
            }
            set
            {
                SubActivitymasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.CreatedBy > 0) ? SubActivitymasterDTO.CreatedBy : new int();
            }
            set
            {
                SubActivitymasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SubActivitymasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.ModifiedBy > 0) ? SubActivitymasterDTO.ModifiedBy : new int();
            }
            set
            {
                SubActivitymasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.ModifiedDate.HasValue) ? SubActivitymasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SubActivitymasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.DeletedBy > 0) ? SubActivitymasterDTO.DeletedBy : new int();
            }
            set
            {
                SubActivitymasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.DeletedDate.HasValue) ? SubActivitymasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SubActivitymasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (SubActivitymasterDTO != null && SubActivitymasterDTO.LastSyncDate.HasValue) ? SubActivitymasterDTO.LastSyncDate : null;
            }
            set
            {
                SubActivitymasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.SyncType : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (SubActivitymasterDTO != null) ? SubActivitymasterDTO.Entity : string.Empty;
            }
            set
            {
                SubActivitymasterDTO.Entity = value;
            }
        }
    }
}
