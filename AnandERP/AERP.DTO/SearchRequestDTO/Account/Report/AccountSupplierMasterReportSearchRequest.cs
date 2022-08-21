using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class AccountSupplierMasterReportSearchRequest : Request
	{
		public int ID
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
		public int TahsilID
		{
			get;
			set;
		}
		public int PinCode
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
		public int CategoryId
		{
			get;
			set;
		}
		public int AccountId
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
		public bool IsActive
		{
			get;
			set;
		}
		public string SortOrder
		{
			get;
			set;
		}
		public string SortBy
		{
			get;
			set;
		}
		public int StartRow
		{
			get;
			set;
		}
		public int RowLength
		{
			get;
			set;
		}
		public int EndRow
		{
			get;
			set;
		}
	}
}
