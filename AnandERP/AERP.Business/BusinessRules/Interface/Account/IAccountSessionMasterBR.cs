using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
	public interface IAccountSessionMasterBR
	{
		IValidateBusinessRuleResponse InsertAccountSessionMasterValidate(AccountSessionMaster item);
		IValidateBusinessRuleResponse UpdateAccountSessionMasterValidate(AccountSessionMaster item);
		IValidateBusinessRuleResponse DeleteAccountSessionMasterValidate(AccountSessionMaster item);
        IValidateBusinessRuleResponse InsertAccountYearEndJobValidate(AccountSessionMaster item);
    }
}
