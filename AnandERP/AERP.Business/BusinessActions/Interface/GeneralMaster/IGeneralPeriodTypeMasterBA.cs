using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessAction
{
    public interface IGeneralPeriodTypeMasterBA
    {
        IBaseEntityResponse<GeneralPeriodTypeMaster> InsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> UpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityResponse<GeneralPeriodTypeMaster> DeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearch(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearchList(GeneralPeriodTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPeriodTypeMaster> SelectByID(GeneralPeriodTypeMaster item);
    }
}
