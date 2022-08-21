using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSubjectTypeMasterDataProvider
    {
        IBaseEntityResponse<OrganisationSubjectTypeMaster> InsertOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> UpdateOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetOrganisationSubjectTypeMasterBySearch(OrganisationSubjectTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetOrganisationSubjectTypeMasterBySearchList(OrganisationSubjectTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> GetOrganisationSubjectTypeMasterByID(OrganisationSubjectTypeMaster item);
    }
}
