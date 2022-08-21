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
    public class EmployeeESICReportForm7BA : IEmployeeESICReportForm7BA
    {
        IEmployeeESICReportForm7DataProvider _EmployeeESICReportForm7DataProvider;
        private ILogger _logException;

        public EmployeeESICReportForm7BA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeESICReportForm7DataProvider = new EmployeeESICReportForm7DataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeESICReportForm7> GetEmployeeESICReportForm7DataList(EmployeeESICReportForm7SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeESICReportForm7> EmployeeESICReportForm7Collection = new BaseEntityCollectionResponse<EmployeeESICReportForm7>();
            try
            {
                if (_EmployeeESICReportForm7DataProvider != null)
                    EmployeeESICReportForm7Collection = _EmployeeESICReportForm7DataProvider.GetEmployeeESICReportForm7DataList(searchRequest);
                else
                {
                    EmployeeESICReportForm7Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeESICReportForm7Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeESICReportForm7Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeESICReportForm7Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeESICReportForm7Collection;
        }


    }
}