using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralMovementTypeBA
    {
        IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementType(GeneralMovementType item);
        IBaseEntityResponse<GeneralMovementType> UpdateGeneralMovementType(GeneralMovementType item);
        IBaseEntityResponse<GeneralMovementType> DeleteGeneralMovementType(GeneralMovementType item);

        IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementTypeRules(GeneralMovementType item);
        

        IBaseEntityCollectionResponse<GeneralMovementType> GetBySearch(GeneralMovementTypeSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralMovementType> GetGeneralMovementTypeSearchList(GeneralMovementTypeSearchRequest searchRequest);
        IBaseEntityResponse<GeneralMovementType> SelectByID(GeneralMovementType item);
    }
}

