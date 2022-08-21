using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class LocationTrackingViewModel
    {
        public int ID
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.ID > 0) ? LocationTrackingDTO.ID : new int();
            }
            set
            {
                LocationTrackingDTO.ID = value;
            }
        }

        public LocationTrackingViewModel()
        {
            LocationTrackingDTO = new LocationTracking();
        }

        public LocationTracking LocationTrackingDTO
        {
            get;
            set;
        }

        public int ManagerID
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.ManagerID > 0) ? LocationTrackingDTO.ManagerID : new int();
            }
            set
            {
                LocationTrackingDTO.ManagerID = value;
            }
        }

        public decimal Latitude
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.Latitude : new Decimal();
            }
            set
            {
                LocationTrackingDTO.Latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.Longitude : new Decimal();
            }
            set
            {
                LocationTrackingDTO.Longitude = value;
            }
        }

        public string XML
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.XML : string.Empty;
            }
            set
            {
                LocationTrackingDTO.XML = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.IsDeleted : false;
            }
            set
            {
                LocationTrackingDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.CreatedBy > 0) ? LocationTrackingDTO.CreatedBy : new int();
            }
            set
            {
                LocationTrackingDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LocationTrackingDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.ModifiedBy > 0) ? LocationTrackingDTO.ModifiedBy : new int();
            }
            set
            {
                LocationTrackingDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.ModifiedDate.HasValue) ? LocationTrackingDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LocationTrackingDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.DeletedBy > 0) ? LocationTrackingDTO.DeletedBy : new int();
            }
            set
            {
                LocationTrackingDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.DeletedDate.HasValue) ? LocationTrackingDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LocationTrackingDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.VersionNumber : string.Empty;
            }
            set
            {
                LocationTrackingDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (LocationTrackingDTO != null && LocationTrackingDTO.LastSyncDate.HasValue) ? LocationTrackingDTO.LastSyncDate : null;
            }
            set
            {
                LocationTrackingDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.SyncType : string.Empty;
            }
            set
            {
                LocationTrackingDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (LocationTrackingDTO != null) ? LocationTrackingDTO.Entity : string.Empty;
            }
            set
            {
                LocationTrackingDTO.Entity = value;
            }
        }
    }
}
