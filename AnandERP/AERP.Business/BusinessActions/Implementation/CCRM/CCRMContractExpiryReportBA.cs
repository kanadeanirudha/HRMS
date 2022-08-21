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

namespace AERP.Business.BusinessActions
{
   public class CCRMContractExpiryReportBA :ICCRMContractExpiryReportBA
    {
        ICCRMContractExpiryReportDataProvider _CCRMContractExpiryReportDataProvider;
        private ILogger _logException;
        public CCRMContractExpiryReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMContractExpiryReportDataProvider = new CCRMContractExpiryReportDataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMContractExpiryReport> GetCCRMContractExpiryReportBySearch_AllContractExpiry(CCRMContractExpiryReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractExpiryReport> CCRMContractExpiryReportCollection = new BaseEntityCollectionResponse<CCRMContractExpiryReport>();
            try
            {
                if (_CCRMContractExpiryReportDataProvider != null)
                    CCRMContractExpiryReportCollection = _CCRMContractExpiryReportDataProvider.GetCCRMContractExpiryReportBySearch_AllContractExpiry(searchRequest);
                else
                {
                    CCRMContractExpiryReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMContractExpiryReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMContractExpiryReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMContractExpiryReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMContractExpiryReportCollection;
        }
    }
}
