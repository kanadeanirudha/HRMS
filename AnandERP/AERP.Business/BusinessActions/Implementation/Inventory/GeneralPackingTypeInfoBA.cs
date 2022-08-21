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
    public class GeneralPackingTypeInfoBA : IGeneralPackingTypeInfoBA
    {
        IGeneralPackingTypeInfoDataProvider _GeneralPackingTypeInfoDataProvider;
        IGeneralPackingTypeInfoBR _GeneralPackingTypeInfoBR;
        private ILogger _logException;
        public GeneralPackingTypeInfoBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPackingTypeInfoBR = new GeneralPackingTypeInfoBR();
            _GeneralPackingTypeInfoDataProvider = new GeneralPackingTypeInfoDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPackingTypeInfo.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackingTypeInfo> InsertGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            IBaseEntityResponse<GeneralPackingTypeInfo> entityResponse = new BaseEntityResponse<GeneralPackingTypeInfo>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackingTypeInfoBR.InsertGeneralPackingTypeInfoValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackingTypeInfoDataProvider.InsertGeneralPackingTypeInfo(item);
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
        /// Update a specific record  of GeneralPackingTypeInfo.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackingTypeInfo> UpdateGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            IBaseEntityResponse<GeneralPackingTypeInfo> entityResponse = new BaseEntityResponse<GeneralPackingTypeInfo>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackingTypeInfoBR.UpdateGeneralPackingTypeInfoValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackingTypeInfoDataProvider.UpdateGeneralPackingTypeInfo(item);
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
        /// Delete a selected record from GeneralPackingTypeInfo.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackingTypeInfo> DeleteGeneralPackingTypeInfo(GeneralPackingTypeInfo item)
        {
            IBaseEntityResponse<GeneralPackingTypeInfo> entityResponse = new BaseEntityResponse<GeneralPackingTypeInfo>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackingTypeInfoBR.DeleteGeneralPackingTypeInfoValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackingTypeInfoDataProvider.DeleteGeneralPackingTypeInfo(item);
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
        /// Select all record from GeneralPackingTypeInfo table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetBySearch(GeneralPackingTypeInfoSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GeneralPackingTypeInfoCollection = new BaseEntityCollectionResponse<GeneralPackingTypeInfo>();
            try
            {
                if (_GeneralPackingTypeInfoDataProvider != null)
                    GeneralPackingTypeInfoCollection = _GeneralPackingTypeInfoDataProvider.GetGeneralPackingTypeInfoBySearch(searchRequest);
                else
                {
                    GeneralPackingTypeInfoCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPackingTypeInfoCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPackingTypeInfoCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPackingTypeInfoCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPackingTypeInfoCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GetGeneralPackingTypeInfoSearchList(GeneralPackingTypeInfoSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPackingTypeInfo> GeneralPackingTypeInfoCollection = new BaseEntityCollectionResponse<GeneralPackingTypeInfo>();
            try
            {
                if (_GeneralPackingTypeInfoDataProvider != null)
                    GeneralPackingTypeInfoCollection = _GeneralPackingTypeInfoDataProvider.GetGeneralPackingTypeInfoSearchList(searchRequest);
                else
                {
                    GeneralPackingTypeInfoCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPackingTypeInfoCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPackingTypeInfoCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPackingTypeInfoCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPackingTypeInfoCollection;
        }
        /// <summary>
        /// Select a record from GeneralPackingTypeInfo table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackingTypeInfo> SelectByID(GeneralPackingTypeInfo item)
        {
            IBaseEntityResponse<GeneralPackingTypeInfo> entityResponse = new BaseEntityResponse<GeneralPackingTypeInfo>();
            try
            {
                entityResponse = _GeneralPackingTypeInfoDataProvider.GetGeneralPackingTypeInfoByID(item);
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
