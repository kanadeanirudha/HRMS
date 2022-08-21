using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class EmployeeProjectWorksMasterController : BaseController
    {
        IEmployeeProjectWorksMasterServiceAccess _employeeProjectWorksMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeProjectWorksMasterController()
        {
            _employeeProjectWorksMasterServiceAcess = new EmployeeProjectWorksMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeProjectWorksMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeProjectWorksMasterViewModel model = new EmployeeProjectWorksMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeeProjectWorksMasterDTO.EmployeeID = EmployeeID;
                model.EmployeeProjectWorksMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeProjectWorksMaster> response = _employeeProjectWorksMasterServiceAcess.SelectEmployeeCentreCode(model.EmployeeProjectWorksMasterDTO);
                model.CentreCode = response.Entity != null ? response.Entity.CentreCode : string.Empty;
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeeProjectWorksMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                EmployeeProjectWorksMasterViewModel model = new EmployeeProjectWorksMasterViewModel();
                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = Resources.DisplayName_Ongoing, Value = "0" });
                li1.Add(new SelectListItem { Text = Resources.DisplayName_Completed, Value = "1" });
                ViewData["ProjectStatus"] = li1;

                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Days, Value = "Days" });
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Months, Value = "Months" });
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Years, Value = "Years" });
                ViewData["DurationUnit"] = li2;
                return PartialView("/Views/Employee/EmployeeProjectWorksMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeProjectWorksMasterViewModel model)
        {
            try
            {

                if (model != null && model.EmployeeProjectWorksMasterDTO != null)
                {
                    model.EmployeeProjectWorksMasterDTO.ConnectionString = _connectioString;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkName = model.ProjectWorkName;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkDate = model.ProjectWorkDate; ;
                    model.EmployeeProjectWorksMasterDTO.ProjectCost = model.ProjectCost;
                    model.EmployeeProjectWorksMasterDTO.CentreCode = model.CentreCode;
                    model.EmployeeProjectWorksMasterDTO.FundingAgency = model.FundingAgency;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkFromDate = model.ProjectWorkFromDate;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkToDate = model.ProjectWorkToDate; ;
                    model.EmployeeProjectWorksMasterDTO.EmployeeID = model.EmployeeID;
                    model.EmployeeProjectWorksMasterDTO.AssignmentFromDate = model.AssignmentFromDate;
                    model.EmployeeProjectWorksMasterDTO.AssignmentToDate = model.AssignmentToDate;
                    model.EmployeeProjectWorksMasterDTO.EmployeeRemark = !string.IsNullOrEmpty(model.EmployeeRemark) ? model.EmployeeRemark : string.Empty;
                    model.EmployeeProjectWorksMasterDTO.WorkAsDesignation = model.WorkAsDesignation;
                    model.EmployeeProjectWorksMasterDTO.Duration = model.Duration;
                    model.EmployeeProjectWorksMasterDTO.DurationUnit = model.DurationUnit;
                    model.EmployeeProjectWorksMasterDTO.ProjectStatus = model.ProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.IndividualProjectStatus = model.ProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.IsActive = true;
                    model.EmployeeProjectWorksMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeProjectWorksMaster> response = _employeeProjectWorksMasterServiceAcess.InsertEmployeeProjectWorksMaster(model.EmployeeProjectWorksMasterDTO);
                    model.EmployeeProjectWorksMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.EmployeeProjectWorksMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(string IDs)
        {
            EmployeeProjectWorksMasterViewModel model = new EmployeeProjectWorksMasterViewModel();
            try
            {
                model.EmployeeProjectWorksMasterDTO = new EmployeeProjectWorksMaster();

                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = Resources.DisplayName_Ongoing, Value = "0" });
                li1.Add(new SelectListItem { Text = Resources.DisplayName_Completed, Value = "1" });

                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Ongoing, Value = "0" });
                li2.Add(new SelectListItem { Text = Resources.DisplayName_Completed, Value = "1" });

                List<SelectListItem> li3 = new List<SelectListItem>();
                li3.Add(new SelectListItem { Text = Resources.DisplayName_Days, Value = "Days" });
                li3.Add(new SelectListItem { Text = Resources.DisplayName_Months,Value = "Months" });
                li3.Add(new SelectListItem { Text = Resources.DisplayName_Years, Value = "Years" });

                var splitData = IDs.Split('~');
                model.EmployeeProjectWorksMasterDTO.ID = Convert.ToInt32(splitData[0]);
                model.EmployeeProjectWorksMasterDTO.EmployeeID = Convert.ToInt32(splitData[1]);
                model.EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID = Convert.ToInt32(splitData[2]);
                model.EmployeeProjectWorksMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeProjectWorksMaster> response = _employeeProjectWorksMasterServiceAcess.SelectByID(model.EmployeeProjectWorksMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeProjectWorksMasterDTO.ID = response.Entity.ID;
                    model.EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID = response.Entity.EmployeeProjectWorksDetailsID;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkName = response.Entity.ProjectWorkName;
                    model.EmployeeProjectWorksMasterDTO.FundingAgency = response.Entity.FundingAgency;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkDate = response.Entity.ProjectWorkDate; ;
                    model.EmployeeProjectWorksMasterDTO.ProjectCost = Convert.ToDecimal(String.Format("{0:0.00}", response.Entity.ProjectCost));// response.Entity.ConsultancyCost;
                    model.EmployeeProjectWorksMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkFromDate = response.Entity.ProjectWorkFromDate;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkToDate = response.Entity.ProjectWorkToDate; ;
                    model.EmployeeProjectWorksMasterDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeProjectWorksMasterDTO.Duration = response.Entity.Duration;
                    model.EmployeeProjectWorksMasterDTO.AssignmentFromDate = response.Entity.AssignmentFromDate;
                    model.EmployeeProjectWorksMasterDTO.AssignmentToDate = response.Entity.AssignmentToDate;
                    model.EmployeeProjectWorksMasterDTO.EmployeeRemark = response.Entity.EmployeeRemark;
                    model.EmployeeProjectWorksMasterDTO.WorkAsDesignation = response.Entity.WorkAsDesignation;
                    model.EmployeeProjectWorksMasterDTO.IndividualProjectStatus = response.Entity.IndividualProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.ProjectStatus = response.Entity.ProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.IsActive = response.Entity.IsActive;
                    ViewData["DurationUnit"] = new SelectList(li3, "Value", "Text", response.Entity.DurationUnit);
                    ViewData["ProjectStatus"] = new SelectList(li1, "Value", "Text", response.Entity.ProjectStatus != true ? "0" : "1");
                    ViewData["IndividualProjectStatus"] = new SelectList(li2, "Value", "Text", response.Entity.IndividualProjectStatus != true ? "0" : "1");
                }
                return PartialView("/Views/Employee/EmployeeProjectWorksMaster/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeProjectWorksMasterViewModel model)
        {
            try
            {

                if (model != null && model.EmployeeProjectWorksMasterDTO != null)
                {

                    model.EmployeeProjectWorksMasterDTO.ConnectionString = _connectioString;
                    model.EmployeeProjectWorksMasterDTO.ID = model.ID;
                    model.EmployeeProjectWorksMasterDTO.EmployeeProjectWorksDetailsID = model.EmployeeProjectWorksDetailsID;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkName = model.ProjectWorkName;
                    model.EmployeeProjectWorksMasterDTO.FundingAgency = model.FundingAgency;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkDate = model.ProjectWorkDate; ;
                    model.EmployeeProjectWorksMasterDTO.ProjectCost = model.ProjectCost;
                    model.EmployeeProjectWorksMasterDTO.CentreCode = model.CentreCode;
                    model.EmployeeProjectWorksMasterDTO.Duration = model.Duration;
                    model.EmployeeProjectWorksMasterDTO.DurationUnit = model.DurationUnit;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkFromDate = model.ProjectWorkFromDate;
                    model.EmployeeProjectWorksMasterDTO.ProjectWorkToDate = model.ProjectWorkToDate; ;
                    model.EmployeeProjectWorksMasterDTO.EmployeeID = model.EmployeeID;
                    model.EmployeeProjectWorksMasterDTO.AssignmentFromDate = model.AssignmentFromDate;
                    model.EmployeeProjectWorksMasterDTO.AssignmentToDate = model.AssignmentToDate;
                    model.EmployeeProjectWorksMasterDTO.EmployeeRemark = !string.IsNullOrEmpty(model.EmployeeRemark) ? model.EmployeeRemark : string.Empty;
                    model.EmployeeProjectWorksMasterDTO.WorkAsDesignation = model.WorkAsDesignation;
                    model.EmployeeProjectWorksMasterDTO.IndividualProjectStatus = model.IndividualProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.ProjectStatus = model.ProjectStatus;
                    model.EmployeeProjectWorksMasterDTO.IsActive = model.IsActive;

                    model.EmployeeProjectWorksMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<EmployeeProjectWorksMaster> response = _employeeProjectWorksMasterServiceAcess.InsertEmployeeProjectWorksMaster(model.EmployeeProjectWorksMasterDTO);
                    model.EmployeeProjectWorksMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.EmployeeProjectWorksMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeProjectWorksMasterViewModel> GetEmployeeProjectWorksMaster(string CentreCode, int EmployeeID, out int TotalRecords)
        {
            EmployeeProjectWorksMasterSearchRequest searchRequest = new EmployeeProjectWorksMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "B.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "B.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
                searchRequest.CentreCode = CentreCode;
            }
            List<EmployeeProjectWorksMasterViewModel> listEmployeeProjectWorksMasterViewModel = new List<EmployeeProjectWorksMasterViewModel>();
            List<EmployeeProjectWorksMaster> listEmployeeProjectWorksMaster = new List<EmployeeProjectWorksMaster>();
            IBaseEntityCollectionResponse<EmployeeProjectWorksMaster> baseEntityCollectionResponse = _employeeProjectWorksMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeProjectWorksMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeProjectWorksMaster item in listEmployeeProjectWorksMaster)
                    {
                        EmployeeProjectWorksMasterViewModel EmployeeProjectWorksMasterViewModel = new EmployeeProjectWorksMasterViewModel();
                        EmployeeProjectWorksMasterViewModel.EmployeeProjectWorksMasterDTO = item;
                        listEmployeeProjectWorksMasterViewModel.Add(EmployeeProjectWorksMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeProjectWorksMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeProjectWorksMasterViewModel> filteredEmployeeProjectWorksMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ProjectWorkName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ProjectWorkName Like '%" + param.sSearch + "%' or ProjectWorkFromDate Like '%" + param.sSearch + "%' or ProjectWorkToDate Like'%" + param.sSearch + "%'  or ProjectStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ProjectWorkFromDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ProjectWorkName Like '%" + param.sSearch + "%' or ProjectWorkFromDate Like '%" + param.sSearch + "%' or ProjectWorkToDate Like'%" + param.sSearch + "%' or ProjectStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ProjectWorkToDate";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ProjectWorkName Like '%" + param.sSearch + "%' or ProjectWorkFromDate Like '%" + param.sSearch + "%' or ProjectWorkToDate Like'%" + param.sSearch + "%' or ProjectStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ProjectStatus";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ProjectWorkName Like '%" + param.sSearch + "%' or ProjectWorkFromDate Like '%" + param.sSearch + "%' or ProjectWorkToDate Like'%" + param.sSearch + "%' or ProjectStatus Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (EmployeeID > 0 && !string.IsNullOrEmpty(CentreCode))
            {
                filteredEmployeeProjectWorksMaster = GetEmployeeProjectWorksMaster(CentreCode, EmployeeID, out TotalRecords);
            }
            else
            {
                filteredEmployeeProjectWorksMaster = new List<EmployeeProjectWorksMasterViewModel>();
                TotalRecords = 0;
            }

            var records = filteredEmployeeProjectWorksMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ProjectWorkName), Convert.ToString(c.ProjectWorkFromDate), Convert.ToString(c.ProjectWorkToDate), Convert.ToString(c.ProjectStatus), Convert.ToString(c.StatusFlag), Convert.ToString(c.ID + "~" + c.EmployeeID + "~" + c.EmployeeProjectWorksDetailsID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}