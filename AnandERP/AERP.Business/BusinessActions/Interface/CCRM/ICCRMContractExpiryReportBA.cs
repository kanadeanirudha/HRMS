using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessActions
{
  public  interface ICCRMContractExpiryReportBA
    {
        IBaseEntityCollectionResponse<CCRMContractExpiryReport> GetCCRMContractExpiryReportBySearch_AllContractExpiry(CCRMContractExpiryReportSearchRequest searchRequest);
    }
}
