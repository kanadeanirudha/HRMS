using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationMemberMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int PersonID
		{
			get;
			set;
		}
		public string PersonType
		{
			get;
			set;
		}
        public string JoiningDate
		{
			get;
			set;
		}
        public string LeavingDate
		{
			get;
			set;
		}
		public decimal ShareQuantity
		{
			get;
			set;
		}
        public decimal EachSharePrice
		{
			get;
			set;
		}
		public string CentreCode
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string AdminRoleMasterID { get; set; }
        public string EntityLevel { get; set; }
        public string SearchWord { get; set; }        
	}
}
