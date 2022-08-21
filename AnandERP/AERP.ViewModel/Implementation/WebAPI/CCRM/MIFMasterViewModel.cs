using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class MIFMasterViewModel
    {
        public MIFMasterViewModel()
        {
            MIFMasterDTO = new MIFMaster();
        }
        public MIFMaster MIFMasterDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (MIFMasterDTO != null && MIFMasterDTO.ID > 0) ? MIFMasterDTO.ID : new Int32();
            }
            set
            {
                MIFMasterDTO.ID = value;
            }
        }
        public Int32 MIFNumber
        {
            get
            {
                return (MIFMasterDTO != null && MIFMasterDTO.MIFNumber > 0) ? MIFMasterDTO.MIFNumber : new Int32();
            }
            set
            {
                MIFMasterDTO.MIFNumber = value;
            }
        }
        public string SerialNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.SerialNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.SerialNumber = value;
            }
        }
        public string CustomerName
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.CustomerName : string.Empty;
            }
            set
            {
                MIFMasterDTO.CustomerName = value;
            }
        }
        public string InstallationAddress
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.InstallationAddress : string.Empty;
            }
            set
            {
                MIFMasterDTO.InstallationAddress = value;
            }
        }
        public string ContractType
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.ContractType : string.Empty;
            }
            set
            {
                MIFMasterDTO.ContractType = value;
            }
        }
        public string ContractNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.ContractNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.ContractNumber = value;
            }
        }
        public string KeyOperator
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.KeyOperator : string.Empty;
            }
            set
            {
                MIFMasterDTO.KeyOperator = value;
            }
        }
        public string ModelNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.ModelNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.ModelNumber = value;
            }
        }
        public string EngineerName
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.EngineerName : string.Empty;
            }
            set
            {
                MIFMasterDTO.EngineerName = value;
            }
        }
        public string PhoneNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.PhoneNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.PhoneNumber = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.MobileNumber = value;
            }
        }
        public string EngineerContactNumber
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.EngineerContactNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.EngineerContactNumber = value;
            }
        }
        public string VersionNumber
        {

            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                MIFMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (MIFMasterDTO != null && MIFMasterDTO.LastSyncDate.HasValue) ? MIFMasterDTO.LastSyncDate : null;
            }
            set
            {
                MIFMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.SyncType : string.Empty;
            }
            set
            {
                MIFMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (MIFMasterDTO != null) ? MIFMasterDTO.Entity : string.Empty;
            }
            set
            {
                MIFMasterDTO.Entity = value;
            }
        }
    }
}
