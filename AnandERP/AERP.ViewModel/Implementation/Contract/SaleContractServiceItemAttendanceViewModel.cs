using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class SaleContractServiceItemAttendanceViewModel : ISaleContractServiceItemAttendanceViewModel
    {

        public SaleContractServiceItemAttendanceViewModel()
        {
            SaleContractServiceItemAttendanceDTO = new SaleContractServiceItemAttendance();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListSaleContractServiceItemAttendance = new List<SaleContractServiceItemAttendance>();
            ListSaleContractBillingSpan = new List<SaleContractAttendance>();
        }
        
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public List<SaleContractServiceItemAttendance> ListSaleContractServiceItemAttendance
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

        public SaleContractServiceItemAttendance SaleContractServiceItemAttendanceDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.ID > 0) ? SaleContractServiceItemAttendanceDTO.ID : new int();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ID = value;
            }
        }

        [Display(Name = "Machine Name")]
        [Required(ErrorMessage = "Machine Name Required")]
        public string Name
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.Name : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.Name = value;
            }
        }

        [Display(Name = "Item Description")]
        [Required(ErrorMessage = "Item Description Required")]
        public Int32 ItemNumber
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.ItemNumber > 0) ? SaleContractServiceItemAttendanceDTO.ItemNumber : new Int32();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ItemNumber = value;
            }
        }

        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.ItemDescription : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ItemDescription = value;
            }
        }

        [Display(Name = "Serial Number Code")]
        [Required(ErrorMessage = "Serial Number Required")]
        public string SerialNumber
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.SerialNumber : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.SerialNumber = value;
            }
        }
        [Display(Name = "Purchase Date")]
        public string PurchaseDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.PurchaseDate : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.PurchaseDate = value;
            }
        }
        [Display(Name = "Next Maintance Date")]
        public string NextMaintanceDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.NextMaintanceDate : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.NextMaintanceDate = value;
            }
        }
        [Display(Name = "Centre Name")]
        [Required(ErrorMessage = "Centre Name Required")]
        public string CentreCode
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.CentreCode : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.CentreCode = value;
            }
        }
        [Display(Name = "Centre Name")]
        public string SelectedCentreCode
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.SelectedCentreCode = value;
            }
        }
        [Display(Name = "Is Enguage")]
        public bool IsEnguage
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.IsEnguage : false;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.IsEnguage = value;
            }
        }
        [Display(Name = "Customer")]
        public Int32 CustomerID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.CustomerID > 0) ? SaleContractServiceItemAttendanceDTO.CustomerID : new Int32();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.CustomerID = value;
            }
        }
        [Display(Name = "Location")]
        public Int32 LocationID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.LocationID > 0) ? SaleContractServiceItemAttendanceDTO.LocationID : new Int32();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.LocationID = value;
            }
        }
        [Display(Name = "Customer")]
        public string CustomerName
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.CustomerName : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.CustomerName = value;
            }
        }
        [Display(Name = "Location")]
        public string LocationName
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.LocationName : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.LocationName = value;
            }
        }
        [Display(Name = "Machine Type")]
        public byte MachineType
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.MachineType > 0) ? SaleContractServiceItemAttendanceDTO.MachineType : new byte();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.MachineType = value;
            }
        }
        [Display(Name = "Machine Use For")]
        public string MachineUseFor
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.MachineUseFor : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.MachineUseFor = value;
            }
        }
        [Display(Name = "Model Number")]
        public string ModelNumber
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.ModelNumber : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ModelNumber = value;
            }
        }
        [Display(Name = "Make By")]
        public string MakeBy
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.MakeBy : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.MakeBy = value;
            }
        }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.IsDeleted : false;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.CreatedBy > 0) ? SaleContractServiceItemAttendanceDTO.CreatedBy : new int();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.ModifiedBy > 0) ? SaleContractServiceItemAttendanceDTO.ModifiedBy : new int();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.ModifiedDate.HasValue) ? SaleContractServiceItemAttendanceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.DeletedBy > 0) ? SaleContractServiceItemAttendanceDTO.DeletedBy : new int();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.DeletedDate.HasValue) ? SaleContractServiceItemAttendanceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "Contract Number")]
        public string ContractNumber
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.ContractNumber : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.ContractNumber = value;
            }
        }
        [Display(Name = "Span")]
        public Int64 SaleContractBillingSpanID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.SaleContractBillingSpanID > 0) ? SaleContractServiceItemAttendanceDTO.SaleContractBillingSpanID : new Int64();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.SaleContractBillingSpanID = value;
            }
        }
        [Display(Name = "Contract Master")]
        public Int64 SaleContractMasterID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.SaleContractMasterID > 0) ? SaleContractServiceItemAttendanceDTO.SaleContractMasterID : new Int64();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.SaleContractMasterID = value;
            }
        }
        [Display(Name = "Removal Date")]
        public string MachineAssignUptoDate
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null) ? SaleContractServiceItemAttendanceDTO.MachineAssignUptoDate : string.Empty;
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.MachineAssignUptoDate = value;
            }
        }
        [Display(Name = "Machine Assign")]
        public Int64 SaleContractMachineAssignID
        {
            get
            {
                return (SaleContractServiceItemAttendanceDTO != null && SaleContractServiceItemAttendanceDTO.SaleContractMachineAssignID > 0) ? SaleContractServiceItemAttendanceDTO.SaleContractMachineAssignID : new Int64();
            }
            set
            {
                SaleContractServiceItemAttendanceDTO.SaleContractMachineAssignID = value;
            }
        }
        public string XMLstringForAttendance { get; set; }
    }
}

