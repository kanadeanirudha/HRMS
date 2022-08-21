using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IInventoryUoMGroupAndDetailsViewModel
    {
        InventoryUoMGroupAndDetails InventoryUoMGroupAndDetailsDTO
        {
            get;
            set;
        }

         Int16 InventoryUoMGroupID
        {
            get;
            set;
        }
         string GroupCode
        {
            get;
            set;
        }
         string GroupDescription
        {
            get;
            set;
        }
         string BaseUomCode
        {
            get;
            set;
        }
        //InventoryUoMGroupDetails

         Int16 InventoryUoMGroupDetailsID
        {
            get;
            set;
        }
         string AlternativeUomName
        {
            get;
            set;
        }
         string AlternativeUomCode
        {
            get;
            set;
        }
         decimal AlternativeQuantity
        {
            get;
            set;
        }
        
         decimal BaseUoMQuantity
        {
            get;
            set;
        }
         decimal BasePriceReducedBy
        {
            get;
            set;
        }
         Int16 UsedFor
        {
            get;
            set;
        }

        //Common Properties

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
