using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralUnitsStorageLocationViewModel
    {
        GeneralUnitsStorageLocation GeneralUnitStorageLocationDTO
        {
            get;
            set;
        }
        Int16 ID { get; set; }
        Int16 GeneralUnitsID { get; set; }
        int InventoryLocationMasterID { get; set; }
        // bool DefaultFlag { get; set; }
        // bool IsUserDefined { get; set; }
        // Nullable<int> SeqNo { get; set; }
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
