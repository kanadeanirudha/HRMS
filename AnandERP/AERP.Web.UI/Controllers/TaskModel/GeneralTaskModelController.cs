using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class GeneralTaskModelController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------

        IGeneralTaskModelBA _GeneralTaskModelBA = null;
       // IFeeCriteriaParametersAndValuesBA _feeCriteriaParametersAndValuesBA = null;
        
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public GeneralTaskModelController()
        {
            _GeneralTaskModelBA = new GeneralTaskModelBA();
            //_feeCriteriaParametersAndValuesBA = new GeneralTaskModelBA();
            
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    return View("/Views/TaskModel/GeneralTaskModel/Index.cshtml");
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                } 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                IGeneralTaskModelViewModel model = new GeneralTaskModelViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/TaskModel/GeneralTaskModel/List.cshtml", model);
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
                IGeneralTaskModelViewModel model = new GeneralTaskModelViewModel();
                model.MenuCodeList = GetMenuCodeAndMenuLink(0); // 0 for MenuCodeList
                model.LinkMenuCodeList = GetMenuCodeAndMenuLink(1); // 1 for LinkMenuCodeList
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Value = "E", Text = "Employee" });
                li.Add(new SelectListItem { Value = "S", Text = "Student" });
                ViewBag.TaskModelApplicableTo = li;
                return PartialView("/Views/TaskModel/GeneralTaskModel/Create.cshtml", model); 
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult Create(GeneralTaskModelViewModel model)
        {
            try
            {
                model.GeneralTaskModelDTO.ConnectionString = _connectioString;
                model.GeneralTaskModelDTO.TaskDescription = model.TaskDescription;
                model.GeneralTaskModelDTO.TaskCode = model.TaskCode;
                model.GeneralTaskModelDTO.TaskModelApplicableTo = model.TaskModelApplicableTo;
                model.GeneralTaskModelDTO.MenuCode = model.MenuCode;
                model.GeneralTaskModelDTO.LinkMenuCode = model.LinkMenuCode; 
                model.GeneralTaskModelDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralTaskModel> response = _GeneralTaskModelBA.InsertGeneralTaskModel(model.GeneralTaskModelDTO);
                model.GeneralTaskModelDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(model.GeneralTaskModelDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        //    try
        //    {
        //        IGeneralTaskModelViewModel model = new GeneralTaskModelViewModel();
        //        model.GeneralTaskModelDTO = new GeneralTaskModel();
        //        model.GeneralTaskModelDTO.ID = ID;
        //        return PartialView("/Views/TaskModel/GeneralTaskModel/Delete.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}
        //[HttpPost]
        //public ActionResult Delete(GeneralTaskModelViewModel model)
        //{
        //    try
        //    {
        //        if ( model.ID > 0)
        //        {
        //            GeneralTaskModel GeneralTaskModelDTO = new GeneralTaskModel();
        //            GeneralTaskModelDTO.ConnectionString = _connectioString;
        //            GeneralTaskModelDTO.ID = model.ID;
        //            GeneralTaskModelDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<GeneralTaskModel> response = _GeneralTaskModelBA.DeleteGeneralTaskModel(GeneralTaskModelDTO);
        //            model.GeneralTaskModelDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            return Json(model.GeneralTaskModelDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(int ID)
        {
            try
            {
                GeneralTaskModelViewModel model = new GeneralTaskModelViewModel();
                if (ID > 0)
                {
                    GeneralTaskModel GeneralTaskModelDTO = new GeneralTaskModel();
                    GeneralTaskModelDTO.ConnectionString = _connectioString;
                    GeneralTaskModelDTO.ID = ID;
                    GeneralTaskModelDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTaskModel> response = _GeneralTaskModelBA.DeleteGeneralTaskModel(GeneralTaskModelDTO);
                    model.GeneralTaskModelDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    return Json(model.GeneralTaskModelDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        #region ------------CONTROLLER NON ACTION METHODS------------
        //Non-Action method to fetch list of Balancesheet
        protected List<GeneralTaskModel> GetMenuCodeAndMenuLink(int flag)
        {
            GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.StatusFlag = flag;
            List<GeneralTaskModel> list = new List<GeneralTaskModel>();
            IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _GeneralTaskModelBA.GetMenuCodeAndMenuLink(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    list = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return list;
        }
        
        // Non-Action method to fetch all records from table.
        [NonAction]
        public List<GeneralTaskModel> GetListGeneralTaskModel( out int TotalRecords)
        {
            List<GeneralTaskModel> listGeneralTaskModel = new List<GeneralTaskModel>();
            GeneralTaskModelSearchRequest searchRequest = new GeneralTaskModelSearchRequest();
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
            IBaseEntityCollectionResponse<GeneralTaskModel> baseEntityCollectionResponse = _GeneralTaskModelBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaskModel = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaskModel;
        }
        #endregion

        #region ------------CONTROLLER AJAX HANDLER METHODS------------
        /// <summary>
        /// AJAX Method for binding List GeneralTaskModel
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralTaskModel> filteredGeneralTaskModel;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "TaskDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%' or TaskCode Like '%" + param.sSearch + "%' or TaskModelApplicableTo Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "TaskCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%' or TaskCode Like '%" + param.sSearch + "%' or TaskModelApplicableTo Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "TaskModelApplicableTo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "(TaskDescription Like '%" + param.sSearch + "%' or TaskCode Like '%" + param.sSearch + "%' or TaskModelApplicableTo Like '%" + param.sSearch + "%')";         //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralTaskModel = GetListGeneralTaskModel( out TotalRecords);    
            var records = filteredGeneralTaskModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.TaskDescription), Convert.ToString(c.TaskCode), Convert.ToString(c.TaskModelApplicableTo), Convert.ToString(c.MenuCode), Convert.ToString(c.LinkMenuCode), Convert.ToString(c.ID) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
