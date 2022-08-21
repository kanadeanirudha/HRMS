using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralMainTypeMasterBA
    {
        /// business action interface of insert new record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// business action interface of update record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// business action interface of dalete record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// business action interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearch(GeneralMainTypeMasterSearchRequest searchRequest);

        /// business action interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest);

        /// business action interface of select one record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> SelectByID(GeneralMainTypeMaster item);

        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode.
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item);
    }
}
