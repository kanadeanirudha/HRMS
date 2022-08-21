using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISaleContractRecieptBA
    {
        IBaseEntityResponse<SaleContractReciept> InsertSaleContractReciept(SaleContractReciept item);
        IBaseEntityResponse<SaleContractReciept> UpdateSaleContractReciept(SaleContractReciept item);
        IBaseEntityResponse<SaleContractReciept> DeleteSaleContractReciept(SaleContractReciept item);
        IBaseEntityCollectionResponse<SaleContractReciept> GetBySearch(SaleContractRecieptSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractReciept> SelectByID(SaleContractReciept item);
        IBaseEntityCollectionResponse<SaleContractReciept> GetCustomerWiseContractDetailsForReciept(SaleContractRecieptSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractReciept> GetRecordForPurchaseOrderPDF(SaleContractRecieptSearchRequest searchRequest);

    }
}
