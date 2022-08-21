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
    public class GeneralTaskModelBA : IGeneralTaskModelBA
    {
        IGeneralTaskModelDataProvider _GeneralTaskModelDataProvider;
        IGeneralTaskModelBR _GeneralTaskModelBR;
        private ILogger _logException;
        public GeneralTaskModelBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralTaskModelBR = new GeneralTaskModelBR();
            _GeneralTaskModelDataProvider = new GeneralTaskModelDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTaskModel.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskModel> InsertGeneralTaskModel(GeneralTaskModel item)
        {
            IBaseEntityResponse<GeneralTaskModel> entityResponse = new BaseEntityResponse<GeneralTaskModel>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTaskModelBR.InsertGeneralTaskModelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTaskModelDataProvider.InsertGeneralTaskModel(item);
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
        /// Update a specific record  of GeneralTaskModel.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskModel> UpdateGeneralTaskModel(GeneralTaskModel item)
        {
            IBaseEntityResponse<GeneralTaskModel> entityResponse = new BaseEntityResponse<GeneralTaskModel>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTaskModelBR.UpdateGeneralTaskModelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTaskModelDataProvider.UpdateGeneralTaskModel(item);
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
        /// Delete a selected record from GeneralTaskModel.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskModel> DeleteGeneralTaskModel(GeneralTaskModel item)
        {
            IBaseEntityResponse<GeneralTaskModel> entityResponse = new BaseEntityResponse<GeneralTaskModel>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTaskModelBR.DeleteGeneralTaskModelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTaskModelDataProvider.DeleteGeneralTaskModel(item);
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
        /// Select all record from GeneralTaskModel table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskModel> GetBySearch(GeneralTaskModelSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskModel> GeneralTaskModelCollection = new BaseEntityCollectionResponse<GeneralTaskModel>();
            try
            {
                if (_GeneralTaskModelDataProvider != null)
                    GeneralTaskModelCollection = _GeneralTaskModelDataProvider.GetGeneralTaskModelBySearch(searchRequest);
                else
                {
                    GeneralTaskModelCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskModelCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskModelCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskModelCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskModelCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskModel table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskModel> GetMenuCodeAndMenuLink(GeneralTaskModelSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskModel> GeneralTaskModelCollection = new BaseEntityCollectionResponse<GeneralTaskModel>();
            try
            {
                if (_GeneralTaskModelDataProvider != null)
                    GeneralTaskModelCollection = _GeneralTaskModelDataProvider.GetMenuCodeAndMenuLink(searchRequest);
                else
                {
                    GeneralTaskModelCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskModelCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskModelCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskModelCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskModelCollection;
        }




        /// <summary>
        /// Select all record from GeneralTaskModel table with search parameters(Task COde).
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskModel> GetTaskCode(GeneralTaskModelSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskModel> GeneralTaskModelCollection = new BaseEntityCollectionResponse<GeneralTaskModel>();
            try
            {
                if (_GeneralTaskModelDataProvider != null)
                    GeneralTaskModelCollection = _GeneralTaskModelDataProvider.GetTaskCode(searchRequest);
                else
                {
                    GeneralTaskModelCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskModelCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskModelCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskModelCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskModelCollection;
        }        
        /// <summary>
        /// Select a record from GeneralTaskModel table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskModel> SelectByID(GeneralTaskModel item)
        {
            IBaseEntityResponse<GeneralTaskModel> entityResponse = new BaseEntityResponse<GeneralTaskModel>();
            try
            {
                entityResponse = _GeneralTaskModelDataProvider.GetGeneralTaskModelByID(item);
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
