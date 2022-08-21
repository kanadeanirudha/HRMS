
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class ECommerceSystemSettings : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EComStoreSettingID
        {
            get;
            set;
        }
        public string TaskCode
        {
            get;
            set;
        }
        public string EComSystemSettingsMenus
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
      
        public string SelectedIDs
        {
            get;
            set;
        }
        public string MerchandiseGroup
        {
            get;
            set;
        }
        public string Department
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
        public string SubCategory
        {
            get;
            set;
        }
        public string BaseMerchandiseCategory
        {
            get;
            set;
        }
        public Int16 EComCategorySettingID
        {
            get;
            set;
        }
        public Int16 SequenceNumber
        {
            get;
            set;
        }
        public Int16 LevelNumber
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public Int16 NextLevel
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
