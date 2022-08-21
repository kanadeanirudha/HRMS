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
    public class ContractPaymentPendingReportBA : IContractPaymentPendingReportBA
    {
        IContractPaymentPendingReportDataProvider _ContractPaymentPendingReportDataProvider;
        private ILogger _logException;

        public ContractPaymentPendingReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ContractPaymentPendingReportDataProvider = new ContractPaymentPendingReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ContractPaymentPendingReport> GetContractPaymentPendingReportDataList(ContractPaymentPendingReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractPaymentPendingReport> ContractPaymentPendingReportCollection = new BaseEntityCollectionResponse<ContractPaymentPendingReport>();
            try
            {
                if (_ContractPaymentPendingReportDataProvider != null)
                    ContractPaymentPendingReportCollection = _ContractPaymentPendingReportDataProvider.GetContractPaymentPendingReportDataList(searchRequest);
                else
                {
                    ContractPaymentPendingReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ContractPaymentPendingReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ContractPaymentPendingReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ContractPaymentPendingReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ContractPaymentPendingReportCollection;
        }


    }
}