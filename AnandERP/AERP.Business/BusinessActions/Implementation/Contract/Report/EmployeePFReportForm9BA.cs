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
    public class EmployeePFReportForm9BA : IEmployeePFReportForm9BA
    {
        IEmployeePFReportForm9DataProvider _EmployeePFReportForm9DataProvider;
        private ILogger _logException;

        public EmployeePFReportForm9BA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeePFReportForm9DataProvider = new EmployeePFReportForm9DataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeePFReportForm9> GetEmployeePFReportForm9DataList(EmployeePFReportForm9SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportForm9> EmployeePFReportForm9Collection = new BaseEntityCollectionResponse<EmployeePFReportForm9>();
            try
            {
                if (_EmployeePFReportForm9DataProvider != null)
                    EmployeePFReportForm9Collection = _EmployeePFReportForm9DataProvider.GetEmployeePFReportForm9DataList(searchRequest);
                else
                {
                    EmployeePFReportForm9Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePFReportForm9Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePFReportForm9Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePFReportForm9Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePFReportForm9Collection;
        }


    }
}