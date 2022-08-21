using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralPriceListAndListLineBA
    {
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetBySearch(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineSearchList(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceListAndListLine> SelectByID(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> GetIsRootCount(GeneralPriceListAndListLine item);

        //*****************************************************************************************************
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> SelectByGeneralPriceListID(GeneralPriceListAndListLineSearchRequest searchRequest);
    }
}

