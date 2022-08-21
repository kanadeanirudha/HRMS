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
    public class GeneralItemMerchantiseCategoryBA : IGeneralItemMerchantiseCategoryBA
    {
        IGeneralItemMerchantiseCategoryDataProvider _GeneralItemMerchantiseCategoryDataProvider;
        IGeneralItemMerchantiseCategoryBR _GeneralItemMerchantiseCategoryBR;
        private ILogger _logException;
        public GeneralItemMerchantiseCategoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMerchantiseCategoryBR = new GeneralItemMerchantiseCategoryBR();
            _GeneralItemMerchantiseCategoryDataProvider = new GeneralItemMerchantiseCategoryDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMerchantiseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> InsertGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseCategory> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseCategoryBR.InsertGeneralItemMerchantiseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseCategoryDataProvider.InsertGeneralItemMerchantiseCategory(item);
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
        /// Update a specific record  of GeneralItemMerchantiseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> UpdateGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseCategory> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseCategoryBR.UpdateGeneralItemMerchantiseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseCategoryDataProvider.UpdateGeneralItemMerchantiseCategory(item);
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
        /// Delete a selected record from GeneralItemMerchantiseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> DeleteGeneralItemMerchantiseCategory(GeneralItemMerchantiseCategory item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseCategory> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseCategoryBR.DeleteGeneralItemMerchantiseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseCategoryDataProvider.DeleteGeneralItemMerchantiseCategory(item);
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
        /// Select all record from GeneralItemMerchantiseCategory table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetBySearch(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GeneralItemMerchantiseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseCategory>();
            try
            {
                if (_GeneralItemMerchantiseCategoryDataProvider != null)
                    GeneralItemMerchantiseCategoryCollection = _GeneralItemMerchantiseCategoryDataProvider.GetGeneralItemMerchantiseCategoryBySearch(searchRequest);
                else
                {
                    GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseCategoryCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategorySearchList(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GeneralItemMerchantiseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseCategory>();
            try
            {
                if (_GeneralItemMerchantiseCategoryDataProvider != null)
                    GeneralItemMerchantiseCategoryCollection = _GeneralItemMerchantiseCategoryDataProvider.GetGeneralItemMerchantiseCategorySearchList(searchRequest);
                else
                {
                    GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseCategoryCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMerchantiseCategory table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseCategory> SelectByID(GeneralItemMerchantiseCategory item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseCategory> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseCategory>();
            try
            {
                entityResponse = _GeneralItemMerchantiseCategoryDataProvider.GetGeneralItemMerchantiseCategoryByID(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(GeneralItemMerchantiseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseCategory> GeneralItemMerchantiseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseCategory>();
            try
            {
                if (_GeneralItemMerchantiseCategoryDataProvider != null)
                    GeneralItemMerchantiseCategoryCollection = _GeneralItemMerchantiseCategoryDataProvider.GetGeneralItemMerchantiseCategoryCodeByDepartmentCode(searchRequest);
                else
                {
                    GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseCategoryCollection;
        }
    }
}
