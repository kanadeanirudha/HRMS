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
    public class SalaryAllowanceMasterBA : ISalaryAllowanceMasterBA
    {
        ISalaryAllowanceMasterDataProvider _generalSalaryAllowanceMasterDataProvider;
        ISalaryAllowanceMasterBR _generalSalaryAllowanceMasterBR;
        private ILogger _logException;

        public SalaryAllowanceMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalSalaryAllowanceMasterBR = new SalaryAllowanceMasterBR();
            _generalSalaryAllowanceMasterDataProvider = new SalaryAllowanceMasterDataProvider();
        }

        /// <summary>
        /// Create new record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceMaster(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryAllowanceMasterBR.InsertSalaryAllowanceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.InsertSalaryAllowanceMaster(item);
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

        /// <summary>
        /// Update a specific record of SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceMaster(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryAllowanceMasterBR.UpdateSalaryAllowanceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.UpdateSalaryAllowanceMaster(item);
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

        /// <summary>
        /// Delete a selected record from SalaryAllowanceMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceMaster(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryAllowanceMasterBR.DeleteSalaryAllowanceMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.DeleteSalaryAllowanceMaster(item);
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

        /// <summary>
        /// Select all record from SalaryAllowanceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearch(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryAllowanceMasterDataProvider.GetSalaryAllowanceMasterBySearch(searchRequest);
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

        /// <summary>
        /// Select all record from SalaryAllowanceMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetBySearchList(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryAllowanceMasterDataProvider.GetSalaryAllowanceMasterGetBySearchList(searchRequest);
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


        /// <summary>
        /// Select a record from SalaryAllowanceMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryAllowanceMaster> SelectByID(SalaryAllowanceMaster item)
        {

            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                entityResponse = _generalSalaryAllowanceMasterDataProvider.GetSalaryAllowanceMasterByID(item);
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

        public IBaseEntityResponse<SalaryAllowanceMaster> InsertSalaryAllowanceRules(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.InsertSalaryAllowanceRules(item);
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

        public IBaseEntityResponse<SalaryAllowanceMaster> SelectBySalaryAllowanceRulesID(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.SelectBySalaryAllowanceRulesID(item);
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

        public IBaseEntityResponse<SalaryAllowanceMaster> UpdateSalaryAllowanceRules(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.UpdateSalaryAllowanceRules(item);
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

        public IBaseEntityResponse<SalaryAllowanceMaster> DeleteSalaryAllowanceRules(SalaryAllowanceMaster item)
        {
            IBaseEntityResponse<SalaryAllowanceMaster> entityResponse = new BaseEntityResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryAllowanceMasterDataProvider.DeleteSalaryAllowanceRules(item);
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
        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetAllowanceRulesByAllowanceMaster(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryAllowanceMasterDataProvider.GetAllowanceRulesByAllowanceMaster(searchRequest);
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
        public IBaseEntityCollectionResponse<SalaryAllowanceMaster> GetCalculateOnListForRules(SalaryAllowanceMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryAllowanceMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryAllowanceMaster>();
            try
            {
                if (_generalSalaryAllowanceMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryAllowanceMasterDataProvider.GetCalculateOnListForRules(searchRequest);
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
    }
}