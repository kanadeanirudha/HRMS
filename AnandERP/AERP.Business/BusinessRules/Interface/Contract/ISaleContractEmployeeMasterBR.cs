using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractEmployeeMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item);

        /// <summary>
        /// business rule interface of update record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item);
        IValidateBusinessRuleResponse InsertSaleContractEmployeeMasterExcelUploadValidate(SaleContractEmployeeMaster item);
    }
}

