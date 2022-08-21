using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISalesReturnMasterAndDetailsBA
    {
        IBaseEntityResponse<SalesReturnMasterAndDetails> InsertSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityResponse<SalesReturnMasterAndDetails> UpdateSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityResponse<SalesReturnMasterAndDetails> DeleteSalesReturnMasterAndDetails(SalesReturnMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetBySearch(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetSalesReturnMasterAndDetailsSearchList(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesReturnMasterAndDetails> GetDropDownListforSalesReturnMasterAndDetails(SalesReturnMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesReturnMasterAndDetails> SelectByID(SalesReturnMasterAndDetails item);
    }
}

