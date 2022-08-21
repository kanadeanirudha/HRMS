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
    public class SaleContractEmployeePFReportBA : ISaleContractEmployeePFReportBA
    {
        ISaleContractEmployeePFReportDataProvider _SaleContractEmployeePFReportDataProvider;
        ISaleContractEmployeePFReportBR _generalRegionMasterBR;
        private ILogger _logException;

        public SaleContractEmployeePFReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SaleContractEmployeePFReportBR();
            _SaleContractEmployeePFReportDataProvider = new SaleContractEmployeePFReportDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractEmployeePFReport> GetSaleContractEmployeePFReportDataList(SaleContractEmployeePFReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractEmployeePFReport> SaleContractEmployeePFReportCollection = new BaseEntityCollectionResponse<SaleContractEmployeePFReport>();
            try
            {
                if (_SaleContractEmployeePFReportDataProvider != null)
                    SaleContractEmployeePFReportCollection = _SaleContractEmployeePFReportDataProvider.GetSaleContractEmployeePFReportDataList(searchRequest);
                else
                {
                    SaleContractEmployeePFReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractEmployeePFReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractEmployeePFReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractEmployeePFReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractEmployeePFReportCollection;
        }

        public IBaseEntityResponse<SaleContractEmployeePFReport> InsertSaleContractEmployeePFReport(SaleContractEmployeePFReport item)
        {
            IBaseEntityResponse<SaleContractEmployeePFReport> entityResponse = new BaseEntityResponse<SaleContractEmployeePFReport>();
            try
            {
                if (_SaleContractEmployeePFReportDataProvider != null)
                {
                    entityResponse = _SaleContractEmployeePFReportDataProvider.InsertSaleContractEmployeePFReport(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
    }
}