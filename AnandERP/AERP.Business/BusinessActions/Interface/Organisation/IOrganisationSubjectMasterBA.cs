using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubjectMasterBA
    {
        IBaseEntityResponse<OrganisationSubjectMaster> InsertOrganisationSubjectMaster(OrganisationSubjectMaster item);
        IBaseEntityResponse<OrganisationSubjectMaster> UpdateOrganisationSubjectMaster(OrganisationSubjectMaster item);
        IBaseEntityResponse<OrganisationSubjectMaster> DeleteOrganisationSubjectMaster(OrganisationSubjectMaster item);
        IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearch(OrganisationSubjectMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearchList(OrganisationSubjectMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetSubjectList(OrganisationSubjectMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectMaster> SelectByID(OrganisationSubjectMaster item);
    }
}
