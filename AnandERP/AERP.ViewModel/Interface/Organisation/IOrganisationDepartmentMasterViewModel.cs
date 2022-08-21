using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
namespace AERP.ViewModel
{
    public interface IOrganisationDepartmentMasterBaseViewModel
    {
        List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
    }
    public interface IOrganisationDepartmentMasterViewModel
    {

        OrganisationDepartmentMaster OrganisationDepartmentMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string DepartmentName
        {
            get;
            set;
        }

        string DeptShortCode
        {
            get;
            set;
        }

        string PrintShortDesc
        {
            get;
            set;
        }

        int DepartmentSeqNo
        {
            get;
            set;
        }

        string AcademicNonacademic
        {
            get;
            set;
        }

        bool TeachingActivity
        {
            get;
            set;
        }

             
        bool IsDeleted
        {
            get;
            set;
        }

        int CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedDate
        {
            get;
            set;
        }

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }

        #region 
        int CentrewiseDepartmentID
        {
            get;
            set;
        }

        bool CentrewiseDepartmentStatus
        {
            get;
            set;
        }
        #endregion

    }
}
