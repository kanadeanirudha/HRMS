using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace AERP.Web.UI.Controllers
{
    public class LeaveSessionController : BaseController
    {
        ILeaveSessionBA _ILeaveSessionBA = null;
        ILeaveSessionViewModel _LeaveSessionViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveSessionController()
        {
            _ILeaveSessionBA = new LeaveSessionBA();
            _LeaveSessionViewModel = new LeaveSessionViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveSession/Index.cshtml");
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    if (listAdminRoleApplicableDetails.Count > 0)
                    {
                        return View("/Views/Leave/LeaveSession/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("UnauthorizedAccess", "Home");
                    }
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _LeaveSessionViewModel.CentreCode = splitCentreCode[0];
                    // _LeaveSessionViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _LeaveSessionViewModel.CentreCode = centerCode;
                    //_LeaveSessionViewModel.EntityLevel = null;
                }
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveSessionViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveSessionViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveSessionViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    }
                    else
                    {
                        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    }
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveSessionViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveSessionViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeaveSessionViewModel.CentreCode = centerCode;
                _LeaveSessionViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveSession/List.cshtml", _LeaveSessionViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string centerCode, string centerName)
        {
            _LeaveSessionViewModel.CentreCode = centerCode;
            _LeaveSessionViewModel.CentreName = centerName;
            return View("/Views/Leave/LeaveSession/CreateSession.cshtml", _LeaveSessionViewModel);
        }

        [HttpPost]
        public ActionResult Create(LeaveSessionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveSessionDTO != null)
                    {
                        model.LeaveSessionDTO.ConnectionString = _connectioString;
                        string[] splitCentreCode = model.CentreCode.Split(':');
                        var centreCode = splitCentreCode[0];
                        model.LeaveSessionDTO.CentreCode = centreCode;
                        model.LeaveSessionDTO.LeaveSessionName = model.LeaveSessionName;
                        model.LeaveSessionDTO.LeaveSessionFromDate = model.LeaveSessionFromDate;
                        model.LeaveSessionDTO.LeaveSessionUptoDate = model.LeaveSessionUptoDate;
                        model.LeaveSessionDTO.IsCurrentLeaveSession = model.IsCurrentLeaveSession;
                        model.LeaveSessionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); 
                        IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.InsertLeaveSession(model.LeaveSessionDTO);
                       model.LeaveSessionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                 return Json(model.LeaveSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                   
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

        [HttpGet]
        public ActionResult Edit(string LeaveSessionID, string CentreCode, string CentreName,string Mode)
        {
            string[] splitCentreCode = CentreCode.Split(':');
            var splitcentreCode = splitCentreCode[0];
            _LeaveSessionViewModel.LeaveSessionDTO = new LeaveSession();
            _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
            _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = splitcentreCode;
           // _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = CentreCode;
            _LeaveSessionViewModel.LeaveSessionDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.SelectByID(_LeaveSessionViewModel.LeaveSessionDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionName = response.Entity.LeaveSessionName;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionFromDate = response.Entity.LeaveSessionFromDate;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionUptoDate = response.Entity.LeaveSessionUptoDate;
                _LeaveSessionViewModel.LeaveSessionDTO.IsSessionLocked = response.Entity.IsSessionLocked;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = response.Entity.CentreCode;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreName = CentreName;
                _LeaveSessionViewModel.LeaveSessionDTO.IsCurrentLeaveSession = response.Entity.IsCurrentLeaveSession;
                _LeaveSessionViewModel.LeaveSessionDTO.Mode = Convert.ToInt32(Mode); 
            }
            return View("/Views/Leave/LeaveSession/EditSession.cshtml", _LeaveSessionViewModel);
        }

        [HttpPost]
        public ActionResult Edit(LeaveSessionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveSessionDTO != null)
                    {
                        if (model != null && model.LeaveSessionDTO != null)
                        {
                            model.LeaveSessionDTO.ConnectionString = _connectioString;
                            model.LeaveSessionDTO.LeaveSessionID = model.LeaveSessionID;
                            model.LeaveSessionDTO.LeaveSessionName = model.LeaveSessionName;
                            model.LeaveSessionDTO.LeaveSessionFromDate = model.LeaveSessionFromDate;
                            model.LeaveSessionDTO.LeaveSessionUptoDate = model.LeaveSessionUptoDate;
                            model.LeaveSessionDTO.CentreCode = model.CentreCode;
                            model.LeaveSessionDTO.IsCurrentLeaveSession = model.IsCurrentLeaveSession;
                            model.LeaveSessionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.UpdateLeaveSession(model.LeaveSessionDTO);
                            model.LeaveSessionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.LeaveSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult ViewSessionDetails(string LeaveSessionID, string CentreCode, string CentreName, string Mode)
        {
            _LeaveSessionViewModel.LeaveSessionDTO = new LeaveSession();
            _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
            _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = CentreCode;
            _LeaveSessionViewModel.LeaveSessionDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.SelectByID(_LeaveSessionViewModel.LeaveSessionDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionName = response.Entity.LeaveSessionName;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionFromDate = response.Entity.LeaveSessionFromDate;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionUptoDate = response.Entity.LeaveSessionUptoDate;
                _LeaveSessionViewModel.LeaveSessionDTO.IsSessionLocked = response.Entity.IsSessionLocked;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = response.Entity.CentreCode;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreName = CentreName;
                _LeaveSessionViewModel.LeaveSessionDTO.IsCurrentLeaveSession = response.Entity.IsCurrentLeaveSession;
                _LeaveSessionViewModel.LeaveSessionDTO.Mode = Convert.ToInt32(Mode);
            }
            return View("/Views/Leave/LeaveSession/ViewSessionDetails.cshtml", _LeaveSessionViewModel);
        }

        [HttpGet]
        public ActionResult CreateLeaveSessionDetails(string LeaveSessionID, string centreCode, string centreName,string Mode)
        {
            _LeaveSessionViewModel.LeaveSessionDTO = new LeaveSession();
            _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
            _LeaveSessionViewModel.LeaveSessionDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.SelectByID(_LeaveSessionViewModel.LeaveSessionDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionName = response.Entity.LeaveSessionName;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionFromDate = response.Entity.LeaveSessionFromDate;
                _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionUptoDate = response.Entity.LeaveSessionUptoDate;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreCode = response.Entity.CentreCode;
                _LeaveSessionViewModel.LeaveSessionDTO.CentreName = centreName;
                _LeaveSessionViewModel.LeaveSessionDTO.IsCurrentLeaveSession = response.Entity.IsCurrentLeaveSession;
                _LeaveSessionViewModel.LeaveSessionDTO.Mode = Convert.ToInt32(Mode);
            }
            return View("/Views/Leave/LeaveSession/CreateLeaveSessionDetails.cshtml", _LeaveSessionViewModel);
        }


        [HttpPost]
        public ActionResult CreateLeaveSessionDetails(LeaveSessionViewModel model)
        {
            try
            {
                if (model.LeaveSessionID > 0)
                {
                    if (model != null && model.LeaveSessionDTO != null)
                    {
                        LeaveSession LeaveSessionDTO = new LeaveSession();
                        LeaveSessionDTO.ConnectionString = _connectioString;
                        LeaveSessionDTO.LeaveSessionID = model.LeaveSessionID;
                        LeaveSessionDTO.CentreCode = model.CentreCode;
                        LeaveSessionDTO.SelectedIDs = model.SelectedIDs;                       
                        LeaveSessionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.InsertLeaveSessionDetails(LeaveSessionDTO);
                        model.LeaveSessionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult EditLeaveSessionDetails(string LeaveSessionDetailsID, string EmployeeShiftDescription)
        {
            _LeaveSessionViewModel.LeaveSessionDTO = new LeaveSession();
            _LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionDetailsID = Convert.ToInt32(LeaveSessionDetailsID);

            _LeaveSessionViewModel.LeaveSessionDTO.ConnectionString = _connectioString;

            ////IBaseEntityResponse<LeaveSession> response = _LeaveSessionServiceAccess.SelectByLeaveSessionDetailsID(_LeaveSessionViewModel.LeaveSessionDTO);

            ////if (response != null && response.Entity != null)
            ////{
                //_LeaveSessionViewModel.LeaveSessionDTO.EmployeeShiftDescription = EmployeeShiftDescription;
                //_LeaveSessionViewModel.LeaveSessionDTO.LeaveSessionID = response.Entity.LeaveSessionID;
                //_LeaveSessionViewModel.LeaveSessionDTO.CentreCode = response.Entity.CentreCode;
                //_LeaveSessionViewModel.LeaveSessionDTO.CentreName = response.Entity.CentreName;
                //_LeaveSessionViewModel.LeaveSessionDTO.GeneralWeekDaysID = response.Entity.GeneralWeekDaysID;
                //_LeaveSessionViewModel.LeaveSessionDTO.WeekDay = response.Entity.WeekDay;
                //_LeaveSessionViewModel.LeaveSessionDTO.WeeklyOffStatus = response.Entity.WeeklyOffStatus;
                //_LeaveSessionViewModel.LeaveSessionDTO.WeeklyOffType = response.Entity.WeeklyOffType;
                //_LeaveSessionViewModel.LeaveSessionDTO.ShiftTimeFrom = response.Entity.ShiftTimeFrom;
                //_LeaveSessionViewModel.LeaveSessionDTO.ShiftTimeUpto = response.Entity.ShiftTimeUpto;
                //_LeaveSessionViewModel.LeaveSessionDTO.ShiftTimeMargin = response.Entity.ShiftTimeMargin;
                //_LeaveSessionViewModel.LeaveSessionDTO.ShiftEndBuffer = response.Entity.ShiftEndBuffer;
                //_LeaveSessionViewModel.LeaveSessionDTO.LunchTimeFrom = response.Entity.LunchTimeFrom;
                //_LeaveSessionViewModel.LeaveSessionDTO.LunchTimeUpto = response.Entity.LunchTimeUpto;
                //_LeaveSessionViewModel.LeaveSessionDTO.FirstHalfUpto = response.Entity.FirstHalfUpto;
                //_LeaveSessionViewModel.LeaveSessionDTO.SecondHalfFrom = response.Entity.SecondHalfFrom;
                //_LeaveSessionViewModel.LeaveSessionDTO.ConsiderLateMarkUpto = response.Entity.ConsiderLateMarkUpto;

            ////}

            List<SelectListItem> LeaveSessionDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            ViewBag.LeaveSessionDetails_WeeklyOffDayStatus = new SelectList(LeaveSessionDetails_WeeklyOffDayStatus, "Value", "Text");
            List<SelectListItem> li_LeaveSessionDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            li_LeaveSessionDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = "NO", Value = "N" });
            li_LeaveSessionDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = "YES", Value = "Y" });
            ViewData["WeeklyOffStatus"] = li_LeaveSessionDetails_WeeklyOffDayStatus;


            List<SelectListItem> EmployeeServiceDetails_WeeklyOffType = new List<SelectListItem>();
            ViewBag.EmpolyeeServiceDetail_WeeklyOffType = new SelectList(EmployeeServiceDetails_WeeklyOffType, "Value", "Text");
            List<SelectListItem> li_EmpolyeeServiceDetail_WeeklyOffType = new List<SelectListItem>();
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = "ALL", Value = "ALL" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = "AlternetEven", Value = "AlternetEven" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = "AlternetOdd", Value = "AlternetOdd" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = "Not Applicable", Value = "Not Applicable" });
            ViewData["EmployeeServiceDetails_WeeklyOffType"] = li_EmpolyeeServiceDetail_WeeklyOffType;

            return View("/Views/Leave/LeaveSession/EditDayDetails.cshtml", _LeaveSessionViewModel);
        }

        [HttpPost]
        public ActionResult EditLeaveSessionDetails(LeaveSessionViewModel model)
        {
            try
            {
                if (model.LeaveSessionID > 0)
                {
                    if (model != null && model.LeaveSessionDTO != null)
                    {
                        LeaveSession LeaveSessionDTO = new LeaveSession();
                        LeaveSessionDTO.ConnectionString = _connectioString;
                        LeaveSessionDTO.LeaveSessionDetailsID = model.LeaveSessionDetailsID;
                        ////LeaveSessionDTO.WeeklyOffStatus = model.WeeklyOffStatus;
                        ////LeaveSessionDTO.WeeklyOffType = model.WeeklyOffType;
                        ////LeaveSessionDTO.ShiftTimeFrom = model.ShiftTimeFrom;
                        ////LeaveSessionDTO.ShiftTimeUpto = model.ShiftTimeUpto;
                        ////LeaveSessionDTO.ShiftTimeMargin = model.ShiftTimeMargin;
                        ////LeaveSessionDTO.ShiftEndBuffer = model.ShiftEndBuffer;
                        ////LeaveSessionDTO.LunchTimeFrom = model.LunchTimeFrom;
                        ////LeaveSessionDTO.LunchTimeUpto = model.LunchTimeUpto;
                        ////LeaveSessionDTO.FirstHalfUpto = model.FirstHalfUpto;
                        ////LeaveSessionDTO.SecondHalfFrom = model.SecondHalfFrom;
                        ////LeaveSessionDTO.ConsiderLateMarkUpto = model.ConsiderLateMarkUpto;
                        LeaveSessionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveSession> response = _ILeaveSessionBA.UpdateLeaveSessionDetails(LeaveSessionDTO);
                        model.LeaveSessionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.LeaveSessionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        public IEnumerable<LeaveSessionViewModel> GetLeaveSessionRecords(out int TotalRecords, string CentreCode)
        {
            LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
            }
            List<LeaveSessionViewModel> listLeaveSessionViewModel = new List<LeaveSessionViewModel>();
            List<LeaveSession> listLeaveSession = new List<LeaveSession>();
            IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _ILeaveSessionBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveSession item in listLeaveSession)
                    {
                        LeaveSessionViewModel _LeaveSessionViewModel = new LeaveSessionViewModel();
                        _LeaveSessionViewModel.LeaveSessionDTO = item;
                        listLeaveSessionViewModel.Add(_LeaveSessionViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveSessionViewModel;
        }

        public IEnumerable<LeaveSessionViewModel> GetLeaveSessionDetails(string LeaveSessionID,int Mode)
        {
            LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
                    searchRequest.Mode = Mode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
                    searchRequest.Mode = Mode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
                searchRequest.Mode = Mode;
            }
            List<LeaveSessionViewModel> listLeaveSessionViewModel = new List<LeaveSessionViewModel>();
            List<LeaveSession> listLeaveSession = new List<LeaveSession>();
            IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _ILeaveSessionBA.GetLeaveSessionDetailsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveSession item in listLeaveSession)
                    {
                        LeaveSessionViewModel _LeaveSessionViewModel = new LeaveSessionViewModel();
                        _LeaveSessionViewModel.LeaveSessionDTO = item;
                        listLeaveSessionViewModel.Add(_LeaveSessionViewModel);
                    }
                }
            }
           // TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveSessionViewModel;
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveSessionViewModel> filteredLeaveSession;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LeaveSessionName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveSessionName Like '%" + param.sSearch + "%' or LeaveSessionFromDate Like '%" + param.sSearch + "%' or LeaveSessionUptoDate Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "LeaveSessionFromDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveSessionName Like '%" + param.sSearch + "%' or LeaveSessionFromDate Like '%" + param.sSearch + "%' or LeaveSessionUptoDate Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "LeaveSessionUptoDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveSessionName Like '%" + param.sSearch + "%' or LeaveSessionFromDate Like '%" + param.sSearch + "%' or LeaveSessionUptoDate Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {

                string[] splitCentreCode = CentreCode.Split(':');
                var centreCode = splitCentreCode[0];
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
               

                filteredLeaveSession = GetLeaveSessionRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveSession = new List<LeaveSessionViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveSession.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveSessionName), Convert.ToString(c.LeaveSessionFromDate), Convert.ToString(c.LeaveSessionUptoDate), Convert.ToString(c.IsCurrentLeaveSession), Convert.ToString(c.IsSessionLocked), Convert.ToString(c.LeaveSessionID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AjaxHandlerLeaveSessionDetails(JQueryDataTableParamModel param, string LeaveSessionID, int Mode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveSessionViewModel> filteredLeaveSession;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.JobProfileDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.JobProfileDescription Like '%" + param.sSearch + "%' or C.JobStatusDescription Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "C.JobStatusDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.JobProfileDescription Like '%" + param.sSearch + "%' or C.JobStatusDescription Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

              
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(LeaveSessionID))
            {

                //string[] splitCentreCode = CentreCode.Split(':');
               // var LeaveSessionID = 0;
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                //centerCode = splitCentreCode[0];

                filteredLeaveSession = GetLeaveSessionDetails(LeaveSessionID,Mode);
            }
            else
            {
                filteredLeaveSession = new List<LeaveSessionViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveSession.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.JobProfileDescription), Convert.ToString(c.JobStatusDescription), Convert.ToString(c.IsActive), Convert.ToString(c.JobProfileID), Convert.ToString(c.JobStatusCode), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.LeaveSessionDetailsID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = 0, iTotalDisplayRecords = 0, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}


