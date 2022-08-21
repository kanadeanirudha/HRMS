using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{

    public interface IGeneralGroupMasterViewModel
    {
        GeneralGroupMaster GeneralGroupMasterDTO
        {
            get;
            set;
        }
       int ID
        {
            get;
            set;
        }
        string GroupName
        {
            get;
            set;
        }
        string GroupDependentObject
        {
            get;
            set;
        }
      int JobProfileID
        {
            get;
            set;
        }
      string JobProfileDescription
        {
            get;
            set;
        }        
       bool IsActive
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

       #region ----------------EmployeeGroupDetails-----------------

       int EmployeeGroupDetailsID
       {
           get;
           set;
       }
       int DependentObjectID
       {
           get;
           set;
       }

       string CentreCode
       {
           get;
           set;
       }
       int DepartmentID
       {
           get;
           set;
       }        
       string Department
       {
           get;
           set;
       }
       string Designation
       {
           get;
           set;
       }
       string PayScale
       {
           get;
           set;
       }
       #endregion
    }
}

