using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractPayementDataProvider
    {
        IBaseEntityResponse<SaleContractPayement> InsertSaleContractPayement(SaleContractPayement item);
        IBaseEntityResponse<SaleContractPayement> UpdateSaleContractPayement(SaleContractPayement item);
        IBaseEntityResponse<SaleContractPayement> DeleteSaleContractPayement(SaleContractPayement item);
        IBaseEntityCollectionResponse<SaleContractPayement> GetSaleContractPayementBySearch(SaleContractPayementSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractPayement> GetSaleContractPayementByID(SaleContractPayement item);
        IBaseEntityCollectionResponse<SaleContractPayement> GetSaleContractEmployeeByBillingSpanForPayement(SaleContractPayementSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractPayement> GetRecordForPurchaseOrderPDF(SaleContractPayementSearchRequest searchRequest);

    }
}
