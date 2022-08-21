using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IOrganisationSubjectMasterBR
	{
		IValidateBusinessRuleResponse InsertOrganisationSubjectMasterValidate(OrganisationSubjectMaster item);
		IValidateBusinessRuleResponse UpdateOrganisationSubjectMasterValidate(OrganisationSubjectMaster item);
		IValidateBusinessRuleResponse DeleteOrganisationSubjectMasterValidate(OrganisationSubjectMaster item);
	}
}
