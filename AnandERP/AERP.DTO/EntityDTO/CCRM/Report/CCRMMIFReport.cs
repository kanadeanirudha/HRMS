using AERP.Base.DTO;
using System;


namespace AERP.DTO
{
   public class CCRMMIFReport :BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public string InstallationDate
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
        public string ModelNo
        {
            get; set;
        }
        public string SerialNo
        {
            get; set;
        }
        public Int16 MachineFamilyID
        {
            get; set;
        }
        public string AreaPatchName
        {
            get; set;
        }
        public Int32 CCRMLocationTypeID
        {
            get; set;
        }
        public string InstalledBy
        {
            get; set;
        }
        public string WarantyExpiryDate
        {
            get; set;
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
        public string GroupName
        {
            get; set;
        }
        public string LocationTypeCode
        {
            get; set;
        }
        public string MachineFamilyName
        {
            get; set;
        }
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
        public string EmployeeName
        {
            get; set;
        }
        public string ItemDescription
        {
            get; set;
        }
        public string Status
        {
            get; set;
        }
        public bool IsPosted
        {
            get; set;
        }
        public string ContractType
        {
            get; set;
        }
        public Int32 ContractTypeId
        {
            get;
            set;
        }
        public string ContractCode
        {
            get; set;
        }
        public string EnggName
        {
            get; set;
        }
        public Int32 EngineerID
        {
            get;
            set;
        }
        public string Category
        {
            get; set;
        }
        public string PhoneNo
        {
            get; set;
        }
        public string MobileNo
        {
            get; set;
        }
        public byte Priority
        {
            get; set;
        }
        public string ContractNo
        {
            get; set;
        }
    }
}
