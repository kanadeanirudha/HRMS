using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IOrganisationSubjectTypeMasterViewModel
    {
        OrganisationSubjectTypeMaster OrganisationSubjectTypeMasterDTO
        {
            get;
            set;
        }

         Int16 ID
        {
            get;
            set;
        }

         string TypeName
        {
            get;
            set;
        }

         string TypeShortCode
        {
            get;
            set;
        }      

         bool IsDeleted
        {
            get;
            set;
        }

         int CreatedBy
        {
            get;
            set;
        }

         DateTime CreatedDate
        {
            get;
            set;
        }

         int? ModifiedBy
        {
            get;
            set;
        }

         DateTime? ModifiedDate
        {
            get;
            set;
        }

         int? DeletedBy
        {
            get;
            set;
        }

         DateTime? DeletedDate
        {
            get;
            set;
        }

    }
}