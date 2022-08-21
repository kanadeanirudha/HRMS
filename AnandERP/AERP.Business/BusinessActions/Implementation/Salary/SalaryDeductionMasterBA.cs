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
    public class SalaryDeductionMasterBA : ISalaryDeductionMasterBA
    {
        ISalaryDeductionMasterDataProvider _generalSalaryDeductionMasterDataProvider;
        ISalaryDeductionMasterBR _generalSalaryDeductionMasterBR;
        private ILogger _logException;

        public SalaryDeductionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalSalaryDeductionMasterBR = new SalaryDeductionMasterBR();
            _generalSalaryDeductionMasterDataProvider = new SalaryDeductionMasterDataProvider();
        }

        /// <summary>
        /// Create new record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryDeductionMasterBR.InsertSalaryDeductionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.InsertSalaryDeductionMaster(item);
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
        /// Update a specific record of SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryDeductionMasterBR.UpdateSalaryDeductionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.UpdateSalaryDeductionMaster(item);
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
        /// Delete a selected record from SalaryDeductionMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionMaster(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalSalaryDeductionMasterBR.DeleteSalaryDeductionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.DeleteSalaryDeductionMaster(item);
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
        /// Select all record from SalaryDeductionMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearch(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryDeductionMasterDataProvider.GetSalaryDeductionMasterBySearch(searchRequest);
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
        /// Select all record from SalaryDeductionMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetBySearchList(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryDeductionMasterDataProvider.GetSalaryDeductionMasterGetBySearchList(searchRequest);
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
        /// Select a record from SalaryDeductionMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalaryDeductionMaster> SelectByID(SalaryDeductionMaster item)
        {

            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                entityResponse = _generalSalaryDeductionMasterDataProvider.GetSalaryDeductionMasterByID(item);
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

        public IBaseEntityResponse<SalaryDeductionMaster> InsertSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.InsertSalaryDeductionRules(item);
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

        public IBaseEntityResponse<SalaryDeductionMaster> SelectBySalaryDeductionRulesID(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.SelectBySalaryDeductionRulesID(item);
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

        public IBaseEntityResponse<SalaryDeductionMaster> UpdateSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.UpdateSalaryDeductionRules(item);
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

        public IBaseEntityResponse<SalaryDeductionMaster> DeleteSalaryDeductionRules(SalaryDeductionMaster item)
        {
            IBaseEntityResponse<SalaryDeductionMaster> entityResponse = new BaseEntityResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    entityResponse = _generalSalaryDeductionMasterDataProvider.DeleteSalaryDeductionRules(item);
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
        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetDeductionRulesByDeductionMaster(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryDeductionMasterDataProvider.GetDeductionRulesByDeductionMaster(searchRequest);
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

        public IBaseEntityCollectionResponse<SalaryDeductionMaster> GetCalculateOnListForRules(SalaryDeductionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalaryDeductionMaster> categoryMasterCollection = new BaseEntityCollectionResponse<SalaryDeductionMaster>();
            try
            {
                if (_generalSalaryDeductionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalSalaryDeductionMasterDataProvider.GetCalculateOnListForRules(searchRequest);
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