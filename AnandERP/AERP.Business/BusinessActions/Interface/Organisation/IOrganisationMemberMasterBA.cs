using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IOrganisationMemberMasterBA
	{
		IBaseEntityResponse<OrganisationMemberMaster> InsertOrganisationMemberMaster(OrganisationMemberMaster item);
		IBaseEntityResponse<OrganisationMemberMaster> UpdateOrganisationMemberMaster(OrganisationMemberMaster item);
		IBaseEntityResponse<OrganisationMemberMaster> DeleteOrganisationMemberMaster(OrganisationMemberMaster item);
		IBaseEntityCollectionResponse<OrganisationMemberMaster> GetBySearch(OrganisationMemberMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationMemberMaster> GetUserEntityCentrewiseSearchList(OrganisationMemberMasterSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationMemberMaster> SelectByID(OrganisationMemberMaster item);
	}
}
