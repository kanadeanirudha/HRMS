
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IOrganisationBranchMasterDataProvider
	{
		IBaseEntityResponse<OrganisationBranchMaster> InsertOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityResponse<OrganisationBranchMaster> UpdateOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityResponse<OrganisationBranchMaster> DeleteOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityCollectionResponse<OrganisationBranchMaster> GetOrganisationBranchMasterBySearch(OrganisationBranchMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBranchListRoleWise(OrganisationBranchMasterSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationBranchMaster> GetOrganisationBranchMasterByID(OrganisationBranchMaster item);
	}
}
