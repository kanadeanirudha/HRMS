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
	public class OrganisationSubGrpRuleSessionwiseBA : IOrganisationSubGrpRuleSessionwiseBA
	{
		IOrganisationSubGrpRuleSessionwiseDataProvider _organisationSubGrpRuleSessionwiseDataProvider;
		IOrganisationSubGrpRuleSessionwiseBR _organisationSubGrpRuleSessionwiseBR;
		private ILogger _logException;
		public OrganisationSubGrpRuleSessionwiseBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_organisationSubGrpRuleSessionwiseBR = new OrganisationSubGrpRuleSessionwiseBR();
			_organisationSubGrpRuleSessionwiseDataProvider = new OrganisationSubGrpRuleSessionwiseDataProvider();
		}
		/// <summary>
		/// Create new record of OrganisationSubGrpRuleSessionwise.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> InsertOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> entityResponse = new BaseEntityResponse<OrganisationSubGrpRuleSessionwise>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationSubGrpRuleSessionwiseBR.InsertOrganisationSubGrpRuleSessionwiseValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSubGrpRuleSessionwiseDataProvider.InsertOrganisationSubGrpRuleSessionwise(item);
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
		/// Update a specific record  of OrganisationSubGrpRuleSessionwise.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> UpdateOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> entityResponse = new BaseEntityResponse<OrganisationSubGrpRuleSessionwise>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationSubGrpRuleSessionwiseBR.UpdateOrganisationSubGrpRuleSessionwiseValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSubGrpRuleSessionwiseDataProvider.UpdateOrganisationSubGrpRuleSessionwise(item);
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
		/// Delete a selected record from OrganisationSubGrpRuleSessionwise.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> DeleteOrganisationSubGrpRuleSessionwise(OrganisationSubGrpRuleSessionwise item)
		{
			IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> entityResponse = new BaseEntityResponse<OrganisationSubGrpRuleSessionwise>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationSubGrpRuleSessionwiseBR.DeleteOrganisationSubGrpRuleSessionwiseValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSubGrpRuleSessionwiseDataProvider.DeleteOrganisationSubGrpRuleSessionwise(item);
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
		/// Select all record from OrganisationSubGrpRuleSessionwise table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise> GetBySearch(OrganisationSubGrpRuleSessionwiseSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise> OrganisationSubGrpRuleSessionwiseCollection = new BaseEntityCollectionResponse<OrganisationSubGrpRuleSessionwise>();
			try
			{
				if (_organisationSubGrpRuleSessionwiseDataProvider != null)
				OrganisationSubGrpRuleSessionwiseCollection = _organisationSubGrpRuleSessionwiseDataProvider.GetOrganisationSubGrpRuleSessionwiseBySearch(searchRequest);
				else
				{
					OrganisationSubGrpRuleSessionwiseCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OrganisationSubGrpRuleSessionwiseCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OrganisationSubGrpRuleSessionwiseCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OrganisationSubGrpRuleSessionwiseCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OrganisationSubGrpRuleSessionwiseCollection;
		}
		/// <summary>
		/// Select a record from OrganisationSubGrpRuleSessionwise table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> SelectByID(OrganisationSubGrpRuleSessionwise item)
		{
			IBaseEntityResponse<OrganisationSubGrpRuleSessionwise> entityResponse = new BaseEntityResponse<OrganisationSubGrpRuleSessionwise>();
			try
			{
				 entityResponse = _organisationSubGrpRuleSessionwiseDataProvider.GetOrganisationSubGrpRuleSessionwiseByID(item);
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
