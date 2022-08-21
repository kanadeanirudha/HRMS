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
    public class GeneralTemperatureMasterController : BaseController
    {
        IGeneralTemperatureMasterBA _GeneralTemperatureMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralTemperatureMasterController()
        {
            _GeneralTemperatureMasterBA = new GeneralTemperatureMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/Inventory/GeneralTemperatureMaster/Index.cshtml");
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
                GeneralTemperatureMasterViewModel model = new GeneralTemperatureMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Inventory/GeneralTemperatureMaster/List.cshtml", model);
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
            GeneralTemperatureMasterViewModel model = new GeneralTemperatureMasterViewModel();

            return PartialView("/Views/Inventory/GeneralTemperatureMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTemperatureMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralTemperatureMasterDTO != null)
                {
                    model.GeneralTemperatureMasterDTO.ConnectionString = _connectioString;
                    model.GeneralTemperatureMasterDTO.GeneralTemperatureMasterID = model.GeneralTemperatureMasterID;
                    model.GeneralTemperatureMasterDTO.TemperatureFrom = model.TemperatureFrom;
                    model.GeneralTemperatureMasterDTO.TemperatureUpto = model.TemperatureUpto;
                    model.GeneralTemperatureMasterDTO.TemperatureType = model.TemperatureType;
                    model.GeneralTemperatureMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTemperatureMaster> response = _GeneralTemperatureMasterBA.InsertGeneralTemperatureMaster(model.GeneralTemperatureMasterDTO);

                    model.GeneralTemperatureMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralTemperatureMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        

        [HttpPost]
        public ActionResult Edit(GeneralTemperatureMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralTemperatureMasterDTO != null)
                {
                    if (model != null && model.GeneralTemperatureMasterDTO != null)
                    {
                        model.GeneralTemperatureMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTemperatureMasterDTO.GeneralTemperatureMasterID = model.GeneralTemperatureMasterID;
                        model.GeneralTemperatureMasterDTO.TemperatureType = model.TemperatureType;
                        model.GeneralTemperatureMasterDTO.TemperatureFrom = model.TemperatureFrom;
                        model.GeneralTemperatureMasterDTO.TemperatureUpto = model.TemperatureUpto;
                        //model.GeneralTemperatureMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralTemperatureMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTemperatureMaster> response = _GeneralTemperatureMasterBA.UpdateGeneralTemperatureMaster(model.GeneralTemperatureMasterDTO);
                        //model.GeneralTemperatureMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                //return Json(model.GeneralTemperatureMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            GeneralTemperatureMasterViewModel model = new GeneralTemperatureMasterViewModel();
            try
            {
                model.GeneralTemperatureMasterDTO = new GeneralTemperatureMaster();
                model.GeneralTemperatureMasterDTO.GeneralTemperatureMasterID = id;
                model.GeneralTemperatureMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralTemperatureMaster> response = _GeneralTemperatureMasterBA.SelectByID(model.GeneralTemperatureMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralTemperatureMasterDTO.TemperatureFrom = response.Entity.TemperatureFrom;
                    model.GeneralTemperatureMasterDTO.TemperatureUpto = response.Entity.TemperatureUpto;
                    model.GeneralTemperatureMasterDTO.TemperatureType = response.Entity.TemperatureType;
                    model.GeneralTemperatureMasterDTO.CreatedBy = response.Entity.CreatedBy;
                   
                }

                return PartialView("/Views/Inventory/GeneralTemperatureMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralTemperatureMasterViewModel model = new GeneralTemperatureMasterViewModel();
        //        model.GeneralTemperatureMasterDTO = new GeneralTemperatureMaster();
        //        model.GeneralTemperatureMasterDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralTemperatureMasterDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralTemperatureMaster> response = _GeneralTemperatureMasterBA.SelectByID(model.GeneralTemperatureMasterDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralTemperatureMasterDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralTemperatureMasterDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralTemperatureMasterDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralTemperatureMasterDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralTemperatureMaster/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<GeneralTemperatureMaster> response = null;
                GeneralTemperatureMaster GeneralTemperatureMasterDTO = new GeneralTemperatureMaster();
                GeneralTemperatureMasterDTO.ConnectionString = _connectioString;
                GeneralTemperatureMasterDTO.ID = Convert.ToInt16(ID);
                GeneralTemperatureMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralTemperatureMasterBA.DeleteGeneralTemperatureMaster(GeneralTemperatureMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralTemperatureMasterViewModel> GetGeneralTemperatureMaster(out int TotalRecords)
        {
            GeneralTemperatureMasterSearchRequest searchRequest = new GeneralTemperatureMasterSearchRequest();
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
            List<GeneralTemperatureMasterViewModel> listGeneralTemperatureMasterViewModel = new List<GeneralTemperatureMasterViewModel>();
            List<GeneralTemperatureMaster> listGeneralTemperatureMaster = new List<GeneralTemperatureMaster>();
            IBaseEntityCollectionResponse<GeneralTemperatureMaster> baseEntityCollectionResponse = _GeneralTemperatureMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTemperatureMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTemperatureMaster item in listGeneralTemperatureMaster)
                    {
                        GeneralTemperatureMasterViewModel GeneralTemperatureMasterViewModel = new GeneralTemperatureMasterViewModel();
                        GeneralTemperatureMasterViewModel.GeneralTemperatureMasterDTO = item;
                        listGeneralTemperatureMasterViewModel.Add(GeneralTemperatureMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTemperatureMasterViewModel;
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

                IEnumerable<GeneralTemperatureMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TempratureType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.TempratureType Like '%" + param.sSearch + "%' or A.TemperatureDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.TemperatureDescription";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "A.TempratureType Like '%" + param.sSearch + "%' or A.TemperatureDescription Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralTemperatureMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.TemperatureType), Convert.ToString(c.TemperatureDescription), Convert.ToString(c.GeneralTemperatureMasterID) };

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