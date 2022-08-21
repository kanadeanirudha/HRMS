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
    public class EmployeePFReportFORM6ABA : IEmployeePFReportFORM6ABA
    {
        IEmployeePFReportFORM6ADataProvider _EmployeePFReportFORM6ADataProvider;
        private ILogger _logException;

        public EmployeePFReportFORM6ABA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeePFReportFORM6ADataProvider = new EmployeePFReportFORM6ADataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeePFReportFORM6A> GetEmployeePFReportFORM6ADataList(EmployeePFReportFORM6ASearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportFORM6A> EmployeePFReportFORM6ACollection = new BaseEntityCollectionResponse<EmployeePFReportFORM6A>();
            try
            {
                if (_EmployeePFReportFORM6ADataProvider != null)
                    EmployeePFReportFORM6ACollection = _EmployeePFReportFORM6ADataProvider.GetEmployeePFReportFORM6ADataList(searchRequest);
                else
                {
                    EmployeePFReportFORM6ACollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePFReportFORM6ACollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePFReportFORM6ACollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePFReportFORM6ACollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePFReportFORM6ACollection;
        }

    
    }
}