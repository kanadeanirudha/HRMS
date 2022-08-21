using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessActions
{
    public interface ILeaveDeductRuleExceptionForCentreBA
    {
        /// <summary>
        /// business action interface of insert new record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// business action interface of update record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// business action interface of dalete record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// business action interface of select all record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> SelectByID(LeaveDeductRuleExceptionForCentre item);
    }
}
