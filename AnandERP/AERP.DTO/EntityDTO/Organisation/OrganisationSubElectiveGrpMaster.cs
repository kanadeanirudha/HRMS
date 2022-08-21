using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSubElectiveGrpMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public int OrgElectiveGrpID
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public string ShortDescription
		{
			get;
			set;
		}
		public int TotalNoOfSubjects
		{
			get;
			set;
		}
		public bool SubGrpCompulsorySubjFlag
		{
			get;
			set;
		}
		public int AllowToSelect
		{
			get;
			set;
		}
		public bool SubGroupCompulsoryFlag
		{
			get;
			set;
		}
		public int TotalNoOfSubjectCompulsory
		{
			get;
			set;
		}
		public string ElectiveCommonSubGroup
		{
			get;
			set;
		}
		public bool FeeBased
		{
			get;
			set;
		}
		public int NextSubElectiveGrpID
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
	}
}
