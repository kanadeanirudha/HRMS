using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class SalePromotionPlanAndDetailsBA : ISalePromotionPlanAndDetailsBA
    {
        ISalePromotionPlanAndDetailsDataProvider _SalePromotionPlanAndDetailsDataProvider;
        ISalePromotionPlanAndDetailsBR _SalePromotionPlanAndDetailsBR;
        private ILogger _logException;
        public SalePromotionPlanAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalePromotionPlanAndDetailsBR = new SalePromotionPlanAndDetailsBR();
            _SalePromotionPlanAndDetailsDataProvider = new SalePromotionPlanAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalePromotionPlanAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            IBaseEntityResponse<SalePromotionPlanAndDetails> entityResponse = new BaseEntityResponse<SalePromotionPlanAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionPlanAndDetailsBR.InsertSalePromotionPlanAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionPlanAndDetailsDataProvider.InsertSalePromotionPlanAndDetails(item);
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
        /// Update a specific record  of SalePromotionPlanAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<SalePromotionPlanAndDetails> InsertSalePromotionPlan(SalePromotionPlanAndDetails item)
        {
            IBaseEntityResponse<SalePromotionPlanAndDetails> entityResponse = new BaseEntityResponse<SalePromotionPlanAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionPlanAndDetailsBR.InsertSalePromotionPlanValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionPlanAndDetailsDataProvider.InsertSalePromotionPlan(item);
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
        public IBaseEntityResponse<SalePromotionPlanAndDetails> UpdateSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            IBaseEntityResponse<SalePromotionPlanAndDetails> entityResponse = new BaseEntityResponse<SalePromotionPlanAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionPlanAndDetailsBR.UpdateSalePromotionPlanAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionPlanAndDetailsDataProvider.UpdateSalePromotionPlanAndDetails(item);
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
        /// Delete a selected record from SalePromotionPlanAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionPlanAndDetails> DeleteSalePromotionPlanAndDetails(SalePromotionPlanAndDetails item)
        {
            IBaseEntityResponse<SalePromotionPlanAndDetails> entityResponse = new BaseEntityResponse<SalePromotionPlanAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionPlanAndDetailsBR.DeleteSalePromotionPlanAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionPlanAndDetailsDataProvider.DeleteSalePromotionPlanAndDetails(item);
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
        /// Select all record from SalePromotionPlanAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBySearch(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionPlanAndDetails>();
            try
            {
                if (_SalePromotionPlanAndDetailsDataProvider != null)
                    SalePromotionPlanAndDetailsCollection = _SalePromotionPlanAndDetailsDataProvider.GetSalePromotionPlanAndDetailsBySearch(searchRequest);
                else
                {
                    SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionPlanAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetSalePromotionPlanAndDetailsSearchList(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionPlanAndDetails>();
            try
            {
                if (_SalePromotionPlanAndDetailsDataProvider != null)
                    SalePromotionPlanAndDetailsCollection = _SalePromotionPlanAndDetailsDataProvider.GetSalePromotionPlanAndDetailsSearchList(searchRequest);
                else
                {
                    SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionPlanAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalePromotionPlanAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionPlanAndDetails> SelectByID(SalePromotionPlanAndDetails item)
        {
            IBaseEntityResponse<SalePromotionPlanAndDetails> entityResponse = new BaseEntityResponse<SalePromotionPlanAndDetails>();
            try
            {
                entityResponse = _SalePromotionPlanAndDetailsDataProvider.GetSalePromotionPlanAndDetailsByID(item);
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

        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetPlanDescriptionByPlanCode(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionPlanAndDetails>();
            try
            {
                if (_SalePromotionPlanAndDetailsDataProvider != null)
                    SalePromotionPlanAndDetailsCollection = _SalePromotionPlanAndDetailsDataProvider.GetPlanDescriptionByPlanCode(searchRequest);
                else
                {
                    SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionPlanAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetDiscountInPercentLIst(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionPlanAndDetails>();
            try
            {
                if (_SalePromotionPlanAndDetailsDataProvider != null)
                    SalePromotionPlanAndDetailsCollection = _SalePromotionPlanAndDetailsDataProvider.GetDiscountInPercentLIst(searchRequest);
                else
                {
                    SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionPlanAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> GetBillAmountrangeForGiftVoucher(SalePromotionPlanAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionPlanAndDetails> SalePromotionPlanAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionPlanAndDetails>();
            try
            {
                if (_SalePromotionPlanAndDetailsDataProvider != null)
                    SalePromotionPlanAndDetailsCollection = _SalePromotionPlanAndDetailsDataProvider.GetBillAmountrangeForGiftVoucher(searchRequest);
                else
                {
                    SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionPlanAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionPlanAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionPlanAndDetailsCollection.CollectionResponse = null
                    ;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionPlanAndDetailsCollection;
        }
    }
}
