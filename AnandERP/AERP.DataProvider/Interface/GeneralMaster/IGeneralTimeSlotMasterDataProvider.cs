using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralTimeSlotMasterDataProvider
    {
        IBaseEntityResponse<GeneralTimeSlotMaster> InsertGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityResponse<GeneralTimeSlotMaster> UpdateGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityResponse<GeneralTimeSlotMaster> DeleteGeneralTimeSlotMaster(GeneralTimeSlotMaster item);
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetGeneralTimeSlotMasterBySearch(GeneralTimeSlotMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralTimeSlotMaster> GetGeneralTimeSlotMasterByID(GeneralTimeSlotMaster item);
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GeneralTimeSlotMasterSearchList(GeneralTimeSlotMasterSearchRequest searchRequest);
        
        // For GeneralTimeZoneMaster Searchlist
        IBaseEntityCollectionResponse<GeneralTimeSlotMaster> GetGeneralTimeZoneMasterSearchlist(GeneralTimeSlotMasterSearchRequest searchRequest);
        
    }
}
