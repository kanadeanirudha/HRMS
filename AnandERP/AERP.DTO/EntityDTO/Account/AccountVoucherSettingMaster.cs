using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountVoucherSettingMaster : BaseDTO
    {
        public int ID { get; set; }
        public Nullable<int> AccSessionID { get; set; }
        public string AccSessionName { get; set; }
        public string AccBalsheetMstName { get; set; }
        public string TransactionType { get; set; }
        public string TransactionTypeCode { get; set; }
        public Nullable<int> VoucherNumber { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> AccBalsheetMstID { get; set; }
        public string errorMessage { get; set; }
    }
}
