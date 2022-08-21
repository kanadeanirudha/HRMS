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
    public class EmployeeShiftApplicableMasterController : BaseController
    {
        IEmployeeShiftApplicableMasterBA _employeeShiftApplicableMasterServiceAccess = null;
        IGeneralWeekDaysBA _generalWeekDaysServiceAccess = null;
        IEmployeeShiftMasterBA _employeeShiftMasterServiceAccess = null;
        IEmployeeShiftApplicableMasterViewModel _employeeShiftApplicableMasterViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeShiftApplicableMasterController()
        {
            _employeeShiftApplicableMasterServiceAccess = new EmployeeShiftApplicableMasterBA();
            _employeeShiftApplicableMasterViewModel = new EmployeeShiftApplicableMasterViewModel();
            _employeeShiftMasterServiceAccess = new EmployeeShiftMasterBA();
            _generalWeekDaysServiceAccess = new GeneralWeekDaysBA();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Employee/EmployeeShiftApplicableMaster/Index.cshtml");
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
                        return View("/Views/Employee/EmployeeShiftApplicableMaster/Index.cshtml");
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

        public ActionResult List(string actionMode, string centerCode, string centreName, string departmentId, string departmentName)
        {
            try
            {

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _employeeShiftApplicableMasterViewModel.CentreCode = splitCentreCode[0];
                    _employeeShiftApplicableMasterViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                }
                else
                {
                    _employeeShiftApplicableMasterViewModel.CentreCode = centerCode;
                    _employeeShiftApplicableMasterViewModel.EntityLevel = null;
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
                        _employeeShiftApplicableMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _employeeShiftApplicableMasterViewModel.EntityLevel = "Centre";

                    foreach (var b in _employeeShiftApplicableMasterViewModel.ListGetAdminRoleApplicableCentre)
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
                        a.ScopeIdentity = item.ScopeIdentity;
                        _employeeShiftApplicableMasterViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _employeeShiftApplicableMasterViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                    if (centerCode == null)
                    {
                        _employeeShiftApplicableMasterViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(Convert.ToString(_employeeShiftApplicableMasterViewModel.ListGetAdminRoleApplicableCentre[0].CentreCode));
                    }
                    if (centerCode != null)
                    {
                        _employeeShiftApplicableMasterViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(_employeeShiftApplicableMasterViewModel.CentreCode);
                    }
                    foreach (var b in _employeeShiftApplicableMasterViewModel.ListOrganisationDepartmentMaster)
                    {
                        b.DeptID = b.ID + ":" + b.DepartmentName;
                    }
                }


                if (!string.IsNullOrEmpty(departmentName))
                {
                    string[] splitDepartmentID = departmentId.Split(':');
                    if (splitDepartmentID.Length == 2)
                    {
                        _employeeShiftApplicableMasterViewModel.DepartmentName = departmentName;
                        _employeeShiftApplicableMasterViewModel.SelectedDepartmentID = Convert.ToInt32(splitDepartmentID[0]);
                    }
                    else
                    {
                        _employeeShiftApplicableMasterViewModel.DepartmentName = departmentName;
                        _employeeShiftApplicableMasterViewModel.SelectedDepartmentID = !string.IsNullOrEmpty(departmentId) ? Convert.ToInt32(departmentId) : 0;
                    }
                    _employeeShiftApplicableMasterViewModel.CentreName = centreName;
                }
              if (!string.IsNullOrEmpty(actionMode))
              {
                  TempData["ActionMode"] = actionMode;
              }
              //_employeeShiftApplicableMasterViewModel.CentreCode = string.IsNullOrEmpty(centerCode) ? string.Empty : centerCode;
              //_employeeShiftApplicableMasterViewModel.DepartmentID = string.IsNullOrEmpty(departmentId) ? 0 : Convert.ToInt32(departmentId);
              return PartialView("/Views/Employee/EmployeeShiftApplicableMaster/List.cshtml", _employeeShiftApplicableMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(string EmployeeID, string CentreCode, string CentreName, string EmpName)
        {
            string[] splitEmployeeName = EmpName.Split(':');
            _employeeShiftApplicableMasterViewModel.EmployeeID = Convert.ToInt32(EmployeeID);
            _employeeShiftApplicableMasterViewModel.EmployeeName = splitEmployeeName[0] + " " + splitEmployeeName[1] + " " + splitEmployeeName[2];
            _employeeShiftApplicableMasterViewModel.CentreCode = CentreCode;
            _employeeShiftApplicableMasterViewModel.CentreName = CentreName;

            //--------------------------------------For Employee shift list----------------------------------------//
            List<EmployeeShiftMaster> employeeShiftMasterList = GetListEmployeeShiftMaster(CentreCode);
            List<SelectListItem> employeeShiftMaster = new List<SelectListItem>();
           
            foreach (EmployeeShiftMaster item in employeeShiftMasterList)
            {
              
                employeeShiftMaster.Add(new SelectListItem { Text = item.EmployeeShiftDescription, Value = item.EmployeeShiftMasterID.ToString() + "~" + item.ShiftAllocationCentreID });
            }
            ViewBag.employeeShiftMasterList = new SelectList(employeeShiftMaster, "Value", "Text");

            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Shiftwise, Value = "0" });
            li.Add(new SelectListItem { Text = Resources.DropdownMessage_Daywise, Value = "1" });
            ViewBag.WeeklyOffConsideration = li;
            _employeeShiftApplicableMasterViewModel.ListGeneralWeekDays = GetGeneralWeekDaysList(0);

            return View("/Views/Employee/EmployeeShiftApplicableMaster/Create.cshtml", _employeeShiftApplicableMasterViewModel);
        }

        [HttpGet]
        public ActionResult _ShiftDetails(int EmployeeShiftMasterID)
        {
            EmployeeShiftMasterViewModel model = new EmployeeShiftMasterViewModel();
            model.EmployeeShiftMasterDTO.EmployeeShiftMasterID = EmployeeShiftMasterID;

            List<EmployeeShiftMaster> employeeShiftMasterDetailsList = GetEmployeeShiftMasterDetails(EmployeeShiftMasterID);
            if (employeeShiftMasterDetailsList.Count > 0)
            {
                ViewBag.Data = 1;
                ViewBag.ListEmployeeShiftMasterDetails = employeeShiftMasterDetailsList;
            }
            else
            {
                ViewBag.Data = 0;
            }

            return PartialView("~/Views/Employee/EmployeeShiftApplicableMaster/ShiftDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeShiftApplicableMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeShiftApplicableMasterDTO != null)
                    {
                        model.EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;
                        model.EmployeeShiftApplicableMasterDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeShiftApplicableMasterDTO.EmployeeShiftMasterID = model.SelectedShiftAndCentreAllocationID != null ? Convert.ToString(model.SelectedShiftAndCentreAllocationID.Split('~')[0]) : string.Empty;
                        model.EmployeeShiftApplicableMasterDTO.ShiftAllocationCentreID = model.SelectedShiftAndCentreAllocationID != null ? Convert.ToInt32(model.SelectedShiftAndCentreAllocationID.Split('~')[1]) : 0;
                        model.EmployeeShiftApplicableMasterDTO.WeeklyOffConsideration = model.WeeklyOffConsideration;
                        model.EmployeeShiftApplicableMasterDTO.RotationDays = model.RotationDays;
                        model.EmployeeShiftApplicableMasterDTO.ShiftStartDate = model.ShiftStartDate;
                        model.EmployeeShiftApplicableMasterDTO.ShiftEndDate = model.ShiftEndDate;
                        model.EmployeeShiftApplicableMasterDTO.CentreCode = model.CentreCode;
                        model.EmployeeShiftApplicableMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.InsertEmployeeShiftApplicableMaster(model.EmployeeShiftApplicableMasterDTO);
                        model.EmployeeShiftApplicableMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeShiftApplicableMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            try
            {
                _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
                _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;
                _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ID = ID;
                IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.SelectByID(_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO);
                if (response != null && response.Entity != null)
                {
                    _employeeShiftApplicableMasterViewModel.ID = response.Entity.ID;
                    _employeeShiftApplicableMasterViewModel.EmployeeShiftMasterID = response.Entity.EmployeeShiftMasterID + "~" + response.Entity.ShiftAllocationCentreID;
                    _employeeShiftApplicableMasterViewModel.EmployeeName = response.Entity.EmployeeFirstName + " " + response.Entity.EmployeeMiddleName + " " + response.Entity.EmployeeLastName;
                    _employeeShiftApplicableMasterViewModel.CentreCode = response.Entity.CentreCode;
                    _employeeShiftApplicableMasterViewModel.CentreName = response.Entity.CentreName;
                    _employeeShiftApplicableMasterViewModel.ShiftStartDate = response.Entity.ShiftStartDate;
                    _employeeShiftApplicableMasterViewModel.ShiftEndDate = response.Entity.ShiftEndDate;
                    _employeeShiftApplicableMasterViewModel.CurrentActiveFlag = response.Entity.CurrentActiveFlag;
                    _employeeShiftApplicableMasterViewModel.RotationDays = response.Entity.RotationDays;
                    _employeeShiftApplicableMasterViewModel.EmployeeID = response.Entity.EmployeeID;
                    _employeeShiftApplicableMasterViewModel.ShiftAllocationCentreID = response.Entity.ShiftAllocationCentreID;
                    _employeeShiftApplicableMasterViewModel.WeeklyOffConsideration = response.Entity.WeeklyOffConsideration;
                    _employeeShiftApplicableMasterViewModel.IsActive = response.Entity.IsActive;
                }
                //--------------------------------------For Employee shift list----------------------------------------//
                List<EmployeeShiftMaster> employeeShiftMasterList = GetListEmployeeShiftMaster(_employeeShiftApplicableMasterViewModel.CentreCode);
                List<SelectListItem> employeeShiftMaster = new List<SelectListItem>();
                foreach (EmployeeShiftMaster item in employeeShiftMasterList)
                {
                    employeeShiftMaster.Add(new SelectListItem { Text = item.EmployeeShiftDescription, Value = item.EmployeeShiftMasterID.ToString() + "~" + item.ShiftAllocationCentreID });
                }
                ViewBag.employeeShiftMasterList = new SelectList(employeeShiftMaster, "Value", "Text", _employeeShiftApplicableMasterViewModel.EmployeeShiftMasterID);
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.DropdownMessage_Shiftwise, Value = "0" });
                li.Add(new SelectListItem { Text = Resources.DropdownMessage_Daywise, Value = "1" });
                ViewBag.WeeklyOffConsideration = new SelectList(li, "Value", "Text", _employeeShiftApplicableMasterViewModel.WeeklyOffConsideration);
                _employeeShiftApplicableMasterViewModel.ListGeneralWeekDays = GetGeneralWeekDaysList(response.Entity.ID);
                //List<int> varInt = null;
                //varInt.ToList();
                return View("/Views/Employee/EmployeeShiftApplicableMaster/Edit.cshtml", _employeeShiftApplicableMasterViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(EmployeeShiftApplicableMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeShiftApplicableMasterDTO != null)
                    {
                        if (model != null && model.EmployeeShiftApplicableMasterDTO != null)
                        {
                            model.EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;
                            model.EmployeeShiftApplicableMasterDTO.ID = model.ID;
                            model.EmployeeShiftApplicableMasterDTO.EmployeeID = model.EmployeeID;
                            model.EmployeeShiftApplicableMasterDTO.EmployeeShiftMasterID = model.SelectedShiftAndCentreAllocationID != null ? Convert.ToString(model.SelectedShiftAndCentreAllocationID.Split('~')[0]) : string.Empty;
                            model.EmployeeShiftApplicableMasterDTO.ShiftAllocationCentreID = model.SelectedShiftAndCentreAllocationID != null ? Convert.ToInt32(model.SelectedShiftAndCentreAllocationID.Split('~')[1]) : 0;
                            model.EmployeeShiftApplicableMasterDTO.WeeklyOffConsideration = model.WeeklyOffConsideration;
                            model.EmployeeShiftApplicableMasterDTO.EmployeeShistApplicableMasterFromDate = model.EmployeeShistApplicableMasterFromDate;
                            model.EmployeeShiftApplicableMasterDTO.ShiftStartDate = model.ShiftStartDate;
                            model.EmployeeShiftApplicableMasterDTO.ShiftEndDate = model.ShiftEndDate;
                            model.EmployeeShiftApplicableMasterDTO.RotationDays = model.RotationDays;
                            model.EmployeeShiftApplicableMasterDTO.CurrentActiveFlag = true;
                            model.EmployeeShiftApplicableMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.UpdateEmployeeShiftApplicableMaster(model.EmployeeShiftApplicableMasterDTO);
                            model.EmployeeShiftApplicableMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeShiftApplicableMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult GetShiftMasterDetails(int EmployeeShiftApplicableMasterID)
        {
            _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
            // _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterID = EmployeeShiftApplicableMasterID;
            _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.SelectByID(_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO);
            if (response != null && response.Entity != null)
            {

                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftDescription = response.Entity.EmployeeShiftDescription;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreCode = response.Entity.CentreCode;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreName = response.Entity.CentreName;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.IsShiftLocked = response.Entity.IsShiftLocked;
            }

            return View("/Views/Employee/EmployeeShiftApplicableMaster/ShiftMasterDetails.cshtml", _employeeShiftApplicableMasterViewModel);
        }

        [HttpGet]
        public ActionResult CreateEmployeeShiftApplicableMasterDetails(string WeekDay, string centreName, string centreCode, string EmployeeShiftApplicableMasterID, string EmployeeShiftDescription, string GeneralWeekDaysID)
        {
            _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterID = Convert.ToInt32(EmployeeShiftApplicableMasterID);
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftDescription = EmployeeShiftDescription;
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreCode = centreCode;
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreName = centreName;
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.GeneralWeekDaysID = Convert.ToInt32(GeneralWeekDaysID);
            //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.WeekDay = WeekDay;

            List<SelectListItem> EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            ViewBag.EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new SelectList(EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus, "Value", "Text");
            List<SelectListItem> li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_NO, Value = "N" });
            li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_YES, Value = "Y" });
            ViewData["WeeklyOffStatus"] = li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus;


            List<SelectListItem> EmployeeServiceDetails_WeeklyOffType = new List<SelectListItem>();
            ViewBag.EmpolyeeServiceDetail_WeeklyOffType = new SelectList(EmployeeServiceDetails_WeeklyOffType, "Value", "Text");
            List<SelectListItem> li_EmpolyeeServiceDetail_WeeklyOffType = new List<SelectListItem>();

            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_ALL, Value = "ALL" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetEven, Value = "AlternetEven" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetOdd, Value = "AlternetOdd" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_NotApplicable, Value = "Not Applicable" });
            ViewData["EmployeeServiceDetails_WeeklyOffType"] = li_EmpolyeeServiceDetail_WeeklyOffType;

            return View("/Views/Employee/EmployeeShiftApplicableMaster/AddDayDetails.cshtml", _employeeShiftApplicableMasterViewModel);
        }


        [HttpPost]
        public ActionResult CreateEmployeeShiftApplicableMasterDetails(EmployeeShiftApplicableMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    if (model != null && model.EmployeeShiftApplicableMasterDTO != null)
                    {
                        EmployeeShiftApplicableMaster EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
                        EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;
                        //EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterID = model.EmployeeShiftApplicableMasterID;
                        //EmployeeShiftApplicableMasterDTO.CentreCode = model.CentreCode;
                        //EmployeeShiftApplicableMasterDTO.GeneralWeekDaysID = model.GeneralWeekDaysID;
                        //EmployeeShiftApplicableMasterDTO.WeeklyOffStatus = model.WeeklyOffStatus;
                        //EmployeeShiftApplicableMasterDTO.WeeklyOffType = model.WeeklyOffType;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeFrom = model.ShiftTimeFrom;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeUpto = model.ShiftTimeUpto;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeMargin = model.ShiftTimeMargin;
                        //EmployeeShiftApplicableMasterDTO.ShiftEndBuffer = model.ShiftEndBuffer;
                        //EmployeeShiftApplicableMasterDTO.LunchTimeFrom = model.LunchTimeFrom;
                        //EmployeeShiftApplicableMasterDTO.LunchTimeUpto = model.LunchTimeUpto;
                        //EmployeeShiftApplicableMasterDTO.FirstHalfUpto = model.FirstHalfUpto;
                        //EmployeeShiftApplicableMasterDTO.SecondHalfFrom = model.SecondHalfFrom;
                        //EmployeeShiftApplicableMasterDTO.ConsiderLateMarkUpto = model.ConsiderLateMarkUpto;
                        EmployeeShiftApplicableMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.InsertEmployeeShiftApplicableMaster(EmployeeShiftApplicableMasterDTO);
                        model.EmployeeShiftApplicableMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeShiftApplicableMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult EditEmployeeShiftApplicableMasterDetails(string EmployeeShiftApplicableMasterDetailsID, string EmployeeShiftDescription)
        {
            _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
            // _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterDetailsID = Convert.ToInt32(EmployeeShiftApplicableMasterDetailsID);

            _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.SelectByID(_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO);

            if (response != null && response.Entity != null)
            {
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftDescription = EmployeeShiftDescription;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterID = response.Entity.EmployeeShiftApplicableMasterID;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreCode = response.Entity.CentreCode;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.CentreName = response.Entity.CentreName;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.GeneralWeekDaysID = response.Entity.GeneralWeekDaysID;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.WeekDay = response.Entity.WeekDay;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.WeeklyOffStatus = response.Entity.WeeklyOffStatus;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.WeeklyOffType = response.Entity.WeeklyOffType;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ShiftTimeFrom = response.Entity.ShiftTimeFrom;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ShiftTimeUpto = response.Entity.ShiftTimeUpto;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ShiftTimeMargin = response.Entity.ShiftTimeMargin;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ShiftEndBuffer = response.Entity.ShiftEndBuffer;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.LunchTimeFrom = response.Entity.LunchTimeFrom;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.LunchTimeUpto = response.Entity.LunchTimeUpto;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.FirstHalfUpto = response.Entity.FirstHalfUpto;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.SecondHalfFrom = response.Entity.SecondHalfFrom;
                //_employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO.ConsiderLateMarkUpto = response.Entity.ConsiderLateMarkUpto;

            }

            List<SelectListItem> EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            ViewBag.EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new SelectList(EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus, "Value", "Text");
            List<SelectListItem> li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus = new List<SelectListItem>();
            li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_NO, Value = "N" });
            li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus.Add(new SelectListItem { Text = Resources.DropdownMessage_YES, Value = "Y" });
            ViewData["WeeklyOffStatus"] = li_EmployeeShiftApplicableMasterDetails_WeeklyOffDayStatus;


            List<SelectListItem> EmployeeServiceDetails_WeeklyOffType = new List<SelectListItem>();
            ViewBag.EmpolyeeServiceDetail_WeeklyOffType = new SelectList(EmployeeServiceDetails_WeeklyOffType, "Value", "Text");
            List<SelectListItem> li_EmpolyeeServiceDetail_WeeklyOffType = new List<SelectListItem>();
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_ALL, Value = "ALL" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetEven, Value = "AlternetEven" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_AlternetOdd, Value = "AlternetOdd" });
            li_EmpolyeeServiceDetail_WeeklyOffType.Add(new SelectListItem { Text = Resources.DropdownMessage_NotApplicable, Value = "Not Applicable" });
            ViewData["EmployeeServiceDetails_WeeklyOffType"] = li_EmpolyeeServiceDetail_WeeklyOffType;

            return View("/Views/Employee/EmployeeShiftApplicableMaster/EditDayDetails.cshtml", _employeeShiftApplicableMasterViewModel);
        }

        [HttpPost]
        public ActionResult EditEmployeeShiftApplicableMasterDetails(EmployeeShiftApplicableMasterViewModel model)
        {
            try
            {
                if (model.ID > 0)
                {
                    if (model != null && model.EmployeeShiftApplicableMasterDTO != null)
                    {
                        EmployeeShiftApplicableMaster EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
                        EmployeeShiftApplicableMasterDTO.ConnectionString = _connectioString;
                        //EmployeeShiftApplicableMasterDTO.EmployeeShiftApplicableMasterDetailsID = model.EmployeeShiftApplicableMasterDetailsID;
                        //EmployeeShiftApplicableMasterDTO.WeeklyOffStatus = model.WeeklyOffStatus;
                        //EmployeeShiftApplicableMasterDTO.WeeklyOffType = model.WeeklyOffType;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeFrom = model.ShiftTimeFrom;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeUpto = model.ShiftTimeUpto;
                        //EmployeeShiftApplicableMasterDTO.ShiftTimeMargin = model.ShiftTimeMargin;
                        //EmployeeShiftApplicableMasterDTO.ShiftEndBuffer = model.ShiftEndBuffer;
                        //EmployeeShiftApplicableMasterDTO.LunchTimeFrom = model.LunchTimeFrom;
                        //EmployeeShiftApplicableMasterDTO.LunchTimeUpto = model.LunchTimeUpto;
                        //EmployeeShiftApplicableMasterDTO.FirstHalfUpto = model.FirstHalfUpto;
                        //EmployeeShiftApplicableMasterDTO.SecondHalfFrom = model.SecondHalfFrom;
                        //EmployeeShiftApplicableMasterDTO.ConsiderLateMarkUpto = model.ConsiderLateMarkUpto;
                        EmployeeShiftApplicableMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeShiftApplicableMaster> response = _employeeShiftApplicableMasterServiceAccess.UpdateEmployeeShiftApplicableMaster(EmployeeShiftApplicableMasterDTO);
                        model.EmployeeShiftApplicableMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.EmployeeShiftApplicableMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetDepartmentByCentreCode(string CentreCode)
        {
            if (CentreCode.Contains(':'))
            {
                string[] splited;
                splited = CentreCode.Split(':');

                // _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
                CentreCode = splited[0];
            }

            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var departments = GetListOrganisationDepartmentMaster(CentreCode);
            var result = (from s in departments
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        #endregion

        // Non-Action Methods
        #region Methods

        public IEnumerable<EmployeeShiftApplicableMasterViewModel> GetEmployeeShiftApplicableMasterRecords(out int TotalRecords, string CentreCode, string DepartmentID)
        {
            EmployeeShiftApplicableMasterSearchRequest searchRequest = new EmployeeShiftApplicableMasterSearchRequest();
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
                    searchRequest.DepartmentID = DepartmentID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                    searchRequest.DepartmentID = DepartmentID;
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
                searchRequest.DepartmentID = DepartmentID;
            }
            List<EmployeeShiftApplicableMasterViewModel> listEmployeeShiftApplicableMasterViewModel = new List<EmployeeShiftApplicableMasterViewModel>();
            List<EmployeeShiftApplicableMaster> listEmployeeShiftApplicableMaster = new List<EmployeeShiftApplicableMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftApplicableMaster> baseEntityCollectionResponse = _employeeShiftApplicableMasterServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftApplicableMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeShiftApplicableMaster item in listEmployeeShiftApplicableMaster)
                    {
                        EmployeeShiftApplicableMasterViewModel _employeeShiftApplicableMasterViewModel = new EmployeeShiftApplicableMasterViewModel();
                        _employeeShiftApplicableMasterViewModel.EmployeeShiftApplicableMasterDTO = item;
                        listEmployeeShiftApplicableMasterViewModel.Add(_employeeShiftApplicableMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeShiftApplicableMasterViewModel;
        }

        public List<EmployeeShiftMaster> GetEmployeeShiftMasterDetails(int EmployeeShiftMasterID)
        {
            EmployeeShiftMasterSearchRequest searchRequest = new EmployeeShiftMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //  int SelectedEducationTypeID = 0;
            // bool isValid = EmployeeID;
            searchRequest.EmployeeShiftMasterID = EmployeeShiftMasterID;
            searchRequest.SortBy = "B.ID";
            searchRequest.StartRow = 0;
            searchRequest.EndRow = 100;
            searchRequest.SearchBy = string.Empty;
            searchRequest.SortDirection = "asc";
            //searchRequest.SearchType = 1;
            List<EmployeeShiftMaster> listEmployeeShiftMasterDetails = new List<EmployeeShiftMaster>();
            IBaseEntityCollectionResponse<EmployeeShiftMaster> baseEntityCollectionResponse = _employeeShiftMasterServiceAccess.GetEmployeeShiftMasterDetailsBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeShiftMasterDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployeeShiftMasterDetails;
        }
        public List<GeneralWeekDays> GetGeneralWeekDaysList(int LeaveEmployeeShiftTransactionID)
        {
            GeneralWeekDaysSearchRequest searchRequest = new GeneralWeekDaysSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.LeaveEmployeeShiftTransactionID = LeaveEmployeeShiftTransactionID;
            List<GeneralWeekDays> listGeneralWeekDays = new List<GeneralWeekDays>();
            IBaseEntityCollectionResponse<GeneralWeekDays> baseEntityCollectionResponse = _generalWeekDaysServiceAccess.GetGeneralWeekDayList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralWeekDays = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralWeekDays;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, string DepartmentID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeShiftApplicableMasterViewModel> filteredEmployeeShiftApplicableMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "EmployeeFirstName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "ShiftDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%' )";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ShiftStartDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ShiftEndDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "IsShiftIsActive";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(EmployeeFirstName Like '%" + param.sSearch + "%' or EmployeeLastName Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {
                filteredEmployeeShiftApplicableMaster = GetEmployeeShiftApplicableMasterRecords(out TotalRecords, CentreCode, DepartmentID);
            }
            else
            {
                filteredEmployeeShiftApplicableMaster = new List<EmployeeShiftApplicableMasterViewModel>();
                TotalRecords = 0;
            }
            var records = filteredEmployeeShiftApplicableMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EmployeeFirstName) + " " + Convert.ToString(c.EmployeeMiddleName) + " " + Convert.ToString(c.EmployeeLastName), Convert.ToString(c.EmployeeShiftDescription), Convert.ToString(c.ShiftStartDate), Convert.ToString(c.ShiftEndDate), Convert.ToString(c.CurrentActiveFlag), Convert.ToString(c.ID), Convert.ToString(c.EmployeeShiftMasterID), Convert.ToString(c.EmployeeID), Convert.ToString(c.EmployeeFirstName) + ":" + Convert.ToString(c.EmployeeMiddleName) + ":" + Convert.ToString(c.EmployeeLastName) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


