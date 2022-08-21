using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
	public interface IPurchaseRequirementMasterBR
	{
		IValidateBusinessRuleResponse InsertPurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
		IValidateBusinessRuleResponse UpdatePurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
		IValidateBusinessRuleResponse DeletePurchaseRequirementMasterValidate(PurchaseRequirementMaster item);
	}
}
