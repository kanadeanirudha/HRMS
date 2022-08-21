using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IInventoryDimensionUnitMasterViewModel
    {
        InventoryDimensionUnitMaster InventoryDimensionUnitMasterDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string DimensionCode
        {
            get;
            set;
        }

        string DimensionDescription
        {
            get;
            set;
        }
        string SIUnit
        {
            get;
            set;
        }

        string SIDescription
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
