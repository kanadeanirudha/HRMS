using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
	public interface IOrganisationCentrewiseSessionDataProvider
	{
		IBaseEntityResponse<OrganisationCentrewiseSession> InsertOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityResponse<OrganisationCentrewiseSession> UpdateOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityResponse<OrganisationCentrewiseSession> DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSession item);
		IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetOrganisationCentrewiseSessionBySearch(OrganisationCentrewiseSessionSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationCentrewiseSession> GetOrganisationCentrewiseSessionByID(OrganisationCentrewiseSession item);
        IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCurrentSession(OrganisationCentrewiseSessionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCentreWiseSessionListRoleWise(OrganisationCentrewiseSessionSearchRequest searchRequest);
	}
}
