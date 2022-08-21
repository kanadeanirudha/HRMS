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
    public class GeneralPolicyRulesBA : IGeneralPolicyRulesBA
    {
        IGeneralPolicyRulesDataProvider _GeneralPolicyRulesDataProvider;
        IGeneralPolicyRulesBR _GeneralPolicyRulesBR;
        private ILogger _logException;
        public GeneralPolicyRulesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPolicyRulesBR = new GeneralPolicyRulesBR();
            _GeneralPolicyRulesDataProvider = new GeneralPolicyRulesDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPolicyRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> InsertGeneralPolicyRules(GeneralPolicyRules item)
        {
            IBaseEntityResponse<GeneralPolicyRules> entityResponse = new BaseEntityResponse<GeneralPolicyRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyRulesBR.InsertGeneralPolicyRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyRulesDataProvider.InsertGeneralPolicyRules(item);
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
        /// Update a specific record  of GeneralPolicyRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> UpdateGeneralPolicyRules(GeneralPolicyRules item)
        {
            IBaseEntityResponse<GeneralPolicyRules> entityResponse = new BaseEntityResponse<GeneralPolicyRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyRulesBR.UpdateGeneralPolicyRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyRulesDataProvider.UpdateGeneralPolicyRules(item);
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
        /// Delete a selected record from GeneralPolicyRules.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyRules> DeleteGeneralPolicyRules(GeneralPolicyRules item)
        {
            IBaseEntityResponse<GeneralPolicyRules> entityResponse = new BaseEntityResponse<GeneralPolicyRules>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyRulesBR.DeleteGeneralPolicyRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyRulesDataProvider.DeleteGeneralPolicyRules(item);
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
        /// Select all record from GeneralPolicyRules table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetBySearch(GeneralPolicyRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyRules> GeneralPolicyRulesCollection = new BaseEntityCollectionResponse<GeneralPolicyRules>();
            try
            {
                if (_GeneralPolicyRulesDataProvider != null)
                    GeneralPolicyRulesCollection = _GeneralPolicyRulesDataProvider.GetGeneralPolicyRulesBySearch(searchRequest);
                else
                {
                    GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyRulesCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesGetBySearchList(GeneralPolicyRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyRules> GeneralPolicyRulesCollection = new BaseEntityCollectionResponse<GeneralPolicyRules>();
            try
            {
                if (_GeneralPolicyRulesDataProvider != null)
                    GeneralPolicyRulesCollection = _GeneralPolicyRulesDataProvider.GetGeneralPolicyRulesGetBySearchList(searchRequest);
                else
                {
                    GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyRulesCollection;
        }
        /// <summary>
        /// Select a record from GeneralPolicyRules table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        //dropdown
        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetGeneralPolicyRulesForPolicyRange(GeneralPolicyRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyRules> GeneralPolicyRulesCollection = new BaseEntityCollectionResponse<GeneralPolicyRules>();
            try
            {
                if (_GeneralPolicyRulesDataProvider != null)
                    GeneralPolicyRulesCollection = _GeneralPolicyRulesDataProvider.GetGeneralPolicyRulesForPolicyRange(searchRequest);
                else
                {
                    GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyRulesCollection;
        }
        /// <summary>
        /// Select a record from GeneralPolicyRules table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>








        public IBaseEntityResponse<GeneralPolicyRules> SelectByID(GeneralPolicyRules item)
        {
            IBaseEntityResponse<GeneralPolicyRules> entityResponse = new BaseEntityResponse<GeneralPolicyRules>();
            try
            {
                entityResponse = _GeneralPolicyRulesDataProvider.GetGeneralPolicyRulesByID(item);
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

        public IBaseEntityCollectionResponse<GeneralPolicyRules> GetPolicyAnswerByPolicyStatus(GeneralPolicyRulesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyRules> GeneralPolicyRulesCollection = new BaseEntityCollectionResponse<GeneralPolicyRules>();
            try
            {
                if (_GeneralPolicyRulesDataProvider != null)
                    GeneralPolicyRulesCollection = _GeneralPolicyRulesDataProvider.GetPolicyAnswerByPolicyStatus(searchRequest);
                else
                {
                    GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyRulesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyRulesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyRulesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyRulesCollection;
        }

        public IBaseEntityResponse<GeneralPolicyRules> GetPolicyApplicableStatus(GeneralPolicyRules item)
        {
            IBaseEntityResponse<GeneralPolicyRules> entityResponse = new BaseEntityResponse<GeneralPolicyRules>();
            try
            {
                entityResponse = _GeneralPolicyRulesDataProvider.GetPolicyApplicableStatus(item);
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
