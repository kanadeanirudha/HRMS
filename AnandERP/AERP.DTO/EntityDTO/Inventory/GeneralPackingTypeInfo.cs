using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class GeneralPackingTypeInfo : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public Int32 ItemCodeID
        {
            get;
            set;
        }
        public int UomCodeId
        {
            get;
            set;
        }
        public string PackageType
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string UomCode
        {
            get;
            set;
        }
        public Int32 PackageTypeID
        {
            get;
            set;
        }

        public decimal QuantityPerPackage
        {
            get;
            set;
        }
        public decimal Height
        {
            get;
            set;
        }

        public decimal Length
        {
            get;
            set;
        }
        public decimal Width
        {
            get;
            set;
        }
        public decimal Weight
        {
            get;
            set;
        }

        public decimal Volume
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
