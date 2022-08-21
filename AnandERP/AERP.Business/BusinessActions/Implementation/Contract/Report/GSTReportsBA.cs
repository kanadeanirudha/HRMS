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
    public class GSTReportsBA : IGSTReportsBA
    {
        IGSTReportsDataProvider _GSTReportsDataProvider;
        private ILogger _logException;

        public GSTReportsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _GSTReportsDataProvider = new GSTReportsDataProvider();
        }

        public IBaseEntityCollectionResponse<GSTReports> GetGSTR1ReportsDataList(GSTReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GSTReports> GSTReportsCollection = new BaseEntityCollectionResponse<GSTReports>();
            try
            {
                if (_GSTReportsDataProvider != null)
                    GSTReportsCollection = _GSTReportsDataProvider.GetGSTR1ReportsDataList(searchRequest);
                else
                {
                    GSTReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GSTReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GSTReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GSTReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GSTReportsCollection;
        }
        public IBaseEntityCollectionResponse<GSTReports> GetGSTR2ReportsDataList(GSTReportsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<GSTReports> GSTReportsCollection = new BaseEntityCollectionResponse<GSTReports>();
            try
            {
                if (_GSTReportsDataProvider != null)
                    GSTReportsCollection = _GSTReportsDataProvider.GetGSTR2ReportsDataList(searchRequest);
                else
                {
                    GSTReportsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    GSTReportsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                GSTReportsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                GSTReportsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return GSTReportsCollection;
        }


    }
}