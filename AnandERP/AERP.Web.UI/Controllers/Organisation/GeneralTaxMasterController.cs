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
    public class GeneralTaxMasterController : BaseController
    {
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

        public GeneralTaxMasterController()
        {
            _GeneralTaxMasterBA = new GeneralTaxMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/GeneralTaxMaster/Index.cshtml");
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
                GeneralTaxMasterViewModel model = new GeneralTaxMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/GeneralTaxMaster/List.cshtml", model);
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
            GeneralTaxMasterViewModel model = new GeneralTaxMasterViewModel();
            return PartialView("/Views/GeneralMaster/GeneralTaxMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTaxMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.GeneralTaxMasterDTO != null)
                    {
                        model.GeneralTaxMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTaxMasterDTO.TaxName = model.TaxName;    
                        model.GeneralTaxMasterDTO.TaxRate = model.TaxRate;
                        model.GeneralTaxMasterDTO.IsOtherState = model.IsOtherState;
                        model.GeneralTaxMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTaxMaster> response = _GeneralTaxMasterBA.InsertGeneralTaxMaster(model.GeneralTaxMasterDTO);
                        model.GeneralTaxMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20 , ActionModeEnum.Insert);

                    }
                    return Json(model.GeneralTaxMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralTaxMasterViewModel model = new GeneralTaxMasterViewModel();
            try
            {                
                model.GeneralTaxMasterDTO = new GeneralTaxMaster();
                model.GeneralTaxMasterDTO.ID = id;
                model.GeneralTaxMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralTaxMaster> response = _GeneralTaxMasterBA.SelectByID(model.GeneralTaxMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralTaxMasterDTO.ID = response.Entity.ID;
                    model.GeneralTaxMasterDTO.TaxName = response.Entity.TaxName;
                   // model.GeneralTaxMasterDTO.SeqNo = response.Entity.SeqNo;
                    model.GeneralTaxMasterDTO.TaxRate = response.Entity.TaxRate;
                    model.GeneralTaxMasterDTO.IsOtherState = response.Entity.IsOtherState;
                    model.GeneralTaxMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralMaster/GeneralTaxMaster/Edit.cshtml",model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralTaxMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralTaxMasterDTO != null)
                {
                    if (model != null && model.GeneralTaxMasterDTO != null)
                    {
                        model.GeneralTaxMasterDTO.ConnectionString = _connectioString;
                        model.GeneralTaxMasterDTO.TaxName = model.TaxName;
                        model.GeneralTaxMasterDTO.TaxRate = model.TaxRate;
                        model.GeneralTaxMasterDTO.IsOtherState = model.IsOtherState;
                        model.GeneralTaxMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralTaxMaster> response = _GeneralTaxMasterBA.UpdateGeneralTaxMaster(model.GeneralTaxMasterDTO);
                        model.GeneralTaxMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.GeneralTaxMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }
        
        public ActionResult Delete(int ID)
        {
            GeneralTaxMasterViewModel model = new GeneralTaxMasterViewModel();
            //if (!ModelState.IsValid)
            //{
                if (ID > 0)
                {
                    GeneralTaxMaster GeneralTaxMasterDTO = new GeneralTaxMaster();
                    GeneralTaxMasterDTO.ConnectionString = _connectioString;
                    GeneralTaxMasterDTO.ID = ID;
                    GeneralTaxMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTaxMaster> response = _GeneralTaxMasterBA.DeleteGeneralTaxMaster(GeneralTaxMasterDTO);
                    model.GeneralTaxMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

                }
                return Json(model.GeneralTaxMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralTaxMasterViewModel> GetGeneralTaxMaster(out int TotalRecords)
        {
            GeneralTaxMasterSearchRequest searchRequest = new GeneralTaxMasterSearchRequest();
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
            List<GeneralTaxMasterViewModel> listGeneralTaxMasterViewModel = new List<GeneralTaxMasterViewModel>();
            List<GeneralTaxMaster> listGeneralTaxMaster = new List<GeneralTaxMaster>();
            IBaseEntityCollectionResponse<GeneralTaxMaster> baseEntityCollectionResponse = _GeneralTaxMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTaxMaster item in listGeneralTaxMaster)
                    {
                        GeneralTaxMasterViewModel GeneralTaxMasterViewModel = new GeneralTaxMasterViewModel();
                        GeneralTaxMasterViewModel.GeneralTaxMasterDTO = item;
                        listGeneralTaxMasterViewModel.Add(GeneralTaxMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTaxMasterViewModel;
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

                IEnumerable<GeneralTaxMasterViewModel> filteredTaxMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "TaxName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "TaxName Like '%" + param.sSearch + "%' or TaxRate Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "TaxRate";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "TaxName Like '%" + param.sSearch + "%' or TaxRate Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredTaxMaster = GetGeneralTaxMaster(out TotalRecords);
                var records = filteredTaxMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.TaxName.ToString(), c.TaxRate.ToString(), Convert.ToString( c.IsOtherState), Convert.ToString(c.ID)};

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