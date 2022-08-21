using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPeriodTypeMasterDataProvider
    {
        IBaseEntityResponse<GeneralPeriodTypeMaster> InsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> UpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> DeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetGeneralPeriodTypeMasterBySearch(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetGeneralPeriodTypeMasterBySearchList(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPeriodTypeMaster> GetGeneralPeriodTypeMasterByID(GeneralPeriodTypeMaster item);
    }
}
