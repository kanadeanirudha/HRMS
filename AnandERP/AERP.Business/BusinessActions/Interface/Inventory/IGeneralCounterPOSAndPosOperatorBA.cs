using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IGeneralCounterPOSAndPosOperatorBA
    {
        IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListCounterMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetListPOSMaster(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSApplicableBySearch(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCounterPOSAndPosOperator> SelectByID(GeneralCounterPOSAndPosOperator item);

        IBaseEntityResponse<GeneralCounterPOSAndPosOperator> InsertGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item);
        IBaseEntityResponse<GeneralCounterPOSAndPosOperator> UpdateGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item);
        IBaseEntityResponse<GeneralCounterPOSAndPosOperator> DeleteGeneralCounterPOSAndPosOperator(GeneralCounterPOSAndPosOperator item);
        IBaseEntityCollectionResponse<GeneralCounterPOSAndPosOperator> GetGeneralCounterPOSAndPosOperatorSearchList(GeneralCounterPOSAndPosOperatorSearchRequest searchRequest);
       
    }
}

