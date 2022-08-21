using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractJobWorkDataBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractJobWorkData.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractJobWorkDataValidate(SaleContractJobWorkData item);

        /// <summary>
        /// business rule interface of update record of SaleContractJobWorkData.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractJobWorkDataValidate(SaleContractJobWorkData item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractJobWorkData.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractJobWorkDataValidate(SaleContractJobWorkData item);
    }
}

