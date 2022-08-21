using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralLeaveDocument : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string DocumentName
        {
            get;
            set;
        }
        public string DocumentType
        {
            get;
            set;
        }
        public string DocumentDescription
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
    }
}
