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
    public class SaleContractWiseComplianceReportBA : ISaleContractWiseComplianceReportBA
    {
        ISaleContractWiseComplianceReportDataProvider _SaleContractWiseComplianceReportDataProvider;
        private ILogger _logException;

        public SaleContractWiseComplianceReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractWiseComplianceReportDataProvider = new SaleContractWiseComplianceReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractWiseComplianceReport> GetSaleContractWiseComplianceReportDataList(SaleContractWiseComplianceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractWiseComplianceReport> SaleContractWiseComplianceReportCollection = new BaseEntityCollectionResponse<SaleContractWiseComplianceReport>();
            try
            {
                if (_SaleContractWiseComplianceReportDataProvider != null)
                    SaleContractWiseComplianceReportCollection = _SaleContractWiseComplianceReportDataProvider.GetSaleContractWiseComplianceReportDataList(searchRequest);
                else
                {
                    SaleContractWiseComplianceReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractWiseComplianceReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractWiseComplianceReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractWiseComplianceReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractWiseComplianceReportCollection;
        }


    }
}