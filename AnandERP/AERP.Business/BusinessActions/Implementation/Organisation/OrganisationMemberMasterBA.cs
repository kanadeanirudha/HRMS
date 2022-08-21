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
	public class OrganisationMemberMasterBA : IOrganisationMemberMasterBA
	{
		IOrganisationMemberMasterDataProvider _organisationMemberMasterDataProvider;
		IOrganisationMemberMasterBR _organisationMemberMasterBR;
		private ILogger _logException;
		public OrganisationMemberMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_organisationMemberMasterBR = new OrganisationMemberMasterBR();
			_organisationMemberMasterDataProvider = new OrganisationMemberMasterDataProvider();
		}
		/// <summary>
		/// Create new record of OrganisationMemberMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationMemberMaster> InsertOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			IBaseEntityResponse<OrganisationMemberMaster> entityResponse = new BaseEntityResponse<OrganisationMemberMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationMemberMasterBR.InsertOrganisationMemberMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationMemberMasterDataProvider.InsertOrganisationMemberMaster(item);
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
		/// Update a specific record  of OrganisationMemberMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationMemberMaster> UpdateOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			IBaseEntityResponse<OrganisationMemberMaster> entityResponse = new BaseEntityResponse<OrganisationMemberMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationMemberMasterBR.UpdateOrganisationMemberMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationMemberMasterDataProvider.UpdateOrganisationMemberMaster(item);
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
		/// Delete a selected record from OrganisationMemberMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationMemberMaster> DeleteOrganisationMemberMaster(OrganisationMemberMaster item)
		{
			IBaseEntityResponse<OrganisationMemberMaster> entityResponse = new BaseEntityResponse<OrganisationMemberMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationMemberMasterBR.DeleteOrganisationMemberMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationMemberMasterDataProvider.DeleteOrganisationMemberMaster(item);
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
		/// Select all record from OrganisationMemberMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<OrganisationMemberMaster> GetBySearch(OrganisationMemberMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationMemberMaster> OrganisationMemberMasterCollection = new BaseEntityCollectionResponse<OrganisationMemberMaster>();
			try
			{
				if (_organisationMemberMasterDataProvider != null)
				OrganisationMemberMasterCollection = _organisationMemberMasterDataProvider.GetOrganisationMemberMasterBySearch(searchRequest);
				else
				{
					OrganisationMemberMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OrganisationMemberMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OrganisationMemberMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OrganisationMemberMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OrganisationMemberMasterCollection;
		}
        /// <summary>
        /// Select all record from OrganisationMemberMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMemberMaster> GetUserEntityCentrewiseSearchList(OrganisationMemberMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMemberMaster> OrganisationMemberMasterCollection = new BaseEntityCollectionResponse<OrganisationMemberMaster>();
            try
            {
                if (_organisationMemberMasterDataProvider != null)
                    OrganisationMemberMasterCollection = _organisationMemberMasterDataProvider.GetUserEntityCentrewiseSearchList(searchRequest);
                else
                {
                    OrganisationMemberMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationMemberMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationMemberMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationMemberMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationMemberMasterCollection;
        }
		/// <summary>
		/// Select a record from OrganisationMemberMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationMemberMaster> SelectByID(OrganisationMemberMaster item)
		{
			IBaseEntityResponse<OrganisationMemberMaster> entityResponse = new BaseEntityResponse<OrganisationMemberMaster>();
			try
			{
				 entityResponse = _organisationMemberMasterDataProvider.GetOrganisationMemberMasterByID(item);
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
