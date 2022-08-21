using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralUnitsViewModel
    {
        GeneralUnits GeneralUnitsDTO
        {
            get;
            set;
        }

        Int16 ID
        {
            get;
            set;
        }
        string UnitName
        {
            get;
            set;
        }
        Int16 GeneralUnitTypeID
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
        string LocationAddress
        {
            get;
            set;
        }
        int CityId
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
        string ListingDate { get; set; }
        string DeListingDate { get; set; }
    }
}
