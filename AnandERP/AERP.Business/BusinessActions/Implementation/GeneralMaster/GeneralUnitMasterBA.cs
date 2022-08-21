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
    public class GeneralUnitMasterBA : IGeneralUnitMasterBA
    {
        IGeneralUnitMasterDataProvider _generalUnitMasterDataProvider;
        IGeneralUnitMasterBR _generalUnitMasterBR;
        private ILogger _logException;
        public GeneralUnitMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalUnitMasterBR = new GeneralUnitMasterBR();
            _generalUnitMasterDataProvider = new GeneralUnitMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitMaster> InsertGeneralUnitMaster(GeneralUnitMaster item)
        {
            IBaseEntityResponse<GeneralUnitMaster> entityResponse = new BaseEntityResponse<GeneralUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalUnitMasterBR.InsertGeneralUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalUnitMasterDataProvider.InsertGeneralUnitMaster(item);
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
        /// Update a specific record  of GeneralUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitMaster> UpdateGeneralUnitMaster(GeneralUnitMaster item)
        {
            IBaseEntityResponse<GeneralUnitMaster> entityResponse = new BaseEntityResponse<GeneralUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalUnitMasterBR.UpdateGeneralUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalUnitMasterDataProvider.UpdateGeneralUnitMaster(item);
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
        /// Delete a selected record from GeneralUnitMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitMaster> DeleteGeneralUnitMaster(GeneralUnitMaster item)
        {
            IBaseEntityResponse<GeneralUnitMaster> entityResponse = new BaseEntityResponse<GeneralUnitMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalUnitMasterBR.DeleteGeneralUnitMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalUnitMasterDataProvider.DeleteGeneralUnitMaster(item);
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
        /// Select all record from GeneralUnitMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearch(GeneralUnitMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnitMaster> GeneralUnitMasterCollection = new BaseEntityCollectionResponse<GeneralUnitMaster>();
            try
            {
                if (_generalUnitMasterDataProvider != null)
                    GeneralUnitMasterCollection = _generalUnitMasterDataProvider.GetGeneralUnitMasterBySearch(searchRequest);
                else
                {
                    GeneralUnitMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitMasterCollection;
        }



        public IBaseEntityCollectionResponse<GeneralUnitMaster> GetBySearchList(GeneralUnitMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnitMaster> GeneralUnitMasterCollection = new BaseEntityCollectionResponse<GeneralUnitMaster>();
            try
            {
                if (_generalUnitMasterDataProvider != null)
                    GeneralUnitMasterCollection = _generalUnitMasterDataProvider.GetGeneralUnitMasterBySearchList(searchRequest);
                else
                {
                    GeneralUnitMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralUnitMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitMaster> SelectByID(GeneralUnitMaster item)
        {
            IBaseEntityResponse<GeneralUnitMaster> entityResponse = new BaseEntityResponse<GeneralUnitMaster>();
            try
            {
                entityResponse = _generalUnitMasterDataProvider.GetGeneralUnitMasterByID(item);
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
