using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralItemMerchantiseCategory : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string MerchantiseCategoryName
        {
            get;
            set;
        }

        public string MerchantiseCategoryCode
        {
            get;
            set;
        }
        public Int16 MerchandiseDepartmentID
        {
            get;
            set;
        }
        




        //Feilds from GeneralUnitType//



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
