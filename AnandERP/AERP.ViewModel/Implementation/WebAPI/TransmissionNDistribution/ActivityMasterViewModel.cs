using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class ActivityMasterViewModel
    {
        public ActivityMasterViewModel()
        {
            ActivityMasterDTO = new ActivityMaster();
        }

        public ActivityMaster ActivityMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.ID > 0) ? ActivityMasterDTO.ID : new int();
            }
            set
            {
                ActivityMasterDTO.ID = value;
            }
        }

        public string Activity
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.Activity : string.Empty;
            }
            set
            {
                ActivityMasterDTO.Activity = value;
            }
        }

        public string Category
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.Category : string.Empty;
            }
            set
            {
                ActivityMasterDTO.Category = value;
            }
        }

        public string ActivityCode
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.ActivityCode : string.Empty;
            }
            set
            {
                ActivityMasterDTO.ActivityCode = value;
            }
        }

        public string ActivityDescription
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.ActivityDescription : string.Empty;
            }
            set
            {
                ActivityMasterDTO.ActivityDescription = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.IsDeleted : false;
            }
            set
            {
                ActivityMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.CreatedBy > 0) ? ActivityMasterDTO.CreatedBy : new int();
            }
            set
            {
                ActivityMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ActivityMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.ModifiedBy > 0) ? ActivityMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ActivityMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.ModifiedDate.HasValue) ? ActivityMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ActivityMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.DeletedBy > 0) ? ActivityMasterDTO.DeletedBy : new int();
            }
            set
            {
                ActivityMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.DeletedDate.HasValue) ? ActivityMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ActivityMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                ActivityMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.LastSyncDate.HasValue) ? ActivityMasterDTO.LastSyncDate : null;
            }
            set
            {
                ActivityMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.SyncType : string.Empty;
            }
            set
            {
                ActivityMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.Entity : string.Empty;
            }
            set
            {
                ActivityMasterDTO.Entity = value;
            }
        }

        public int SubActivityID
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.SubActivityID > 0) ? ActivityMasterDTO.SubActivityID : new int();
            }
            set
            {
                ActivityMasterDTO.SubActivityID = value;
            }
        }

        public string SubActivity
        {
            get
            {
                return (ActivityMasterDTO != null) ? ActivityMasterDTO.SubActivity : string.Empty;
            }
            set
            {
                ActivityMasterDTO.SubActivity = value;
            }
        }

        public int WorkDone
        {
            get
            {
                return (ActivityMasterDTO != null && ActivityMasterDTO.WorkDone > 0) ? ActivityMasterDTO.WorkDone : new int();
            }
            set
            {
                ActivityMasterDTO.WorkDone = value;
            }
        }
    }
}
