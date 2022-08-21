using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IOrganisationSyllabusGroupMasterBR
	{
		IValidateBusinessRuleResponse InsertOrganisationSyllabusGroupMasterValidate(OrganisationSyllabusGroupMaster item);
		IValidateBusinessRuleResponse UpdateOrganisationSyllabusGroupMasterValidate(OrganisationSyllabusGroupMaster item);
		IValidateBusinessRuleResponse DeleteOrganisationSyllabusGroupMasterValidate(OrganisationSyllabusGroupMaster item);
	}
}
