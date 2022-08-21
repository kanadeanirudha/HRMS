using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
   public class CCRMSymptomMaster : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        
        public string SymptomTypeTitle
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }

        public string SymptomTypeCode
        {
            get;
            set;
        }
        public string SymptomTypeDescription
        {
            get; set;
        }
        public Int32 CCRMSymptomMasterID { get; set; }
        public string SymptomTitle { get; set; }
        public string SymptomCode { get; set; }
        public string SymptomDescription { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string errorMessage { get; set; }
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
