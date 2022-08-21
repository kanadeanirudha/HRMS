using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractEmployeePFReportBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractEmployeePFReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractEmployeePFReportValidate(SaleContractEmployeePFReport item);

        /// <summary>
        /// business rule interface of update record of SaleContractEmployeePFReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractEmployeePFReportValidate(SaleContractEmployeePFReport item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractEmployeePFReport.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractEmployeePFReportValidate(SaleContractEmployeePFReport item);
    }
}

