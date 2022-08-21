using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationAllotAdmissionMasterDataProvider
    {
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> InsertOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> UpdateOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> DeleteOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item);
        IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetOrganisationAllotAdmissionMasterBySearch(OrganisationAllotAdmissionMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationAllotAdmissionMaster> GetOrganisationAllotAdmissionMasterByID(OrganisationAllotAdmissionMaster item);
        IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetOrganisationAllotAdmissionMasterGetBySearchList(OrganisationAllotAdmissionMasterSearchRequest searchRequest);

    }
}
