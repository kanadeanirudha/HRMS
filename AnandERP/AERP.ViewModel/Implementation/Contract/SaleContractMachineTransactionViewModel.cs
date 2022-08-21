using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractMachineTransactionViewModel : ISaleContractMachineTransactionViewModel
    {

        public SaleContractMachineTransactionViewModel()
        {
            SaleContractMachineTransactionDTO = new SaleContractMachineTransaction();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListSaleContractMachineTransaction = new List<SaleContractMachineTransaction>();
            ListSaleContractBillingSpan = new List<SaleContractAttendance>();
            SaleContractMasterListForMachineMaster = new List<SaleContractMaster>();
        }
        
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public List<SaleContractMaster> SaleContractMasterListForMachineMaster
        {
            get;
            set;
        }
        public List<SaleContractMachineTransaction> ListSaleContractMachineTransaction
        {
            get;
            set;
        }
        public List<SaleContractAttendance> ListSaleContractBillingSpan
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetContractSpans
        {
            get
            {
                return new SelectList(ListSaleContractBillingSpan, "SaleContractBillingSpanID", "SaleContractBillingSpanName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public SaleContractMachineTransaction SaleContractMachineTransactionDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.ID > 0) ? SaleContractMachineTransactionDTO.ID : new int();
            }
            set
            {
                SaleContractMachineTransactionDTO.ID = value;
            }
        }

        [Display(Name = "Machine Name")]
        [Required(ErrorMessage = "Machine Name Required")]
        public string Name
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.Name : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.Name = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.ItemNumber > 0) ? SaleContractMachineTransactionDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractMachineTransactionDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Serial Number Code")]
        [Required(ErrorMessage = "Serial Number Required")]
        public string SerialNumber
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.SerialNumber : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.SerialNumber = value;
            }
        }
        [Display(Name = "Purchase Date")]
        public string PurchaseDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.PurchaseDate : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.PurchaseDate = value;
            }
        }
        [Display(Name = "Next Maintance Date")]
        public string NextMaintanceDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.NextMaintanceDate : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.NextMaintanceDate = value;
            }
        }
        [Display(Name = "Centre Name")]
        [Required(ErrorMessage = "Centre Name Required")]
        public string CentreCode
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "Is Enguage")]
        public bool IsEnguage
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.IsEnguage : false;
            }
            set
            {
                SaleContractMachineTransactionDTO.IsEnguage = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.CustomerID > 0) ? SaleContractMachineTransactionDTO.CustomerID : new Int32();
            }
            set
            {
                SaleContractMachineTransactionDTO.CustomerID = value;
            }
        }
        [Display(Name = "Location")]
        public Int32 LocationID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.LocationID > 0) ? SaleContractMachineTransactionDTO.LocationID : new Int32();
            }
            set
            {
                SaleContractMachineTransactionDTO.LocationID = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerName
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.CustomerName : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.CustomerName = value;
            }
        }
        [Display(Name = "Location")]
        public string LocationName
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.LocationName : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.LocationName = value;
            }
        }
        [Display(Name = "Machine Type")]
        public byte MachineType
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.MachineType > 0) ? SaleContractMachineTransactionDTO.MachineType : new byte();
            }
            set
            {
                SaleContractMachineTransactionDTO.MachineType = value;
            }
        }
        [Display(Name = "Machine Use For")]
        public string MachineUseFor
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.MachineUseFor : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.MachineUseFor = value;
            }
        }
        [Display(Name = "Model Number")]
        public string ModelNumber
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.ModelNumber : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.ModelNumber = value;
            }
        }
        [Display(Name = "Make By")]
        public string MakeBy
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.MakeBy : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.MakeBy = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.IsDeleted : false;
            }
            set
            {
                SaleContractMachineTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.CreatedBy > 0) ? SaleContractMachineTransactionDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractMachineTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.ModifiedBy > 0) ? SaleContractMachineTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractMachineTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.ModifiedDate.HasValue) ? SaleContractMachineTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.DeletedBy > 0) ? SaleContractMachineTransactionDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractMachineTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.DeletedDate.HasValue) ? SaleContractMachineTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractMachineTransactionDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.SaleContractBillingSpanID > 0) ? SaleContractMachineTransactionDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Contract Master")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.SaleContractMasterID > 0) ? SaleContractMachineTransactionDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Removal Date")]
        public string MachineAssignUptoDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.MachineAssignUptoDate : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.MachineAssignUptoDate = value;
            }
        }
        [Display(Name = "Machine Assign")]
        public Int64 SaleContractMachineAssignID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.SaleContractMachineAssignID > 0) ? SaleContractMachineTransactionDTO.SaleContractMachineAssignID : new Int64();
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMachineAssignID = value;
            }
        }
        public string XMLstringForAttendance { get; set; }
        [Display(Name = "Machine Name")]
        public Int16 SaleContractMachineMasterID
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null && SaleContractMachineTransactionDTO.SaleContractMachineMasterID > 0) ? SaleContractMachineTransactionDTO.SaleContractMachineMasterID : new Int16();
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMachineMasterID = value;
            }
        }
        [Display(Name = "Machine Name")]
        public string SaleContractMachineMasterName
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.SaleContractMachineMasterName : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMachineMasterName = value;
            }
        }
        [Display(Name = "Serial Number")]
        public string SaleContractMachineMasterSerialNumber
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.SaleContractMachineMasterSerialNumber : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMachineMasterSerialNumber = value;
            }
        }
        [Display(Name = "Machine Rate")]
        public decimal SaleContractMachineMasterRate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.SaleContractMachineMasterRate : new decimal();
            }
            set
            {
                SaleContractMachineTransactionDTO.SaleContractMachineMasterRate = value;
            }
        }
        [Display(Name = "Assign From")]
        public string MachineAssignFromDate
        {
            get
            {
                return (SaleContractMachineTransactionDTO != null) ? SaleContractMachineTransactionDTO.MachineAssignFromDate : string.Empty;
            }
            set
            {
                SaleContractMachineTransactionDTO.MachineAssignFromDate = value;
            }
        }
        
    }
}

