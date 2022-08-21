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
    public class EmployeeFormXBA : IEmployeeFormXBA
    {
        IEmployeeFormXDataProvider _EmployeeFormXDataProvider;
        private ILogger _logException;

        public EmployeeFormXBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeFormXDataProvider = new EmployeeFormXDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeFormX> GetEmployeeFormXDataList(EmployeeFormXSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeFormX> EmployeeFormXCollection = new BaseEntityCollectionResponse<EmployeeFormX>();
            try
            {
                if (_EmployeeFormXDataProvider != null)
                    EmployeeFormXCollection = _EmployeeFormXDataProvider.GetEmployeeFormXDataList(searchRequest);
                else
                {
                    EmployeeFormXCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeFormXCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeFormXCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeFormXCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeFormXCollection;
        }


    }
}