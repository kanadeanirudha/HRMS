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
    public class GeneralMovementTypeBA : IGeneralMovementTypeBA
    {
        IGeneralMovementTypeDataProvider _GeneralMovementTypeDataProvider;
        IGeneralMovementTypeBR _GeneralMovementTypeBR;
        private ILogger _logException;
        public GeneralMovementTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralMovementTypeBR = new GeneralMovementTypeBR();
            _GeneralMovementTypeDataProvider = new GeneralMovementTypeDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralMovementType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementType(GeneralMovementType item)
        {
            IBaseEntityResponse<GeneralMovementType> entityResponse = new BaseEntityResponse<GeneralMovementType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralMovementTypeBR.InsertGeneralMovementTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralMovementTypeDataProvider.InsertGeneralMovementType(item);
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
        /// Update a specific record  of GeneralMovementType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMovementType> UpdateGeneralMovementType(GeneralMovementType item)
        {
            IBaseEntityResponse<GeneralMovementType> entityResponse = new BaseEntityResponse<GeneralMovementType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralMovementTypeBR.UpdateGeneralMovementTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralMovementTypeDataProvider.UpdateGeneralMovementType(item);
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
        /// Delete a selected record from GeneralMovementType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMovementType> DeleteGeneralMovementType(GeneralMovementType item)
        {
            IBaseEntityResponse<GeneralMovementType> entityResponse = new BaseEntityResponse<GeneralMovementType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralMovementTypeBR.DeleteGeneralMovementTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralMovementTypeDataProvider.DeleteGeneralMovementType(item);
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
        /// Select all record from GeneralMovementType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralMovementType> GetBySearch(GeneralMovementTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMovementType> GeneralMovementTypeCollection = new BaseEntityCollectionResponse<GeneralMovementType>();
            try
            {
                if (_GeneralMovementTypeDataProvider != null)
                    GeneralMovementTypeCollection = _GeneralMovementTypeDataProvider.GetGeneralMovementTypeBySearch(searchRequest);
                else
                {
                    GeneralMovementTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralMovementTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralMovementTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralMovementTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralMovementTypeCollection;
        }

        public IBaseEntityCollectionResponse<GeneralMovementType> GetGeneralMovementTypeSearchList(GeneralMovementTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMovementType> GeneralMovementTypeCollection = new BaseEntityCollectionResponse<GeneralMovementType>();
            try
            {
                if (_GeneralMovementTypeDataProvider != null)
                    GeneralMovementTypeCollection = _GeneralMovementTypeDataProvider.GetGeneralMovementTypeSearchList(searchRequest);
                else
                {
                    GeneralMovementTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralMovementTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralMovementTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralMovementTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralMovementTypeCollection;
        }
        /// <summary>
        /// Select a record from GeneralMovementType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralMovementType> SelectByID(GeneralMovementType item)
        {
            IBaseEntityResponse<GeneralMovementType> entityResponse = new BaseEntityResponse<GeneralMovementType>();
            try
            {
                entityResponse = _GeneralMovementTypeDataProvider.GetGeneralMovementTypeByID(item);
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

        public IBaseEntityResponse<GeneralMovementType> InsertGeneralMovementTypeRules(GeneralMovementType item)
        {
            IBaseEntityResponse<GeneralMovementType> entityResponse = new BaseEntityResponse<GeneralMovementType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralMovementTypeBR.InsertGeneralMovementTypeRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralMovementTypeDataProvider.InsertGeneralMovementTypeRules(item);
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

       
    }
}
