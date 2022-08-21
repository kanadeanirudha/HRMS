using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Linq;

using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using AMS.Common;
using AMS.DataProvider;
using System.Configuration;
using System.Xml;

namespace AMS.Web.UI.Controllers
{
    public class EmployeeAttendanceReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IEmployeeAttendanceReportServiceAccess _employeeAttendanceReportServiceAccess = null;
        private readonly ILogger _logException;
        protected static string _uptoDate = string.Empty;
        protected static string _fromDate = string.Empty;
        protected static int _employeeID;
        protected static string _centreCode;
        protected static string _departmentID;
        #endregion


        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public EmployeeAttendanceReportController()
        {
            _employeeAttendanceReportServiceAccess = new EmployeeAttendanceReportServiceAccess();
        }
        #endregion


        //  Controller Methods.
        #region ------------------Controller Methods------------------

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                EmployeeAttendanceReportViewModel model = new EmployeeAttendanceReportViewModel();

                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
                AdminRoleApplicableDetails admin = null;

                foreach (var item in listAdminRoleApplicableDetails)
                {
                    admin = new AdminRoleApplicableDetails();
                    admin.CentreCode = item.CentreCode;
                    admin.CentreName = item.CentreName;
                    admin.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(admin);
                }
                foreach (var b in model.ListGetAdminRoleApplicableCentre)
                {
                    b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                }                
                return View("/Views/Employee/EmployeeAttendanceReport/Index.cshtml", model);                           
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[HttpPost]
        //public ActionResult Index(EmployeeAttendanceReportViewModel model)
        //{
        //    try
        //    {
        //        int AdminRoleMasterID = 0;
        //        if (Session["RoleID"] == null)
        //        {
        //            AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
        //        }
        //        else
        //        {
        //            AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
        //        }
        //        List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
        //        AdminRoleApplicableDetails admin = null;

        //        foreach (var item in listAdminRoleApplicableDetails)
        //        {
        //            admin = new AdminRoleApplicableDetails();
        //            admin.CentreCode = item.CentreCode;
        //            admin.CentreName = item.CentreName;
        //            admin.ScopeIdentity = item.ScopeIdentity;
        //            model.ListGetAdminRoleApplicableCentre.Add(admin);
        //        }
        //        foreach (var b in model.ListGetAdminRoleApplicableCentre)
        //        {
        //            b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
        //        }

        //        //Get Department.
        //        string[] splited = model.CentreCode.Split(':');
        //        List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
        //        OrganisationDepartmentMaster dept = null;
        //        foreach (var item in listOrganisationDepartmentMaster)
        //        {
        //            dept = new OrganisationDepartmentMaster();
        //            dept.ID = item.ID;
        //            dept.DepartmentName = item.DepartmentName;
        //            model.ListOrganisationDepartmentMaster.Add(dept);
        //        }
                                
        //        //Get Employee.                
        //        model.ListGetCentreEmployeeName =  GetEmployeeCentreAndDepartmentWise(splited[0], model.EmployeeID, model.DepartmentID);
             

        //        //if (model.IsPosted == true)
        //        //{
        //            _centreCode = model.CentreCode;
        //            _employeeID = model.EmployeeID;
        //            _departmentID = model.DepartmentID;
        //            _fromDate = model.FromDate;
        //            _uptoDate = model.UptoDate;
        //            model.IsPosted = false;
        //        //}

        //        //Code for Html Report
        //        //if (System.Configuration.ConfigurationManager.AppSettings["IsInventoryHtmlReports"] == "1")
        //        //{
        //            if (model.FromDate != null && model.UptoDate != null && model.DepartmentID > 0 && model.CentreCode != null)
        //            {
        //                model.ListEmployeeAttendanceReportData = GetEmployeeAttendanceReportData();
        //            }
        //        //}

        //        return View("/Views/Employee/EmployeeAttendanceReport/Index.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        [HttpPost]
        public ActionResult List(string centreCode, string departmentID, int employeeID, string fromDate, string uptoDate)
        {
            EmployeeAttendanceReportViewModel model = new EmployeeAttendanceReportViewModel();
            if (centreCode != string.Empty && fromDate != string.Empty && uptoDate != string.Empty)
            {
                _centreCode = centreCode;
                _departmentID = departmentID;
                _employeeID = employeeID;
                _fromDate = fromDate;
                _uptoDate = uptoDate;
            }
            else
            {
                _centreCode = string.Empty;
                _departmentID = string.Empty;
                _employeeID = 0;
                _fromDate = string.Empty;
                _uptoDate = string.Empty;
            }

            model.ListEmployeeAttendanceReportData = GetEmployeeAttendanceReportData();

            return PartialView("/Views/Employee/EmployeeAttendanceReport/List.cshtml", model);
            //return Json(model, JsonRequestBehavior.AllowGet);
        }

        //Get Department by Center code.
        public ActionResult GetDepartmentByCentreCode(string centreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = centreCode.Split(':');
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(centreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get Employee by Department and Center Code.
        public ActionResult GetEmployeeByCentreCodeAndDept(string centreCode, string departmentID)
        {
            string[] splited = centreCode.Split(':');
            int employeeID = 0;
            if (splited[1] == "SELF")
            {
                employeeID = Convert.ToInt32(Convert.ToInt32(Session["PersonID"]));
            }
            else
            {
                employeeID = 0;
            }
            
            if (String.IsNullOrEmpty(centreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            //int id = 0;
            //bool isValid = Int32.TryParse(centreCode, out id);
            var employee = GetEmployeeCentreAndDepartmentWise(splited[0], employeeID, departmentID);
            var result = (from s in employee
                          select new
                          {
                              id = s.EmployeeID,
                              name = s.EmployeeName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // Non-Action Methods
        #region Methods
        public List<EmployeeAttendanceReport> GetEmployeeCentreAndDepartmentWise(string centreCode, int employeeID, string departmentID)
        {
            EmployeeAttendanceReportSearchRequest searchRequest = new EmployeeAttendanceReportSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.CentreCode = centreCode;
            searchRequest.DepartmentID = departmentID;
            searchRequest.EmployeeID = employeeID;

           
            List<EmployeeAttendanceReport> employeeList = new List<EmployeeAttendanceReport>();
            IBaseEntityCollectionResponse<EmployeeAttendanceReport> baseEntityCollectionResponse = _employeeAttendanceReportServiceAccess.GetEmployeeCentreAndDepartmentWise(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    employeeList = baseEntityCollectionResponse.CollectionResponse.ToList();
                   
                }                
            }
            return employeeList;
        }


        public List<EmployeeAttendanceReport> GetEmployeeAttendanceReportData()
        {
            try
            {
                List<EmployeeAttendanceReport> listItemReport = new List<EmployeeAttendanceReport>();
                if (_centreCode != "" && _departmentID != "")
                {
                    EmployeeAttendanceReportSearchRequest searchRequest = new EmployeeAttendanceReportSearchRequest();
                    searchRequest.ConnectionString = _connectioString;
                    string[] splited = _centreCode.Split(':');
                    searchRequest.CentreCode = splited[0];
                    searchRequest.DepartmentID = _departmentID;
                    searchRequest.EmployeeID = _employeeID;
                    searchRequest.FromDate = _fromDate;
                    searchRequest.UptoDate = _uptoDate;                    

                    IBaseEntityCollectionResponse<EmployeeAttendanceReport> response = _employeeAttendanceReportServiceAccess.GetEmployeeAttendanceReportData(searchRequest);                   
                    if (response != null)
                    {
                        if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                        {
                            listItemReport = response.CollectionResponse.OrderBy(x => x.EmployeeName).ToList();
                        }
                    }
                    return listItemReport;
                }
                else
                {
                    return listItemReport;
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

    }
}
