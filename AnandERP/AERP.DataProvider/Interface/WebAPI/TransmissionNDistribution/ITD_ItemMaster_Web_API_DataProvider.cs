using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ITD_ItemMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<ItemMaster> getItems(ItemMaster item);
    }
}
