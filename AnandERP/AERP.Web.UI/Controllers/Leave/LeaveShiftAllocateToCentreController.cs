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
    public class LeaveShiftAllocateToCentreController : BaseController
    {
        ILeaveShiftAllocateToCentreBA _ILeaveShiftAllocateToCentreBA = null;
        ILeaveShiftAllocateToCentreViewModel _leaveShiftAllocateToCentreViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveShiftAllocateToCentreController()
        {
            _ILeaveShiftAllocateToCentreBA = new LeaveShiftAllocateToCentreBA();
            _leaveShiftAllocateToCentreViewModel = new LeaveShiftAllocateToCentreViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveShiftAllocateToCentre/Index.cshtml");
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
                        return View("/Views/Leave/LeaveShiftAllocateToCentre/Index.cshtml");
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
                        _leaveShiftAllocateToCentreViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _leaveShiftAllocateToCentreViewModel.EntityLevel = "Centre";

                    foreach (var b in _leaveShiftAllocateToCentreViewModel.ListGetAdminRoleApplicableCentre)
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
                        _leaveShiftAllocateToCentreViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _leaveShiftAllocateToCentreViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _leaveShiftAllocateToCentreViewModel.CentreCode = centerCode;
                _leaveShiftAllocateToCentreViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveShiftAllocateToCentre/List.cshtml", _leaveShiftAllocateToCentreViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[HttpGet]
        //public ActionResult Create(string CentreCode, string centreName, string ShiftDesc, int ShiftID)
        //{
        //    try
        //    {
        //        LeaveShiftAllocateToCentreViewModel model = new LeaveShiftAllocateToCentreViewModel();
        //        model.LeaveShiftAllocateToCentreDTO.CentreName = centreName.Replace('~', ' ');
        //        model.LeaveShiftAllocateToCentreDTO.ShiftDesc = ShiftDesc.Replace('~', ' ');
        //        model.LeaveShiftAllocateToCentreDTO.CentreCode = CentreCode.ToString();
        //        model.LeaveShiftAllocateToCentreDTO.ShiftID = ShiftID;
        //        return PartialView("/Views/Leave/LeaveShiftAllocateToCentre/Create.cshtml", model); 
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Create(LeaveShiftAllocateToCentreViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (model != null && model.LeaveShiftAllocateToCentreDTO != null)
        //            {
        //                model.LeaveShiftAllocateToCentreDTO.ConnectionString = _connectioString;
        //                string[] splitCentreCode = model.CentreCode.Split(':');
        //                var centreCode = splitCentreCode[0];                     
        //                model.LeaveShiftAllocateToCentreDTO.CentreCode = centreCode;
        //                model.LeaveShiftAllocateToCentreDTO.ShiftID = model.ShiftID;
        //                model.LeaveShiftAllocateToCentreDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<LeaveShiftAllocateToCentre> response = _leaveShiftAllocateToCentreServiceAccess.InsertLeaveShiftAllocateToCentre(model.LeaveShiftAllocateToCentreDTO);
        //                model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
        //            }
        //            return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpGet]
        //public ActionResult Edit(string centreName, string ShiftDesc, int ID)
        //{
        //    try
        //    {
        //        LeaveShiftAllocateToCentreViewModel model = new LeaveShiftAllocateToCentreViewModel();
        //        model.LeaveShiftAllocateToCentreDTO = new LeaveShiftAllocateToCentre();
        //        model.LeaveShiftAllocateToCentreDTO.ID = ID;
        //        model.LeaveShiftAllocateToCentreDTO.CentreName = centreName.Replace('~', ' ');
        //        model.LeaveShiftAllocateToCentreDTO.ShiftDesc = ShiftDesc.Replace('~', ' ');
        //        model.LeaveShiftAllocateToCentreDTO.ConnectionString = _connectioString;
        //        IBaseEntityResponse<LeaveShiftAllocateToCentre> response = _leaveShiftAllocateToCentreServiceAccess.SelectByID(model.LeaveShiftAllocateToCentreDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.LeaveShiftAllocateToCentreDTO.ID = response.Entity.ID;
        //            model.LeaveShiftAllocateToCentreDTO.ShiftID = response.Entity.ShiftID;
        //            model.LeaveShiftAllocateToCentreDTO.ShiftDesc = response.Entity.ShiftDesc;
        //            model.LeaveShiftAllocateToCentreDTO.CentreCode = response.Entity.CentreCode;
        //        }
        //        return PartialView("/Views/Leave/LeaveShiftAllocateToCentre/Edit.cshtml", model); 
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(LeaveShiftAllocateToCentreViewModel model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (model != null && model.LeaveShiftAllocateToCentreDTO != null)
        //            {
        //                model.LeaveShiftAllocateToCentreDTO.ConnectionString = _connectioString;
        //                model.LeaveShiftAllocateToCentreDTO.ID = model.ID;
        //                model.LeaveShiftAllocateToCentreDTO.CentreCode = model.CentreCode;
        //                model.LeaveShiftAllocateToCentreDTO.ShiftID = model.ShiftID;
        //                model.LeaveShiftAllocateToCentreDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<LeaveShiftAllocateToCentre> response = _leaveShiftAllocateToCentreServiceAccess.UpdateLeaveShiftAllocateToCentre(model.LeaveShiftAllocateToCentreDTO);
        //                model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //            }
        //            return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Create(string CentreCode, int ShiftID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LeaveShiftAllocateToCentreViewModel model = new LeaveShiftAllocateToCentreViewModel();
                    
                        model.LeaveShiftAllocateToCentreDTO.ConnectionString = _connectioString;
                        string[] splitCentreCode = CentreCode.Split(':');
                        var centreCode = splitCentreCode[0];
                        model.LeaveShiftAllocateToCentreDTO.CentreCode = centreCode;
                        model.LeaveShiftAllocateToCentreDTO.ShiftID = ShiftID;
                        model.LeaveShiftAllocateToCentreDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveShiftAllocateToCentre> response = _ILeaveShiftAllocateToCentreBA.InsertLeaveShiftAllocateToCentre(model.LeaveShiftAllocateToCentreDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
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

        //[HttpPost]
        public ActionResult Edit(int ID, string CentreCode, int ShiftID)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    LeaveShiftAllocateToCentreViewModel model = new LeaveShiftAllocateToCentreViewModel();
                        model.LeaveShiftAllocateToCentreDTO.ConnectionString = _connectioString;
                        model.LeaveShiftAllocateToCentreDTO.ID = ID;
                        model.LeaveShiftAllocateToCentreDTO.CentreCode = CentreCode;
                        model.LeaveShiftAllocateToCentreDTO.ShiftID = ShiftID;
                        model.LeaveShiftAllocateToCentreDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveShiftAllocateToCentre> response = _ILeaveShiftAllocateToCentreBA.UpdateLeaveShiftAllocateToCentre(model.LeaveShiftAllocateToCentreDTO);
                        //model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    
                    return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
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

        //// Non-Action Methods
        #region Methods
        public IEnumerable<LeaveShiftAllocateToCentreViewModel> GetLeaveShiftAllocateToCentreRecords(out int TotalRecords, string CentreCode)
        {
            LeaveShiftAllocateToCentreSearchRequest searchRequest = new LeaveShiftAllocateToCentreSearchRequest();
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
            List<LeaveShiftAllocateToCentreViewModel> listLeaveShiftAllocateToCentreViewModel = new List<LeaveShiftAllocateToCentreViewModel>();
            List<LeaveShiftAllocateToCentre> listLeaveShiftAllocateToCentre = new List<LeaveShiftAllocateToCentre>();
            IBaseEntityCollectionResponse<LeaveShiftAllocateToCentre> baseEntityCollectionResponse = _ILeaveShiftAllocateToCentreBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveShiftAllocateToCentre = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveShiftAllocateToCentre item in listLeaveShiftAllocateToCentre)
                    {
                        LeaveShiftAllocateToCentreViewModel _leaveShiftAllocateToCentreViewModel = new LeaveShiftAllocateToCentreViewModel();
                        _leaveShiftAllocateToCentreViewModel.LeaveShiftAllocateToCentreDTO = item;
                        listLeaveShiftAllocateToCentreViewModel.Add(_leaveShiftAllocateToCentreViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveShiftAllocateToCentreViewModel;
        }

        #endregion

        //// AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveShiftAllocateToCentreViewModel> filteredLeaveShiftAllocateToCentre;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ShiftDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ShiftDescription Like '%" + param.sSearch + "%'  ";         //this "if" block is added for search functionality
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
                filteredLeaveShiftAllocateToCentre = GetLeaveShiftAllocateToCentreRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveShiftAllocateToCentre = new List<LeaveShiftAllocateToCentreViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveShiftAllocateToCentre.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LeaveShiftAllocateToCentreDTO.ShiftDesc), Convert.ToString(c.LeaveShiftAllocateToCentreDTO.Status), Convert.ToString(c.LeaveShiftAllocateToCentreDTO.ShiftID), Convert.ToString(c.LeaveShiftAllocateToCentreDTO.ID), Convert.ToString(c.LeaveShiftAllocateToCentreDTO.IsShiftIsLocked) };
            
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


