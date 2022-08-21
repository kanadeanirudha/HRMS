using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class AccountVoucherSettingMasterReport : BaseDTO
    {
        public int ID { get; set; }
        public int AccSessionID { get; set; }
        public string TransactionType { get; set; }
        public string SessionName { get; set; }
        public string TransactionTypeCode { get; set; }
        public int VoucherNumber { get; set; }
        public bool IsActive { get; set; }
      
    }
}
