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
    public class SaleContractWisePNLReportBA : ISaleContractWisePNLReportBA
    {
        ISaleContractWisePNLReportDataProvider _SaleContractWisePNLReportDataProvider;
        private ILogger _logException;

        public SaleContractWisePNLReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractWisePNLReportDataProvider = new SaleContractWisePNLReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractWisePNLReport> GetSaleContractWisePNLReportDataList(SaleContractWisePNLReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractWisePNLReport> SaleContractWisePNLReportCollection = new BaseEntityCollectionResponse<SaleContractWisePNLReport>();
            try
            {
                if (_SaleContractWisePNLReportDataProvider != null)
                    SaleContractWisePNLReportCollection = _SaleContractWisePNLReportDataProvider.GetSaleContractWisePNLReportDataList(searchRequest);
                else
                {
                    SaleContractWisePNLReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractWisePNLReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractWisePNLReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractWisePNLReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractWisePNLReportCollection;
        }


    }
}