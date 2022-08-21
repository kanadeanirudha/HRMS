using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISupplierPayementMasterBR
    {
        IValidateBusinessRuleResponse InsertSupplierPayementMasterValidate(SupplierPayementMaster item);
        IValidateBusinessRuleResponse UpdateSupplierPayementMasterValidate(SupplierPayementMaster item);
        IValidateBusinessRuleResponse DeleteSupplierPayementMasterValidate(SupplierPayementMaster item);
    }
}
