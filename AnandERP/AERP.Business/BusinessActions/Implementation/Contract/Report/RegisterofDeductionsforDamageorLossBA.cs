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
    public class RegisterofDeductionsforDamageorLossBA : IRegisterofDeductionsforDamageorLossBA
    {
        IRegisterofDeductionsforDamageorLossDataProvider _RegisterofDeductionsforDamageorLossDataProvider;
        private ILogger _logException;

        public RegisterofDeductionsforDamageorLossBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RegisterofDeductionsforDamageorLossDataProvider = new RegisterofDeductionsforDamageorLossDataProvider();
        }

        public IBaseEntityCollectionResponse<RegisterofDeductionsforDamageorLoss> GetRegisterofDeductionsforDamageorLossDataList(RegisterofDeductionsforDamageorLossSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RegisterofDeductionsforDamageorLoss> RegisterofDeductionsforDamageorLossCollection = new BaseEntityCollectionResponse<RegisterofDeductionsforDamageorLoss>();
            try
            {
                if (_RegisterofDeductionsforDamageorLossDataProvider != null)
                    RegisterofDeductionsforDamageorLossCollection = _RegisterofDeductionsforDamageorLossDataProvider.GetRegisterofDeductionsforDamageorLossDataList(searchRequest);
                else
                {
                    RegisterofDeductionsforDamageorLossCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RegisterofDeductionsforDamageorLossCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RegisterofDeductionsforDamageorLossCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RegisterofDeductionsforDamageorLossCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RegisterofDeductionsforDamageorLossCollection;
        }


    }
}