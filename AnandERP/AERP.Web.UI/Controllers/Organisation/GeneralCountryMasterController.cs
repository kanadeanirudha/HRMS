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
    public class GeneralCountryMasterController : BaseController
    {
        IGeneralCountryMasterBA _generalCountryMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralCountryMasterController()
        {
            _generalCountryMasterBA = new GeneralCountryMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralCountryMaster/Index.cshtml");
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
                GeneralCountryMasterViewModel model = new GeneralCountryMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralCountryMaster/List.cshtml", model);
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
            GeneralCountryMasterViewModel model = new GeneralCountryMasterViewModel();
            return PartialView("/Views/GeneralMaster/GeneralCountryMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralCountryMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralCountryMasterDTO != null)
                    {
                        model.GeneralCountryMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCountryMasterDTO.CountryName = model.CountryName;
                        // model.GeneralCountryMasterDTO.SeqNo = model.SeqNo; ;
                        model.GeneralCountryMasterDTO.ContryCode = model.ContryCode;
                        model.GeneralCountryMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralCountryMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCountryMaster> response = _generalCountryMasterBA.InsertGeneralCountryMaster(model.GeneralCountryMasterDTO);
                        model.GeneralCountryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.GeneralCountryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralCountryMasterViewModel model = new GeneralCountryMasterViewModel();
            try
            {
                model.GeneralCountryMasterDTO = new GeneralCountryMaster();
                model.GeneralCountryMasterDTO.ID = id;
                model.GeneralCountryMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralCountryMaster> response = _generalCountryMasterBA.SelectByID(model.GeneralCountryMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralCountryMasterDTO.ID = response.Entity.ID;
                    model.GeneralCountryMasterDTO.CountryName = response.Entity.CountryName;
                    // model.GeneralCountryMasterDTO.SeqNo = response.Entity.SeqNo;
                    model.GeneralCountryMasterDTO.ContryCode = response.Entity.ContryCode;
                    model.GeneralCountryMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    model.GeneralCountryMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    model.GeneralCountryMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralMaster/GeneralCountryMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralCountryMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralCountryMasterDTO != null)
                {
                    if (model != null && model.GeneralCountryMasterDTO != null)
                    {
                        model.GeneralCountryMasterDTO.ConnectionString = _connectioString;
                        model.GeneralCountryMasterDTO.CountryName = model.CountryName;
                        model.GeneralCountryMasterDTO.SeqNo = model.SeqNo;
                        model.GeneralCountryMasterDTO.ContryCode = model.ContryCode;
                        model.GeneralCountryMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralCountryMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralCountryMaster> response = _generalCountryMasterBA.UpdateGeneralCountryMaster(model.GeneralCountryMasterDTO);
                        model.GeneralCountryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralCountryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public ActionResult Delete(int ID)
        {
            GeneralCountryMasterViewModel model = new GeneralCountryMasterViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                GeneralCountryMaster generalCountryMasterDTO = new GeneralCountryMaster();
                generalCountryMasterDTO.ConnectionString = _connectioString;
                generalCountryMasterDTO.ID = ID;
                generalCountryMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralCountryMaster> response = _generalCountryMasterBA.DeleteGeneralCountryMaster(generalCountryMasterDTO);
                model.GeneralCountryMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.GeneralCountryMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralCountryMasterViewModel> GetGeneralCountryMaster(out int TotalRecords)
        {
            GeneralCountryMasterSearchRequest searchRequest = new GeneralCountryMasterSearchRequest();
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
            List<GeneralCountryMasterViewModel> listGeneralCountryMasterViewModel = new List<GeneralCountryMasterViewModel>();
            List<GeneralCountryMaster> listGeneralCountryMaster = new List<GeneralCountryMaster>();
            IBaseEntityCollectionResponse<GeneralCountryMaster> baseEntityCollectionResponse = _generalCountryMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralCountryMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralCountryMaster item in listGeneralCountryMaster)
                    {
                        GeneralCountryMasterViewModel generalCountryMasterViewModel = new GeneralCountryMasterViewModel();
                        generalCountryMasterViewModel.GeneralCountryMasterDTO = item;
                        listGeneralCountryMasterViewModel.Add(generalCountryMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralCountryMasterViewModel;
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

                IEnumerable<GeneralCountryMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "CountryName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "CountryName Like '%" + param.sSearch + "%' or ContryCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
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
                            _searchBy = "CountryName Like '%" + param.sSearch + "%' or ContryCode Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetGeneralCountryMaster(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.CountryName.ToString(), c.ContryCode.ToString(), Convert.ToString(c.ID), c.IsUserDefined.ToString() };

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