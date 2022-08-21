using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
//using AERP.ViewModel.Implementation.Employee;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class GeneralExperienceTypeMasterController : BaseController
    {
        IGeneralExperienceTypeMasterBA _GeneralExperienceTypeMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralExperienceTypeMasterController()
        {
            _GeneralExperienceTypeMasterBA = new GeneralExperienceTypeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Employee/GeneralExperienceTypeMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralExperienceTypeMasterViewModel model = new GeneralExperienceTypeMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/GeneralExperienceTypeMaster/List.cshtml", model);
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
            GeneralExperienceTypeMasterViewModel model = new GeneralExperienceTypeMasterViewModel();
            return PartialView("/Views/Employee/GeneralExperienceTypeMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(GeneralExperienceTypeMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralExperienceTypeMasterDTO != null)
                    {
                        model.GeneralExperienceTypeMasterDTO.ConnectionString = _connectioString;
                        model.GeneralExperienceTypeMasterDTO.ExperienceTypeDescription = model.ExperienceTypeDescription;
                        model.GeneralExperienceTypeMasterDTO.IsActive = true; 
                        model.GeneralExperienceTypeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralExperienceTypeMaster> response = _GeneralExperienceTypeMasterBA.InsertGeneralExperienceTypeMaster(model.GeneralExperienceTypeMasterDTO);
                        model.GeneralExperienceTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.GeneralExperienceTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int id)
        {
            GeneralExperienceTypeMasterViewModel model = new GeneralExperienceTypeMasterViewModel();
            try
            {
                model.GeneralExperienceTypeMasterDTO = new GeneralExperienceTypeMaster();
                model.GeneralExperienceTypeMasterDTO.ID = id;
                model.GeneralExperienceTypeMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralExperienceTypeMaster> response = _GeneralExperienceTypeMasterBA.SelectByID(model.GeneralExperienceTypeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralExperienceTypeMasterDTO.ID = response.Entity.ID;
                    model.GeneralExperienceTypeMasterDTO.ExperienceTypeDescription = response.Entity.ExperienceTypeDescription;
                    //model.GeneralExperienceTypeMasterDTO.IsActive = response.Entity.IsActive;  
                    model.GeneralExperienceTypeMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Employee/GeneralExperienceTypeMaster/Edit.cshtml",model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralExperienceTypeMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralExperienceTypeMasterDTO != null)
                {
                    if (model != null && model.GeneralExperienceTypeMasterDTO != null)
                    {
                        model.GeneralExperienceTypeMasterDTO.ConnectionString = _connectioString;
                        model.GeneralExperienceTypeMasterDTO.ExperienceTypeDescription = model.ExperienceTypeDescription;
                        model.GeneralExperienceTypeMasterDTO.IsActive = true;
                        model.GeneralExperienceTypeMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralExperienceTypeMaster> response = _GeneralExperienceTypeMasterBA.UpdateGeneralExperienceTypeMaster(model.GeneralExperienceTypeMasterDTO);
                        model.GeneralExperienceTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralExperienceTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        
        public ActionResult Delete(int ID)
        {
            GeneralExperienceTypeMasterViewModel model = new GeneralExperienceTypeMasterViewModel();
            if (ID > 0)
            {
                
                    GeneralExperienceTypeMaster GeneralExperienceTypeMasterDTO = new GeneralExperienceTypeMaster();
                    GeneralExperienceTypeMasterDTO.ConnectionString = _connectioString;
                    GeneralExperienceTypeMasterDTO.ID = ID;
                    GeneralExperienceTypeMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralExperienceTypeMaster> response = _GeneralExperienceTypeMasterBA.DeleteGeneralExperienceTypeMaster(GeneralExperienceTypeMasterDTO);
                    model.GeneralExperienceTypeMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                
                return Json(model.GeneralExperienceTypeMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralExperienceTypeMasterViewModel> GetGeneralExperienceTypeMaster(out int TotalRecords)
        {
            GeneralExperienceTypeMasterSearchRequest searchRequest = new GeneralExperienceTypeMasterSearchRequest();
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
            List<GeneralExperienceTypeMasterViewModel> listGeneralExperienceTypeMasterViewModel = new List<GeneralExperienceTypeMasterViewModel>();
            List<GeneralExperienceTypeMaster> listGeneralExperienceTypeMaster = new List<GeneralExperienceTypeMaster>();
            IBaseEntityCollectionResponse<GeneralExperienceTypeMaster> baseEntityCollectionResponse = _GeneralExperienceTypeMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralExperienceTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralExperienceTypeMaster item in listGeneralExperienceTypeMaster)
                    {
                        GeneralExperienceTypeMasterViewModel GeneralExperienceTypeMasterViewModel = new GeneralExperienceTypeMasterViewModel();
                        GeneralExperienceTypeMasterViewModel.GeneralExperienceTypeMasterDTO = item;
                        listGeneralExperienceTypeMasterViewModel.Add(GeneralExperienceTypeMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralExperienceTypeMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralExperienceTypeMasterViewModel> filteredGeneralExperienceTypeMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ExperienceTypeDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ExperienceTypeDescription Like '%" + param.sSearch + "%' or ExperienceTypeDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ContryCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "ExperienceTypeDescription Like '%" + param.sSearch + "%' or ExperienceTypeDescription Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGeneralExperienceTypeMaster = GetGeneralExperienceTypeMaster(out TotalRecords);
                var records = filteredGeneralExperienceTypeMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.ExperienceTypeDescription.ToString(), Convert.ToString(c.ID) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}