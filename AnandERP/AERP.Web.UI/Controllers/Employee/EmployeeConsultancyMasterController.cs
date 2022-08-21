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
    public class EmployeeConsultancyMasterController : BaseController
    {
        IEmployeeConsultancyMasterServiceAccess _employeeConsultancyMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeConsultancyMasterController()
        {
            _employeeConsultancyMasterServiceAcess = new EmployeeConsultancyMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeConsultancyMaster/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeConsultancyMasterViewModel model = new EmployeeConsultancyMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeeConsultancyMasterDTO.EmployeeID = EmployeeID;
                model.EmployeeConsultancyMasterDTO.ConnectionString = _connectioString;
                  IBaseEntityResponse<EmployeeConsultancyMaster> response = _employeeConsultancyMasterServiceAcess.SelectEmployeeCentreCode(model.EmployeeConsultancyMasterDTO);
                  model.CentreCode = response.Entity != null ? response.Entity.CentreCode : string.Empty;
                  model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeeConsultancyMaster/List.cshtml", model);
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
                EmployeeConsultancyMasterViewModel model = new EmployeeConsultancyMasterViewModel();
                return PartialView("/Views/Employee/EmployeeConsultancyMaster/Create.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(EmployeeConsultancyMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeConsultancyMasterDTO != null)
                    {
                        model.EmployeeConsultancyMasterDTO.ConnectionString = _connectioString;
                        model.EmployeeConsultancyMasterDTO.ConsultancyName = model.ConsultancyName;
                        model.EmployeeConsultancyMasterDTO.ConsultancyDate = model.ConsultancyDate; ;
                        model.EmployeeConsultancyMasterDTO.ConsultancyCost = model.ConsultancyCost;
                        model.EmployeeConsultancyMasterDTO.CentreCode = model.CentreCode;
                        model.EmployeeConsultancyMasterDTO.ConsultingFromDate = model.ConsultingFromDate;
                        model.EmployeeConsultancyMasterDTO.ConsultingToDate = model.ConsultingToDate; ;
                        model.EmployeeConsultancyMasterDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeConsultancyMasterDTO.AssignmentFromDate = model.AssignmentFromDate;
                        model.EmployeeConsultancyMasterDTO.AssignmentToDate = model.AssignmentToDate;
                        model.EmployeeConsultancyMasterDTO.EmployeeRemark = !String.IsNullOrEmpty(model.EmployeeRemark) ? model.EmployeeRemark : string.Empty;
                        model.EmployeeConsultancyMasterDTO.EmployeeShare = model.EmployeeShare;
                        model.EmployeeConsultancyMasterDTO.TitleOfAssignment = model.TitleOfAssignment;
                        model.EmployeeConsultancyMasterDTO.IsActive = true;
                        model.EmployeeConsultancyMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeConsultancyMaster> response = _employeeConsultancyMasterServiceAcess.InsertEmployeeConsultancyMaster(model.EmployeeConsultancyMasterDTO);
                        model.EmployeeConsultancyMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeConsultancyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeConsultancyMasterViewModel model = new EmployeeConsultancyMasterViewModel();
            try
            {                
                model.EmployeeConsultancyMasterDTO = new EmployeeConsultancyMaster();
                var splitData = IDs.Split('~');
                model.EmployeeConsultancyMasterDTO.ID =Convert.ToInt32(splitData[0]);
                model.EmployeeConsultancyMasterDTO.EmployeeID = Convert.ToInt32(splitData[1]);
                model.EmployeeConsultancyMasterDTO.EmpConsultancyDetID = Convert.ToInt32(splitData[2]);
                model.EmployeeConsultancyMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<EmployeeConsultancyMaster> response = _employeeConsultancyMasterServiceAcess.SelectByID(model.EmployeeConsultancyMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeConsultancyMasterDTO.ID = response.Entity.ID;
                    model.EmployeeConsultancyMasterDTO.EmpConsultancyDetID = response.Entity.EmpConsultancyDetID;
                    model.EmployeeConsultancyMasterDTO.ConsultancyName = response.Entity.ConsultancyName;
                    model.EmployeeConsultancyMasterDTO.ConsultancyDate = response.Entity.ConsultancyDate; ;
                    model.EmployeeConsultancyMasterDTO.ConsultancyCost = Convert.ToDecimal(String.Format("{0:0.00}", response.Entity.ConsultancyCost));// response.Entity.ConsultancyCost;
                    model.EmployeeConsultancyMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.EmployeeConsultancyMasterDTO.ConsultingFromDate = response.Entity.ConsultingFromDate;
                    model.EmployeeConsultancyMasterDTO.ConsultingToDate = response.Entity.ConsultingToDate; ;
                    model.EmployeeConsultancyMasterDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeConsultancyMasterDTO.AssignmentFromDate = response.Entity.AssignmentFromDate;
                    model.EmployeeConsultancyMasterDTO.AssignmentToDate = response.Entity.AssignmentToDate;
                    model.EmployeeConsultancyMasterDTO.EmployeeRemark = response.Entity.EmployeeRemark;
                    model.EmployeeConsultancyMasterDTO.EmployeeShare =Convert.ToDecimal(String.Format("{0:0.00}", response.Entity.EmployeeShare)); // String.Format("", Convert.ToString(response.Entity.EmployeeShare));
                    model.EmployeeConsultancyMasterDTO.TitleOfAssignment = response.Entity.TitleOfAssignment;
                    model.EmployeeConsultancyMasterDTO.IsActive = response.Entity.IsActive;
                }
                return PartialView("/Views/Employee/EmployeeConsultancyMaster/Edit.cshtml",model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeConsultancyMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeConsultancyMasterDTO != null)
                    {

                        model.EmployeeConsultancyMasterDTO.ConnectionString = _connectioString;
                        model.EmployeeConsultancyMasterDTO.ID= model.ID;
                        model.EmployeeConsultancyMasterDTO.EmpConsultancyDetID = model.EmpConsultancyDetID; ;
                        
                        model.EmployeeConsultancyMasterDTO.ConsultancyName = model.ConsultancyName;
                        model.EmployeeConsultancyMasterDTO.ConsultancyDate = model.ConsultancyDate; ;
                        model.EmployeeConsultancyMasterDTO.ConsultancyCost = model.ConsultancyCost;
                        model.EmployeeConsultancyMasterDTO.CentreCode = model.CentreCode;
                        model.EmployeeConsultancyMasterDTO.ConsultingFromDate = model.ConsultingFromDate;
                        model.EmployeeConsultancyMasterDTO.ConsultingToDate = model.ConsultingToDate; ;
                        model.EmployeeConsultancyMasterDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeConsultancyMasterDTO.AssignmentFromDate = model.AssignmentFromDate;
                        model.EmployeeConsultancyMasterDTO.AssignmentToDate = model.AssignmentToDate;
                        model.EmployeeConsultancyMasterDTO.EmployeeRemark = !String.IsNullOrEmpty(model.EmployeeRemark) ? model.EmployeeRemark : string.Empty;
                        model.EmployeeConsultancyMasterDTO.EmployeeShare = model.EmployeeShare;
                        model.EmployeeConsultancyMasterDTO.TitleOfAssignment = model.TitleOfAssignment;
                        model.EmployeeConsultancyMasterDTO.IsActive = model.IsActive;
                        model.EmployeeConsultancyMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeConsultancyMaster> response = _employeeConsultancyMasterServiceAcess.InsertEmployeeConsultancyMaster(model.EmployeeConsultancyMasterDTO);
                        model.EmployeeConsultancyMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.EmployeeConsultancyMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<EmployeeConsultancyMasterViewModel> GetEmployeeConsultancyMaster(string CentreCode,int EmployeeID,out int TotalRecords)
        {
            EmployeeConsultancyMasterSearchRequest searchRequest = new EmployeeConsultancyMasterSearchRequest();
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
            List<EmployeeConsultancyMasterViewModel> listEmployeeConsultancyMasterViewModel = new List<EmployeeConsultancyMasterViewModel>();
            List<EmployeeConsultancyMaster> listEmployeeConsultancyMaster = new List<EmployeeConsultancyMaster>();
            IBaseEntityCollectionResponse<EmployeeConsultancyMaster> baseEntityCollectionResponse = _employeeConsultancyMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeConsultancyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeConsultancyMaster item in listEmployeeConsultancyMaster)
                    {
                        EmployeeConsultancyMasterViewModel EmployeeConsultancyMasterViewModel = new EmployeeConsultancyMasterViewModel();
                        EmployeeConsultancyMasterViewModel.EmployeeConsultancyMasterDTO = item;
                        listEmployeeConsultancyMasterViewModel.Add(EmployeeConsultancyMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeConsultancyMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode, int EmployeeID)
        {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<EmployeeConsultancyMasterViewModel> filteredEmployeeConsultancyMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ConsultancyName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ConsultancyName Like '%" + param.sSearch + "%' or ConsultingFromDate Like '%" + param.sSearch + "%' or ConsultingToDate Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ConsultingFromDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ConsultancyName Like '%" + param.sSearch + "%' or ConsultingFromDate Like '%" + param.sSearch + "%' or ConsultingToDate Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "ConsultingToDate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ConsultancyName Like '%" + param.sSearch + "%' or ConsultingFromDate Like '%" + param.sSearch + "%' or ConsultingToDate Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredEmployeeConsultancyMaster = GetEmployeeConsultancyMaster(CentreCode,EmployeeID,out TotalRecords);
                var records = filteredEmployeeConsultancyMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ConsultancyName), Convert.ToString(c.ConsultingFromDate), Convert.ToString(c.ConsultingToDate), Convert.ToString(c.StatusFlag), Convert.ToString(c.ID +"~"+c.EmployeeID +"~"+c.EmpConsultancyDetID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}