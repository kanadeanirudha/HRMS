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
    public class GeneralOperatorRelatedRoleBA : IGeneralOperatorRelatedRoleBA
    {
        IGeneralOperatorRelatedRoleDataProvider _generalTitleMasterDataProvider;
        IGeneralOperatorRelatedRoleBR _generalTitleMasterBR;
        private ILogger _logException;
        public GeneralOperatorRelatedRoleBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new GeneralOperatorRelatedRoleBR();
            _generalTitleMasterDataProvider = new GeneralOperatorRelatedRoleDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralOperatorRelatedRole.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> InsertGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            IBaseEntityResponse<GeneralOperatorRelatedRole> entityResponse = new BaseEntityResponse<GeneralOperatorRelatedRole>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertGeneralOperatorRelatedRoleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertGeneralOperatorRelatedRole(item);
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
        /// Update a specific record  of GeneralOperatorRelatedRole.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> UpdateGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            IBaseEntityResponse<GeneralOperatorRelatedRole> entityResponse = new BaseEntityResponse<GeneralOperatorRelatedRole>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateGeneralOperatorRelatedRoleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateGeneralOperatorRelatedRole(item);
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
        /// Delete a selected record from GeneralOperatorRelatedRole.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> DeleteGeneralOperatorRelatedRole(GeneralOperatorRelatedRole item)
        {
            IBaseEntityResponse<GeneralOperatorRelatedRole> entityResponse = new BaseEntityResponse<GeneralOperatorRelatedRole>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteGeneralOperatorRelatedRoleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteGeneralOperatorRelatedRole(item);
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
        /// Select all record from GeneralOperatorRelatedRole table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearch(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GeneralOperatorRelatedRoleCollection = new BaseEntityCollectionResponse<GeneralOperatorRelatedRole>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralOperatorRelatedRoleCollection = _generalTitleMasterDataProvider.GetGeneralOperatorRelatedRoleBySearch(searchRequest);
                else
                {
                    GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralOperatorRelatedRoleCollection;
        }
        /// <summary>
        /// Select a record from GeneralOperatorRelatedRole table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralOperatorRelatedRole> SelectByID(GeneralOperatorRelatedRole item)
        {
            IBaseEntityResponse<GeneralOperatorRelatedRole> entityResponse = new BaseEntityResponse<GeneralOperatorRelatedRole>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetGeneralOperatorRelatedRoleByID(item);
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
        /// Select all record from GeneralOperatorRelatedRole table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetBySearchList(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GeneralOperatorRelatedRoleCollection = new BaseEntityCollectionResponse<GeneralOperatorRelatedRole>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralOperatorRelatedRoleCollection = _generalTitleMasterDataProvider.GetGeneralOperatorRelatedRoleBySearchList(searchRequest);
                else
                {
                    GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralOperatorRelatedRoleCollection;
        }


        public IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GetAdminRoleCodeList(GeneralOperatorRelatedRoleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralOperatorRelatedRole> GeneralOperatorRelatedRoleCollection = new BaseEntityCollectionResponse<GeneralOperatorRelatedRole>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralOperatorRelatedRoleCollection = _generalTitleMasterDataProvider.GetAdminRoleCodeList(searchRequest);
                else
                {
                    GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralOperatorRelatedRoleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralOperatorRelatedRoleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralOperatorRelatedRoleCollection;
        }
    }



}
