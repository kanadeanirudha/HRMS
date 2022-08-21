using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationElectiveGrpMaster : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public string GroupShortCode
		{
			get;
			set;
		}
		public string GroupName
		{
			get;
			set;
		}
		public int SubjectRuleGrpNumber
		{
			get;
			set;
		}
		public bool GroupCompulsoryFlag
		{
			get;
			set;
		}
		public int NoOfSubGroups
		{
			get;
			set;
		}
		public int NoOfCompulsorySubGrp
		{
			get;
			set;
		}
		public int NoOfSubGrpSubjectSelect
		{
			get;
			set;
		}
		public string ElectiveCommonGroup
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

