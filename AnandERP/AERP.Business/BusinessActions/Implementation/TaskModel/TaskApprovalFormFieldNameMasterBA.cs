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
    public class TaskApprovalFormFieldNameMasterBA: ITaskApprovalFormFieldNameMasterBA
    {
        ITaskApprovalFormFieldNameMasterDataProvider _TaskApprovalFormFieldNameMasterDataProvider;
        ITaskApprovalFormFieldNameMasterBR _TaskApprovalFormFieldNameMasterBR;
        private ILogger _logException;
        public TaskApprovalFormFieldNameMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _TaskApprovalFormFieldNameMasterBR = new TaskApprovalFormFieldNameMasterBR();
            _TaskApprovalFormFieldNameMasterDataProvider = new TaskApprovalFormFieldNameMasterDataProvider();
        }
        /// <summary>
        /// Create new record ofTaskApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> InsertTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TaskApprovalFormFieldNameMasterBR.InsertTaskApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TaskApprovalFormFieldNameMasterDataProvider.InsertTaskApprovalFormFieldNameMaster(item);
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
        /// Update a specific record  ofTaskApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> UpdateTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TaskApprovalFormFieldNameMasterBR.UpdateTaskApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TaskApprovalFormFieldNameMasterDataProvider.UpdateTaskApprovalFormFieldNameMaster(item);
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
        /// Delete a selected record fromTaskApprovalFormFieldNameMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> DeleteTaskApprovalFormFieldNameMaster(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _TaskApprovalFormFieldNameMasterBR.DeleteTaskApprovalFormFieldNameMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _TaskApprovalFormFieldNameMasterDataProvider.DeleteTaskApprovalFormFieldNameMaster(item);
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
        /// Select all record fromTaskApprovalFormFieldNameMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetBySearch(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>TaskApprovalFormFieldNameMasterCollection = new BaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                if (_TaskApprovalFormFieldNameMasterDataProvider != null)
                   TaskApprovalFormFieldNameMasterCollection = _TaskApprovalFormFieldNameMasterDataProvider.GetTaskApprovalFormFieldNameMasterBySearch(searchRequest);
                else
                {
                   TaskApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                   TaskApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
               TaskApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
               TaskApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaskApprovalFormFieldNameMasterCollection;
        }

        public IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster> GetTaskApprovalFormFieldNameMasterSearchList(TaskApprovalFormFieldNameMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>TaskApprovalFormFieldNameMasterCollection = new BaseEntityCollectionResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                if (_TaskApprovalFormFieldNameMasterDataProvider != null)
                   TaskApprovalFormFieldNameMasterCollection = _TaskApprovalFormFieldNameMasterDataProvider.GetTaskApprovalFormFieldNameMasterSearchList(searchRequest);
                else
                {
                   TaskApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                   TaskApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
               TaskApprovalFormFieldNameMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
               TaskApprovalFormFieldNameMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return TaskApprovalFormFieldNameMasterCollection;
        }
        /// <summary>
        /// Select a record fromTaskApprovalFormFieldNameMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<TaskApprovalFormFieldNameMaster> SelectByID(TaskApprovalFormFieldNameMaster item)
        {
            IBaseEntityResponse<TaskApprovalFormFieldNameMaster> entityResponse = new BaseEntityResponse<TaskApprovalFormFieldNameMaster>();
            try
            {
                entityResponse = _TaskApprovalFormFieldNameMasterDataProvider.GetTaskApprovalFormFieldNameMasterByID(item);
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
