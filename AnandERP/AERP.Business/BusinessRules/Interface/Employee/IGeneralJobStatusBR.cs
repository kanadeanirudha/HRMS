using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralJobStatusBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralJobStatusValidate(GeneralJobStatus item);

        /// <summary>
        /// business rule interface of update record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralJobStatusValidate(GeneralJobStatus item);

        /// <summary>
        /// business rule interface of dalete record of GeneralJobStatus.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralJobStatusValidate(GeneralJobStatus item);
    }
}
