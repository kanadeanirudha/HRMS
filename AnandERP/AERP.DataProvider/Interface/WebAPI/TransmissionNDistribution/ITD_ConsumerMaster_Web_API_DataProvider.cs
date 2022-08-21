using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ITD_ConsumerMaster_Web_API_DataProvider
    {
        IBaseEntityCollectionResponse<ConsumerMaster> getConsumers(ConsumerMaster item);
        IBaseEntityResponse<ConsumerMaster> DeleteConsumer(ConsumerMaster item);
        IBaseEntityResponse<ConsumerMaster> UpdateConsumerLatLong(ConsumerMaster item);
        IBaseEntityResponse<ConsumerMaster> UpdateTappingPointLatLong(ConsumerMaster item);
        IBaseEntityResponse<ConsumerMaster> InsertImage(ConsumerMaster item);
        IBaseEntityResponse<ConsumerMaster> AddConsumerRequirment(ConsumerMaster item);
        IBaseEntityCollectionResponse<ConsumerMaster> generateGroups(ConsumerMaster item);
    }
}
