using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationAdmissionTypeMasterDataProvider
    {
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> InsertOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> UpdateOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> DeleteOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetOrganisationAdmissionTypeMasterBySearch(OrganisationAdmissionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationAdmissionTypeMaster> GetOrganisationAdmissionTypeMasterByID(OrganisationAdmissionTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetOrganisationAdmissionTypeMasterGetBySearchList(OrganisationAdmissionTypeMasterSearchRequest searchRequest);

    }
}
