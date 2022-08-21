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
	public class EmployeePHdGuideRecognisationDetailsBA : IEmployeePHdGuideRecognisationDetailsBA
	{
        IEmployeePHdGuideRecognisationDetailsDataProvider _employeePHdGuideRecognisationDetailsDataProvider;
		IEmployeePHdGuideRecognisationDetailsBR _employeePHdGuideRecognisationDetailsBR;
		private ILogger _logException;
		public EmployeePHdGuideRecognisationDetailsBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_employeePHdGuideRecognisationDetailsBR = new EmployeePHdGuideRecognisationDetailsBR();
			_employeePHdGuideRecognisationDetailsDataProvider = new EmployeePHdGuideRecognisationDetailsDataProvider();
		}
		/// <summary>
		/// Create new record of EmployeePHdGuideRecognisationDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.InsertEmployeePHdGuideRecognisationDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.InsertEmployeePHdGuideRecognisationDetails(item);
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
		/// Update a specific record  of EmployeePHdGuideRecognisationDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.UpdateEmployeePHdGuideRecognisationDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.UpdateEmployeePHdGuideRecognisationDetails(item);
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
		/// Delete a selected record from EmployeePHdGuideRecognisationDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideRecognisationDetails(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.DeleteEmployeePHdGuideRecognisationDetailsValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.DeleteEmployeePHdGuideRecognisationDetails(item);
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
		/// Select all record from EmployeePHdGuideRecognisationDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearch(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> EmployeePHdGuideRecognisationDetailsCollection = new BaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails>();
			try
			{
				if (_employeePHdGuideRecognisationDetailsDataProvider != null)
				EmployeePHdGuideRecognisationDetailsCollection = _employeePHdGuideRecognisationDetailsDataProvider.GetEmployeePHdGuideRecognisationDetailsBySearch(searchRequest);
				else
				{
					EmployeePHdGuideRecognisationDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeePHdGuideRecognisationDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeePHdGuideRecognisationDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeePHdGuideRecognisationDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeePHdGuideRecognisationDetailsCollection;
		}
		/// <summary>
		/// Select a record from EmployeePHdGuideRecognisationDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByID(EmployeePHdGuideRecognisationDetails item)
		{
			IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
			try
			{
				 entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.GetEmployeePHdGuideRecognisationDetailsByID(item);
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
        /// Create new record of EmployeePHdGuideStudentsDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> InsertEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.InsertEmployeePHdGuideRecognisationDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.InsertEmployeePHdGuideStudentsDetails(item);
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
        /// Update a specific record  of EmployeePHdGuideStudentsDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> UpdateEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.UpdateEmployeePHdGuideRecognisationDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.UpdateEmployeePHdGuideStudentsDetails(item);
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
        /// Delete a selected record from EmployeePHdGuideStudentsDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> DeleteEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePHdGuideRecognisationDetailsBR.DeleteEmployeePHdGuideRecognisationDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.DeleteEmployeePHdGuideStudentsDetails(item);
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
        /// Select all record from EmployeePHdGuideStudentsDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> GetBySearchEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails> EmployeePHdGuideStudentsDetailsCollection = new BaseEntityCollectionResponse<EmployeePHdGuideRecognisationDetails>();
            try
            {
                if (_employeePHdGuideRecognisationDetailsDataProvider != null)
                    EmployeePHdGuideStudentsDetailsCollection = _employeePHdGuideRecognisationDetailsDataProvider.GetEmployeePHdGuideStudentsDetailsBySearch(searchRequest);
                else
                {
                    EmployeePHdGuideStudentsDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePHdGuideStudentsDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePHdGuideStudentsDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePHdGuideStudentsDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePHdGuideStudentsDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeePHdGuideStudentsDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> SelectByIDEmployeePHdGuideStudentsDetails(EmployeePHdGuideRecognisationDetails item)
        {
            IBaseEntityResponse<EmployeePHdGuideRecognisationDetails> entityResponse = new BaseEntityResponse<EmployeePHdGuideRecognisationDetails>();
            try
            {
                entityResponse = _employeePHdGuideRecognisationDetailsDataProvider.GetEmployeePHdGuideStudentsDetailsByID(item);
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

