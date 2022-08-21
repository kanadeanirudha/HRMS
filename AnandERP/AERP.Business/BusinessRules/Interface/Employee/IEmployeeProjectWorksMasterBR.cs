using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace AMS.Business.BusinessRules
{
	public interface IEmployeeProjectWorksMasterBR
	{
		IValidateBusinessRuleResponse InsertEmployeeProjectWorksMasterValidate(EmployeeProjectWorksMaster item);
		IValidateBusinessRuleResponse UpdateEmployeeProjectWorksMasterValidate(EmployeeProjectWorksMaster item);
		IValidateBusinessRuleResponse DeleteEmployeeProjectWorksMasterValidate(EmployeeProjectWorksMaster item);
	}
}
