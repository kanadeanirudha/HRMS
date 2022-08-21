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
    public class GeneralItemMarchandiseSubCategoryBA : IGeneralItemMarchandiseSubCategoryBA
    {
        IGeneralItemMarchandiseSubCategoryDataProvider _GeneralItemMarchandiseSubCategoryDataProvider;
        IGeneralItemMarchandiseSubCategoryBR _GeneralItemMarchandiseSubCategoryBR;
        private ILogger _logException;
        public GeneralItemMarchandiseSubCategoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMarchandiseSubCategoryBR = new GeneralItemMarchandiseSubCategoryBR();
            _GeneralItemMarchandiseSubCategoryDataProvider = new GeneralItemMarchandiseSubCategoryDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMarchandiseSubCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> InsertGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseSubCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseSubCategoryBR.InsertGeneralItemMarchandiseSubCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseSubCategoryDataProvider.InsertGeneralItemMarchandiseSubCategory(item);
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
        /// Update a specific record  of GeneralItemMarchandiseSubCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> UpdateGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseSubCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseSubCategoryBR.UpdateGeneralItemMarchandiseSubCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseSubCategoryDataProvider.UpdateGeneralItemMarchandiseSubCategory(item);
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
        /// Delete a selected record from GeneralItemMarchandiseSubCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> DeleteGeneralItemMarchandiseSubCategory(GeneralItemMarchandiseSubCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseSubCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseSubCategoryBR.DeleteGeneralItemMarchandiseSubCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseSubCategoryDataProvider.DeleteGeneralItemMarchandiseSubCategory(item);
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
        /// Select all record from GeneralItemMarchandiseSubCategory table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetBySearch(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GeneralItemMarchandiseSubCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                if (_GeneralItemMarchandiseSubCategoryDataProvider != null)
                    GeneralItemMarchandiseSubCategoryCollection = _GeneralItemMarchandiseSubCategoryDataProvider.GetGeneralItemMarchandiseSubCategoryBySearch(searchRequest);
                else
                {
                    GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseSubCategoryCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMarchandiseSubCategorySearchList(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GeneralItemMarchandiseSubCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                if (_GeneralItemMarchandiseSubCategoryDataProvider != null)
                    GeneralItemMarchandiseSubCategoryCollection = _GeneralItemMarchandiseSubCategoryDataProvider.GetGeneralItemMarchandiseSubCategorySearchList(searchRequest);
                else
                {
                    GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseSubCategoryCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMarchandiseSubCategory table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseSubCategory> SelectByID(GeneralItemMarchandiseSubCategory item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseSubCategory> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                entityResponse = _GeneralItemMarchandiseSubCategoryDataProvider.GetGeneralItemMarchandiseSubCategoryByID(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(GeneralItemMarchandiseSubCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory> GeneralItemMarchandiseSubCategoryCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseSubCategory>();
            try
            {
                if (_GeneralItemMarchandiseSubCategoryDataProvider != null)
                    GeneralItemMarchandiseSubCategoryCollection = _GeneralItemMarchandiseSubCategoryDataProvider.GetGeneralItemMerchantiseSubCategoryCodeByDepartmentCode(searchRequest);
                else
                {
                    GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseSubCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseSubCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseSubCategoryCollection;
        }
    }
}
