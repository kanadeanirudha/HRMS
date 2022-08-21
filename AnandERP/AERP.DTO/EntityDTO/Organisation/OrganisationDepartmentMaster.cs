using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
   public class OrganisationDepartmentMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }


       //This is a temprary varibale to store combination of ID and DepartmentName of Dropdownlistfor binding purpose
        public string DeptID
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get;
            set;
        }

        public string DeptShortCode
        {
            get;
            set;
        }

        public string PrintShortDesc
        {
            get;
            set;
        }

        public int DepartmentSeqNo
        {
            get;
            set;
        }

        public string AcademicNonacademic
        {
            get;
            set;
        }

        public bool TeachingActivity
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

        #region properties for CentreWise Department
        public int CentrewiseDepartmentID
        {
            get;
            set;
        }

        public bool CentrewiseDepartmentStatus
        {
            get;
            set;
        }
        #endregion

        public string EmployeeCode
        {
            get;set;
        }

        public string EmployeeName
        {
            get; set;
        }

    }
}
