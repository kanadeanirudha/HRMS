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
    public class GeneralTaxGroupMasterController : BaseController
    {
        IGeneralTaxGroupMasterBA _GeneralTaxGroupMasterBA = null;
        IGeneralTaxMasterBA _GeneralTaxMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralTaxGroupMasterController()
        {
            _GeneralTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
            _GeneralTaxMasterBA = new GeneralTaxMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralTaxGroupMaster/Index.cshtml");
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
                GeneralTaxGroupMasterViewModel model = new GeneralTaxGroupMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralTaxGroupMaster/List.cshtml", model);
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
            int TaxGroupMasterID = 0;

            GeneralTaxGroupMasterViewModel model = new GeneralTaxGroupMasterViewModel();
            model.GetGeneralTaxMasterList = GetListGeneralTaxMaster(TaxGroupMasterID);
            //foreach (var b in model.GetGeneralTaxMasterList)
            //{
            //    if (b.TaxFlag == true)
            //    {
            //        model.SelectedTaxMasterID = "selected";
            //    }
            //    else
            //    {
            //        model.SelectedTaxMasterID = string.Empty;
            //    }
            //}
            return PartialView("/Views/GeneralMaster/GeneralTaxGroupMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTaxGroupMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralTaxGroupMasterDTO != null)
                    {
                        model.GeneralTaxGroupMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTaxGroupMasterDTO.TaxGroupName = model.TaxGroupName;
                        model.GeneralTaxGroupMasterDTO.SelectedTaxMaterIDs = model.SelectedTaxMaterIDs;
                        model.GeneralTaxGroupMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTaxGroupMaster> response = _GeneralTaxGroupMasterBA.InsertGeneralTaxGroupMaster(model.GeneralTaxGroupMasterDTO);
                        model.GeneralTaxGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.GeneralTaxGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralTaxGroupMasterViewModel model = new GeneralTaxGroupMasterViewModel();
            try
            {
                //int TaxGroupMasterID = 0;
                model.GeneralTaxGroupMasterDTO = new GeneralTaxGroupMaster();
                model.GeneralTaxGroupMasterDTO.ID = id;
                model.GeneralTaxGroupMasterDTO.ConnectionString = _connectioString;
                model.GetGeneralTaxMasterList = GetListGeneralTaxMaster(id);
                foreach (var b in model.GetGeneralTaxMasterList)
                {
                    if (b.TaxFlag == true)
                    {
                        model.SelectedTaxMasterID = "selected";
                    }
                    else
                    {
                        model.SelectedTaxMasterID = string.Empty;
                    }
                }



                IBaseEntityResponse<GeneralTaxGroupMaster> response = _GeneralTaxGroupMasterBA.SelectByID(model.GeneralTaxGroupMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralTaxGroupMasterDTO.ID = response.Entity.ID;
                    model.GeneralTaxGroupMasterDTO.TaxGroupName = response.Entity.TaxGroupName;
                    model.GeneralTaxGroupMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralMaster/GeneralTaxGroupMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralTaxGroupMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralTaxGroupMasterDTO != null)
                {
                    if (model != null && model.GeneralTaxGroupMasterDTO != null)
                    {
                        model.GeneralTaxGroupMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTaxGroupMasterDTO.TaxGroupName = model.TaxGroupName;
                        model.GeneralTaxGroupMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTaxGroupMaster> response = _GeneralTaxGroupMasterBA.UpdateGeneralTaxGroupMaster(model.GeneralTaxGroupMasterDTO);
                        model.GeneralTaxGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralTaxGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public ActionResult Delete(int ID)
        {
            GeneralTaxGroupMasterViewModel model = new GeneralTaxGroupMasterViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                GeneralTaxGroupMaster GeneralTaxGroupMasterDTO = new GeneralTaxGroupMaster();
                GeneralTaxGroupMasterDTO.ConnectionString = _connectioString;
                GeneralTaxGroupMasterDTO.ID = ID;
                GeneralTaxGroupMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<GeneralTaxGroupMaster> response = _GeneralTaxGroupMasterBA.DeleteGeneralTaxGroupMaster(GeneralTaxGroupMasterDTO);
                model.GeneralTaxGroupMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.GeneralTaxGroupMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region Methods


        [HttpGet]
        public ActionResult GetTaxSummaryForDisplay(bool IsOtherState, int FromMasterID, string FromDetailTable)
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            try
            {
                searchRequest.ConnectionString = _connectioString;
                searchRequest.IsOtherState = IsOtherState;
                searchRequest.FromMasterID = FromMasterID;
                searchRequest.FromDetailTable = FromDetailTable;

                List<GeneralTaxGroupMaster> listGeneralTaxMaster = new List<GeneralTaxGroupMaster>();
                IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _GeneralTaxGroupMasterBA.GetTaxSummaryForDisplay(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.TaxName).ToList();
                    }
                }
                ViewData["TaxList"] = listGeneralTaxMaster;
                ViewData["TaxColumns"] = listGeneralTaxMaster[0].TaxList.Replace(", ",",");
                
                return PartialView("/Views/GeneralMaster/GeneralTaxGroupMaster/TaxSummaryForDisplay.cshtml");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GeneralTaxGroupMasterViewModel> GetGeneralTaxGroupMaster(out int TotalRecords)
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
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
            List<GeneralTaxGroupMasterViewModel> listGeneralTaxGroupMasterViewModel = new List<GeneralTaxGroupMasterViewModel>();
            List<GeneralTaxGroupMaster> listGeneralTaxGroupMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _GeneralTaxGroupMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxGroupMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTaxGroupMaster item in listGeneralTaxGroupMaster)
                    {
                        GeneralTaxGroupMasterViewModel GeneralTaxGroupMasterViewModel = new GeneralTaxGroupMasterViewModel();
                        GeneralTaxGroupMasterViewModel.GeneralTaxGroupMasterDTO = item;
                        listGeneralTaxGroupMasterViewModel.Add(GeneralTaxGroupMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaxGroupMasterViewModel;
        }
        #endregion

        protected List<GeneralTaxMaster> GetListGeneralTaxMaster(int TaxGroupMasterID)
        {
            GeneralTaxMasterSearchRequest searchRequest = new GeneralTaxMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TaxGroupMasterID = TaxGroupMasterID;
            List<GeneralTaxMaster> listGeneralTaxMaster = new List<GeneralTaxMaster>();
            IBaseEntityCollectionResponse<GeneralTaxMaster> baseEntityCollectionResponse = _GeneralTaxMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.TaxName).ToList();
                }
            }
            return listGeneralTaxMaster;
        }




        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralTaxGroupMasterViewModel> filteredTaxMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "TaxGroupName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "TaxGroupName Like '%" + param.sSearch + "%' or TaxGroupName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredTaxMaster = GetGeneralTaxGroupMaster(out TotalRecords);
                var records = filteredTaxMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.TaxGroupName.ToString(), Convert.ToString(c.ID) };

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