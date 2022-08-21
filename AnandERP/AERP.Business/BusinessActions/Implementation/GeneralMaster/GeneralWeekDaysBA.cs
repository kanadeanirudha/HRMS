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
    public class GeneralWeekDaysBA : IGeneralWeekDaysBA
    {
        IGeneralWeekDaysDataProvider _generalWeekDaysDataProvider;
        IGeneralWeekDaysBR _generalWeekDaysBR;
        private ILogger _logException;
        public GeneralWeekDaysBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalWeekDaysBR = new GeneralWeekDaysBR();
            _generalWeekDaysDataProvider = new GeneralWeekDaysDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralWeekDays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> InsertGeneralWeekDays(GeneralWeekDays item)
        {
            IBaseEntityResponse<GeneralWeekDays> entityResponse = new BaseEntityResponse<GeneralWeekDays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalWeekDaysBR.InsertGeneralWeekDaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalWeekDaysDataProvider.InsertGeneralWeekDays(item);
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
        /// Update a specific record  of GeneralWeekDays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> UpdateGeneralWeekDays(GeneralWeekDays item)
        {
            IBaseEntityResponse<GeneralWeekDays> entityResponse = new BaseEntityResponse<GeneralWeekDays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalWeekDaysBR.UpdateGeneralWeekDaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalWeekDaysDataProvider.UpdateGeneralWeekDays(item);
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
        /// Delete a selected record from GeneralWeekDays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> DeleteGeneralWeekDays(GeneralWeekDays item)
        {
            IBaseEntityResponse<GeneralWeekDays> entityResponse = new BaseEntityResponse<GeneralWeekDays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalWeekDaysBR.DeleteGeneralWeekDaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalWeekDaysDataProvider.DeleteGeneralWeekDays(item);
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
        /// Select all record from GeneralWeekDays table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralWeekDays> GetBySearch(GeneralWeekDaysSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralWeekDays> GeneralWeekDaysCollection = new BaseEntityCollectionResponse<GeneralWeekDays>();
            try
            {
                if (_generalWeekDaysDataProvider != null)
                    GeneralWeekDaysCollection = _generalWeekDaysDataProvider.GetGeneralWeekDaysBySearch(searchRequest);
                else
                {
                    GeneralWeekDaysCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralWeekDaysCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralWeekDaysCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralWeekDaysCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralWeekDaysCollection;
        }
        /// <summary>
        /// Select all record from GeneralWeekDays table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDayList(GeneralWeekDaysSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralWeekDays> GeneralWeekDaysCollection = new BaseEntityCollectionResponse<GeneralWeekDays>();
            try
            {
                if (_generalWeekDaysDataProvider != null)
                    GeneralWeekDaysCollection = _generalWeekDaysDataProvider.GetGeneralWeekDayList(searchRequest);
                else
                {
                    GeneralWeekDaysCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralWeekDaysCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralWeekDaysCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralWeekDaysCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralWeekDaysCollection;
        }        
        /// <summary>
        /// Select a record from GeneralWeekDays table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralWeekDays> SelectByID(GeneralWeekDays item)
        {
            IBaseEntityResponse<GeneralWeekDays> entityResponse = new BaseEntityResponse<GeneralWeekDays>();
            try
            {
                entityResponse = _generalWeekDaysDataProvider.GetGeneralWeekDaysByID(item);
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
