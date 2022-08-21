using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class ActivityRuleViewModel
    {
        public ActivityRuleViewModel()
        {
            ActivityRuleDTO = new ActivityRule();
        }

        public ActivityRule ActivityRuleDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.ID > 0) ? ActivityRuleDTO.ID : new int();
            }
            set
            {
                ActivityRuleDTO.ID = value;
            }
        }

        public int ActivityID
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.ActivityID > 0) ? ActivityRuleDTO.ActivityID : new int();
            }
            set
            {
                ActivityRuleDTO.ActivityID = value;
            }
        }

        public int SubActivityID
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.SubActivityID > 0) ? ActivityRuleDTO.SubActivityID : new int();
            }
            set
            {
                ActivityRuleDTO.SubActivityID = value;
            }
        }

        public int Value
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.Value > 0) ? ActivityRuleDTO.Value : new int();
            }
            set
            {
                ActivityRuleDTO.Value = value;
            }
        }

        public bool IsPresent
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.IsPresent : false;
            }
            set
            {
                ActivityRuleDTO.IsPresent = value;
            }
        }

        public bool IsFixedValue
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.IsFixedValue : false;
            }
            set
            {
                ActivityRuleDTO.IsFixedValue = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.IsDeleted : false;
            }
            set
            {
                ActivityRuleDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.CreatedBy > 0) ? ActivityRuleDTO.CreatedBy : new int();
            }
            set
            {
                ActivityRuleDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ActivityRuleDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.ModifiedBy > 0) ? ActivityRuleDTO.ModifiedBy : new int();
            }
            set
            {
                ActivityRuleDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.ModifiedDate.HasValue) ? ActivityRuleDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ActivityRuleDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.DeletedBy > 0) ? ActivityRuleDTO.DeletedBy : new int();
            }
            set
            {
                ActivityRuleDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.DeletedDate.HasValue) ? ActivityRuleDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ActivityRuleDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.VersionNumber : string.Empty;
            }
            set
            {
                ActivityRuleDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (ActivityRuleDTO != null && ActivityRuleDTO.LastSyncDate.HasValue) ? ActivityRuleDTO.LastSyncDate : null;
            }
            set
            {
                ActivityRuleDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.SyncType : string.Empty;
            }
            set
            {
                ActivityRuleDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (ActivityRuleDTO != null) ? ActivityRuleDTO.Entity : string.Empty;
            }
            set
            {
                ActivityRuleDTO.Entity = value;
            }
        }
    }
}
