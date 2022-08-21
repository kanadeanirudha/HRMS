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
    public class EmployeeEnterpriseReportBA : IEmployeeEnterpriseReportBA
    {
        IEmployeeEnterpriseReportDataProvider _EmployeeEnterpriseReportDataProvider;
       // IEmployeeEnterpriseReportBR _EmployeeEnterpriseReportBR;
        private ILogger _logException;
        public EmployeeEnterpriseReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
           // _EmployeeEnterpriseReportBR = new EmployeeEnterpriseReportBR();
            _EmployeeEnterpriseReportDataProvider = new EmployeeEnterpriseReportDataProvider();
        }
       
        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeePerformanceMonitoringReportBySearch(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> EmployeeEnterpriseReportCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            try
            {
                if (_EmployeeEnterpriseReportDataProvider != null)
                    EmployeeEnterpriseReportCollection = _EmployeeEnterpriseReportDataProvider.GetEmployeePerformanceMonitoringReportBySearch(searchRequest);
                else
                {
                    EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeEnterpriseReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeEnterpriseReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeEnterpriseReportCollection;
        }
        /// <summary>
        /// Select a record from EmployeeEnterpriseReport table by CentreCode
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeEnterpriseReport> GetEmployeeEnterpriseReportByCentreCode(EmployeeEnterpriseReport item)
        {
            IBaseEntityResponse<EmployeeEnterpriseReport> entityResponse = new BaseEntityResponse<EmployeeEnterpriseReport>();
            try
            {
                entityResponse = _EmployeeEnterpriseReportDataProvider.GetEmployeeEnterpriseReportByCentreCode(item);
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
        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetEmployeeList(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> EmployeeEnterpriseReportCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            try
            {
                if (_EmployeeEnterpriseReportDataProvider != null)
                    EmployeeEnterpriseReportCollection = _EmployeeEnterpriseReportDataProvider.GetEmployeeList(searchRequest);
                else
                {
                    EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeEnterpriseReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeEnterpriseReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeEnterpriseReportCollection;
        }
        /// <summary>
        /// Select all record from EmployeeEnterpriseReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeEnterpriseReport> GetByCentreCodeAndDeptID(EmployeeEnterpriseReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> EmployeeEnterpriseReportCollection = new BaseEntityCollectionResponse<EmployeeEnterpriseReport>();
            try
            {
                if (_EmployeeEnterpriseReportDataProvider != null)
                    EmployeeEnterpriseReportCollection = _EmployeeEnterpriseReportDataProvider.GetByCentreCodeAndDeptID(searchRequest);
                else
                {
                    EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeEnterpriseReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeEnterpriseReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeEnterpriseReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeEnterpriseReportCollection;
        }

    }
}
