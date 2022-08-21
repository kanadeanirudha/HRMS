using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IOrganisationSubjectMasterDataProvider
	{
		IBaseEntityResponse<OrganisationSubjectMaster> InsertOrganisationSubjectMaster(OrganisationSubjectMaster item);
		IBaseEntityResponse<OrganisationSubjectMaster> UpdateOrganisationSubjectMaster(OrganisationSubjectMaster item);
		IBaseEntityResponse<OrganisationSubjectMaster> DeleteOrganisationSubjectMaster(OrganisationSubjectMaster item);
		IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetOrganisationSubjectMasterBySearch(OrganisationSubjectMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetOrganisationSubjectMasterBySearchList(OrganisationSubjectMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetSubjectList(OrganisationSubjectMasterSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationSubjectMaster> GetOrganisationSubjectMasterByID(OrganisationSubjectMaster item);
	}
}
