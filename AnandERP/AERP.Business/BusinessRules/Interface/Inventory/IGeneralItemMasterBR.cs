using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralItemMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralItemMasterValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse UpdateGeneralItemMasterValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemMasterValidate(GeneralItemMaster item);

        IValidateBusinessRuleResponse InsertGeneralItemBarcodesValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemBarcodesValidate(GeneralItemMaster item);

        IValidateBusinessRuleResponse InsertInventoryStoreSpecificInformationValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse InsertGeneralItemMasterExcelValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse InsertGeneralItemSupplierDataForVendorDetailsValidate(GeneralItemMaster item);
        IValidateBusinessRuleResponse DeleteGeneralItemMasterEComImagesValidate(GeneralItemMaster item);
    }
}
