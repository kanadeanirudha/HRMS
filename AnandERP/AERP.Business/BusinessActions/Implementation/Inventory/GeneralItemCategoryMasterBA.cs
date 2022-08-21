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
    public class GeneralItemCategoryMasterBA : IGeneralItemCategoryMasterBA
    {
        IGeneralItemCategoryMasterDataProvider _GeneralItemCategoryMasterDataProvider;
        IGeneralItemCategoryMasterBR _GeneralItemCategoryMasterBR;
        private ILogger _logException;
        public GeneralItemCategoryMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemCategoryMasterBR = new GeneralItemCategoryMasterBR();
            _GeneralItemCategoryMasterDataProvider = new GeneralItemCategoryMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemCategoryMasterBR.InsertGeneralItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemCategoryMasterDataProvider.InsertGeneralItemCategoryMaster(item);
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
        /// Update a specific record  of GeneralItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> UpdateGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemCategoryMasterBR.UpdateGeneralItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemCategoryMasterDataProvider.UpdateGeneralItemCategoryMaster(item);
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
        /// Delete a selected record from GeneralItemCategoryMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> DeleteGeneralItemCategoryMaster(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemCategoryMasterBR.DeleteGeneralItemCategoryMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemCategoryMasterDataProvider.DeleteGeneralItemCategoryMaster(item);
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
        /// Select all record from GeneralItemCategoryMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetBySearch(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GeneralItemCategoryMasterCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
            try
            {
                if (_GeneralItemCategoryMasterDataProvider != null)
                    GeneralItemCategoryMasterCollection = _GeneralItemCategoryMasterDataProvider.GetGeneralItemCategoryMasterBySearch(searchRequest);
                else
                {
                    GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemCategoryMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemCategoryMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetGeneralItemCategoryMasterSearchList(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GeneralItemCategoryMasterCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
            try
            {
                if (_GeneralItemCategoryMasterDataProvider != null)
                    GeneralItemCategoryMasterCollection = _GeneralItemCategoryMasterDataProvider.GetGeneralItemCategoryMasterSearchList(searchRequest);
                else
                {
                    GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemCategoryMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemCategoryMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemCategoryMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemCategoryMaster> SelectByID(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                entityResponse = _GeneralItemCategoryMasterDataProvider.GetGeneralItemCategoryMasterByID(item);
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

        public IBaseEntityResponse<GeneralItemCategoryMaster> InsertGeneralItemCategoryMasterExcel(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemCategoryMasterBR.InsertGeneralItemCategoryMasterExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemCategoryMasterDataProvider.InsertGeneralItemCategoryMasterExcel(item);
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
        public IBaseEntityResponse<GeneralItemCategoryMaster> GetGeneralItemByCategoryCode(GeneralItemCategoryMaster item)
        {
            IBaseEntityResponse<GeneralItemCategoryMaster> entityResponse = new BaseEntityResponse<GeneralItemCategoryMaster>();
            try
            {
                entityResponse = _GeneralItemCategoryMasterDataProvider.GetGeneralItemByCategoryCode(item);
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

        public IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GetBySearchList(GeneralItemCategoryMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> GeneralItemCategoryMasterCollection = new BaseEntityCollectionResponse<GeneralItemCategoryMaster>();
            try
            {
                if (_GeneralItemCategoryMasterDataProvider != null)
                {
                    GeneralItemCategoryMasterCollection = _GeneralItemCategoryMasterDataProvider.GetGeneralItemCategoryMasterGetBySearchList(searchRequest);
                }
                else
                {
                    GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemCategoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemCategoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                GeneralItemCategoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemCategoryMasterCollection;
        }

    }
}
