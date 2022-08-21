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
    public class SaleContractWiseEmployeeDataReportBA : ISaleContractWiseEmployeeDataReportBA
    {
        ISaleContractWiseEmployeeDataReportDataProvider _SaleContractWiseEmployeeDataReportDataProvider;
        private ILogger _logException;

        public SaleContractWiseEmployeeDataReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractWiseEmployeeDataReportDataProvider = new SaleContractWiseEmployeeDataReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractWiseEmployeeDataReport> GetSaleContractWiseEmployeeDataReportDataList(SaleContractWiseEmployeeDataReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractWiseEmployeeDataReport> SaleContractWiseEmployeeDataReportCollection = new BaseEntityCollectionResponse<SaleContractWiseEmployeeDataReport>();
            try
            {
                if (_SaleContractWiseEmployeeDataReportDataProvider != null)
                    SaleContractWiseEmployeeDataReportCollection = _SaleContractWiseEmployeeDataReportDataProvider.GetSaleContractWiseEmployeeDataReportDataList(searchRequest);
                else
                {
                    SaleContractWiseEmployeeDataReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractWiseEmployeeDataReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractWiseEmployeeDataReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractWiseEmployeeDataReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractWiseEmployeeDataReportCollection;
        }
    }
}