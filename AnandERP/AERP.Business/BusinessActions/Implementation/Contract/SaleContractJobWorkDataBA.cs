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
    public class SaleContractJobWorkDataBA : ISaleContractJobWorkDataBA
    {
        ISaleContractJobWorkDataDataProvider _SaleContractJobWorkDataDataProvider;
        ISaleContractJobWorkDataBR _generalRegionMasterBR;
        private ILogger _logException;

        public SaleContractJobWorkDataBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SaleContractJobWorkDataBR();
            _SaleContractJobWorkDataDataProvider = new SaleContractJobWorkDataDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractJobWorkData> GetJobWorkDataList(SaleContractJobWorkDataSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractJobWorkData> SaleContractJobWorkDataCollection = new BaseEntityCollectionResponse<SaleContractJobWorkData>();
            try
            {
                if (_SaleContractJobWorkDataDataProvider != null)
                    SaleContractJobWorkDataCollection = _SaleContractJobWorkDataDataProvider.GetJobWorkDataList(searchRequest);
                else
                {
                    SaleContractJobWorkDataCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractJobWorkDataCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractJobWorkDataCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractJobWorkDataCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractJobWorkDataCollection;
        }

        public IBaseEntityResponse<SaleContractJobWorkData> InsertSaleContractJobWorkData(SaleContractJobWorkData item)
        {
            IBaseEntityResponse<SaleContractJobWorkData> entityResponse = new BaseEntityResponse<SaleContractJobWorkData>();
            try
            {
                if (_SaleContractJobWorkDataDataProvider != null)
                {
                    entityResponse = _SaleContractJobWorkDataDataProvider.InsertSaleContractJobWorkData(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}