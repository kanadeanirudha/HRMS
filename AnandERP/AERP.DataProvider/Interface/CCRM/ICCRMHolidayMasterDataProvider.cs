using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.DataProvider
{
  public  interface ICCRMHolidayMasterDataProvider
    {
        IBaseEntityResponse<CCRMHolidayMaster> InsertCCRMHolidayMaster(CCRMHolidayMaster item);

        IBaseEntityCollectionResponse<CCRMHolidayMaster> GetCCRMHolidayMasterBySearch(CCRMHolidayMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMHolidayMaster> GetCCRMHolidayMasterList(CCRMHolidayMasterSearchRequest searchRequest);
    }
}
