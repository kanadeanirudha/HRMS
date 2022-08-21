using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationBranchMasterBA
	{
		IBaseEntityResponse<OrganisationBranchMaster> InsertOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityResponse<OrganisationBranchMaster> UpdateOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityResponse<OrganisationBranchMaster> DeleteOrganisationBranchMaster(OrganisationBranchMaster item);
		IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBySearch(OrganisationBranchMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBranchListRoleWise(OrganisationBranchMasterSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationBranchMaster> SelectByID(OrganisationBranchMaster item);
	}
}
