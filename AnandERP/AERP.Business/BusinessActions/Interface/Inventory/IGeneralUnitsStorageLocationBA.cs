using System;
using AERP.Base.DTO;
using AERP.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralUnitsStorageLocationBA
    {
        IBaseEntityResponse<GeneralUnitsStorageLocation> InsertGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> UpdateGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> DeleteGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetBySearch(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationSearchList(GeneralUnitsStorageLocationSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnitsStorageLocation> SelectByID(GeneralUnitsStorageLocation item);
        IBaseEntityResponse<GeneralUnitsStorageLocation> CheckFocusOnAction(GeneralUnitsStorageLocation item);
        IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetStorageLocationForRequisition(GeneralUnitsStorageLocationSearchRequest searchRequest);
    }
}

