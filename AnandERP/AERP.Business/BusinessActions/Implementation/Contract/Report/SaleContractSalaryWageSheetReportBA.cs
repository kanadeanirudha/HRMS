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
    public class SaleContractSalaryWageSheetReportBA : ISaleContractSalaryWageSheetReportBA
    {
        ISaleContractSalaryWageSheetReportDataProvider _SaleContractSalaryWageSheetReportDataProvider;
        private ILogger _logException;

        public SaleContractSalaryWageSheetReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractSalaryWageSheetReportDataProvider = new SaleContractSalaryWageSheetReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> GetSaleContractSalaryWageSheetReportDataList(SaleContractSalaryWageSheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractSalaryWageSheetReport> SaleContractSalaryWageSheetReportCollection = new BaseEntityCollectionResponse<SaleContractSalaryWageSheetReport>();
            try
            {
                if (_SaleContractSalaryWageSheetReportDataProvider != null)
                    SaleContractSalaryWageSheetReportCollection = _SaleContractSalaryWageSheetReportDataProvider.GetSaleContractSalaryWageSheetReportDataList(searchRequest);
                else
                {
                    SaleContractSalaryWageSheetReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractSalaryWageSheetReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractSalaryWageSheetReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractSalaryWageSheetReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractSalaryWageSheetReportCollection;
        }


    }
}