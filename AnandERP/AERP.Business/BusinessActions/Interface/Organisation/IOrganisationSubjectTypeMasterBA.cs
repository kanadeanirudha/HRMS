using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubjectTypeMasterBA
    {
        IBaseEntityResponse<OrganisationSubjectTypeMaster> InsertOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> UpdateOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item);
        IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySearch(OrganisationSubjectTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySubjectTypeMaterList(OrganisationSubjectTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectTypeMaster> SelectByID(OrganisationSubjectTypeMaster item);
    }
}
