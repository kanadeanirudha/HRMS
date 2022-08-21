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
    public class InventoryDashboardReportBA : IInventoryDashboardReportBA
    {
        IInventoryDashboardReportDataProvider InventoryDashboardReportDataProvider;

        private ILogger _logException;

        public InventoryDashboardReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            InventoryDashboardReportDataProvider = new InventoryDashboardReportDataProvider();
        }

        //InventoryDashboardReport

        public IBaseEntityCollectionResponse<InventoryDashboardReport> GetMonthlySaleReport(InventoryDashboardReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryDashboardReport> cRMSaleBillingTransactionCollection = new BaseEntityCollectionResponse<InventoryDashboardReport>();
            try
            {
                if (InventoryDashboardReportDataProvider != null)
                    cRMSaleBillingTransactionCollection = InventoryDashboardReportDataProvider.GetMonthlySaleReport(searchRequest);
                else
                {
                    cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    cRMSaleBillingTransactionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                cRMSaleBillingTransactionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                cRMSaleBillingTransactionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return cRMSaleBillingTransactionCollection;
        }
        
    }
}
