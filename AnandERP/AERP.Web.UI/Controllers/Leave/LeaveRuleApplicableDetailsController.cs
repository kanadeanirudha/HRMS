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
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveRuleApplicableDetailsController : BaseController
    {
        ILeaveRuleApplicableDetailsBA _ILeaveRuleApplicableDetailsBA = null;
        ILeaveRuleApplicableDetailsViewModel _LeaveRuleApplicableDetailsViewModel = null;
        ILeaveRuleMasterBA _ILeaveRuleMasterBA = null; 
        ILeaveSessionBA _ILeaveSessionBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveRuleApplicableDetailsController()
        {
            _ILeaveRuleApplicableDetailsBA = new LeaveRuleApplicableDetailsBA();
            _LeaveRuleApplicableDetailsViewModel = new LeaveRuleApplicableDetailsViewModel();
            _ILeaveSessionBA = new LeaveSessionBA();
            _ILeaveRuleMasterBA = new LeaveRuleMasterBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveRuleApplicableDetails/Index.cshtml");
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
                        return View("/Views/Leave/LeaveRuleApplicableDetails/Index.cshtml");
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

        //public ActionResult List(string actionMode, string centerCode, string centreName,string LeaveSessionID)
        //{
        //    try
        //    {
        //        if (!string.IsNullOrEmpty(centerCode))
        //        {
        //            string[] splitCentreCode = centerCode.Split(':');
        //            _LeaveRuleApplicableDetailsViewModel.CentreCode = splitCentreCode[0];
        //            // _LeaveRuleApplicableDetailsViewModel.EntityLevel = splitCentreCode[1];
        //            //centerCode = splitCentreCode[0];
        //        }
        //        else
        //        {
        //            _LeaveRuleApplicableDetailsViewModel.CentreCode = centerCode;
        //            //_LeaveRuleApplicableDetailsViewModel.EntityLevel = null;
        //        }
        //        if (Convert.ToString(Session["UserType"]) == "A")
        //        {
        //            //--------------------------------------For Centre Code list---------------------------------//
        //            List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
        //            AdminRoleApplicableDetails a = null;
        //            foreach (var item in listAdminRoleApplicableDetails)
        //            {
        //                a = new AdminRoleApplicableDetails();
        //                a.CentreCode = item.CentreCode;
        //                a.CentreName = item.CentreName;
        //                a.ScopeIdentity = item.ScopeIdentity;
        //                _LeaveRuleApplicableDetailsViewModel.ListGetAdminRoleApplicableCentre.Add(a);
        //            }
        //            _LeaveRuleApplicableDetailsViewModel.EntityLevel = "Centre";

        //            foreach (var b in _LeaveRuleApplicableDetailsViewModel.ListGetAdminRoleApplicableCentre)
        //            {
        //                b.CentreCode = b.CentreCode + ":" + "Centre";
        //            }
        //        }
        //        else
        //        {
        //            int AdminRoleMasterID = 0;
        //            if (Session["RoleID"] == null)
        //            {
        //                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
        //            }
        //            else
        //            {
        //                AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
        //            }
        //            List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID);
        //            AdminRoleApplicableDetails a = null;
        //            foreach (var item in listAdminRoleApplicableDetails)
        //            {
        //                a = new AdminRoleApplicableDetails();
        //                a.CentreCode = item.CentreCode;
        //                a.CentreName = item.CentreName;                      
        //                _LeaveRuleApplicableDetailsViewModel.ListGetAdminRoleApplicableCentre.Add(a);
        //            }
        //            foreach (var b in _LeaveRuleApplicableDetailsViewModel.ListGetAdminRoleApplicableCentre)
        //            {
        //                b.CentreCode = b.CentreCode;
        //            }
        //        }

        //        _LeaveRuleApplicableDetailsViewModel.CentreCode = centerCode;
        //        _LeaveRuleApplicableDetailsViewModel.CentreName = centreName;
        //        if (!string.IsNullOrEmpty(actionMode))
        //        {
        //            TempData["ActionMode"] = actionMode;
        //        }
        //        return PartialView("/Views/Leave/LeaveRuleApplicableDetails/List.cshtml", _LeaveRuleApplicableDetailsViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        public ActionResult List(string centerCode, string universityID, string actionMode,string SessionId)
        {
            try
            {
                LeaveRuleApplicableDetailsViewModel model = new LeaveRuleApplicableDetailsViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    model.ListLeaveSession = GetListLeaveSession(splitCentreCode[0]);
                }
                model.CentreCode = centerCode;
                model.SelectedCentreCode = centerCode;
                model.SelectedSessionID = SessionId;
                model.LeaveSessionID = Convert.ToInt32(SessionId);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveRuleApplicableDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]

        public ActionResult Create(string CentreCode, string LeaveCode, string LeaveSessionID, string LeaveSessionName, string JobProfileID, string JobStatusID, string CombinationRuleCode)
        {
            var splitedCentreCode = CentreCode.Split(':');
            _LeaveRuleApplicableDetailsViewModel.CentreCode = splitedCentreCode[0];
            _LeaveRuleApplicableDetailsViewModel.LeaveCode = LeaveCode;
            _LeaveRuleApplicableDetailsViewModel.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
            _LeaveRuleApplicableDetailsViewModel.JobProfileID = Convert.ToInt32(JobProfileID);
            _LeaveRuleApplicableDetailsViewModel.JobStatusID = Convert.ToInt32(JobStatusID);
            _LeaveRuleApplicableDetailsViewModel.CombinationRuleCode = CombinationRuleCode.Replace('-', ' ');
           

            string SelectedCountryID = string.Empty;
            List<LeaveRuleMaster> leaveRuleMasterList = GetListLeaveRuleMaster(LeaveCode, splitedCentreCode[0]);
            List<SelectListItem> leaveRuleMaster = new List<SelectListItem>();
            foreach (LeaveRuleMaster item in leaveRuleMasterList)
            {
                leaveRuleMaster.Add(new SelectListItem { Text = item.LeaveRuleDescription, Value = item.ID.ToString() });
            }
            ViewBag.LeaveRuleMaster = new SelectList(leaveRuleMaster, "Value", "Text");
            return View("/Views/Leave/LeaveRuleApplicableDetails/Create.cshtml", _LeaveRuleApplicableDetailsViewModel);
        }

        [HttpGet]
        public ActionResult CreatePartialForm(string LeaveRuleMasterID)
        {
            LeaveRuleMasterViewModel _leaveRuleMsterViewModel = new LeaveRuleMasterViewModel();
            _leaveRuleMsterViewModel.ID = Convert.ToInt32(LeaveRuleMasterID);
            _leaveRuleMsterViewModel.LeaveRuleMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.SelectByID(_leaveRuleMsterViewModel.LeaveRuleMasterDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleApplicableDetailsViewModel.NumberOfLeaves = response.Entity.NumberOfLeaves;
                _LeaveRuleApplicableDetailsViewModel.MaxLeaveAtTime = response.Entity.MaxLeaveAtTime;
                _LeaveRuleApplicableDetailsViewModel.MinimumLeaveEncash = response.Entity.MinimumLeaveEncash;
                _LeaveRuleApplicableDetailsViewModel.MaxLeaveEncash = response.Entity.MaxLeaveEncash;
                _LeaveRuleApplicableDetailsViewModel.MaxLeaveAccumulated = response.Entity.MaxLeaveAccumulated;
                _LeaveRuleApplicableDetailsViewModel.MinServiceRequiredInMonth = response.Entity.MinServiceRequiredInMonth;
                _LeaveRuleApplicableDetailsViewModel.AttendDaysRequired = response.Entity.AttendDaysRequired;
                _LeaveRuleApplicableDetailsViewModel.CreditDependOn = response.Entity.CreditDependOn;
                _LeaveRuleApplicableDetailsViewModel.DayOfTheMonth = response.Entity.DayOfTheMonth;
                _LeaveRuleApplicableDetailsViewModel.IsLocked = response.Entity.IsLocked;
                _LeaveRuleApplicableDetailsViewModel.IsActive = response.Entity.IsActive;
                _LeaveRuleApplicableDetailsViewModel.MinLeavesAtTime = response.Entity.MinLeavesAtTime;              
            }

            return View("/Views/Leave/LeaveRuleApplicableDetails/CreatePartialForm.cshtml", _LeaveRuleApplicableDetailsViewModel);
        }
        

        [HttpPost]
        public ActionResult Create(LeaveRuleApplicableDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveRuleApplicableDetailsDTO != null)
                    {
                        model.LeaveRuleApplicableDetailsDTO.ConnectionString = _connectioString;                       
                        model.LeaveRuleApplicableDetailsDTO.LeaveRuleMasterID = model.LeaveRuleMasterID;
                        model.LeaveRuleApplicableDetailsDTO.LeaveSessionID = model.LeaveSessionID;
                        model.LeaveRuleApplicableDetailsDTO.JobProfileID = model.JobProfileID;
                        model.LeaveRuleApplicableDetailsDTO.JobStatusID = model.JobStatusID;
                        model.LeaveRuleApplicableDetailsDTO.IsActive = true;
                        model.LeaveRuleApplicableDetailsDTO.IsCurrentFlag = true;
                        model.LeaveRuleApplicableDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);

                        IBaseEntityResponse<LeaveRuleApplicableDetails> response = _ILeaveRuleApplicableDetailsBA.InsertLeaveRuleApplicableDetails(model.LeaveRuleApplicableDetailsDTO);
                        model.LeaveRuleApplicableDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveRuleApplicableDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult Edit(string ID)
        {
            LeaveRuleApplicableDetailsViewModel model = new LeaveRuleApplicableDetailsViewModel();

            if (ID != null)
            {
                string[] RuleArray = ID.Split('~');

                model.LeaveRuleApplicableDetailsDTO.ConnectionString = _connectioString;
                model.LeaveRuleApplicableDetailsDTO.ID = Convert.ToInt32(RuleArray[0]);
                model.LeaveRuleApplicableDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<LeaveRuleApplicableDetails> response = _ILeaveRuleApplicableDetailsBA.UpdateLeaveRuleApplicableDetails(model.LeaveRuleApplicableDetailsDTO);
                model.LeaveRuleApplicableDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.LeaveRuleApplicableDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }


        [HttpGet]
        public ActionResult ViewSessionDetails(string LeaveRuleApplicableDetailsID, string CentreCode, string CentreName, string Mode)
        {
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO = new LeaveRuleApplicableDetails();
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ID = Convert.ToInt32(LeaveRuleApplicableDetailsID);
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleApplicableDetails> response = _ILeaveRuleApplicableDetailsBA.SelectByID(_LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ID = response.Entity.ID;
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.CentreCode = response.Entity.CentreCode;
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.CentreName = CentreName;

            }
            return View("/Views/Leave/LeaveRuleApplicableDetails/ViewSessionDetails.cshtml", _LeaveRuleApplicableDetailsViewModel);
        }

        [HttpGet]
        public ActionResult CreateLeaveRuleApplicableDetailsDetails(string LeaveRuleApplicableDetailsID, string centreCode, string centreName, string Mode)
        {
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO = new LeaveRuleApplicableDetails();
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ID = Convert.ToInt32(LeaveRuleApplicableDetailsID);
            _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleApplicableDetails> response = _ILeaveRuleApplicableDetailsBA.SelectByID(_LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.ID = response.Entity.ID;
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.CentreCode = response.Entity.CentreCode;
                _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO.CentreName = centreName;
            }
            return View("/Views/Leave/LeaveRuleApplicableDetails/CreateLeaveRuleApplicableDetailsDetails.cshtml", _LeaveRuleApplicableDetailsViewModel);
        }

        #endregion

        // Non-Action Methods
        #region Methods
        //protected List<LeaveSession> GetListLeaveSession(string CentreCode)
        //{
        //    LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SortBy = "LeaveSessionName";                        // parameters for SelectAll procedures under normal condition
        //    searchRequest.StartRow = 0;
        //    searchRequest.EndRow = 100;
        //    searchRequest.SearchBy = string.Empty;
        //    searchRequest.SortDirection = "asc";
        //    searchRequest.CentreCode = CentreCode;
        //    //searchRequest.SearchType = 1;
        //    List<LeaveSession> listLeaveSession = new List<LeaveSession>();
        //    IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _leaveSessionServiceAccess.GetBySearch(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listLeaveSession;
        //}

        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult GetLeaveSessionByCentreCode(string SelectedCentreCode)
        //{
        //    LeaveRuleApplicableDetailsViewModel model = new LeaveRuleApplicableDetailsViewModel();
        //    string[] splited;
        //    splited = SelectedCentreCode.Split(':');
        //    model.SelectedCentreName = splited[1];
        //    SelectedCentreCode = splited[0];
        //    if (String.IsNullOrEmpty(SelectedCentreCode))
        //    {
        //        throw new ArgumentNullException("SelectedCentreCode");
        //    }
        //    int id = 0;
        //    bool isValid = Int32.TryParse(SelectedCentreCode, out id);
        //    var session = GetListLeaveSession(SelectedCentreCode);
        //    var result = (from s in session
        //                  select new
        //                  {
        //                      id = s.LeaveSessionID,
        //                      name = s.LeaveSessionName,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        public IEnumerable<LeaveRuleApplicableDetailsViewModel> GetLeaveRuleApplicableDetailsRecords(out int TotalRecords, string CentreCode, int LeaveSessionID)
        {
            LeaveRuleApplicableDetailsSearchRequest searchRequest = new LeaveRuleApplicableDetailsSearchRequest();
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
                    searchRequest.LeaveSessionID = LeaveSessionID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.LeaveSessionID = LeaveSessionID;
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
                searchRequest.LeaveSessionID = LeaveSessionID;
            }
            List<LeaveRuleApplicableDetailsViewModel> listLeaveRuleApplicableDetailsViewModel = new List<LeaveRuleApplicableDetailsViewModel>();
            List<LeaveRuleApplicableDetails> listLeaveRuleApplicableDetails = new List<LeaveRuleApplicableDetails>();
            IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> baseEntityCollectionResponse = _ILeaveRuleApplicableDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveRuleApplicableDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveRuleApplicableDetails item in listLeaveRuleApplicableDetails)
                    {
                        LeaveRuleApplicableDetailsViewModel _LeaveRuleApplicableDetailsViewModel = new LeaveRuleApplicableDetailsViewModel();
                        _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO = item;
                        listLeaveRuleApplicableDetailsViewModel.Add(_LeaveRuleApplicableDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveRuleApplicableDetailsViewModel;
        }

        protected IEnumerable<LeaveRuleApplicableDetailsViewModel> GetLeaveRuleApplicableDetailsByLeaveCode(out int TotalRecords, string centreCode, string LeaveSessionID, string LeaveCode)
        {
            LeaveRuleApplicableDetailsSearchRequest searchRequest = new LeaveRuleApplicableDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.LeaveCode = LeaveCode;
            searchRequest.LeaveSessionID = Convert.ToInt32(LeaveSessionID);
            searchRequest.CentreCode = centreCode;

            List<LeaveRuleApplicableDetailsViewModel> listLeaveRuleApplicableDetailsViewModelByLeaveRuleMasterID = new List<LeaveRuleApplicableDetailsViewModel>();
            List<LeaveRuleApplicableDetails> listLeaveRuleApplicableDetailsByLeaveRuleMasterID = new List<LeaveRuleApplicableDetails>();
            IBaseEntityCollectionResponse<LeaveRuleApplicableDetails> baseEntityCollectionResponse = _ILeaveRuleApplicableDetailsBA.SelectByLeaveRuleMasterID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                   // listLeaveRuleApplicableDetailsByLeaveRuleMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    listLeaveRuleApplicableDetailsByLeaveRuleMasterID = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveRuleApplicableDetails item in listLeaveRuleApplicableDetailsByLeaveRuleMasterID)
                    {
                        LeaveRuleApplicableDetailsViewModel _LeaveRuleApplicableDetailsViewModel = new LeaveRuleApplicableDetailsViewModel();
                        _LeaveRuleApplicableDetailsViewModel.LeaveRuleApplicableDetailsDTO = item;
                        listLeaveRuleApplicableDetailsViewModelByLeaveRuleMasterID.Add(_LeaveRuleApplicableDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveRuleApplicableDetailsViewModelByLeaveRuleMasterID;
        }

        protected List<LeaveRuleMaster> GetListLeaveRuleMaster(string LeaveCode,string CentreCode)
        {
            LeaveRuleMasterSearchRequest searchRequest = new LeaveRuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LeaveCode = !string.IsNullOrEmpty(LeaveCode) ? LeaveCode : string.Empty;
            searchRequest.CentreCode = !string.IsNullOrEmpty(CentreCode) ? CentreCode : string.Empty;
            List<LeaveRuleMaster> listLeaveRuleMaster = new List<LeaveRuleMaster>();
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollectionResponse = _ILeaveRuleMasterBA.GetByLeaveCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveRuleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveRuleMaster;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string leaveSessionID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveRuleApplicableDetailsViewModel> filteredLeaveRuleApplicableDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                 case 0:
                    _sortBy = "LeaveDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or JobProfileDescription like '%" + param.sSearch + "%' or JobStatusDescription like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "LeaveRuleDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or JobProfileDescription like '%" + param.sSearch + "%' or JobStatusDescription like '%" + param.sSearch + "%' ";         //this "if" block is added for search functionality
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
                var LeaveSessionID = Convert.ToInt32(leaveSessionID);
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

                filteredLeaveRuleApplicableDetails = GetLeaveRuleApplicableDetailsRecords(out TotalRecords, centreCode, LeaveSessionID);
            }
            else
            {
                filteredLeaveRuleApplicableDetails = new List<LeaveRuleApplicableDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveRuleApplicableDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveCode), Convert.ToString(c.LeaveDescription), Convert.ToString(c.JobProfileDescription), Convert.ToString(c.JobStatusDescription), Convert.ToString(c.LeaveRuleMasterID), Convert.ToString(c.LeaveCode + "-" + c.LeaveRuleMasterDescription), Convert.ToString(c.StatusFlag), Convert.ToString(c.LeaveSessionID), Convert.ToString(c.JobStatusID), Convert.ToString(c.JobProfileID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxHandlerLeaveRuleApplicableDetailsByLeaveRuleMasterID(JQueryDataTableParamModel param, string CentreCode, string LeaveSessionID,string LeaveCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveRuleApplicableDetailsViewModel> filteredLeaveRuleApplicableDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "JobProfileDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobProfileDescription Like '%" + param.sSearch + "%' or JobStatusDescription Like '%" + param.sSearch + "%'or LeaveDescription Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "JobStatusDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "JobStatusDescription Like '%" + param.sSearch + "%' or JobProfileDescription Like '%" + param.sSearch + "%'or LeaveDescription Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
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
                //centerCode = splitCentreCode[0];

                filteredLeaveRuleApplicableDetails = GetLeaveRuleApplicableDetailsByLeaveCode(out TotalRecords, centreCode, LeaveSessionID, LeaveCode);
            }
            else
            {
                filteredLeaveRuleApplicableDetails = new List<LeaveRuleApplicableDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveRuleApplicableDetails.Skip(0).Take(filteredLeaveRuleApplicableDetails.Count());
            var result = from c in records select new[] { Convert.ToString(c.JobProfileDescription), Convert.ToString(c.JobStatusDescription), Convert.ToString(c.LeaveCode + "-" + c.LeaveRuleMasterDescription), Convert.ToString(c.IsActive), Convert.ToString(c.LeaveRuleMasterID), Convert.ToString(c.JobProfileID), Convert.ToString(c.JobStatusID), Convert.ToString(c.ID), Convert.ToString(c.IsCurrentFlag), Convert.ToString(c.JobStatusCode), Convert.ToString(c.LeaveRuleMasterDescription), Convert.ToString(TotalRecords) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


