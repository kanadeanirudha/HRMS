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

namespace AERP.Business.BusinessActions
{
    public class GeneralRequestMasterBA: IGeneralRequestMasterBA
    {
        IGeneralRequestMasterDataProvider _GeneralRequestMasterDataProvider;
        IGeneralRequestMasterBR _GeneralRequestMasterBR;
        private ILogger _logException;
        public GeneralRequestMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralRequestMasterBR = new GeneralRequestMasterBR();
            _GeneralRequestMasterDataProvider = new GeneralRequestMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralRequestMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRequestMaster> InsertGeneralRequestMaster(GeneralRequestMaster item)
        {
            IBaseEntityResponse<GeneralRequestMaster> entityResponse = new BaseEntityResponse<GeneralRequestMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRequestMasterBR.InsertGeneralRequestMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRequestMasterDataProvider.InsertGeneralRequestMaster(item);
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
        /// Update a specific record  of GeneralRequestMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRequestMaster> UpdateGeneralRequestMaster(GeneralRequestMaster item)
        {
            IBaseEntityResponse<GeneralRequestMaster> entityResponse = new BaseEntityResponse<GeneralRequestMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRequestMasterBR.UpdateGeneralRequestMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRequestMasterDataProvider.UpdateGeneralRequestMaster(item);
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
        /// Delete a selected record from GeneralRequestMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRequestMaster> DeleteGeneralRequestMaster(GeneralRequestMaster item)
        {
            IBaseEntityResponse<GeneralRequestMaster> entityResponse = new BaseEntityResponse<GeneralRequestMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRequestMasterBR.DeleteGeneralRequestMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRequestMasterDataProvider.DeleteGeneralRequestMaster(item);
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
        /// Select all record from GeneralRequestMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetBySearch(GeneralRequestMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRequestMaster> GeneralRequestMasterCollection = new BaseEntityCollectionResponse<GeneralRequestMaster>();
            try
            {
                if (_GeneralRequestMasterDataProvider != null)
                    GeneralRequestMasterCollection = _GeneralRequestMasterDataProvider.GetGeneralRequestMasterBySearch(searchRequest);
                else
                {
                    GeneralRequestMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRequestMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRequestMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRequestMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRequestMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetGeneralRequestMasterSearchList(GeneralRequestMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRequestMaster> GeneralRequestMasterCollection = new BaseEntityCollectionResponse<GeneralRequestMaster>();
            try
            {
                if (_GeneralRequestMasterDataProvider != null)
                    GeneralRequestMasterCollection = _GeneralRequestMasterDataProvider.GetGeneralRequestMasterSearchList(searchRequest);
                else
                {
                    GeneralRequestMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRequestMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRequestMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRequestMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRequestMasterCollection;
        }



        /// <summary>
        /// Select all record from GeneralRequestMaster table with search parameters(Request Code)
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRequestMaster> GetRequestCode(GeneralRequestMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRequestMaster> GeneralRequestMasterCollection = new BaseEntityCollectionResponse<GeneralRequestMaster>();
            try
            {
                if (_GeneralRequestMasterDataProvider != null)
                    GeneralRequestMasterCollection = _GeneralRequestMasterDataProvider.GetRequestCode(searchRequest);
                else
                {
                    GeneralRequestMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRequestMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRequestMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRequestMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRequestMasterCollection;
        }  

        /// <summary>
        /// Select a record from GeneralRequestMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRequestMaster> SelectByID(GeneralRequestMaster item)
        {
            IBaseEntityResponse<GeneralRequestMaster> entityResponse = new BaseEntityResponse<GeneralRequestMaster>();
            try
            {
                entityResponse = _GeneralRequestMasterDataProvider.GetGeneralRequestMasterByID(item);
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
