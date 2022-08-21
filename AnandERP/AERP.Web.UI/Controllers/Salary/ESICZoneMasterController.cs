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
using AERP.DataProvider;
namespace AERP.Web.UI.Controllers
{
    public class ESICZoneMasterController : BaseController
    {
        IESICZoneMasterBA _ESICZoneMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public ESICZoneMasterController()
        {
            _ESICZoneMasterBA = new ESICZoneMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Salary/ESICZoneMaster/Index.cshtml");
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
                ESICZoneMasterViewModel model = new ESICZoneMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Salary/ESICZoneMaster/List.cshtml", model);
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
            ESICZoneMasterViewModel model = new ESICZoneMasterViewModel();
            return PartialView("/Views/Salary/ESICZoneMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(ESICZoneMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.ESICZoneMasterDTO != null)
                {
                    model.ESICZoneMasterDTO.ConnectionString = _connectioString;
                    model.ESICZoneMasterDTO.ZoneName = model.ZoneName;
                    model.ESICZoneMasterDTO.ZoneCode = model.ZoneCode;
                    model.ESICZoneMasterDTO.IsDefault = model.IsDefault;
                    model.ESICZoneMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<ESICZoneMaster> response = _ESICZoneMasterBA.InsertESICZoneMaster(model.ESICZoneMasterDTO);

                    model.ESICZoneMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.ESICZoneMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


                //  }
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
        public ActionResult Edit(Int16 id)
        {
            ESICZoneMasterViewModel model = new ESICZoneMasterViewModel();
            try
            {
                model.ESICZoneMasterDTO = new ESICZoneMaster();
                model.ESICZoneMasterDTO.ID = id;
                model.ESICZoneMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ESICZoneMaster> response = _ESICZoneMasterBA.SelectByID(model.ESICZoneMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.ESICZoneMasterDTO.ID = response.Entity.ID;
                    model.ESICZoneMasterDTO.ZoneName= response.Entity.ZoneName;
                    model.ESICZoneMasterDTO.ZoneCode = response.Entity.ZoneCode;
                    model.ESICZoneMasterDTO.IsDefault = response.Entity.IsDefault;
                    model.ESICZoneMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/Salary/ESICZoneMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult Edit(ESICZoneMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.ESICZoneMasterDTO != null)
                {
                    if (model != null && model.ESICZoneMasterDTO != null)
                    {
                        model.ESICZoneMasterDTO.ConnectionString = _connectioString;
                        model.ESICZoneMasterDTO.ZoneName = model.ZoneName;
                        model.ESICZoneMasterDTO.ZoneCode = model.ZoneCode;
                        model.ESICZoneMasterDTO.IsDefault = model.IsDefault;
                        model.ESICZoneMasterDTO.ID = model.ID;


                        model.ESICZoneMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<ESICZoneMaster> response = _ESICZoneMasterBA.UpdateESICZoneMaster(model.ESICZoneMasterDTO);
                        model.ESICZoneMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.ESICZoneMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }



        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<ESICZoneMaster> response = null;
                ESICZoneMaster ESICZoneMasterDTO = new ESICZoneMaster();
                ESICZoneMasterDTO.ConnectionString = _connectioString;
                ESICZoneMasterDTO.ID = Convert.ToInt16(ID);
                ESICZoneMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _ESICZoneMasterBA.DeleteESICZoneMaster(ESICZoneMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<ESICZoneMasterViewModel> GetESICZoneMaster(out int TotalRecords)
        {
            ESICZoneMasterSearchRequest searchRequest = new ESICZoneMasterSearchRequest();
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
            List<ESICZoneMasterViewModel> listESICZoneMasterViewModel = new List<ESICZoneMasterViewModel>();
            List<ESICZoneMaster> listESICZoneMaster = new List<ESICZoneMaster>();
            IBaseEntityCollectionResponse<ESICZoneMaster> baseEntityCollectionResponse = _ESICZoneMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listESICZoneMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (ESICZoneMaster item in listESICZoneMaster)
                    {
                        ESICZoneMasterViewModel ESICZoneMasterViewModel = new ESICZoneMasterViewModel();
                        ESICZoneMasterViewModel.ESICZoneMasterDTO = item;
                        listESICZoneMasterViewModel.Add(ESICZoneMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listESICZoneMasterViewModel;
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

                IEnumerable<ESICZoneMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ZoneName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ZoneName Like '%" + param.sSearch + "%' or A.ZoneCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.ZoneCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.ZoneCode Like '%" + param.sSearch + "%' or A.ZoneName Like '%" + param.sSearch + "%' ";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetESICZoneMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ZoneName), Convert.ToString(c.ZoneCode),Convert.ToString(c.ID), Convert.ToString(c.IsDefault) };

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