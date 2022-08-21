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
    public class BankMasterBA : IBankMasterBA
    {
        IBankMasterDataProvider _BankMasterDataProvider;
        
        private ILogger _logException;

        public BankMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _BankMasterDataProvider = new BankMasterDataProvider();
        }

        /// <summary>
        /// Create new record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BankMaster> InsertBankMaster(BankMaster item)
        {
            IBaseEntityResponse<BankMaster> entityResponse = new BaseEntityResponse<BankMaster>();
            try
            {
                if (_BankMasterDataProvider != null)
                {
                    entityResponse = _BankMasterDataProvider.InsertBankMaster(item);
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
        /// Update a specific record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BankMaster> UpdateBankMaster(BankMaster item)
        {
            IBaseEntityResponse<BankMaster> entityResponse = new BaseEntityResponse<BankMaster>();
            try
            {
                if (_BankMasterDataProvider != null)
                {
                    entityResponse = _BankMasterDataProvider.UpdateBankMaster(item);
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
        /// Delete a selected record from BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BankMaster> DeleteBankMaster(BankMaster item)
        {
            IBaseEntityResponse<BankMaster> entityResponse = new BaseEntityResponse<BankMaster>();
            try
            {
                if (_BankMasterDataProvider != null)
                {
                    entityResponse = _BankMasterDataProvider.DeleteBankMaster(item);
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
        /// Select all record from BankMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<BankMaster> GetBySearch(BankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BankMaster> categoryMasterCollection = new BaseEntityCollectionResponse<BankMaster>();
            try
            {
                if (_BankMasterDataProvider != null)
                {
                    categoryMasterCollection = _BankMasterDataProvider.GetBankMasterBySearch(searchRequest);
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
        /// Select all record from BankMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<BankMaster> GetBySearchList(BankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BankMaster> categoryMasterCollection = new BaseEntityCollectionResponse<BankMaster>();
            try
            {
                if (_BankMasterDataProvider != null)
                {
                    categoryMasterCollection = _BankMasterDataProvider.GetBankMasterGetBySearchList(searchRequest);
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
        /// Select a record from BankMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BankMaster> SelectByID(BankMaster item)
        {

            IBaseEntityResponse<BankMaster> entityResponse = new BaseEntityResponse<BankMaster>();
            try
            {
                entityResponse = _BankMasterDataProvider.GetBankMasterByID(item);
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
    }
}