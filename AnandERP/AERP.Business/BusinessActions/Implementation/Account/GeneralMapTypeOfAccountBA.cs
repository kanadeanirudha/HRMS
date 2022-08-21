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
    public class GeneralMapTypeOfAccountBA : IGeneralMapTypeOfAccountBA
    {
        IGeneralMapTypeOfAccountDataProvider _generalMapTypeOfAccountDataProvider;
        IGeneralMapTypeOfAccountBR _generalMapTypeOfAccountBR;
        private ILogger _logException;
        public GeneralMapTypeOfAccountBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalMapTypeOfAccountBR = new GeneralMapTypeOfAccountBR();
            _generalMapTypeOfAccountDataProvider = new GeneralMapTypeOfAccountDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralMapTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMapTypeOfAccount> InsertGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralMapTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralMapTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalMapTypeOfAccountBR.InsertGeneralMapTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMapTypeOfAccountDataProvider.InsertGeneralMapTypeOfAccount(item);
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
        /// Update a specific record  of GeneralMapTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMapTypeOfAccount> UpdateGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralMapTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralMapTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalMapTypeOfAccountBR.UpdateGeneralMapTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMapTypeOfAccountDataProvider.UpdateGeneralMapTypeOfAccount(item);
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
        /// Delete a selected record from GeneralMapTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMapTypeOfAccount> DeleteGeneralMapTypeOfAccount(GeneralMapTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralMapTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralMapTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalMapTypeOfAccountBR.DeleteGeneralMapTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMapTypeOfAccountDataProvider.DeleteGeneralMapTypeOfAccount(item);
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
        /// Select all record from GeneralMapTypeOfAccount table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetBySearch(GeneralMapTypeOfAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GeneralMapTypeOfAccountCollection = new BaseEntityCollectionResponse<GeneralMapTypeOfAccount>();
            try
            {
                if (_generalMapTypeOfAccountDataProvider != null)
                    GeneralMapTypeOfAccountCollection = _generalMapTypeOfAccountDataProvider.GetGeneralMapTypeOfAccountBySearch(searchRequest);
                else
                {
                    GeneralMapTypeOfAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralMapTypeOfAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralMapTypeOfAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralMapTypeOfAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralMapTypeOfAccountCollection;
        }
        /// <summary>
        /// Select a record from GeneralMapTypeOfAccount table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMapTypeOfAccount> SelectByID(GeneralMapTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralMapTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralMapTypeOfAccount>();
            try
            {
                entityResponse = _generalMapTypeOfAccountDataProvider.GetGeneralMapTypeOfAccountByID(item);
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

        public IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GetByModuleCode(GeneralMapTypeOfAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> GeneralMapTypeOfAccountCollection = new BaseEntityCollectionResponse<GeneralMapTypeOfAccount>();
            try
            {
                if (_generalMapTypeOfAccountDataProvider != null)
                    GeneralMapTypeOfAccountCollection = _generalMapTypeOfAccountDataProvider.GetByModuleCode(searchRequest);
                else
                {
                    GeneralMapTypeOfAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralMapTypeOfAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralMapTypeOfAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralMapTypeOfAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralMapTypeOfAccountCollection;
        }
    }
}
