
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralUnitsStorageLocationBR
    {
        IValidateBusinessRuleResponse InsertGeneralUnitsStorageLocationValidate(GeneralUnitsStorageLocation item);
        IValidateBusinessRuleResponse UpdateGeneralUnitsStorageLocationValidate(GeneralUnitsStorageLocation item);
        IValidateBusinessRuleResponse DeleteGeneralUnitsStorageLocationValidate(GeneralUnitsStorageLocation item);
    }
}
