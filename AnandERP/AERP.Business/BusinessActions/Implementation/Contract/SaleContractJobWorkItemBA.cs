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
    public class SaleContractJobWorkItemBA : ISaleContractJobWorkItemBA
    {
        ISaleContractJobWorkItemDataProvider _generalRegionMasterDataProvider;
        ISaleContractJobWorkItemBR _generalRegionMasterBR;
        private ILogger _logException;

        public SaleContractJobWorkItemBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SaleContractJobWorkItemBR();
            _generalRegionMasterDataProvider = new SaleContractJobWorkItemDataProvider();
        }

        /// <summary>
        /// Create new record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractJobWorkItem> InsertSaleContractJobWorkItem(SaleContractJobWorkItem item)
        {
            IBaseEntityResponse<SaleContractJobWorkItem> entityResponse = new BaseEntityResponse<SaleContractJobWorkItem>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertSaleContractJobWorkItemValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertSaleContractJobWorkItem(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractJobWorkItem> UpdateSaleContractJobWorkItem(SaleContractJobWorkItem item)
        {
            IBaseEntityResponse<SaleContractJobWorkItem> entityResponse = new BaseEntityResponse<SaleContractJobWorkItem>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateSaleContractJobWorkItemValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateSaleContractJobWorkItem(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractJobWorkItem> DeleteSaleContractJobWorkItem(SaleContractJobWorkItem item)
        {
            IBaseEntityResponse<SaleContractJobWorkItem> entityResponse = new BaseEntityResponse<SaleContractJobWorkItem>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteSaleContractJobWorkItemValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteSaleContractJobWorkItem(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from SaleContractJobWorkItem table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetBySearch(SaleContractJobWorkItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractJobWorkItem> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractJobWorkItem>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractJobWorkItemBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from SaleContractJobWorkItem table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetBySearchList(SaleContractJobWorkItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractJobWorkItem> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractJobWorkItem>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetSaleContractJobWorkItemGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from SaleContractJobWorkItem table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractJobWorkItem> SelectByID(SaleContractJobWorkItem item)
        {

            IBaseEntityResponse<SaleContractJobWorkItem> entityResponse = new BaseEntityResponse<SaleContractJobWorkItem>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetSaleContractJobWorkItemByID(item);
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

        public IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetJobWorkItemBySearchWord(SaleContractJobWorkItemSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractJobWorkItem> categoryMasterCollection = new BaseEntityCollectionResponse<SaleContractJobWorkItem>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetJobWorkItemBySearchWord(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }
    }
}