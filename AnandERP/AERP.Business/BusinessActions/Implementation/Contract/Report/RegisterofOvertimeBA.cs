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
    public class RegisterofOvertimeBA : IRegisterofOvertimeBA
    {
        IRegisterofOvertimeDataProvider _RegisterofOvertimeDataProvider;
        private ILogger _logException;

        public RegisterofOvertimeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RegisterofOvertimeDataProvider = new RegisterofOvertimeDataProvider();
        }

        public IBaseEntityCollectionResponse<RegisterofOvertime> GetRegisterofOvertimeDataList(RegisterofOvertimeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RegisterofOvertime> RegisterofOvertimeCollection = new BaseEntityCollectionResponse<RegisterofOvertime>();
            try
            {
                if (_RegisterofOvertimeDataProvider != null)
                    RegisterofOvertimeCollection = _RegisterofOvertimeDataProvider.GetRegisterofOvertimeDataList(searchRequest);
                else
                {
                    RegisterofOvertimeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RegisterofOvertimeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RegisterofOvertimeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RegisterofOvertimeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RegisterofOvertimeCollection;
        }


    }
}