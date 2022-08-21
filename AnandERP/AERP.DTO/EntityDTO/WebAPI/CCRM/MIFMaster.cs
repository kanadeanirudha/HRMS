using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class MIFMaster : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public Int32 MIFNumber
        {
            get;
            set;
        }
        public string SerialNumber
        {
            get; set;
        }
        public string CustomerName
        {
            get; set;
        }
        public string InstallationAddress
        {
            get; set;
        }
        public string ContractType
        {
            get; set;
        }
        public string ContractNumber
        {
            get; set;
        }
        public string KeyOperator
        {
            get; set;
        }
        public string ModelNumber
        {
            get; set;
        }
        public string EngineerName
        {
            get; set;
        }
        public string PhoneNumber
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }
        public string EngineerContactNumber
        {
            get; set;
        }
        public string VersionNumber { get; set; }
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
