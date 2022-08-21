using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralPackageTypeViewModel
    {
        GeneralPackageType GeneralPackageTypeDTO
        {
            get;
            set;
        }

        Int32 ID
        {
            get;
            set;
        }
        string PackageType
        {
            get;
            set;
        }
        decimal Height
        {
            get;
            set;
        }

        decimal Length
        {
            get;
            set;
        }
        decimal Width
        {
            get;
            set;
        }
       
        decimal Weight
        {
            get;
            set;
        }
        decimal Volume
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
        int ModifiedBy
        {
            get;
            set;
        }
        DateTime ModifiedDate
        {
            get;
            set;
        }
        int DeletedBy
        {
            get;
            set;
        }
        DateTime DeletedDate
        {
            get;
            set;
        }
        string errorMessage { get; set; }
    }
}
