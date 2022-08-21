using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralTaskReportingDetailsBR
    {
        IValidateBusinessRuleResponse InsertGeneralTaskReportingDetailsValidate(GeneralTaskReportingDetails item);
        IValidateBusinessRuleResponse UpdateGeneralTaskReportingDetailsValidate(GeneralTaskReportingDetails item);
        IValidateBusinessRuleResponse DeleteGeneralTaskReportingDetailsValidate(GeneralTaskReportingDetails item);
        IValidateBusinessRuleResponse UpdateEnagedByUserIDValidate(GeneralTaskReportingDetails item);
        
    }
}
