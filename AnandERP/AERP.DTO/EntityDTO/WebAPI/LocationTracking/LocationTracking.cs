using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class LocationTracking : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int ManagerID
        {
            get;
            set;
        }

        public decimal Latitude
        {
            get;
            set;
        }

        public decimal Longitude
        {
            get;
            set;
        }
        public string XML
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Int64 Location_TimeStamp
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
    }
}
