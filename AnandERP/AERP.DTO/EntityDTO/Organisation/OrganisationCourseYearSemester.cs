using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationCourseYearSemester : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public int CourseYearDetailID
		{
			get;
			set;
		}
		public int OrgSemesterMstID
		{
			get;
			set;
		}
		public string SemesterActiveFlag
		{
			get;
			set;
		}
		public string SemesterType
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
