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
    public class GeneralRunningNumbersForAccountBA : IGeneralRunningNumbersForAccountBA
    {
        IGeneralRunningNumbersForAccountDataProvider _GeneralRunningNumbersForAccountDataProvider;
        IGeneralRunningNumbersForAccountBR _GeneralRunningNumbersForAccountBR;
        private ILogger _logException;
        public GeneralRunningNumbersForAccountBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralRunningNumbersForAccountBR = new GeneralRunningNumbersForAccountBR();
            _GeneralRunningNumbersForAccountDataProvider = new GeneralRunningNumbersForAccountDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralRunningNumbersForAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> InsertGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            IBaseEntityResponse<GeneralRunningNumbersForAccount> entityResponse = new BaseEntityResponse<GeneralRunningNumbersForAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRunningNumbersForAccountBR.InsertGeneralRunningNumbersForAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRunningNumbersForAccountDataProvider.InsertGeneralRunningNumbersForAccount(item);
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
        /// Update a specific record  of GeneralRunningNumbersForAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> UpdateGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            IBaseEntityResponse<GeneralRunningNumbersForAccount> entityResponse = new BaseEntityResponse<GeneralRunningNumbersForAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRunningNumbersForAccountBR.UpdateGeneralRunningNumbersForAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRunningNumbersForAccountDataProvider.UpdateGeneralRunningNumbersForAccount(item);
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
        /// Delete a selected record from GeneralRunningNumbersForAccount.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> DeleteGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item)
        {
            IBaseEntityResponse<GeneralRunningNumbersForAccount> entityResponse = new BaseEntityResponse<GeneralRunningNumbersForAccount>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralRunningNumbersForAccountBR.DeleteGeneralRunningNumbersForAccountValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralRunningNumbersForAccountDataProvider.DeleteGeneralRunningNumbersForAccount(item);
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
        /// Select all record from GeneralRunningNumbersForAccount table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetBySearch(GeneralRunningNumbersForAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GeneralRunningNumbersForAccountCollection = new BaseEntityCollectionResponse<GeneralRunningNumbersForAccount>();
            try
            {
                if (_GeneralRunningNumbersForAccountDataProvider != null)
                    GeneralRunningNumbersForAccountCollection = _GeneralRunningNumbersForAccountDataProvider.GetGeneralRunningNumbersForAccountBySearch(searchRequest);
                else
                {
                    GeneralRunningNumbersForAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRunningNumbersForAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRunningNumbersForAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRunningNumbersForAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRunningNumbersForAccountCollection;
        }

        public IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountList(GeneralRunningNumbersForAccountSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GeneralRunningNumbersForAccountCollection = new BaseEntityCollectionResponse<GeneralRunningNumbersForAccount>();
            try
            {
                if (_GeneralRunningNumbersForAccountDataProvider != null)
                    GeneralRunningNumbersForAccountCollection = _GeneralRunningNumbersForAccountDataProvider.GetGeneralRunningNumbersForAccountGetBySearchList(searchRequest);
                else
                {
                    GeneralRunningNumbersForAccountCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRunningNumbersForAccountCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRunningNumbersForAccountCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRunningNumbersForAccountCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRunningNumbersForAccountCollection;
        }
        /// <summary>
        /// Select a record from GeneralRunningNumbersForAccount table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> SelectByID(GeneralRunningNumbersForAccount item)
        {
            IBaseEntityResponse<GeneralRunningNumbersForAccount> entityResponse = new BaseEntityResponse<GeneralRunningNumbersForAccount>();
            try
            {
                entityResponse = _GeneralRunningNumbersForAccountDataProvider.GetGeneralRunningNumbersForAccountByID(item);
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

        //Get Auto generated Purchase Requirement Number
        public IBaseEntityResponse<GeneralRunningNumbersForAccount> GetAutoGeneratedRequirementNumber(GeneralRunningNumbersForAccount item)
        {
            IBaseEntityResponse<GeneralRunningNumbersForAccount> entityResponse = new BaseEntityResponse<GeneralRunningNumbersForAccount>();
            try
            {
                entityResponse = _GeneralRunningNumbersForAccountDataProvider.GetAutoGeneratedRequirementNumber(item);
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
    
