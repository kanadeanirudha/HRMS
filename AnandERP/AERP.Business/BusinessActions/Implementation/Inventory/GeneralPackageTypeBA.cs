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
    public class GeneralPackageTypeBA : IGeneralPackageTypeBA
    {
        IGeneralPackageTypeDataProvider _GeneralPackageTypeDataProvider;
        IGeneralPackageTypeBR _GeneralPackageTypeBR;
        private ILogger _logException;
        public GeneralPackageTypeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPackageTypeBR = new GeneralPackageTypeBR();
            _GeneralPackageTypeDataProvider = new GeneralPackageTypeDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPackageType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackageType> InsertGeneralPackageType(GeneralPackageType item)
        {
            IBaseEntityResponse<GeneralPackageType> entityResponse = new BaseEntityResponse<GeneralPackageType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackageTypeBR.InsertGeneralPackageTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackageTypeDataProvider.InsertGeneralPackageType(item);
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
        /// Update a specific record  of GeneralPackageType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackageType> UpdateGeneralPackageType(GeneralPackageType item)
        {
            IBaseEntityResponse<GeneralPackageType> entityResponse = new BaseEntityResponse<GeneralPackageType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackageTypeBR.UpdateGeneralPackageTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackageTypeDataProvider.UpdateGeneralPackageType(item);
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
        /// Delete a selected record from GeneralPackageType.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackageType> DeleteGeneralPackageType(GeneralPackageType item)
        {
            IBaseEntityResponse<GeneralPackageType> entityResponse = new BaseEntityResponse<GeneralPackageType>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPackageTypeBR.DeleteGeneralPackageTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPackageTypeDataProvider.DeleteGeneralPackageType(item);
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
        /// Select all record from GeneralPackageType table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPackageType> GetBySearch(GeneralPackageTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPackageType> GeneralPackageTypeCollection = new BaseEntityCollectionResponse<GeneralPackageType>();
            try
            {
                if (_GeneralPackageTypeDataProvider != null)
                    GeneralPackageTypeCollection = _GeneralPackageTypeDataProvider.GetGeneralPackageTypeBySearch(searchRequest);
                else
                {
                    GeneralPackageTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPackageTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPackageTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPackageTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPackageTypeCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPackageType> GetGeneralPackageTypeSearchList(GeneralPackageTypeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPackageType> GeneralPackageTypeCollection = new BaseEntityCollectionResponse<GeneralPackageType>();
            try
            {
                if (_GeneralPackageTypeDataProvider != null)
                    GeneralPackageTypeCollection = _GeneralPackageTypeDataProvider.GetGeneralPackageTypeSearchList(searchRequest);
                else
                {
                    GeneralPackageTypeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPackageTypeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPackageTypeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPackageTypeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPackageTypeCollection;
        }
        /// <summary>
        /// Select a record from GeneralPackageType table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPackageType> SelectByID(GeneralPackageType item)
        {
            IBaseEntityResponse<GeneralPackageType> entityResponse = new BaseEntityResponse<GeneralPackageType>();
            try
            {
                entityResponse = _GeneralPackageTypeDataProvider.GetGeneralPackageTypeByID(item);
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
