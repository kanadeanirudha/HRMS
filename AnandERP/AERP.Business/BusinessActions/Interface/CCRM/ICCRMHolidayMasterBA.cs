using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessAction
{
   public interface ICCRMHolidayMasterBA
    {
        IBaseEntityResponse<CCRMHolidayMaster> InsertCCRMHolidayMaster(CCRMHolidayMaster item);
        //IBaseEntityResponse<CCRMHolidayMaster> UpdateCCRMHolidayMaster(CCRMHolidayMaster item);
        // IBaseEntityResponse<CCRMHolidayMaster> DeleteCCRMHolidayMaster(CCRMHolidayMaster item);
        // IBaseEntityResponse<CCRMHolidayMaster> SelectByID(CCRMHolidayMaster item);
        IBaseEntityCollectionResponse<CCRMHolidayMaster> GetBySearch(CCRMHolidayMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMHolidayMaster> GetCCRMHolidayMasterList(CCRMHolidayMasterSearchRequest searchRequest);
    }
}
