using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralBoardUniversityMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralBoardUniversityMasterValidate(GeneralBoardUniversityMaster item);
        IValidateBusinessRuleResponse UpdateGeneralBoardUniversityMasterValidate(GeneralBoardUniversityMaster item);
        IValidateBusinessRuleResponse DeleteGeneralBoardUniversityMasterValidate(GeneralBoardUniversityMaster item);
    }
}
