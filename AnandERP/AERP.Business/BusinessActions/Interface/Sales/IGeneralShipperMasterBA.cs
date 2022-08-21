using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralShipperMasterBA
    {
        IBaseEntityResponse<GeneralShipperMaster> InsertGeneralShipperMaster(GeneralShipperMaster item);
        IBaseEntityResponse<GeneralShipperMaster> UpdateGeneralShipperMaster(GeneralShipperMaster item);
        IBaseEntityResponse<GeneralShipperMaster> DeleteGeneralShipperMaster(GeneralShipperMaster item);
        IBaseEntityCollectionResponse<GeneralShipperMaster> GetBySearch(GeneralShipperMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralShipperMaster> GetGeneralShipperMasterSearchList(GeneralShipperMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralShipperMaster> GetDropDownListforGeneralShipperMaster(GeneralShipperMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralShipperMaster> SelectByID(GeneralShipperMaster item);
    }
}

