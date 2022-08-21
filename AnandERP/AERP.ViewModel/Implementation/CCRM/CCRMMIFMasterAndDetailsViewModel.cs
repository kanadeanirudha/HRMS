using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
   public class CCRMMIFMasterAndDetailsViewModel :ICCRMMIFMasterAndDetailsViewModel
    {
        public CCRMMIFMasterAndDetailsViewModel()
        {
            CCRMMIFMasterAndDetailsDTO = new CCRMMIFMasterAndDetails();
            KeyOperatorByCCRMMIFMasterAndDetailsID = new List<CCRMMIFMasterAndDetails>();
        }
        public List<CCRMMIFMasterAndDetails> KeyOperatorByCCRMMIFMasterAndDetailsID { get; set; }
        public CCRMMIFMasterAndDetails CCRMMIFMasterAndDetailsDTO
        {
            get;
            set;
        }
        public Int32 ID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.ID > 0) ? CCRMMIFMasterAndDetailsDTO.ID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ID = value;
            }
        }
        public Int32 CustomerMasterID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.CustomerMasterID > 0) ? CCRMMIFMasterAndDetailsDTO.CustomerMasterID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerMasterID = value;
            }
        }
        public Int32 CustomerContactDetailsID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.CustomerContactDetailsID > 0) ? CCRMMIFMasterAndDetailsDTO.CustomerContactDetailsID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerContactDetailsID = value;
            }
        }
        public int MIFMasterID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.MIFMasterID > 0) ? CCRMMIFMasterAndDetailsDTO.MIFMasterID : new int();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MIFMasterID = value;
            }
        }
        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Customer Name  should not be blank.")]
        public string CustomerMasterName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Customer Code")]
        public string CustomerCode
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CustomerCode : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerCode = value;
            }
        }
        [Display(Name = " Address")]
        public string CustomerAddress
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CustomerAddress : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerAddress = value;
            }
        }
        [Display(Name = "PinCode")]
        public string CustomerPinCode
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CustomerPinCode : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerPinCode = value;
            }
        }
        [Display(Name = "Segment")]
        [Required(ErrorMessage = "Segment should not be blank.")]
        public byte CutomerSegementMasterID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CutomerSegementMasterID :new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CutomerSegementMasterID = value;
            }
        }
        [Display(Name = "MIFTitle")]
      //  [Required(ErrorMessage = "MIF Title  Required")]
        public string MIFTitle
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MIFTitle : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MIFTitle = value;
            }
        }
        [Display(Name = "MIFAddress")]
        [Required(ErrorMessage = "MIF Address  Required")]
        public string MIFAddress
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MIFAddress : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MIFAddress = value;
            }
        }
        [Display(Name = "PinCode")]
        public string MIFPinCode
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MIFPinCode : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MIFPinCode = value;
            }
        }
        [Display(Name = "Folio No")]
        public string FolioNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.FolioNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.FolioNo = value;
            }
        }
        [Display(Name = "Bill Title")]
        [Required(ErrorMessage = "Bill Title")]
        public string BillTitle
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.BillTitle : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.BillTitle = value;
            }
        }
        [Display(Name = "Address")]
       // [Required(ErrorMessage = "Address")]
        public string BillAddress
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.BillAddress : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.BillAddress = value;
            }
        }
        [Display(Name = "Model No")]
        [Required(ErrorMessage = "Model No Required")]
        public string ModelNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ModelNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ModelNo = value;
            }
        }
        [Display(Name = "M/C Serial Number")]
        [Required(ErrorMessage = "SerialNo.  Required")]
        public string SerialNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.SerialNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.SerialNo = value;
            }
        }
        [Display(Name = "MIF Type")]
        public byte MIFType
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MIFType : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MIFType = value;
            }
        }
        [Display(Name = "Machine Family")]
        public Int16 MachineFamilyID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MachineFamilyID :new Int16();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MachineFamilyID = value;
            }
        }
        [Display(Name = "Country")]
        public Int16 CountryID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CountryID : new Int16();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CountryID = value;
            }
        }
        [Display(Name = "State")]
        public Int16 StateID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.StateID : new Int16();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.StateID = value;
            }
        }
        [Display(Name = "City")]
        public Int16 CityID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CityID : new Int16();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CityID = value;
            }
        }
       
      
        public string Group
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Group : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Group = value;
            }
        }
        [Display(Name = "LocationType")]
        public Int32 CCRMLocationTypeID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CCRMLocationTypeID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CCRMLocationTypeID = value;
            }
        }
        [Display(Name = "Priority")]
        public byte Priority
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Priority :new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Priority = value;
            }
        }
        [Display(Name = "Installation Date")]
        public string InstallationDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.InstallationDate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.InstallationDate = value;
            }
        }
        [Display(Name = "Key Operator")]
        public string KeyOperator
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.KeyOperator : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.KeyOperator = value;
            }
        }
        [Display(Name = "Phone No.")]
        public string Phone
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Phone : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Phone = value;
            }
        }
        public string PhoneNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.PhoneNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.PhoneNo = value;
            }
        }
        public string MobileNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MobileNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MobileNo = value;
            }
        }
      
        public string MobileNumber
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.MobileNumber : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.MobileNumber = value;
            }
        }
        [Display(Name = "Email (Corporate)")]
        public string EmailCorporate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.EmailCorporate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.EmailCorporate = value;
            }
        }
        [Display(Name = "Email (Accounts)")]
        public string EmailAccounts
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.EmailAccounts : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.EmailAccounts = value;
            }
        }
        [Display(Name = "Email (services)")]
        public string Emailservices
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Emailservices : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Emailservices = value;
            }
        }
        [Display(Name = "Installed By")]
        public Int32 InstalledById
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.InstalledById :new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.InstalledById = value;
            }
        }
        [Display(Name = "ServiceEngg")]
        public Int32 ServiceEngID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ServiceEngID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ServiceEngID = value;
            }
        }
        [Display(Name = "Collection Executive")]
        public Int32 CollExecId
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CollExecId : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CollExecId = value;
            }
        }
        [Display(Name = "Printer")]
        public byte ISPrinter
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ISPrinter : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ISPrinter = value;
            }
        }
        [Display(Name = "Scanner")]
        public byte ISScanner
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ISScanner : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ISScanner = value;
            }
        }
        [Display(Name = "Fax")]
        public byte ISFax
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ISFax : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ISFax = value;
            }
        }
        [Display(Name = "Others")]
        public string Others
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Others : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Others = value;
            }
        }
        [Display(Name = "War In days")]
        public Int32 WarantyInDays
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.WarantyInDays : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.WarantyInDays = value;
            }
        }
        [Display(Name = "War Exp Date")]
        public string WarantyExpiryDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.WarantyExpiryDate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.WarantyExpiryDate = value;
            }
        }
        [Display(Name = "In Active Date")]
        public string InactiveDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.InactiveDate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.InactiveDate = value;
            }
        }
        [Display(Name = "Status")]
        public byte Status
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Status : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Status = value;
            }
        }
        [Display(Name = "Remarks")]
        public string Remarks
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Remarks : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Remarks = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.IsDeleted : false;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.IsDeleted = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.CreatedBy > 0) ? CCRMMIFMasterAndDetailsDTO.CreatedBy : new int();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CreatedDate = value;
            }
        }

        public int ModifiedBy
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.ModifiedBy > 0) ? CCRMMIFMasterAndDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ModifiedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

        public string XmlString
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.XmlString : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.XmlString = value;
            }
        }
        public string ItemDescription
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ItemDescription = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ItemNumber : new int();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ItemNumber = value;
            }
        }
        public string AreaPatchName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.AreaPatchName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.AreaPatchName = value;
            }
        }
        public Int16 CCRMAreaPatchMasterID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CCRMAreaPatchMasterID :new Int16();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CCRMAreaPatchMasterID = value;
            }
        }
        [Display(Name = " Group ")]
        public Int32 CCRMEngineersGroupMasterID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CCRMEngineersGroupMasterID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CCRMEngineersGroupMasterID = value;
            }
        }
        public string SelectedContactDetailsIDs
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.SelectedContactDetailsIDs : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.SelectedContactDetailsIDs = value;
            }
        }
        public string CustomerContactPersonName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CustomerContactPersonName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CustomerContactPersonName = value;
            }
        }
        public Int32 CCRMMIFCallOperatorDetailsID
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.CCRMMIFCallOperatorDetailsID > 0) ? CCRMMIFMasterAndDetailsDTO.CCRMMIFCallOperatorDetailsID : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CCRMMIFCallOperatorDetailsID = value;
            }
        }
        public string KeyOperatorName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.KeyOperatorName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.KeyOperatorName = value;
            }
        }
        public Int32 ContractTypeId
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ContractTypeId : new Int32();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ContractTypeId = value;
            }
        }
        public string ContractNo
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ContractNo : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ContractNo = value;
            }
        }
        public string ContractName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ContractName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ContractName = value;
            }
        }
        public string ContractOpDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ContractOpDate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ContractOpDate = value;
            }
        }
        public string ContractClosingDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.ContractClosingDate : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.ContractClosingDate = value;
            }
        }
      
        public string CallerName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CallerName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CallerName = value;
            }
        }
        public decimal CallCharges
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.CallCharges : new decimal();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.CallCharges = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.EmployeeName : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.EmployeeName = value;
            }
        }
        public byte Category
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Category : new byte();
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Category = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null && CCRMMIFMasterAndDetailsDTO.LastSyncDate.HasValue) ? CCRMMIFMasterAndDetailsDTO.LastSyncDate : null;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.SyncType : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.SyncType = value;
            }
        }
        public string VersionNumber
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.VersionNumber : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.VersionNumber = value;
            }
        }

        public string Entity
        {
            get
            {
                return (CCRMMIFMasterAndDetailsDTO != null) ? CCRMMIFMasterAndDetailsDTO.Entity : string.Empty;
            }
            set
            {
                CCRMMIFMasterAndDetailsDTO.Entity = value;
            }
        }
    }
}
