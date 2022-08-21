using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
	public class EmployeeProjectWorksMasterBA : IEmployeeProjectWorksMasterBA
	{
		IEmployeeProjectWorksMasterDataProvider _employeeProjectWorksMasterDataProvider;
		IEmployeeProjectWorksMasterBR _employeeProjectWorksMasterBR;
		private ILogger _logException;
		public EmployeeProjectWorksMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_employeeProjectWorksMasterBR = new EmployeeProjectWorksMasterBR();
			_employeeProjectWorksMasterDataProvider = new EmployeeProjectWorksMasterDataProvider();
		}
		/// <summary>
		/// Create new record of EmployeeProjectWorksMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.InsertEmployeeProjectWorksMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeProjectWorksMasterDataProvider.InsertEmployeeProjectWorksMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Update a specific record  of EmployeeProjectWorksMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.UpdateEmployeeProjectWorksMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeProjectWorksMasterDataProvider.UpdateEmployeeProjectWorksMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Delete a selected record from EmployeeProjectWorksMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksMaster(EmployeeProjectWorksMaster item)
		{
			IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.DeleteEmployeeProjectWorksMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeProjectWorksMasterDataProvider.DeleteEmployeeProjectWorksMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Select all record from EmployeeProjectWorksMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearch(EmployeeProjectWorksMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> EmployeeProjectWorksMasterCollection = new BaseEntityCollectionResponse<EmployeeProjectWorksMaster>();
			try
			{
				if (_employeeProjectWorksMasterDataProvider != null)
				EmployeeProjectWorksMasterCollection = _employeeProjectWorksMasterDataProvider.GetEmployeeProjectWorksMasterBySearch(searchRequest);
				else
				{
					EmployeeProjectWorksMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeeProjectWorksMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeeProjectWorksMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeeProjectWorksMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeeProjectWorksMasterCollection;
		}


        	/// <summary>
		/// Select all record from EmployeeProjectWorksMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetAppliedDetails(EmployeeProjectWorksMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> EmployeeProjectWorksMasterCollection = new BaseEntityCollectionResponse<EmployeeProjectWorksMaster>();
			try
			{
				if (_employeeProjectWorksMasterDataProvider != null)
                    EmployeeProjectWorksMasterCollection = _employeeProjectWorksMasterDataProvider.GetAppliedDetailsEmployeeProjectWorksMasterBySearch(searchRequest);
				else
				{
					EmployeeProjectWorksMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeeProjectWorksMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeeProjectWorksMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeeProjectWorksMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeeProjectWorksMasterCollection;
		}
        
		/// <summary>
		/// Select a record from EmployeeProjectWorksMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeProjectWorksMaster> SelectByID(EmployeeProjectWorksMaster item)
		{
			IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
			try
			{
				 entityResponse = _employeeProjectWorksMasterDataProvider.GetEmployeeProjectWorksMasterByID(item);
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
        /// Create new record of EmployeeProjectWorksDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeProjectWorksMaster> InsertEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.InsertEmployeeProjectWorksMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeProjectWorksMasterDataProvider.InsertEmployeeProjectWorksDetails(item);
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
        /// Update a specific record  of EmployeeProjectWorksDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeProjectWorksMaster> UpdateEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.UpdateEmployeeProjectWorksMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeProjectWorksMasterDataProvider.UpdateEmployeeProjectWorksDetails(item);
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
        /// Delete a selected record from EmployeeProjectWorksDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeProjectWorksMaster> DeleteEmployeeProjectWorksDetails(EmployeeProjectWorksMaster item)
        {
            IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeProjectWorksMasterBR.DeleteEmployeeProjectWorksMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeProjectWorksMasterDataProvider.DeleteEmployeeProjectWorksDetails(item);
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
        /// Select all record from EmployeeProjectWorksDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> GetBySearchEmployeeProjectWorksDetails(EmployeeProjectWorksMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> EmployeeProjectWorksDetailsCollection = new BaseEntityCollectionResponse<EmployeeProjectWorksMaster>();
            try
            {
                if (_employeeProjectWorksMasterDataProvider != null)
                    EmployeeProjectWorksDetailsCollection = _employeeProjectWorksMasterDataProvider.GetEmployeeProjectWorksDetailsBySearch(searchRequest);
                else
                {
                    EmployeeProjectWorksDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeProjectWorksDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeProjectWorksDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeProjectWorksDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeProjectWorksDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeProjectWorksDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeProjectWorksMaster> SelectEmployeeCentreCode(EmployeeProjectWorksMaster item)
        {
            IBaseEntityResponse<EmployeeProjectWorksMaster> entityResponse = new BaseEntityResponse<EmployeeProjectWorksMaster>();
            try
            {
                entityResponse = _employeeProjectWorksMasterDataProvider.SelectEmployeeCentreCode(item);
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

