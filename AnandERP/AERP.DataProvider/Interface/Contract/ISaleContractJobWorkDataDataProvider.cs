using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractJobWorkDataDataProvider
    {
        IBaseEntityCollectionResponse<SaleContractJobWorkData> GetJobWorkDataList(SaleContractJobWorkDataSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractJobWorkData> InsertSaleContractJobWorkData(SaleContractJobWorkData item);
    }
}
