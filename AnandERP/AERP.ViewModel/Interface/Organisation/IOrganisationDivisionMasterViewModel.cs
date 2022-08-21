using AMS.DTO;
using System;
namespace AMS.ViewModel
{
    public interface IOrganisationDivisionMasterViewModel
    {
        OrganisationDivisionMaster OrganisationDivisionMasterDTO
        {
            get;
            set;
        }

         int ID
        {
            get;
            set;
        }

         string DivisionDescription
        {
            get;
            set;
        }

         string DivShortCode
        {
            get;
            set;
        }

         string PrintShortCode
        {
            get;
            set;
        }

         bool IsDeleted
        {
            get;
            set;
        }
         bool IsUserDefined { get;set;}
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