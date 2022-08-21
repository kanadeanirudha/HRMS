using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class OrganisationDepartmentMasterController : BaseController
    {
        IOrganisationDepartmentMasterBA _organisationDepartmentMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public OrganisationDepartmentMasterController()
        {
            _organisationDepartmentMasterBA = new OrganisationDepartmentMasterBA();

        }

        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/Organisation/OrganisationDepartmentMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OrganisationDepartmentMasterViewModel model = new OrganisationDepartmentMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationDepartmentMaster/List.cshtml", model);
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
            OrganisationDepartmentMasterViewModel model = new OrganisationDepartmentMasterViewModel();
            try
            {
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_Academic, Value = "Academic" });
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_NonAcademic, Value = "Non-Academic" });
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_Sales, Value = "Sales" });
                ViewData["AcademicNonacademic"] = li;

            }
            catch (Exception)
            {

                throw;
            }

            return PartialView("/Views/Organisation/OrganisationDepartmentMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationDepartmentMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationDepartmentMasterDTO != null)
                    {
                        model.OrganisationDepartmentMasterDTO.ConnectionString = _connectioString;

                        model.OrganisationDepartmentMasterDTO.DepartmentName = model.DepartmentName;
                        model.OrganisationDepartmentMasterDTO.DeptShortCode = model.DeptShortCode;
                        model.OrganisationDepartmentMasterDTO.PrintShortDesc = model.PrintShortDesc;
                        model.OrganisationDepartmentMasterDTO.AcademicNonacademic = model.AcademicNonacademic;
                        model.OrganisationDepartmentMasterDTO.TeachingActivity = model.TeachingActivity;
                        model.OrganisationDepartmentMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]); //model.CreatedBy;
                        IBaseEntityResponse<OrganisationDepartmentMaster> response = _organisationDepartmentMasterBA.InsertOrganisationDepartmentMaster(model.OrganisationDepartmentMasterDTO);
                        model.OrganisationDepartmentMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationDepartmentMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            OrganisationDepartmentMasterViewModel model = new OrganisationDepartmentMasterViewModel();
            try
            {
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_Academic, Value = "Academic" });
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_NonAcademic, Value = "Non-Academic" });
                li.Add(new SelectListItem { Text = Resources.ddlHeaders_Sales, Value = "Sales" });

                model.OrganisationDepartmentMasterDTO = new OrganisationDepartmentMaster();
                model.OrganisationDepartmentMasterDTO.ID = id;
                model.OrganisationDepartmentMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationDepartmentMaster> response = _organisationDepartmentMasterBA.SelectByID(model.OrganisationDepartmentMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationDepartmentMasterDTO.ID = response.Entity.ID;
                    model.OrganisationDepartmentMasterDTO.DepartmentName = response.Entity.DepartmentName;
                    model.OrganisationDepartmentMasterDTO.DeptShortCode = response.Entity.DeptShortCode;
                    model.OrganisationDepartmentMasterDTO.PrintShortDesc = response.Entity.PrintShortDesc;
                    model.OrganisationDepartmentMasterDTO.TeachingActivity = response.Entity.TeachingActivity;
                    ViewData["AcademicNonacademic"] = new SelectList(li, "Text", "Value", response.Entity.AcademicNonacademic);

                }
                return PartialView("/Views/Organisation/OrganisationDepartmentMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Edit(OrganisationDepartmentMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationDepartmentMasterDTO != null)
                    {
                        if (model != null && model.OrganisationDepartmentMasterDTO != null)
                        {
                            model.OrganisationDepartmentMasterDTO.ConnectionString = _connectioString;
                            model.OrganisationDepartmentMasterDTO.DepartmentName = model.DepartmentName;
                            model.OrganisationDepartmentMasterDTO.DeptShortCode = model.DeptShortCode;
                            model.OrganisationDepartmentMasterDTO.PrintShortDesc = model.PrintShortDesc;
                            model.OrganisationDepartmentMasterDTO.TeachingActivity = model.TeachingActivity;
                            model.OrganisationDepartmentMasterDTO.AcademicNonacademic = model.AcademicNonacademic;
                            model.OrganisationDepartmentMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);  //model.ModifiedBy;
                            IBaseEntityResponse<OrganisationDepartmentMaster> response = _organisationDepartmentMasterBA.UpdateOrganisationDepartmentMaster(model.OrganisationDepartmentMasterDTO);
                            model.OrganisationDepartmentMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                        }
                    }

                    return Json(model.OrganisationDepartmentMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        public ActionResult Delete(int ID)
        {
            OrganisationDepartmentMasterViewModel model = new OrganisationDepartmentMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        OrganisationDepartmentMaster OrganisationDepartmentMasterDTO = new OrganisationDepartmentMaster();
                        OrganisationDepartmentMasterDTO.ConnectionString = _connectioString;
                        OrganisationDepartmentMasterDTO.ID = ID;
                        OrganisationDepartmentMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);//model.DeletedBy;
                        IBaseEntityResponse<OrganisationDepartmentMaster> response = _organisationDepartmentMasterBA.DeleteOrganisationDepartmentMaster(OrganisationDepartmentMasterDTO);
                        model.OrganisationDepartmentMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.OrganisationDepartmentMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("Please review your form");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region Methods

        public IEnumerable<OrganisationDepartmentMasterViewModel> GetOrganisationDepartmentMaster(out int TotalRecords)
        {
            OrganisationDepartmentMasterSearchRequest searchRequest = new OrganisationDepartmentMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationDepartmentMasterViewModel> listOrganisationDepartmentMasterViewModel = new List<OrganisationDepartmentMasterViewModel>();
            List<OrganisationDepartmentMaster> listOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> baseEntityCollectionResponse = _organisationDepartmentMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationDepartmentMaster item in listOrganisationDepartmentMaster)
                    {
                        OrganisationDepartmentMasterViewModel organisationDepartmentMasterViewModel = new OrganisationDepartmentMasterViewModel();
                        organisationDepartmentMasterViewModel.OrganisationDepartmentMasterDTO = item;
                        listOrganisationDepartmentMasterViewModel.Add(organisationDepartmentMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationDepartmentMasterViewModel;
        }

        #endregion

        #region AjaxHandler


        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc        
            IEnumerable<OrganisationDepartmentMasterViewModel> filteredOrganisationDepartmentMasterViewModel;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "DepartmentName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or DeptShortCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "DeptShortCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "DepartmentName Like '%" + param.sSearch + "%' or DeptShortCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;

            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            //Check whether the companies should be filtered by keyword

            filteredOrganisationDepartmentMasterViewModel = GetOrganisationDepartmentMaster(out TotalRecords);
            var displayedPosts = filteredOrganisationDepartmentMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.DepartmentName.ToString(), c.DeptShortCode.ToString(), Convert.ToString(c.ID) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}