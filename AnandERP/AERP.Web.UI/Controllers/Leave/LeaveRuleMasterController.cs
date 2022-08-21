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
    public class LeaveRuleMasterController : BaseController
    {
        ILeaveRuleMasterBA _ILeaveRuleMasterBA = null;
        LeaveRuleMasterViewModel _LeaveRuleMasterViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveRuleMasterController()
        {
            _ILeaveRuleMasterBA = new LeaveRuleMasterBA();
            _LeaveRuleMasterViewModel = new LeaveRuleMasterViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveRuleMaster/Index.cshtml");
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
                        return View("/Views/Leave/LeaveRuleMaster/Index.cshtml");
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
                    _LeaveRuleMasterViewModel.CentreCode = splitCentreCode[0];
                    // _LeaveRuleMasterViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _LeaveRuleMasterViewModel.CentreCode = centerCode;
                    //_LeaveRuleMasterViewModel.EntityLevel = null;
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
                        _LeaveRuleMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveRuleMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveRuleMasterViewModel.ListGetAdminRoleApplicableCentre)
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
                        _LeaveRuleMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveRuleMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeaveRuleMasterViewModel.CentreCode = centerCode;
                _LeaveRuleMasterViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveRuleMaster/List.cshtml", _LeaveRuleMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string CentreCode, string LeaveMasterID, string LeaveDescription)
        {
            _LeaveRuleMasterViewModel.CentreCode = CentreCode;
            _LeaveRuleMasterViewModel.LeaveMasterID = Convert.ToInt32(LeaveMasterID);
           _LeaveRuleMasterViewModel.LeaveDescription = LeaveDescription.Replace('~',' ');

            List<SelectListItem> employeeAccumulationMethod = new List<SelectListItem>();
            employeeAccumulationMethod.Add(new SelectListItem { Text = "Fixed", Value = "1" });
            employeeAccumulationMethod.Add(new SelectListItem { Text = "Periodic", Value = "2" });

            _LeaveRuleMasterViewModel.employeeAccumulationMethod = employeeAccumulationMethod;
            return View("/Views/Leave/LeaveRuleMaster/Create.cshtml", _LeaveRuleMasterViewModel);
        }

        [HttpPost]
        public ActionResult Create(LeaveRuleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveRuleMasterDTO != null)
                    {
                        model.LeaveRuleMasterDTO.ConnectionString = _connectioString;
                        model.LeaveRuleMasterDTO.CentreCode =!string.IsNullOrEmpty(model.CentreCode)? model.CentreCode.Split(':')[0]:string.Empty;
                        model.LeaveRuleMasterDTO.LeaveMasterID = model.LeaveMasterID;
                        model.LeaveRuleMasterDTO.LeaveRuleDescription = model.LeaveRuleDescription;
                        model.LeaveRuleMasterDTO.NumberOfLeaves = model.NumberOfLeaves;
                        model.LeaveRuleMasterDTO.MaxLeaveAtTime = model.MaxLeaveAtTime;
                        //model.LeaveRuleMasterDTO.MinimumLeaveEncash = model.MinimumLeaveEncash;
                        model.LeaveRuleMasterDTO.MaxLeaveEncash = model.MaxLeaveEncash;
                        model.LeaveRuleMasterDTO.MaxLeaveAccumulated = model.MaxLeaveAccumulated;
                        model.LeaveRuleMasterDTO.MinServiceRequiredInMonth = model.MinServiceRequiredInMonth;
                        //model.LeaveRuleMasterDTO.AttendDaysRequired = model.AttendDaysRequired;
                        model.LeaveRuleMasterDTO.MinLeavesAtTime = model.MinLeavesAtTime;
                        model.LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted = model.DaysBeforeApplicationSubmitted;
                        model.LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays = model.LeaveApplicationSubmittedUptoDays;
                        model.LeaveRuleMasterDTO.IsActive = true;
                        //model.LeaveRuleMasterDTO.IsLeaveAccumulatePeriodically = model.IsLeaveAccumulatePeriodically;
                        model.LeaveRuleMasterDTO.NumberOfMonths = model.NumberOfMonths;
                        model.LeaveRuleMasterDTO.NumberOfAccumulatedLeaves = model.NumberOfAccumulatedLeaves;
                        model.LeaveRuleMasterDTO.DaysAfterApplicationSubmitted = model.DaysAfterApplicationSubmitted;
                        model.LeaveRuleMasterDTO.AccumulationMethod = model.AccumulationMethod;
                        model.LeaveRuleMasterDTO.LeaveEncashFormula = model.LeaveEncashFormula;
                        model.LeaveRuleMasterDTO.LeaveMonthRatio = model.LeaveMonthRatio;

                        model.LeaveRuleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.InsertLeaveRuleMaster(model.LeaveRuleMasterDTO);
                        model.LeaveRuleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveRuleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult Edit(string ID, string LeaveDescription, string Mode)
        {
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO = new LeaveRuleMaster();
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ID = Convert.ToInt32(ID);
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveDescription = LeaveDescription.Replace('~', ' ');
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.SelectByID(_LeaveRuleMasterViewModel.LeaveRuleMasterDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveMasterID = response.Entity.LeaveMasterID;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleDescription = response.Entity.LeaveRuleDescription;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.NumberOfLeaves = response.Entity.NumberOfLeaves;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MaxLeaveAtTime = response.Entity.MaxLeaveAtTime;
               // _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MinimumLeaveEncash = response.Entity.MinimumLeaveEncash;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MaxLeaveEncash = response.Entity.MaxLeaveEncash;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MaxLeaveAccumulated = response.Entity.MaxLeaveAccumulated;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MinServiceRequiredInMonth = response.Entity.MinServiceRequiredInMonth;
               //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.AttendDaysRequired = response.Entity.AttendDaysRequired;
               // _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CreditDependOn = response.Entity.CreditDependOn;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.DayOfTheMonth = response.Entity.DayOfTheMonth;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.IsLocked = response.Entity.IsLocked;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.IsActive = response.Entity.IsActive;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.MinLeavesAtTime = response.Entity.MinLeavesAtTime;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted = response.Entity.DaysBeforeApplicationSubmitted;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays = response.Entity.LeaveApplicationSubmittedUptoDays;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CentreCode = response.Entity.CentreCode;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.IsLeaveAccumulatePeriodically = response.Entity.IsLeaveAccumulatePeriodically;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.NumberOfMonths = response.Entity.NumberOfMonths;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.NumberOfAccumulatedLeaves = response.Entity.NumberOfAccumulatedLeaves;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.DaysAfterApplicationSubmitted = response.Entity.DaysAfterApplicationSubmitted;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.AccumulationMethod = response.Entity.AccumulationMethod;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveMonthRatio = response.Entity.LeaveMonthRatio;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveEncashFormula = response.Entity.LeaveEncashFormula;


            }
            List<SelectListItem> employeeAccumulationMethod = new List<SelectListItem>();
            employeeAccumulationMethod.Add(new SelectListItem { Text = "Fixed", Value = "1" });
            employeeAccumulationMethod.Add(new SelectListItem { Text = "Periodic", Value = "2" });

            ViewBag.AccumulationMethodList = new SelectList(employeeAccumulationMethod, "Value", "Text");
            if ("1" == Mode)
            {
                return View("/Views/Leave/LeaveRuleMaster/Edit.cshtml", _LeaveRuleMasterViewModel);
            }
            else
            {
                return View("/Views/Leave/LeaveRuleMaster/ViewDeatils.cshtml", _LeaveRuleMasterViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveRuleMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveRuleMasterDTO != null)
                    {
                        if (model != null && model.LeaveRuleMasterDTO != null)
                        {
                            model.LeaveRuleMasterDTO.ConnectionString = _connectioString;
                            model.LeaveRuleMasterDTO.ID = model.ID;
                            model.LeaveRuleMasterDTO.CentreCode = !string.IsNullOrEmpty(model.CentreCode) ? model.CentreCode.Split(':')[0] : string.Empty;
                            model.LeaveRuleMasterDTO.LeaveMasterID = model.LeaveMasterID;
                            model.LeaveRuleMasterDTO.LeaveRuleDescription = model.LeaveRuleDescription;
                            model.LeaveRuleMasterDTO.NumberOfLeaves = model.NumberOfLeaves;
                            model.LeaveRuleMasterDTO.MaxLeaveAtTime = model.MaxLeaveAtTime;
                            //model.LeaveRuleMasterDTO.MinimumLeaveEncash = model.MinimumLeaveEncash;
                            model.LeaveRuleMasterDTO.MaxLeaveEncash = model.MaxLeaveEncash;
                            model.LeaveRuleMasterDTO.MaxLeaveAccumulated = model.MaxLeaveAccumulated;
                            model.LeaveRuleMasterDTO.MinServiceRequiredInMonth = model.MinServiceRequiredInMonth;
                            //model.LeaveRuleMasterDTO.AttendDaysRequired = model.AttendDaysRequired;
                            model.LeaveRuleMasterDTO.MinLeavesAtTime = model.MinLeavesAtTime;
                            model.LeaveRuleMasterDTO.DaysBeforeApplicationSubmitted = model.DaysBeforeApplicationSubmitted;
                            model.LeaveRuleMasterDTO.LeaveApplicationSubmittedUptoDays = model.LeaveApplicationSubmittedUptoDays;
                            model.LeaveRuleMasterDTO.IsActive = model.IsActive;
                            //model.LeaveRuleMasterDTO.IsLeaveAccumulatePeriodically = model.IsLeaveAccumulatePeriodically;
                            model.LeaveRuleMasterDTO.NumberOfMonths = model.NumberOfMonths;
                            model.LeaveRuleMasterDTO.NumberOfAccumulatedLeaves = model.NumberOfAccumulatedLeaves;
                            model.LeaveRuleMasterDTO.DaysAfterApplicationSubmitted = model.DaysAfterApplicationSubmitted;
                            model.LeaveRuleMasterDTO.AccumulationMethod = model.AccumulationMethod;
                            model.LeaveRuleMasterDTO.LeaveEncashFormula = model.LeaveEncashFormula;
                            model.LeaveRuleMasterDTO.LeaveMonthRatio = model.LeaveMonthRatio;

                            model.LeaveRuleMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.UpdateLeaveRuleMaster(model.LeaveRuleMasterDTO);
                            model.LeaveRuleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.LeaveRuleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewSessionDetails(string LeaveRuleMasterID, string CentreCode, string CentreName, string Mode)
        {
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO = new LeaveRuleMaster();
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ID = Convert.ToInt32(LeaveRuleMasterID);
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.SelectByID(_LeaveRuleMasterViewModel.LeaveRuleMasterDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ID = response.Entity.ID;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterName = response.Entity.LeaveRuleMasterName;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterFromDate = response.Entity.LeaveRuleMasterFromDate;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterUptoDate = response.Entity.LeaveRuleMasterUptoDate;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CentreCode = response.Entity.CentreCode;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CentreName = CentreName;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.IsCurrentLeaveRuleMaster = response.Entity.IsCurrentLeaveRuleMaster;
               
            }
            return View("/Views/Leave/LeaveRuleMaster/ViewSessionDetails.cshtml", _LeaveRuleMasterViewModel);
        }

        [HttpGet]
        public ActionResult CreateLeaveRuleMasterDetails(string LeaveRuleMasterID, string centreCode, string centreName, string Mode)
        {
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO = new LeaveRuleMaster();
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ID = Convert.ToInt32(LeaveRuleMasterID);
            _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveRuleMaster> response = _ILeaveRuleMasterBA.SelectByID(_LeaveRuleMasterViewModel.LeaveRuleMasterDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.ID = response.Entity.ID;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterName = response.Entity.LeaveRuleMasterName;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterFromDate = response.Entity.LeaveRuleMasterFromDate;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.LeaveRuleMasterUptoDate = response.Entity.LeaveRuleMasterUptoDate;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CentreCode = response.Entity.CentreCode;
                _LeaveRuleMasterViewModel.LeaveRuleMasterDTO.CentreName = centreName;
                //_LeaveRuleMasterViewModel.LeaveRuleMasterDTO.IsCurrentLeaveRuleMaster = response.Entity.IsCurrentLeaveRuleMaster;
             
            }
            return View("/Views/Leave/LeaveRuleMaster/CreateLeaveRuleMasterDetails.cshtml", _LeaveRuleMasterViewModel);
        }
  
        #endregion

        // Non-Action Methods
        #region Methods
        public IEnumerable<LeaveRuleMasterViewModel> GetLeaveRuleMasterRecords(out int TotalRecords, string CentreCode)
        {
            LeaveRuleMasterSearchRequest searchRequest = new LeaveRuleMasterSearchRequest();
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
            List<LeaveRuleMasterViewModel> listLeaveRuleMasterViewModel = new List<LeaveRuleMasterViewModel>();
            List<LeaveRuleMaster> listLeaveRuleMaster = new List<LeaveRuleMaster>();
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollectionResponse = _ILeaveRuleMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveRuleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveRuleMaster item in listLeaveRuleMaster)
                    {
                        LeaveRuleMasterViewModel _LeaveRuleMasterViewModel = new LeaveRuleMasterViewModel();
                        _LeaveRuleMasterViewModel.LeaveRuleMasterDTO = item;
                        listLeaveRuleMasterViewModel.Add(_LeaveRuleMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveRuleMasterViewModel;
        }      

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveRuleMasterViewModel> filteredLeaveRuleMaster;
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
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
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
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "NumberOfLeaves";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "MaxLeaveAccumulated";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "IsLocked";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LeaveDescription Like '%" + param.sSearch + "%' or LeaveRuleDescription Like '%" + param.sSearch + "%' or NumberOfLeaves Like '%" + param.sSearch + "%' or MaxLeaveAccumulated Like '%" + param.sSearch + "%' or IsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {

                //string[] splitCentreCode = CentreCode.Split(':');
            
                var centreCode = CentreCode;
                var RoleID = "";
                var UserType = Session["UserType"];
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                //centerCode = splitCentreCode[0];

                filteredLeaveRuleMaster = GetLeaveRuleMasterRecords(out TotalRecords, !string.IsNullOrEmpty(CentreCode) ? CentreCode.Split(':')[0] : string.Empty);
            }
            else
            {
                filteredLeaveRuleMaster = new List<LeaveRuleMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveRuleMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveDescription), Convert.ToString(c.LeaveRuleDescription), Convert.ToString(c.NumberOfLeaves), Convert.ToString(c.MaxLeaveAccumulated), Convert.ToString(c.IsLocked), Convert.ToString(c.IsActive), Convert.ToString(c.ID), Convert.ToString(c.LeaveMasterID),Convert.ToString(c.IsLeaveAccumulatePeriodically),Convert.ToString(c.NumberOfMonths),Convert.ToString(c.NumberOfAccumulatedLeaves) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


