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

namespace AERP.Business.BusinessActions
{
    public class VendorMasterReportBA : IVendorMasterReportBA
    {
          IVendorMasterReportDataProvider _VendorMasterReportDataProvider;
        private ILogger _logException;
        public VendorMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _VendorMasterReportDataProvider = new VendorMasterReportDataProvider();
        }

        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_AllVendorList(VendorMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMasterReport> VendorMasterReportCollection = new BaseEntityCollectionResponse<VendorMasterReport>();
            try
            {
                if (_VendorMasterReportDataProvider != null)
                    VendorMasterReportCollection = _VendorMasterReportDataProvider.GetVendorMasterReportBySearch_AllVendorList(searchRequest);
                else
                {
                    VendorMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterReportCollection;
        }
       //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<VendorMasterReport> GetVendorMasterReportBySearch_ItemList(VendorMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMasterReport> VendorMasterReportCollection = new BaseEntityCollectionResponse<VendorMasterReport>();
            try
            {
                if (_VendorMasterReportDataProvider != null)
                    VendorMasterReportCollection = _VendorMasterReportDataProvider.GetVendorMasterReportBySearch_ItemList(searchRequest);
                else
                {
                    VendorMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterReportCollection;
        }
    }
}
