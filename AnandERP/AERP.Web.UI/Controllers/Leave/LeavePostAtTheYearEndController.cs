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
    public class LeavePostAtTheYearEndController : BaseController
    {
        ILeavePostBA _ILeavePostBA = null;
        ILeaveSessionBA _ILeaveSessionBA = null;
        ILeavePostViewModel _LeavePostViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeavePostAtTheYearEndController()
        {
            _ILeavePostBA = new LeavePostBA();
            _ILeaveSessionBA = new LeaveSessionBA();
            _LeavePostViewModel = new LeavePostViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeavePostAtTheYearEnd/Index.cshtml");
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID,0);
                    if (listAdminRoleApplicableDetails.Count > 0)
                    {
                        return View("/Views/Leave/LeavePostAtTheYearEnd/Index.cshtml");
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

        public ActionResult List(string actionMode, string centerCode, string centreName, string SelectedFromSessionID, string SelectedToSessionID)
        {
            try
            {
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _LeavePostViewModel.CentreCode = splitCentreCode[0];
                    // _LeavePostViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                    IEnumerable<LeavePostViewModel> filteredLeavePost = GetLeavePostAtTheYearEndRecords(_LeavePostViewModel.CentreCode,Convert.ToInt32(SelectedFromSessionID),Convert.ToInt32(SelectedToSessionID));
                    int numberOfColumn = 0;
                    List<String> listLeaveType = new List<String>();
                    if (filteredLeavePost.Count() > 0)
                    {
                        ViewBag.Data = 1;
                        ViewBag.ListLeavePost = filteredLeavePost;

                        foreach (var item in filteredLeavePost)
                        {
                            string[] splitedLeaveList = item.LeaveList.Split(',');
                            if (splitedLeaveList.Length > numberOfColumn)
                            {
                               // numberOfColumn = splitedLeaveList.Length;
                            }

                            foreach (var a in splitedLeaveList)
                            {
                                var b = a.Split('#');
                                if (!listLeaveType.Contains(b[0].Trim()))
                                {
                                    listLeaveType.Add(b[0].Trim());
                                    numberOfColumn = numberOfColumn + 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Data = 0;
                    }
                    ViewBag.numberOfcolumn = numberOfColumn;
                    ViewBag.listLeaveType = listLeaveType;
                    ViewBag.listLeaveTypeCount = listLeaveType.Count;
                    ViewBag.TotalRecords = filteredLeavePost.Count();
                    _LeavePostViewModel.ListFromLeaveSession = GetListLeaveSession(splitCentreCode[0]);
                    _LeavePostViewModel.ListToLeaveSession = GetListLeaveSession(splitCentreCode[0]);
                }
                else
                {
                    _LeavePostViewModel.CentreCode = centerCode;
                    ViewBag.Data = 0;
                    ViewBag.ListLeavePost = "";
                    ViewBag.numberOfcolumn = 0;
                    ViewBag.listLeaveType = "";
                    ViewBag.TotalRecords = 0;
                    //_LeavePostViewModel.EntityLevel = null;
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
                        _LeavePostViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeavePostViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeavePostViewModel.ListGetAdminRoleApplicableCentre)
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0); ;
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _LeavePostViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeavePostViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeavePostViewModel.CentreCode = centerCode;
                _LeavePostViewModel.CentreName = centreName;
                _LeavePostViewModel.SelectedFromSessionID = Convert.ToInt32(SelectedFromSessionID);
                _LeavePostViewModel.SelectedToSessionID = Convert.ToInt32(SelectedToSessionID);
             
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeavePostAtTheYearEnd/List.cshtml", _LeavePostViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(LeavePostViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeavePostDTO != null)
                    {
                        model.LeavePostDTO.ConnectionString = _connectioString;
                        model.LeavePostDTO.CentreCode = model.CentreCode;
                        model.LeavePostDTO.SelectedFromSessionID = model.SelectedFromSessionID;
                        model.LeavePostDTO.SelectedToSessionID = model.SelectedToSessionID; 
                        model.LeavePostDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeavePost> response = _ILeavePostBA.InsertLeavePostAtYearEnd(model.LeavePostDTO);
                        model.LeavePostDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeavePostDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            _LeavePostViewModel.LeavePostDTO = new LeavePost();
            _LeavePostViewModel.LeavePostDTO.LeaveMasterID = Convert.ToInt32(ID);
            _LeavePostViewModel.LeavePostDTO.LeaveDescription = LeaveDescription.Replace('~', ' ');
            _LeavePostViewModel.LeavePostDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeavePost> response = _ILeavePostBA.SelectByID(_LeavePostViewModel.LeavePostDTO);

            if (response != null && response.Entity != null)
            {
                _LeavePostViewModel.LeavePostDTO.CentreCode = response.Entity.CentreCode;
            }
            if ("1" == Mode)
            {
                return View("/Views/Leave/LeavePostAtTheYearEnd/Edit.cshtml", _LeavePostViewModel);
            }
            else
            {
                return View("/Views/Leave/LeavePostAtTheYearEnd/ViewDeatils.cshtml", _LeavePostViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(LeavePostViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeavePostDTO != null)
                    {
                        if (model != null && model.LeavePostDTO != null)
                        {
                            model.LeavePostDTO.ConnectionString = _connectioString;
                            model.LeavePostDTO.LeaveMasterID = model.LeaveMasterID;
                            model.LeavePostDTO.CentreCode = model.CentreCode;
                            //model.LeavePostDTO.LeaveMasterID = model.LeaveMasterID;
                            //model.LeavePostDTO.LeaveRuleDescription = model.LeaveRuleDescription;
                            //model.LeavePostDTO.NumberOfLeaves = model.NumberOfLeaves;
                            //model.LeavePostDTO.MaxLeaveAtTime = model.MaxLeaveAtTime;
                            //model.LeavePostDTO.MinimumLeaveEncash = model.MinimumLeaveEncash;
                            //model.LeavePostDTO.MaxLeaveEncash = model.MaxLeaveEncash;
                            //model.LeavePostDTO.MaxLeaveAccumulated = model.MaxLeaveAccumulated;
                            //model.LeavePostDTO.MinServiceRequiredInMonth = model.MinServiceRequiredInMonth;
                            //model.LeavePostDTO.AttendDaysRequired = model.AttendDaysRequired;
                            //model.LeavePostDTO.MinLeavesAtTime = model.MinLeavesAtTime;
                            model.LeavePostDTO.IsActive = model.IsActive;
                            model.LeavePostDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<LeavePost> response = _ILeavePostBA.UpdateLeavePost(model.LeavePostDTO);
                            model.LeavePostDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.LeavePostDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewSessionDetails(string LeavePostID, string CentreCode, string CentreName, string Mode)
        {
            _LeavePostViewModel.LeavePostDTO = new LeavePost();
            _LeavePostViewModel.LeavePostDTO.LeaveMasterID = Convert.ToInt32(LeavePostID);
            _LeavePostViewModel.LeavePostDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeavePost> response = _ILeavePostBA.SelectByID(_LeavePostViewModel.LeavePostDTO);

            if (response != null && response.Entity != null)
            {
                _LeavePostViewModel.LeavePostDTO.LeaveMasterID = response.Entity.LeaveMasterID;
                //_LeavePostViewModel.LeavePostDTO.LeavePostName = response.Entity.LeavePostName;
                //_LeavePostViewModel.LeavePostDTO.LeavePostFromDate = response.Entity.LeavePostFromDate;
                //_LeavePostViewModel.LeavePostDTO.LeavePostUptoDate = response.Entity.LeavePostUptoDate;
                _LeavePostViewModel.LeavePostDTO.CentreCode = response.Entity.CentreCode;
                _LeavePostViewModel.LeavePostDTO.CentreName = CentreName;
                //_LeavePostViewModel.LeavePostDTO.IsCurrentLeavePost = response.Entity.IsCurrentLeavePost;

            }
            return View("/Views/Leave/LeavePostAtTheYearEnd/ViewSessionDetails.cshtml", _LeavePostViewModel);
        }

        [HttpGet]
        public ActionResult CreateLeavePostDetails(string LeavePostID, string centreCode, string centreName, string Mode)
        {
            _LeavePostViewModel.LeavePostDTO = new LeavePost();
            _LeavePostViewModel.LeavePostDTO.LeaveMasterID = Convert.ToInt32(LeavePostID);
            _LeavePostViewModel.LeavePostDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeavePost> response = _ILeavePostBA.SelectByID(_LeavePostViewModel.LeavePostDTO);

            if (response != null && response.Entity != null)
            {
                _LeavePostViewModel.LeavePostDTO.LeaveMasterID = response.Entity.LeaveMasterID;
                //_LeavePostViewModel.LeavePostDTO.LeavePostName = response.Entity.LeavePostName;
                //_LeavePostViewModel.LeavePostDTO.LeavePostFromDate = response.Entity.LeavePostFromDate;
                //_LeavePostViewModel.LeavePostDTO.LeavePostUptoDate = response.Entity.LeavePostUptoDate;
                _LeavePostViewModel.LeavePostDTO.CentreCode = response.Entity.CentreCode;
                _LeavePostViewModel.LeavePostDTO.CentreName = centreName;
                //_LeavePostViewModel.LeavePostDTO.IsCurrentLeavePost = response.Entity.IsCurrentLeavePost;

            }
            return View("/Views/Leave/LeavePostAtTheYearEnd/CreateLeavePostDetails.cshtml", _LeavePostViewModel);
        }

        #endregion

        // Non-Action Methods
        #region Methods
        public IEnumerable<LeavePostViewModel> GetLeavePostAtTheYearEndRecords(string CentreCode,int FromLeaveSessionID,int ToLeaveSessionID)
        {
            LeavePostSearchRequest searchRequest = new LeavePostSearchRequest();
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
                    searchRequest.FromLeaveSessionID = FromLeaveSessionID;
                    searchRequest.ToLeaveSessionID = ToLeaveSessionID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.FromLeaveSessionID = FromLeaveSessionID;
                    searchRequest.ToLeaveSessionID = ToLeaveSessionID;
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
                 searchRequest.FromLeaveSessionID = FromLeaveSessionID;
                    searchRequest.ToLeaveSessionID = ToLeaveSessionID;
            }
            List<LeavePostViewModel> listLeavePostViewModel = new List<LeavePostViewModel>();
            List<LeavePost> listLeavePost = new List<LeavePost>();
            IBaseEntityCollectionResponse<LeavePost> baseEntityCollectionResponse = _ILeavePostBA.GetLeaveSummaryAtTheYearEndBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeavePost = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeavePost item in listLeavePost)
                    {
                        LeavePostViewModel _LeavePostViewModel = new LeavePostViewModel();
                        _LeavePostViewModel.LeavePostDTO = item;
                        listLeavePostViewModel.Add(_LeavePostViewModel);
                    }
                }
            }
            // TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeavePostViewModel;
        }


        protected List<LeaveSession> GetListToLeaveSession(string CentreCode,string FromLeaveSessionID)
        {
            LeaveSessionSearchRequest searchRequest = new LeaveSessionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);          
            searchRequest.CentreCode = CentreCode;
            searchRequest.LeaveSessionID = Convert.ToInt32(FromLeaveSessionID);
            //searchRequest.SearchType = 1;
            List<LeaveSession> listLeaveSession = new List<LeaveSession>();
            IBaseEntityCollectionResponse<LeaveSession> baseEntityCollectionResponse = _ILeaveSessionBA.GetByFromLeaveSessionID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveSession = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveSession;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetToLeaveSessionByCentreCodeAndFromLeaveSession(string CentreCode, string FromLeaveSessionID)
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
            if (String.IsNullOrEmpty(FromLeaveSessionID))
            {
                throw new ArgumentNullException("FromLeaveSessionID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var session = GetListToLeaveSession(CentreCode, FromLeaveSessionID);
            var result = (from s in session
                          select new
                          {
                              id = s.LeaveSessionID,
                              name = s.LeaveSessionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords = 0;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeavePostViewModel> filteredLeavePost;
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
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }
                //centerCode = splitCentreCode[0];

                filteredLeavePost = GetLeavePostAtTheYearEndRecords(centreCode,5,7);
            }
            else
            {
                filteredLeavePost = new List<LeavePostViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeavePost.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeFirstName + " " + c.EmployeeMiddleName + " " + c.EmployeeLastName), Convert.ToString(c.EmployeeID), Convert.ToString(c.LeaveList), Convert.ToString(c.LeaveSessionID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


