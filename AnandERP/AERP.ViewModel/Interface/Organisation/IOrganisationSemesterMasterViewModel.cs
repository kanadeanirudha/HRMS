using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IOrganisationSemesterMasterViewModel
    {
        OrganisationSemesterMaster OrganisationSemesterMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string OrgSemesterName
        {
            get;
            set;
        }

        string SemesterType
        {
            get;
            set;
        }

        string SemesterCode
        {
            get;
            set;
        }
        bool IsUserDefined { get; set; }
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