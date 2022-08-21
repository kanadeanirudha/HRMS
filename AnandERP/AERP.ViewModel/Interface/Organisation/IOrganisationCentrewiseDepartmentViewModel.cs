using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IOrganisationCentrewiseDepartmentBaseViewModel
    {
        List<OrganisationCentrewiseDepartment> ListOrganisationCentrewiseDepartment
        {
            get;
            set;
        }

        List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }
    }
    public interface IOrganisationCentrewiseDepartmentViewModel
    {
        OrganisationCentrewiseDepartment OrganisationCentrewiseDepartmentDTO 
        { 
            get; 
            set; 
        }

        int ID
        {
            get;
            set;
        }
        Nullable<int> DepartmentID
        {
            get;
            set;
        }
        string SelectedCentreName
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
         string DepartmentName
        {
            get;
            set;
        }
        bool ActiveFlag
        {
            get;
            set;
        }
        Nullable<int> DepartmentSeqNo
        {
            get;
            set;
        }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }
        Nullable<int> CreatedBy
        {
            get;
            set;
        }
        Nullable<DateTime> CreatedDate
        {
            get;
            set;
        }
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<DateTime> DeletedDate
        {
            get;
            set;
        }

    }
}
