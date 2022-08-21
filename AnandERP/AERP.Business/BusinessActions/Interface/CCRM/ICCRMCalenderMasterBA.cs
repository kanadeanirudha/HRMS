using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessAction
{
   public interface ICCRMCalenderMasterBA
    {
        IBaseEntityResponse<CCRMCalenderMaster> InsertCCRMCalenderMaster(CCRMCalenderMaster item);
        //IBaseEntityResponse<CCRMCalenderMaster> UpdateCCRMCalenderMaster(CCRMCalenderMaster item);
       // IBaseEntityResponse<CCRMCalenderMaster> DeleteCCRMCalenderMaster(CCRMCalenderMaster item);
       // IBaseEntityResponse<CCRMCalenderMaster> SelectByID(CCRMCalenderMaster item);
        IBaseEntityCollectionResponse<CCRMCalenderMaster> GetBySearch(CCRMCalenderMasterSearchRequest searchRequest);
    }
}
