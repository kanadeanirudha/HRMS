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
    public class GeneralRelationshipTypeMasterBA : IGeneralRelationshipTypeMasterBA
    {
        IGeneralRelationshipTypeMasterDataProvider _generalRelationshipTypeMasterDataProvider;
        IGeneralRelationshipTypeMasterBR _generalRelationshipTypeMasterBR;
        private ILogger _logException;
        public GeneralRelationshipTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRelationshipTypeMasterBR = new GeneralRelationshipTypeMasterBR();
            _generalRelationshipTypeMasterDataProvider = new GeneralRelationshipTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralRelationshipTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> InsertGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            IBaseEntityResponse<GeneralRelationshipTypeMaster> entityResponse = new BaseEntityResponse<GeneralRelationshipTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRelationshipTypeMasterBR.InsertGeneralRelationshipTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRelationshipTypeMasterDataProvider.InsertGeneralRelationshipTypeMaster(item);
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
        /// Update a specific record  of GeneralRelationshipTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> UpdateGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            IBaseEntityResponse<GeneralRelationshipTypeMaster> entityResponse = new BaseEntityResponse<GeneralRelationshipTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRelationshipTypeMasterBR.UpdateGeneralRelationshipTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRelationshipTypeMasterDataProvider.UpdateGeneralRelationshipTypeMaster(item);
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
        /// Delete a selected record from GeneralRelationshipTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralRelationshipTypeMaster> DeleteGeneralRelationshipTypeMaster(GeneralRelationshipTypeMaster item)
        {
            IBaseEntityResponse<GeneralRelationshipTypeMaster> entityResponse = new BaseEntityResponse<GeneralRelationshipTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRelationshipTypeMasterBR.DeleteGeneralRelationshipTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalRelationshipTypeMasterDataProvider.DeleteGeneralRelationshipTypeMaster(item);
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
        /// Select all record from GeneralRelationshipTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetBySearch(GeneralRelationshipTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GeneralRelationshipTypeMasterCollection = new BaseEntityCollectionResponse<GeneralRelationshipTypeMaster>();
            try
            {
                if (_generalRelationshipTypeMasterDataProvider != null)
                    GeneralRelationshipTypeMasterCollection = _generalRelationshipTypeMasterDataProvider.GetGeneralRelationshipTypeMasterBySearch(searchRequest);
                else
                {
                    GeneralRelationshipTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralRelationshipTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralRelationshipTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralRelationshipTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralRelationshipTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralRelationshipTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> GetGeneralRelationshipTypeMasterGetBySearchList(GeneralRelationshipTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> categoryMasterCollection = new BaseEntityCollectionResponse<GeneralRelationshipTypeMaster>();
            try
            {
                if (_generalRelationshipTypeMasterDataProvider != null)
                {
                    categoryMasterCollection = _generalRelationshipTypeMasterDataProvider.GetGeneralRelationshipTypeMasterGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }





        public IBaseEntityResponse<GeneralRelationshipTypeMaster> SelectByID(GeneralRelationshipTypeMaster item)
        {
            IBaseEntityResponse<GeneralRelationshipTypeMaster> entityResponse = new BaseEntityResponse<GeneralRelationshipTypeMaster>();
            try
            {
                entityResponse = _generalRelationshipTypeMasterDataProvider.GetGeneralRelationshipTypeMasterByID(item);
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
