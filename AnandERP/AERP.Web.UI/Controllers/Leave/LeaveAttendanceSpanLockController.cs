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
    public class LeaveAttendanceSpanLockController : BaseController
    {
        ILeaveAttendanceSpanLockBA _ILeaveAttendanceSpanLockBA = null;
        ILeaveAttendanceSpanLockViewModel _LeaveAttendanceSpanLockViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveAttendanceSpanLockController()
        {
            _ILeaveAttendanceSpanLockBA = new LeaveAttendanceSpanLockBA();
            _LeaveAttendanceSpanLockViewModel = new LeaveAttendanceSpanLockViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveAttendanceSpanLock/Index.cshtml");
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
                        return View("/Views/Leave/LeaveAttendanceSpanLock/Index.cshtml");
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
                    _LeaveAttendanceSpanLockViewModel.CentreCode = splitCentreCode[0];
                    // _LeaveAttendanceSpanLockViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _LeaveAttendanceSpanLockViewModel.CentreCode = centerCode;
                    //_LeaveAttendanceSpanLockViewModel.EntityLevel = null;
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
                        _LeaveAttendanceSpanLockViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveAttendanceSpanLockViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveAttendanceSpanLockViewModel.ListGetAdminRoleApplicableCentre)
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID,0);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveAttendanceSpanLockViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveAttendanceSpanLockViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeaveAttendanceSpanLockViewModel.CentreCode = centerCode;
                _LeaveAttendanceSpanLockViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveAttendanceSpanLock/List.cshtml", _LeaveAttendanceSpanLockViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string centreCode)
        {
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                string[] CentreCodeArray = centreCode.Split(':');
                _LeaveAttendanceSpanLockViewModel.CentreCode = CentreCodeArray[0];
            }
            else
            {
                _LeaveAttendanceSpanLockViewModel.CentreCode = centreCode;
            }

          
            _LeaveAttendanceSpanLockViewModel.LeaveAttendanceSpanLockDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<LeaveAttendanceSpanLock> response = _ILeaveAttendanceSpanLockBA.SelectByCentreCode(_LeaveAttendanceSpanLockViewModel.LeaveAttendanceSpanLockDTO);

            if (response != null && response.Entity != null)
            {
                _LeaveAttendanceSpanLockViewModel.LeaveAttendanceSpanLockDTO.SpanFromDate = response.Entity.SpanUptoDate;
            }


            return View("/Views/Leave/LeaveAttendanceSpanLock/Create.cshtml", _LeaveAttendanceSpanLockViewModel);
        }

        [HttpPost]
        public ActionResult Create(LeaveAttendanceSpanLockViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveAttendanceSpanLockDTO != null)
                    {
                        model.LeaveAttendanceSpanLockDTO.ConnectionString = _connectioString;
                        if (Convert.ToString(Session["UserType"]) == "A")
                        {
                            string[] CentreCodeArray = model.CentreCode.Split(':');
                            model.LeaveAttendanceSpanLockDTO.CentreCode = CentreCodeArray[0];
                        }
                        else
                        {
                            model.LeaveAttendanceSpanLockDTO.CentreCode = model.CentreCode;
                        }
                        model.LeaveAttendanceSpanLockDTO.SpanFromDate = model.SpanFromDate;
                        model.LeaveAttendanceSpanLockDTO.SpanUptoDate = model.SpanUptoDate;
                      
                        model.LeaveAttendanceSpanLockDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveAttendanceSpanLock> response = _ILeaveAttendanceSpanLockBA.InsertLeaveAttendanceSpanLock(model.LeaveAttendanceSpanLockDTO);
                        model.LeaveAttendanceSpanLockDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.LeaveAttendanceSpanLockDTO.errorMessage, JsonRequestBehavior.AllowGet);

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

    
        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    LeaveAttendanceSpanLockViewModel model = new LeaveAttendanceSpanLockViewModel();
        //    model.LeaveAttendanceSpanLockDTO = new LeaveAttendanceSpanLock();
        //    model.LeaveAttendanceSpanLockDTO.ID = ID;
        //    return PartialView("/Views/Leave/LeaveAttendanceSpanLock/Delete.cshtml", _LeaveAttendanceSpanLockViewModel);
        //}

        //[HttpPost]
        //public ActionResult Delete(LeaveAttendanceSpanLockViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            LeaveAttendanceSpanLock leaveAttendanceSpanLockDTO = new LeaveAttendanceSpanLock();
        //            leaveAttendanceSpanLockDTO.ConnectionString = _connectioString;
        //            leaveAttendanceSpanLockDTO.ID = model.ID;
        //            leaveAttendanceSpanLockDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<LeaveAttendanceSpanLock> response = _LeaveAttendanceSpanLockServiceAccess.DeleteLeaveAttendanceSpanLock(leaveAttendanceSpanLockDTO);
        //            model.LeaveAttendanceSpanLockDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.LeaveAttendanceSpanLockDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            LeaveAttendanceSpanLockViewModel model = new LeaveAttendanceSpanLockViewModel();
            
                if (ID > 0)
                {
                    LeaveAttendanceSpanLock leaveAttendanceSpanLockDTO = new LeaveAttendanceSpanLock();
                    leaveAttendanceSpanLockDTO.ConnectionString = _connectioString;
                    leaveAttendanceSpanLockDTO.ID = ID;
                    //leaveAttendanceSpanLockDTO.ID = model.ID;
                    leaveAttendanceSpanLockDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveAttendanceSpanLock> response = _ILeaveAttendanceSpanLockBA.DeleteLeaveAttendanceSpanLock(leaveAttendanceSpanLockDTO);
                    //model.LeaveAttendanceSpanLockDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    model.LeaveAttendanceSpanLockDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.LeaveAttendanceSpanLockDTO.errorMessage, JsonRequestBehavior.AllowGet);
            
            
        }
        #endregion

        // Non-Action Methods
        #region Methods
        public IEnumerable<LeaveAttendanceSpanLockViewModel> GetLeaveAttendanceSpanLockRecords(out int TotalRecords, string CentreCode)
        {
            LeaveAttendanceSpanLockSearchRequest searchRequest = new LeaveAttendanceSpanLockSearchRequest();
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
            List<LeaveAttendanceSpanLockViewModel> listLeaveAttendanceSpanLockViewModel = new List<LeaveAttendanceSpanLockViewModel>();
            List<LeaveAttendanceSpanLock> listLeaveAttendanceSpanLock = new List<LeaveAttendanceSpanLock>();
            IBaseEntityCollectionResponse<LeaveAttendanceSpanLock> baseEntityCollectionResponse = _ILeaveAttendanceSpanLockBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveAttendanceSpanLock = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveAttendanceSpanLock item in listLeaveAttendanceSpanLock)
                    {
                        LeaveAttendanceSpanLockViewModel _LeaveAttendanceSpanLockViewModel = new LeaveAttendanceSpanLockViewModel();
                        _LeaveAttendanceSpanLockViewModel.LeaveAttendanceSpanLockDTO = item;
                        listLeaveAttendanceSpanLockViewModel.Add(_LeaveAttendanceSpanLockViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveAttendanceSpanLockViewModel;
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveAttendanceSpanLockViewModel> filteredLeaveAttendanceSpanLock;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SpanFromDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SpanFromDate Like '%" + param.sSearch + "%' or SpanUptoDate Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "SpanUptoDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SpanFromDate Like '%" + param.sSearch + "%' or SpanUptoDate Like '%" + param.sSearch + "%'";
                    }
                    break;
                case 2:
                    _sortBy = "IsSpanLock";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SpanFromDate Like '%" + param.sSearch + "%' or SpanUptoDate Like '%" + param.sSearch + "%'";
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
                filteredLeaveAttendanceSpanLock = GetLeaveAttendanceSpanLockRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveAttendanceSpanLock = new List<LeaveAttendanceSpanLockViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveAttendanceSpanLock.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.SpanFromDate), Convert.ToString(c.SpanUptoDate), Convert.ToString(c.IsSpanLock), Convert.ToString(c.ID), Convert.ToString(c.MaxID), Convert.ToString(c.IsSpanLockCount) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


