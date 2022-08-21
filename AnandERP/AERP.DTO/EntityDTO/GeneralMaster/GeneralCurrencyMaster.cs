using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralCurrencyMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public string CurrencySymbol
        {
            get;
            set;
        }
        public bool IsBaseCurrency
        {
            get;
            set;
        }
        public string CurrencyName
        {
            get;
            set;
        }
        public Int16 DecimalPlaces
        {
            get;
            set;
        }
        public string Format
        {
            get;
            set;
        }
        public bool IsActive
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
        public int? ModifiedBy
        {
            get;
            set;
        }
        public DateTime? ModifiedDate
        {
            get;
            set;
        }
        public int? DeletedBy
        {
            get;
            set;
        }
        public DateTime? DeletedDate
        {
            get;
            set;
        }
    }
}
