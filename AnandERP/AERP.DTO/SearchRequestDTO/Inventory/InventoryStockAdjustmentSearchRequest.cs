using System;
using AERP.Base.DTO;

namespace AERP.DTO
{
    public class InventoryStockAdjustmentSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public string SearchWord
        {
            get;
            set;
        }

        public int InvLocationMasterID
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        public int InventoryRecipeMasterID
        {
            get;
            set;
        }
        public int InventoryVariationMasterID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string CurrentStockStatus
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        public string SortOrder
        {
            get;
            set;
        }

        public string SortBy
        {
            get;
            set;
        }

        public int StartRow
        {
            get;
            set;
        }

        public int EndRow
        {
            get;
            set;
        }

        public int RowLength
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string SortDirection
        {
            get;
            set;
        }
    }
}
