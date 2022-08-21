using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IOrganisationSubjectGrpRuleBR
	{
		IValidateBusinessRuleResponse InsertOrganisationSubjectGrpRuleValidate(OrganisationSubjectGrpRule item);
		IValidateBusinessRuleResponse UpdateOrganisationSubjectGrpRuleValidate(OrganisationSubjectGrpRule item);
		IValidateBusinessRuleResponse DeleteOrganisationSubjectGrpRuleValidate(OrganisationSubjectGrpRule item);
	}
}
