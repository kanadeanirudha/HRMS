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
    public class EmployeeShiftMasterController : BaseController
    {
        IEmployeeShiftMasterBA _EmployeeShiftMasterServiceAccess = null;
        IEmployeeShiftMasterViewModel _employeeShiftMasterViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeShiftMasterController()
        {
            _EmployeeShiftMasterServiceAccess = new EmployeeShiftMasterBA();
            _employeeShiftMasterViewModel = new EmployeeShiftMasterViewModel();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Employee/EmployeeShiftMaster/Index.cshtml");
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
                        return View("/Views/Employee/EmployeeShiftMaster/Index.cshtml");
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
                    _employeeShiftMasterViewModel.CentreCode = splitCentreCode[0];
                    // _employeeShiftMasterViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _employeeShiftMasterViewModel.CentreCode = centerCode;
                    //_employeeShiftMasterViewModel.EntityLevel = null;
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
                        _employeeShiftMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    // _employeeShiftMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _employeeShiftMasterViewModel.ListGetAdminRoleApplicableCentre)
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
                        _employeeShiftMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _employeeShiftMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _employeeShiftMasterViewModel.CentreCode = centerCode;
                _employeeShiftMasterViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeeShiftMaster/List.cshtml", _employeeShiftMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateShift()
        {
            return View("/Views/Employee/EmployeeShiftMaster/CreateShift.cshtml", _employeeShiftMasterViewModel);
        }

        [HttpPost]
        public ActionResult CreateShift(EmployeeShiftMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeShiftMasterDTO != null)
                    {
                        model.EmployeeShiftMasterDTO.ConnectionString = _connectioString;
                        model.EmployeeShiftMasterDTO.EmployeeShiftDescription = model.EmployeeShiftDescription;
                        model.EmployeeShiftMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.InsertEmployeeShiftMaster(model.EmployeeShiftMasterDTO);
                        model.EmployeeShiftMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeShiftMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult EditShift(int EmployeeShiftMasterID)
        {
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = new EmployeeShiftMaster();
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterID = EmployeeShiftMasterID;
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.SelectByEmployeeShiftMasterID(_employeeShiftMasterViewModel.EmployeeShiftMasterDTO);

            if (response != null && response.Entity != null)
            {
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterID = response.Entity.EmployeeShiftMasterID;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftDescription = response.Entity.EmployeeShiftDescription;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.IsActive = response.Entity.IsActive;
            }
            return View("/Views/Employee/EmployeeShiftMaster/EditShift.cshtml", _employeeShiftMasterViewModel);
        }

        [HttpPost]
        public ActionResult EditShift(EmployeeShiftMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeShiftMasterDTO != null)
                    {
                        if (model != null && model.EmployeeShiftMasterDTO != null)
                        {
                            model.EmployeeShiftMasterDTO.ConnectionString = _connectioString;
                            model.EmployeeShiftMasterDTO.IsActive = model.IsActive;
                            model.EmployeeShiftMasterDTO.EmployeeShiftDescription = model.EmployeeShiftDescription;
                            model.EmployeeShiftMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.UpdateEmployeeShiftMaster(model.EmployeeShiftMasterDTO);
                            model.EmployeeShiftMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeShiftMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetShiftMasterDetails(int EmployeeShiftMasterID)
        {
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = new EmployeeShiftMaster();
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterID = EmployeeShiftMasterID;
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.SelectByEmployeeShiftMasterID(_employeeShiftMasterViewModel.EmployeeShiftMasterDTO);
            if (response != null && response.Entity != null)
            {

                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftDescription = response.Entity.EmployeeShiftDescription;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreCode = response.Entity.CentreCode;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreName = response.Entity.CentreName;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.IsShiftLocked = response.Entity.IsShiftLocked;
            }

            return View("/Views/Employee/EmployeeShiftMaster/ShiftMasterDetails.cshtml", _employeeShiftMasterViewModel);
        }

        [HttpGet]
        public ActionResult CreateEmployeeShiftMasterDetails(string WeekDay, string centreName, string centreCode, string EmployeeShiftMasterID, string EmployeeShiftDescription, string GeneralWeekDaysID)
        {
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = new EmployeeShiftMaster();
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterID = Convert.ToInt32(EmployeeShiftMasterID);
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftDescription = EmployeeShiftDescription;
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreCode = centreCode;
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreName = centreName;
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.GeneralWeekDaysID = Convert.ToInt32(GeneralWeekDaysID);
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.WeekDay = WeekDay;

            List<SelectListItem> li_EmployeeShiftMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            li_EmployeeShiftMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_NO, Value = "N" });
            li_EmployeeShiftMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_YES, Value = "Y" });
            ViewData["WeeklyOffStatus"] = li_EmployeeShiftMasterDetails_WeeklyOffDayStatus;


            List<SelectListItem> li_EmpolyeeServiceDetail_WeeklyOffType = new List<SelectListItem>();
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_ALL, Value = "ALL" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetEven, Value = "AlternetEven" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetOdd, Value = "AlternetOdd" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_NotApplicable, Value = "Not Applicable" });
            ViewData["EmployeeServiceDetails_WeeklyOffType"] = li_EmpolyeeServiceDetail_WeeklyOffType;

            return View("/Views/Employee/EmployeeShiftMaster/AddDayDetails.cshtml", _employeeShiftMasterViewModel);
        }


        [HttpPost]
        public ActionResult CreateEmployeeShiftMasterDetails(EmployeeShiftMasterViewModel model)
        {
            try
            {
                if (model.EmployeeShiftMasterID > 0)
                {
                    if (model != null && model.EmployeeShiftMasterDTO != null)
                    {
                        EmployeeShiftMaster EmployeeShiftMasterDTO = new EmployeeShiftMaster();
                        EmployeeShiftMasterDTO.ConnectionString = _connectioString;
                        EmployeeShiftMasterDTO.EmployeeShiftMasterID = model.EmployeeShiftMasterID;
                        EmployeeShiftMasterDTO.CentreCode = model.CentreCode;
                        EmployeeShiftMasterDTO.GeneralWeekDaysID = model.GeneralWeekDaysID;
                        EmployeeShiftMasterDTO.WeeklyOffStatus = model.WeeklyOffStatus;
                        EmployeeShiftMasterDTO.WeeklyOffType = model.WeeklyOffType;
                        EmployeeShiftMasterDTO.ShiftTimeFrom = model.ShiftTimeFrom;
                        EmployeeShiftMasterDTO.ShiftTimeUpto = model.ShiftTimeUpto;
                        EmployeeShiftMasterDTO.ShiftTimeMargin = model.ShiftTimeMargin;
                        EmployeeShiftMasterDTO.ShiftEndBuffer = model.ShiftEndBuffer;
                        EmployeeShiftMasterDTO.LunchTimeFrom = model.LunchTimeFrom;
                        EmployeeShiftMasterDTO.LunchTimeUpto = model.LunchTimeUpto;
                        EmployeeShiftMasterDTO.FirstHalfUpto = model.FirstHalfUpto;
                        EmployeeShiftMasterDTO.SecondHalfFrom = model.SecondHalfFrom;
                        EmployeeShiftMasterDTO.ConsiderLateMarkUpto = model.ConsiderLateMarkUpto;
                        EmployeeShiftMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.InsertEmployeeShiftMasterDetails(EmployeeShiftMasterDTO);
                        model.EmployeeShiftMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeShiftMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult EditEmployeeShiftMasterDetails(string EmployeeShiftMasterDetailsID, string EmployeeShiftDescription)
        {
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = new EmployeeShiftMaster();
            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsID = Convert.ToInt32(EmployeeShiftMasterDetailsID);

            _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.SelectByEmployeeShiftMasterDetailsID(_employeeShiftMasterViewModel.EmployeeShiftMasterDTO);

            if (response != null && response.Entity != null)
            {
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftDescription = EmployeeShiftDescription;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.EmployeeShiftMasterID = response.Entity.EmployeeShiftMasterID;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreCode = response.Entity.CentreCode;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.CentreName = response.Entity.CentreName;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.GeneralWeekDaysID = response.Entity.GeneralWeekDaysID;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.WeekDay = response.Entity.WeekDay;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.WeeklyOffStatus = response.Entity.WeeklyOffStatus;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.WeeklyOffType = response.Entity.WeeklyOffType;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ShiftTimeFrom = response.Entity.ShiftTimeFrom;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ShiftTimeUpto = response.Entity.ShiftTimeUpto;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ShiftTimeMargin = response.Entity.ShiftTimeMargin;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ShiftEndBuffer = response.Entity.ShiftEndBuffer;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.LunchTimeFrom = response.Entity.LunchTimeFrom;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.LunchTimeUpto = response.Entity.LunchTimeUpto;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.FirstHalfUpto = response.Entity.FirstHalfUpto;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.SecondHalfFrom = response.Entity.SecondHalfFrom;
                _employeeShiftMasterViewModel.EmployeeShiftMasterDTO.ConsiderLateMarkUpto = response.Entity.ConsiderLateMarkUpto;

            }

            List<SelectListItem> li_EmployeeShiftMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            li_EmployeeShiftMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_NO, Value = "N" });
            li_EmployeeShiftMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_YES, Value = "Y" });
            ViewData["WeeklyOffStatus"] = new SelectList(li_EmployeeShiftMasterDetails_WeeklyOffDayStatus, "Value", "Text", response.Entity.WeeklyOffStatus); ;

            List<SelectListItem> li_EmpolyeeServiceDetail_WeeklyOffType = new List<SelectListItem>();
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_ALL, Value = "ALL" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetEven, Value = "AlternetEven" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetOdd, Value = "AlternetOdd" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_NotApplicable, Value = "Not Applicable" });
            ViewData["EmployeeServiceDetails_WeeklyOffType"] = new SelectList(li_EmpolyeeServiceDetail_WeeklyOffType, "Value", "Text", response.Entity.WeeklyOffType);

            return View("/Views/Employee/EmployeeShiftMaster/EditDayDetails.cshtml", _employeeShiftMasterViewModel);
        }

        [HttpPost]
        public ActionResult EditEmployeeShiftMasterDetails(EmployeeShiftMasterViewModel model)
        {
            try
            {
                if (model.EmployeeShiftMasterID > 0)
                {
                    if (model != null && model.EmployeeShiftMasterDTO != null)
                    {
                        EmployeeShiftMaster EmployeeShiftMasterDTO = new EmployeeShiftMaster();
                        EmployeeShiftMasterDTO.ConnectionString = _connectioString;
                        EmployeeShiftMasterDTO.EmployeeShiftMasterDetailsID = model.EmployeeShiftMasterDetailsID;
                        EmployeeShiftMasterDTO.WeeklyOffStatus = model.WeeklyOffStatus;
                        EmployeeShiftMasterDTO.WeeklyOffType = model.WeeklyOffType;
                        EmployeeShiftMasterDTO.ShiftTimeFrom = model.ShiftTimeFrom;
                        EmployeeShiftMasterDTO.ShiftTimeUpto = model.ShiftTimeUpto;
                        EmployeeShiftMasterDTO.ShiftTimeMargin = model.ShiftTimeMargin;
                        EmployeeShiftMasterDTO.ShiftEndBuffer = model.ShiftEndBuffer;
                        EmployeeShiftMasterDTO.LunchTimeFrom = model.LunchTimeFrom;
                        EmployeeShiftMasterDTO.LunchTimeUpto = model.LunchTimeUpto;
                        EmployeeShiftMasterDTO.FirstHalfUpto = model.FirstHalfUpto;
                        EmployeeShiftMasterDTO.SecondHalfFrom = model.SecondHalfFrom;
                        EmployeeShiftMasterDTO.ConsiderLateMarkUpto = model.ConsiderLateMarkUpto;
                        EmployeeShiftMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeShiftMaster> response = _EmployeeShiftMasterServiceAccess.UpdateEmployeeShiftMasterDetails(EmployeeShiftMasterDTO);
                        model.EmployeeShiftMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.EmployeeShiftMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<EmployeeShiftMasterViewModel> GetEmployeeShiftMasterRecords(out int TotalRecords)
        {
            EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<EmployeeShiftMasterViewModel> listEmployeeShiftMasterViewModel = new List<EmployeeShiftMasterViewModel>();
            List<EmployeeShiftMaster> listEmployeeShiftMaster = new List<EmployeeShiftMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _EmployeeShiftMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeShiftMaster item in listEmployeeShiftMaster)
                    {
                        EmployeeShiftMasterViewModel _employeeShiftMasterViewModel = new EmployeeShiftMasterViewModel();
                        _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = item;
                        listEmployeeShiftMasterViewModel.Add(_employeeShiftMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeShiftMasterViewModel;
        }

        public IEnumerable<EmployeeShiftMasterViewModel> GetEmployeeShiftMasterDetails(out int TotalRecords, string EmployeeShiftMasterID)
        {
            EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
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
                    searchRequest.EmployeeShiftMasterID = Convert.ToInt32(EmployeeShiftMasterID);
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeShiftMasterID = Convert.ToInt32(EmployeeShiftMasterID);
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeShiftMasterID = Convert.ToInt32(EmployeeShiftMasterID);
            }
            List<EmployeeShiftMasterViewModel> listEmployeeShiftMasterViewModel = new List<EmployeeShiftMasterViewModel>();
            List<EmployeeShiftMaster> listEmployeeShiftMaster = new List<EmployeeShiftMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _EmployeeShiftMasterServiceAccess.GetEmployeeShiftMasterDetailsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeShiftMaster item in listEmployeeShiftMaster)
                    {
                        EmployeeShiftMasterViewModel _employeeShiftMasterViewModel = new EmployeeShiftMasterViewModel();
                        _employeeShiftMasterViewModel.EmployeeShiftMasterDTO = item;
                        listEmployeeShiftMasterViewModel.Add(_employeeShiftMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeShiftMasterViewModel;
        }

        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeShiftMasterViewModel> filteredEmployeeShiftMaster;
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
                        _searchBy = "ShiftDescription Like '%" + param.sSearch + "%' or IsShiftIsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "IsShiftIsLocked";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "EmployeeShiftDescription Like '%" + param.sSearch + "%' or IsShiftIsLocked Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeShiftMaster = GetEmployeeShiftMasterRecords(out TotalRecords);

            var records = filteredEmployeeShiftMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeShiftDescription), Convert.ToString(c.IsShiftLocked), Convert.ToString(c.IsActive), Convert.ToString(c.EmployeeShiftMasterID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult AjaxHandlerShiftMasterDetails(JQueryDataTableParamModel param, string ShiftMasterID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeShiftMasterViewModel> filteredEmployeeShiftMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ID Like '%" + param.sSearch + "%' or WeeklyOffType Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "WeeklyOffType";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.ID Like '%" + param.sSearch + "%' or WeeklyOffType Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(ShiftMasterID))
            {

                //string[] splitCentreCode = CentreCode.Split(':');
                var EmployeeShiftMasterID = ShiftMasterID;
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

                filteredEmployeeShiftMaster = GetEmployeeShiftMasterDetails(out TotalRecords, EmployeeShiftMasterID);
            }
            else
            {
                filteredEmployeeShiftMaster = new List<EmployeeShiftMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredEmployeeShiftMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.WeekDay), Convert.ToString(c.WeeklyOffStatus), Convert.ToString(c.ShiftTimeFrom), Convert.ToString(c.ShiftTimeUpto), Convert.ToString(c.ShiftTimeMargin), Convert.ToString(c.ShiftEndBuffer), Convert.ToString(c.LunchTimeFrom), Convert.ToString(c.LunchTimeUpto), Convert.ToString(c.ConsiderLateMarkUpto), Convert.ToString(c.FirstHalfUpto), Convert.ToString(c.SecondHalfFrom), Convert.ToString(c.WeeklyOffType), Convert.ToString(c.EmployeeShiftMasterDetailsID), Convert.ToString(c.GeneralWeekDaysID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}


