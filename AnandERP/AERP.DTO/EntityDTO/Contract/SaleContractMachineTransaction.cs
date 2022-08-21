using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class SaleContractMachineTransaction : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Int32 ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get; set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public string PurchaseDate
        {
            get;
            set;
        }

        public string NextMaintanceDate
        {
            get;
            set;
        }
        public string MachineUseFor
        {
            get;
            set;
        }
        public string ModelNumber
        {
            get;
            set;
        }
        public string MakeBy
        {
            get;
            set;
        }
        public byte MachineType
        {
            get; set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get; set;
        }
        public string CentreName
        {
            get;
            set;
        }

        public bool IsEnguage
        {
            get; set;
        }
        public Int32 CustomerID
        {
            get; set;
        }
        public string CustomerName
        {
            get; set;
        }
        public Int32 LocationID
        {
            get; set;
        }
        public string LocationName
        {
            get; set;
        }

        public bool IsActive
        {
            get;
            set;
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
        public string ContractNumber { get; set; }
        public Int64 SaleContractBillingSpanID { get; set; }
        public Int64 SaleContractMasterID { get; set; }
        public string MachineAssignFromDate { get; set; }
        public string MachineAssignUptoDate { get; set; }
        public Int64 SaleContractRequirementDetailsID { get; set; }
        public Int64 SaleContractMachineAssignID { get; set; }
        public Int64 SaleContractMachineAttendanceID { get; set; }
        public byte TotalDays { get; set; }
        public decimal TotalAttendance { get; set; }
        public string XMLstringForAttendance { get; set; }
        public Int16 SaleContractMachineMasterID { get; set; }
        public string SaleContractMachineMasterName { get; set; }
        public string SaleContractMachineMasterSerialNumber { get; set; }
        public decimal SaleContractMachineMasterRate { get; set; }
    }
}
