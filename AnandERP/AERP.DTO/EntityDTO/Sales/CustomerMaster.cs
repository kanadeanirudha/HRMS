using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class CustomerMaster : BaseDTO
    {
        //**********CustomerMaster**********//
        public Int32 CustomerMasterID
        {
            get;
            set;
        }
        public Int32 CustomerContactDetailsID
        {
            get;
            set;
        }
        public string CustomerMasterName
        {
            get; set;
        }
        public string CompanyName
        {
            get;
            set;
        }
        public string CompanyTypeName
        {
            get;
            set;
        }
        public byte CustomerType
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string CustomerAddress
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }
        public string Address3
        {
            get;
            set;
        }
        public string CityID
        {
            get;
            set;
        }
        public string StateID
        {
            get;
            set;
        }
        public string CountryID
        {
            get;
            set;
        }
        public string SelectedCountryID
        {
            get;
            set;
        }

        public string MobileNumber
        {
            get;
            set;
        }
        public Int16 Currency
        {
            get;
            set;
        }
        public string CreditPeriod
        {
            get;
            set;
        }
        public string UnitMasterId
        {
            get;
            set;
        }
        public string GSTNumber
        {
            get;
            set;
        }
        public string Code
        {
            get;
            set;
        }
        public bool IsTaxExempted
        {
            get;
            set;
        }
        public byte ReasonForExemption
        {
            get;
            set;
        }
        public string TaxExemptionRemark
        {
            get; set;
        }
        public bool IsCentre
        {
            get; set;
        }
        public string CentreCode
        {
            get; set;
        }
        public string BankName
        {
            get;
            set;
        }
        public string IFCICODE
        {
            get;
            set;
        }
        public string BankAccountNumber
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }

        //**********CustomerBranchMaster**********//
        public int CustomerBranchMasterID
        {
            get;
            set;
        }
        public bool IsMainBranch
        {
            get;
            set;
        }
        public byte PeriodUnitID
        {
            get;
            set;
        }
        public string CustomerBranchMasterName
        {
            get;
            set;
        }
        //**********CustomerContactDetails**********//
        public string CustomerContactFirstName
        {
            get;
            set;
        }
        public string CustomerContactMiddleName
        {
            get;
            set;
        }
        public string CustomerContactLastName
        {
            get;
            set;
        }
        public string CustomerContactEmailID
        {
            get;
            set;
        }
        public string CustomerContactDesignation
        {
            get;
            set;
        }
        public bool IsPrimaryContact
        {
            get;
            set;
        }
        public string CustomerContactMobileNumber
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
        public bool IsDeleted
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string XmlString { get; set; }
        public string CustomerContactPersonName { get; set; }
        public decimal CreditAmount { get; set; }

        public string ShortCode { get; set; }
        public bool IsBillToSameAsShipTo { get; set; }
        public string CustomerBranchCode { get; set; }
        public string PinCode
        {
            get;
            set;
        }

    }
}

