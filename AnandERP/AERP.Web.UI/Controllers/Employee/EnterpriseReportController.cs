using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
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

namespace AERP.Web.UI.Controllers
{
    public class EnterpriseReportController : BaseController
    {
        IEmployeeEnterpriseReportBA _employeeEnterpriseReportBA= null;       

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        private readonly ILogger _logException;
        //
        // GET: /EnterpriseReport/

        public EnterpriseReportController()
        {
            _employeeEnterpriseReportBA= new EmployeeEnterpriseReportBA();            
        }
        public ActionResult Index()
        {
            IEmployeeEnterpriseReportViewModel model = new EmployeeEnterpriseReportViewModel();
            model.CentreCode = null;
            model.DepartmentID = 0;
            model.Level = 0;
           
            return View("/Views/Employee/EmployeeEnterpriseReport/Index.cshtml",model);
        }

        public ActionResult EmployeePerformanceMonitoringReport(int level,string centreCode,int DepartmentID)
        {
            EmployeeEnterpriseReportViewModel model = new EmployeeEnterpriseReportViewModel();
           // model.EmployeeEnterpriseReportDTO.EmployeeID = EmployeeID;

            List<EmployeeEnterpriseReport> EmployeePerformanceMonitoringReporttList = GetEmployeePerformanceMonitoringReport(level, centreCode, DepartmentID);
            if (EmployeePerformanceMonitoringReporttList.Count > 0)
            {
                ViewBag.Data = 1;
                ViewBag.ListEmployeePerformanceMonitoringReport = EmployeePerformanceMonitoringReporttList;
                
            }
            else
            {
                ViewBag.Data = 0;
            }
           
             if (level == 1 && centreCode != null && DepartmentID == 0)
            {
                return PartialView("/Views/Employee/EmployeeEnterpriseReport/EmpPerformanceMonitoringRptCenCodeLevOne.cshtml");
            }
            else if (level == 2 && centreCode != null && DepartmentID == 0)
            {
                return PartialView("/Views/Employee/EmployeeEnterpriseReport/EmployeePerformanceMonitoringRptDaptID.cshtml");
            }
             else if (level == 2 && centreCode != null && DepartmentID != 0)
            {
                return PartialView("/Views/Employee/EmployeeEnterpriseReport/EmployeePerformanceMonitoringRptDaptID.cshtml");
            }
            else
            {
                return PartialView("/Views/Employee/EmployeeEnterpriseReport/EmployeePerformanceMonitoringReport.cshtml"); 
            }

        }


        public List<EmployeeEnterpriseReport> GetEmployeePerformanceMonitoringReport(int Level,string CentreCode,int DeptID)
        {
            EmployeeEnterpriseReportSearchRequest searchRequest = new EmployeeEnterpriseReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.Level = Level;
            searchRequest.CentreCode = CentreCode;
            searchRequest.DepartmentID = DeptID;            
            
            List<EmployeeEnterpriseReport> listEmployeePerformanceMonitoringReport = new List<EmployeeEnterpriseReport>();
            IBaseEntityCollectionResponse<EmployeeEnterpriseReport> baseEntityCollectionResponse = _employeeEnterpriseReportServiceAccess.GetEmployeePerformanceMonitoringReportBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeePerformanceMonitoringReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeePerformanceMonitoringReport;
        }

    }
}
