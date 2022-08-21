using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DTO
{
    public class AccountIndividualOpeningBalance: BaseDTO
    {
        public int ID { get; set; }
        public Nullable<int> AccSessionID { get; set; }
        public Nullable<int> AccountID { get; set; }
        public string PersonType { get; set; }
        public Nullable<int> PersonID { get; set; }
        public Nullable<System.DateTime> OpeningDatetime { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        public Nullable<decimal> TotalDebitAmount { get; set; }
        public Nullable<decimal> TotalCreditAmount { get; set; }
        public Nullable<decimal> ClosingBalance { get; set; }
        public string CarryForward { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> AccBalsheetMstID { get; set; }
    }
}
