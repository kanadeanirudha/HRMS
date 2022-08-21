using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class AccountVoucherSettingMasterController : BaseController
    {
        IAccountVoucherSettingMasterServiceAccess _AccountVoucherSettingMasterServiceAcess = null;
        IAccountTransactionTypeMasterServiceAccess _AccountTransactionTypeMasterServiceAcess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public AccountVoucherSettingMasterController()
        {
            _AccountVoucherSettingMasterServiceAcess = new AccountVoucherSettingMasterServiceAccess();
            _AccountTransactionTypeMasterServiceAcess = new AccountTransactionTypeMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            if (Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["FinMgr"]) > 0)
            {
                return View("/Views/AccountVoucherSettingMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
            

        }

        public ActionResult List(string selectedBalsheet, string actionMode, string AccSessionID)
        {
            try
            {
                AccountVoucherSettingMasterViewModel model = new AccountVoucherSettingMasterViewModel();
                //if (!string.IsNullOrEmpty(selectedBalsheet) || !string.IsNullOrEmpty(AccSessionID))
                if (!string.IsNullOrEmpty(selectedBalsheet) && !string.IsNullOrEmpty(AccSessionID))
                {
                    model.AccSessionID = !string.IsNullOrEmpty(AccSessionID) ? Convert.ToInt32(AccSessionID) : 0;
                    if (!string.IsNullOrEmpty(actionMode))
                    {
                        TempData["ActionMode"] = actionMode;
                    }
                }
                    model.ListGetSession = GetAllAccountSession();

                    return PartialView("/Views/AccountVoucherSettingMaster/List.cshtml", model);
                
               
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create( string AccSessionID)
        {
            string AccBalsheetMstID=string.Empty;
            AccountVoucherSettingMasterViewModel model = new AccountVoucherSettingMasterViewModel();
            if (Convert.ToInt32(!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetID"])) ? Session["BalancesheetID"] : 0) > 0)
            {
                model.AccBalsheetMstID = Convert.ToInt32(Session["BalancesheetID"]);
                AccBalsheetMstID = Convert.ToString(model.AccBalsheetMstID);
                model.AccBalsheetMstName = Convert.ToString(Session["BalancesheetName"]);
            }
            List<AccountTransactionTypeMaster> AccountTransactionTypeMaster = GetListAccountVoucherSettingMaster(AccBalsheetMstID, AccSessionID);
            List<SelectListItem> AccountTransactionTypeMasterList = new List<SelectListItem>();

            foreach (AccountTransactionTypeMaster item in AccountTransactionTypeMaster)
            {
                AccountTransactionTypeMasterList.Add(new SelectListItem { Text = item.TransactionTypeName, Value = Convert.ToString((item.TransactionTypeName) + "-" + (item.TransactionTypeCode)) });
            }
            ViewBag.AccountTransactionTypeMasterList = new SelectList(AccountTransactionTypeMasterList, "Value", "Text");
            
            //*************** Drop down list for account session************//
            List<AccountSessionMaster> AccountSessionMasterList = GetAllAccountSession();
            List<SelectListItem> AccountSessionList = new List<SelectListItem>();
            foreach (AccountSessionMaster item in AccountSessionMasterList)
            {
                AccountSessionList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.AccountSessionList = new SelectList(AccountSessionList, "Value", "Text", model.AccSessionID);
            
            return PartialView("/Views/AccountVoucherSettingMaster/Create.cshtml", model);

         
        }

        [HttpPost]
        public ActionResult Create(AccountVoucherSettingMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.AccountVoucherSettingMasterDTO != null)
                {
                    model.AccountVoucherSettingMasterDTO.ConnectionString = _connectioString;
                    model.AccountVoucherSettingMasterDTO.ID = model.ID;
                    model.AccountVoucherSettingMasterDTO.AccSessionID = model.AccSessionID;
                    model.AccountVoucherSettingMasterDTO.AccBalsheetMstID = model.AccBalsheetMstID;

                    model.AccountVoucherSettingMasterDTO.TransactionType = model.TransactionType;
                    string accnm = model.AccountVoucherSettingMasterDTO.TransactionType;
                    string[] accnmArray = accnm.Split('-');
                    model.AccountVoucherSettingMasterDTO.TransactionType = Convert.ToString(accnmArray[0]);
                    model.AccountVoucherSettingMasterDTO.TransactionTypeCode = accnmArray[1];
                    
                    model.AccountVoucherSettingMasterDTO.VoucherNumber = model.VoucherNumber;
                    model.AccountVoucherSettingMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<AccountVoucherSettingMaster> response = _AccountVoucherSettingMasterServiceAcess.InsertAccountVoucherSettingMaster(model.AccountVoucherSettingMasterDTO);

                    model.AccountVoucherSettingMasterDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.AccountVoucherSettingMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(AccountVoucherSettingMasterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.AccountVoucherSettingMasterDTO != null)
                {
                    if (model != null && model.AccountVoucherSettingMasterDTO != null)
                    {
                        model.AccountVoucherSettingMasterDTO.ConnectionString = _connectioString;
                       // model.AccountVoucherSettingMasterDTO.AccountVoucherSettingMasterID = model.AccountVoucherSettingMasterID;
                        //model.AccountVoucherSettingMasterDTO.TemperatureType = model.TemperatureType;
                        //model.AccountVoucherSettingMasterDTO.TemperatureFrom = model.TemperatureFrom;
                        //model.AccountVoucherSettingMasterDTO.TemperatureUpto = model.TemperatureUpto;
                        //model.AccountVoucherSettingMasterDTO.DefaultFlag = model.DefaultFlag;
                        model.AccountVoucherSettingMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<AccountVoucherSettingMaster> response = _AccountVoucherSettingMasterServiceAcess.UpdateAccountVoucherSettingMaster(model.AccountVoucherSettingMasterDTO);
                        //model.AccountVoucherSettingMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        model.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                //return Json(model.AccountVoucherSettingMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            AccountVoucherSettingMasterViewModel model = new AccountVoucherSettingMasterViewModel();
            try
            {
                model.AccountVoucherSettingMasterDTO = new AccountVoucherSettingMaster();
                //model.AccountVoucherSettingMasterDTO.AccountVoucherSettingMasterID = id;
                model.AccountVoucherSettingMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<AccountVoucherSettingMaster> response = _AccountVoucherSettingMasterServiceAcess.SelectByID(model.AccountVoucherSettingMasterDTO);
                if (response != null && response.Entity != null)
                {
                    //model.AccountVoucherSettingMasterDTO.TemperatureFrom = response.Entity.TemperatureFrom;
                    //model.AccountVoucherSettingMasterDTO.TemperatureUpto = response.Entity.TemperatureUpto;
                    //model.AccountVoucherSettingMasterDTO.TemperatureType = response.Entity.TemperatureType;
                    model.AccountVoucherSettingMasterDTO.CreatedBy = response.Entity.CreatedBy;

                }

                return PartialView("/Views/AccountVoucherSettingMaster/Edit.cshtml", model);
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
                IBaseEntityResponse<AccountVoucherSettingMaster> response = null;
                AccountVoucherSettingMaster AccountVoucherSettingMasterDTO = new AccountVoucherSettingMaster();
                AccountVoucherSettingMasterDTO.ConnectionString = _connectioString;
                AccountVoucherSettingMasterDTO.ID = Convert.ToInt16(ID);
                AccountVoucherSettingMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _AccountVoucherSettingMasterServiceAcess.DeleteAccountVoucherSettingMaster(AccountVoucherSettingMasterDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion
        protected List<AccountTransactionTypeMaster> GetListAccountVoucherSettingMaster(string selectedBalsheet, string AccSessionID)
        {
            AccountTransactionTypeMasterSearchRequest searchRequest = new AccountTransactionTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalsheetMstID = Convert.ToInt32(selectedBalsheet);
            searchRequest.AccSessionID = Convert.ToInt32(AccSessionID);
            List<AccountTransactionTypeMaster> listAccountTransactionTypeMaster = new List<AccountTransactionTypeMaster>();
            IBaseEntityCollectionResponse<AccountTransactionTypeMaster> baseEntityCollectionResponse = _AccountTransactionTypeMasterServiceAcess.GetTransactionTypeList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountTransactionTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccountTransactionTypeMaster;
        }
        // Non-Action Method
        #region Methods
        public IEnumerable<AccountVoucherSettingMaster> GetAccountVoucherSettingMaster(out int TotalRecords, string AccBalsheetMstID, string AccSessionID)
        {
            List<AccountVoucherSettingMaster> listAccountVoucherSettingMaster = new List<AccountVoucherSettingMaster>();
            AccountVoucherSettingMasterSearchRequest searchRequest = new AccountVoucherSettingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AccBalsheetMstID = Convert.ToInt32(AccBalsheetMstID);
            searchRequest.AccSessionID = Convert.ToInt32(AccSessionID);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
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
            //List<AccountVoucherSettingMasterViewModel> listAccountVoucherSettingMasterViewModel = new List<AccountVoucherSettingMasterViewModel>();
            //List<AccountVoucherSettingMaster> listAccountVoucherSettingMaster = new List<AccountVoucherSettingMaster>();
            //IBaseEntityCollectionResponse<AccountVoucherSettingMaster> baseEntityCollectionResponse = _AccountVoucherSettingMasterServiceAcess.GetBySearch(searchRequest);
            //if (baseEntityCollectionResponse != null)
            //{
            //    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
            //    {
            //        listAccountVoucherSettingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
            //        foreach (AccountVoucherSettingMaster item in listAccountVoucherSettingMaster)
            //        {
            //            AccountVoucherSettingMasterViewModel AccountVoucherSettingMasterViewModel = new AccountVoucherSettingMasterViewModel();
            //            AccountVoucherSettingMasterViewModel.AccountVoucherSettingMasterDTO = item;
            //            listAccountVoucherSettingMasterViewModel.Add(AccountVoucherSettingMasterViewModel);
            //        }
            //    }
            //}
            //TotalRecords = baseEntityCollectionResponse.TotalRecords;
            //return listAccountVoucherSettingMasterViewModel;

            //////
            IBaseEntityCollectionResponse<AccountVoucherSettingMaster> baseEntityCollectionResponse = _AccountVoucherSettingMasterServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccountVoucherSettingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listAccountVoucherSettingMaster;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string AccBalsheetMstID, string AccSessionID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<AccountVoucherSettingMaster> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.TransactionType";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.TransactionType Like '%" + param.sSearch + "%'";
                           
                        }
                        else
                        {
                           // _searchBy = "A.TransactionType Like '%" + param.sSearch + "%'";
                            _searchBy = "A.TransactionType Like '%" + param.sSearch + "%' or A.TransactionTypeCode Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "A.TransactionTypeCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = "A.TransactionTypeCode Like '%" + param.sSearch + "%'";
                           
                           
                        }
                        else
                        {
                            //_searchBy = "A.TransactionTypeCode Like '%" + param.sSearch + "%'";
                            _searchBy = "A.TransactionType Like '%" + param.sSearch + "%' or A.TransactionTypeCode Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.VoucherNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.VoucherNumber Like '%" + param.sSearch + "%'";
                         
                        }
                        else
                        {
                            //_searchBy = "A.VoucherNumber Like '%" + param.sSearch + "%'";
                            _searchBy = "A.TransactionType Like '%" + param.sSearch + "%' or A.TransactionTypeCode Like '%" + param.sSearch + "%' or A.VoucherNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

               // filteredGroupDescription = GetAccountVoucherSettingMaster(out TotalRecords, AccBalsheetMstID, AccSessionID);
                if ((!string.IsNullOrEmpty(AccBalsheetMstID)) && !string.IsNullOrEmpty(AccSessionID))
                {
                    filteredGroupDescription = GetAccountVoucherSettingMaster(out TotalRecords, AccBalsheetMstID, AccSessionID);
                }
                else
                {
                    filteredGroupDescription = new List<AccountVoucherSettingMaster>();
                    TotalRecords = 0;
                }



                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.AccSessionID), Convert.ToString(c.AccBalsheetMstID), Convert.ToString(c.TransactionType), Convert.ToString(c.TransactionTypeCode), Convert.ToString(c.VoucherNumber), Convert.ToString(c.ID) };

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