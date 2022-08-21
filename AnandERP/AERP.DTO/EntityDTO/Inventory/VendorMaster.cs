using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class VendorMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int VendorFinanceDetailsID
        {
            get;
            set;
        }
        public bool ReturnGoods
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public int PinCode
        {
            get;
            set;
        }
        public int VendorContactPersoninfoID
        {
            get;
            set;
        }
        public int VendorReplenishmentInfoID
        {
            get;
            set;
        }
        public int VendorID
        {
            get;
            set;
        }
        public decimal VendorRestriction
        {
            get;
            set;
        }
        public string VendorName
        {  
            get;
            set;
        }
         public string xmlParameter
        {
            get;
            set;
        }
         public string PersonDesgDesc
         {
             get;
             set;
         }

        public string XMLstring
        {
            get;
            set;
        }
        public string XMLstring1
        {
            get;
            set;
        }
        public string XMLstring2
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public int CityId
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string MerchandiseCategory
        {
            get;
            set;
        }
        public string LeadTime
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
        public string Country
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string ContactPersonMobNumber
        {
            get;
            set;
        }
        public string EmailID
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
        public string BankName
        {
            get;
            set;
        }
        public string BankAddress 
        {
            get;
            set;
        }
        public string BranchName
        {
            get;
            set;
        }
        public string Incoterms
        {
            get;
            set;
        }
        public string CreditLimit
        {
            get;
            set;
        }
        public string IFSCCode
        {
            get;
            set;
        }
        public string AccountNo
        {
            get;
            set;
        }
        public int PersonDesg
        {
            get;
            set;
        }
        public decimal CashDiscount
        {
            get;
            set;
        }
        public decimal Rebate 
        {
            get;
            set;
        }
        public string CPFirstName
        {
            get;
            set;
        }
        public string CPMiddleName
        {
            get;
            set;
        }
        public string CPLastName
        {
            get;
            set;
        }
        //public byte MovementTypeID
        //{
        //    get;
        //    set;
        //}
        //Feilds from GeneralUnitType//



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
        public string XMLstringForContactPerson1
        {
            get;
            set;
        }
        public string XMLstringForContactPerson2
        {
            get;
            set;
        }

        public string XMLstringForContactPerson3
        {
            get;
            set;
        }
        public string XMLstringForReplenishmentInfo1
        {
            get;
            set;
        }
        public string XMLstringForReplenishmentInfo2
        {
            get;
            set;
        }

        public string XMLstringForReplenishmentInfo3
        {
            get;
            set;
        }
        public string CountryList
        {
            get;
            set;
        }
        public string CityList
        {
            get;
            set;
        }
        public string CurrencyList
        {
            get;
            set;
        }
        public string CategoryList
        {
            get;
            set;
        }
        public bool CashOnDelivery
        {
            get;
            set;
        }
        public bool CurrentDatedCheque 
        {
            get;
            set;
        }
        public bool Credit
        {
            get;
            set;
        }
        public string ModeOfPayment
        {
            get;
            set;
        }
        public string VendorCode
        {
            get;
            set;
        }
        public bool IsCentre
        {
            get;set;
        }
        public string CentreCode { get; set; }
    }
}
