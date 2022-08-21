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

namespace AMS.Business.BusinessActions
{
    public class GeneralMainTypeMasterBA : IGeneralMainTypeMasterBA
    {
        IGeneralMainTypeMasterDataProvider _generalMainTypeMasterDataProvider;
        IGeneralMainTypeMasterBR _generalMainTypeMasterBR;
        private ILogger _logException;

        public GeneralMainTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalMainTypeMasterBR = new GeneralMainTypeMasterBR();
            _generalMainTypeMasterDataProvider = new GeneralMainTypeMasterDataProvider();
        }

        /// Create new record of GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> InsertGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralMainTypeMaster>();
             try
            {
                IValidateBusinessRuleResponse brResponse = _generalMainTypeMasterBR.InsertGeneralMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMainTypeMasterDataProvider.InsertGeneralMainTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        /// Update a specific record of GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> UpdateGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralMainTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalMainTypeMasterBR.UpdateGeneralMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMainTypeMasterDataProvider.UpdateGeneralMainTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        /// Delete a selected record from GeneralMainTypeMaster.
        public IBaseEntityResponse<GeneralMainTypeMaster> DeleteGeneralMainTypeMaster(GeneralMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralMainTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalMainTypeMasterBR.DeleteGeneralMainTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalMainTypeMasterDataProvider.DeleteGeneralMainTypeMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        /// Select all record from GeneralMainTypeMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearch(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMainTypeMaster> typeMasterCollection = new BaseEntityCollectionResponse<GeneralMainTypeMaster>();
            try
            {
                if (_generalMainTypeMasterDataProvider != null)
                {
                    typeMasterCollection = _generalMainTypeMasterDataProvider.GetGeneralMainTypeMasterBySearch(searchRequest);
                }
                else
                {
                    typeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    typeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                typeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                typeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return typeMasterCollection;
        }

        /// Select all record from GeneralMainTypeMaster table with search parameters.
        public IBaseEntityCollectionResponse<GeneralMainTypeMaster> GetBySearchList(GeneralMainTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralMainTypeMaster> typeMasterCollection = new BaseEntityCollectionResponse<GeneralMainTypeMaster>();
            try
            {
                if (_generalMainTypeMasterDataProvider != null)
                {
                    typeMasterCollection = _generalMainTypeMasterDataProvider.GetGeneralMainTypeMasterGetBySearchList(searchRequest);
                }
                else
                {
                    typeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    typeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                typeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                typeMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return typeMasterCollection;
        }

        /// Select a record from GeneralMainTypeMaster table by ID.
        public IBaseEntityResponse<GeneralMainTypeMaster> SelectByID(GeneralMainTypeMaster item)
        {

            IBaseEntityResponse<GeneralMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralMainTypeMaster>();
            try
            {
                entityResponse = _generalMainTypeMasterDataProvider.GetGeneralMainTypeMasterByID(item);
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

        ///Service Access interface to select record from GeneralPreTableForMainTypeMaster on Module code and MenuCode.
        public IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(GeneralPreTablesForMainTypeMaster item)
        {
            IBaseEntityResponse<GeneralPreTablesForMainTypeMaster> entityResponse = new BaseEntityResponse<GeneralPreTablesForMainTypeMaster>();
            try
            {
                entityResponse = _generalMainTypeMasterDataProvider.GetGeneralPreTablesForMainTypeByModuleCodeAndMenuCode(item);
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
