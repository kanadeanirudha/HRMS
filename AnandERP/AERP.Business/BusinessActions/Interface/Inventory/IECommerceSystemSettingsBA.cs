
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IECommerceSystemSettingsBA
    {
        IBaseEntityResponse<ECommerceSystemSettings> InsertECommerceSystemSettings(ECommerceSystemSettings item);
        IBaseEntityCollectionResponse<ECommerceSystemSettings> GetBySearch(ECommerceSystemSettingsSearchRequest searchRequest);
    }

}

