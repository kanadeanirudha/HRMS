using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPFChallanRemittanceDataProvider
    {
        IBaseEntityCollectionResponse<PFChallanRemittance> GetPFChallanRemittanceDataList(PFChallanRemittanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PFChallanRemittance> GetPFChallanRemittanceDataListForParticularsMonthWise(PFChallanRemittanceSearchRequest searchRequest);
        IBaseEntityResponse<PFChallanRemittance> InsertPFChallanRemittance(PFChallanRemittance item);
    }
}
