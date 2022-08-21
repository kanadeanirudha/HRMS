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

namespace AMS.Business.BusinessActions
{
    public class GeneralPolicyDetailsBA : IGeneralPolicyDetailsBA
    {
        IGeneralPolicyDetailsDataProvider _GeneralPolicyDetailsDataProvider;
        IGeneralPolicyDetailsBR _GeneralPolicyDetailsBR;
        private ILogger _logException;
        public GeneralPolicyDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPolicyDetailsBR = new GeneralPolicyDetailsBR();
            _GeneralPolicyDetailsDataProvider = new GeneralPolicyDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPolicyDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> InsertGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            IBaseEntityResponse<GeneralPolicyDetails> entityResponse = new BaseEntityResponse<GeneralPolicyDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyDetailsBR.InsertGeneralPolicyDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyDetailsDataProvider.InsertGeneralPolicyDetails(item);
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
        /// Update a specific record  of GeneralPolicyDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> UpdateGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            IBaseEntityResponse<GeneralPolicyDetails> entityResponse = new BaseEntityResponse<GeneralPolicyDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyDetailsBR.UpdateGeneralPolicyDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyDetailsDataProvider.UpdateGeneralPolicyDetails(item);
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
        /// Delete a selected record from GeneralPolicyDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> DeleteGeneralPolicyDetails(GeneralPolicyDetails item)
        {
            IBaseEntityResponse<GeneralPolicyDetails> entityResponse = new BaseEntityResponse<GeneralPolicyDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPolicyDetailsBR.DeleteGeneralPolicyDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPolicyDetailsDataProvider.DeleteGeneralPolicyDetails(item);
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
        /// Select all record from GeneralPolicyDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPolicyDetails> GetBySearch(GeneralPolicyDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyDetails> GeneralPolicyDetailsCollection = new BaseEntityCollectionResponse<GeneralPolicyDetails>();
            try
            {
                if (_GeneralPolicyDetailsDataProvider != null)
                    GeneralPolicyDetailsCollection = _GeneralPolicyDetailsDataProvider.GetGeneralPolicyDetailsBySearch(searchRequest);
                else
                {
                    GeneralPolicyDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyDetailsCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPolicyDetails> GetGeneralPolicyDetailsList(GeneralPolicyDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPolicyDetails> GeneralPolicyDetailsCollection = new BaseEntityCollectionResponse<GeneralPolicyDetails>();
            try
            {
                if (_GeneralPolicyDetailsDataProvider != null)
                    GeneralPolicyDetailsCollection = _GeneralPolicyDetailsDataProvider.GetGeneralPolicyDetailsGetBySearchList(searchRequest);
                else
                {
                    GeneralPolicyDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPolicyDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPolicyDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPolicyDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPolicyDetailsCollection;
        }
        /// <summary>
        /// Select a record from GeneralPolicyDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPolicyDetails> SelectByID(GeneralPolicyDetails item)
        {
            IBaseEntityResponse<GeneralPolicyDetails> entityResponse = new BaseEntityResponse<GeneralPolicyDetails>();
            try
            {
                entityResponse = _GeneralPolicyDetailsDataProvider.GetGeneralPolicyDetailsByID(item);
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
