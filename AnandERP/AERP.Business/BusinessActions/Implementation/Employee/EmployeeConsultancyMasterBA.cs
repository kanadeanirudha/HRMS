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
	public class EmployeeConsultancyMasterBA : IEmployeeConsultancyMasterBA
	{
		IEmployeeConsultancyMasterDataProvider _employeeConsultancyMasterDataProvider;
		IEmployeeConsultancyMasterBR _employeeConsultancyMasterBR;
		private ILogger _logException;
		public EmployeeConsultancyMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_employeeConsultancyMasterBR = new EmployeeConsultancyMasterBR();
			_employeeConsultancyMasterDataProvider = new EmployeeConsultancyMasterDataProvider();
		}
		/// <summary>
		/// Create new record of EmployeeConsultancyMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
		{
			IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.InsertEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeConsultancyMasterDataProvider.InsertEmployeeConsultancyMaster(item);
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
		/// Update a specific record  of EmployeeConsultancyMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
		{
			IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.UpdateEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeConsultancyMasterDataProvider.UpdateEmployeeConsultancyMaster(item);
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
		/// Delete a selected record from EmployeeConsultancyMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyMaster(EmployeeConsultancyMaster item)
		{
			IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.DeleteEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _employeeConsultancyMasterDataProvider.DeleteEmployeeConsultancyMaster(item);
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
		/// Select all record from EmployeeConsultancyMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearch(EmployeeConsultancyMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeConsultancyMaster> EmployeeConsultancyMasterCollection = new BaseEntityCollectionResponse<EmployeeConsultancyMaster>();
			try
			{
				if (_employeeConsultancyMasterDataProvider != null)
				EmployeeConsultancyMasterCollection = _employeeConsultancyMasterDataProvider.GetEmployeeConsultancyMasterBySearch(searchRequest);
				else
				{
					EmployeeConsultancyMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeeConsultancyMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeeConsultancyMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeeConsultancyMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeeConsultancyMasterCollection;
		}
		/// <summary>
		/// Select a record from EmployeeConsultancyMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<EmployeeConsultancyMaster> SelectByID(EmployeeConsultancyMaster item)
		{
			IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
				 entityResponse = _employeeConsultancyMasterDataProvider.GetEmployeeConsultancyMasterByID(item);
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
		/// Select all record from EmployeeConsultancyMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetAppliedDetails(EmployeeConsultancyMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<EmployeeConsultancyMaster> EmployeeConsultancyMasterCollection = new BaseEntityCollectionResponse<EmployeeConsultancyMaster>();
			try
			{
				if (_employeeConsultancyMasterDataProvider != null)
                    EmployeeConsultancyMasterCollection = _employeeConsultancyMasterDataProvider.GetEmployeeConsultancyMasterAppliedDetails(searchRequest);
				else
				{
					EmployeeConsultancyMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeeConsultancyMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeeConsultancyMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeeConsultancyMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeeConsultancyMasterCollection;
		}
        

		/// <summary>
		/// Create new record of EmployeeConsultancyDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<EmployeeConsultancyMaster> InsertEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
		{
            IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.InsertEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _employeeConsultancyMasterDataProvider.InsertEmployeeConsultancyDetails(item);
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
		/// Update a specific record  of EmployeeConsultancyDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<EmployeeConsultancyMaster> UpdateEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
		{
            IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
                IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.UpdateEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _employeeConsultancyMasterDataProvider.UpdateEmployeeConsultancyDetails(item);
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
		/// Delete a selected record from EmployeeConsultancyDetails.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<EmployeeConsultancyMaster> DeleteEmployeeConsultancyDetails(EmployeeConsultancyMaster item)
		{
            IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
                IValidateBusinessRuleResponse brResponse = _employeeConsultancyMasterBR.DeleteEmployeeConsultancyMasterValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _employeeConsultancyMasterDataProvider.DeleteEmployeeConsultancyDetails(item);
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
		/// Select all record from EmployeeConsultancyDetails table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeConsultancyMaster> GetBySearchEmployeeConsultancyDetails(EmployeeConsultancyMasterSearchRequest searchRequest)
		{
            IBaseEntityCollectionResponse<EmployeeConsultancyMaster> EmployeeConsultancyDetailsCollection = new BaseEntityCollectionResponse<EmployeeConsultancyMaster>();
			try
			{
                if (_employeeConsultancyMasterDataProvider != null)
                    EmployeeConsultancyDetailsCollection = _employeeConsultancyMasterDataProvider.GetEmployeeConsultancyDetailsBySearch(searchRequest);
				else
				{
					EmployeeConsultancyDetailsCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					EmployeeConsultancyDetailsCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				EmployeeConsultancyDetailsCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				EmployeeConsultancyDetailsCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return EmployeeConsultancyDetailsCollection;
		}
		/// <summary>
		/// Select a record from EmployeeConsultancyDetails table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<EmployeeConsultancyMaster> SelectEmployeeCentreCode(EmployeeConsultancyMaster item)
		{
            IBaseEntityResponse<EmployeeConsultancyMaster> entityResponse = new BaseEntityResponse<EmployeeConsultancyMaster>();
			try
			{
                entityResponse = _employeeConsultancyMasterDataProvider.SelectEmployeeCentreCode(item);
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