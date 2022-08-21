using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IOrganisationStreamMasterViewModel
    {
        OrganisationStreamMaster OrganisationStreamMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        int DivisionID
        {
            get;
            set;
        }

        string StreamDescription
        {
            get;
            set;
        }

        string StreamShortCode
        {
            get;
            set;
        }

        string PrintShortCode
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
    public interface IOrganisationStreamMasterBaseViewModel
    {

        List<OrganisationStreamMaster> ListOrganisationStreamMaster
        {
            get;
            set;
        }
    }
}