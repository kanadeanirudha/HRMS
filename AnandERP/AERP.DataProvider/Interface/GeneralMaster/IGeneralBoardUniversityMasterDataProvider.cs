using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralBoardUniversityMasterDataProvider
    {
        IBaseEntityResponse<GeneralBoardUniversityMaster> InsertGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityResponse<GeneralBoardUniversityMaster> UpdateGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityResponse<GeneralBoardUniversityMaster> DeleteGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetGeneralBoardUniversityMasterBySearch(GeneralBoardUniversityMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetGeneralBoardUniversityMasterBySearchList(GeneralBoardUniversityMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralBoardUniversityMaster> GetGeneralBoardUniversityMasterByID(GeneralBoardUniversityMaster item);
    }
}
