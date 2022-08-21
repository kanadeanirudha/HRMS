using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralTransactionMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralTransactionMasterValidate(GeneralTransactionMaster item);
        IValidateBusinessRuleResponse UpdateGeneralTransactionMasterValidate(GeneralTransactionMaster item);
        IValidateBusinessRuleResponse DeleteGeneralTransactionMasterValidate(GeneralTransactionMaster item);
    }
}
