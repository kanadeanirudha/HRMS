using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IGeneralPreTablesForMainTypeMasterDataProvider
    {
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> InsertGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> UpdateGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item);
        IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeMasterBySearch(GeneralPreTablesForMainTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeMasterByID(GeneralPreTablesForMainTypeMaster item);
    }
}
