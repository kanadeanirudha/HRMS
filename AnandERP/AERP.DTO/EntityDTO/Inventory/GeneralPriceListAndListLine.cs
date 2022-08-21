using System;
using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralPriceListAndListLine : BaseDTO
    {
        //Feilds from GeneralPriceList

        public Int16 GeneralPriceListID
        {
            get;
            set;
        }
        public string PriceListName
        {
            get;
            set;
        }
        public string BasePriceListname
        {
            get;
            set;
        }
        public bool IsRoot
        {
            get;
            set;
        }
        public bool IsUpdationAutomatic
        {
            get;
            set;
        }
        public bool IsDeleted
        {
            get;
            set;
        }

        //Feilds from GeneralPriceList
        public Int16 GeneralPriceListLineID
        {
            get;
            set;
        }
        public Int16 BasePriseListID
        {
            get;
            set;
        }
        public decimal Factor
        {
            get;
            set;
        }
        public byte RoundingMethod
        {
            get;
            set;
        }
        public Int16 PriceGroupId
        {
            get;
            set;
        }
        public string ValidFromDate
        {
            get;
            set;
        }
        public string GeneralPriceGroupCode
        {
            get;
            set;
        }
        public string GeneralPriceGroupDescription
        {
            get;
            set;
        }
       
        public string ValidUptoDate
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }


        public Int16 IsRootCount
        {
            get;
            set;
        }
        public bool IsRounding
        {
            get;
            set;
        }
        //Common Feilds
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
