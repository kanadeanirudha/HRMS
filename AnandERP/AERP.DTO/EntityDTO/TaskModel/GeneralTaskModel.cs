using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralTaskModel : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public string TaskCode
		{
			get;
			set;
		}
		public string TaskDescription
		{
			get;
			set;
		}
		public string MenuCode
		{
			get;
			set;
		}
		public string TaskModelApplicableTo
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public string LinkMenuCode
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
        public string errorMessage { get; set; }
        public string MenuLink { get; set; }
        public string MenuName{ get; set; }
	}
}
