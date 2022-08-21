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
    public class GeneralPeriodTypeMasterBA : IGeneralPeriodTypeMasterBA
    {
        IGeneralPeriodTypeMasterDataProvider _generalPeriodTypeMasterDataProvider;
        IGeneralPeriodTypeMasterBR _generalPeriodTypeMasterBR;
        private ILogger _logException;

        public GeneralPeriodTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalPeriodTypeMasterBR = new GeneralPeriodTypeMasterBR();
            _generalPeriodTypeMasterDataProvider = new GeneralPeriodTypeMasterDataProvider();
        }

        /// Create new record of GeneralPeriodTypeMaster.
        public IBaseEntityResponse<GeneralPeriodTypeMaster> InsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            IBaseEntityResponse<GeneralPeriodTypeMaster> entityResponse = new BaseEntityResponse<GeneralPeriodTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPeriodTypeMasterBR.InsertGeneralPeriodTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPeriodTypeMasterDataProvider.InsertGeneralPeriodTypeMaster(item);
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


        /// Update a specific record  of GeneralPeriodTypeMaster.
        public IBaseEntityResponse<GeneralPeriodTypeMaster> UpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            IBaseEntityResponse<GeneralPeriodTypeMaster> entityResponse = new BaseEntityResponse<GeneralPeriodTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPeriodTypeMasterBR.UpdateGeneralPeriodTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPeriodTypeMasterDataProvider.UpdateGeneralPeriodTypeMaster(item);
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

        /// Delete a selected record from GeneralPeriodTypeMaster.        
        public IBaseEntityResponse<GeneralPeriodTypeMaster> DeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster item)
        {
            IBaseEntityResponse<GeneralPeriodTypeMaster> entityResponse = new BaseEntityResponse<GeneralPeriodTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalPeriodTypeMasterBR.DeleteGeneralPeriodTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalPeriodTypeMasterDataProvider.DeleteGeneralPeriodTypeMaster(item);
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

        /// Select all record from GeneralPeriodTypeMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearch(GeneralPeriodTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> generalPeriodTypeMasterCollection = new BaseEntityCollectionResponse<GeneralPeriodTypeMaster>();
            try
            {
                if (_generalPeriodTypeMasterDataProvider != null)
                    generalPeriodTypeMasterCollection = _generalPeriodTypeMasterDataProvider.GetGeneralPeriodTypeMasterBySearch(searchRequest);
                else
                {
                    generalPeriodTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    generalPeriodTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                generalPeriodTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                generalPeriodTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return generalPeriodTypeMasterCollection;
        }

        /// Select all record from GeneralPeriodTypeMaster table with search.
        public IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> GetBySearchList(GeneralPeriodTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPeriodTypeMaster> generalPeriodTypeMasterCollection = new BaseEntityCollectionResponse<GeneralPeriodTypeMaster>();
            try
            {
                if (_generalPeriodTypeMasterDataProvider != null)
                    generalPeriodTypeMasterCollection = _generalPeriodTypeMasterDataProvider.GetGeneralPeriodTypeMasterBySearchList(searchRequest);
                else
                {
                    generalPeriodTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    generalPeriodTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                generalPeriodTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                generalPeriodTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return generalPeriodTypeMasterCollection;
        }

        /// Select a record from GeneralPeriodTypeMaster table by ID.

        public IBaseEntityResponse<GeneralPeriodTypeMaster> SelectByID(GeneralPeriodTypeMaster item)
        {
            IBaseEntityResponse<GeneralPeriodTypeMaster> entityResponse = new BaseEntityResponse<GeneralPeriodTypeMaster>();
            try
            {
                entityResponse = _generalPeriodTypeMasterDataProvider.GetGeneralPeriodTypeMasterByID(item);
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
