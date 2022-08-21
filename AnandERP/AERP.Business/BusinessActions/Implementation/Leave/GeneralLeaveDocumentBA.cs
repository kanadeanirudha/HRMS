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
    public class GeneralLeaveDocumentBA : IGeneralLeaveDocumentBA
    {
        IGeneralLeaveDocumentDataProvider _generalLeaveDocumentDataProvider;
        IGeneralLeaveDocumentBR _generalLeaveDocumentBR;
        private ILogger _logException;
        public GeneralLeaveDocumentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalLeaveDocumentBR = new GeneralLeaveDocumentBR();
            _generalLeaveDocumentDataProvider = new GeneralLeaveDocumentDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralLeaveDocument.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLeaveDocument> InsertGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            IBaseEntityResponse<GeneralLeaveDocument> entityResponse = new BaseEntityResponse<GeneralLeaveDocument>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLeaveDocumentBR.InsertGeneralLeaveDocumentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLeaveDocumentDataProvider.InsertGeneralLeaveDocument(item);
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
        /// Update a specific record  of GeneralLeaveDocument.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLeaveDocument> UpdateGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            IBaseEntityResponse<GeneralLeaveDocument> entityResponse = new BaseEntityResponse<GeneralLeaveDocument>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLeaveDocumentBR.UpdateGeneralLeaveDocumentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLeaveDocumentDataProvider.UpdateGeneralLeaveDocument(item);
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
        /// Delete a selected record from GeneralLeaveDocument.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLeaveDocument> DeleteGeneralLeaveDocument(GeneralLeaveDocument item)
        {
            IBaseEntityResponse<GeneralLeaveDocument> entityResponse = new BaseEntityResponse<GeneralLeaveDocument>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalLeaveDocumentBR.DeleteGeneralLeaveDocumentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalLeaveDocumentDataProvider.DeleteGeneralLeaveDocument(item);
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
        /// Select all record from GeneralLeaveDocument table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearch(GeneralLeaveDocumentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLeaveDocument> GeneralLeaveDocumentCollection = new BaseEntityCollectionResponse<GeneralLeaveDocument>();
            try
            {
                if (_generalLeaveDocumentDataProvider != null)
                    GeneralLeaveDocumentCollection = _generalLeaveDocumentDataProvider.GetGeneralLeaveDocumentBySearch(searchRequest);
                else
                {
                    GeneralLeaveDocumentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralLeaveDocumentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralLeaveDocumentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralLeaveDocumentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralLeaveDocumentCollection;
        }
        /// <summary>
        /// Select a record from GeneralLeaveDocument table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralLeaveDocument> SelectByID(GeneralLeaveDocument item)
        {
            IBaseEntityResponse<GeneralLeaveDocument> entityResponse = new BaseEntityResponse<GeneralLeaveDocument>();
            try
            {
                entityResponse = _generalLeaveDocumentDataProvider.GetGeneralLeaveDocumentByID(item);
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
        /// Select ID and Document Name record from GeneralLeaveDocument table with/without search parameters for dropdownlist.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralLeaveDocument> GetBySearchList(GeneralLeaveDocumentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralLeaveDocument> GeneralLeaveDocumentCollection = new BaseEntityCollectionResponse<GeneralLeaveDocument>();
            try
            {
                if (_generalLeaveDocumentDataProvider != null)
                    GeneralLeaveDocumentCollection = _generalLeaveDocumentDataProvider.GetGeneralLeaveDocumentBySearchList(searchRequest);
                else
                {
                    GeneralLeaveDocumentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralLeaveDocumentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralLeaveDocumentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralLeaveDocumentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralLeaveDocumentCollection;
        }
    }
}
