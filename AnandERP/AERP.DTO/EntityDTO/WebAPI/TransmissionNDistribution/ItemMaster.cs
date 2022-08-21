using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ItemMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int CategoryID
        {
            get;
            set;
        }
        
        public string Item
        {
            get;
            set;
        }

        public string Size
        {
            get;
            set;
        }

        public decimal Weight_In_KG
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public decimal Rate
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public string ItemDescription
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

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }
    }
}
