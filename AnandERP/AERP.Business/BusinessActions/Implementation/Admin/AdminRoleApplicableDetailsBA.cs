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
    public class AdminRoleApplicableDetailsBA : IAdminRoleApplicableDetailsBA
    {
        IAdminRoleApplicableDetailsDataProvider _adminRoleApplicableDetailsDataProvider;
        IAdminRoleApplicableDetailsBR _adminRoleApplicableDetailsBR;
        private ILogger _logException;

        public AdminRoleApplicableDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleApplicableDetailsBR = new AdminRoleApplicableDetailsBR();
            _adminRoleApplicableDetailsDataProvider = new AdminRoleApplicableDetailsDataProvider();
        }

        /// <summary>
        /// Create new record of AdminRoleApplicableDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> InsertAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> entityResponse = new BaseEntityResponse<AdminRoleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleApplicableDetailsBR.InsertAdminRoleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleApplicableDetailsDataProvider.InsertAdminRoleApplicableDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of AdminRoleApplicableDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> UpdateAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> entityResponse = new BaseEntityResponse<AdminRoleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleApplicableDetailsBR.UpdateAdminRoleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleApplicableDetailsDataProvider.UpdateAdminRoleApplicableDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from AdminRoleApplicableDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<AdminRoleApplicableDetails> DeleteAdminRoleApplicableDetails(AdminRoleApplicableDetails item)
        {
            IBaseEntityResponse<AdminRoleApplicableDetails> entityResponse = new BaseEntityResponse<AdminRoleApplicableDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleApplicableDetailsBR.DeleteAdminRoleApplicableDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleApplicableDetailsDataProvider.DeleteAdminRoleApplicableDetails(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from AdminRoleApplicableDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetAdminRoleApplicableDetailsBySearch(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }


        /// <summary>
        /// Select a record from AdminRoleApplicableDetails table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleApplicableDetails> SelectByID(AdminRoleApplicableDetails item)
        {

            IBaseEntityResponse<AdminRoleApplicableDetails> entityResponse = new BaseEntityResponse<AdminRoleApplicableDetails>();
            try
            {
                entityResponse = _adminRoleApplicableDetailsDataProvider.GetAdminRoleApplicableDetailsByID(item);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminRegularListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetAdminRegularListBySearch(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetAdminAdditionalListBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetAdminAdditionalListBySearch(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetRoleListForLoginUserIDBySearch(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetRoleListForLoginUserIDBySearch(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForAcademicManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForAcademicManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }



        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForFinanceManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForFinanceManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        /// <summary>
        /// Select AdminRoleCode By EmployeeID and CentreCode and DeaprtmentID .
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>

        public IBaseEntityResponse<AdminRoleApplicableDetails> SelectActiveAdminRoleCodeByEmployeeID(AdminRoleApplicableDetails item)
        {
           
            IBaseEntityResponse<AdminRoleApplicableDetails> entityResponse = new BaseEntityResponse<AdminRoleApplicableDetails>();
            try
            {
                entityResponse = _adminRoleApplicableDetailsDataProvider.SelectActiveAdminRoleCodeByEmployeeID(item);
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

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForPurchaseManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForPurchaseManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForStoreManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForStoreManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForSalesManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForSalesManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleApplicableDetails> GetStudyCentreListForHRManagerByAdminRoleMasterID(AdminRoleApplicableDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> AdminRoleApplicableDetailsCollection = new BaseEntityCollectionResponse<AdminRoleApplicableDetails>();
            try
            {
                if (_adminRoleApplicableDetailsDataProvider != null)
                {
                    AdminRoleApplicableDetailsCollection = _adminRoleApplicableDetailsDataProvider.GetStudyCentreListForHRManagerByAdminRoleMasterID(searchRequest);
                }
                else
                {
                    AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleApplicableDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleApplicableDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleApplicableDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleApplicableDetailsCollection;
        }
    }
}
