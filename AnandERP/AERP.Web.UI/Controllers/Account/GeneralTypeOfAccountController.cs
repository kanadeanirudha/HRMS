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
    public class GeneralTypeOfAccountController : BaseController
    {
        IGeneralTypeOfAccountBA _GeneralTypeOfAccountBA = null;
     
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public GeneralTypeOfAccountController()
        {
            _GeneralTypeOfAccountBA = new GeneralTypeOfAccountBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Accounts/GeneralTypeOfAccount/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralTypeOfAccountViewModel model = new GeneralTypeOfAccountViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/GeneralTypeOfAccount/List.cshtml", model);
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
            GeneralTypeOfAccountViewModel model = new GeneralTypeOfAccountViewModel();
         
            //************************** Dynamic Drop Down For Name********************************
            string  dispalyFor = "Create";
            List<GeneralTypeOfAccount> GeneralTypeOfAccount = GetListGeneralTypeOfAccount(dispalyFor);
            List<SelectListItem> GeneralTypeOfAccountList = new List<SelectListItem>();

            foreach (GeneralTypeOfAccount item in GeneralTypeOfAccount)
            {
                GeneralTypeOfAccountList.Add(new SelectListItem { Text = item.AccountName, Value = Convert.ToString((item.AccountMasterId) + "-" + (item.AccountCode)) });
            }
            ViewBag.GeneralTypeOfAccountList = new SelectList(GeneralTypeOfAccountList, "Value", "Text");
                    

            return PartialView("/Views/Accounts/GeneralTypeOfAccount/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralTypeOfAccountViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralTypeOfAccountDTO != null)
                {
                    model.GeneralTypeOfAccountDTO.ConnectionString = _connectioString;
                    model.GeneralTypeOfAccountDTO.Name = model.Name;
                    //General Type Of Account Map With Account
                    model.GeneralTypeOfAccountDTO.GeneralTypeOfAccountMapWithAccountID = model.GeneralTypeOfAccountMapWithAccountID;
                    model.GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = model.GeneralTypeOfAccountId;
                   
                    model.GeneralTypeOfAccountDTO.AccountName = model.AccountName;
                    string accnm = model.GeneralTypeOfAccountDTO.AccountName;
                    string[] accnmArray = accnm.Split('-');
                    model.GeneralTypeOfAccountDTO.AccountMasterId = Convert.ToInt16(accnmArray[0]);
                    model.GeneralTypeOfAccountDTO.AccountCode = Convert.ToString(accnmArray[1]);

                    model.GeneralTypeOfAccountDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTypeOfAccount> response = _GeneralTypeOfAccountBA.InsertGeneralTypeOfAccount(model.GeneralTypeOfAccountDTO);

                    model.GeneralTypeOfAccountDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralTypeOfAccountDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int16 ID)
        {
            GeneralTypeOfAccountViewModel model = new GeneralTypeOfAccountViewModel();

           
            try
            {

                model.GeneralTypeOfAccountDTO = new GeneralTypeOfAccount();
                model.GeneralTypeOfAccountDTO.ConnectionString = _connectioString;
                model.GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = ID;

                IBaseEntityResponse<GeneralTypeOfAccount> response = _GeneralTypeOfAccountBA.SelectByID(model.GeneralTypeOfAccountDTO);
                if (response != null && response.Entity != null)
                {
                    model.GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = response.Entity.GeneralTypeOfAccountId;

                    model.GeneralTypeOfAccountDTO.Name = response.Entity.Name;
                    model.GeneralTypeOfAccountDTO.AccountName = response.Entity.AccountMasterId + "-" + response.Entity.AccountCode;
                    model.GeneralTypeOfAccountDTO.AccountMasterId = response.Entity.AccountMasterId;
                    model.GeneralTypeOfAccountDTO.AccountCode = response.Entity.AccountCode;

                }

                string displayFor = "Edit";
                List<GeneralTypeOfAccount> GeneralTypeOfAccount = GetListGeneralTypeOfAccount(displayFor);
                List<SelectListItem> GeneralTypeOfAccountList = new List<SelectListItem>();

                foreach (GeneralTypeOfAccount item in GeneralTypeOfAccount)
                {
                    GeneralTypeOfAccountList.Add(new SelectListItem { Text = item.AccountName, Value = Convert.ToString((item.AccountMasterId) + "-" + (item.AccountCode)) });
                }
                ViewBag.GeneralTypeOfAccountList = new SelectList(GeneralTypeOfAccountList, "Value", "Text", ((model.GeneralTypeOfAccountDTO.AccountMasterId) + "-" + (model.GeneralTypeOfAccountDTO.AccountCode)));
                return PartialView("/Views/Accounts/GeneralTypeOfAccount/Edit.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(GeneralTypeOfAccountViewModel model)
        {
            try
            {
                if (model != null && model.GeneralTypeOfAccountDTO != null)
                {
                    model.GeneralTypeOfAccountDTO.ConnectionString = _connectioString;
                    model.GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = model.GeneralTypeOfAccountId;

                    model.GeneralTypeOfAccountDTO.Name = model.Name;
                    //model.GeneralTypeOfAccountDTO.IsActive = model.IsActive;


                    model.GeneralTypeOfAccountDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralTypeOfAccount> response = _GeneralTypeOfAccountBA.UpdateGeneralTypeOfAccount(model.GeneralTypeOfAccountDTO);
                    model.GeneralTypeOfAccountDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.GeneralTypeOfAccountDTO.errorMessage, JsonRequestBehavior.AllowGet);
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


        //[HttpGet]
        //public ActionResult ViewDetails(string ID)
        //{
        //    try
        //    {
        //        GeneralTypeOfAccountViewModel model = new GeneralTypeOfAccountViewModel();
        //        model.GeneralTypeOfAccountDTO = new GeneralTypeOfAccount();
        //        model.GeneralTypeOfAccountDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralTypeOfAccountDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralTypeOfAccount> response = _GeneralTypeOfAccountBA.SelectByID(model.GeneralTypeOfAccountDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralTypeOfAccountDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralTypeOfAccountDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralTypeOfAccountDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralTypeOfAccountDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralTypeOfAccount/ViewDetails.cshtml", model);
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
                IBaseEntityResponse<GeneralTypeOfAccount> response = null;
                GeneralTypeOfAccount GeneralTypeOfAccountDTO = new GeneralTypeOfAccount();
                GeneralTypeOfAccountDTO.ConnectionString = _connectioString;
                GeneralTypeOfAccountDTO.GeneralTypeOfAccountId = Convert.ToInt16(ID);
                GeneralTypeOfAccountDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralTypeOfAccountBA.DeleteGeneralTypeOfAccount(GeneralTypeOfAccountDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        #endregion

        // Non-Action Method
        //Dropdown For Name 
        protected List<GeneralTypeOfAccount> GetListGeneralTypeOfAccount(string displayFor)
        {
            GeneralTypeOfAccountSearchRequest searchRequest = new GeneralTypeOfAccountSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.DisplayFor = displayFor;
            List<GeneralTypeOfAccount> listGeneralTypeOfAccount = new List<GeneralTypeOfAccount>();
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> baseEntityCollectionResponse = _GeneralTypeOfAccountBA.GetListName(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTypeOfAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralTypeOfAccount;
        }
        #region Methods
        public IEnumerable<GeneralTypeOfAccountViewModel> GetGeneralTypeOfAccount(out int TotalRecords)
        {
            GeneralTypeOfAccountSearchRequest searchRequest = new GeneralTypeOfAccountSearchRequest();
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
            List<GeneralTypeOfAccountViewModel> listGeneralTypeOfAccountViewModel = new List<GeneralTypeOfAccountViewModel>();
            List<GeneralTypeOfAccount> listGeneralTypeOfAccount = new List<GeneralTypeOfAccount>();
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> baseEntityCollectionResponse = _GeneralTypeOfAccountBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTypeOfAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralTypeOfAccount item in listGeneralTypeOfAccount)
                    {
                        GeneralTypeOfAccountViewModel GeneralTypeOfAccountViewModel = new GeneralTypeOfAccountViewModel();
                        GeneralTypeOfAccountViewModel.GeneralTypeOfAccountDTO = item;
                        listGeneralTypeOfAccountViewModel.Add(GeneralTypeOfAccountViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralTypeOfAccountViewModel;
        }
        #endregion

        // AjaxHandler Method
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<GeneralTypeOfAccountViewModel> filteredGeneralTypeOfAccount;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.Name";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.Name like '%'";
                            
                        }
                        else
                        {
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                           
                        }
                        break;
                    case 1:
                        _sortBy = "C.AccountName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                           
                            _searchBy = string.Empty;
                        }
                        else
                        {
                          
                            _searchBy = "A.Name Like '%" + param.sSearch + "%' or C.AccountName Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGeneralTypeOfAccount = GetGeneralTypeOfAccount(out TotalRecords);

                var records = filteredGeneralTypeOfAccount.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.Name), Convert.ToString(c.AccountName), Convert.ToString(c.IsActive), Convert.ToString(c.ID), Convert.ToString(c.GeneralTypeOfAccountId), Convert.ToString(c.AccountMasterId) + "-" + Convert.ToString(c.AccountCode) };

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