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
    public class ContractEmployeeReportBA : IContractEmployeeReportBA
    {
        IContractEmployeeReportDataProvider _ContractEmployeeReportDataProvider;
        //IContractEmployeeReportBR _generalRegionMasterBR;
        private ILogger _logException;

        public ContractEmployeeReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_generalRegionMasterBR = new ContractEmployeeReportBR();
            _ContractEmployeeReportDataProvider = new ContractEmployeeReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeReportDataList(ContractEmployeeReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractEmployeeReport> ContractEmployeeReportCollection = new BaseEntityCollectionResponse<ContractEmployeeReport>();
            try
            {
                if (_ContractEmployeeReportDataProvider != null)
                    ContractEmployeeReportCollection = _ContractEmployeeReportDataProvider.GetContractEmployeeReportDataList(searchRequest);
                else
                {
                    ContractEmployeeReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ContractEmployeeReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ContractEmployeeReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ContractEmployeeReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ContractEmployeeReportCollection;
        }

        public IBaseEntityResponse<ContractEmployeeReport> InsertContractEmployeeReport(ContractEmployeeReport item)
        {
            IBaseEntityResponse<ContractEmployeeReport> entityResponse = new BaseEntityResponse<ContractEmployeeReport>();
            try
            {
                if (_ContractEmployeeReportDataProvider != null)
                {
                    entityResponse = _ContractEmployeeReportDataProvider.InsertContractEmployeeReport(item);
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

        public IBaseEntityCollectionResponse<ContractEmployeeReport> GetContractEmployeeWorkDetailsReportDataList(ContractEmployeeReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ContractEmployeeReport> ContractEmployeeReportCollection = new BaseEntityCollectionResponse<ContractEmployeeReport>();
            try
            {
                if (_ContractEmployeeReportDataProvider != null)
                    ContractEmployeeReportCollection = _ContractEmployeeReportDataProvider.GetContractEmployeeWorkDetailsReportDataList(searchRequest);
                else
                {
                    ContractEmployeeReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ContractEmployeeReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ContractEmployeeReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ContractEmployeeReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ContractEmployeeReportCollection;
        }
    }
}