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
    public class GeneralAllocateSaleProcessUnitBA : IGeneralAllocateSaleProcessUnitBA
    {
        IGeneralAllocateSaleProcessUnitDataProvider _GeneralAllocateSaleProcessUnitDataProvider;
        IGeneralAllocateSaleProcessUnitBR _GeneralAllocateSaleProcessUnitBR;
        private ILogger _logException;
        public GeneralAllocateSaleProcessUnitBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralAllocateSaleProcessUnitBR = new GeneralAllocateSaleProcessUnitBR();
            _GeneralAllocateSaleProcessUnitDataProvider = new GeneralAllocateSaleProcessUnitDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralAllocateSaleProcessUnit.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> InsertGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            IBaseEntityResponse<GeneralAllocateSaleProcessUnit> entityResponse = new BaseEntityResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralAllocateSaleProcessUnitBR.InsertGeneralAllocateSaleProcessUnitValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralAllocateSaleProcessUnitDataProvider.InsertGeneralAllocateSaleProcessUnit(item);
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
        /// Update a specific record  of GeneralAllocateSaleProcessUnit.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> UpdateGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            IBaseEntityResponse<GeneralAllocateSaleProcessUnit> entityResponse = new BaseEntityResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralAllocateSaleProcessUnitBR.UpdateGeneralAllocateSaleProcessUnitValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralAllocateSaleProcessUnitDataProvider.UpdateGeneralAllocateSaleProcessUnit(item);
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
        /// Delete a selected record from GeneralAllocateSaleProcessUnit.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> DeleteGeneralAllocateSaleProcessUnit(GeneralAllocateSaleProcessUnit item)
        {
            IBaseEntityResponse<GeneralAllocateSaleProcessUnit> entityResponse = new BaseEntityResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralAllocateSaleProcessUnitBR.DeleteGeneralAllocateSaleProcessUnitValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralAllocateSaleProcessUnitDataProvider.DeleteGeneralAllocateSaleProcessUnit(item);
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
        /// Select all record from GeneralAllocateSaleProcessUnit table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetBySearch(GeneralAllocateSaleProcessUnitSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GeneralAllocateSaleProcessUnitCollection = new BaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                if (_GeneralAllocateSaleProcessUnitDataProvider != null)
                    GeneralAllocateSaleProcessUnitCollection = _GeneralAllocateSaleProcessUnitDataProvider.GetGeneralAllocateSaleProcessUnitBySearch(searchRequest);
                else
                {
                    GeneralAllocateSaleProcessUnitCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralAllocateSaleProcessUnitCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralAllocateSaleProcessUnitCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralAllocateSaleProcessUnitCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralAllocateSaleProcessUnitCollection;
        }

        public IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GetGeneralAllocateSaleProcessUnitSearchList(GeneralAllocateSaleProcessUnitSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit> GeneralAllocateSaleProcessUnitCollection = new BaseEntityCollectionResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                if (_GeneralAllocateSaleProcessUnitDataProvider != null)
                    GeneralAllocateSaleProcessUnitCollection = _GeneralAllocateSaleProcessUnitDataProvider.GetGeneralAllocateSaleProcessUnitSearchList(searchRequest);
                else
                {
                    GeneralAllocateSaleProcessUnitCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralAllocateSaleProcessUnitCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralAllocateSaleProcessUnitCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralAllocateSaleProcessUnitCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralAllocateSaleProcessUnitCollection;
        }
        /// <summary>
        /// Select a record from GeneralAllocateSaleProcessUnit table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralAllocateSaleProcessUnit> SelectByID(GeneralAllocateSaleProcessUnit item)
        {
            IBaseEntityResponse<GeneralAllocateSaleProcessUnit> entityResponse = new BaseEntityResponse<GeneralAllocateSaleProcessUnit>();
            try
            {
                entityResponse = _GeneralAllocateSaleProcessUnitDataProvider.GetGeneralAllocateSaleProcessUnitByID(item);
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
