using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationMemberMaster : BaseDTO
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
        public string CentreName
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
        public string TransDate
        {
            get;
            set;
        }
		public bool IsActive
		{
			get;
			set;
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
		public int? ModifiedBy
		{
			get;
			set;
		}
		public DateTime? ModifiedDate
		{
			get;
			set;
		}
		public int? DeletedBy
		{
			get;
			set;
		}
		public DateTime? DeletedDate
		{
			get;
			set;
		}
        public string EntityLevel { get; set; }
        public int UserID { get; set; }
        public int Status { get; set; }
	}
}
