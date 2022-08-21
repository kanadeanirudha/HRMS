using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISaleContractPayementBA
    {
        IBaseEntityResponse<SaleContractPayement> InsertSaleContractPayement(SaleContractPayement item);
        IBaseEntityResponse<SaleContractPayement> UpdateSaleContractPayement(SaleContractPayement item);
        IBaseEntityResponse<SaleContractPayement> DeleteSaleContractPayement(SaleContractPayement item);
        IBaseEntityCollectionResponse<SaleContractPayement> GetBySearch(SaleContractPayementSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractPayement> SelectByID(SaleContractPayement item);
        IBaseEntityCollectionResponse<SaleContractPayement> GetSaleContractEmployeeByBillingSpanForPayement(SaleContractPayementSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractPayement> GetRecordForPurchaseOrderPDF(SaleContractPayementSearchRequest searchRequest);

    }
}
