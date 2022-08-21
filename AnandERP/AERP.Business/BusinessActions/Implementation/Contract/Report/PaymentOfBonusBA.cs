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
    public class PaymentOfBonusBA : IPaymentOfBonusBA
    {
        IPaymentOfBonusDataProvider _PaymentOfBonusDataProvider;
        private ILogger _logException;

        public PaymentOfBonusBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PaymentOfBonusDataProvider = new PaymentOfBonusDataProvider();
        }

        public IBaseEntityCollectionResponse<PaymentOfBonus> GetPaymentOfBonusDataList(PaymentOfBonusSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PaymentOfBonus> PaymentOfBonusCollection = new BaseEntityCollectionResponse<PaymentOfBonus>();
            try
            {
                if (_PaymentOfBonusDataProvider != null)
                    PaymentOfBonusCollection = _PaymentOfBonusDataProvider.GetPaymentOfBonusDataList(searchRequest);
                else
                {
                    PaymentOfBonusCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PaymentOfBonusCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PaymentOfBonusCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PaymentOfBonusCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PaymentOfBonusCollection;
        }


    }
}