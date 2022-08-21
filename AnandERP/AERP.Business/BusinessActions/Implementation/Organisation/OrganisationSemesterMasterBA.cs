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
	public class OrganisationSemesterMasterBA : IOrganisationSemesterMasterBA
	{
		IOrganisationSemesterMasterDataProvider _organisationSemesterMasterDataProvider;
		IOrganisationSemesterMasterBR _organisationSemesterMasterBR;
		private ILogger _logException;
		public OrganisationSemesterMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_organisationSemesterMasterBR = new OrganisationSemesterMasterBR();
			_organisationSemesterMasterDataProvider = new OrganisationSemesterMasterDataProvider();
		}
		/// <summary>
		/// Create new record of OrgSemesterMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSemesterMaster> InsertOrganisationSemesterMaster(OrganisationSemesterMaster item)
		{
			IBaseEntityResponse<OrganisationSemesterMaster> entityResponse = new BaseEntityResponse<OrganisationSemesterMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationSemesterMasterBR.InsertOrganisationSemesterMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSemesterMasterDataProvider.InsertOrganisationSemesterMaster(item);
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
		/// Update a specific record  of OrgSemesterMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSemesterMaster> UpdateOrganisationSemesterMaster(OrganisationSemesterMaster item)
		{
			IBaseEntityResponse<OrganisationSemesterMaster> entityResponse = new BaseEntityResponse<OrganisationSemesterMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _organisationSemesterMasterBR.UpdateOrganisationSemesterMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSemesterMasterDataProvider.UpdateOrganisationSemesterMaster(item);
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
		/// Delete a selected record from OrganisationSemesterMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSemesterMaster> DeleteOrganisationSemesterMaster(OrganisationSemesterMaster item)
		{
			IBaseEntityResponse<OrganisationSemesterMaster> entityResponse = new BaseEntityResponse<OrganisationSemesterMaster>();
			try
			{
               IValidateBusinessRuleResponse brResponse = _organisationSemesterMasterBR.DeleteOrganisationSemesterMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _organisationSemesterMasterDataProvider.DeleteOrganisationSemesterMaster(item);
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
		/// Select all record from OrganisationSemesterMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
     
        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearch(OrganisationSemesterMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<OrganisationSemesterMaster> OrganisationSemesterMasterCollection = new BaseEntityCollectionResponse<OrganisationSemesterMaster>();
			try
			{
				if (_organisationSemesterMasterDataProvider != null)
				OrganisationSemesterMasterCollection = _organisationSemesterMasterDataProvider.GetOrganisationSemesterMasterBySearch(searchRequest);
				else
				{
					OrganisationSemesterMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					OrganisationSemesterMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				OrganisationSemesterMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				OrganisationSemesterMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return OrganisationSemesterMasterCollection;
		}

		/// <summary>
		/// Select a record from OrganisationSemesterMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<OrganisationSemesterMaster> SelectByID(OrganisationSemesterMaster  item)
		{
			IBaseEntityResponse<OrganisationSemesterMaster> entityResponse = new BaseEntityResponse<OrganisationSemesterMaster>();
			try
			{

                entityResponse = _organisationSemesterMasterDataProvider.GetOrganisationSemesterMasterByID(item);
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
        /// Select all record from OrganisationSemesterMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetBySearchList(OrganisationSemesterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSemesterMaster> SemesterMasterCollection = new BaseEntityCollectionResponse<OrganisationSemesterMaster>();
            try
            {
                if (_organisationSemesterMasterDataProvider != null)
                {
                    SemesterMasterCollection = _organisationSemesterMasterDataProvider.GetOrganisationSemesterMasterGetBySearchList(searchRequest);
                }
                else
                {
                    SemesterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SemesterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SemesterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                SemesterMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SemesterMasterCollection;
        }
        //For Semester*************************************
        /// <summary>
        /// Select all record from OrganisationSemesterMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationSemesterMaster> GetSemester(OrganisationSemesterMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSemesterMaster> SemesterMasterCollection = new BaseEntityCollectionResponse<OrganisationSemesterMaster>();
            try
            {
                if (_organisationSemesterMasterDataProvider != null)
                {
                    SemesterMasterCollection = _organisationSemesterMasterDataProvider.GetOrganisationSemesterMasterGetSemester(searchRequest);
                }
                else
                {
                    SemesterMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SemesterMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SemesterMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                SemesterMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SemesterMasterCollection;
        }
	}
}
