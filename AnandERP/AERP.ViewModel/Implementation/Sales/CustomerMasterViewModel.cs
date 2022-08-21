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
    public class CustomerMasterViewModel : ICustomerMasterViewModel
    {

        public CustomerMasterViewModel()
        {


            CustomerMasterDTO = new CustomerMaster();
            ContactDetailsByCustomerMasterID = new List<CustomerMaster>();
        }
        public List<CustomerMaster> ContactDetailsByCustomerMasterID { get; set; }
        public CustomerMaster CustomerMasterDTO
        {
            get;
            set;
        }

        public int CustomerMasterID
        {
            get
            {
                return (CustomerMasterDTO != null && CustomerMasterDTO.CustomerMasterID > 0) ? CustomerMasterDTO.CustomerMasterID : new int();
            }
            set
            {
                CustomerMasterDTO.CustomerMasterID = value;
            }
        }

        [Display(Name = "Customer Name")]
        public string CustomerMasterName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerMasterName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerMasterName = value;
            }
        }
        [Display(Name = "Company Name")]
        public string CompanyName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CompanyName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CompanyName = value;
            }
        }
        [Display(Name = "Company Type")]
        public byte CustomerType
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerType : new byte();
            }
            set
            {
                CustomerMasterDTO.CustomerType = value;
            }
        }
        [Display(Name = "Email")]
        public string Email
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.Email : string.Empty;
            }
            set
            {
                CustomerMasterDTO.Email = value;
            }
        }
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.FirstName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.FirstName = value;
            }
        }
        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.MiddleName = value;
            }
        }
        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.LastName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.LastName = value;
            }
        }
        [Display(Name = "Address 1")]
        public string Address1
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.Address1 : string.Empty;
            }
            set
            {
                CustomerMasterDTO.Address1 = value;
            }
        }
        [Display(Name = "Company Type")]
        public string CompanyTypeName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CompanyTypeName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CompanyTypeName = value;
            }
        }
        [Display(Name = "Street")]
        public string Address2
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.Address2 : string.Empty;
            }
            set
            {
                CustomerMasterDTO.Address2 = value;
            }
        }
        [Display(Name = "Landmark")]
        public string Address3
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.Address3 : string.Empty;
            }
            set
            {
                CustomerMasterDTO.Address3 = value;
            }
        }
        [Display(Name = "City")]
        public string CityID
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CityID : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CityID = value;
            }
        }
        [Display(Name = "State")]
        public string StateID
        {
            get
            {
                return (CustomerMasterDTO != null ) ? CustomerMasterDTO.StateID : string.Empty;
            }
            set
            {
                CustomerMasterDTO.StateID = value;
            }
        }
      
        public string CountryID
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CountryID : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CountryID = value;
            }
        }



        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                CustomerMasterDTO.MobileNumber = value;
            }
        }
        [Display(Name = "GST Number")]
        public string GSTNumber
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.GSTNumber : string.Empty;
            }
            set
            {
                CustomerMasterDTO.GSTNumber = value;
            }
        }
        public string Code
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.Code : string.Empty;
            }
            set
            {
                CustomerMasterDTO.Code = value;
            }
        }
        [Display(Name = "Currency")]
        public Int16 Currency
        {
            get
            {
                return (CustomerMasterDTO != null && CustomerMasterDTO.Currency > 0) ? CustomerMasterDTO.Currency : new Int16();
            }
            set
            {
                CustomerMasterDTO.Currency = value;
            }
        }
        [Display(Name = "Credit Period")]
        public string CreditPeriod
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CreditPeriod : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CreditPeriod = value;
            }
        }
        [Display(Name = "Unit")]
        public string UnitMasterId
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.UnitMasterId : string.Empty;
            }
            set
            {
                CustomerMasterDTO.UnitMasterId = value;
            }
        }
      
        [Display(Name = "Is Tax Excempted")]
        public bool IsTaxExempted
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsTaxExempted : false;
            }
            set
            {
                CustomerMasterDTO.IsTaxExempted = value;
            }
        }

        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.BankName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.BankName = value;
            }
        }
        [Display(Name = "Account Number")]
        public string BankAccountNumber
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.BankAccountNumber : string.Empty;
            }
            set
            {
                CustomerMasterDTO.BankAccountNumber = value;
            }
        }
        [Display(Name = "IFCI Code")]
        public string IFCICODE
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IFCICODE : string.Empty;
            }
            set
            {
                CustomerMasterDTO.IFCICODE = value;
            }
        }
        [Display(Name = "Reason For Excmption")]
        public byte ReasonForExemption
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.ReasonForExemption : new byte();
            }
            set
            {
                CustomerMasterDTO.ReasonForExemption = value;
            }
        }
        [Display(Name = "Tax Exemption Remark")]
        public string TaxExemptionRemark
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.TaxExemptionRemark : string.Empty;
            }
            set
            {
                CustomerMasterDTO.TaxExemptionRemark = value;
            }
        }
        [Display(Name = "Is Centre")]
        public bool IsCentre
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsCentre : false;
            }
            set
            {
                CustomerMasterDTO.IsCentre = value;
            }
        }
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CentreCode = value;
            }
        }
        
        public bool IsDeleted
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsDeleted : false;
            }
            set
            {
                CustomerMasterDTO.IsDeleted = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsActive : false;
            }
            set
            {
                CustomerMasterDTO.IsActive = value;
            }
        }
        public int CustomerBranchMasterID
        {
            get
            {
                return (CustomerMasterDTO != null && CustomerMasterDTO.CustomerBranchMasterID > 0) ? CustomerMasterDTO.CustomerBranchMasterID : new int();
            }
            set
            {
                CustomerMasterDTO.CustomerBranchMasterID = value;
            }
        }
        public bool IsMainBranch
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsMainBranch : false;
            }
            set
            {
                CustomerMasterDTO.IsMainBranch = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string CustomerBranchMasterName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerBranchMasterName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerBranchMasterName = value;
            }
        }
        [Display(Name = "First Name")]
        public string CustomerContactFirstName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactFirstName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactFirstName = value;
            }
        }
        [Display(Name = "Middle Name")]
        public string CustomerContactMiddleName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactMiddleName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactMiddleName = value;
            }
        }
        [Display(Name = "Last Name")]
        public string CustomerContactLastName
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactLastName : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactLastName = value;
            }
        }
        [Display(Name = "Email ID")]
        public string CustomerContactEmailID
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactEmailID : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactEmailID = value;
            }
        }
        [Display(Name = "Designation")]
        public string CustomerContactDesignation
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactDesignation : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactDesignation = value;
            }
        }
        [Display(Name = "primary Contact")]
        public bool IsPrimaryContact
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsPrimaryContact : false;
            }
            set
            {
                CustomerMasterDTO.IsPrimaryContact = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string CustomerContactMobileNumber
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerContactMobileNumber : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerContactMobileNumber = value;
            }
        }
        public string XmlString
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.XmlString : string.Empty;
            }
            set
            {
                CustomerMasterDTO.XmlString = value;
            }
        }





        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (CustomerMasterDTO != null && CustomerMasterDTO.CreatedBy > 0) ? CustomerMasterDTO.CreatedBy : new int();
            }
            set
            {
                CustomerMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                CustomerMasterDTO.CreatedDate = value;
            }
        }
        public byte PeriodUnitID
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.PeriodUnitID : new byte();
            }
            set
            {
                CustomerMasterDTO.PeriodUnitID = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (CustomerMasterDTO != null && CustomerMasterDTO.ModifiedBy > 0) ? CustomerMasterDTO.ModifiedBy : new int();
            }
            set
            {
                CustomerMasterDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                CustomerMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Short Code")]
        [Required(ErrorMessage =  "Short code Required")]
        public string ShortCode
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.ShortCode : string.Empty;
            }
            set
            {
                CustomerMasterDTO.ShortCode = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }
        [Display(Name = "Is BillTo Same As ShipTo")]
        public bool IsBillToSameAsShipTo
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.IsBillToSameAsShipTo : false;
            }
            set
            {
                CustomerMasterDTO.IsBillToSameAsShipTo = value;
            }
        }
        [Display(Name = "Customer Branch Code")]
        public string CustomerBranchCode
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.CustomerBranchCode : string.Empty;
            }
            set
            {
                CustomerMasterDTO.CustomerBranchCode = value;
            }
        }
        [Display(Name = "Pin Code")]
        public string PinCode
        {
            get
            {
                return (CustomerMasterDTO != null) ? CustomerMasterDTO.PinCode : string.Empty;
            }
            set
            {
                CustomerMasterDTO.PinCode = value;
            }
        }

    }
}

