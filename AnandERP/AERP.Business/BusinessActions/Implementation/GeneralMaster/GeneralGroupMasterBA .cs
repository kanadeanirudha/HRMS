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

namespace AERP.Business.BusinessActions
{
    public class GeneralGroupMasterBA : IGeneralGroupMasterBA
    {
        IGeneralGroupMasterDataProvider _generalGroupMasterDataProvider;
        IGeneralGroupMasterBR _generalGroupMasterBR;
        private ILogger _logException;
        public GeneralGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalGroupMasterBR = new GeneralGroupMasterBR();
            _generalGroupMasterDataProvider = new GeneralGroupMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> InsertGeneralGroupMaster(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalGroupMasterBR.InsertGeneralGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalGroupMasterDataProvider.InsertGeneralGroupMaster(item);
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
        /// Update a specific record  of GeneralGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> UpdateGeneralGroupMaster(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalGroupMasterBR.UpdateGeneralGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalGroupMasterDataProvider.UpdateGeneralGroupMaster(item);
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
        /// Delete a selected record from GeneralGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> DeleteGeneralGroupMaster(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalGroupMasterBR.DeleteGeneralGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalGroupMasterDataProvider.DeleteGeneralGroupMaster(item);
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
        /// Select all record from GeneralGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralGroupMaster> GetBySearch(GeneralGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralGroupMaster> GeneralGroupMasterCollection = new BaseEntityCollectionResponse<GeneralGroupMaster>();
            try
            {
                if (_generalGroupMasterDataProvider != null)
                    GeneralGroupMasterCollection = _generalGroupMasterDataProvider.GetGeneralGroupMasterBySearch(searchRequest);
                else
                {
                    GeneralGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralGroupMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> SelectByID(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                entityResponse = _generalGroupMasterDataProvider.GetGeneralGroupMasterByID(item);
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
        /// Create new record of GroupDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> InsertGroupDetails(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalGroupMasterBR.InsertGroupDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalGroupMasterDataProvider.InsertGroupDetails(item);
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
        /// Select all record from EmployeeGroupDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralGroupMaster> EmployeeGroupDetailsGetBySearch(GeneralGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralGroupMaster> GeneralGroupMasterCollection = new BaseEntityCollectionResponse<GeneralGroupMaster>();
            try
            {
                if (_generalGroupMasterDataProvider != null)
                    GeneralGroupMasterCollection = _generalGroupMasterDataProvider.GetEmployeeGroupDetailsBySearch(searchRequest);
                else
                {
                    GeneralGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralGroupMasterCollection;
        }

         /// <summary>
        /// Select a record from GeneralGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> SelectEmployeeGroupDetailsByID(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                entityResponse = _generalGroupMasterDataProvider.GetEmployeeGroupDetailsByID(item);
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
        /// Update a specific record  of EmployeeGroupDetails
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralGroupMaster> UpdateGroupDetails(GeneralGroupMaster item)
        {
            IBaseEntityResponse<GeneralGroupMaster> entityResponse = new BaseEntityResponse<GeneralGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalGroupMasterBR.UpdateGeneralGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalGroupMasterDataProvider.UpdateGroupDetails(item);
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
        
    }
}
