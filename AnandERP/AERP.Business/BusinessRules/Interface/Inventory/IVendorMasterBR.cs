using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IVendorMasterBR
    {
        IValidateBusinessRuleResponse InsertVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse UpdateVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse DeleteVendorMasterValidate(VendorMaster item);
        IValidateBusinessRuleResponse InsertVendorMasterExcelValidate(VendorMaster item);

    }
}
