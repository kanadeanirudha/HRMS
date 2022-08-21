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
    public class GeneralTransactionMasterBA : IGeneralTransactionMasterBA
    {
        IGeneralTransactionMasterDataProvider _GeneralTransactionMasterDataProvider;
        IGeneralTransactionMasterBR _GeneralTransactionMasterBR;
        private ILogger _logException;
        public GeneralTransactionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralTransactionMasterBR = new GeneralTransactionMasterBR();
            _GeneralTransactionMasterDataProvider = new GeneralTransactionMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTransactionMaster> InsertGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            IBaseEntityResponse<GeneralTransactionMaster> entityResponse = new BaseEntityResponse<GeneralTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTransactionMasterBR.InsertGeneralTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTransactionMasterDataProvider.InsertGeneralTransactionMaster(item);
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
        /// Update a specific record  of GeneralTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTransactionMaster> UpdateGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            IBaseEntityResponse<GeneralTransactionMaster> entityResponse = new BaseEntityResponse<GeneralTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTransactionMasterBR.UpdateGeneralTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTransactionMasterDataProvider.UpdateGeneralTransactionMaster(item);
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
        /// Delete a selected record from GeneralTransactionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTransactionMaster> DeleteGeneralTransactionMaster(GeneralTransactionMaster item)
        {
            IBaseEntityResponse<GeneralTransactionMaster> entityResponse = new BaseEntityResponse<GeneralTransactionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTransactionMasterBR.DeleteGeneralTransactionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTransactionMasterDataProvider.DeleteGeneralTransactionMaster(item);
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
        /// Select all record from GeneralTransactionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTransactionMaster> GetBySearch(GeneralTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTransactionMaster> GeneralTransactionMasterCollection = new BaseEntityCollectionResponse<GeneralTransactionMaster>();
            try
            {
                if (_GeneralTransactionMasterDataProvider != null)
                    GeneralTransactionMasterCollection = _GeneralTransactionMasterDataProvider.GetGeneralTransactionMasterBySearch(searchRequest);
                else
                {
                    GeneralTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTransactionMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralTransactionMaster> GetGeneralTransactionMasterSearchList(GeneralTransactionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTransactionMaster> GeneralTransactionMasterCollection = new BaseEntityCollectionResponse<GeneralTransactionMaster>();
            try
            {
                if (_GeneralTransactionMasterDataProvider != null)
                    GeneralTransactionMasterCollection = _GeneralTransactionMasterDataProvider.GetGeneralTransactionMasterSearchList(searchRequest);
                else
                {
                    GeneralTransactionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTransactionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTransactionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTransactionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTransactionMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralTransactionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTransactionMaster> SelectByID(GeneralTransactionMaster item)
        {
            IBaseEntityResponse<GeneralTransactionMaster> entityResponse = new BaseEntityResponse<GeneralTransactionMaster>();
            try
            {
                entityResponse = _GeneralTransactionMasterDataProvider.GetGeneralTransactionMasterByID(item);
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
