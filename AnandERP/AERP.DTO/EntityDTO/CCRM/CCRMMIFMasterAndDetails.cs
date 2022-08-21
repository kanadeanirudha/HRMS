using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
   public class CCRMMIFMasterAndDetails :BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        
        public Int32 CCRMMIFCallOperatorDetailsID
        {
            get;
            set;
        }
        public Int32 CCRMMIFMasterID
        {
            get;
            set;
        }

        public int MIFMasterID
        {
            get;
            set;
        }
        public string CustomerCode
        {
            get; set;
        }
        public string InstallationDate
        {
            get; set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public string CustomerAddress
        {
            get; set;
        }
        public string CustomerPinCode
        {
            get; set;
        }

        public byte CutomerSegementMasterID
        {
            get; set;
        }
        public string MIFTitle
        {
            get; set;
        }
        public string MIFAddress
        {
            get; set;
        }
        public string MIFPinCode
        {
            get; set;
        }
        public string FolioNo
        {
            get; set;
        }
        public string BillTitle
        {
            get; set;
        }
        public string BillAddress
        {
            get; set;
        }
        public string ModelNo
        {
            get; set;
        }
        public string SerialNo
        {
            get; set;
        }
        public byte MIFType
        {
            get; set;
        }
        public Int16 MachineFamilyID
        {
            get; set;
        }
        public Int16 CountryID
        {
            get; set;
        }
        public Int16 StateID
        {
            get; set;
        }
        public Int16 CityID
        {
            get; set;
        }
        public string AreaPatchName
        {
            get; set;
        }
        public string Group
        {
            get; set;
        }
        public Int32 CCRMLocationTypeID
        {
            get; set;
        }
        public byte Priority
        {
            get; set;
        }
        public string KeyOperator
        {
            get; set;
        }
        public string Phone
        {
            get; set;
        }
        public string PhoneNo
        {
            get; set;
        }
        public string MobileNumber
        {
            get; set;
        }
        public string MobileNo
        {
            get; set;
        }
        public Int32 CustomerContactDetailsID
        {
            get;
            set;
        }
        public string EmailCorporate
        {
            get; set;
        }
        public string EmailAccounts
        {
            get; set;
        }
        public string Emailservices
        {
            get; set;
        }
        public string InstalledBy
        {
            get; set;
        }
        public Int32 ServiceEngID
        {
            get; set;
        }
        public Int32 CollExecId
        {
            get; set;
        }
        public byte ISPrinter
        {
            get; set;
        }
        public byte ISScanner
        {
            get; set;
        }
        public byte ISFax
        {
            get; set;
        }
        public string Others
        {
            get; set;
        }
        public Int32 WarantyInDays
        {
            get; set;
        }
        public string WarantyExpiryDate
        {
            get; set;
        }
        public string InactiveDate
        {
            get; set;
        }
        public byte Status
        {
            get; set;
        }
        public string Remarks
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
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XmlString { get; set; }
        public int ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public Int16 CCRMAreaPatchMasterID
        {
            get;
            set;
        }
        public Int32 CCRMEngineersGroupMasterID
        {
            get;
            set;
        }
        public Int32 InstalledById
        {
            get;
            set;
        }
        public string SelectedContactDetailsIDs
        {
            get;
            set;
        }
        public string CustomerContactPersonName
        {
            get;
            set;
        }

        public string KeyOperatorName
        {
            get; set;
        }
        public byte CustomerType
        {
            get; set;
        }
        public byte ColorMono
        {
            get; set;
        }
        public string PaperSize
        {
            get; set;
        }
        public Int32 ContractTypeId
        {
            get;
            set;
        }
        public string ContractNo
        {
            get; set;
        }
        public string ContractName
        {
            get; set;
        }
        public string ContractOpDate
        {
            get; set;
        }
        public string ContractClosingDate
        {
            get; set;
        }
        public string EmailServices
        {
            get; set;
        }
        public string CallerName
        {
            get; set;
        }
        public Int32 MifID
        {
            get;
            set;
        }
        public decimal CallCharges { get; set; }
        public string CentreCode
        {
            get; set;
        }
        public Int32 AdminRoleMasterID
        {
            get;
            set;
        }
        public string RightName
        {
            get; set;
        }
        public Int32 EmployeeID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get; set;
        }
        public string EmployeeFirstName
        {
            get; set;
        }
        public string EmployeeMiddleName
        {
            get; set;
        }
        public string EmployeeLastName
        {
            get; set;
        }
       
        public string EmployeeName { get; set; }
        public string ContractCode { get; set; }
        public string CallTktNo { get; set; }
        public string CallDate { get; set; }
        public string MachineFamilyName { get; set; }
        public byte Category { get; set; }

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
