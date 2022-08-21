using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class MachineTransactionReport : BaseDTO
    {
        public Int64 ID
        {
            get;
            set;
        }
        public string MachineMasterName
        {
            get;set;
        }
        public Int32 MachineMasterID
        {
            get; set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }

        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public string CustomerMasterName { get; set; }
        public string PurchaseDate { get; set; }
    }
}
