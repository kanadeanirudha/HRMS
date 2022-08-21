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
    public class BankMasterController : BaseController
    {
        IBankMasterBA _BankMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public BankMasterController()
        {
            _BankMasterBA = new BankMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/GeneralMaster/BankMaster/Index.cshtml");
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
                BankMasterViewModel model = new BankMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/GeneralMaster/BankMaster/List.cshtml", model);
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
            BankMasterViewModel model = new BankMasterViewModel();
            return PartialView("/Views/GeneralMaster/BankMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(BankMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.BankMasterDTO != null)
                    {
                        model.BankMasterDTO.ConnectionString = _connectioString;
                        model.BankMasterDTO.BankName= model.BankName;
                        model.BankMasterDTO.BankIFSCCode= model.BankIFSCCode;
                        model.BankMasterDTO.AccountNumber= model.AccountNumber;
                        model.BankMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<BankMaster> response = _BankMasterBA.InsertBankMaster(model.BankMasterDTO);
                        model.BankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.BankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(byte id)
        {
            BankMasterViewModel model = new BankMasterViewModel();
            try
            {
                model.BankMasterDTO = new BankMaster();
                model.BankMasterDTO.ID = id;
                model.BankMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<BankMaster> response = _BankMasterBA.SelectByID(model.BankMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.BankMasterDTO.ID = response.Entity.ID;
                    model.BankMasterDTO.BankName = response.Entity.BankName;
                    model.BankMasterDTO.BankIFSCCode= response.Entity.BankIFSCCode;
                    model.BankMasterDTO.AccountNumber = response.Entity.AccountNumber;
                    model.BankMasterDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView("/Views/GeneralMaster/BankMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(BankMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.BankMasterDTO != null)
                {
                    if (model != null && model.BankMasterDTO != null)
                    {
                        model.BankMasterDTO.ConnectionString = _connectioString;
                        model.BankMasterDTO.BankName = model.BankName;
                        model.BankMasterDTO.BankIFSCCode = model.BankIFSCCode;
                        model.BankMasterDTO.AccountNumber = model.AccountNumber;
                        model.BankMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<BankMaster> response = _BankMasterBA.UpdateBankMaster(model.BankMasterDTO);
                        model.BankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.BankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        public ActionResult Delete(byte ID)
        {
            BankMasterViewModel model = new BankMasterViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                BankMaster BankMasterDTO = new BankMaster();
                BankMasterDTO.ConnectionString = _connectioString;
                BankMasterDTO.ID = ID;
                BankMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<BankMaster> response = _BankMasterBA.DeleteBankMaster(BankMasterDTO);
                model.BankMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.BankMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<BankMasterViewModel> GetBankMaster(out int TotalRecords)
        {
            BankMasterSearchRequest searchRequest = new BankMasterSearchRequest();
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
            List<BankMasterViewModel> listBankMasterViewModel = new List<BankMasterViewModel>();
            List<BankMaster> listBankMaster = new List<BankMaster>();
            IBaseEntityCollectionResponse<BankMaster> baseEntityCollectionResponse = _BankMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listBankMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (BankMaster item in listBankMaster)
                    {
                        BankMasterViewModel BankMasterViewModel = new BankMasterViewModel();
                        BankMasterViewModel.BankMasterDTO = item;
                        listBankMasterViewModel.Add(BankMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listBankMasterViewModel;
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

                IEnumerable<BankMasterViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "BankName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "BankName Like '%" + param.sSearch + "%' or BankIFSCCode Like '%" + param.sSearch + "%' or AccountNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "BankIFSCCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "BankName Like '%" + param.sSearch + "%' or BankIFSCCode Like '%" + param.sSearch + "%' or AccountNumber Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "AccountNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "BankName Like '%" + param.sSearch + "%' or BankIFSCCode Like '%" + param.sSearch + "%' or AccountNumber Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetBankMaster(out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { c.BankName.ToString(), c.BankIFSCCode.ToString(), c.AccountNumber.ToString(), Convert.ToString(c.ID) };

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