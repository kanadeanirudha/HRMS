using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ICCRMItemMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<GeneralItemMaster> getItemOnSearchApi(GeneralItemMaster item);
    }
}
