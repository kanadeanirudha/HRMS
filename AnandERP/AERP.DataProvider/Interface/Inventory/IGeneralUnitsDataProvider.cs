using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralUnitsDataProvider
    {
        IBaseEntityResponse<GeneralUnits> InsertGeneralUnits(GeneralUnits item);
        IBaseEntityResponse<GeneralUnits> UpdateGeneralUnits(GeneralUnits item);
        IBaseEntityResponse<GeneralUnits> DeleteGeneralUnits(GeneralUnits item);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsBySearch(GeneralUnitsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchList(GeneralUnitsSearchRequest searchRequest);
        IBaseEntityResponse<GeneralUnits> GetGeneralUnitsByID(GeneralUnits item);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsByCentreCode(GeneralUnitsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchListByAdminRoleIDAndCentre(GeneralUnitsSearchRequest searchRequest); 
    }
}
