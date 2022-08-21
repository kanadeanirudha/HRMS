using AMS.DTO;
using System;
using System.Collections.Generic;
namespace AMS.ViewModel
{
    public interface IOrganisationMemberMasterViewModel
    {
        OrganisationMemberMaster OrganisationMemberMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        int PersonID
        {
            get;
            set;
        }
        string PersonType
        {
            get;
            set;
        }
        string JoiningDate
        {
            get;
            set;
        }
        string LeavingDate
        {
            get;
            set;
        }
        decimal ShareQuantity
        {
            get;
            set;
        }
        decimal EachSharePrice
        {
            get;
            set;
        }
        string CentreCode
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string MiddleName
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;
        }
        string TransDate
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
        string EntityLevel
        {
            get;
            set;
        }
        string CentreName
        {
            get;
            set;
        }
         List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster { get; set; }
         List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre { get; set; }
    }
}
