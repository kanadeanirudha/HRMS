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
    public class ContractSalaryBonusReportBA : IContractSalaryBonusReportBA
    {
        IContractSalaryBonusReportDataProvider _ContractSalaryBonusReportDataProvider;
        //IContractSalaryBonusReportBR _generalRegionMasterBR;
        private ILogger _logException;

        public ContractSalaryBonusReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_generalRegionMasterBR = new ContractSalaryBonusReportBR();
            _ContractSalaryBonusReportDataProvider = new ContractSalaryBonusReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ContractSalaryBonusReport> GetContractSalaryBonusReportDataList(ContractSalaryBonusReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractSalaryBonusReport> ContractSalaryBonusReportCollection = new BaseEntityCollectionResponse<ContractSalaryBonusReport>();
            try
            {
                if (_ContractSalaryBonusReportDataProvider != null)
                    ContractSalaryBonusReportCollection = _ContractSalaryBonusReportDataProvider.GetContractSalaryBonusReportDataList(searchRequest);
                else
                {
                    ContractSalaryBonusReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ContractSalaryBonusReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ContractSalaryBonusReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ContractSalaryBonusReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ContractSalaryBonusReportCollection;
        }

        public IBaseEntityResponse<ContractSalaryBonusReport> InsertContractSalaryBonusReport(ContractSalaryBonusReport item)
        {
            IBaseEntityResponse<ContractSalaryBonusReport> entityResponse = new BaseEntityResponse<ContractSalaryBonusReport>();
            try
            {
                if (_ContractSalaryBonusReportDataProvider != null)
                {
                    entityResponse = _ContractSalaryBonusReportDataProvider.InsertContractSalaryBonusReport(item);
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