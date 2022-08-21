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
    public class GeneralCounterMasterBA : IGeneralCounterMasterBA
    {
        IGeneralCounterMasterDataProvider _GeneralCounterMasterDataProvider;
        IGeneralCounterMasterBR _GeneralCounterMasterBR;
        private ILogger _logException;
        public GeneralCounterMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralCounterMasterBR = new GeneralCounterMasterBR();
            _GeneralCounterMasterDataProvider = new GeneralCounterMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterMaster> InsertGeneralCounterMaster(GeneralCounterMaster item)
        {
            IBaseEntityResponse<GeneralCounterMaster> entityResponse = new BaseEntityResponse<GeneralCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterMasterBR.InsertGeneralCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterMasterDataProvider.InsertGeneralCounterMaster(item);
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
        /// Update a specific record  of GeneralCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterMaster> UpdateGeneralCounterMaster(GeneralCounterMaster item)
        {
            IBaseEntityResponse<GeneralCounterMaster> entityResponse = new BaseEntityResponse<GeneralCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterMasterBR.UpdateGeneralCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterMasterDataProvider.UpdateGeneralCounterMaster(item);
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
        /// Delete a selected record from GeneralCounterMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterMaster> DeleteGeneralCounterMaster(GeneralCounterMaster item)
        {
            IBaseEntityResponse<GeneralCounterMaster> entityResponse = new BaseEntityResponse<GeneralCounterMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralCounterMasterBR.DeleteGeneralCounterMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralCounterMasterDataProvider.DeleteGeneralCounterMaster(item);
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
        /// Select all record from GeneralCounterMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralCounterMaster> GetBySearch(GeneralCounterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterMaster> GeneralCounterMasterCollection = new BaseEntityCollectionResponse<GeneralCounterMaster>();
            try
            {
                if (_GeneralCounterMasterDataProvider != null)
                    GeneralCounterMasterCollection = _GeneralCounterMasterDataProvider.GetGeneralCounterMasterBySearch(searchRequest);
                else
                {
                    GeneralCounterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCounterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCounterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCounterMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCounterMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralCounterMaster> GetGeneralCounterMasterSearchList(GeneralCounterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCounterMaster> GeneralCounterMasterCollection = new BaseEntityCollectionResponse<GeneralCounterMaster>();
            try
            {
                if (_GeneralCounterMasterDataProvider != null)
                    GeneralCounterMasterCollection = _GeneralCounterMasterDataProvider.GetGeneralCounterMasterSearchList(searchRequest);
                else
                {
                    GeneralCounterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralCounterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralCounterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralCounterMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralCounterMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralCounterMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralCounterMaster> SelectByID(GeneralCounterMaster item)
        {
            IBaseEntityResponse<GeneralCounterMaster> entityResponse = new BaseEntityResponse<GeneralCounterMaster>();
            try
            {
                entityResponse = _GeneralCounterMasterDataProvider.GetGeneralCounterMasterByID(item);
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
