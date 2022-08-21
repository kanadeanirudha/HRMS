using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralPriceGroupViewModel
    {
        GeneralPriceGroup GeneralPriceGroupDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        Int16 IsRelatedTo
        {
            get;
            set;
        }
        string GeneralPriceGroupCode
        {
            get;
            set;
        }

        string GeneralPriceGroupDescription
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
