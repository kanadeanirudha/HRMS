using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IGeneralMainTypeMasterDataProvider
    {
        /// data provider interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterBySearch(GeneralMainTypeMasterSearchRequest searchRequest);

        /// data provider interface of select all record of GeneralMainTypeMaster.
        IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterGetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest);

        /// data provider interface of select one record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> GetGeneralMainTypeMasterByID(GeneralMainTypeMaster item);

        /// data provider interface of insert new record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// data provider interface of update record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item);

        /// data provider interface of dalete record of GeneralMainTypeMaster.
        IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item);

        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode.
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item);
    }
}
