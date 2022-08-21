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
    public class GeneralItemMarchandiseBaseCategoryBA : IGeneralItemMarchandiseBaseCategoryBA
    {
        IGeneralItemMarchandiseBaseCategoryDataProvider _GeneralItemMarchandiseBaseCategoryDataProvider;
        IGeneralItemMarchandiseBaseCategoryBR _GeneralItemMarchandiseBaseCategoryBR;
        private ILogger _logException;
        public GeneralItemMarchandiseBaseCategoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMarchandiseBaseCategoryBR = new GeneralItemMarchandiseBaseCategoryBR();
            _GeneralItemMarchandiseBaseCategoryDataProvider = new GeneralItemMarchandiseBaseCategoryDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMarchandiseBaseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> InsertGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseBaseCategoryBR.InsertGeneralItemMarchandiseBaseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseBaseCategoryDataProvider.InsertGeneralItemMarchandiseBaseCategory(item);
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
        /// Update a specific record  of GeneralItemMarchandiseBaseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> UpdateGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseBaseCategoryBR.UpdateGeneralItemMarchandiseBaseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseBaseCategoryDataProvider.UpdateGeneralItemMarchandiseBaseCategory(item);
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
        /// Delete a selected record from GeneralItemMarchandiseBaseCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> DeleteGeneralItemMarchandiseBaseCategory(GeneralItemMarchandiseBaseCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseBaseCategoryBR.DeleteGeneralItemMarchandiseBaseCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseBaseCategoryDataProvider.DeleteGeneralItemMarchandiseBaseCategory(item);
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
        /// Select all record from GeneralItemMarchandiseBaseCategory table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetBySearch(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GeneralItemMarchandiseBaseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                if (_GeneralItemMarchandiseBaseCategoryDataProvider != null)
                    GeneralItemMarchandiseBaseCategoryCollection = _GeneralItemMarchandiseBaseCategoryDataProvider.GetGeneralItemMarchandiseBaseCategoryBySearch(searchRequest);
                else
                {
                    GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseBaseCategoryCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMarchandiseBaseCategorySearchList(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GeneralItemMarchandiseBaseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                if (_GeneralItemMarchandiseBaseCategoryDataProvider != null)
                    GeneralItemMarchandiseBaseCategoryCollection = _GeneralItemMarchandiseBaseCategoryDataProvider.GetGeneralItemMarchandiseBaseCategorySearchList(searchRequest);
                else
                {
                    GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseBaseCategoryCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMarchandiseBaseCategory table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> SelectByID(GeneralItemMarchandiseBaseCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseBaseCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                entityResponse = _GeneralItemMarchandiseBaseCategoryDataProvider.GetGeneralItemMarchandiseBaseCategoryByID(item);
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
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(GeneralItemMarchandiseBaseCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory> GeneralItemMarchandiseBaseCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseBaseCategory>();
            try
            {
                if (_GeneralItemMarchandiseBaseCategoryDataProvider != null)
                    GeneralItemMarchandiseBaseCategoryCollection = _GeneralItemMarchandiseBaseCategoryDataProvider.GetGeneralItemMerchantiseBaseCategoryCodeByCategoryCode(searchRequest);
                else
                {
                    GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseBaseCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseBaseCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseBaseCategoryCollection;
        }
    }
}
