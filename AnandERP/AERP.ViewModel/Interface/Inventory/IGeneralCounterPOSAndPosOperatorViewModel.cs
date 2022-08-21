using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IGeneralCounterPOSAndPosOperatorViewModel
    {
        GeneralCounterPOSAndPosOperator GeneralCounterPOSAndPosOperatorDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string GeneralUnitsName
        {
            get;
            set;
        }
        string GeneralCounterMasterName
        {
            get;
            set;
        }
        string GeneralPOSMasterDeviceCode
        {
            get;
            set;
        }
        string DateFrom
        {
            get;
            set;
        }
        string DateUpto
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
