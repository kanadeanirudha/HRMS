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

namespace AMS.Web.UI.Controllers
{
    public class EmployeeSpecializationResearchAreaDetailsController : BaseController
    {
        IEmployeeSpecializationResearchAreaDetailsServiceAccess _EmployeeSpecializationResearchAreaDetailsServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeSpecializationResearchAreaDetailsController()
        {
            _EmployeeSpecializationResearchAreaDetailsServiceAccess = new EmployeeSpecializationResearchAreaDetailsServiceAccess();
        }

        //  Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeSpecializationResearchAreaDetails/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeSpecializationResearchAreaDetailsViewModel model = new EmployeeSpecializationResearchAreaDetailsViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                model.EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = EmployeeID;
                model.EmployeeSpecializationResearchAreaDetailsDTO.ConnectionString = _connectioString;
                model.EmployeeID = EmployeeID;
                return PartialView("~/Views/Employee/EmployeeSpecializationResearchAreaDetails/List.cshtml", model);
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
            EmployeeSpecializationResearchAreaDetailsViewModel model = new EmployeeSpecializationResearchAreaDetailsViewModel();
            return PartialView("/Views/Employee/EmployeeSpecializationResearchAreaDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeSpecializationResearchAreaDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeSpecializationResearchAreaDetailsDTO != null)
                    {
                        model.EmployeeSpecializationResearchAreaDetailsDTO.ConnectionString = _connectioString;
                        model.EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeSpecializationResearchAreaDetailsDTO.SpecializationField = model.SpecializationField;
                        model.EmployeeSpecializationResearchAreaDetailsDTO.ResearchArea = model.ResearchArea;
                     
                        model.EmployeeSpecializationResearchAreaDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); ;
                        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> response = _EmployeeSpecializationResearchAreaDetailsServiceAccess.InsertEmployeeSpecializationResearchAreaDetails(model.EmployeeSpecializationResearchAreaDetailsDTO);
                        model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            EmployeeSpecializationResearchAreaDetailsViewModel model = new EmployeeSpecializationResearchAreaDetailsViewModel();
            model.EmployeeSpecializationResearchAreaDetailsDTO = new EmployeeSpecializationResearchAreaDetails();
            model.EmployeeSpecializationResearchAreaDetailsDTO.ID = ID;
            model.EmployeeSpecializationResearchAreaDetailsDTO.ConnectionString = _connectioString;

            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> response = _EmployeeSpecializationResearchAreaDetailsServiceAccess.SelectByID(model.EmployeeSpecializationResearchAreaDetailsDTO);

            if (response != null && response.Entity != null)
            {

                model.EmployeeSpecializationResearchAreaDetailsDTO.ID = response.Entity.ID;
                model.EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = response.Entity.EmployeeID;
                model.EmployeeSpecializationResearchAreaDetailsDTO.SpecializationField = response.Entity.SpecializationField;
                model.EmployeeSpecializationResearchAreaDetailsDTO.ResearchArea = response.Entity.ResearchArea;
               
            }
            return PartialView("/Views/Employee/EmployeeSpecializationResearchAreaDetails/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeSpecializationResearchAreaDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeSpecializationResearchAreaDetailsDTO != null)
                    {
                        if (model != null && model.EmployeeSpecializationResearchAreaDetailsDTO != null)
                        {
                            model.EmployeeSpecializationResearchAreaDetailsDTO.ConnectionString = _connectioString;
                            model.EmployeeSpecializationResearchAreaDetailsDTO.ID = model.ID;
                            model.EmployeeSpecializationResearchAreaDetailsDTO.EmployeeID = model.EmployeeID;
                            model.EmployeeSpecializationResearchAreaDetailsDTO.SpecializationField = model.SpecializationField;
                            model.EmployeeSpecializationResearchAreaDetailsDTO.ResearchArea = model.ResearchArea;                           
                            model.EmployeeSpecializationResearchAreaDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> response = _EmployeeSpecializationResearchAreaDetailsServiceAccess.UpdateEmployeeSpecializationResearchAreaDetails(model.EmployeeSpecializationResearchAreaDetailsDTO);
                            model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
            EmployeeSpecializationResearchAreaDetailsViewModel model = new EmployeeSpecializationResearchAreaDetailsViewModel();
            model.EmployeeSpecializationResearchAreaDetailsDTO = new EmployeeSpecializationResearchAreaDetails();
            model.EmployeeSpecializationResearchAreaDetailsDTO.ID = ID;
            return PartialView("~/Views/Employee/EmployeeSpecializationResearchAreaDetails/Delete.cshtml", model);
        }

        [HttpPost]
        public ActionResult Delete(EmployeeSpecializationResearchAreaDetailsViewModel model)
        {
            try
            {

                if (model.ID > 0)
                {
                    if (model != null && model.EmployeeSpecializationResearchAreaDetailsDTO != null)
                    {
                        EmployeeSpecializationResearchAreaDetails EmployeeSpecializationResearchAreaDetailsDTO = new EmployeeSpecializationResearchAreaDetails();
                        EmployeeSpecializationResearchAreaDetailsDTO.ConnectionString = _connectioString;
                        EmployeeSpecializationResearchAreaDetailsDTO.ID = model.ID;
                        EmployeeSpecializationResearchAreaDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> response = _EmployeeSpecializationResearchAreaDetailsServiceAccess.DeleteEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetailsDTO);
                        model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.EmployeeSpecializationResearchAreaDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<EmployeeSpecializationResearchAreaDetailsViewModel> GetEmployeeSpecializationResearchAreaDetailsDetails(int EmployeeID, out int TotalRecords)
        {
            EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest = new EmployeeSpecializationResearchAreaDetailsSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
            }
            List<EmployeeSpecializationResearchAreaDetailsViewModel> listEmployeeSpecializationResearchAreaDetailsViewModel = new List<EmployeeSpecializationResearchAreaDetailsViewModel>();
            List<EmployeeSpecializationResearchAreaDetails> listEmployeeSpecializationResearchAreaDetails = new List<EmployeeSpecializationResearchAreaDetails>();
            IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> baseEntityCollectionResponse = _EmployeeSpecializationResearchAreaDetailsServiceAccess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeSpecializationResearchAreaDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeSpecializationResearchAreaDetails item in listEmployeeSpecializationResearchAreaDetails)
                    {
                        EmployeeSpecializationResearchAreaDetailsViewModel _EmployeeSpecializationResearchAreaDetailsViewModel = new EmployeeSpecializationResearchAreaDetailsViewModel();
                        _EmployeeSpecializationResearchAreaDetailsViewModel.EmployeeSpecializationResearchAreaDetailsDTO = item;
                        listEmployeeSpecializationResearchAreaDetailsViewModel.Add(_EmployeeSpecializationResearchAreaDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeSpecializationResearchAreaDetailsViewModel;
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeSpecializationResearchAreaDetailsViewModel> filteredEmployeeSpecializationResearchAreaDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SpecializationField";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SpecializationField Like '%" + param.sSearch + "%' or ResearchArea Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ResearchArea";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SpecializationField Like '%" + param.sSearch + "%' or ResearchArea Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;


            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeSpecializationResearchAreaDetails = GetEmployeeSpecializationResearchAreaDetailsDetails(EmployeeID, out TotalRecords);
            var records = filteredEmployeeSpecializationResearchAreaDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.SpecializationField.ToString(), Convert.ToString(c.ResearchArea), Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}


