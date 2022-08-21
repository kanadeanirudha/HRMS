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
    public class AccountHeadMasterController : BaseController
    {
        IAccountHeadMasterBA _AccountHeadMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountHeadMasterController()
        {
            _AccountHeadMasterBA = new AccountHeadMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Accounts/AccountHeadMaster/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                AccountHeadMasterViewModel model = new AccountHeadMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/AccountHeadMaster/List.cshtml", model);
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
            AccountHeadMasterViewModel model = new AccountHeadMasterViewModel();

            //**********************Printing Sequence ********************
            List<SelectListItem> PrintingSequence = new List<SelectListItem>();
            ViewBag.PrintingSequence = new SelectList(PrintingSequence, "Value", "Text");
            List<SelectListItem> li_PrintingSequence = new List<SelectListItem>();
            li_PrintingSequence.Add(new SelectListItem { Text = "1", Value = "1" });
            li_PrintingSequence.Add(new SelectListItem { Text = "2", Value = "2" });
            li_PrintingSequence.Add(new SelectListItem { Text = "3", Value = "3" });
            li_PrintingSequence.Add(new SelectListItem { Text = "4", Value = "4" });
            li_PrintingSequence.Add(new SelectListItem { Text = "5", Value = "5" });
            li_PrintingSequence.Add(new SelectListItem { Text = "6", Value = "6" });
            li_PrintingSequence.Add(new SelectListItem { Text = "7", Value = "7" });
            li_PrintingSequence.Add(new SelectListItem { Text = "8", Value = "8" });
            li_PrintingSequence.Add(new SelectListItem { Text = "9", Value = "9" });
            li_PrintingSequence.Add(new SelectListItem { Text = "10", Value = "10" });
            ViewData["PrintingSequence"] = li_PrintingSequence;

            //**********************Credit Debit Flag ********************
            List<SelectListItem> CreditDebitFlag = new List<SelectListItem>();
            ViewBag.CreditDebitFlag = new SelectList(CreditDebitFlag, "Value", "Text");
            List<SelectListItem> li_CreditDebitFlag = new List<SelectListItem>();
            li_CreditDebitFlag.Add(new SelectListItem { Text = "Debit", Value = "D" });
            li_CreditDebitFlag.Add(new SelectListItem { Text = "Credit", Value = "C" });
            ViewData["CreditDebitFlag"] = li_CreditDebitFlag;

            return PartialView("/Views/Accounts/AccountHeadMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(AccountHeadMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.AccountHeadMasterDTO != null)
                {
                    model.AccountHeadMasterDTO.ConnectionString = _connectioString;
                    model.AccountHeadMasterDTO.ID = model.ID;
                    model.AccountHeadMasterDTO.HeadCode = model.HeadCode;
                    model.AccountHeadMasterDTO.HeadName = model.HeadName;
                    model.AccountHeadMasterDTO.PrintingSequence = model.PrintingSequence;
                    model.AccountHeadMasterDTO.CreditDebitFlag = model.CreditDebitFlag;
                    model.AccountHeadMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountHeadMaster> response = _AccountHeadMasterBA.InsertAccountHeadMaster(model.AccountHeadMasterDTO);

                    model.AccountHeadMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.AccountHeadMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(AccountHeadMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.AccountHeadMasterDTO != null)
                {
                    if (model != null && model.AccountHeadMasterDTO != null)
                    {
                        model.AccountHeadMasterDTO.ConnectionString = _connectioString;
                        //model.AccountHeadMasterDTO.AccountHeadMasterID = model.AccountHeadMasterID;
                        //model.AccountHeadMasterDTO.TemperatureType = model.TemperatureType;
                        //model.AccountHeadMasterDTO.TemperatureFrom = model.TemperatureFrom;
                        //model.AccountHeadMasterDTO.TemperatureUpto = model.TemperatureUpto;
                        //model.AccountHeadMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.AccountHeadMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountHeadMaster> response = _AccountHeadMasterBA.UpdateAccountHeadMaster(model.AccountHeadMasterDTO);
                        //model.AccountHeadMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                //return Json(model.AccountHeadMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            AccountHeadMasterViewModel model = new AccountHeadMasterViewModel();
            try
            {
                model.AccountHeadMasterDTO = new AccountHeadMaster();
               // model.AccountHeadMasterDTO.AccountHeadMasterID = id;
                model.AccountHeadMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<AccountHeadMaster> response = _AccountHeadMasterBA.GetAccountHeadMasterByID(model.AccountHeadMasterDTO);
                if (response != null && response.Entity != null)
                {
                    //model.AccountHeadMasterDTO.TemperatureFrom = response.Entity.TemperatureFrom;
                    //model.AccountHeadMasterDTO.TemperatureUpto = response.Entity.TemperatureUpto;
                    //model.AccountHeadMasterDTO.TemperatureType = response.Entity.TemperatureType;
                    model.AccountHeadMasterDTO.CreatedBy = response.Entity.CreatedBy;

                }

                return PartialView("/Views/Accounts/AccountHeadMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<AccountHeadMaster> response = null;
                AccountHeadMaster AccountHeadMasterDTO = new AccountHeadMaster();
                AccountHeadMasterDTO.ConnectionString = _connectioString;
                AccountHeadMasterDTO.ID = Convert.ToByte(ID);
                AccountHeadMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _AccountHeadMasterBA.DeleteAccountHeadMaster(AccountHeadMasterDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<AccountHeadMasterViewModel> GetAccountHeadMaster(out int TotalRecords)
        {
            AccountHeadMasterSearchRequest searchRequest = new AccountHeadMasterSearchRequest();
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
            List<AccountHeadMasterViewModel> listAccountHeadMasterViewModel = new List<AccountHeadMasterViewModel>();
            List<AccountHeadMaster> listAccountHeadMaster = new List<AccountHeadMaster>();
            IBaseEntityCollectionResponse<AccountHeadMaster> baseEntityCollectionResponse = _AccountHeadMasterBA.GetAccountHeadMasterBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountHeadMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (AccountHeadMaster item in listAccountHeadMaster)
                    {
                        AccountHeadMasterViewModel AccountHeadMasterViewModel = new AccountHeadMasterViewModel();
                        AccountHeadMasterViewModel.AccountHeadMasterDTO = item;
                        listAccountHeadMasterViewModel.Add(AccountHeadMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountHeadMasterViewModel;
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

                IEnumerable<AccountHeadMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.HeadCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.HeadCode Like '%" + param.sSearch + "%' or A.HeadName Like '%" + param.sSearch + "%' or A.PrintingSequence Like '%" + param.sSearch + "%' or A.CreditDebitFlag Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.HeadName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.HeadCode Like '%" + param.sSearch + "%' or A.HeadName Like '%" + param.sSearch + "%' or A.PrintingSequence Like '%" + param.sSearch + "%' or A.CreditDebitFlag Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.PrintingSequence";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.HeadCode Like '%" + param.sSearch + "%' or A.HeadName Like '%" + param.sSearch + "%' or A.PrintingSequence Like '%" + param.sSearch + "%' or A.CreditDebitFlag Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.CreditDebitFlag";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = "A.HeadCode Like '%" + param.sSearch + "%' or A.HeadName Like '%" + param.sSearch + "%' or A.PrintingSequence Like '%" + param.sSearch + "%'or A.CreditDebitFlag Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetAccountHeadMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.HeadCode), Convert.ToString(c.HeadName), Convert.ToString(c.PrintingSequence), Convert.ToString(c.CreditDebitFlag), Convert.ToString(c.ID) };

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