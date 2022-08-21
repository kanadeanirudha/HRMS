using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public interface IOrganisationSubGrpRuleSessionwiseBA
	{
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> InsertOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> UpdateOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> DeleteOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item);
		IBaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise> GetBySearch(OrganisationSubGrpRuleSessionwiseSearchRequest searchRequest);
		IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> SelectByID(OrganisationSubGrpRuleSessionwise item);
	}
}
