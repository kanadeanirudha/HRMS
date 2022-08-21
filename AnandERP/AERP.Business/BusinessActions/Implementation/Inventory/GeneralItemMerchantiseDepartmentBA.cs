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
    public class GeneralItemMerchantiseDepartmentBA : IGeneralItemMerchantiseDepartmentBA
    {
        IGeneralItemMerchantiseDepartmentDataProvider _GeneralItemMerchantiseDepartmentDataProvider;
        IGeneralItemMerchantiseDepartmentBR _GeneralItemMerchantiseDepartmentBR;
        private ILogger _logException;
        public GeneralItemMerchantiseDepartmentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMerchantiseDepartmentBR = new GeneralItemMerchantiseDepartmentBR();
            _GeneralItemMerchantiseDepartmentDataProvider = new GeneralItemMerchantiseDepartmentDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMerchantiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> InsertGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseDepartment> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseDepartmentBR.InsertGeneralItemMerchantiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseDepartmentDataProvider.InsertGeneralItemMerchantiseDepartment(item);
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
        /// Update a specific record  of GeneralItemMerchantiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> UpdateGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseDepartment> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseDepartmentBR.UpdateGeneralItemMerchantiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseDepartmentDataProvider.UpdateGeneralItemMerchantiseDepartment(item);
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
        /// Delete a selected record from GeneralItemMerchantiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> DeleteGeneralItemMerchantiseDepartment(GeneralItemMerchantiseDepartment item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseDepartment> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMerchantiseDepartmentBR.DeleteGeneralItemMerchantiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMerchantiseDepartmentDataProvider.DeleteGeneralItemMerchantiseDepartment(item);
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
        /// Select all record from GeneralItemMerchantiseDepartment table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetBySearch(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GeneralItemMerchantiseDepartmentCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                if (_GeneralItemMerchantiseDepartmentDataProvider != null)
                    GeneralItemMerchantiseDepartmentCollection = _GeneralItemMerchantiseDepartmentDataProvider.GetGeneralItemMerchantiseDepartmentBySearch(searchRequest);
                else
                {
                    GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseDepartmentCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentSearchList(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GeneralItemMerchantiseDepartmentCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                if (_GeneralItemMerchantiseDepartmentDataProvider != null)
                    GeneralItemMerchantiseDepartmentCollection = _GeneralItemMerchantiseDepartmentDataProvider.GetGeneralItemMerchantiseDepartmentSearchList(searchRequest);
                else
                {
                    GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseDepartmentCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMerchantiseDepartment table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMerchantiseDepartment> SelectByID(GeneralItemMerchantiseDepartment item)
        {
            IBaseEntityResponse<GeneralItemMerchantiseDepartment> entityResponse = new BaseEntityResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                entityResponse = _GeneralItemMerchantiseDepartmentDataProvider.GetGeneralItemMerchantiseDepartmentByID(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GetGeneralItemMerchantiseDepartmentCodeByGroupCode(GeneralItemMerchantiseDepartmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMerchantiseDepartment> GeneralItemMerchantiseDepartmentCollection = new BaseEntityCollectionResponse<GeneralItemMerchantiseDepartment>();
            try
            {
                if (_GeneralItemMerchantiseDepartmentDataProvider != null)
                    GeneralItemMerchantiseDepartmentCollection = _GeneralItemMerchantiseDepartmentDataProvider.GetGeneralItemMerchantiseDepartmentCodeByGroupCode(searchRequest);
                else
                {
                    GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMerchantiseDepartmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMerchantiseDepartmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMerchantiseDepartmentCollection;
        }
    }
}
