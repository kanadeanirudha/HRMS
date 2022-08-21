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
    public class GeneralTaskReportingDetailsBA : IGeneralTaskReportingDetailsBA
    {
        IGeneralTaskReportingDetailsDataProvider _generalTaskReportingDetailsDataProvider;
        IGeneralTaskReportingDetailsBR _generalTaskReportingDetailsBR;
        private ILogger _logException;
        public GeneralTaskReportingDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTaskReportingDetailsBR = new GeneralTaskReportingDetailsBR();
            _generalTaskReportingDetailsDataProvider = new GeneralTaskReportingDetailsDataProvider();
        }
        
        /// <summary>
        /// Create new record of InsertGeneralTaskReportingMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingMaster(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.InsertGeneralTaskReportingDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.InsertGeneralTaskReportingMaster(item);
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
        /// Create new record of InsertGeneralTaskReportingMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskApprovalStageDetails(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.InsertGeneralTaskReportingDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.InsertGeneralTaskApprovalStageDetails(item);
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
        /// Create new record of GeneralTaskReportingDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> InsertGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.InsertGeneralTaskReportingDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.InsertGeneralTaskReportingDetails(item);
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
        /// Update a specific record  of GeneralTaskReportingDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> UpdateGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.UpdateGeneralTaskReportingDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.UpdateGeneralTaskReportingDetails(item);
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
        /// Delete a selected record from GeneralTaskReportingDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> DeleteGeneralTaskReportingDetails(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.DeleteGeneralTaskReportingDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.DeleteGeneralTaskReportingDetails(item);
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
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetBySearch(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetGeneralTaskReportingDetailsBySearch(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStages(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskReportingDetailsApprovalStages(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }

        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskReportingDetailsApprovalStageDetails(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskReportingDetailsApprovalStageDetails(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }        

        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> ReportingRoleIDsSearchList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.ReportingRoleIDsSearchList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> DepartmentList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.DepartmentList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }            
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskApprovalBasedTableList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskApprovalParamPrimaryKeyList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalKeyValueList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskApprovalKeyValueList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetGeneralTaskModelList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetGeneralTaskModelList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }        
        /// <summary>
        /// Select all record from GeneralTaskReportingDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(GeneralTaskReportingDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> GeneralTaskReportingDetailsCollection = new BaseEntityCollectionResponse<GeneralTaskReportingDetails>();
            try
            {
                if (_generalTaskReportingDetailsDataProvider != null)
                    GeneralTaskReportingDetailsCollection = _generalTaskReportingDetailsDataProvider.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
                else
                {
                    GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaskReportingDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaskReportingDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaskReportingDetailsCollection;
        }                
        /// <summary>
        /// Select a record from GeneralTaskReportingDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<GeneralTaskReportingDetails> SelectByID(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                entityResponse = _generalTaskReportingDetailsDataProvider.GetGeneralTaskReportingDetailsByID(item);
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
        /// Update a EngagedByUserID  of GeneralTaskReportingDetails table.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaskReportingDetails> UpdateEnagedByUserID(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTaskReportingDetailsBR.UpdateEnagedByUserIDValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTaskReportingDetailsDataProvider.UpdateEnagedByUserID(item);
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
        /// Get TotalPendingCountTask Employeewise
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<GeneralTaskReportingDetails> GetTotalPendingCountTaskEmployeewise(GeneralTaskReportingDetails item)
        {
            IBaseEntityResponse<GeneralTaskReportingDetails> entityResponse = new BaseEntityResponse<GeneralTaskReportingDetails>();
            try
            {
                entityResponse = _generalTaskReportingDetailsDataProvider.GetTotalPendingCountTaskEmployeewise(item);
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
