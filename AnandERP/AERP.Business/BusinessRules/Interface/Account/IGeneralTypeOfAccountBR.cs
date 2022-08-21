using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
	public interface IGeneralTypeOfAccountBR
	{
		IValidateBusinessRuleResponse InsertGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
		IValidateBusinessRuleResponse UpdateGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
		IValidateBusinessRuleResponse DeleteGeneralTypeOfAccountValidate(GeneralTypeOfAccount item);
	}
}
