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
    public class SaleContractLifeSpanReportBA : ISaleContractLifeSpanReportBA
    {
        ISaleContractLifeSpanReportDataProvider _SaleContractLifeSpanReportDataProvider;
        private ILogger _logException;

        public SaleContractLifeSpanReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractLifeSpanReportDataProvider = new SaleContractLifeSpanReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractLifeSpanReport> GetSaleContractLifeSpanReportDataList(SaleContractLifeSpanReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractLifeSpanReport> SaleContractLifeSpanReportCollection = new BaseEntityCollectionResponse<SaleContractLifeSpanReport>();
            try
            {
                if (_SaleContractLifeSpanReportDataProvider != null)
                    SaleContractLifeSpanReportCollection = _SaleContractLifeSpanReportDataProvider.GetSaleContractLifeSpanReportDataList(searchRequest);
                else
                {
                    SaleContractLifeSpanReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractLifeSpanReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractLifeSpanReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractLifeSpanReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractLifeSpanReportCollection;
        }


    }
}