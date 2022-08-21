using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IEmployeePHdGuideRecognisationDetailsBR
	{
		IValidateBusinessRuleResponse InsertEmployeePHdGuideRecognisationDetailsValidate(EmployeePHdGuideRecognisationDetails item);
		IValidateBusinessRuleResponse UpdateEmployeePHdGuideRecognisationDetailsValidate(EmployeePHdGuideRecognisationDetails item);
		IValidateBusinessRuleResponse DeleteEmployeePHdGuideRecognisationDetailsValidate(EmployeePHdGuideRecognisationDetails item);
	}
}
