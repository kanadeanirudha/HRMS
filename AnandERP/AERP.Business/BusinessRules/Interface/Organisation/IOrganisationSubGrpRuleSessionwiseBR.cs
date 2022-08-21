using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IOrganisationSubGrpRuleSessionwiseBR
	{
		IValidateBusinessRuleResponse InsertOrganisationSubGrpRuleSessionwiseValidate(OrganisationSubGrpRuleSessionwise item);
		IValidateBusinessRuleResponse UpdateOrganisationSubGrpRuleSessionwiseValidate(OrganisationSubGrpRuleSessionwise item);
		IValidateBusinessRuleResponse DeleteOrganisationSubGrpRuleSessionwiseValidate(OrganisationSubGrpRuleSessionwise item);
	}
}
