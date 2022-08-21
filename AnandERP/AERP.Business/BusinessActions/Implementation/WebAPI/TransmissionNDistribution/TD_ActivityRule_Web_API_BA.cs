using AERP.Base.DTO;
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
    public class TD_ActivityRule_Web_API_BA : ITD_ActivityRule_Web_API_BA
    {
        private ILogger _logException;
        private ITD_ActivityRule_Web_API_DataProvider _ITD_ActivityRule_Web_API_DataProvider;
        public TD_ActivityRule_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_ActivityRule_Web_API_DataProvider = new TD_ActivityRule_Web_API_DataProvider();
        }

        public IBaseEntityCollectionResponse<ActivityRule> getActivityRule(ActivityRule item)
        {
            IBaseEntityCollectionResponse<ActivityRule> ActivityRuleCollection = new BaseEntityCollectionResponse<ActivityRule>();
            try
            {
                if (_ITD_ActivityRule_Web_API_DataProvider != null)
                    ActivityRuleCollection = _ITD_ActivityRule_Web_API_DataProvider.getActivityRules(item);
                else
                {
                    ActivityRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ActivityRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ActivityRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ActivityRuleCollection;
        }
    }
}
