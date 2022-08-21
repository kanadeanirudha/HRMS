using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
	public interface IOrganisationSubGrpRuleSessionwiseDataProvider
	{
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> InsertOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> UpdateOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> DeleteOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise> GetOrganisationSubGrpRuleSessionwiseBySearch(OrganisationSubGrpRuleSessionwiseSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> GetOrganisationSubGrpRuleSessionwiseByID(OrganisationSubGrpRuleSessionwise item);
	}
}
