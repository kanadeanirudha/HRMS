using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralMovementTypeViewModel
    {
        GeneralMovementType GeneralMovementTypeDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string MovementType
        {
            get;
            set;
        }

        string MovementCode
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
