using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountTransactionTypeMaster : BaseDTO
    {
        public int ID { get; set; }
        public int AccBalsheetMstID { get; set; }
        public int AccountTransactionTypeMasterID { get; set; }
        public string TransactionTypeCode { get; set; }
        public string TransactionTypeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public string errorMessage { get; set; }

    }
}
