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
    public class GeneralPriceGroupBA : IGeneralPriceGroupBA
    {
        IGeneralPriceGroupDataProvider _GeneralPriceGroupDataProvider;
        IGeneralPriceGroupBR _GeneralPriceGroupBR;
        private ILogger _logException;
        public GeneralPriceGroupBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GeneralPriceGroupBR = new GeneralPriceGroupBR();
            _GeneralPriceGroupDataProvider = new GeneralPriceGroupDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralPriceGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceGroup> InsertGeneralPriceGroup(GeneralPriceGroup item)
        {
            IBaseEntityResponse<GeneralPriceGroup> entityResponse = new BaseEntityResponse<GeneralPriceGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceGroupBR.InsertGeneralPriceGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceGroupDataProvider.InsertGeneralPriceGroup(item);
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
        /// Update a specific record  of GeneralPriceGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceGroup> UpdateGeneralPriceGroup(GeneralPriceGroup item)
        {
            IBaseEntityResponse<GeneralPriceGroup> entityResponse = new BaseEntityResponse<GeneralPriceGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceGroupBR.UpdateGeneralPriceGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceGroupDataProvider.UpdateGeneralPriceGroup(item);
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
        /// Delete a selected record from GeneralPriceGroup.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceGroup> DeleteGeneralPriceGroup(GeneralPriceGroup item)
        {
            IBaseEntityResponse<GeneralPriceGroup> entityResponse = new BaseEntityResponse<GeneralPriceGroup>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _GeneralPriceGroupBR.DeleteGeneralPriceGroupValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _GeneralPriceGroupDataProvider.DeleteGeneralPriceGroup(item);
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
        /// Select all record from GeneralPriceGroup table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralPriceGroup> GetBySearch(GeneralPriceGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPriceGroup> GeneralPriceGroupCollection = new BaseEntityCollectionResponse<GeneralPriceGroup>();
            try
            {
                if (_GeneralPriceGroupDataProvider != null)
                    GeneralPriceGroupCollection = _GeneralPriceGroupDataProvider.GetGeneralPriceGroupBySearch(searchRequest);
                else
                {
                    GeneralPriceGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPriceGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPriceGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPriceGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPriceGroupCollection;
        }

        public IBaseEntityCollectionResponse<GeneralPriceGroup> GetGeneralPriceGroupSearchList(GeneralPriceGroupSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralPriceGroup> GeneralPriceGroupCollection = new BaseEntityCollectionResponse<GeneralPriceGroup>();
            try
            {
                if (_GeneralPriceGroupDataProvider != null)
                    GeneralPriceGroupCollection = _GeneralPriceGroupDataProvider.GetGeneralPriceGroupSearchList(searchRequest);
                else
                {
                    GeneralPriceGroupCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralPriceGroupCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralPriceGroupCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralPriceGroupCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralPriceGroupCollection;
        }
        /// <summary>
        /// Select a record from GeneralPriceGroup table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralPriceGroup> SelectByID(GeneralPriceGroup item)
        {
            IBaseEntityResponse<GeneralPriceGroup> entityResponse = new BaseEntityResponse<GeneralPriceGroup>();
            try
            {
                entityResponse = _GeneralPriceGroupDataProvider.GetGeneralPriceGroupByID(item);
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
