using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSemesterMasterDataProvider
    {
        IBaseEntityResponse<OrganisationSemesterMaster> InsertOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityResponse<OrganisationSemesterMaster> UpdateOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityResponse<OrganisationSemesterMaster> DeleteOrganisationSemesterMaster(OrganisationSemesterMaster item);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetOrganisationSemesterMasterBySearch(OrganisationSemesterMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSemesterMaster> GetOrganisationSemesterMasterByID(OrganisationSemesterMaster item);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetOrganisationSemesterMasterGetBySearchList(OrganisationSemesterMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetOrganisationSemesterMasterGetSemester(OrganisationSemesterMasterSearchRequest searchRequest);

    }
}
