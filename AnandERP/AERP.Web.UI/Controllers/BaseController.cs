using AERP.DTO;
using AERP.Common;
using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using System.Threading;
using AERP.ViewModel;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Web.UI;
using AERP.Web.UI.HtmlHelperExtensions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;
using System.Net.Mail;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net.Security;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using GoogleMaps.LocationServices;
using System.Device.Location;
using System.Xml;

namespace AERP.Web.UI.Controllers
{
    [Authorize]
    //[SessionExpire]
    public class BaseController : Controller
    {
        IAdminRoleApplicableDetailsBA _adminRoleApplicableDetailsBA = null;
        IOrganisationStudyCentreMasterBA _organisationStudyCentreMasterBA = null;
        IOrganisationDepartmentMasterBA _organisationDepartmentMasterBA = null;
        IAdminSnPostsBA _adminSnPostsBA = null;
        IEmpDesignationMasterBA _empDesignationMasterBA = null;
        IGeneralRegionMasterBA _generalRegionMasterBA = null;
        IGeneralCountryMasterBA _generalCountryMasterBA = null;
        IGeneralEducationTypeMasterBA _generalEducationTypeMasterBA = null;
        IGeneralCityMasterBA _generalCityMasterBA = null;
        IOrganisationMasterBA _organisationMasterBA = null;
        IGeneralUnitMasterBA _generalUnitMasterBA = null;
        IGeneralLocationMasterBA _generalLocationMasterBA = null;
        IUserModuleMasterBA _userModuleMasterBA = null;
        IUserMainMenuMasterBA _userMainMenuMasterBA = null;
        IGeneralTitleMasterBA _generalTitleMasterBA = null;
        IGeneralNationalityMasterBA _generalNationalityMasterBA = null;
        IEmployeeShiftMasterBA _employeeShiftMasterBA = null;
        IGeneralJobProfileBA _generalJobProfileBA = null;
        IGeneralJobStatusBA _generalJobStatusBA = null;
        IAccountSessionMasterBA _accountSessionMasterBA = null;
        IGeneralTaskReportingDetailsBA _generalTaskReportingDetailsBA;
        IUserMasterBA _userMasterBA = null;
        IAccountBalancesheetMasterBA _accountBalancesheetMasterBA = null;
        IAccountTransactionTypeMasterBA _accountTransactionTypeMasterBA = null;
        IAccountMasterBA _accountMasterBA = null;
        IGeneralTaxGroupMasterBA _generalTaxGroupMasterBA = null;
        IDashboardBA _DashboardBA = null;
        IAdminRoleMenuDetailsBA _adminRoleMenuDetailsBA = null;
        IBankMasterBA _BankMasterBA = null;
        IEmpEmployeeMasterBA _EmpEmployeeMasterBA = null;
        ILeaveRuleMasterBA _ILeaveRuleMasterBA = null;
        ILeaveMasterBA _leaveMasterBA = null;
        EmpEmployeeMasterBA _empEmployeeMasterBA = null;
        GeneralHolidaysBA _GeneralHolidaysBA = null;
        ILeaveSessionBA _leaveSessionBA = null;
        LeaveAttendanceSpanLockBA _leaveAttendanceSpanLockBA = null;
        IGeneralTaskModelBA _generalTaskModelBA = null;

        public BaseController()
        {
            _adminRoleApplicableDetailsBA = new AdminRoleApplicableDetailsBA();
            _organisationStudyCentreMasterBA = new OrganisationStudyCentreMasterBA();
            _organisationDepartmentMasterBA = new OrganisationDepartmentMasterBA();
            _adminSnPostsBA = new AdminSnPostsBA();
            _empDesignationMasterBA = new EmpDesignationMasterBA();
            _generalRegionMasterBA = new GeneralRegionMasterBA();
            _generalCountryMasterBA = new GeneralCountryMasterBA();
            _generalEducationTypeMasterBA = new GeneralEducationTypeMasterBA();
            _generalCityMasterBA = new GeneralCityMasterBA();
            _organisationMasterBA = new OrganisationMasterBA();
            _generalUnitMasterBA = new GeneralUnitMasterBA();
            _generalLocationMasterBA = new GeneralLocationMasterBA();
            _userModuleMasterBA = new UserModuleMasterBA();
            _userMainMenuMasterBA = new UserMainMenuMasterBA();
            _generalTitleMasterBA = new GeneralTitleMasterBA();
            _generalNationalityMasterBA = new GeneralNationalityMasterBA();
            _employeeShiftMasterBA = new EmployeeShiftMasterBA();
            _generalJobProfileBA = new GeneralJobProfileBA();
            _generalJobStatusBA = new GeneralJobStatusBA();
            _accountSessionMasterBA = new AccountSessionMasterBA();
            _userMasterBA = new UserMasterBA();
            _accountBalancesheetMasterBA = new AccountBalancesheetMasterBA();
            _accountTransactionTypeMasterBA = new AccountTransactionTypeMasterBA();
            _accountMasterBA = new AccountMasterBA();
            _generalTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
            _DashboardBA = new DashboardBA();
            _adminRoleMenuDetailsBA = new AdminRoleMenuDetailsBA();
            _BankMasterBA = new BankMasterBA();
            _EmpEmployeeMasterBA = new EmpEmployeeMasterBA();
            _ILeaveRuleMasterBA = new LeaveRuleMasterBA();
            _leaveMasterBA = new LeaveMasterBA();
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
            _GeneralHolidaysBA = new GeneralHolidaysBA();
            _leaveSessionBA = new LeaveSessionBA();
            _leaveAttendanceSpanLockBA = new LeaveAttendanceSpanLockBA();
            _generalTaskReportingDetailsBA = new GeneralTaskReportingDetailsBA();
        }

        public String RedirectController
        {
            get;
            set;
        }
        public String RedirectAction
        {
            get;
            set;
        }

        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //UrlHelper helper = new UrlHelper(filterContext.RequestContext);
            //RedirectController = filterContext.RouteData.Values["controller"].ToString();
            //RedirectAction = filterContext.RouteData.Values["action"].ToString();
            //if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    RedirectController = "Account";
            //    RedirectAction = "Login";
            //    filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //}
            //else if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (_acceptedRoles != null)
            //    {
            //        string roleID = ((System.Web.Security.FormsIdentity)(filterContext.HttpContext.User.Identity)).Ticket.UserData.Trim();
            //        if (!String.IsNullOrEmpty(roleID) && Convert.ToInt32(roleID) > 0)
            //        {
            //            RoleEnum roleEnum = (RoleEnum)Convert.ToInt32(roleID);
            //            if (!_acceptedRoles.Contains(roleEnum))
            //            {
            //                RedirectController = "Account";
            //                RedirectAction = "UnAuthorizeAccess";
            //                filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //            }
            //        }
            //        else
            //        {
            //            RedirectController = "Account";
            //            RedirectAction = "Login";
            //            filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //        }
            //    }
            //    else
            //    {
            //        RedirectController = "Account";
            //        RedirectAction = "UnAuthorizeAccess";
            //        filterContext.Result = new RedirectResult(helper.Action(this.RedirectAction, this.RedirectController));
            //    }
            //}
        }

        protected LeaveRuleMaster GetLeaveDetailsByLeaveMasterID(int LeaveMasterID, int EmployeeID, int LeaveSessionID)
        {
            ILeaveRuleMasterViewModel model = new LeaveRuleMasterViewModel();
            model.LeaveRuleMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            model.LeaveRuleMasterDTO.LeaveMasterID = LeaveMasterID;
            model.LeaveRuleMasterDTO.EmployeeID = EmployeeID;
            model.LeaveRuleMasterDTO.LeaveSessionID = LeaveSessionID;
            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.GetLeaveDetails(model.LeaveRuleMasterDTO);
            return response.Entity;
        }

        public ActionResult GetLeaveSessionByCentreCode(string CentreCode)
        {
            LeaveRuleApplicableDetailsViewModel model = new LeaveRuleApplicableDetailsViewModel();
            string[] splited;
            splited = CentreCode.Split(':');
            //model.SelectedCentreName = splited[1];
            CentreCode = splited[0];
            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var session = GetListLeaveSession(CentreCode);
            var result = (from s in session
                          select new
                          {
                              id = s.LeaveSessionID,
                              name = s.LeaveSessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<LeaveMaster> GetListLeaveMaster()
        {
            LeaveMasterSearchRequest searchRequest = new LeaveMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
            IBaseEntityCollectionResponse<LeaveMaster> baseEntityCollectionResponse = _leaveMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveMaster;
        }

        protected List<LeaveAttendanceSpanLock> GetListLeaveAttendanceSpanLock(string CentreCode)
        {
            LeaveAttendanceSpanLockSearchRequest searchRequest = new LeaveAttendanceSpanLockSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<LeaveAttendanceSpanLock> listLeaveAttendanceSpanLock = new List<LeaveAttendanceSpanLock>();
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> baseEntityCollectionResponse = _leaveAttendanceSpanLockBA.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAttendanceSpanLock = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveAttendanceSpanLock;
        }


        protected List<EmpEmployeeMaster> GetEmployeeCentrewiseSearchList(string SearchWord, string CentreCode)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.SearchWord = SearchWord;
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeCentrewiseSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null)
            {
                base.OnException(filterContext);
                if (filterContext.Exception == null)
                {
                    ExceptionManager.ExceptionManager exceptionManager = new ExceptionManager.ExceptionManager();
                    string controller = filterContext.RouteData.Values["controller"].ToString();
                    string action = filterContext.RouteData.Values["action"].ToString();
                    string loggerName = string.Format("{0}Controller.{1}", controller, action);
                    exceptionManager.Error(loggerName, filterContext.Exception);
                }
                else
                {
                    filterContext.Exception.Data.Add("IsViewable", true);
                    filterContext.ExceptionHandled = true;
                    HandleErrorInfo handleErrorInfo = new HandleErrorInfo(filterContext.Exception, "Error", "Index");
                    Session["Source"] = filterContext.Exception.Source;
                    Session["TargetSite"] = filterContext.Exception.TargetSite;
                    Session["ErrorInfoMessage"] = filterContext.Exception.Message;
                    Session["StackTrace"] = filterContext.Exception.StackTrace;
                    this.View("Error", handleErrorInfo).ExecuteResult(this.ControllerContext);
                }
            }
        }

        protected List<GeneralHolidays> GetListGeneralWeeklyOffAndHoliday(int EmployeeID)
        {
            GeneralHolidaysSearchRequest searchRequest = new GeneralHolidaysSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
            List<GeneralHolidays> listGeneralHolidays = new List<GeneralHolidays>();
            IBaseEntityCollectionResponse<GeneralHolidays> baseEntityCollectionResponse = _GeneralHolidaysBA.GetHolidayAndWeeklyOffDayByEmployeeID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralHolidays = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralHolidays;
        }

        protected List<GeneralHolidays> GetListCheckInCheckOutTime(LeaveCompensatoryWorkDay item)
        {
            GeneralHolidaysSearchRequest searchRequest = new GeneralHolidaysSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = item.EmployeeID;
            searchRequest.Date = item.WorkingDate;

            List<GeneralHolidays> listGeneralHolidays = new List<GeneralHolidays>();
            IBaseEntityCollectionResponse<GeneralHolidays> baseEntityCollectionResponse = _GeneralHolidaysBA.GetListCheckInCheckOutTime(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralHolidays = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralHolidays;
        }



        protected List<LeaveSession> GetListLeaveSession(string CentreCode)
        {
            LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SortBy = "LeaveSessionName";                        // parameters for SelectAll procedures under normal condition
            searchRequest.StartRow = 0;
            searchRequest.EndRow = 100;
            searchRequest.SearchBy = string.Empty;
            searchRequest.SortDirection = "asc";
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<LeaveSession> listLeaveSession = new List<LeaveSession>();
            IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _leaveSessionBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveSession;
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName = null;

            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = Request.Cookies["_culture"];
            if (cultureCookie != null)
                cultureName = cultureCookie.Value;
            else
                cultureName = Request.UserLanguages != null && Request.UserLanguages.Length > 0 ? Request.UserLanguages[0] : null; // obtain it from HTTP header AcceptLanguages

            // Validate culture name
            cultureName = CultureHelper.GetImplementedCulture(cultureName); // This is safe


            // Modify current thread's cultures            
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cultureName);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;


            return base.BeginExecuteCore(callback, state);
        }

        protected string CheckError(int errorCode, ActionModeEnum actionMode)
        {

            string errorMessage = string.Empty;
            string colorCode = string.Empty;
            string mode = string.Empty;
            if (actionMode == ActionModeEnum.Insert)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists;// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.LimitExceeds:
                        errorMessage = "Cannot create record as limit exceeds!";// "Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordCreatedSuccessfully;// "Record created successfully";
                        colorCode = "success";
                        mode = "0";
                        break;
                    case (Int32)ErrorEnum.WorkFlowNotDefined:
                        errorMessage = Resources.Message_WorkFlowNotDefined;// "Work Flow Not Defined ";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotCreatedSuccessfully;// "Record not created successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Update)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordAlreadyExists; ;//"Record already exists";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordUpdatedSuccessfully;// "Record updated successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotUpdatedSuccessfully;// "Record not updated successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Delete)
            {
                mode = string.Empty;
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordDeletedSuccessfully;// "Record deleted successfully";
                        colorCode = "success";
                        break;
                    case (Int32)ErrorEnum.DependantEntry:
                        errorMessage = Resources.Message_RecordDependantEntry;// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotDeletedSuccessfully;// "Record not deleted successfully";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.Sync)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_SyncProcessDoneSuccessfully;// "Sync process completed successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = Resources.Message_SyncProcessAborted;// "Sync process aborted due to unexpected error";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.FiredJob)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_JobFiredSuccessfully;// "Job Fired successfully";
                        colorCode = "success";
                        break;
                    default:
                        errorMessage = Resources.Message_UnexpectedErrorOccured;// "unexpected error Occured.";
                        colorCode = "danger";
                        break;
                }
            }
            else if (actionMode == ActionModeEnum.InActive)
            {
                switch (errorCode)
                {
                    case (Int32)ErrorEnum.DuplicateEntry:
                        errorMessage = Resources.Message_RecordInaciveDependantEntry;// "Record not deleted successfully, Because it is used in another form.";
                        colorCode = "warning";
                        mode = string.Empty;
                        break;
                    case (Int32)ErrorEnum.AllOk:
                        errorMessage = Resources.Message_RecordInactiveSuccessfully;// "Record inactive successfully";
                        colorCode = "success";
                        mode = "1";
                        break;
                    default:
                        errorMessage = Resources.Message_RecordNotInactiveSuccessfully;// "Record not deleted successfully";
                        colorCode = "danger";
                        mode = string.Empty;
                        break;
                }
            }
            string[] arrayList = { errorMessage, colorCode, mode };
            return string.Join(",", arrayList);
        }

        [HttpGet]
        public ActionResult ErrorMessageForJS(string keyName)
        {
            try
            {
                string message = Resources.ResourceManager.GetString(keyName);
                string errorMessageWithCode = message;
                return Json(errorMessageWithCode, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public ActionResult GeneralMessageForJS(string keyName)
        {
            try
            {
                string message = Resources.ResourceManager.GetString(keyName);
                return Json(message, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalBaseTableDisplayFieldList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalBaseTableDisplayFieldList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalParamPrimaryKeyList(string tableName)
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TableName = tableName;
            List<GeneralTaskReportingDetails> taskApprovalPrimaryKeyList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalParamPrimaryKeyList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalPrimaryKeyList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalPrimaryKeyList;
        }

        protected List<GeneralTaskModel> GetMenuCodeAndMenuLink(int flag)
        {
            GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StatusFlag = flag;
            List<GeneralTaskModel> list = new List<GeneralTaskModel>();
            IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _generalTaskModelBA.GetMenuCodeAndMenuLink(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    list = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return list;
        }

        protected List<GeneralTaskReportingDetails> GetTaskApprovalBasedTableList()
        {
            GeneralTaskReportingDetailsSearchRequest searchRequest = new GeneralTaskReportingDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaskReportingDetails> taskApprovalBasedTableList = new List<GeneralTaskReportingDetails>();
            IBaseEntityCollectionResponse<GeneralTaskReportingDetails> baseEntityCollectionResponse = _generalTaskReportingDetailsBA.GetTaskApprovalBasedTableList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    taskApprovalBasedTableList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return taskApprovalBasedTableList;
        }

        protected static DateTime ConvertFromMiliSecondsToDate(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        // Encode function
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decode function
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        [HttpGet]
        public int CheckSessionStatus()
        {
            int _sessionStatus;
            if (Session["UserType"] != null)
            {
                _sessionStatus = 1;
            }
            else
            {
                _sessionStatus = 0;
            }
            return _sessionStatus; //return _sessionStatus;
        }

        //Convert numeric Value in words
        public static String ones(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }
        public static String tens(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = tens(Number.Substring(0, 1) + "0") + " " + ones(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }
        public static String ConvertWholeNumber(String Number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX   
                bool isDone = false;//test if already translated   
                double dblAmt = (Convert.ToDouble(Number));
                //if ((dblAmt > 0) && !Number.StartsWith("0"))   
                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric   
                    beginsZero = Number.StartsWith("0");

                    int numDigits = Number.Length;
                    int pos = 0;//store digit grouping   
                    String place = "";//digit grouping name:hundres,thousand,etc...   
                    switch (numDigits)
                    {
                        case 1://ones' range   

                            word = ones(Number);
                            isDone = true;
                            break;
                        case 2://tens' range   
                            word = tens(Number);
                            isDone = true;
                            break;
                        case 3://hundreds' range   
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4://thousands' range   
                        case 5:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 6:
                        case 7:
                            pos = (numDigits % 6) + 1;
                            place = " Lakh ";
                            break;
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10://Billions's range   
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        //add extra case options for anything above Billion...   
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)   
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0" && Convert.ToInt32(Number.Substring(0, pos)) != 0)
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }

                        if (beginsZero) word = " and " + word.Trim();
                        //if (beginsZero) word = " and ";
                    }
                    //ignore digit grouping names   
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        public static String ConvertToWords(String numb)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = "Only";
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = "and";// just to separate whole numbers from points/cents   
                        endStr = "Paisa " + endStr;//Cents   
                        pointStr = ConvertDecimals(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch { }
            return val;
        }
        public static String ConvertDecimals(String number)
        {
            String cd = "", digit = "", engOne = "";
            for (int i = 0; i < number.Length; i++)
            {
                digit = number[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "Zero";
                }
                else
                {
                    engOne = ones(digit);
                }
                cd += " " + engOne;
            }
            return cd;
        }

        public string ConvertNumbertoWords(long number)
        {
            if (number == 0) return "Zero";
            if (number < 0) return "minus " + ConvertNumbertoWords(Math.Abs(number));
            string words = "";
            if ((number / 1000000) > 0)
            {
                words += ConvertNumbertoWords(number / 100000) + " Lakh ";
                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                words += ConvertNumbertoWords(number / 1000) + " Thousand ";
                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                words += ConvertNumbertoWords(number / 100) + " Hundred ";
                number %= 100;
            }
            //if ((number / 10) > 0)  
            //{  
            // words += ConvertNumbertoWords(number / 10) + " RUPEES ";  
            // number %= 10;  
            //}  
            if (number > 0)
            {
                if (words != "") words += "and ";
                var unitsMap = new[]
                {
                    "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
                };
                var tensMap = new[]
                {
                    "Zero", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"
                };
                if (number < 20) words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0) words += " " + unitsMap[number % 10];
                }
            }
            return words;
        }

        protected List<AdminRoleApplicableDetails> GetRoleListByUserID()
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonId = Convert.ToInt32(Session["PersonId"]);
            List<AdminRoleApplicableDetails> RoleList = new List<AdminRoleApplicableDetails>();
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetRoleListForLoginUserIDBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    RoleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return RoleList;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByAcademicManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForAcademicManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByHRManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForHRManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<OrganisationStudyCentreMaster> GetListOrgStudyCentreMaster()
        {

            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterBA.GetOrganisationStudyCentreList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentre(int AdminRoleMasterID, int EmployeeID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            searchRequest.EmployeeID = EmployeeID; // Convert.ToInt32(Session["PersonID"]);
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByPurchaseManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForPurchaseManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByStoreManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForStoreManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreBySalesManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForSalesManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }


        protected List<OrganisationDepartmentMaster> GetListOrganisationDepartmentMaster(string CentreCode)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            //searchRequest.SearchType = 1;
            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterBA.GetByCentreCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected List<AdminSnPosts> GetListAdminSnPosts(string SelectedCentreCodeforRoleMaster, string SelectedDepartmentIDforRoleMaster)
        {
            AdminSnPostsSearchRequest searchRequest = new AdminSnPostsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = SelectedCentreCodeforRoleMaster;
            string[] splitedDepartmentID = SelectedDepartmentIDforRoleMaster.Split(':');
            searchRequest.DepartmentID = Convert.ToInt32(splitedDepartmentID[0]);

            List<AdminSnPosts> listAdminSnPosts = new List<AdminSnPosts>();
            IBaseEntityCollectionResponse<AdminSnPosts> baseEntityCollectionResponse = _adminSnPostsBA.GetBySearchCentreCodeAndDepartmentIDForSPD(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminSnPosts = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdminSnPosts;
        }

        protected List<EmpDesignationMaster> GetListEmpDesignationMaster()
        {
            EmpDesignationMasterSearchRequest searchRequest = new EmpDesignationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmpDesignationMaster> listEmpDesignationMaster = new List<EmpDesignationMaster>();
            IBaseEntityCollectionResponse<EmpDesignationMaster> baseEntityCollectionResponse = _empDesignationMasterBA.GetBySelectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpDesignationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpDesignationMaster;
        }

        protected List<GeneralRegionMaster> GetListGeneralRegionMaster(string SelectedCountryID)
        {
            GeneralRegionMasterSearchRequest searchRequest = new GeneralRegionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CountryID = !string.IsNullOrEmpty(SelectedCountryID) ? Convert.ToInt32(SelectedCountryID) : 0;
            List<GeneralRegionMaster> listGeneralRegionMaster = new List<GeneralRegionMaster>();
            IBaseEntityCollectionResponse<GeneralRegionMaster> baseEntityCollectionResponse = _generalRegionMasterBA.GetByCountryID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRegionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralRegionMaster;
        }

        protected List<GeneralCountryMaster> GetListGeneralCountryMaster()
        {
            GeneralCountryMasterSearchRequest searchRequest = new GeneralCountryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralCountryMaster> listGeneralCountryMaster = new List<GeneralCountryMaster>();
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollectionResponse = _generalCountryMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCountryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCountryMaster;
        }

        protected List<GeneralEducationTypeMaster> GetListGeneralEducationTypeMaster()
        {
            GeneralEducationTypeMasterSearchRequest searchRequest = new GeneralEducationTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralEducationTypeMaster> listGeneralEducationTypeMaster = new List<GeneralEducationTypeMaster>();
            IBaseEntityCollectionResponse<GeneralEducationTypeMaster> baseEntityCollectionResponse = _generalEducationTypeMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralEducationTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralEducationTypeMaster;
        }

        protected List<GeneralCityMaster> GetListGeneralCityMaster(string RegionID)
        {
            GeneralCityMasterSearchRequest searchRequest = new GeneralCityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            int SelectedRegionID = 0;
            bool isValid = Int32.TryParse(RegionID, out SelectedRegionID);
            searchRequest.RegionID = SelectedRegionID;
            //searchRequest.SearchType = 1;
            List<GeneralCityMaster> listGeneralCityMaster = new List<GeneralCityMaster>();
            IBaseEntityCollectionResponse<GeneralCityMaster> baseEntityCollectionResponse = _generalCityMasterBA.GetByRegionID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralCityMaster;
        }

        protected List<OrganisationMaster> GetListOrganisationMaster()
        {
            OrganisationMasterSearchRequest searchRequest = new OrganisationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationMaster> listOrganisationMaster = new List<OrganisationMaster>();
            IBaseEntityCollectionResponse<OrganisationMaster> baseEntityCollectionResponse = _organisationMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationMaster;
        }

        protected List<OrganisationStudyCentreMaster> GetListStudyCentreHORO()
        {
            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterBA.GetListHORO(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<GeneralUnitMaster> GetListGeneralUnitMaster()
        {
            GeneralUnitMasterSearchRequest searchRequest = new GeneralUnitMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralUnitMaster> listGeneralUnitMaster = new List<GeneralUnitMaster>();
            IBaseEntityCollectionResponse<GeneralUnitMaster> baseEntityCollectionResponse = _generalUnitMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralUnitMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralUnitMaster;
        }

        protected List<GeneralLocationMaster> GetListGeneralLocationMaster()
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralLocationMaster> listGeneralLocationMaster = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLocationMaster;
        }

        protected List<UserModuleMaster> GetModuleListByUserID(int AdminRoleMasterID)
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            List<UserModuleMaster> ModuleList = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterBA.GetModuleListForLoginUserIDByRoleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            //  TempData["ModuleList"] = ModuleList;
            return ModuleList;
        }

        protected List<UserModuleMaster> GetModuleListForAdmin()
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<UserModuleMaster> ModuleList = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterBA.GetModuleListForAdmin(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            // TempData["ModuleList"] = ModuleList;
            return ModuleList;
        }

        [HttpGet]
        public List<UserMainMenuMasterViewModel> BuildMenu(string ModuleCode, string AdminRoleMasterID)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();

            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = 0;
            searchRequest.ModuleCode = ModuleCode;
            searchRequest.RoleId = Convert.ToInt32(AdminRoleMasterID);
            searchRequest.UserId = Convert.ToInt32(Session["UserId"]);
            // ViewData["path"] = path;


            List<UserMainMenuMasterViewModel> mmList = new List<UserMainMenuMasterViewModel>();
            List<UserMainMenuMaster> listM = new List<UserMainMenuMaster>();
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterBA.GetByModuleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listM = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (UserMainMenuMaster item in listM)
                    {
                        UserMainMenuMasterViewModel UserMainMenuMasterViewModel = new UserMainMenuMasterViewModel();
                        UserMainMenuMasterViewModel.UserMainMenuMasterDTO = item;

                        mmList.Add(UserMainMenuMasterViewModel);
                    }
                }
                else if (baseEntityCollectionResponse.Message != null && baseEntityCollectionResponse.Message.Count > 0)
                {
                    IMessageDTO errordto = baseEntityCollectionResponse.Message.FirstOrDefault();
                }
            }

            return mmList;
        }

        protected List<GeneralTitleMaster> GetListGeneralTitleMaster()
        {
            GeneralTitleMasterSearchRequest searchRequest = new GeneralTitleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralTitleMaster> listGeneralTitleMaster = new List<GeneralTitleMaster>();
            IBaseEntityCollectionResponse<GeneralTitleMaster> baseEntityCollectionResponse = _generalTitleMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTitleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTitleMaster;
        }

        protected List<GeneralNationalityMaster> GetListGeneralNationalityMaster()
        {
            GeneralNationalityMasterSearchRequest searchRequest = new GeneralNationalityMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralNationalityMaster> listGeneralNationalityMaster = new List<GeneralNationalityMaster>();
            IBaseEntityCollectionResponse<GeneralNationalityMaster> baseEntityCollectionResponse = _generalNationalityMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralNationalityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralNationalityMaster;
        }

        protected List<EmployeeShiftMaster> GetListEmployeeShiftMaster(string CentreCode)
        {
            EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<EmployeeShiftMaster> listEmployeeShiftMaster = new List<EmployeeShiftMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _employeeShiftMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeShiftMaster;
        }

        protected List<GeneralJobProfile> GetListGeneralJobProfile()
        {
            GeneralJobProfileSearchRequest searchRequest = new GeneralJobProfileSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralJobProfile> listGeneralJobProfile = new List<GeneralJobProfile>();
            IBaseEntityCollectionResponse<GeneralJobProfile> baseEntityCollectionResponse = _generalJobProfileBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobProfile = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralJobProfile;
        }

        protected List<GeneralJobStatus> GetListGeneralJobStatus()
        {
            GeneralJobStatusSearchRequest searchRequest = new GeneralJobStatusSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralJobStatus> listGeneralJobStatus = new List<GeneralJobStatus>();
            IBaseEntityCollectionResponse<GeneralJobStatus> baseEntityCollectionResponse = _generalJobStatusBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralJobStatus = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralJobStatus;
        }

        protected AccountSessionMaster GetCurrentAccountSession()
        {
            AccountSessionMasterViewModel model = new AccountSessionMasterViewModel();
            model.AccountSessionMasterDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]); ;
            IBaseEntityResponse<AccountSessionMaster> response = _accountSessionMasterBA.GetCurrentAccountSession(model.AccountSessionMasterDTO);
            return response.Entity;
        }

        protected List<UserMaster> GetUserTypeMaster()
        {
            UserMasterSearchRequest searchRequest = new UserMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<UserMaster> listUserMaster = new List<UserMaster>();
            IBaseEntityCollectionResponse<UserMaster> baseEntityCollectionResponse = _userMasterBA.GetUserType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserMaster;
        }

        protected List<AdminRoleApplicableDetails> GetAdminRoleApplicableCentreByFinanceManager(int AdminRoleMasterID)
        {

            AdminRoleApplicableDetailsSearchRequest searchRequest = new AdminRoleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = new List<AdminRoleApplicableDetails>();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            IBaseEntityCollectionResponse<AdminRoleApplicableDetails> baseEntityCollectionResponse = _adminRoleApplicableDetailsBA.GetStudyCentreListForFinanceManagerByAdminRoleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listAdminRoleApplicableDetails;
        }

        protected List<AccountBalancesheetMaster> GetListOfAccountBalancesheetMasterRoleWise(int RoleID)
        {
            AccountBalancesheetMasterSearchRequest searchRequest = new AccountBalancesheetMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.RoleId = RoleID;
            List<AccountBalancesheetMaster> listAccountBalancesheetMaster = new List<AccountBalancesheetMaster>();
            IBaseEntityCollectionResponse<AccountBalancesheetMaster> baseEntityCollectionResponse = _accountBalancesheetMasterBA.GetBalancesheetForAccountMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountBalancesheetMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountBalancesheetMaster;
        }

        public ActionResult UpdateBalancesheetSession(string selectedBalsheetID, string selectedBalsheetName)
        {
            Session["BalancesheetName"] = selectedBalsheetName;
            Session["BalancesheetID"] = selectedBalsheetID;
            return null;
        }

        public ActionResult AccountHome()
        {
            if (Session["UserType"] != null)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        protected List<AccountTransactionTypeMaster> GetListOfAccountTransactionType()
        {
            AccountTransactionTypeMasterSearchRequest searchRequest = new AccountTransactionTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountTransactionTypeMaster> listAccountTransactionTypeMaster = new List<AccountTransactionTypeMaster>();
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> baseEntityCollectionResponse = _accountTransactionTypeMasterBA.GetTransactionTypeSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountTransactionTypeMaster;
        }

        protected List<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(string centreCode, int accBalsheetMstID)
        {
            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = centreCode;
            searchRequest.AccBalsheetMstID = accBalsheetMstID;
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterBA.GetStudyCentreDetailsForReports(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationStudyCentreMaster;
        }

        protected List<AccountSessionMaster> GetAllAccountSession()
        {
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountSessionMaster> listAccountSessionMaster = new List<AccountSessionMaster>();
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _accountSessionMasterBA.GetAccountSessionList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountSessionMaster;
        }
        protected List<AccountSessionMaster> GetAccountSessionMasterSelectList()
        {
            AccountSessionMasterSearchRequest searchRequest = new AccountSessionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AccountSessionMaster> listAccountSessionMaster = new List<AccountSessionMaster>();
            IBaseEntityCollectionResponse<AccountSessionMaster> baseEntityCollectionResponse = _accountSessionMasterBA.GetAccountSessionMasterSelectList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountSessionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountSessionMaster;
        }

        protected List<AccountMaster> GetAccountList(string CashBankFalg, string PersonType)
        {
            AccountMasterSearchRequest searchRequest = new AccountMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CashBankFlag = CashBankFalg;
            searchRequest.PersonType = PersonType;
            List<AccountMaster> listAccountMaster = new List<AccountMaster>();
            IBaseEntityCollectionResponse<AccountMaster> baseEntityCollectionResponse = _accountMasterBA.GetAccountListForReport(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountMaster;
        }

        protected List<OrganisationDepartmentMaster> GetListOrganisationMasterCentreAndRoleWise(string CentreCode, string EntityLevel, int AdminRoleID)
        {

            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.EntityLevel = EntityLevel;
            searchRequest.AdminRoleMasterID = AdminRoleID;
            searchRequest.EmployeeID = Convert.ToInt32(Session["PersonID"]);

            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterBA.GetDepartmentListCentreAndRoleWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

        protected static Cell InsertCellInWorksheet(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {
            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;

            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                Cell newCell = new Cell() { CellReference = cellReference };
                //row.InsertBefore(newCell, refCell);

                row.Append(newCell);
                worksheet.Save();
                return newCell;
            }
        }

        protected static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        protected List<GeneralTaxGroupMaster> GetGeneralTaxGroupMaster()
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTaxGroupMaster> listGeneralTaxGroupMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _generalTaxGroupMasterBA.GetGeneralTaxGroupMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTaxGroupMaster;
        }

        //protected List<EmployeeShiftMaster> GetListEmployeeShiftMasterForContract()
        //{
        //    EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        //    List<EmployeeShiftMaster> listEmployeeShiftMaster = new List<EmployeeShiftMaster>();
        //    IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _employeeShiftMasterBA.GetBySelectList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listEmployeeShiftMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listEmployeeShiftMaster;
        //}

        [NonAction]
        protected List<GeneralTaxGroupMaster> GetTaxSummaryForDisplay(bool IsOtherState, int FromMasterID, string FromDetailTable)
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsOtherState = IsOtherState;
            searchRequest.FromMasterID = FromMasterID;
            searchRequest.FromDetailTable = FromDetailTable;

            List<GeneralTaxGroupMaster> listGeneralTaxMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _generalTaxGroupMasterBA.GetTaxSummaryForDisplay(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.TaxName).ToList();
                }
            }
            return listGeneralTaxMaster;
        }

        protected List<Dashboard> GetListDashboardRoleCode()
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<Dashboard> listAdmin = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetDashboardRoleCodeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdmin = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAdmin;
        }

        protected bool CheckMenuApplicableOrNot(string MenuCode)
        {
            AdminRoleMenuDetailsViewModel model = new AdminRoleMenuDetailsViewModel();

            int AdminRoleMasterID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
            }
            else
            {
                AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
            }

            model.AdminRoleMenuDetailsDTO = new AdminRoleMenuDetails();
            model.AdminRoleMenuDetailsDTO.AdminRoleMasterID = Convert.ToInt32(AdminRoleMasterID);
            model.AdminRoleMenuDetailsDTO.MenuCode = MenuCode;
            model.AdminRoleMenuDetailsDTO.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            IBaseEntityResponse<AdminRoleMenuDetails> response = _adminRoleMenuDetailsBA.CheckMenuApplicableOrNotByAdminRoleID(model.AdminRoleMenuDetailsDTO);

            if (response != null && response.Entity != null)
            {
                model.AdminRoleMenuDetailsDTO.Status = response.Entity.Status;
            }

            return model.AdminRoleMenuDetailsDTO.Status;
        }

        protected List<BankMaster> GetListBankMaster()
        {
            BankMasterSearchRequest searchRequest = new BankMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<BankMaster> listBankMaster = new List<BankMaster>();
            IBaseEntityCollectionResponse<BankMaster> baseEntityCollectionResponse = _BankMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBankMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listBankMaster;
        }
        //*********************EmployeeSrviveEngg*********************//
        protected List<EmpEmployeeMaster> GetEmpEmployeeMasterService()
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<EmpEmployeeMaster> listEmpEmployeeMaster = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _EmpEmployeeMasterBA.GetEmpEmployeeMasterServiceList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmpEmployeeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmpEmployeeMaster;
        }

        public static bool ValidateServerCertificate(
        object sender,
        Org.BouncyCastle.X509.X509Certificate certificate,
        X509Chain chain,
        SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        

        //For Push Notification
        protected object SendGCMNotification(string DeviceToken)
        {
            string postDataContentType = "application/json";
            string APIKey = "AAAAjvMWWfg:APA91bGWrUM8PtbO5wWe6AJoeGwQ6MqauMXtxEAKuuqYfAHE7dAxed_AAWFx5myZxOzn-csAsn0PFK_W-TmcNqSwUD5tKWQbVwY45H6t8mlTIlpzJmRSQUUm03Ozluoi2k2H7n-I0lxw";
          
            string message = "New Complaint has been registered";
            string tickerText = "example test GCM";
            string contentTitle = "content title GCM";
            string postData =
            "{ \"registration_ids\": [ \"" + DeviceToken + "\" ], " +
              "\"data\": {\"tickerText\":\"" + tickerText + "\", " +
                         "\"contentTitle\":\"" + contentTitle + "\", " +
                         "\"message\": \"" + message + "\"}}";


            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; };

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(HttpRequestHeader.Authorization, String.Format("key={0}",APIKey));
            Request.UseDefaultCredentials = true;

            Request.ContentLength = byteArray.Length;

            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //
            //  SEND MESSAGE
            try
            {

                WebResponse Response = Request.GetResponse();

                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {
            }
            return "error";
        }

        public Dictionary<string,Double> getLatLongFromAddress(string address)
        {
            /* var locationService = new GoogleLocationService();
             Thread.Sleep(1000);
             var point = locationService.GetLatLongFromAddress(address);

             var latitude = point.Latitude;
             var longitude = point.Longitude;

             return new Dictionary<string, Double>
             {
                 { "Latitude",latitude },
                 { "Longitude",longitude }
             };*/


            string urlAddress = "http://maps.googleapis.com/maps/api/geocode/xml?address=" + HttpUtility.UrlEncode(address) + "&sensor=false";
            string latitude = "",longitude = "";
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(urlAddress);
                XmlNodeList objXmlNodeList = objXmlDocument.SelectNodes("/GeocodeResponse/result/geometry/location");
                foreach (XmlNode objXmlNode in objXmlNodeList)
                {
                    // GET LONGITUDE 
                    latitude = objXmlNode.ChildNodes.Item(0).InnerText;

                    // GET LATITUDE 
                    longitude = objXmlNode.ChildNodes.Item(1).InnerText;
                }
                return new Dictionary<string, Double>
                {
                     { "Latitude",Convert.ToDouble(latitude) },
                     { "Longitude",Convert.ToDouble(longitude)}
                };
            }
            catch(Exception e)
            {
                // Process an error action here if needed  
            }

            return new Dictionary<string, Double>
                {
                     { "Latitude",Convert.ToDouble(0) },
                     { "Longitude",Convert.ToDouble(0)}
                };

        }

        public Double getDistanceBetweenTwoLatLong(Dictionary<string, Double> latlongs)
        {
            var DestinationLocation = new GeoCoordinate(latlongs["DestinationLatitude"], latlongs["DestinationLongitude"]);
            var CurrentLocation = new GeoCoordinate(latlongs["CurrentLatitude"], latlongs["CurrentLongitude"]);

            return DestinationLocation.GetDistanceTo(CurrentLocation)/1000;
        }

        protected List<OrganisationDepartmentMaster> GetOrganisationDepartmentList()
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listOrganisationDepartmentMaster;
        }
    }
}
