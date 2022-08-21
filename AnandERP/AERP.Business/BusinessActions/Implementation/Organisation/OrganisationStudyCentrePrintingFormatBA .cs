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
    public class OrganisationStudyCentrePrintingFormatBA : IOrganisationStudyCentrePrintingFormatBA
    {
        IOrganisationanizationStudyCentrePrintingFormatDataProvider _organisationStudyCentrePrintingFormatDataProvider;
        IOrganisationStudyCentrePrintingFormatBR _organisationStudyCentrePrintingFormatBR;
        private ILogger _logException;
        public OrganisationStudyCentrePrintingFormatBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationStudyCentrePrintingFormatBR = new OrganisationStudyCentrePrintingFormatBR();
            _organisationStudyCentrePrintingFormatDataProvider = new OrganisationStudyCentrePrintingFormatDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationStudyCentrePrintingFormat.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> InsertOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> entityResponse = new BaseEntityResponse<OrganisationStudyCentrePrintingFormat>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentrePrintingFormatBR.InsertOrganisationStudyCentrePrintingFormatValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentrePrintingFormatDataProvider.InsertOrganisationStudyCentrePrintingFormat(item);
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
        /// Update a specific record  of OrganisationStudyCentrePrintingFormat.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> UpdateOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> entityResponse = new BaseEntityResponse<OrganisationStudyCentrePrintingFormat>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentrePrintingFormatBR.UpdateOrganisationStudyCentrePrintingFormatValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentrePrintingFormatDataProvider.UpdateOrganisationStudyCentrePrintingFormat(item);
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
        /// Delete a selected record from OrganisationStudyCentrePrintingFormat.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> DeleteOrganisationStudyCentrePrintingFormat(OrganisationStudyCentrePrintingFormat item)
        {
            IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> entityResponse = new BaseEntityResponse<OrganisationStudyCentrePrintingFormat>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentrePrintingFormatBR.DeleteOrganisationStudyCentrePrintingFormatValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentrePrintingFormatDataProvider.DeleteOrganisationStudyCentrePrintingFormat(item);
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
        /// Select all record from OrganisationStudyCentrePrintingFormat table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat> GetBySearch(OrganisationStudyCentrePrintingFormatSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat> OrganisationStudyCentrePrintingFormatCollection = new BaseEntityCollectionResponse<OrganisationStudyCentrePrintingFormat>();
            try
            {
                if (_organisationStudyCentrePrintingFormatDataProvider != null)
                    OrganisationStudyCentrePrintingFormatCollection = _organisationStudyCentrePrintingFormatDataProvider.GetOrganisationStudyCentrePrintingFormatBySearch(searchRequest);
                else
                {
                    OrganisationStudyCentrePrintingFormatCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentrePrintingFormatCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentrePrintingFormatCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentrePrintingFormatCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentrePrintingFormatCollection;
        }
        /// <summary>
        /// Select a record from OrganisationStudyCentrePrintingFormat table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> SelectByID(OrganisationStudyCentrePrintingFormat item)
        {
            IBaseEntityResponse<OrganisationStudyCentrePrintingFormat> entityResponse = new BaseEntityResponse<OrganisationStudyCentrePrintingFormat>();
            try
            {
                entityResponse = _organisationStudyCentrePrintingFormatDataProvider.GetOrganisationStudyCentrePrintingFormatByID(item);
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
