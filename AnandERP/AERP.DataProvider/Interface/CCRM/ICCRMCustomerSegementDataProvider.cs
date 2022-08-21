using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.DataProvider
{
   public interface ICCRMCustomerSegementDataProvider
    {
        IBaseEntityResponse<CCRMCustomerSegement> InsertCCRMCustomerSegement(CCRMCustomerSegement item);
        IBaseEntityResponse<CCRMCustomerSegement> UpdateCCRMCustomerSegement(CCRMCustomerSegement item);
        IBaseEntityResponse<CCRMCustomerSegement> DeleteCCRMCustomerSegement(CCRMCustomerSegement item);
        IBaseEntityResponse<CCRMCustomerSegement> GetCCRMCustomerSegementByID(CCRMCustomerSegement item);
        IBaseEntityCollectionResponse<CCRMCustomerSegement> GetCCRMCustomerSegementBySearch(CCRMCustomerSegementSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCustomerSegement> GetCCRMCustomerSegementList(CCRMCustomerSegementSearchRequest searchRequest);


    }
}
