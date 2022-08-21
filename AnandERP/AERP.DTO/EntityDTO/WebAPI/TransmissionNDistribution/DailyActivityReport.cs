using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class DailyActivityReport : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int ConsumerID
        {
            get;
            set;
        }

        public int ActivityID
        {
            get;
            set;
        }

        public string Activity
        {
            get;
            set;
        }

        public string ActivityCategory
        {
            get;
            set;
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

        public int CityID
        {
            get;
            set;
        }

        public string City
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

        public String WorkDone
        {
            get;
            set;
        }

        public int Labours
        {
            get;
            set;
        }

        public string Issues
        {
            get;
            set;
        }

        public string WorkType
        {
            get;
            set;
        }

        public string ConsumerName
        {
            get;
            set;
        }

        public string EngineerName
        {
            get;
            set;
        }

        public string XML
        {
            get;
            set;
        }

        public int Status
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

        public bool ISAdd
        {
            get;
            set;
        }

        public long ConsumerNumber
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

        public Int16 ConsumerStatus
        {
            get;
            set;
        }

        public int EngineerID
        {
            get;
            set;
        }

        public bool BillingStatus
        {
            get;
            set;
        }

        public int ReasonStatus
        {
            get;
            set;
        }
    }
}
