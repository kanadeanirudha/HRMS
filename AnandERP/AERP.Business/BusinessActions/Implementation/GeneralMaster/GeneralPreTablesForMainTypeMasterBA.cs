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
    public class GeneralPreTablesForMainTypeMasterBA : IGeneralPreTablesForMainTypeMasterBA
    {
        IGeneralPreTablesForMainTypeMasterDataProvider _generalPreTablesForMainTypeMasterDataProvider;
        IGeneralPreTablesForMainTypeMasterBR _generalPreTablesForMainTypeMasterBR;
        private ILogger _logException;
        public GeneralPreTablesForMainTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalPreTablesForMainTypeMasterBR = new GeneralPreTablesForMainTypeMasterBR();
            _generalPreTablesForMainTypeMasterDataProvider = new GeneralPreTablesForMainTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPreTablesForMainTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> InsertGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPreTablesForMainTypeMasterBR.InsertGeneralPreTablesForMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPreTablesForMainTypeMasterDataProvider.InsertGeneralPreTablesForMainTypeMaster(item);
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
        /// Update a specific record  of GeneralPreTablesForMainTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> UpdateGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPreTablesForMainTypeMasterBR.UpdateGeneralPreTablesForMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPreTablesForMainTypeMasterDataProvider.UpdateGeneralPreTablesForMainTypeMaster(item);
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
        /// Delete a selected record from GeneralPreTablesForMainTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> DeleteGeneralPreTablesForMainTypeMaster(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPreTablesForMainTypeMasterBR.DeleteGeneralPreTablesForMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPreTablesForMainTypeMasterDataProvider.DeleteGeneralPreTablesForMainTypeMaster(item);
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
        /// Select all record from GeneralPreTablesForMainTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> GetBySearch(GeneralPreTablesForMainTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster> GeneralPreTablesForMainTypeMasterCollection = new BaseEntityCollectionResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                if (_generalPreTablesForMainTypeMasterDataProvider != null)
                    GeneralPreTablesForMainTypeMasterCollection = _generalPreTablesForMainTypeMasterDataProvider.GetGeneralPreTablesForMainTypeMasterBySearch(searchRequest);
                else
                {
                    GeneralPreTablesForMainTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPreTablesForMainTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPreTablesForMainTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPreTablesForMainTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPreTablesForMainTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralPreTablesForMainTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> SelectByID(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                entityResponse = _generalPreTablesForMainTypeMasterDataProvider.GetGeneralPreTablesForMainTypeMasterByID(item);
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
