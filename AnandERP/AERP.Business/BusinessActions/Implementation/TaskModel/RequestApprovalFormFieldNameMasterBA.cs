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

namespace AERP.Business.BusinessActions
{
    public class RequestApprovalFormFieldNameMasterBA: IRequestApprovalFormFieldNameMasterBA
    {
        IRequestApprovalFormFieldNameMasterDataProvider _RequestApprovalFormFieldNameMasterDataProvider;
        IRequestApprovalFormFieldNameMasterBR _RequestApprovalFormFieldNameMasterBR;
        private ILogger _logException;
        public RequestApprovalFormFieldNameMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RequestApprovalFormFieldNameMasterBR = new RequestApprovalFormFieldNameMasterBR();
            _RequestApprovalFormFieldNameMasterDataProvider = new RequestApprovalFormFieldNameMasterDataProvider();
        }
        /// <summary>
        /// Create new record ofRequestApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> InsertRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<RequestApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RequestApprovalFormFieldNameMasterBR.InsertRequestApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RequestApprovalFormFieldNameMasterDataProvider.InsertRequestApprovalFormFieldNameMaster(item);
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
        /// Update a specific record  ofRequestApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> UpdateRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<RequestApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RequestApprovalFormFieldNameMasterBR.UpdateRequestApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RequestApprovalFormFieldNameMasterDataProvider.UpdateRequestApprovalFormFieldNameMaster(item);
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
        /// Delete a selected record fromRequestApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> DeleteRequestApprovalFormFieldNameMaster(RequestApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<RequestApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _RequestApprovalFormFieldNameMasterBR.DeleteRequestApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _RequestApprovalFormFieldNameMasterDataProvider.DeleteRequestApprovalFormFieldNameMaster(item);
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
        /// Select all record fromRequestApprovalFormFieldNameMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetBySearch(RequestApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster>RequestApprovalFormFieldNameMasterCollection = new BaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                if (_RequestApprovalFormFieldNameMasterDataProvider != null)
                   RequestApprovalFormFieldNameMasterCollection = _RequestApprovalFormFieldNameMasterDataProvider.GetRequestApprovalFormFieldNameMasterBySearch(searchRequest);
                else
                {
                   RequestApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                   RequestApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
               RequestApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
               RequestApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RequestApprovalFormFieldNameMasterCollection;
        }

        public IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster> GetRequestApprovalFormFieldNameMasterSearchList(RequestApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster>RequestApprovalFormFieldNameMasterCollection = new BaseEntityCollectionResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                if (_RequestApprovalFormFieldNameMasterDataProvider != null)
                   RequestApprovalFormFieldNameMasterCollection = _RequestApprovalFormFieldNameMasterDataProvider.GetRequestApprovalFormFieldNameMasterSearchList(searchRequest);
                else
                {
                   RequestApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                   RequestApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
               RequestApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
               RequestApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RequestApprovalFormFieldNameMasterCollection;
        }
        /// <summary>
        /// Select a record fromRequestApprovalFormFieldNameMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<RequestApprovalFormFieldNameMaster> SelectByID(RequestApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<RequestApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<RequestApprovalFormFieldNameMaster>();
            try
            {
                entityResponse = _RequestApprovalFormFieldNameMasterDataProvider.GetRequestApprovalFormFieldNameMasterByID(item);
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
