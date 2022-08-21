using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Common;
using AERP.DataProvider;
using System.Configuration;
using AERP.Web.UI;
using AERP.Web.UI.HtmlHelperExtensions;
using AERP.Web.UI.Models;

namespace AERP.Web.UI.Controllers
{
    
    public class TaskNotificationController : BaseController
    {
        ITaskNotificationBA _TaskNotificationBA = null;
        IDashboardBA _DashboardBA = null;
        IGeneralTaskReportingDetailsBA _generalTaskReportingDetailsBA = null;
        AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public TaskNotificationController()
        {
            _TaskNotificationBA = new TaskNotificationBA();
            _generalTaskReportingDetailsBA = new GeneralTaskReportingDetailsBA();
            _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();
            _DashboardBA = new DashboardBA();
        }

        #region ------------------Controller Methods------------------

        //public ActionResult GetNotificationCount()
        //{
        //    MessagesRepository _messageRepository = new MessagesRepository();
        //    return Json(_messageRepository.GetAllMessages(), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Index()
        {
            TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() == "E")
                {
                    _adminRoleApplicableDetailsBaseViewModel.RoleList = GetRoleListByUserID();
                    if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count > 0)
                    {

                        //Create selectlistitem list 
                        List<SelectListItem> items = new List<SelectListItem>();
                        SelectListItem s = null;

                        //add the empty selection
                        s = new SelectListItem();
                        //s.Value = "";
                        //s.Text = "";
                        //items.Add(s);
                        foreach (var t in _adminRoleApplicableDetailsBaseViewModel.RoleList)
                        {
                            s = new SelectListItem();
                            s.Text = t.AdminRoleMasterID.ToString();
                            s.Value = t.AdminRoleCode.ToString();
                            items.Add(s);

                            if (t.RoleType == "Regular")
                            {
                                //DefaultRoleCode = t.AdminRoleCode;
                                Session["DefaultRoleID"] = t.AdminRoleMasterID;
                            }

                        }

                        ViewData["UserType"] = "E";

                    }

                    _TaskNotificationViewModel.TaskNotificationContentList = GetDashboardContentListByAdminRoleID(Convert.ToInt32(Session["DefaultRoleID"]));
                    if (_TaskNotificationViewModel.TaskNotificationContentList.Count > 0)
                    {
                        return View("/Views/TaskNotification/TaskNotificationIndex.cshtml", _TaskNotificationViewModel);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }

               
            }
            else
            {

                //return View("Login","Account");
                return RedirectToAction("Login", "Account");
                // return PartialView("Login");
            }
        }


        public ActionResult NotificationList(string actionMode, string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _TaskNotificationViewModel.TaskCodeList = GetTaskCodeList(_TaskNotificationViewModel.PersonID);
                if (TaskCode == null)
                {
                    _TaskNotificationViewModel.TaskCode = "LA";

                }
                else
                {
                    _TaskNotificationViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _TaskNotificationViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _TaskNotificationViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _TaskNotificationViewModel.ModuleList.Count()/4;
                }
                
                return PartialView("NotificationList", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult GetNotificationCount()
        {
            MessagesRepository _messageRepository = new MessagesRepository();
            return Json(_messageRepository.GetAllMessages(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult NotificationListCount()
        {
            GeneralTaskReportingDetailsViewModel _generalTaskReportingDetailsViewModel = new GeneralTaskReportingDetailsViewModel();
            _generalTaskReportingDetailsViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
            _generalTaskReportingDetailsViewModel.GeneralTaskReportingDetailsDTO.ConnectionString = _connectioString;
            IBaseEntityResponse<GeneralTaskReportingDetails> response = _generalTaskReportingDetailsBA.GetTotalPendingCountTaskEmployeewise(_generalTaskReportingDetailsViewModel.GeneralTaskReportingDetailsDTO);
            int result = 0;
            if (response != null && response.Entity != null)
            {
                result = Convert.ToInt32(response.Entity.TotalPendingRequest);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InformativeNotifications(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                return PartialView("/Views/TaskNotification/InformativeNotifications.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult GeneralRequest(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                return PartialView("/Views/TaskNotification/GeneralRequest.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult List(string actionMode, string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _TaskNotificationViewModel.TaskCodeList = GetTaskCodeList(_TaskNotificationViewModel.PersonID);
                if (TaskCode == null)
                {
                    _TaskNotificationViewModel.TaskCode = "LA";

                }
                else
                {
                    _TaskNotificationViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _TaskNotificationViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _TaskNotificationViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _TaskNotificationViewModel.ModuleList.Count()/4;
                }

                //return PartialView("List", _TaskNotificationViewModel);
                return PartialView("/Views/Home/ListV2.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult PendingRequestList(string actionMode, string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _TaskNotificationViewModel.TaskCodeList = GetTaskCodeList(_TaskNotificationViewModel.PersonID);
                if (TaskCode == null)
                {
                    _TaskNotificationViewModel.TaskCode = "LA";

                }
                else
                {
                    _TaskNotificationViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("RequestOnTaskNotification", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

      

        public ActionResult PendingRequest(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                //_TaskNotificationViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_TaskNotificationViewModel.TaskCodeList = GetTaskCodeList(_TaskNotificationViewModel.PersonID);               
                _TaskNotificationViewModel.TaskCode = TaskCode;
                return PartialView("/Views/Home/PendingRequests.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        
        public ActionResult PurchaseRequirementPendingRequest(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/PurchaseRequirementPendingRequest.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PendingLeaveRequestV2(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _dashboardViewModel = new TaskNotificationViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);              
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/PendingLeaveRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult ApproveAllV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "LA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.ApproveAllLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult PurchaseRequsitionPendingRequest(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/PurchaseRequisitionPendingRequest.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult PurchaseOrderPendingRequest(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/PurchaseOrderPendingRequest.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult SalesOrderPendingRequest(string TaskCode)
        {
            try
            {
                TaskNotificationViewModel _TaskNotificationViewModel = new TaskNotificationViewModel();
                _TaskNotificationViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/SalesOrderPendingRequest.cshtml", _TaskNotificationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult CODAPendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/CODAPendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        #endregion

        #region ---------------------Methods-ddd----------------------
        protected List<TaskNotification> GetDashboardContentListByAdminRoleID(int AdminRoleMasterID)
        {
            TaskNotificationSearchRequest searchRequest = new TaskNotificationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            List<TaskNotification> ModuleList = new List<TaskNotification>();
            IBaseEntityCollectionResponse<TaskNotification> baseEntityCollectionResponse = _TaskNotificationBA.GetDashboardContentListByAdminRoleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
          
            return ModuleList;
        }

        public IEnumerable<DashboardViewModel> GetPendingLeaveRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.ApplicationDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ApplicationDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPendingLeaveRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPendingLeaveRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPendingLeaveRequestViewModel;
        }


        public IEnumerable<TaskNotificationViewModel> GetPendingPRRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            TaskNotificationSearchRequest searchRequest = new TaskNotificationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "PurchaseRequirementNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "PurchaseRequirementNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<TaskNotificationViewModel> listFSAARequestViewModel = new List<TaskNotificationViewModel>();
            List<TaskNotification> listPendingLeaveRequest = new List<TaskNotification>();
            IBaseEntityCollectionResponse<TaskNotification> baseEntityCollectionResponse = _TaskNotificationBA.GetBySearchForTaskApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (TaskNotification item in listPendingLeaveRequest)
                    {
                        TaskNotificationViewModel TaskNotificationViewModel = new TaskNotificationViewModel();
                        TaskNotificationViewModel.TaskNotificationDTO = item;
                        listFSAARequestViewModel.Add(TaskNotificationViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listFSAARequestViewModel;
        }

        public IEnumerable<TaskNotificationViewModel> GetPendingPORequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            TaskNotificationSearchRequest searchRequest = new TaskNotificationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "PurchaseRequisitionNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<TaskNotificationViewModel> listPORequestViewModel = new List<TaskNotificationViewModel>();
            List<TaskNotification> listPendingPORequest = new List<TaskNotification>();
            IBaseEntityCollectionResponse<TaskNotification> baseEntityCollectionResponse = _TaskNotificationBA.GetBySearchForTaskApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingPORequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (TaskNotification item in listPendingPORequest)
                    {
                        TaskNotificationViewModel TaskNotificationViewModel = new TaskNotificationViewModel();
                        TaskNotificationViewModel.TaskNotificationDTO = item;
                        listPORequestViewModel.Add(TaskNotificationViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPORequestViewModel;
        }


        public IEnumerable<TaskNotificationViewModel> GetPendingSORequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            TaskNotificationSearchRequest searchRequest = new TaskNotificationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "SalesQuotationNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "SalesQuotationNumber";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<TaskNotificationViewModel> listPORequestViewModel = new List<TaskNotificationViewModel>();
            List<TaskNotification> listPendingPORequest = new List<TaskNotification>();
            IBaseEntityCollectionResponse<TaskNotification> baseEntityCollectionResponse = _TaskNotificationBA.GetBySearchForTaskApproval(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingPORequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (TaskNotification item in listPendingPORequest)
                    {
                        TaskNotificationViewModel TaskNotificationViewModel = new TaskNotificationViewModel();
                        TaskNotificationViewModel.TaskNotificationDTO = item;
                        listPORequestViewModel.Add(TaskNotificationViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPORequestViewModel;
        }
        

        protected List<Dashboard> GetTaskCodeList(int PersonID)
        {
             DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = PersonID;
            List<Dashboard> listTaskCode = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetGeneralTaskModelListByPersonID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listTaskCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listTaskCode;
        }
        #endregion


        #region ----------------------AjaxHandler---------------------
    
        public ActionResult AjaxHandlerMyDataTablePurchaseRequirementRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<TaskNotificationViewModel> filteredPendingFSAARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "PurchaseRequirementNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "Status";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PurchaseRequirementNumber Like '%" + param.sSearch + "%' or TransDate Like '%" + param.sSearch + "%' or Status Like '%" + param.sSearch + "%' or TotalFeeAmount Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingFSAARequest = GetPendingPRRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingFSAARequest = new List<TaskNotificationViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingFSAARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TaskDescription), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequirementNumber), Convert.ToString(c.TransDate) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePurchaseOrderRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<TaskNotificationViewModel> filteredPendingPORequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "F.PurchaseRequisitionNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "F.TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "H.Vender";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.Vender Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingPORequest = GetPendingPORequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingPORequest = new List<TaskNotificationViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingPORequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TaskDescription), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.TransDate), Convert.ToString(c.Vendor) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTableSalesOrderRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<TaskNotificationViewModel> filteredPendingPORequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "F.SalesQuotationNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.SalesQuotationNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.CustomerName Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "F.TransDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.SalesQuotationNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.CustomerName Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "H.CustomerName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "F.SalesQuotationNumber Like '%" + param.sSearch + "%' or F.TransDate Like '%" + param.sSearch + "%' or H.CustomerName Like '%" + param.sSearch + "%''";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingPORequest = GetPendingSORequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingPORequest = new List<TaskNotificationViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingPORequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TaskDescription), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.StudentName), Convert.ToString(c.SessionName), Convert.ToString(c.SectionDescription), Convert.ToString(c.TotalFeeAmount), Convert.ToString(c.FeeStructureMasterID), Convert.ToString(c.FeeStructureApplicableHistoryID), Convert.ToString(c.StudentID), Convert.ToString(c.PurchaseRequisitionNumber), Convert.ToString(c.TransDate), Convert.ToString(c.Vendor) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AjaxHandlerMyDataTablePendingLeaveRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "A.ApplicationDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "A.ApplicationDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingLeaveRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records
                         select new[] { Convert.ToString(c.Description)
                                       ,Convert.ToString(c.ApprovalStatus)
                                       ,Convert.ToString(c.MenuCodeLink)
                                       ,Convert.ToString(c.TaskNotificationDetailsID)
                                       ,Convert.ToString(c.TaskNotificationMasterID)
                                       ,Convert.ToString(c.GeneralTaskReportingDetailsID)
                                       ,Convert.ToString(c.StageSequenceNumber)
                                       ,Convert.ToString(c.IsLastRecordFlag)
                                       ,Convert.ToString(c.ApplicationDate)
                                       ,Convert.ToString(c.IsEngaged)
                                       ,(Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false))
                                       ,Convert.ToString(c.FromDate) + " - " + Convert.ToString(c.UptoDate)
                                       ,Convert.ToString(c.TotalfullDaysLeave)
                                       ,Convert.ToString(c.TotalHalfDayLeave)
                                       ,Convert.ToString(Convert.ToInt32(c.TotalDays) <= 1 ? c.TotalDays+ " Day" : c.TotalDays + " Days")
                                       ,Convert.ToString(c.CentreCode)
                                       ,Convert.ToString(c.EntityPKValue)
                                       ,Convert.ToString(c.LeaveMasterID)
                                       ,Convert.ToString(c.IsActiveMember)
                                       ,Convert.ToString(c.LeaveDescription)
                                       ,Convert.ToString(c.ApplicationStatus)};

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult InformativeNotifications(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.NotificationTransactionID = model.NotificationTransactionID;
                    model.DashboardDTO.PersonID = Convert.ToInt32(Session["UserID"]);

                    IBaseEntityResponse<Dashboard> response = _DashboardBA.InformativeNotificationsReadInsert(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult AjaxHandlerInformativeNotificationsList(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.TransactionDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            int PersonID = Convert.ToInt32(Session["PersonID"]);

            filteredPendingSSARequest = GetInformativeNotificationList(out TotalRecords, PersonID);

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.NotificationTransactionID), Convert.ToString(c.TransactionDate), Convert.ToString(c.SubjectDescription), Convert.ToString(c.BodyDescription), Convert.ToString(c.NotificationStatus) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public IEnumerable<DashboardViewModel> GetInformativeNotificationList(out int TotalRecords, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
            }
            List<DashboardViewModel> listInformativeNotificationViewModel = new List<DashboardViewModel>();
            List<Dashboard> listInformativeNotificationRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetInformativeNotificationListBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listInformativeNotificationRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listInformativeNotificationRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listInformativeNotificationViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listInformativeNotificationViewModel;
        }

        public ActionResult AjaxHandlerMyDataTableGeneralRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingSSARequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "G.RequestDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "G.RequestDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "B.EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "G.RequestDescription Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                //  int AdminRoleMasterID;
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingSSARequest = GetGeneralPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingSSARequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }

            var records = filteredPendingSSARequest.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.RequestDescription), Convert.ToString(c.RequestsStatus), Convert.ToString(c.RequestsLinkMenuCode), Convert.ToString(c.GeneralRequestTransactionID), Convert.ToString(c.FromUserName), Convert.ToString(c.PrimaryKeyValue), Convert.ToString(c.RequestCode) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        public IEnumerable<DashboardViewModel> GetGeneralPendingRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "RequestDescription";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listGeneralRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingGeneralRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetGeneralRequestBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingGeneralRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingGeneralRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listGeneralRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralRequestViewModel;
        }

        public ActionResult PendingManualAttendanceRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);               
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/PendingManualAttendanceRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AjaxHandlerMyDataTablePendingManualAttendanceRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "H.AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "H.AttendanceDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "H.AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "H.AttendanceDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "H.AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "H.AttendanceDate Like '%" + param.sSearch + "%' or E.ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "H.AttendanceDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "H.AttendanceDate Like '%" + param.sSearch + "%' or E.ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.AttendanceDate), Convert.ToString(c.CheckInTime), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult RequestApprovalV2(int PersonID, string TNDID, string TNMID, string GTRDID1, string TaskCode, string StageSequenceNumber, string IsLast)
        {
            DashboardViewModel _dashboradViewModel = new DashboardViewModel();

            _dashboradViewModel.PersonID = Convert.ToInt32(PersonID);
            _dashboradViewModel.TaskNotificationDetailsID = Convert.ToInt32(TNDID);
            _dashboradViewModel.TaskNotificationMasterID = Convert.ToInt32(TNMID);
            _dashboradViewModel.GeneralTaskReportingDetailsID = Convert.ToInt32(GTRDID1);
            _dashboradViewModel.TaskCode = TaskCode;
            _dashboradViewModel.StageSequenceNumber = Convert.ToInt32(StageSequenceNumber);
            _dashboradViewModel.IsLastRecord = Convert.ToBoolean(IsLast);

            _dashboradViewModel.RequestApprovalFieldMasterList = GetListRequestApprovalField(Convert.ToInt32(TNMID));

            return View("/Views/TaskNotification/RequestApprovalV2.cshtml", _dashboradViewModel);
        }

        public IEnumerable<DashboardViewModel> GetPendingRequest(out int TotalRecords, string TaskCode, int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "Description";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.PersonID = PersonID;
                    searchRequest.TaskCode = TaskCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PersonID = PersonID;
                searchRequest.TaskCode = TaskCode;
            }
            List<DashboardViewModel> listPendingLeaveRequestViewModel = new List<DashboardViewModel>();
            List<Dashboard> listPendingLeaveRequest = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPendingLeaveRequest = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listPendingLeaveRequest)
                    {
                        DashboardViewModel DashboardViewModel = new DashboardViewModel();
                        DashboardViewModel.DashboardDTO = item;
                        listPendingLeaveRequestViewModel.Add(DashboardViewModel);
                    }
                }
            }

            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPendingLeaveRequestViewModel;
        }

        [HttpPost]
        public ActionResult ApproveAllMARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "MA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.ApproveAllManualAttendanceApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult SPAttendancePendingRequestV2(string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                //_dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                //_dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                _dashboardViewModel.TaskCode = TaskCode;
                return PartialView("/Views/TaskNotification/SPAttendancePendingRequestV2.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult AjaxHandlerMyDataTablePendingLeaveAttendanceSpecialRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "RequestedDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "RequestedDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.RequestedDate), Convert.ToString(c.LeaveAttendanceSpecialDesctiption), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        protected List<Dashboard> GetListRequestApprovalField(int TaskNotificationMasterID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TaskNotificationMasterID = TaskNotificationMasterID;
            List<Dashboard> RequestApprovalFieldList = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetByRequestApprovalField(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    RequestApprovalFieldList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return RequestApprovalFieldList;
        }

        [HttpPost]
        public ActionResult RequestApprovalV2(DashboardViewModel model)
        {
            try
            {

                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.IsLastRecord = model.IsLastRecord;
                    model.DashboardDTO.TaskNotificationMasterID = model.TaskNotificationMasterID;
                    model.DashboardDTO.TaskNotificationDetailsID = model.TaskNotificationDetailsID;
                    model.DashboardDTO.ApprovalStatus = model.ApprovalStatus;
                    model.DashboardDTO.Remark = model.Remark;
                    model.DashboardDTO.PersonID = model.PersonID;
                    model.DashboardDTO.StageSequenceNumber = model.StageSequenceNumber;
                    model.DashboardDTO.TaskCode = model.TaskCode;
                    model.DashboardDTO.ApprovedByUserID = Convert.ToInt32(Session["UserID"]);
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.InsertDashboard(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult ApproveAllCODARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "CODA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.ApproveAllCompensatoryLeaveApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        public ActionResult AjaxHandlerMyDataTablePendingCompensatoryWorkDayRequest(JQueryDataTableParamModel param, string TaskCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<DashboardViewModel> filteredPendingLeaveRequest;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApprovalStatus Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "WorkingDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "WorkingDate Like '%" + param.sSearch + "%' or ApplicationDate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;


            if (!string.IsNullOrEmpty(Convert.ToString(TaskCode)))
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                filteredPendingLeaveRequest = GetPendingRequest(out TotalRecords, TaskCode, PersonID);
            }
            else
            {
                filteredPendingLeaveRequest = new List<DashboardViewModel>();
                TotalRecords = 0;
            }


            var records = filteredPendingLeaveRequest.Skip(0).Take(param.iDisplayLength);
            //var result = from c in records select new[] { Convert.ToString(c.LeaveMasterID), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveType), Convert.ToString(c.ID) };
            var result = from c in records select new[] { Convert.ToString(c.Description), Convert.ToString(c.ApprovalStatus), Convert.ToString(c.MenuCodeLink), Convert.ToString(c.TaskNotificationDetailsID), Convert.ToString(c.TaskNotificationMasterID), Convert.ToString(c.GeneralTaskReportingDetailsID), Convert.ToString(c.StageSequenceNumber), Convert.ToString(c.IsLastRecordFlag), Convert.ToString(c.ApplicationDate), Convert.ToString(c.IsEngaged), (Convert.ToString(c.EngagedByUserID) == Convert.ToString(Session["UserID"]) ? Convert.ToString(true) : Convert.ToString(false)), Convert.ToString(c.WorkingDate), Convert.ToString(c.CheckInTime), Convert.ToString(c.CheckOutTime), Convert.ToString(c.Reason), Convert.ToString(c.EntityPKValue), Convert.ToString(c.CentreCode) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult ApproveAllSPARequestV2(DashboardViewModel model)
        {
            try
            {
                if (model != null && model.DashboardDTO != null)
                {
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.XMLString = model.XMLString;
                    model.DashboardDTO.TaskCode = "ASA";
                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.ApproveAllAttendanceSpecialRequestApplication(model.DashboardDTO);

                    if (response.Entity.ErrorCode == 18)
                    {
                        model.DashboardDTO.errorMessage = "Notification Data Invalid.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 19)
                    {
                        model.DashboardDTO.errorMessage = "TaskApprovalFormFieldNameMaster Invalid Data.,#FFCC80,''";
                    }
                    else if (response.Entity.ErrorCode == 21)
                    {
                        model.DashboardDTO.errorMessage = "InsertUpdateProcedure not found.,#FFCC80,''";
                    }
                    else
                    {
                        model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
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