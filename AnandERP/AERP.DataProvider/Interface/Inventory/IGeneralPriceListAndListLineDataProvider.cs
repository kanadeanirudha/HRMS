using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralPriceListAndListLineDataProvider
    {
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceListAndListLine(GeneralPriceListAndListLine item);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineBySearch(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineSearchList(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineByID(GeneralPriceListAndListLine item);

        //*******************************************************************
        IBaseEntityResponse<GeneralPriceListAndListLine> InsertGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> UpdateGeneralPriceList(GeneralPriceListAndListLine item);
        IBaseEntityResponse<GeneralPriceListAndListLine> DeleteGeneralPriceList(GeneralPriceListAndListLine item);

        IBaseEntityCollectionResponse<GeneralPriceListAndListLine> GetGeneralPriceListAndListLineByGeneralPriceListID(GeneralPriceListAndListLineSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPriceListAndListLine> GetIsRootCount(GeneralPriceListAndListLine item);


    }
}
