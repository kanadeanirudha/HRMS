using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class DailyActivityReportViewModel
    {
        public DailyActivityReportViewModel()
        {
            DailyActivityReportDTO = new DailyActivityReport();
        }

        public DailyActivityReport DailyActivityReportDTO
        {
            get;
            set;
        }

        public List<ActivityMaster> Activities
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.ID > 0) ? DailyActivityReportDTO.ID : new int();
            }
            set
            {
                DailyActivityReportDTO.ID = value;
            }
        }


        public decimal Latitude
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.Latitude : new Decimal();
            }
            set
            {
                DailyActivityReportDTO.Latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.Longitude : new Decimal();
            }
            set
            {
                DailyActivityReportDTO.Longitude = value;
            }
        }

        public int Status
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.Status > 0) ? DailyActivityReportDTO.Status : new int();
            }
            set
            {
                DailyActivityReportDTO.Status = value;
            }
        }

        public int ConsumerID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.ConsumerID > 0) ? DailyActivityReportDTO.ConsumerID : new int();
            }
            set
            {
                DailyActivityReportDTO.ConsumerID = value;
            }
        }

        public int EngineerID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.EngineerID > 0) ? DailyActivityReportDTO.EngineerID : new int();
            }
            set
            {
                DailyActivityReportDTO.EngineerID = value;
            }
        }

        public int ActivityID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.ActivityID > 0) ? DailyActivityReportDTO.ActivityID : new int();
            }
            set
            {
                DailyActivityReportDTO.ActivityID = value;
            }
        }

        public int SubActivityID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.SubActivityID > 0) ? DailyActivityReportDTO.SubActivityID : new int();
            }
            set
            {
                DailyActivityReportDTO.SubActivityID = value;
            }
        }

        public int CityID
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.CityID > 0) ? DailyActivityReportDTO.CityID : new int();
            }
            set
            {
                DailyActivityReportDTO.CityID = value;
            }
        }

        public string WorkDone
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.WorkDone : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.WorkDone = value;
            }
        }

        public string ActivityCategory
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.ActivityCategory : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.ActivityCategory = value;
            }
        }


        public int Labours
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.Labours > 0) ? DailyActivityReportDTO.Labours : new int();
            }
            set
            {
                DailyActivityReportDTO.Labours = value;
            }
        }

        public string Issues
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.Issues : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.Issues = value;
            }
        }

        public string WorkType
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.WorkType : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.WorkType = value;
            }
        }

        public bool ISAdd
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.ISAdd : false;
            }
            set
            {
                DailyActivityReportDTO.ISAdd = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.IsDeleted : false;
            }
            set
            {
                DailyActivityReportDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.CreatedBy > 0) ? DailyActivityReportDTO.CreatedBy : new int();
            }
            set
            {
                DailyActivityReportDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                DailyActivityReportDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.ModifiedBy > 0) ? DailyActivityReportDTO.ModifiedBy : new int();
            }
            set
            {
                DailyActivityReportDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.ModifiedDate.HasValue) ? DailyActivityReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                DailyActivityReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.DeletedBy > 0) ? DailyActivityReportDTO.DeletedBy : new int();
            }
            set
            {
                DailyActivityReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.DeletedDate.HasValue) ? DailyActivityReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                DailyActivityReportDTO.DeletedDate = value;
            }
        }
        public string VersionNumber
        {

            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.VersionNumber : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (DailyActivityReportDTO != null && DailyActivityReportDTO.LastSyncDate.HasValue) ? DailyActivityReportDTO.LastSyncDate : null;
            }
            set
            {
                DailyActivityReportDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.SyncType : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.SyncType = value;
            }
        }

        public string XML
        {
            get
           ;
            set
            ;
        }

        public string Entity
        {
            get
            {
                return (DailyActivityReportDTO != null) ? DailyActivityReportDTO.Entity : string.Empty;
            }
            set
            {
                DailyActivityReportDTO.Entity = value;
            }
        }
    }
}
