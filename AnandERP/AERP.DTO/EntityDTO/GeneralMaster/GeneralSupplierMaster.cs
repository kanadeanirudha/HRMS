using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DTO
{
	public class GeneralSupplierMaster : BaseDTO
	{
        public int ID 
        { 
            get; 
            set; 
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public string Vender
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
        public string FullName
        {
            get;
            set;
        }
        public string Sex
        {
            get;
            set;
        }
        public string AddressFirst
        {
            get;
            set;
        }
        public string AddressSecond
        {
            get;
            set;
        }
        public string PlotNumber
        {
            get;
            set;
        }
        public string StreetNumber
        {
            get;
            set;
        }
        public Nullable<int> TahsilID
        {
            get;
            set;
        }
        public Nullable<int> PinCode
        {
            get;
            set;
        }
        public string PhoneNumber
        {
            get;
            set;
        }
        public string ResiPhoneNumber
        {
            get;
            set;
        }
        public string CellPhoneNumber
        {
            get;
            set;
        }
        public int CountryID
        {
            get;
            set;
        }
        public string Currency
        {
            get;
            set;
        }
        public string FaxNumber
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string WebUrl
        {
            get;
            set;
        }
        public string VenderDescription
        {
            get;
            set;
        }
        public Nullable<int> CategoryId
        {
            get;
            set;
        }
        public Nullable<int> AccountId
        {
            get;
            set;
        }
        public string VAT
        {
            get;
            set;
        }
        public string CST
        {
            get;
            set;
        }
        public string Excise
        {
            get;
            set;
        }
        public string StablishmentNumber
        {
            get;
            set;
        }
        public string RefNumber
        {
            get;
            set;
        }
        public Nullable<bool> IsActive
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        public Nullable<int> DeletedBy
        {
            get;
            set;
        }
        public Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }
	}
}
