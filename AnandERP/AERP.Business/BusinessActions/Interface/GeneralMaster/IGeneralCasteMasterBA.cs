using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.Business.BusinessAction
{
    public interface IGeneralCasteMasterBA
    {
        IBaseEntityResponse<GeneralCasteMaster> InsertGeneralCasteMaster(GeneralCasteMaster item);

        IBaseEntityResponse<GeneralCasteMaster> UpdateGeneralCasteMaster(GeneralCasteMaster item);

        IBaseEntityResponse<GeneralCasteMaster> DeleteGeneralCasteMaster(GeneralCasteMaster item);

        IBaseEntityCollectionResponse<GeneralCasteMaster> GetBySearch(GeneralCasteMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralCasteMaster> GetGeneralCasteMasterGetBySearchList(GeneralCasteMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralCasteMaster> SelectByID(GeneralCasteMaster item);
    }
}
