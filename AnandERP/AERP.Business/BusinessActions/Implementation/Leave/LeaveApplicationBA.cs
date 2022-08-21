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
    public class LeaveApplicationBA : ILeaveApplicationBA
    {
        ILeaveApplicationDataProvider _leaveApplicationDataProvider;
        ILeaveApplicationBR _leaveApplicationBR;
        private ILogger _logException;
        public LeaveApplicationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveApplicationBR = new LeaveApplicationBR();
            _leaveApplicationDataProvider = new LeaveApplicationDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> InsertLeaveApplication(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.InsertLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.InsertLeaveApplication(item);
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
        /// Update a specific record  of LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> UpdateLeaveApplication(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.UpdateLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.UpdateLeaveApplication(item);
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
        /// Delete a selected record from LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> DeleteLeaveApplication(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.DeleteLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.DeleteLeaveApplication(item);
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
        /// Select all record from LeaveApplication table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveApplication> GetBySearch(LeaveApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
            try
            {
                if (_leaveApplicationDataProvider != null)
                    LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveApplicationBySearch(searchRequest);
                else
                {
                    LeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveApplicationCollection;
        }
        /// <summary>
        /// Select a record from LeaveApplication table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> SelectByID(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                entityResponse = _leaveApplicationDataProvider.GetLeaveApplicationByID(item);
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
        /// Select all record from LeaveApplication table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveSummaryByEmployeeID(LeaveApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
            try
            {
                if (_leaveApplicationDataProvider != null)
                    LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveSummaryByEmployeeID(searchRequest);
                else
                {
                    LeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveApplicationCollection;
        }
         /// <summary>
        /// Select all record from LeaveApplication table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationStatusByEmployeeID(LeaveApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
            try
            {
                if (_leaveApplicationDataProvider != null)
                    LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveApplicationStatusByEmployeeID(searchRequest);
                else
                {
                    LeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveApplicationCollection;
        }
        

        //--------------- LeaveApplicationCancel ---------------------


        public IBaseEntityResponse<LeaveApplication> InsertLeaveApplicationCancel(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.InsertLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.InsertLeaveApplicationCancel(item);
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
        /// Update a specific record  of LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> UpdateLeaveApplicationCancel(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.UpdateLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.UpdateLeaveApplication(item);
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
        /// Delete a selected record from LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> DeleteLeaveApplicationCancel(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveApplicationBR.DeleteLeaveApplicationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveApplicationDataProvider.DeleteLeaveApplication(item);
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
        /// Select all record from LeaveApplication table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelBySearch(LeaveApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
            try
            {
                if (_leaveApplicationDataProvider != null)
                    LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveApplicationCancelBySearch(searchRequest);
                else
                {
                    LeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveApplicationCollection;
        }
        /// <summary>
        /// Select a record from LeaveApplication table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveApplication> SelectLeaveApplicationCancelByID(LeaveApplication item)
        {
            IBaseEntityResponse<LeaveApplication> entityResponse = new BaseEntityResponse<LeaveApplication>();
            try
            {
                entityResponse = _leaveApplicationDataProvider.SelectLeaveApplicationCancelByID(item);
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


         public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationCancelViewDetails(LeaveApplicationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
            try
            {
                if (_leaveApplicationDataProvider != null)
                    LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveApplicationCancelViewDetails(searchRequest);
                else
                {
                    LeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveApplicationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveApplicationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveApplicationCollection;
        }

         public IBaseEntityCollectionResponse<LeaveApplication> GetLeaveApplicationApprocedPendingStatus_SearchList(LeaveApplicationSearchRequest searchRequest)
         {
             IBaseEntityCollectionResponse<LeaveApplication> LeaveApplicationCollection = new BaseEntityCollectionResponse<LeaveApplication>();
             try
             {
                 if (_leaveApplicationDataProvider != null)
                     LeaveApplicationCollection = _leaveApplicationDataProvider.GetLeaveApplicationApprocedPendingStatus_SearchList(searchRequest);
                 else
                 {
                     LeaveApplicationCollection.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     LeaveApplicationCollection.CollectionResponse = null;
                 }
             }
             catch (Exception ex)
             {
                 LeaveApplicationCollection.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 LeaveApplicationCollection.CollectionResponse = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return LeaveApplicationCollection;
         }


         public IBaseEntityCollectionResponse<LeaveApplication> GetEmployeeBalanceLeave(LeaveApplicationSearchRequest searchRequest)
         {
             IBaseEntityCollectionResponse<LeaveApplication> balanceLeaveCollection = new BaseEntityCollectionResponse<LeaveApplication>();
             try
             {
                 if (_leaveApplicationDataProvider != null)
                     balanceLeaveCollection = _leaveApplicationDataProvider.GetEmployeeBalanceLeave(searchRequest);
                 else
                 {
                     balanceLeaveCollection.Message.Add(new MessageDTO
                     {
                         ErrorMessage = Resources.Null_Object_Exception,
                         MessageType = MessageTypeEnum.Error
                     });
                     balanceLeaveCollection.CollectionResponse = null;
                 }
             }
             catch (Exception ex)
             {
                 balanceLeaveCollection.Message.Add(new MessageDTO
                 {
                     ErrorMessage = ex.Message,
                     MessageType = MessageTypeEnum.Error
                 });
                 balanceLeaveCollection.CollectionResponse = null;
                 if (_logException != null)
                 {
                     _logException.Error(ex.Message);
                 }
             }
             return balanceLeaveCollection;
         }
    }
}
