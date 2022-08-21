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
    public class GeneralTypeOfAccountBA : IGeneralTypeOfAccountBA
    {
        IGeneralTypeOfAccountDataProvider _GeneralTypeOfAccountDataProvider;
        IGeneralTypeOfAccountBR _GeneralTypeOfAccountBR;
        private ILogger _logException;
        public GeneralTypeOfAccountBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralTypeOfAccountBR = new GeneralTypeOfAccountBR();
            _GeneralTypeOfAccountDataProvider = new GeneralTypeOfAccountDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTypeOfAccount> InsertGeneralTypeOfAccount(GeneralTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTypeOfAccountBR.InsertGeneralTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTypeOfAccountDataProvider.InsertGeneralTypeOfAccount(item);
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
        /// Update a specific record  of GeneralTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTypeOfAccount> UpdateGeneralTypeOfAccount(GeneralTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTypeOfAccountBR.UpdateGeneralTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTypeOfAccountDataProvider.UpdateGeneralTypeOfAccount(item);
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
        /// Delete a selected record from GeneralTypeOfAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTypeOfAccount> DeleteGeneralTypeOfAccount(GeneralTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralTypeOfAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralTypeOfAccountBR.DeleteGeneralTypeOfAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralTypeOfAccountDataProvider.DeleteGeneralTypeOfAccount(item);
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
        /// Select all record from GeneralTypeOfAccount table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetBySearch(GeneralTypeOfAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> GeneralTypeOfAccountCollection = new BaseEntityCollectionResponse<GeneralTypeOfAccount>();
            try
            {
                if (_GeneralTypeOfAccountDataProvider != null)
                    GeneralTypeOfAccountCollection = _GeneralTypeOfAccountDataProvider.GetGeneralTypeOfAccountBySearch(searchRequest);
                else
                {
                    GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTypeOfAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTypeOfAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTypeOfAccountCollection;
        }
        /// <summary>
        /// Select a record from GeneralTypeOfAccount table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTypeOfAccount> SelectByID(GeneralTypeOfAccount item)
        {
            IBaseEntityResponse<GeneralTypeOfAccount> entityResponse = new BaseEntityResponse<GeneralTypeOfAccount>();
            try
            {
                entityResponse = _GeneralTypeOfAccountDataProvider.SelectByID(item);
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
        /// Select a record from GeneralTypeOfAccount table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListName(GeneralTypeOfAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> GeneralTypeOfAccountCollection = new BaseEntityCollectionResponse<GeneralTypeOfAccount>();
            try
            {
                if (_GeneralTypeOfAccountDataProvider != null)
                    GeneralTypeOfAccountCollection = _GeneralTypeOfAccountDataProvider.GetListName(searchRequest);
                else
                {
                    GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTypeOfAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTypeOfAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTypeOfAccountCollection;
        }

        public IBaseEntityCollectionResponse<GeneralTypeOfAccount> GetListAccountType(GeneralTypeOfAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> GeneralTypeOfAccountCollection = new BaseEntityCollectionResponse<GeneralTypeOfAccount>();
            try
            {
                if (_GeneralTypeOfAccountDataProvider != null)
                    GeneralTypeOfAccountCollection = _GeneralTypeOfAccountDataProvider.GetListAccountType(searchRequest);
                else
                {
                    GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTypeOfAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTypeOfAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTypeOfAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTypeOfAccountCollection;
        }
    }
}