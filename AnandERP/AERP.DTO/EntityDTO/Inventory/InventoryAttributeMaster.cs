using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class InventoryAttributeMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int InventoryAttributeMasterID
        {
            get;
            set;
        }
        public string AttributeName
        {
            get;
            set;
        }

        public string AttributeDescription
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
