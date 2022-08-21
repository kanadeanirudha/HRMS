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
    public class PFChallanRemittanceBA : IPFChallanRemittanceBA
    {
        IPFChallanRemittanceDataProvider _PFChallanRemittanceDataProvider;
        IPFChallanRemittanceBR _generalRegionMasterBR;
        private ILogger _logException;

        public PFChallanRemittanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new PFChallanRemittanceBR();
            _PFChallanRemittanceDataProvider = new PFChallanRemittanceDataProvider();
        }

        public IBaseEntityCollectionResponse<PFChallanRemittance> GetPFChallanRemittanceDataList(PFChallanRemittanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PFChallanRemittance> PFChallanRemittanceCollection = new BaseEntityCollectionResponse<PFChallanRemittance>();
            try
            {
                if (_PFChallanRemittanceDataProvider != null)
                    PFChallanRemittanceCollection = _PFChallanRemittanceDataProvider.GetPFChallanRemittanceDataList(searchRequest);
                else
                {
                    PFChallanRemittanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PFChallanRemittanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PFChallanRemittanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PFChallanRemittanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PFChallanRemittanceCollection;
        }
        public IBaseEntityCollectionResponse<PFChallanRemittance> GetPFChallanRemittanceDataListForParticularsMonthWise(PFChallanRemittanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PFChallanRemittance> PFChallanRemittanceCollection = new BaseEntityCollectionResponse<PFChallanRemittance>();
            try
            {
                if (_PFChallanRemittanceDataProvider != null)
                    PFChallanRemittanceCollection = _PFChallanRemittanceDataProvider.GetPFChallanRemittanceDataListForParticularsMonthWise(searchRequest);
                else
                {
                    PFChallanRemittanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PFChallanRemittanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PFChallanRemittanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PFChallanRemittanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PFChallanRemittanceCollection;
        }
        public IBaseEntityResponse<PFChallanRemittance> InsertPFChallanRemittance(PFChallanRemittance item)
        {
            IBaseEntityResponse<PFChallanRemittance> entityResponse = new BaseEntityResponse<PFChallanRemittance>();
            try
            {
                if (_PFChallanRemittanceDataProvider != null)
                {
                    entityResponse = _PFChallanRemittanceDataProvider.InsertPFChallanRemittance(item);
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