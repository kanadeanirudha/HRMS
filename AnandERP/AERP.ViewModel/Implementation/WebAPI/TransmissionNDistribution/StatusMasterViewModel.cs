using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class StatusMasterViewModel
    {
        public StatusMasterViewModel()
        {
            StatusMasterDTO = new StatusMaster();
        }

        public StatusMaster StatusMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.ID > 0) ? StatusMasterDTO.ID : new int();
            }
            set
            {
                StatusMasterDTO.ID = value;
            }
        }

        public string StatusCode
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.StatusCode : string.Empty;
            }
            set
            {
                StatusMasterDTO.StatusCode = value;
            }
        }

        public string ParentDisplayStatus
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.ParentDisplayStatus : string.Empty;
            }
            set
            {
                StatusMasterDTO.ParentDisplayStatus = value;
            }
        }

        public string Status
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.Status : string.Empty;
            }
            set
            {
                StatusMasterDTO.Status = value;
            }
        }

        public decimal Weightage
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.Weightage : new decimal();
            }
            set
            {
                StatusMasterDTO.Weightage = value;
            }
        }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.IsDeleted : false;
            }
            set
            {
                StatusMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.CreatedBy > 0) ? StatusMasterDTO.CreatedBy : new int();
            }
            set
            {
                StatusMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                StatusMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.ModifiedBy > 0) ? StatusMasterDTO.ModifiedBy : new int();
            }
            set
            {
                StatusMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.ModifiedDate.HasValue) ? StatusMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                StatusMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.DeletedBy > 0) ? StatusMasterDTO.DeletedBy : new int();
            }
            set
            {
                StatusMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.DeletedDate.HasValue) ? StatusMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                StatusMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                StatusMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.LastSyncDate.HasValue) ? StatusMasterDTO.LastSyncDate : null;
            }
            set
            {
                StatusMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.SyncType : string.Empty;
            }
            set
            {
                StatusMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.Entity : string.Empty;
            }
            set
            {
                StatusMasterDTO.Entity = value;
            }
        }
        
        public int BrokenStatusReasonID
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.BrokenStatusReasonID > 0) ? StatusMasterDTO.BrokenStatusReasonID : new int();
            }
            set
            {
                StatusMasterDTO.BrokenStatusReasonID = value;
            }
        }

        public string BrokenReasonCode
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.BrokenReasonCode : string.Empty;
            }
            set
            {
                StatusMasterDTO.BrokenReasonCode = value;
            }
        }

        public string Reason
        {
            get
            {
                return (StatusMasterDTO != null) ? StatusMasterDTO.Reason : string.Empty;
            }
            set
            {
                StatusMasterDTO.Reason = value;
            }
        }

        public Int16 Flag
        {
            get
            {
                return (StatusMasterDTO != null && StatusMasterDTO.Flag > 0) ? StatusMasterDTO.Flag : new Int16();
            }
            set
            {
                StatusMasterDTO.Flag = value;
            }
        }

    }
}
