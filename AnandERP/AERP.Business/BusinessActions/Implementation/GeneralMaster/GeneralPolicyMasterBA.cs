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
    public class GeneralPolicyMasterBA : IGeneralPolicyMasterBA
    {
        IGeneralPolicyMasterDataProvider _GeneralPolicyMasterDataProvider;
        IGeneralPolicyMasterBR _GeneralPolicyMasterBR;
        private ILogger _logException;
        public GeneralPolicyMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPolicyMasterBR = new GeneralPolicyMasterBR();
            _GeneralPolicyMasterDataProvider = new GeneralPolicyMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPolicyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> InsertGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            IBaseEntityResponse<GeneralPolicyMaster> entityResponse = new BaseEntityResponse<GeneralPolicyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyMasterBR.InsertGeneralPolicyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyMasterDataProvider.InsertGeneralPolicyMaster(item);
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
        /// Update a specific record  of GeneralPolicyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> UpdateGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            IBaseEntityResponse<GeneralPolicyMaster> entityResponse = new BaseEntityResponse<GeneralPolicyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyMasterBR.UpdateGeneralPolicyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyMasterDataProvider.UpdateGeneralPolicyMaster(item);
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
        /// Delete a selected record from GeneralPolicyMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> DeleteGeneralPolicyMaster(GeneralPolicyMaster item)
        {
            IBaseEntityResponse<GeneralPolicyMaster> entityResponse = new BaseEntityResponse<GeneralPolicyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyMasterBR.DeleteGeneralPolicyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyMasterDataProvider.DeleteGeneralPolicyMaster(item);
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
        /// Select all record from GeneralPolicyMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyMaster> GetBySearch(GeneralPolicyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyMaster> GeneralPolicyMasterCollection = new BaseEntityCollectionResponse<GeneralPolicyMaster>();
            try
            {
                if (_GeneralPolicyMasterDataProvider != null)
                    GeneralPolicyMasterCollection = _GeneralPolicyMasterDataProvider.GetGeneralPolicyMasterBySearch(searchRequest);
                else
                {
                    GeneralPolicyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPolicyMaster> GetGeneralPolicyMasterList(GeneralPolicyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyMaster> GeneralPolicyMasterCollection = new BaseEntityCollectionResponse<GeneralPolicyMaster>();
            try
            {
                if (_GeneralPolicyMasterDataProvider != null)
                    GeneralPolicyMasterCollection = _GeneralPolicyMasterDataProvider.GetGeneralPolicyMasterGetBySearchList(searchRequest);
                else
                {
                    GeneralPolicyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralPolicyMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyMaster> SelectByID(GeneralPolicyMaster item)
        {
            IBaseEntityResponse<GeneralPolicyMaster> entityResponse = new BaseEntityResponse<GeneralPolicyMaster>();
            try
            {
                entityResponse = _GeneralPolicyMasterDataProvider.GetGeneralPolicyMasterByID(item);
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
