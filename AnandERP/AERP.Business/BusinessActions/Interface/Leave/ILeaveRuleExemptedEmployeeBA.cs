using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveRuleExemptedEmployeeBA
    {
        IBaseEntityResponse<LeaveRuleExemptedEmployee> InsertLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> UpdateLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item);
        IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> GetBySearch(LeaveRuleExemptedEmployeeSearchRequest searchRequest);
        IBaseEntityResponse<LeaveRuleExemptedEmployee> SelectByID(LeaveRuleExemptedEmployee item);
    }
}
