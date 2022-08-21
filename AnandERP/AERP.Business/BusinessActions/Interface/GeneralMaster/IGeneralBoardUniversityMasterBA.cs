using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IGeneralBoardUniversityMasterBA
    {
        IBaseEntityResponse<GeneralBoardUniversityMaster> InsertGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityResponse<GeneralBoardUniversityMaster> UpdateGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityResponse<GeneralBoardUniversityMaster> DeleteGeneralBoardUniversityMaster(GeneralBoardUniversityMaster item);
        IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearch(GeneralBoardUniversityMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralBoardUniversityMaster> GetBySearchList(GeneralBoardUniversityMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralBoardUniversityMaster> SelectByID(GeneralBoardUniversityMaster item);
    }
}
