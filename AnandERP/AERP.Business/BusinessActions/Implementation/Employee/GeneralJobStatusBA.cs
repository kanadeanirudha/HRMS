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
    public class GeneralJobStatusBA : IGeneralJobStatusBA
    {
        IGeneralJobStatusDataProvider _generalJobStatusDataProvider;
        IGeneralJobStatusBR _generalJobStatusBR;
        private ILogger _logException;
        public GeneralJobStatusBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalJobStatusBR = new GeneralJobStatusBR();
            _generalJobStatusDataProvider = new GeneralJobStatusDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralJobStatus.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> InsertGeneralJobStatus(GeneralJobStatus item)
        {
            IBaseEntityResponse<GeneralJobStatus> entityResponse = new BaseEntityResponse<GeneralJobStatus>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobStatusBR.InsertGeneralJobStatusValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobStatusDataProvider.InsertGeneralJobStatus(item);
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
        /// Update a specific record  of GeneralJobStatus.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> UpdateGeneralJobStatus(GeneralJobStatus item)
        {
            IBaseEntityResponse<GeneralJobStatus> entityResponse = new BaseEntityResponse<GeneralJobStatus>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobStatusBR.UpdateGeneralJobStatusValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobStatusDataProvider.UpdateGeneralJobStatus(item);
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
        /// Delete a selected record from GeneralJobStatus.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> DeleteGeneralJobStatus(GeneralJobStatus item)
        {
            IBaseEntityResponse<GeneralJobStatus> entityResponse = new BaseEntityResponse<GeneralJobStatus>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalJobStatusBR.DeleteGeneralJobStatusValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalJobStatusDataProvider.DeleteGeneralJobStatus(item);
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
        /// Select all record from GeneralJobStatus table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearch(GeneralJobStatusSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralJobStatus> GeneralJobStatusCollection = new BaseEntityCollectionResponse<GeneralJobStatus>();
            try
            {
                if (_generalJobStatusDataProvider != null)
                    GeneralJobStatusCollection = _generalJobStatusDataProvider.GetGeneralJobStatusBySearch(searchRequest);
                else
                {
                    GeneralJobStatusCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralJobStatusCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralJobStatusCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralJobStatusCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralJobStatusCollection;
        }
        /// <summary>
        /// Select a record from GeneralJobStatus table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralJobStatus> SelectByID(GeneralJobStatus item)
        {
            IBaseEntityResponse<GeneralJobStatus> entityResponse = new BaseEntityResponse<GeneralJobStatus>();
            try
            {
                entityResponse = _generalJobStatusDataProvider.GetGeneralJobStatusByID(item);
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

        public IBaseEntityCollectionResponse<GeneralJobStatus> GetBySearchList(GeneralJobStatusSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralJobStatus> GeneralJobStatusCollection = new BaseEntityCollectionResponse<GeneralJobStatus>();
            try
            {
                if (_generalJobStatusDataProvider != null)
                    GeneralJobStatusCollection = _generalJobStatusDataProvider.GetGeneralJobStatusBySearchList(searchRequest);
                else
                {
                    GeneralJobStatusCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralJobStatusCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralJobStatusCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralJobStatusCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralJobStatusCollection;
        }
    }
}
