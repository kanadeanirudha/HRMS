using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IOrganisationCentrewiseSessionBR
	{
		IValidateBusinessRuleResponse InsertOrganisationCentrewiseSessionValidate(OrganisationCentrewiseSession item);
		IValidateBusinessRuleResponse UpdateOrganisationCentrewiseSessionValidate(OrganisationCentrewiseSession item);
		IValidateBusinessRuleResponse DeleteOrganisationCentrewiseSessionValidate(OrganisationCentrewiseSession item);
	}
}
