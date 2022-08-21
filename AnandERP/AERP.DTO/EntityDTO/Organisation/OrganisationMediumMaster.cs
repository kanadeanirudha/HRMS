using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationMediumMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public string CodeShortCode
        {
            get;
            set;
        }
        public string PrintShortCode
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
        public bool IsUserDefined { get; set; }
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
