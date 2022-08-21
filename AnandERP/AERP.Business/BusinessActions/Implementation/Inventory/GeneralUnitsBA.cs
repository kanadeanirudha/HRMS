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
    public class GeneralUnitsBA : IGeneralUnitsBA
    {
        IGeneralUnitsDataProvider _GeneralUnitsDataProvider;
        IGeneralUnitsBR _GeneralUnitsBR;
        private ILogger _logException;
        public GeneralUnitsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralUnitsBR = new GeneralUnitsBR();
            _GeneralUnitsDataProvider = new GeneralUnitsDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralUnits.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnits> InsertGeneralUnits(GeneralUnits item)
        {
            IBaseEntityResponse<GeneralUnits> entityResponse = new BaseEntityResponse<GeneralUnits>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsBR.InsertGeneralUnitsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsDataProvider.InsertGeneralUnits(item);
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
        /// Update a specific record  of GeneralUnits.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnits> UpdateGeneralUnits(GeneralUnits item)
        {
            IBaseEntityResponse<GeneralUnits> entityResponse = new BaseEntityResponse<GeneralUnits>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsBR.UpdateGeneralUnitsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsDataProvider.UpdateGeneralUnits(item);
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
        /// Delete a selected record from GeneralUnits.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnits> DeleteGeneralUnits(GeneralUnits item)
        {
            IBaseEntityResponse<GeneralUnits> entityResponse = new BaseEntityResponse<GeneralUnits>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralUnitsBR.DeleteGeneralUnitsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralUnitsDataProvider.DeleteGeneralUnits(item);
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
        /// Select all record from GeneralUnits table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralUnits> GetBySearch(GeneralUnitsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnits> GeneralUnitsCollection = new BaseEntityCollectionResponse<GeneralUnits>();
            try
            {
                if (_GeneralUnitsDataProvider != null)
                    GeneralUnitsCollection = _GeneralUnitsDataProvider.GetGeneralUnitsBySearch(searchRequest);
                else
                {
                    GeneralUnitsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsCollection;
        }

        public IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchList(GeneralUnitsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnits> GeneralUnitsCollection = new BaseEntityCollectionResponse<GeneralUnits>();
            try
            {
                if (_GeneralUnitsDataProvider != null)
                    GeneralUnitsCollection = _GeneralUnitsDataProvider.GetGeneralUnitsSearchList(searchRequest);
                else
                {
                    GeneralUnitsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsCollection;
        }
        /// <summary>
        /// Select a record from GeneralUnits table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralUnits> SelectByID(GeneralUnits item)
        {
            IBaseEntityResponse<GeneralUnits> entityResponse = new BaseEntityResponse<GeneralUnits>();
            try
            {
                entityResponse = _GeneralUnitsDataProvider.GetGeneralUnitsByID(item);
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

        public IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsByCentreCode(GeneralUnitsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnits> GeneralUnitsCollection = new BaseEntityCollectionResponse<GeneralUnits>();
            try
            {
                if (_GeneralUnitsDataProvider != null)
                    GeneralUnitsCollection = _GeneralUnitsDataProvider.GetGeneralUnitsByCentreCode(searchRequest);
                else
                {
                    GeneralUnitsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsCollection;
        }

        public IBaseEntityCollectionResponse<GeneralUnits> GetGeneralUnitsSearchListByAdminRoleIDAndCentre(GeneralUnitsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralUnits> GeneralUnitsCollection = new BaseEntityCollectionResponse<GeneralUnits>();
            try
            {
                if (_GeneralUnitsDataProvider != null)
                    GeneralUnitsCollection = _GeneralUnitsDataProvider.GetGeneralUnitsSearchListByAdminRoleIDAndCentre(searchRequest);
                else
                {
                    GeneralUnitsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralUnitsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralUnitsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralUnitsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralUnitsCollection;
        }
        
    }
}
