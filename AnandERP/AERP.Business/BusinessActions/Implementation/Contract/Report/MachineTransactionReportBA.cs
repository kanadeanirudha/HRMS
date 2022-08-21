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
    public class MachineTransactionReportBA : IMachineTransactionReportBA
    {
        IMachineTransactionReportDataProvider _MachineTransactionReportDataProvider;
        //IMachineTransactionReportBR _generalRegionMasterBR;
        private ILogger _logException;

        public MachineTransactionReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_generalRegionMasterBR = new MachineTransactionReportBR();
            _MachineTransactionReportDataProvider = new MachineTransactionReportDataProvider();
        }

        public IBaseEntityCollectionResponse<MachineTransactionReport> GetMachineTransactionReportDataList(MachineTransactionReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<MachineTransactionReport> MachineTransactionReportCollection = new BaseEntityCollectionResponse<MachineTransactionReport>();
            try
            {
                if (_MachineTransactionReportDataProvider != null)
                    MachineTransactionReportCollection = _MachineTransactionReportDataProvider.GetMachineTransactionReportDataList(searchRequest);
                else
                {
                    MachineTransactionReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    MachineTransactionReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                MachineTransactionReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                MachineTransactionReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return MachineTransactionReportCollection;
        }

    
    }
}