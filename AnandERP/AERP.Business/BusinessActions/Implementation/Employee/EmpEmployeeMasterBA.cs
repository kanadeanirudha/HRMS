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
    public class EmpEmployeeMasterBA : IEmpEmployeeMasterBA
    {
        IEmpEmployeeMasterDataProvider _empEmployeeMasterDataProvider;
        IEmpEmployeeMasterBR _empEmployeeMasterBR;
        private ILogger _logException;
        public EmpEmployeeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _empEmployeeMasterBR = new EmpEmployeeMasterBR();
            _empEmployeeMasterDataProvider = new EmpEmployeeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of EmpEmployeeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> InsertEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empEmployeeMasterBR.InsertEmpEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empEmployeeMasterDataProvider.InsertEmpEmployeeMaster(item);
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
        /// Update a specific record  of EmpEmployeeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empEmployeeMasterBR.UpdateEmpEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empEmployeeMasterDataProvider.UpdateEmpEmployeeMaster(item);
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
        /// Update a specific record  of EmpEmployeeMaster PersonalInformation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterPersonalInformation(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empEmployeeMasterBR.UpdateEmpEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empEmployeeMasterDataProvider.UpdateEmpEmployeeMasterPersonalInformation(item);
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
        /// Update a specific record  of EmpEmployeeMaster Office Details.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> UpdateEmpEmployeeMasterOfficeDetails(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empEmployeeMasterBR.UpdateEmpEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empEmployeeMasterDataProvider.UpdateEmpEmployeeMasterOfficeDetails(item);
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
        /// Delete a selected record from EmpEmployeeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> DeleteEmpEmployeeMaster(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _empEmployeeMasterBR.DeleteEmpEmployeeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _empEmployeeMasterDataProvider.DeleteEmpEmployeeMaster(item);
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
        /// Select all record from EmpEmployeeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetBySearch(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmpEmployeeMasterBySearch(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
        /// <summary>
        /// Select a record from EmpEmployeeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmpEmployeeMaster> SelectByID(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                entityResponse = _empEmployeeMasterDataProvider.GetEmpEmployeeMasterByID(item);
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
        /// Select all record from EmpEmployeeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmployeeList(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
        /// <summary>
        /// Select all record from EmpEmployeeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmployeeCentrewiseSearchList(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }        
        /// <summary>
        /// Select all record from EmpEmployeeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeRoleCentrewiseSearchList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmployeeRoleCentrewiseSearchList(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }        
        

         /// <summary>
        /// Select all record from EmpEmployeeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByCentreCodeAndDeptID(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetByCentreCodeAndDeptID(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }


        public IBaseEntityResponse<EmpEmployeeMaster> GetCurrentPassword(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                entityResponse = _empEmployeeMasterDataProvider.GetCurrentPassword(item);
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


        public IBaseEntityResponse<EmpEmployeeMaster> InsertNewPassword(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                entityResponse = _empEmployeeMasterDataProvider.InsertNewPassword(item);
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
        /// Select all record from EmpEmployeeMaster table with search parameters who are caller for CRM.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetCallerEmployeeList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetCallerEmployeeList(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetByEmployeeInCRMSales(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetByEmployeeInCRMSales(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForCRMSalesGroup(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetListEmpEmployeeMasterForCRMSalesGroup(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetListEmpEmployeeMasterForTargetException(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetListEmpEmployeeMasterForTargetException(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
        //Allocate Support Staff

        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeNameList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmployeeNameList(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmployeeDetailsForImportExcel(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmployeeDetailsForImportExcel(searchRequest);
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmpEmployeeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }

        public IBaseEntityResponse<EmpEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(EmpEmployeeMaster item)
        {

            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                entityResponse = _empEmployeeMasterDataProvider.GetDataValidationListsForEmployeeMasterExcel(item);
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

        public IBaseEntityResponse<EmpEmployeeMaster> InsertEmployeeMasterExcelUpload(EmpEmployeeMaster item)
        {
            IBaseEntityResponse<EmpEmployeeMaster> entityResponse = new BaseEntityResponse<EmpEmployeeMaster>();
            try
            {
                entityResponse = _empEmployeeMasterDataProvider.InsertEmployeeMasterExcelUpload(item);

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
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterServiceList(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                {
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmpEmployeeMasterServiceList(searchRequest);
                }
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                EmpEmployeeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
        public IBaseEntityCollectionResponse<EmpEmployeeMaster> GetEmpEmployeeMasterExecutive(EmpEmployeeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmpEmployeeMaster> EmpEmployeeMasterCollection = new BaseEntityCollectionResponse<EmpEmployeeMaster>();
            try
            {
                if (_empEmployeeMasterDataProvider != null)
                {
                    EmpEmployeeMasterCollection = _empEmployeeMasterDataProvider.GetEmpEmployeeMasterExecutive(searchRequest);
                }
                else
                {
                    EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmpEmployeeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmpEmployeeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                EmpEmployeeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmpEmployeeMasterCollection;
        }
    }
}
