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
    public class GeneralUnitsStorageLocationBA : IGeneralUnitsStorageLocationBA
    {
        IGeneralUnitsStorageLocationDataProvider _GeneralUnitsStorageLocationDataProvider;
        IGeneralUnitsStorageLocationBR _GeneralUnitsStorageLocationBR;
        private ILogger _logException;
        public GeneralUnitsStorageLocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralUnitsStorageLocationBR = new GeneralUnitsStorageLocationBR();
            _GeneralUnitsStorageLocationDataProvider = new GeneralUnitsStorageLocationDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralUnitsStorageLocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitsStorageLocation> InsertGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            IBaseEntityResponse<GeneralUnitsStorageLocation> entityResponse = new BaseEntityResponse<GeneralUnitsStorageLocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsStorageLocationBR.InsertGeneralUnitsStorageLocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsStorageLocationDataProvider.InsertGeneralUnitsStorageLocation(item);
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
        /// Update a specific record  of GeneralUnitsStorageLocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitsStorageLocation> UpdateGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            IBaseEntityResponse<GeneralUnitsStorageLocation> entityResponse = new BaseEntityResponse<GeneralUnitsStorageLocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsStorageLocationBR.UpdateGeneralUnitsStorageLocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsStorageLocationDataProvider.UpdateGeneralUnitsStorageLocation(item);
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
        /// Delete a selected record from GeneralUnitsStorageLocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitsStorageLocation> DeleteGeneralUnitsStorageLocation(GeneralUnitsStorageLocation item)
        {
            IBaseEntityResponse<GeneralUnitsStorageLocation> entityResponse = new BaseEntityResponse<GeneralUnitsStorageLocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsStorageLocationBR.DeleteGeneralUnitsStorageLocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsStorageLocationDataProvider.DeleteGeneralUnitsStorageLocation(item);
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
        /// Select all record from GeneralUnitsStorageLocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetBySearch(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GeneralUnitsStorageLocationCollection = new BaseEntityCollectionResponse<GeneralUnitsStorageLocation>();
            try
            {
                if (_GeneralUnitsStorageLocationDataProvider != null)
                    GeneralUnitsStorageLocationCollection = _GeneralUnitsStorageLocationDataProvider.GetGeneralUnitsStorageLocationBySearch(searchRequest);
                else
                {
                    GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsStorageLocationCollection;
        }

        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetGeneralUnitsStorageLocationSearchList(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GeneralUnitsStorageLocationCollection = new BaseEntityCollectionResponse<GeneralUnitsStorageLocation>();
            try
            {
                if (_GeneralUnitsStorageLocationDataProvider != null)
                    GeneralUnitsStorageLocationCollection = _GeneralUnitsStorageLocationDataProvider.GetGeneralUnitsStorageLocationSearchList(searchRequest);
                else
                {
                    GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsStorageLocationCollection;
        }
        /// <summary>
        /// Select a record from GeneralUnitsStorageLocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnitsStorageLocation> SelectByID(GeneralUnitsStorageLocation item)
        {
            IBaseEntityResponse<GeneralUnitsStorageLocation> entityResponse = new BaseEntityResponse<GeneralUnitsStorageLocation>();
            try
            {
                entityResponse = _GeneralUnitsStorageLocationDataProvider.GetGeneralUnitsStorageLocationByID(item);
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

        public IBaseEntityResponse<GeneralUnitsStorageLocation> CheckFocusOnAction(GeneralUnitsStorageLocation item)
        {
            IBaseEntityResponse<GeneralUnitsStorageLocation> entityResponse = new BaseEntityResponse<GeneralUnitsStorageLocation>();
            try
            {
                entityResponse = _GeneralUnitsStorageLocationDataProvider.CheckFocusOnAction(item);
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

        public IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GetStorageLocationForRequisition(GeneralUnitsStorageLocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnitsStorageLocation> GeneralUnitsStorageLocationCollection = new BaseEntityCollectionResponse<GeneralUnitsStorageLocation>();
            try
            {
                if (_GeneralUnitsStorageLocationDataProvider != null)
                    GeneralUnitsStorageLocationCollection = _GeneralUnitsStorageLocationDataProvider.GetStorageLocationForRequisition(searchRequest);
                else
                {
                    GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsStorageLocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsStorageLocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsStorageLocationCollection;
        }
    }
}
