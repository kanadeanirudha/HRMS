using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using System.Web;
using System.IO;
using System.Net;
using AERP.Business.BusinessActions;

namespace AERP.Web.UI.Controllers
{
    public class AttendenceMonitoringSystemController : BaseController
    {
        IAttendenceMonitoringSystemBA _attendenceMonitoringSystemBA = null;   
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;

        // GET: /AttendenceMonitoringSystem/
        public AttendenceMonitoringSystemController()
        {
            _attendenceMonitoringSystemBA = new AttendenceMonitoringSystemBA();            
        }
        public ActionResult Index()
        {
            IAttendenceMonitoringSystemViewModel model = new AttendenceMonitoringSystemViewModel();
            model.CentreCode = null;
            model.DepartmentID = 0;
            model.Level = 0;
            return View("/Views/MonitoringSystem/AttendenceMonitoringSystem/Index.cshtml", model);
        }

        public ActionResult List(int level,string centreCode,int DepartmentID)
        {
            try
            {
                IAttendenceMonitoringSystemViewModel model = new AttendenceMonitoringSystemViewModel();
                int AccessLevel;
                model.DataCollection= GetAttendenceMonitoringSystemBySearch(level, centreCode, DepartmentID, out AccessLevel);

                if (model.DataCollection.Count > 0)
                {
                    ViewBag.Data = 1;
                }
                else
                {
                    ViewBag.Data = 0;
                }
                if (AccessLevel == 2 && centreCode != null && DepartmentID == 0)
                {
                    return PartialView("/Views/MonitoringSystem/AttendenceMonitoringSystem/AttendenceMonitoringSystemAllDepartmentView.cshtml", model);  // Attendence Monitoring System All Department CentreWise View
                }
                else if (AccessLevel == 3 && centreCode != null && DepartmentID == 0)
                {
                    return PartialView("/Views/MonitoringSystem/AttendenceMonitoringSystem/AttendenceMonitoringSystemEmployeeView.cshtml",model); // Attendence Monitoring System CentreWise Employee View
                }
                else if (AccessLevel == 3 && centreCode != null && DepartmentID != 0)
                {
                    return PartialView("/Views/MonitoringSystem/AttendenceMonitoringSystem/AttendenceMonitoringSystemEmployeeView.cshtml",model); // Attendence Monitoring System DepartmentWise Employee View
                }
                else
                {
                    return PartialView("/Views/MonitoringSystem/AttendenceMonitoringSystem/List.cshtml", model); // Attendence Monitoring System All Centre View
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
       
        public ActionResult AttendenceDetails(int employeeID,string employeeName)
        {
            try
            {
                AttendenceMonitoringSystemViewModel model = new AttendenceMonitoringSystemViewModel();
                model.EmployeeID = employeeID;
                model.EmployeeFullName = employeeName;
                return PartialView("/Views/MonitoringSystem/AttendenceMonitoringSystem/AttendenceDetails.cshtml",model); 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public JsonResult GetAttendenceDetails(double start, double end, int employeeID)
         {
             try
             {
                 var fromDate = ConvertFromMiliSecondsToDate(start);
                 var toDate = ConvertFromMiliSecondsToDate(end);
                 List<AttendenceMonitoringSystem> AttendenceDetailsCollection = LoadAllAttendenceDetailsInDateRange(fromDate, toDate, employeeID);
                 var eventList = from e in AttendenceDetailsCollection
                                 select new
                                 {
                                     holidayDescription = e.HolidayDescription,
                                     start = e.AttendanceDate,
                                     // end = e.EventeEndDate,
                                     color = "red",//e.EventColor,
                                     allDay = true,
                                     editable = false,
                                     weeklyOffStatus = e.WeeklyOffStatus,
                                     leaveCode = e.LeaveCode,
                                     attendanceDescription = e.AttendanceDescription,
                                     checkInTime = e.CheckInTime,
                                     checkOutTime= e.CheckOutTime,
                                     workingHour = e.WorkingHour,
                                     halfLeaveStatus = e.HalfLeaveStatus,
                                     backgroundColor = "#9FEA7A",
                                     borderColor = "#9FEA7A"
                                 };
                 var rows = eventList.ToArray();
                 return Json(rows, JsonRequestBehavior.AllowGet);
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
        }
        
        protected List<AttendenceMonitoringSystem> GetAttendenceMonitoringSystemBySearch(int Level, string CentreCode, int DeptID ,out int AccessLevel)
        {
            try
            {
                AttendenceMonitoringSystemSearchRequest searchRequest = new AttendenceMonitoringSystemSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.Level = Level;
                searchRequest.CentreCode = CentreCode;
                searchRequest.DepartmentID = DeptID;
                searchRequest.RoleID =  !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                searchRequest.EmployeeID = !string.IsNullOrEmpty(Convert.ToString(Session["PersonID"])) ? Convert.ToInt32(Session["PersonID"]) : 0;
                List<AttendenceMonitoringSystem> listAttendenceMonitoringSystem = new List<AttendenceMonitoringSystem>();
                IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollectionResponse = _attendenceMonitoringSystemBA.GetAttendenceMonitoringSystemBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAttendenceMonitoringSystem = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                AccessLevel = baseEntityCollectionResponse.AccessLevel;
                return listAttendenceMonitoringSystem;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        protected List<AttendenceMonitoringSystem> LoadAllAttendenceDetailsInDateRange(DateTime fromDate,DateTime toDate,int employeeID )
        {
            try
            {
                AttendenceMonitoringSystemSearchRequest searchRequest = new AttendenceMonitoringSystemSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.EmployeeID = employeeID;
                searchRequest.FromDate = fromDate;
                searchRequest.UptoDate = toDate;
                List<AttendenceMonitoringSystem> listAttendenceMonitoringSystem = new List<AttendenceMonitoringSystem>();
                IBaseEntityCollectionResponse<AttendenceMonitoringSystem> baseEntityCollectionResponse = _attendenceMonitoringSystemBA.GetAttendenceDetailsByEmployeeID(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listAttendenceMonitoringSystem = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listAttendenceMonitoringSystem;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

    }
}
