using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
	public interface IEmployeeConsultancyMasterBR
	{
		IValidateBusinessRuleResponse InsertEmployeeConsultancyMasterValidate(EmployeeConsultancyMaster item);
		IValidateBusinessRuleResponse UpdateEmployeeConsultancyMasterValidate(EmployeeConsultancyMaster item);
		IValidateBusinessRuleResponse DeleteEmployeeConsultancyMasterValidate(EmployeeConsultancyMaster item);
	}
}
