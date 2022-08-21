using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class OrderingAndDeliveryDay : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public bool sunday
        {
            get;
            set;
        }

        public bool monday
        {
            get;
            set;
        }
        public bool tuesday
        {
            get;
            set;
        }
        public bool wednesday
        {
            get;
            set;
        }
        public bool thursday
        {
            get;
            set;
        }
        public bool friday
        {
            get;
            set;
        }
        public bool saturday
        {
            get;
            set;
        }
        public string code
        {
            get;
            set;
        }
        public string ParameterXml
        {
            get;
            set;
        }
        public string OrderingCode
        {
            get;
            set;
        }
        public string OrderingDay
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
        public double Quantity
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string UoMCode
        {
            get;
            set;
        }
    }
}
