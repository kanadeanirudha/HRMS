using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IAccountVoucherSettingMasterBR
    {
        IValidateBusinessRuleResponse InsertAccountVoucherSettingMasterValidate(AccountVoucherSettingMaster item);
        IValidateBusinessRuleResponse UpdateAccountVoucherSettingMasterValidate(AccountVoucherSettingMaster item);
        IValidateBusinessRuleResponse DeleteAccountVoucherSettingMasterValidate(AccountVoucherSettingMaster item);
    }
}
