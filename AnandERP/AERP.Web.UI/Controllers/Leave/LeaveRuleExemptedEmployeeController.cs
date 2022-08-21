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
using AERP.DataProvider;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveRuleExemptedEmployeeController : BaseController
    {
        ILeaveRuleExemptedEmployeeBA _ILeaveRuleExemptedEmployeeBA = null;
        ILeaveRuleExemptedEmployeeViewModel _LeaveRuleExemptedEmployeeViewModel = null;
        ILeaveRuleMasterBA _ILeaveRuleMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveRuleExemptedEmployeeController()
        {
            _ILeaveRuleExemptedEmployeeBA = new LeaveRuleExemptedEmployeeBA();
            _LeaveRuleExemptedEmployeeViewModel = new LeaveRuleExemptedEmployeeViewModel();
            _ILeaveRuleMasterBA = new LeaveRuleMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveRuleExemptedEmployee/Index.cshtml");
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
                        return View("/Views/Leave/LeaveRuleExemptedEmployee/Index.cshtml");
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
                    _LeaveRuleExemptedEmployeeViewModel.CentreCode = splitCentreCode[0];
                }
                else
                {
                    _LeaveRuleExemptedEmployeeViewModel.CentreCode = centerCode;
                    //_LeaveRuleExemptedEmployeeViewModel.EntityLevel = null;
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
                        _LeaveRuleExemptedEmployeeViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveRuleExemptedEmployeeViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveRuleExemptedEmployeeViewModel.ListGetAdminRoleApplicableCentre)
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
                        _LeaveRuleExemptedEmployeeViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveRuleExemptedEmployeeViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeaveRuleExemptedEmployeeViewModel.CentreCode = centerCode;
                _LeaveRuleExemptedEmployeeViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveRuleExemptedEmployee/List.cshtml", _LeaveRuleExemptedEmployeeViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetLeaveRuleByEmployeeID(string EmployeeID, string CentreCode)
        {
            LeaveRuleExemptedEmployeeViewModel model = new LeaveRuleExemptedEmployeeViewModel();
            string splitedCentreCode1 = string.Empty;
            if (CentreCode != null)
            {
                var splitedCentreCode = CentreCode.Split(':');
                splitedCentreCode1 = splitedCentreCode[0];
            }
          
            //List<LeaveRuleMaster> leaveRuleMasterList = GetListLeaveRuleStatusByEmployeeID(EmployeeID, splitedCentreCode1);
            //List<SelectListItem> leaveRuleMaster = new List<SelectListItem>();
            //foreach (LeaveRuleMaster item in leaveRuleMasterList)
            //{
            //    leaveRuleMaster.Add(new SelectListItem { Text = item.LeaveRuleDescription + " (" + item.LeaveCode + ")", Value = item.ID.ToString() + "~" + item.LeaveMasterID });
            //}
            //ViewBag.LeaveRuleMaster = new SelectList(leaveRuleMaster, "Value", "Text");


            ViewData["LeaveRuleList"] = GetListLeaveRuleStatusByEmployeeID(EmployeeID, splitedCentreCode1);

            return PartialView("/Views/Leave/LeaveRuleExemptedEmployee/DropDownListForLeavRule.cshtml", ViewData["LeaveRuleList"]);

        }

        [HttpGet]
        public ActionResult Create(string CentreCode, string CentreName)
        {
            LeaveRuleExemptedEmployeeViewModel model = new LeaveRuleExemptedEmployeeViewModel();
            var splitedCentreCode = CentreCode.Split(':');
            model.CentreName = CentreName;
            //    List<LeaveRuleMaster> leaveRuleMasterList = GetListLeaveRuleMaster(null, splitedCentreCode[0]);
            List<SelectListItem> leaveRuleMaster = new List<SelectListItem>();
            //foreach (LeaveRuleMaster item in leaveRuleMasterList)
            //{
            //    leaveRuleMaster.Add(new SelectListItem { Text = item.LeaveRuleDescription + " (" + item.LeaveCode + ")", Value = item.ID.ToString() + "~" + item.LeaveMasterID });
            //}
            ViewBag.LeaveRuleMaster = new SelectList(leaveRuleMaster, "Value", "Text");

            return PartialView("/Views/Leave/LeaveRuleExemptedEmployee/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(LeaveRuleExemptedEmployeeViewModel model)
        {
            try
            {

                if (model != null && model.LeaveRuleExemptedEmployeeDTO != null)
                {
                    model.LeaveRuleExemptedEmployeeDTO.ConnectionString = _connectioString;
                    model.LeaveRuleExemptedEmployeeDTO.LeaveRuleIDs = model.LeaveRuleIDs;
                    model.LeaveRuleExemptedEmployeeDTO.EmployeeID = model.EmployeeID;
                    model.LeaveRuleExemptedEmployeeDTO.FromDate = model.FromDate;
                    model.LeaveRuleExemptedEmployeeDTO.UptoDate = model.UptoDate;

                    if (Convert.ToString(Session["UserType"]) == "A")
                    {
                        string[] CentreCodeArray = model.CentreCode.Split(':');
                        model.LeaveRuleExemptedEmployeeDTO.CentreCode = CentreCodeArray[0];
                    }
                    else
                    {
                        model.LeaveRuleExemptedEmployeeDTO.CentreCode = model.CentreCode;
                    }
                    model.LeaveRuleExemptedEmployeeDTO.IsActive = true;
                    model.LeaveRuleExemptedEmployeeDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<LeaveRuleExemptedEmployee> response = _ILeaveRuleExemptedEmployeeBA.InsertLeaveRuleExemptedEmployee(model.LeaveRuleExemptedEmployeeDTO);
                    model.LeaveRuleExemptedEmployeeDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.LeaveRuleExemptedEmployeeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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
        //public ActionResult Edit(string IDs)
        //{
        //    LeaveRuleExemptedEmployeeViewModel model = new LeaveRuleExemptedEmployeeViewModel();
        //    try
        //    {
        //        string[] RuleArray = IDs.Split('~');

        //        model.LeaveRuleExemptedEmployeeDTO.ID = Convert.ToInt32(RuleArray[0]);
        //        model.LeaveRuleExemptedEmployeeDTO.LeaveRuleDescription = RuleArray[1].Replace("$"," ");
        //        return PartialView("/Views/Leave/LeaveRuleExemptedEmployee/Edit.cshtml", model);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpPost]
        //public ActionResult Edit(LeaveRuleExemptedEmployeeViewModel model)
        //{

        //    if (model != null && model.LeaveRuleExemptedEmployeeDTO != null)
        //    {
        //        model.LeaveRuleExemptedEmployeeDTO.ConnectionString = _connectioString;
        //        model.LeaveRuleExemptedEmployeeDTO.ID = model.ID;
        //        model.LeaveRuleExemptedEmployeeDTO.IsActive = false;
        //        model.LeaveRuleExemptedEmployeeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
        //        IBaseEntityResponse<LeaveRuleExemptedEmployee> response = _LeaveRuleExemptedEmployeeServiceAccess.UpdateLeaveRuleExemptedEmployee(model.LeaveRuleExemptedEmployeeDTO);
        //        model.LeaveRuleExemptedEmployeeDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
        //        return Json(model.LeaveRuleExemptedEmployeeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Edit(string ID)
        {
            LeaveRuleExemptedEmployeeViewModel model = new LeaveRuleExemptedEmployeeViewModel();

            if (ID != null)
            {
                string[] RuleArray = ID.Split('~');

                model.LeaveRuleExemptedEmployeeDTO.ConnectionString = _connectioString;
                //model.LeaveRuleExemptedEmployeeDTO.ID = IDs;
                model.LeaveRuleExemptedEmployeeDTO.ID = Convert.ToInt32(RuleArray[0]);
                model.LeaveRuleExemptedEmployeeDTO.IsActive = false;
                model.LeaveRuleExemptedEmployeeDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<LeaveRuleExemptedEmployee> response = _ILeaveRuleExemptedEmployeeBA.UpdateLeaveRuleExemptedEmployee(model.LeaveRuleExemptedEmployeeDTO);
                //model.LeaveRuleExemptedEmployeeDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                model.LeaveRuleExemptedEmployeeDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.LeaveRuleExemptedEmployeeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            LeaveRuleExemptedEmployeeViewModel model = new LeaveRuleExemptedEmployeeViewModel();
            model.LeaveRuleExemptedEmployeeDTO = new LeaveRuleExemptedEmployee();
            model.LeaveRuleExemptedEmployeeDTO.ID = ID;
            return PartialView("/Views/Leave/LeaveRuleExemptedEmployee/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(LeaveRuleExemptedEmployeeViewModel model)
        {

            if (model.ID > 0)
            {
                LeaveRuleExemptedEmployee LeaveRuleExemptedEmployeeDTO = new LeaveRuleExemptedEmployee();
                LeaveRuleExemptedEmployeeDTO.ConnectionString = _connectioString;
                LeaveRuleExemptedEmployeeDTO.ID = model.ID;
                LeaveRuleExemptedEmployeeDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<LeaveRuleExemptedEmployee> response = _ILeaveRuleExemptedEmployeeBA.DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployeeDTO);
                model.LeaveRuleExemptedEmployeeDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.LeaveRuleExemptedEmployeeDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json("Please review your form");
            }
        }
        #endregion

        // Non-Action Method
        #region Methods

        protected List<LeaveRuleMaster> GetListLeaveRuleStatusByEmployeeID(string EmployeeID, string CentreCode)
        {
            LeaveRuleMasterSearchRequest searchRequest = new LeaveRuleMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //  searchRequest.LeaveCode = !string.IsNullOrEmpty(LeaveCode) ? LeaveCode : string.Empty;
            searchRequest.EmployeeID = Convert.ToInt32(EmployeeID);
            searchRequest.CentreCode = !string.IsNullOrEmpty(CentreCode) ? CentreCode : string.Empty;
            List<LeaveRuleMaster> listLeaveRuleMaster = new List<LeaveRuleMaster>();
            IBaseEntityCollectionResponse<LeaveRuleMaster> baseEntityCollectionResponse = _ILeaveRuleMasterBA.LeaveRuleStatusGetByCentreAndEmployee(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveRuleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLeaveRuleMaster;
        }
        [HttpPost]
        public JsonResult GetEmployeeCentrewise(string term, string centreCode)
        {
            string[] centreCodeArrray = centreCode.Split(':');
            var data = GetEmployeeCentrewiseSearchList(term, centreCodeArrray[0]);

            var result = (from r in data
                          select new
                          {
                              id = r.ID,
                              name = r.EmployeeFirstName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public IEnumerable<LeaveRuleExemptedEmployeeViewModel> GetLeaveRuleExemptedEmployeeRecords(out int TotalRecords, string CentreCode)
        {
            LeaveRuleExemptedEmployeeSearchRequest searchRequest = new LeaveRuleExemptedEmployeeSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "EmployeeID,C.DepartmentName";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<LeaveRuleExemptedEmployeeViewModel> listLeaveRuleExemptedEmployeeViewModel = new List<LeaveRuleExemptedEmployeeViewModel>();
            List<LeaveRuleExemptedEmployee> listLeaveRuleExemptedEmployee = new List<LeaveRuleExemptedEmployee>();
            IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> baseEntityCollectionResponse = _ILeaveRuleExemptedEmployeeBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveRuleExemptedEmployee = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveRuleExemptedEmployee item in listLeaveRuleExemptedEmployee)
                    {
                        LeaveRuleExemptedEmployeeViewModel _LeaveRuleExemptedEmployeeViewModel = new LeaveRuleExemptedEmployeeViewModel();
                        _LeaveRuleExemptedEmployeeViewModel.LeaveRuleExemptedEmployeeDTO = item;
                        listLeaveRuleExemptedEmployeeViewModel.Add(_LeaveRuleExemptedEmployeeViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveRuleExemptedEmployeeViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveRuleExemptedEmployeeViewModel> filteredLeaveRuleExemptedEmployee;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeID,C.DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or A.FromDate Like '%" + param.sSearch + "%' or A.UptoDate Like '%" + param.sSearch + "%' or E.LeaveRuleDescription Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "B.EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or A.FromDate Like '%" + param.sSearch + "%' or A.UptoDate Like '%" + param.sSearch + "%' or E.LeaveRuleDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "A.FromDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or A.FromDate Like '%" + param.sSearch + "%' or A.UptoDate Like '%" + param.sSearch + "%' or E.LeaveRuleDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.IsActive";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "C.DepartmentName Like '%" + param.sSearch + "%' or B.EmployeeFirstName Like '%" + param.sSearch + "%' or A.FromDate Like '%" + param.sSearch + "%' or A.UptoDate Like '%" + param.sSearch + "%' or E.LeaveRuleDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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


                filteredLeaveRuleExemptedEmployee = GetLeaveRuleExemptedEmployeeRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveRuleExemptedEmployee = new List<LeaveRuleExemptedEmployeeViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveRuleExemptedEmployee.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.DepartmentName), Convert.ToString(c.EmployeeFullName) + "(" + Convert.ToString(c.DepartmentName) + ")", Convert.ToString(c.LeaveRuleDescription + "(" + c.LeaveCode + ")"), Convert.ToString(c.FromDate), Convert.ToString(c.UptoDate), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}