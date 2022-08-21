using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AccountBalancesheetTypeMaster : BaseDTO
    {
        public byte ID
        {
            get;
            set;
        }
        public string AccBalsheetTypeCode
        {
            get;
            set;
        }
        public string AccBalsheetTypeDesc
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
        public string errorMessage { get; set; }
        public Int16 AccBalsheetType { get; set; }
    }
}
