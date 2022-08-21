using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationDepartmentBranch : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int BranchID
        {
            get;
            set;
        }
        public string Remark
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
    }
}
