using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountFeeCentreWorkingDate : BaseDTO
    {
        public int ID { get; set; }
        public Nullable<int> AccBalsheetMstID { get; set; }
        public Nullable<System.DateTime> FeesWorkingDatetime { get; set; }
        public Nullable<System.DateTime> AccWorkingDatetime { get; set; }
        public Nullable<int> AccSessionID { get; set; }
        public string FeeOutCarryForward { get; set; }
        public string FeeOutBroughtForward { get; set; }
        public string AccOutCarryForward { get; set; }
        public string AccOutBroughtForward { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
