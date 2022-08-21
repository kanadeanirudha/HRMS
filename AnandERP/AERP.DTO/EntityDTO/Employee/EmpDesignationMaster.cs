using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class EmpDesignationMaster : BaseDTO
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

        public int DesignationLevel
        {
            get;
            set;
        }

        public int Grade
        {
            get;
            set;
        }

        public string ShortCode
        {
            get;
            set;
        }

        public int CollegeID
        {
            get;
            set;
        }

        public string EmpDesigType
        {
            get;
            set;
        }

        public string RelatedWith
        {
            get;
            set;
        }
        public bool IsActive { get; set; }
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
