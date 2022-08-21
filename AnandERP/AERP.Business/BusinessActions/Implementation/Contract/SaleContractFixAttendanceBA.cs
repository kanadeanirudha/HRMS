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
    public class SaleContractFixAttendanceBA : ISaleContractFixAttendanceBA
    {
        ISaleContractFixAttendanceDataProvider _SaleContractFixAttendanceDataProvider;
        ISaleContractFixAttendanceBR _generalRegionMasterBR;
        private ILogger _logException;

        public SaleContractFixAttendanceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new SaleContractFixAttendanceBR();
            _SaleContractFixAttendanceDataProvider = new SaleContractFixAttendanceDataProvider();
        }

        public IBaseEntityCollectionResponse<SaleContractFixAttendance> GetFixItemDataList(SaleContractFixAttendanceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractFixAttendance> SaleContractFixAttendanceCollection = new BaseEntityCollectionResponse<SaleContractFixAttendance>();
            try
            {
                if (_SaleContractFixAttendanceDataProvider != null)
                    SaleContractFixAttendanceCollection = _SaleContractFixAttendanceDataProvider.GetFixItemDataList(searchRequest);
                else
                {
                    SaleContractFixAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractFixAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractFixAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractFixAttendanceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractFixAttendanceCollection;
        }

        public IBaseEntityResponse<SaleContractFixAttendance> InsertSaleContractFixAttendance(SaleContractFixAttendance item)
        {
            IBaseEntityResponse<SaleContractFixAttendance> entityResponse = new BaseEntityResponse<SaleContractFixAttendance>();
            try
            {
                if (_SaleContractFixAttendanceDataProvider != null)
                {
                    entityResponse = _SaleContractFixAttendanceDataProvider.InsertSaleContractFixAttendance(item);
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