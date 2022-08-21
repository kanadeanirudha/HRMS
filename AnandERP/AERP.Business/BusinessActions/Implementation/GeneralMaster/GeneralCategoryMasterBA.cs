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


namespace AMS.Business.BusinessAction
{
    public class GeneralCategoryMasterBA : IGeneralCategoryMasterBA
    {
        IGeneralCategoryMasterDataProvider _categoryMasterDataProvider;
        IGeneralCategoryMasterBR _categoryMasterBR;
        private ILogger _logException;

        public GeneralCategoryMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _categoryMasterBR = new GeneralCategoryMasterBR();
            _categoryMasterDataProvider = new GeneralCategoryMasterDataProvider();
        }

        public IBaseEntityResponse<GeneralCategoryMaster> InsertCategory(GeneralCategoryMaster item)
        {
            IBaseEntityResponse<GeneralCategoryMaster> entityResponse = new BaseEntityResponse<GeneralCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _categoryMasterBR.InsertCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _categoryMasterDataProvider.InsertCategory(item);
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

        public IBaseEntityResponse<GeneralCategoryMaster> UpdateCategory(GeneralCategoryMaster item)
        {
            IBaseEntityResponse<GeneralCategoryMaster> entityResponse = new BaseEntityResponse<GeneralCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _categoryMasterBR.UpdateCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _categoryMasterDataProvider.UpdateCategory(item);
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

        public IBaseEntityResponse<GeneralCategoryMaster> DeleteCategory(GeneralCategoryMaster item)
        {
            IBaseEntityResponse<GeneralCategoryMaster> entityResponse = new BaseEntityResponse<GeneralCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _categoryMasterBR.DeleteCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _categoryMasterDataProvider.DeleteCategory(item);
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

        public IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearch(GeneralCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCategoryMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCategoryMaster>();
            try
            {
                if (_categoryMasterDataProvider != null)
                {
                    categoryMasterCollection = _categoryMasterDataProvider.GetCategoryBySearch(searchRequest);
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



        public IBaseEntityCollectionResponse<GeneralCategoryMaster> GetBySearchList(GeneralCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralCategoryMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralCategoryMaster>();
            try
            {
                if (_categoryMasterDataProvider != null)
                {
                    categoryMasterCollection = _categoryMasterDataProvider.GetCategoryBySearchList(searchRequest);
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


        public IBaseEntityResponse<GeneralCategoryMaster> SelectByID(GeneralCategoryMaster item)
        {

            IBaseEntityResponse<GeneralCategoryMaster> entityResponse = new BaseEntityResponse<GeneralCategoryMaster>();
            try
            {
                entityResponse = _categoryMasterDataProvider.GetCategoryByID(item);
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
