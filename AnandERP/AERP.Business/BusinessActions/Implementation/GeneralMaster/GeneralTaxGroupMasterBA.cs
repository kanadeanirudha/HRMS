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
    public class GeneralTaxGroupMasterBA : IGeneralTaxGroupMasterBA
    {
        IGeneralTaxGroupMasterDataProvider _generalTitleMasterDataProvider;
        IGeneralTaxGroupMasterBR _generalTitleMasterBR;
        private ILogger _logException;
        public GeneralTaxGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalTitleMasterBR = new GeneralTaxGroupMasterBR();
            _generalTitleMasterDataProvider = new GeneralTaxGroupMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralTaxGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> InsertGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            IBaseEntityResponse<GeneralTaxGroupMaster> entityResponse = new BaseEntityResponse<GeneralTaxGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.InsertGeneralTaxGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.InsertGeneralTaxGroupMaster(item);
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
        /// Update a specific record  of GeneralTaxGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> UpdateGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            IBaseEntityResponse<GeneralTaxGroupMaster> entityResponse = new BaseEntityResponse<GeneralTaxGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.UpdateGeneralTaxGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.UpdateGeneralTaxGroupMaster(item);
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
        /// Delete a selected record from GeneralTaxGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> DeleteGeneralTaxGroupMaster(GeneralTaxGroupMaster item)
        {
            IBaseEntityResponse<GeneralTaxGroupMaster> entityResponse = new BaseEntityResponse<GeneralTaxGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalTitleMasterBR.DeleteGeneralTaxGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalTitleMasterDataProvider.DeleteGeneralTaxGroupMaster(item);
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
        /// Select all record from GeneralTaxGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetBySearch(GeneralTaxGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GeneralTaxGroupMasterCollection = new BaseEntityCollectionResponse<GeneralTaxGroupMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralTaxGroupMasterCollection = _generalTitleMasterDataProvider.GetGeneralTaxGroupMasterBySearch(searchRequest);
                else
                {
                    GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaxGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaxGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaxGroupMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralTaxGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralTaxGroupMaster> SelectByID(GeneralTaxGroupMaster item)
        {
            IBaseEntityResponse<GeneralTaxGroupMaster> entityResponse = new BaseEntityResponse<GeneralTaxGroupMaster>();
            try
            {
                entityResponse = _generalTitleMasterDataProvider.GetGeneralTaxGroupMasterByID(item);
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
        /// Select all record from GeneralTaxGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetGeneralTaxGroupMasterList(GeneralTaxGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GeneralTaxGroupMasterCollection = new BaseEntityCollectionResponse<GeneralTaxGroupMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralTaxGroupMasterCollection = _generalTitleMasterDataProvider.GetGeneralTaxGroupMasterBySearchList(searchRequest);
                else
                {
                    GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaxGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaxGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaxGroupMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GetTaxSummaryForDisplay(GeneralTaxGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> GeneralTaxGroupMasterCollection = new BaseEntityCollectionResponse<GeneralTaxGroupMaster>();
            try
            {
                if (_generalTitleMasterDataProvider != null)
                    GeneralTaxGroupMasterCollection = _generalTitleMasterDataProvider.GetTaxSummaryForDisplay(searchRequest);
                else
                {
                    GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralTaxGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralTaxGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralTaxGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralTaxGroupMasterCollection;
        }
        
    }
}
