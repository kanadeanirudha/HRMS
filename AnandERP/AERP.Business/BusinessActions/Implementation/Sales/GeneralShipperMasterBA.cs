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
    public class GeneralShipperMasterBA : IGeneralShipperMasterBA
    {
        IGeneralShipperMasterDataProvider _GeneralShipperMasterDataProvider;
        IGeneralShipperMasterBR _GeneralShipperMasterBR;
        private ILogger _logException;
        public GeneralShipperMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralShipperMasterBR = new GeneralShipperMasterBR();
            _GeneralShipperMasterDataProvider = new GeneralShipperMasterDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralShipperMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralShipperMaster> InsertGeneralShipperMaster(GeneralShipperMaster item)
        {
            IBaseEntityResponse<GeneralShipperMaster> entityResponse = new BaseEntityResponse<GeneralShipperMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralShipperMasterBR.InsertGeneralShipperMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralShipperMasterDataProvider.InsertGeneralShipperMaster(item);
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
        /// Update a specific record  of GeneralShipperMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralShipperMaster> UpdateGeneralShipperMaster(GeneralShipperMaster item)
        {
            IBaseEntityResponse<GeneralShipperMaster> entityResponse = new BaseEntityResponse<GeneralShipperMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralShipperMasterBR.UpdateGeneralShipperMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralShipperMasterDataProvider.UpdateGeneralShipperMaster(item);
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
        /// Delete a selected record from GeneralShipperMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralShipperMaster> DeleteGeneralShipperMaster(GeneralShipperMaster item)
        {
            IBaseEntityResponse<GeneralShipperMaster> entityResponse = new BaseEntityResponse<GeneralShipperMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralShipperMasterBR.DeleteGeneralShipperMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralShipperMasterDataProvider.DeleteGeneralShipperMaster(item);
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
        /// Select all record from GeneralShipperMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralShipperMaster> GetBySearch(GeneralShipperMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralShipperMaster> GeneralShipperMasterCollection = new BaseEntityCollectionResponse<GeneralShipperMaster>();
            try
            {
                if (_GeneralShipperMasterDataProvider != null)
                    GeneralShipperMasterCollection = _GeneralShipperMasterDataProvider.GetGeneralShipperMasterBySearch(searchRequest);
                else
                {
                    GeneralShipperMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralShipperMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralShipperMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralShipperMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralShipperMasterCollection;
        }

        public IBaseEntityCollectionResponse<GeneralShipperMaster> GetGeneralShipperMasterSearchList(GeneralShipperMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralShipperMaster> GeneralShipperMasterCollection = new BaseEntityCollectionResponse<GeneralShipperMaster>();
            try
            {
                if (_GeneralShipperMasterDataProvider != null)
                    GeneralShipperMasterCollection = _GeneralShipperMasterDataProvider.GetGeneralShipperMasterSearchList(searchRequest);
                else
                {
                    GeneralShipperMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralShipperMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralShipperMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralShipperMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralShipperMasterCollection;
        }
        /// <summary>
        /// Select a record from GeneralShipperMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralShipperMaster> SelectByID(GeneralShipperMaster item)
        {
            IBaseEntityResponse<GeneralShipperMaster> entityResponse = new BaseEntityResponse<GeneralShipperMaster>();
            try
            {
                entityResponse = _GeneralShipperMasterDataProvider.GetGeneralShipperMasterByID(item);
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

        public IBaseEntityCollectionResponse<GeneralShipperMaster> GetDropDownListforGeneralShipperMaster(GeneralShipperMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralShipperMaster> GeneralShipperMasterCollection = new BaseEntityCollectionResponse<GeneralShipperMaster>();
            try
            {
                if (_GeneralShipperMasterDataProvider != null)
                    GeneralShipperMasterCollection = _GeneralShipperMasterDataProvider.GetDropDownListforGeneralShipperMaster(searchRequest);
                else
                {
                    GeneralShipperMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralShipperMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralShipperMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralShipperMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralShipperMasterCollection;
        }
    }
}
