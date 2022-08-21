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
    public class RegisterofWorkmenEmployedbyContractorBA : IRegisterofWorkmenEmployedbyContractorBA
    {
        IRegisterofWorkmenEmployedbyContractorDataProvider _RegisterofWorkmenEmployedbyContractorDataProvider;
        private ILogger _logException;

        public RegisterofWorkmenEmployedbyContractorBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RegisterofWorkmenEmployedbyContractorDataProvider = new RegisterofWorkmenEmployedbyContractorDataProvider();
        }

        public IBaseEntityCollectionResponse<RegisterofWorkmenEmployedbyContractor> GetRegisterofWorkmenEmployedbyContractorDataList(RegisterofWorkmenEmployedbyContractorSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RegisterofWorkmenEmployedbyContractor> RegisterofWorkmenEmployedbyContractorCollection = new BaseEntityCollectionResponse<RegisterofWorkmenEmployedbyContractor>();
            try
            {
                if (_RegisterofWorkmenEmployedbyContractorDataProvider != null)
                    RegisterofWorkmenEmployedbyContractorCollection = _RegisterofWorkmenEmployedbyContractorDataProvider.GetRegisterofWorkmenEmployedbyContractorDataList(searchRequest);
                else
                {
                    RegisterofWorkmenEmployedbyContractorCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RegisterofWorkmenEmployedbyContractorCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RegisterofWorkmenEmployedbyContractorCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RegisterofWorkmenEmployedbyContractorCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RegisterofWorkmenEmployedbyContractorCollection;
        }


    }
}