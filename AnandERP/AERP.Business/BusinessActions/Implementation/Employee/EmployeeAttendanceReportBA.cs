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

namespace AMS.Business.BusinessAction
{
    public class EmployeeAttendanceReportBA : IEmployeeAttendanceReportBA
    {
        IEmployeeAttendanceReportDataProvider _employeeAttendanceReportDataProvider;
        IEmployeeAttendanceReportMasterBR _employeeAttendanceReportBR;
        private ILogger _logException;

        public EmployeeAttendanceReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeAttendanceReportBR = new EmployeeAttendanceReportMasterBR();
            _employeeAttendanceReportDataProvider = new EmployeeAttendanceReportDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportSelectAll(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> employeeAttendanceReportCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
            try
            {
                if (_employeeAttendanceReportDataProvider != null)
                {
                    employeeAttendanceReportCollection = _employeeAttendanceReportDataProvider.GetEmployeeAttendanceReportSelectAll(searchRequest);
                }
                else
                {
                    employeeAttendanceReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    employeeAttendanceReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                employeeAttendanceReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                employeeAttendanceReportCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return employeeAttendanceReportCollection;
        }


        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeCentreAndDepartmentWise(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> employeeCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
            try
            {
                if (_employeeAttendanceReportDataProvider != null)
                {
                    employeeCollection = _employeeAttendanceReportDataProvider.GetEmployeeCentreAndDepartmentWise(searchRequest);
                }
                else
                {
                    employeeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    employeeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                employeeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                employeeCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return employeeCollection;
        }

        //Get Data from Attendance Report.
        public IBaseEntityCollectionResponse<EmployeeAttendanceReport> GetEmployeeAttendanceReportData(EmployeeAttendanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> empAttendanceCollection = new BaseEntityCollectionResponse<EmployeeAttendanceReport>();
            try
            {
                if (_employeeAttendanceReportDataProvider != null)
                {
                    empAttendanceCollection = _employeeAttendanceReportDataProvider.GetEmployeeAttendanceReportData(searchRequest);
                }
                else
                {
                    empAttendanceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    empAttendanceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                empAttendanceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                empAttendanceCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return empAttendanceCollection;
        }

    }
}
