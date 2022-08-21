using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralPackageType : BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public string PackageType
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
