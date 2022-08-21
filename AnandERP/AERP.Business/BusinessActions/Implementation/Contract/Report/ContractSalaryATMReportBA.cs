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
    public class ContractSalaryATMReportBA : IContractSalaryATMReportBA
    {
        IContractSalaryATMReportDataProvider _ContractSalaryATMReportDataProvider;
        //IContractSalaryATMReportBR _generalRegionMasterBR;
        private ILogger _logException;

        public ContractSalaryATMReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_generalRegionMasterBR = new ContractSalaryATMReportBR();
            _ContractSalaryATMReportDataProvider = new ContractSalaryATMReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ContractSalaryATMReport> GetContractSalaryATMReportDataList(ContractSalaryATMReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractSalaryATMReport> ContractSalaryATMReportCollection = new BaseEntityCollectionResponse<ContractSalaryATMReport>();
            try
            {
                if (_ContractSalaryATMReportDataProvider != null)
                    ContractSalaryATMReportCollection = _ContractSalaryATMReportDataProvider.GetContractSalaryATMReportDataList(searchRequest);
                else
                {
                    ContractSalaryATMReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ContractSalaryATMReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ContractSalaryATMReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ContractSalaryATMReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ContractSalaryATMReportCollection;
        }

        public IBaseEntityResponse<ContractSalaryATMReport> InsertContractSalaryATMReport(ContractSalaryATMReport item)
        {
            IBaseEntityResponse<ContractSalaryATMReport> entityResponse = new BaseEntityResponse<ContractSalaryATMReport>();
            try
            {
                if (_ContractSalaryATMReportDataProvider != null)
                {
                    entityResponse = _ContractSalaryATMReportDataProvider.InsertContractSalaryATMReport(item);
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