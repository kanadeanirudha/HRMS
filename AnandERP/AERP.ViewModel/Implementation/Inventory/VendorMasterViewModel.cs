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
    public class VendorMasterViewModel : IVendorMasterViewModel
    {

        public VendorMasterViewModel()
        {
            VendorMasterDTO = new VendorMaster();
            VendorMasterListForPersonDetails = new List<VendorMaster>();
            VendorMasterListForGeneralData = new List<VendorMaster>();
        }
        public List<VendorMaster> VendorMasterListForPersonDetails { get; set; }
        public List<VendorMaster> VendorMasterListForGeneralData { get; set; }

        public HttpPostedFileBase MyFile { get; set; }

        public VendorMaster VendorMasterDTO
        {
            get;
            set;
        }
        public int CityId
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.CityId > 0) ? VendorMasterDTO.CityId : new int();
            }
            set
            {
                VendorMasterDTO.CityId = value;
            }
        }
        public int ID
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.ID > 0) ? VendorMasterDTO.ID : new int();
            }
            set
            {
                VendorMasterDTO.ID = value;
            }
        }
        public int VendorFinanceDetailsID
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.VendorFinanceDetailsID > 0) ? VendorMasterDTO.VendorFinanceDetailsID : new int();
            }
            set
            {
                VendorMasterDTO.VendorFinanceDetailsID = value;
            }
        }
         [Display(Name = "PO Box")]
        public int PinCode
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.PinCode > 0) ? VendorMasterDTO.PinCode : new int();
            }
            set
            {
                VendorMasterDTO.PinCode = value;
            }
        }
        public int VendorID
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.VendorID > 0) ? VendorMasterDTO.VendorID : new int();
            }
            set
            {
                VendorMasterDTO.VendorID = value;
            }
        }
        public int VendorContactPersoninfoID
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.VendorContactPersoninfoID > 0) ? VendorMasterDTO.VendorContactPersoninfoID : new int();
            }
            set
            {
                VendorMasterDTO.VendorContactPersoninfoID = value;
            }
        }
        [Display(Name = "Will accept return of goods")]
        public bool ReturnGoods
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.ReturnGoods : false;
            }
            set
            {
                VendorMasterDTO.ReturnGoods = value;
            }
        }
        public int VendorReplenishmentInfoID
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.VendorReplenishmentInfoID > 0) ? VendorMasterDTO.VendorReplenishmentInfoID : new int();
            }
            set
            {
                VendorMasterDTO.VendorReplenishmentInfoID = value;
            }
        }
        [Display(Name = "Vendor Number")]
        public int VendorNumber
        {
            get
            {
                return (VendorMasterDTO == null) ? VendorMasterDTO.VendorNumber : new int();
            }
            set
            {
                VendorMasterDTO.VendorNumber = value;
            }
        }
       // [Display(Name = "Vendor Number")]
        public int ItemNumber
        {
            get
            {
                return (VendorMasterDTO == null) ? VendorMasterDTO.ItemNumber : new int();
            }
            set
            {
                VendorMasterDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Vendor Restriction")]
        public decimal VendorRestriction
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.VendorRestriction : new decimal();
            }
            set
            {
                VendorMasterDTO.VendorRestriction = value;
            }
        }
        
        [Display(Name = "Designation")]
        public int PersonDesg
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.PersonDesg : new int();
            }
            set
            {
                VendorMasterDTO.PersonDesg = value;
            }
        }
        [Display(Name = "Designation")]
        public string PersonDesgDesc
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.PersonDesgDesc : string.Empty;
            }
            set
            {
                VendorMasterDTO.PersonDesgDesc = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string ContactPersonMobNumber
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.ContactPersonMobNumber : string.Empty;
            }
            set
            {
                VendorMasterDTO.ContactPersonMobNumber = value;
            }
        }
        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.FirstName : string.Empty;
            }
            set
            {
                VendorMasterDTO.FirstName = value;
            }
        }
        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.MiddleName : string.Empty;
            }
            set
            {
                VendorMasterDTO.MiddleName = value;
            }
        }
         [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.LastName : string.Empty;
            }
            set
            {
                VendorMasterDTO.LastName = value;
            }
        }
         public string City
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.City : string.Empty;
             }
             set
             {
                 VendorMasterDTO.City = value;
             }
         }
         public string State
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.State : string.Empty;
             }
             set
             {
                 VendorMasterDTO.State = value;
             }
         }
         public string XMLstring
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstring : string.Empty;
             }
             set
             {
                 VendorMasterDTO.XMLstring = value;
             }
         }
         public string XMLstring1
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstring1 : string.Empty;
             }
             set
             {
                 VendorMasterDTO.XMLstring1 = value;
             }
         }
         public string XMLstring2
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstring2 : string.Empty;
             }
             set
             {
                 VendorMasterDTO.XMLstring2 = value;
             }
         }
         public string xmlParameter
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.xmlParameter : string.Empty;
             }
             set
             {
                 VendorMasterDTO.xmlParameter = value;
             }
         }
         public string SearchWord
         {
             get
             {
                 return (VendorMasterDTO != null) ? VendorMasterDTO.SearchWord : string.Empty;
             }
             set
             {
                 VendorMasterDTO.SearchWord = value;
             }
         }
      //  [Required(ErrorMessage = "Movement Type should not be blank.")]
        [Display(Name = "Vendor")]
        public string VendorName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.VendorName : string.Empty;
            }
            set
            {
                VendorMasterDTO.VendorName = value;
            }
        }
        [Display(Name = "Name")]
        public string Name
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Name : string.Empty;
            }
            set
            {
                VendorMasterDTO.Name = value;
            }
        }

        [Display(Name = "Merchandise Category")]
        public string MerchandiseCategory
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.MerchandiseCategory : string.Empty;
            }
            set
            {
                VendorMasterDTO.MerchandiseCategory = value;
            }
        }



        
        [Display(Name = "Lead Time")]
        public string LeadTime
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.LeadTime : string.Empty;
            }
            set
            {
                VendorMasterDTO.LeadTime = value;
            }
        }
        [Display(Name = "Address 1")]
        public string Address1
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Address1 : string.Empty;
            }
            set
            {
                VendorMasterDTO.Address1 = value;
            }
        }
        [Display(Name = "Address 2")]
        public string Address2
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Address2 : string.Empty;
            }
            set
            {
                VendorMasterDTO.Address2 = value;
            }
        }

        [Display(Name = "Address 3")]
        public string Address3
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Address3 : string.Empty;
            }
            set
            {
                VendorMasterDTO.Address3 = value;
            }
        }
      
        public string TaskCode
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                VendorMasterDTO.TaskCode = value;
            }
        }
        [Display(Name = "Country")]
        public string Country
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Country : string.Empty;
            }
            set
            {
                VendorMasterDTO.Country = value;
            }
        }
        [Display(Name = "Currency")]
        public string Currency
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Currency : string.Empty;
            }
            set
            {
                VendorMasterDTO.Currency = value;
            }
        }

        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.PhoneNumber : string.Empty;
            }
            set
            {
                VendorMasterDTO.PhoneNumber = value;
            }
        }
        [Display(Name = "Mobile Number")]
        public string MobileNumber
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                VendorMasterDTO.MobileNumber = value;
            }
        }

        [Display(Name = "Email ID")]
        public string EmailID
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.EmailID : string.Empty;
            }
            set
            {
                VendorMasterDTO.EmailID = value;
            }
        }


       //Fields For Finance Tab

        [Display(Name = "IFSC/IBAN Code")]
        public string IFSCCode
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.IFSCCode : string.Empty;
            }
            set
            {
                VendorMasterDTO.IFSCCode = value;
            }
        }
        [Display(Name = "Credit Limit(In Days)")]
        public string CreditLimit
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CreditLimit : string.Empty;
            }
            set
            {
                VendorMasterDTO.CreditLimit = value;
            }
        }
        [Display(Name = "Incoterms")]
        public string Incoterms
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Incoterms : string.Empty;
            }
            set
            {
                VendorMasterDTO.Incoterms = value;
            }
        }
        [Display(Name = "Branch Name")]
        public string BranchName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.BranchName : string.Empty;
            }
            set
            {
                VendorMasterDTO.BranchName = value;
            }
        }

        [Display(Name = "Address")]
        public string BankAddress
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.BankAddress : string.Empty;
            }
            set
            {
                VendorMasterDTO.BankAddress = value;
            }
        }

        [Display(Name = "Bank Name")]
        public string BankName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.BankName : string.Empty;
            }
            set
            {
                VendorMasterDTO.BankName = value;
            }
        }

        [Display(Name = "Account Number")]
        public string AccountNo
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.AccountNo : string.Empty;
            }
            set
            {
                VendorMasterDTO.AccountNo = value;
            }
        }

        [Display(Name = "Cash Discount")]
        public decimal CashDiscount
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CashDiscount : new decimal();
            }
            set
            {
                VendorMasterDTO.CashDiscount = value;
            }
        }

        [Display(Name = "Rebate %")]
        public decimal Rebate
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Rebate : new decimal();
            }
            set
            {
                VendorMasterDTO.Rebate = value;
            }
        }

        [Display(Name = "Last Name")]
        public string CPLastName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CPLastName : string.Empty;
            }
            set
            {
                VendorMasterDTO.CPLastName = value;
            }
        }
        [Display(Name = "First Name")]
        public string CPFirstName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CPFirstName : string.Empty;
            }
            set
            {
                VendorMasterDTO.CPFirstName = value;
            }
        }
        [Display(Name = "Middle Name")]
        public string CPMiddleName
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CPMiddleName : string.Empty;
            }
            set
            {
                VendorMasterDTO.CPMiddleName = value;
            }
        }
        //Common fields
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.IsDeleted : false;
            }
            set
            {
                VendorMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (VendorMasterDTO != null && VendorMasterDTO.CreatedBy > 0) ? VendorMasterDTO.CreatedBy : new int();
            }
            set
            {
                VendorMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                VendorMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.ModifiedBy : new int();
            }
            set
            {
                VendorMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                VendorMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.DeletedBy : new int();
            }
            set
            {
                VendorMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                VendorMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        public string XMLstringForContactPerson1
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstringForContactPerson1 : string.Empty;
            }
            set
            {
                VendorMasterDTO.XMLstringForContactPerson1 = value;
            }
        }
        public string XMLstringForContactPerson2
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstringForContactPerson2 : string.Empty;
            }
            set
            {
                VendorMasterDTO.XMLstringForContactPerson2 = value;
            }
        }
        public string XMLstringForContactPerson3
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.XMLstringForContactPerson3 : string.Empty;
            }
            set
            {
                VendorMasterDTO.XMLstringForContactPerson3 = value;
            }
        }
        [Display(Name = "Cash On Delivery")]
        public bool CashOnDelivery
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CashOnDelivery : new bool();
            }
            set
            {
                VendorMasterDTO.CashOnDelivery = value;
            }
        }
         [Display(Name = "Current Dated Cheque")]
        public bool CurrentDatedCheque
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CurrentDatedCheque : new bool();
            }
            set
            {
                VendorMasterDTO.CurrentDatedCheque = value;
            }
        }
          [Display(Name = "Credit")]
        public bool Credit
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.Credit : new bool();
            }
            set
            {
                VendorMasterDTO.Credit = value;
            }
        }
        [Display (Name="Mode Of Payment")]
        public string ModeOfPayment
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.ModeOfPayment : string.Empty;
            }
            set
            {
                VendorMasterDTO.ModeOfPayment = value;
            }
        }
        [Display(Name = "Vendor Code")]
        public string VendorCode
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.VendorCode : string.Empty;
            }
            set
            {
                VendorMasterDTO.VendorCode = value;
            }
        }
        [Display(Name = "Is Centre")]
        public bool IsCentre
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.IsCentre : new bool();
            }
            set
            {
                VendorMasterDTO.IsCentre = value;
            }
        }
        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (VendorMasterDTO != null) ? VendorMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                VendorMasterDTO.CentreCode = value;
            }
        }
    }
}

