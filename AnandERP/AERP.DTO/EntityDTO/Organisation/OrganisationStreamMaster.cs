using System;
using AMS.Base.DTO;

namespace AMS.DTO
{
    public class OrganisationStreamMaster : BaseDTO
    { 
        public int ID
        {
            get;
            set;
        }
        public int StreamID
        {
            get;
            set;
        }
        public string StreamDescription
        {
            get;
            set;
        }

        public int DivisionID
        {
            get;
            set;
        }

        public string StreamShortCode
        {
            get;
            set;
        }

        public string PrintShortCode
        {
            get;
            set;
        }
        public bool IsUserDefined { get; set; }
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
