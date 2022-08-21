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
    public class RegisterofFinesBA : IRegisterofFinesBA
    {
        IRegisterofFinesDataProvider _RegisterofFinesDataProvider;
        private ILogger _logException;

        public RegisterofFinesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RegisterofFinesDataProvider = new RegisterofFinesDataProvider();
        }

        public IBaseEntityCollectionResponse<RegisterofFines> GetRegisterofFinesDataList(RegisterofFinesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RegisterofFines> RegisterofFinesCollection = new BaseEntityCollectionResponse<RegisterofFines>();
            try
            {
                if (_RegisterofFinesDataProvider != null)
                    RegisterofFinesCollection = _RegisterofFinesDataProvider.GetRegisterofFinesDataList(searchRequest);
                else
                {
                    RegisterofFinesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RegisterofFinesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RegisterofFinesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RegisterofFinesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RegisterofFinesCollection;
        }


    }
}