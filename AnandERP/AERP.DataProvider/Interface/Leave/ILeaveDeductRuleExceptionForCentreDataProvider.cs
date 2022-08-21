using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveDeductRuleExceptionForCentreDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreGetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> GetLeaveDeductRuleExceptionForCentreByID(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// data provider interface of insert new record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// data provider interface of update record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);

        /// <summary>
        /// data provider interface of dalete record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item);
    }
}
