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
    public class GeneralLocationMasterController : BaseController
    {
        IGeneralLocationMasterBA _generalLocationMasterBA = null;
        private readonly ILogger _logException;
        GeneralLocationMasterBaseViewModel _generalLocationMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralLocationMasterController()
        {
            _generalLocationMasterBA = new GeneralLocationMasterBA();
            _generalLocationMasterBaseViewModel = new GeneralLocationMasterBaseViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralLocationMaster/Index.cshtml");
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
                GeneralLocationMasterViewModel model = new GeneralLocationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralLocationMaster/List.cshtml", model);
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
            GeneralLocationMasterViewModel model = new GeneralLocationMasterViewModel();
            try
            {
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> genCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCountryMaster = new SelectList(genCountryMaster, "Value", "Text");

                //string SelectedCountryID = "";
                //List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                //foreach (GeneralRegionMaster item in generalRegionMasterList)
                //{
                //    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                //}
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
                //ViewBag.GeneralRegionMaster = "";

                //string SelectedRegionID = "";
                //List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                //foreach (GeneralCityMaster item in generalCityMasterList)
                //{
                //    generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //}
                ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("/Views/GeneralMaster/GeneralLocationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralLocationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralLocationMasterDTO != null)
                    {
                        model.GeneralLocationMasterDTO.ConnectionString = _connectioString;
                        model.GeneralLocationMasterDTO.CountryID = Convert.ToInt32(model.SelectedCountryID);
                        model.GeneralLocationMasterDTO.LocationAddress = model.LocationAddress;
                        if (model.Latitude == null)
                        {
                            model.GeneralLocationMasterDTO.Latitude = string.Empty;
                        }
                        else
                        {
                            model.GeneralLocationMasterDTO.Latitude = model.Latitude;
                        }
                        if (model.Longitude == null)
                        {
                            model.GeneralLocationMasterDTO.Longitude = string.Empty;
                        }
                        else
                        {
                            model.GeneralLocationMasterDTO.Longitude = model.Longitude;
                        }
                        if (model.PostCode == null)
                        {
                            model.GeneralLocationMasterDTO.PostCode = string.Empty;
                        }
                        else
                        {
                            model.GeneralLocationMasterDTO.PostCode = model.PostCode;
                        }
                        model.GeneralLocationMasterDTO.RegionID = Convert.ToInt32(model.SelectedRegionID);
                        model.GeneralLocationMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID);
                        model.GeneralLocationMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralLocationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralLocationMaster> response = _generalLocationMasterBA.InsertGeneralLocationMaster(model.GeneralLocationMasterDTO);
                        model.GeneralLocationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.GeneralLocationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralLocationMasterViewModel model = new GeneralLocationMasterViewModel();
            try
            {
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

                string SelectedCountryID = string.Empty;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(SelectedCountryID);
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                }

                string SelectedRegionID = string.Empty;
                List<GeneralCityMaster> generalCityMasterList = GetListGeneralCityMaster(SelectedRegionID);
                List<SelectListItem> generalCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in generalCityMasterList)
                {
                    generalCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                model.GeneralLocationMasterDTO = new GeneralLocationMaster();
                model.GeneralLocationMasterDTO.ID = id;
                model.GeneralLocationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralLocationMaster> response = _generalLocationMasterBA.SelectByID(model.GeneralLocationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralLocationMasterDTO.ID = response.Entity.ID;
                    model.GeneralLocationMasterDTO.LocationAddress = response.Entity.LocationAddress;
                    model.GeneralLocationMasterDTO.Latitude = response.Entity.Latitude;
                    model.GeneralLocationMasterDTO.Longitude = response.Entity.Longitude;
                    model.GeneralLocationMasterDTO.PostCode = response.Entity.PostCode;
                    model.GeneralLocationMasterDTO.DefaultFlag = response.Entity.DefaultFlag;
                    model.GeneralLocationMasterDTO.IsUserDefined = response.Entity.IsUserDefined;
                    ViewBag.GeneralCountryMaster = new SelectList(GeneralCountryMaster, "Value", "Text", response.Entity.CountryID.ToString());
                    ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text", response.Entity.RegionID.ToString());
                    ViewBag.GeneralCityMaster = new SelectList(generalCityMaster, "Value", "Text", response.Entity.CityID.ToString());
                }
                return PartialView("/Views/GeneralMaster/GeneralLocationMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralLocationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralLocationMasterDTO != null)
                    {
                        if (model != null && model.GeneralLocationMasterDTO != null)
                        {
                            model.GeneralLocationMasterDTO.ConnectionString = _connectioString;
                            model.GeneralLocationMasterDTO.LocationAddress = model.LocationAddress;
                            if (model.Latitude == null)
                            {
                                model.GeneralLocationMasterDTO.Latitude = string.Empty;
                            }
                            else
                            {
                                model.GeneralLocationMasterDTO.Latitude = model.Latitude;
                            }
                            if (model.Longitude == null)
                            {
                                model.GeneralLocationMasterDTO.Longitude = string.Empty;
                            }
                            else
                            {
                                model.GeneralLocationMasterDTO.Longitude = model.Longitude;
                            }
                            if (model.PostCode == null)
                            {
                                model.GeneralLocationMasterDTO.PostCode = string.Empty;
                            }
                            else
                            {
                                model.GeneralLocationMasterDTO.PostCode = model.PostCode;
                            }
                            model.GeneralLocationMasterDTO.CountryID = Convert.ToInt32(model.SelectedCountryID.ToString());
                            model.GeneralLocationMasterDTO.RegionID = Convert.ToInt32(model.SelectedRegionID.ToString());
                            model.GeneralLocationMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID.ToString());
                            model.GeneralLocationMasterDTO.DefaultFlag = model.DefaultFlag;
                            model.GeneralLocationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<GeneralLocationMaster> response = _generalLocationMasterBA.UpdateGeneralLocationMaster(model.GeneralLocationMasterDTO);
                            model.GeneralLocationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }

                    return Json(model.GeneralLocationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralLocationMasterViewModel model = new GeneralLocationMasterViewModel();

            IBaseEntityResponse<GeneralLocationMaster> response = null;
            try
            {
                if (ID > 0)
                {
                    GeneralLocationMaster GeneralLocationMasterDTO = new GeneralLocationMaster();
                    GeneralLocationMasterDTO.ConnectionString = _connectioString;
                    GeneralLocationMasterDTO.ID = ID;
                    GeneralLocationMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    response = _generalLocationMasterBA.DeleteGeneralLocationMaster(GeneralLocationMasterDTO);
                    model.GeneralLocationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                if (response.Message.Count == 0)
                {
                    return Json(model.GeneralLocationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        public IEnumerable<GeneralLocationMasterViewModel> GetGeneralLocationMaster(out int TotalRecords)
        {
            GeneralLocationMasterSearchRequest searchRequest = new GeneralLocationMasterSearchRequest();
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
            List<GeneralLocationMasterViewModel> listGeneralLocationMasterViewModel = new List<GeneralLocationMasterViewModel>();
            List<GeneralLocationMaster> listGeneralLocationMaster = new List<GeneralLocationMaster>();
            IBaseEntityCollectionResponse<GeneralLocationMaster> baseEntityCollectionResponse = _generalLocationMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralLocationMaster item in listGeneralLocationMaster)
                    {
                        GeneralLocationMasterViewModel generalLocationMasterViewModel = new GeneralLocationMasterViewModel();
                        generalLocationMasterViewModel.GeneralLocationMasterDTO = item;
                        listGeneralLocationMasterViewModel.Add(generalLocationMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralLocationMasterViewModel;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetRegionByCountryID(string SelectedCountryID)
        {
            if (String.IsNullOrEmpty(SelectedCountryID))
            {
                throw new ArgumentNullException("SelectedCountryID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var Region = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in Region select new { id = s.ID, name = s.RegionName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCityByRegionID(string SelectedRegionID)
        {
            if (String.IsNullOrEmpty(SelectedRegionID))
            {
                throw new ArgumentNullException("SelectedRegionID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedRegionID, out id);
            var City = GetListGeneralCityMaster(SelectedRegionID);
            var result = (from s in City select new { id = s.ID, name = s.Description, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        // AjaxHandler Methods
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<GeneralLocationMasterViewModel> filteredGeneralLocationMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LocationAddress";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LocationAddress Like '%" + param.sSearch + "%' or PostCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "PostCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LocationAddress Like '%" + param.sSearch + "%' or PostCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredGeneralLocationMaster = GetGeneralLocationMaster(out TotalRecords);
            var records = filteredGeneralLocationMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.LocationAddress.ToString(), c.PostCode.ToString(), Convert.ToString(c.ID), Convert.ToString(c.IsUserDefined) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}