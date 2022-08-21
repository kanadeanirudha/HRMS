using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public class OrderingAndDeliveryDayBA : IOrderingAndDeliveryDayBA
    {
        IOrderingAndDeliveryDayDataProvider _OrderingAndDeliveryDayDataProvider;
        IOrderingAndDeliveryDayBR _OrderingAndDeliveryDayBR;
        private ILogger _logException;
        public OrderingAndDeliveryDayBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OrderingAndDeliveryDayBR = new OrderingAndDeliveryDayBR();
            _OrderingAndDeliveryDayDataProvider = new OrderingAndDeliveryDayDataProvider();
        }
        /// <summary>
        /// Create new record of OrderingAndDeliveryDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrderingAndDeliveryDay> InsertOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            IBaseEntityResponse<OrderingAndDeliveryDay> entityResponse = new BaseEntityResponse<OrderingAndDeliveryDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrderingAndDeliveryDayBR.InsertOrderingAndDeliveryDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrderingAndDeliveryDayDataProvider.InsertOrderingAndDeliveryDay(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Update a specific record  of OrderingAndDeliveryDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrderingAndDeliveryDay> UpdateOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            IBaseEntityResponse<OrderingAndDeliveryDay> entityResponse = new BaseEntityResponse<OrderingAndDeliveryDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrderingAndDeliveryDayBR.UpdateOrderingAndDeliveryDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrderingAndDeliveryDayDataProvider.UpdateOrderingAndDeliveryDay(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Delete a selected record from OrderingAndDeliveryDay.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrderingAndDeliveryDay> DeleteOrderingAndDeliveryDay(OrderingAndDeliveryDay item)
        {
            IBaseEntityResponse<OrderingAndDeliveryDay> entityResponse = new BaseEntityResponse<OrderingAndDeliveryDay>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrderingAndDeliveryDayBR.DeleteOrderingAndDeliveryDayValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrderingAndDeliveryDayDataProvider.DeleteOrderingAndDeliveryDay(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
        /// <summary>
        /// Select all record from OrderingAndDeliveryDay table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetBySearch(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrderingAndDeliveryDay> OrderingAndDeliveryDayCollection = new BaseEntityCollectionResponse<OrderingAndDeliveryDay>();
            try
            {
                if (_OrderingAndDeliveryDayDataProvider != null)
                    OrderingAndDeliveryDayCollection = _OrderingAndDeliveryDayDataProvider.GetOrderingAndDeliveryDayBySearch(searchRequest);
                else
                {
                    OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrderingAndDeliveryDayCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrderingAndDeliveryDayCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrderingAndDeliveryDayCollection;
        }

        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetOrderingAndDeliveryDaySearchList(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrderingAndDeliveryDay> OrderingAndDeliveryDayCollection = new BaseEntityCollectionResponse<OrderingAndDeliveryDay>();
            try
            {
                if (_OrderingAndDeliveryDayDataProvider != null)
                    OrderingAndDeliveryDayCollection = _OrderingAndDeliveryDayDataProvider.GetOrderingAndDeliveryDaySearchList(searchRequest);
                else
                {
                    OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrderingAndDeliveryDayCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrderingAndDeliveryDayCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrderingAndDeliveryDayCollection;
        }
        /// <summary>
        /// Select a record from OrderingAndDeliveryDay table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrderingAndDeliveryDay> SelectByID(OrderingAndDeliveryDay item)
        {
            IBaseEntityResponse<OrderingAndDeliveryDay> entityResponse = new BaseEntityResponse<OrderingAndDeliveryDay>();
            try
            {
                entityResponse = _OrderingAndDeliveryDayDataProvider.GetOrderingAndDeliveryDayByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        public IBaseEntityCollectionResponse<OrderingAndDeliveryDay> GetDropDownListForOrderingAndDeliveryDay(OrderingAndDeliveryDaySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrderingAndDeliveryDay> OrderingAndDeliveryDayCollection = new BaseEntityCollectionResponse<OrderingAndDeliveryDay>();
            try
            {
                if (_OrderingAndDeliveryDayDataProvider != null)
                    OrderingAndDeliveryDayCollection = _OrderingAndDeliveryDayDataProvider.GetDropDownListForOrderingAndDeliveryDay(searchRequest);
                else
                {
                    OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrderingAndDeliveryDayCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrderingAndDeliveryDayCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrderingAndDeliveryDayCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrderingAndDeliveryDayCollection;
        }
       
    }
}
