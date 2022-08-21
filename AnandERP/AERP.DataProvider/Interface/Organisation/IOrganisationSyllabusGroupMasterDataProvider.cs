using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IOrganisationSyllabusGroupMasterDataProvider
	{
		IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item);
		IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item);
		IBaseEntityResponse<OrganisationSyllabusGroupMaster> DeleteOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item);
		IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusGroupMasterBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusGroupMasterByID(OrganisationSyllabusGroupMaster item);


        //Interface methods for table OrgSyllabusGroupDetails
        IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item);
        IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item);
        IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusDetailsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusDetailsByID(OrganisationSyllabusGroupMaster item);

        //Interface methods for table OrgSyllabusGroupTopics

        IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item);
        IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item);
        IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusTopicsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusTopicsByID(OrganisationSyllabusGroupMaster item);
	}
}
