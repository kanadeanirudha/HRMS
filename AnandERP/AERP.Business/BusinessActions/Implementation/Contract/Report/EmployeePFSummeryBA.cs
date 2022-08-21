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
    public class EmployeePFSummeryBA : IEmployeePFSummeryBA
    {
        IEmployeePFSummeryDataProvider _EmployeePFSummeryDataProvider;
        private ILogger _logException;

        public EmployeePFSummeryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeePFSummeryDataProvider = new EmployeePFSummeryDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeePFSummery> GetEmployeePFSummeryDataList(EmployeePFSummerySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFSummery> EmployeePFSummeryCollection = new BaseEntityCollectionResponse<EmployeePFSummery>();
            try
            {
                if (_EmployeePFSummeryDataProvider != null)
                    EmployeePFSummeryCollection = _EmployeePFSummeryDataProvider.GetEmployeePFSummeryDataList(searchRequest);
                else
                {
                    EmployeePFSummeryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePFSummeryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePFSummeryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePFSummeryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePFSummeryCollection;
        }


    }
}