using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeeConsultancyMaster : BaseDTO
	{
        //---------------------------------------   EmployeeConsultancyMaster Properties  ------------------------------------------//
		public int ID
		{
			get;
			set;
		}
		public string ConsultancyDate
		{
			get;
			set;
		}
		public string ConsultancyName
		{
			get;
			set;
		}
		public string TitleOfAssignment
		{
			get;
			set;
		}
        public decimal ConsultancyCost
		{
			get;
			set;
		}
		public decimal EmployeeShare
		{
			get;
			set;
		}
		public string AssignmentFromDate
		{
			get;
			set;
		}
		public string AssignmentToDate
		{
			get;
			set;
		}
		public string Remarks
		{
			get;
			set;
		}
        public string CentreCode { get; set; }
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

        //---------------------------------------   EmployeeConsultancyDetails Properties  ------------------------------------------//
		public int EmpConsultancyDetID
		{
			get;
			set;
		}
		public int EmployeeConsultancyMasterID
		{
			get;
			set;
		}
		public int EmployeeID
		{
			get;
			set;
		}
		public string ConsultingFromDate
		{
			get;
			set;
		}
		public string ConsultingToDate
		{
			get;
			set;
		}
		public string EmployeeRemark
		{
			get;
			set;
		}
        public string errorMessage { get; set; }

        public bool StatusFlag { get; set; }
	}
}
