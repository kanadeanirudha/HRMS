using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralCounterMasterBA
    {
        IBaseEntityResponse<GeneralCounterMaster> InsertGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> UpdateGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityResponse<GeneralCounterMaster> DeleteGeneralCounterMaster(GeneralCounterMaster item);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetBySearch(GeneralCounterMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterSearchList(GeneralCounterMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCounterMaster> SelectByID(GeneralCounterMaster item);
    }
}

