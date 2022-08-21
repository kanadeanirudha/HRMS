using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralTemperatureMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public int GeneralTemperatureMasterID
        {
            get;
            set;
        }
        public decimal TemperatureFrom
        {
            get;
            set;
        }

        public decimal TemperatureUpto
        {
            get;
            set;
        }

        public string TemperatureDescription
        {
            get;
            set;
        }

        public string TemperatureType
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
