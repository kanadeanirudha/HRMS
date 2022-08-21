using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IOrderingAndDeliveryDayBA
    {
        IBaseEntityResponse<OrderingAndDeliveryDay> InsertOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityResponse<OrderingAndDeliveryDay> UpdateOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityResponse<OrderingAndDeliveryDay> DeleteOrderingAndDeliveryDay(OrderingAndDeliveryDay item);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetBySearch(OrderingAndDeliveryDaySearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetOrderingAndDeliveryDaySearchList(OrderingAndDeliveryDaySearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetDropDownListForOrderingAndDeliveryDay(OrderingAndDeliveryDaySearchRequest searchRequest);
       
        IBaseEntityResponse<OrderingAndDeliveryDay> SelectByID(OrderingAndDeliveryDay item);
    }
}

