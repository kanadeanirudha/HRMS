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
    public class GeneralHolidaysBA : IGeneralHolidaysBA
    {
        IGeneralHolidaysDataProvider _generalHolidaysDataProvider;
        IGeneralHolidaysBR _generalHolidaysBR;
        private ILogger _logException;
        public GeneralHolidaysBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalHolidaysBR = new GeneralHolidaysBR();
            _generalHolidaysDataProvider = new GeneralHolidaysDataProvider();
        }
        /// <summary>
        /// Create new record of GeneralHolidays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralHolidays> InsertGeneralHolidays(GeneralHolidays item)
        {
            IBaseEntityResponse<GeneralHolidays> entityResponse = new BaseEntityResponse<GeneralHolidays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalHolidaysBR.InsertGeneralHolidaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalHolidaysDataProvider.InsertGeneralHolidays(item);
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
        /// Update a specific record  of GeneralHolidays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralHolidays> UpdateGeneralHolidays(GeneralHolidays item)
        {
            IBaseEntityResponse<GeneralHolidays> entityResponse = new BaseEntityResponse<GeneralHolidays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalHolidaysBR.UpdateGeneralHolidaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalHolidaysDataProvider.UpdateGeneralHolidays(item);
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
        /// Delete a selected record from GeneralHolidays.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralHolidays> DeleteGeneralHolidays(GeneralHolidays item)
        {
            IBaseEntityResponse<GeneralHolidays> entityResponse = new BaseEntityResponse<GeneralHolidays>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalHolidaysBR.DeleteGeneralHolidaysValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _generalHolidaysDataProvider.DeleteGeneralHolidays(item);
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
        /// Select all record from GeneralHolidays table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralHolidays> GetBySearch(GeneralHolidaysSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralHolidays> GeneralHolidaysCollection = new BaseEntityCollectionResponse<GeneralHolidays>();
            try
            {
                if (_generalHolidaysDataProvider != null)
                    GeneralHolidaysCollection = _generalHolidaysDataProvider.GetGeneralHolidaysBySearch(searchRequest);
                else
                {
                    GeneralHolidaysCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralHolidaysCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralHolidaysCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralHolidaysCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralHolidaysCollection;
        }
        /// <summary>
        /// Select a record from GeneralHolidays table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<GeneralHolidays> SelectByID(GeneralHolidays item)
        {
            IBaseEntityResponse<GeneralHolidays> entityResponse = new BaseEntityResponse<GeneralHolidays>();
            try
            {
                entityResponse = _generalHolidaysDataProvider.GetGeneralHolidaysByID(item);
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
        /// Select all record from GeneralHolidays table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<GeneralHolidays> GetHolidayAndWeeklyOffDayByEmployeeID(GeneralHolidaysSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralHolidays> GeneralHolidaysCollection = new BaseEntityCollectionResponse<GeneralHolidays>();
            try
            {
                if (_generalHolidaysDataProvider != null)
                    GeneralHolidaysCollection = _generalHolidaysDataProvider.GetHolidayAndWeeklyOffDayByEmployeeID(searchRequest);
                else
                {
                    GeneralHolidaysCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralHolidaysCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralHolidaysCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralHolidaysCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralHolidaysCollection;
        }

        public IBaseEntityCollectionResponse<GeneralHolidays> GetListCheckInCheckOutTime(GeneralHolidaysSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GeneralHolidays> GeneralHolidaysCollection = new BaseEntityCollectionResponse<GeneralHolidays>();
            try
            {
                if (_generalHolidaysDataProvider != null)
                    GeneralHolidaysCollection = _generalHolidaysDataProvider.GetListCheckInCheckOutTime(searchRequest);
                else
                {
                    GeneralHolidaysCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GeneralHolidaysCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GeneralHolidaysCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GeneralHolidaysCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GeneralHolidaysCollection;
        }

    }
}
