using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryBrandMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }

        public int InventoryBrandMasterID
        {
            get;
            set;
        }

        public string BrandName
        {
            get;
            set;
        }

        public string BrandDescription
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
