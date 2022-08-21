using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessAction
{
  public   interface ICCRMCustomerSegementBA
    {
        IBaseEntityResponse<CCRMCustomerSegement> InsertCCRMCustomerSegement(CCRMCustomerSegement item);

        IBaseEntityResponse<CCRMCustomerSegement> UpdateCCRMCustomerSegement(CCRMCustomerSegement item);
        IBaseEntityResponse<CCRMCustomerSegement> DeleteCCRMCustomerSegement(CCRMCustomerSegement item);
        IBaseEntityResponse<CCRMCustomerSegement> SelectByID(CCRMCustomerSegement item);
        IBaseEntityCollectionResponse<CCRMCustomerSegement> GetBySearch(CCRMCustomerSegementSearchRequest searchRequest);
        IBaseEntityCollectionResponse<CCRMCustomerSegement> GetCCRMCustomerSegementList(CCRMCustomerSegementSearchRequest searchRequest);
    }
}
