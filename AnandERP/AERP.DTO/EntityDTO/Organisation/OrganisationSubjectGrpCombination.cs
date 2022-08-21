using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class OrganisationSubjectGrpCombination : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int SubjectGroupID
        {
            get;
            set;
        }
        public Int16 SubjectTypeNumber
        {
            get;
            set;
        }
        public string ActiveFlag
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
