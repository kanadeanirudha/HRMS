using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrganisationCentrewiseDepartment : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public Nullable<int> DepartmentID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public bool ActiveFlag
        {
            get;
            set;
        }
        public Nullable<int> DepartmentSeqNo
        {
            get;
            set;
        }
        public Nullable<bool> IsActive
        {
            get;
            set;
        }
        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }
        public Nullable<int> CreatedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> CreatedDate
        {
            get;
            set;
        }
        public Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> ModifiedDate
        {
            get;
            set;
        }
        public Nullable<int> DeletedBy
        {
            get;
            set;
        }
        public Nullable<DateTime> DeletedDate
        {
            get;
            set;
        }
        public string xmlInsertUpdate
        {
            get;
            set;
        }

        public string SelectedCentreName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string SelectedDomainIDs { get; set; }
    }
}
