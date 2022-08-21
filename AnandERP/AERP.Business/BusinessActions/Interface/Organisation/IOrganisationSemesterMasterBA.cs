using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSemesterMasterBA
    {
        IBaseEntityResponse<OrganisationSemesterMaster> InsertOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityResponse<OrganisationSemesterMaster> UpdateOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityResponse<OrganisationSemesterMaster> DeleteOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearch(OrganisationSemesterMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSemesterMaster> SelectByID(OrganisationSemesterMaster item);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearchList(OrganisationSemesterMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetSemester(OrganisationSemesterMasterSearchRequest searchRequest);
    }
}
