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
    public class RegisterofAdavancesBA : IRegisterofAdavancesBA
    {
        IRegisterofAdavancesDataProvider _RegisterofAdavancesDataProvider;
        private ILogger _logException;

        public RegisterofAdavancesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RegisterofAdavancesDataProvider = new RegisterofAdavancesDataProvider();
        }

        public IBaseEntityCollectionResponse<RegisterofAdavances> GetRegisterofAdavancesDataList(RegisterofAdavancesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RegisterofAdavances> RegisterofAdavancesCollection = new BaseEntityCollectionResponse<RegisterofAdavances>();
            try
            {
                if (_RegisterofAdavancesDataProvider != null)
                    RegisterofAdavancesCollection = _RegisterofAdavancesDataProvider.GetRegisterofAdavancesDataList(searchRequest);
                else
                {
                    RegisterofAdavancesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RegisterofAdavancesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RegisterofAdavancesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RegisterofAdavancesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RegisterofAdavancesCollection;
        }


    }
}