using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ActivityMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int CategoryID
        {
            get;
            set;
        }

        public string Activity
        {
            get;
            set;
        }

        public string ActivityCode
        {
            get;
            set;
        }

        public string ActivityDescription
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }

        public int SubActivityID
        {
            get;
            set;
        }

        public string SubActivity
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public int WorkDone
        {
            get;
            set;
        }
    }
}
