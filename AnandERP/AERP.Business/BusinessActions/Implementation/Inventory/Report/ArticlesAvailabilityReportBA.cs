using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class ArticlesAvailabilityReportBA : IArticlesAvailabilityReportBA
    {
        IArticlesAvailabilityReportDataProvider _ArticlesAvailabilityReportDataProvider;
        private ILogger _logException;
        public ArticlesAvailabilityReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _ArticlesAvailabilityReportDataProvider = new ArticlesAvailabilityReportDataProvider();
        }

        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportBySociety(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ArticlesAvailabilityReport> ArticlesAvailabilityReportCollection = new BaseEntityCollectionResponse<ArticlesAvailabilityReport>();
            try
            {
                if (_ArticlesAvailabilityReportDataProvider != null)
                    ArticlesAvailabilityReportCollection = _ArticlesAvailabilityReportDataProvider.GetArticlesAvailabilityReportBySociety(searchRequest);
                else
                {
                    ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticlesAvailabilityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticlesAvailabilityReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticlesAvailabilityReportCollection;
        }
        //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByCentre(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ArticlesAvailabilityReport> ArticlesAvailabilityReportCollection = new BaseEntityCollectionResponse<ArticlesAvailabilityReport>();
            try
            {
                if (_ArticlesAvailabilityReportDataProvider != null)
                    ArticlesAvailabilityReportCollection = _ArticlesAvailabilityReportDataProvider.GetArticlesAvailabilityReportByCentre(searchRequest);
                else
                {
                    ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticlesAvailabilityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticlesAvailabilityReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticlesAvailabilityReportCollection;
        }


        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByStore(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ArticlesAvailabilityReport> ArticlesAvailabilityReportCollection = new BaseEntityCollectionResponse<ArticlesAvailabilityReport>();
            try
            {
                if (_ArticlesAvailabilityReportDataProvider != null)
                    ArticlesAvailabilityReportCollection = _ArticlesAvailabilityReportDataProvider.GetArticlesAvailabilityReportByStore(searchRequest);
                else
                {
                    ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticlesAvailabilityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticlesAvailabilityReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticlesAvailabilityReportCollection;
        }

        public IBaseEntityCollectionResponse<ArticlesAvailabilityReport> GetArticlesAvailabilityReportByVendor(ArticlesAvailabilityReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ArticlesAvailabilityReport> ArticlesAvailabilityReportCollection = new BaseEntityCollectionResponse<ArticlesAvailabilityReport>();
            try
            {
                if (_ArticlesAvailabilityReportDataProvider != null)
                    ArticlesAvailabilityReportCollection = _ArticlesAvailabilityReportDataProvider.GetArticlesAvailabilityReportByVendor(searchRequest);
                else
                {
                    ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ArticlesAvailabilityReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ArticlesAvailabilityReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                ArticlesAvailabilityReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ArticlesAvailabilityReportCollection;
        }
    }
}
