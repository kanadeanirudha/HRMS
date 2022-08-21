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
    public class EmployeeSalaryRulesBA : IEmployeeSalaryRulesBA
    {
        IEmployeeSalaryRulesDataProvider _generalRegionMasterDataProvider;
        IEmployeeSalaryRulesBR _generalRegionMasterBR;
        private ILogger _logException;

        public EmployeeSalaryRulesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new EmployeeSalaryRulesBR();
            _generalRegionMasterDataProvider = new EmployeeSalaryRulesDataProvider();
        }

        /// <summary>
        /// Create new record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSalaryRules> InsertEmployeeSalaryRules(EmployeeSalaryRules item)
        {
            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertEmployeeSalaryRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.InsertEmployeeSalaryRules(item);
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
        /// Update a specific record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSalaryRules> UpdateEmployeeSalaryRules(EmployeeSalaryRules item)
        {
            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdateEmployeeSalaryRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.UpdateEmployeeSalaryRules(item);
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
        /// Delete a selected record from EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRules(EmployeeSalaryRules item)
        {
            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeleteEmployeeSalaryRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRegionMasterDataProvider.DeleteEmployeeSalaryRules(item);
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
        /// Select all record from EmployeeSalaryRules table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<EmployeeSalaryRules> GetBySearch(EmployeeSalaryRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryRules> categoryMasterCollection = new BaseEntityCollectionResponse<EmployeeSalaryRules>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetEmployeeSalaryRulesBySearch(searchRequest);
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
        /// Select all record from EmployeeSalaryRules table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<EmployeeSalaryRules> GetBySearchList(EmployeeSalaryRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryRules> categoryMasterCollection = new BaseEntityCollectionResponse<EmployeeSalaryRules>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetEmployeeSalaryRulesGetBySearchList(searchRequest);
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
        /// Select a record from EmployeeSalaryRules table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSalaryRules> SelectByID(EmployeeSalaryRules item)
        {

            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.GetEmployeeSalaryRulesByID(item);
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
        
        public IBaseEntityResponse<EmployeeSalaryRules> ViewEmployeeSalaryRulesRules(EmployeeSalaryRules item)
        {

            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.ViewEmployeeSalaryRulesRules(item);
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

        public IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRulesRules(EmployeeSalaryRules item)
        {

            IBaseEntityResponse<EmployeeSalaryRules> entityResponse = new BaseEntityResponse<EmployeeSalaryRules>();
            try
            {
                entityResponse = _generalRegionMasterDataProvider.DeleteEmployeeSalaryRulesRules(item);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRules(EmployeeSalaryRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryRules> categoryMasterCollection = new BaseEntityCollectionResponse<EmployeeSalaryRules>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetEmployeeSalaryRules(searchRequest);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryRules> categoryMasterCollection = new BaseEntityCollectionResponse<EmployeeSalaryRules>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetEmployeeSalaryRulesBySearchWord(searchRequest);
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

        public IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesAllowancesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSalaryRules> categoryMasterCollection = new BaseEntityCollectionResponse<EmployeeSalaryRules>();
            try
            {
                if (_generalRegionMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRegionMasterDataProvider.GetEmployeeSalaryRulesAllowancesBySearchWord(searchRequest);
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