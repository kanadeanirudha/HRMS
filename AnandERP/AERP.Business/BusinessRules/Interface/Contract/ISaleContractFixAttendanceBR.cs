using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractFixAttendanceBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractFixAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractFixAttendanceValidate(SaleContractFixAttendance item);

        /// <summary>
        /// business rule interface of update record of SaleContractFixAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractFixAttendanceValidate(SaleContractFixAttendance item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractFixAttendance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractFixAttendanceValidate(SaleContractFixAttendance item);
    }
}

