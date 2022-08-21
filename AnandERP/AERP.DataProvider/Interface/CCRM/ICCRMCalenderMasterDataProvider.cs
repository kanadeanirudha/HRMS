using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
   public interface ICCRMCalenderMasterDataProvider
    {
        IBaseEntityResponse<CCRMCalenderMaster> InsertCCRMCalenderMaster(CCRMCalenderMaster item);
       
        IBaseEntityCollectionResponse<CCRMCalenderMaster> GetCCRMCalenderMasterBySearch(CCRMCalenderMasterSearchRequest searchRequest);
    }
}
