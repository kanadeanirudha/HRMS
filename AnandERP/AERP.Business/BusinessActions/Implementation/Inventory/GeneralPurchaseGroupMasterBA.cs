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
    public class GeneralPurchaseGroupMasterBA : IGeneralPurchaseGroupMasterBA
    {
        IGeneralPurchaseGroupMasterDataProvider _GeneralPurchaseGroupMasterDataProvider;
        IGeneralPurchaseGroupMasterBR _GeneralPurchaseGroupMasterBR;

        private ILogger _logException;
        public GeneralPurchaseGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPurchaseGroupMasterBR = new GeneralPurchaseGroupMasterBR();
            _GeneralPurchaseGroupMasterDataProvider = new GeneralPurchaseGroupMasterDataProvider();
        }

        /// Create new record of GeneralPurchaseGroupMaster.
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> InsertGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            IBaseEntityResponse<GeneralPurchaseGroupMaster> entityResponse = new BaseEntityResponse<GeneralPurchaseGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPurchaseGroupMasterBR.InsertGeneralPurchaseGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPurchaseGroupMasterDataProvider.InsertGeneralPurchaseGroupMaster(item);
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

        /// Update a specific record  of GeneralPurchaseGroupMaster.
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> UpdateGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            IBaseEntityResponse<GeneralPurchaseGroupMaster> entityResponse = new BaseEntityResponse<GeneralPurchaseGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPurchaseGroupMasterBR.UpdateGeneralPurchaseGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPurchaseGroupMasterDataProvider.UpdateGeneralPurchaseGroupMaster(item);
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

        /// Delete a selected record from GeneralPurchaseGroupMaster.
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item)
        {
            IBaseEntityResponse<GeneralPurchaseGroupMaster> entityResponse = new BaseEntityResponse<GeneralPurchaseGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPurchaseGroupMasterBR.DeleteGeneralPurchaseGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPurchaseGroupMasterDataProvider.DeleteGeneralPurchaseGroupMaster(item);
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

        /// Select all record from GeneralPurchaseGroupMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetBySearch(GeneralPurchaseGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GeneralPurchaseGroupMasterCollection = new BaseEntityCollectionResponse<GeneralPurchaseGroupMaster>();
            try
            {
                if (_GeneralPurchaseGroupMasterDataProvider != null)
                    GeneralPurchaseGroupMasterCollection = _GeneralPurchaseGroupMasterDataProvider.GetGeneralPurchaseGroupMasterBySearch(searchRequest);
                else
                {
                    GeneralPurchaseGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPurchaseGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPurchaseGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPurchaseGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPurchaseGroupMasterCollection;
        }

        /// Select a record from GeneralPurchaseGroupMaster table by ID.
        public IBaseEntityResponse<GeneralPurchaseGroupMaster> SelectByID(GeneralPurchaseGroupMaster item)
        {
            IBaseEntityResponse<GeneralPurchaseGroupMaster> entityResponse = new BaseEntityResponse<GeneralPurchaseGroupMaster>();
            try
            {
                entityResponse = _GeneralPurchaseGroupMasterDataProvider.GetGeneralPurchaseGroupMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterSearchList(GeneralPurchaseGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GeneralPurchaseGroupMasterCollection = new BaseEntityCollectionResponse<GeneralPurchaseGroupMaster>();
            try
            {
                if (_GeneralPurchaseGroupMasterDataProvider != null)
                    GeneralPurchaseGroupMasterCollection = _GeneralPurchaseGroupMasterDataProvider.GetGeneralPurchaseGroupMasterSearchList(searchRequest);
                else
                {
                    GeneralPurchaseGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPurchaseGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPurchaseGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPurchaseGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPurchaseGroupMasterCollection;
        }
    }
}
