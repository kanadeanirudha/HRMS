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
    public class DashboardBA : IDashboardBA
    {
        IDashboardDataProvider _DashboardDataProvider;
        IDashboardBR _DashboardBR;
        private ILogger _logException;
        public DashboardBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _DashboardBR = new DashboardBR();
            _DashboardDataProvider = new DashboardDataProvider();
        }
        /// <summary>
        /// Create new record of Dashboard.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<Dashboard> ApproveAllCompensatoryLeaveApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertDashboardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.ApproveAllCompensatoryLeaveApplication(item);
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

        public IBaseEntityCollectionResponse<Dashboard> GetDashboardContentListByAdminRoleID(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetDashboardContentListByAdminRoleID(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }

        public IBaseEntityCollectionResponse<Dashboard> GetDeshboardAllocationBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetDeshboardAllocationBySearch(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }

        public IBaseEntityResponse<Dashboard> DeleteContaintAllocateStatus(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.DeleteContaintAllocateStatusValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.DeleteContaintAllocateStatus(item);
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

        public IBaseEntityResponse<Dashboard> InsertDashboard(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertDashboardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.InsertDashboard(item);
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

        public IBaseEntityResponse<Dashboard> InsertContaintAllocateStatus(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertContaintAllocateStatusValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.InsertContaintAllocateStatus(item);
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

        public IBaseEntityCollectionResponse<Dashboard> GetByRequestApprovalField(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetByRequestApprovalField(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }

        public IBaseEntityCollectionResponse<Dashboard> GetDashboardRoleCodeList(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetDashboardRoleCodeList(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }
        public IBaseEntityCollectionResponse<Dashboard> GetGeneralTaskModelListByPersonID(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetGeneralTaskModelListByPersonID(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }


        public IBaseEntityCollectionResponse<Dashboard> GetBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetDashboardBySearch(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }


        public IBaseEntityResponse<Dashboard> ApproveAllLeaveApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertDashboardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.ApproveAllLeaveApplication(item);
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

        public IBaseEntityResponse<Dashboard> InformativeNotificationsReadInsert(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                {
                    entityResponse = _DashboardDataProvider.InformativeNotificationsReadInsert(item);
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


        public IBaseEntityCollectionResponse<Dashboard> GetInformativeNotificationListBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetInformativeNotificationListBySearch(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }

        public IBaseEntityResponse<Dashboard> ApproveAllManualAttendanceApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertDashboardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.ApproveAllManualAttendanceApplication(item);
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

        public IBaseEntityCollectionResponse<Dashboard> GetGeneralRequestBySearch(DashboardSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<Dashboard> DashboardCollection = new BaseEntityCollectionResponse<Dashboard>();
            try
            {
                if (_DashboardDataProvider != null)
                    DashboardCollection = _DashboardDataProvider.GetGeneralRequestBySearch(searchRequest);
                else
                {
                    DashboardCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    DashboardCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                DashboardCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                DashboardCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return DashboardCollection;
        }

        public IBaseEntityResponse<Dashboard> ApproveAllAttendanceSpecialRequestApplication(Dashboard item)
        {
            IBaseEntityResponse<Dashboard> entityResponse = new BaseEntityResponse<Dashboard>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _DashboardBR.InsertDashboardValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _DashboardDataProvider.ApproveAllAttendanceSpecialRequestApplication(item);
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
