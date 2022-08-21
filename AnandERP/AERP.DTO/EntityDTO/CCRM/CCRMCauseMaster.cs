using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
   public class CCRMCauseMaster :BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }

        public string CauseTypeTitle
        {
            get;
            set;
        }

        public string CauseTypeCode
        {
            get;
            set;
        }
        public string CauseTypeDescription
        {
            get; set;
        }
        public Int32 CCRMCauseMasterID { get; set; }
        public string CauseTitle { get; set; }
        public string CauseCode { get; set; }
        public string CauseDescription { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public string VersionNumber
        {
            get;
            set;
        }
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
