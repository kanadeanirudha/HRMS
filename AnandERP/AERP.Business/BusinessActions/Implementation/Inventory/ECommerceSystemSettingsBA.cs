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
    public class ECommerceSystemSettingsBA : IECommerceSystemSettingsBA
    {
        IECommerceSystemSettingsDataProvider _ECommerceSystemSettingsDataProvider;
        IECommerceSystemSettingsBR _ECommerceSystemSettingsBR;
        private ILogger _logException;
        public ECommerceSystemSettingsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ECommerceSystemSettingsBR = new ECommerceSystemSettingsBR();
            _ECommerceSystemSettingsDataProvider = new ECommerceSystemSettingsDataProvider();
        }
        /// <summary>
        /// Create new record of ECommerceSystemSettings.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<ECommerceSystemSettings> InsertECommerceSystemSettings(ECommerceSystemSettings item)
        {
            IBaseEntityResponse<ECommerceSystemSettings> entityResponse = new BaseEntityResponse<ECommerceSystemSettings>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _ECommerceSystemSettingsBR.InsertECommerceSystemSettingsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _ECommerceSystemSettingsDataProvider.InsertECommerceSystemSettings(item);
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
        /// Select all record from ECommerceSystemSettings table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<ECommerceSystemSettings> GetBySearch(ECommerceSystemSettingsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ECommerceSystemSettings> ECommerceSystemSettingsCollection = new BaseEntityCollectionResponse<ECommerceSystemSettings>();
            try
            {
                if (_ECommerceSystemSettingsDataProvider != null)
                    ECommerceSystemSettingsCollection = _ECommerceSystemSettingsDataProvider.GetECommerceSystemSettingsBySearch(searchRequest);
                else
                {
                    ECommerceSystemSettingsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ECommerceSystemSettingsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ECommerceSystemSettingsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ECommerceSystemSettingsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ECommerceSystemSettingsCollection;
        }

    }
}

