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
    public class GeneralItemMarchandiseGroupBA : IGeneralItemMarchandiseGroupBA
    {
        IGeneralItemMarchandiseGroupDataProvider _GeneralItemMarchandiseGroupDataProvider;
        IGeneralItemMarchandiseGroupBR _GeneralItemMarchandiseGroupBR;
        private ILogger _logException;
        public GeneralItemMarchandiseGroupBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralItemMarchandiseGroupBR = new GeneralItemMarchandiseGroupBR();
            _GeneralItemMarchandiseGroupDataProvider = new GeneralItemMarchandiseGroupDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralItemMarchandiseGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> InsertGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseGroup> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseGroupBR.InsertGeneralItemMarchandiseGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseGroupDataProvider.InsertGeneralItemMarchandiseGroup(item);
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
        /// Update a specific record  of GeneralItemMarchandiseGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> UpdateGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseGroup> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseGroupBR.UpdateGeneralItemMarchandiseGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseGroupDataProvider.UpdateGeneralItemMarchandiseGroup(item);
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
        /// Delete a selected record from GeneralItemMarchandiseGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> DeleteGeneralItemMarchandiseGroup(GeneralItemMarchandiseGroup item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseGroup> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralItemMarchandiseGroupBR.DeleteGeneralItemMarchandiseGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralItemMarchandiseGroupDataProvider.DeleteGeneralItemMarchandiseGroup(item);
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
        /// Select all record from GeneralItemMarchandiseGroup table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetBySearch(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GeneralItemMarchandiseGroupCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseGroup>();
            try
            {
                if (_GeneralItemMarchandiseGroupDataProvider != null)
                    GeneralItemMarchandiseGroupCollection = _GeneralItemMarchandiseGroupDataProvider.GetGeneralItemMarchandiseGroupBySearch(searchRequest);
                else
                {
                    GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseGroupCollection;
        }

        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchList(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GeneralItemMarchandiseGroupCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseGroup>();
            try
            {
                if (_GeneralItemMarchandiseGroupDataProvider != null)
                    GeneralItemMarchandiseGroupCollection = _GeneralItemMarchandiseGroupDataProvider.GetGeneralItemMarchandiseGroupSearchList(searchRequest);
                else
                {
                    GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseGroupCollection;
        }
        /// <summary>
        /// Select a record from GeneralItemMarchandiseGroup table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralItemMarchandiseGroup> SelectByID(GeneralItemMarchandiseGroup item)
        {
            IBaseEntityResponse<GeneralItemMarchandiseGroup> entityResponse = new BaseEntityResponse<GeneralItemMarchandiseGroup>();
            try
            {
                entityResponse = _GeneralItemMarchandiseGroupDataProvider.GetGeneralItemMarchandiseGroupByID(item);
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

        public IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GetGeneralItemMarchandiseGroupSearchListForCategory(GeneralItemMarchandiseGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralItemMarchandiseGroup> GeneralItemMarchandiseGroupCollection = new BaseEntityCollectionResponse<GeneralItemMarchandiseGroup>();
            try
            {
                if (_GeneralItemMarchandiseGroupDataProvider != null)
                    GeneralItemMarchandiseGroupCollection = _GeneralItemMarchandiseGroupDataProvider.GetGeneralItemMarchandiseGroupSearchListForCategory(searchRequest);
                else
                {
                    GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralItemMarchandiseGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralItemMarchandiseGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralItemMarchandiseGroupCollection;
        }
    }
}
