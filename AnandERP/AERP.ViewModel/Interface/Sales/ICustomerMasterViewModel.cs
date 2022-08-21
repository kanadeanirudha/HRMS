using AERP.DTO;
using System;
using System.Collections.Generic;
namespace AERP.ViewModel
{
     interface ICustomerMasterViewModel
    {
        //**********CustomerMaster**********//
         Int32 CustomerMasterID
        {
            get;
            set;
        }
         string CompanyName
        {
            get;
            set;
        }
         byte CustomerType
        {
            get;
            set;
        }
         string Email
        {
            get;
            set;
        }
         string FirstName
        {
            get;
            set;
        }
         string MiddleName
        {
            get;
            set;
        }
         string LastName
        {
            get;
            set;
        }
         string Address1
        {
            get;
            set;
        }
         string Address2
        {
            get;
            set;
        }
         string Address3
        {
            get;
            set;
        }
        
    
         string MobileNumber
        {
            get;
            set;
        }
         Int16 Currency
        {
            get;
            set;
        }
         string CreditPeriod
        {
            get;
            set;
        }
         string  UnitMasterId
        {
            get;
            set;
        }
         string GSTNumber
        {
            get;
            set;
        }
         bool IsTaxExempted
        {
            get;
            set;
        }
         byte ReasonForExemption
        {
            get;
            set;
        }
         string BankName
        {
            get;
            set;
        }
         string IFCICODE
        {
            get;
            set;
        }
         string BankAccountNumber
        {
            get;
            set;
        }
         bool IsActive
        {
            get;
            set;
        }

        //**********CustomerBranchMaster**********//
         int CustomerBranchMasterID
        {
            get;
            set;
        }
         bool IsMainBranch
        {
            get;
            set;
        }
         byte PeriodUnitID
        {
            get;
            set;
        }
         string CustomerBranchMasterName
        {
            get;
            set;
        }
        //**********CustomerContactDetails**********//
         string CustomerContactFirstName
        {
            get;
            set;
        }
         string CustomerContactMiddleName
        {
            get;
            set;
        }
         string CustomerContactLastName
        {
            get;
            set;
        }
         string CustomerContactEmailID
        {
            get;
            set;
        }
         string CustomerContactDesignation
        {
            get;
            set;
        }
         bool IsPrimaryContact
        {
            get;
            set;
        }
         string CustomerContactMobileNumber
        {
            get;
            set;
        }

         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int ModifiedBy
        {
            get;
            set;
        }
         DateTime ModifiedDate
        {
            get;
            set;
        }
       
         bool IsDeleted
        {
            get;
            set;
        }
         string errorMessage { get; set; }

    }
}
