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
    public class GeneralMapTypeOfAccountController : BaseController
    {
        IGeneralMapTypeOfAccountBA _GeneralMapTypeOfAccountServiceAcess = null;
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

        public GeneralMapTypeOfAccountController()
        {
            _GeneralMapTypeOfAccountServiceAcess = new GeneralMapTypeOfAccountBA();
            _GeneralTypeOfAccountBA = new GeneralTypeOfAccountBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {

            return View("/Views/Accounts/GeneralMapTypeOfAccount/Index.cshtml");

        }

        public ActionResult List(string actionMode)
        {
            try
            {
                GeneralMapTypeOfAccountViewModel model = new GeneralMapTypeOfAccountViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Accounts/GeneralMapTypeOfAccount/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string ModuleName)
        {
            GeneralMapTypeOfAccountViewModel model = new GeneralMapTypeOfAccountViewModel();

            List<UserModuleMaster> UserModuleMaster = GetModuleListForAdmin();
            List<SelectListItem> UserModuleMasterList = new List<SelectListItem>();
            foreach (UserModuleMaster item in UserModuleMaster)
            {
                UserModuleMasterList.Add(new SelectListItem { Text = item.ModuleName, Value = Convert.ToString(item.ModuleCode) });
            }
            ViewBag.UserModuleMasterList = new SelectList(UserModuleMasterList, "Value", "Text");

            //model.ListUserMenuMaster = GetUserMainMenuMasterList(ModuleName);

            List<GeneralMapTypeOfAccount> UserMenuMaster = GetUserMainMenuMasterList(ModuleName);
            List<SelectListItem> UserMenuMasterList = new List<SelectListItem>();
            foreach (GeneralMapTypeOfAccount item in UserMenuMaster)
            {
                UserMenuMasterList.Add(new SelectListItem { Text = item.MenuName, Value = Convert.ToString(item.MenuCode) });
            }
            ViewBag.UserMenuMasterList = new SelectList(UserMenuMasterList, "Value", "Text");

            
            model.GeneralMapTypeOfAccountListForAccountType = GetAccountType();
        
            return PartialView("/Views/Accounts/GeneralMapTypeOfAccount/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(GeneralMapTypeOfAccountViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.GeneralMapTypeOfAccountDTO != null)
                {
                    model.GeneralMapTypeOfAccountDTO.ConnectionString = _connectioString;
                    model.GeneralMapTypeOfAccountDTO.XMLstring = model.XMLstring;
                    model.GeneralMapTypeOfAccountDTO.MenuName = model.MenuName;
                    model.GeneralMapTypeOfAccountDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<GeneralMapTypeOfAccount> response = _GeneralMapTypeOfAccountServiceAcess.InsertGeneralMapTypeOfAccount(model.GeneralMapTypeOfAccountDTO);

                    model.GeneralMapTypeOfAccountDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.GeneralMapTypeOfAccountDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(GeneralMapTypeOfAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.GeneralMapTypeOfAccountDTO != null)
                {
                    if (model != null && model.GeneralMapTypeOfAccountDTO != null)
                    {
                        model.GeneralMapTypeOfAccountDTO.ConnectionString = _connectioString;
                        //model.GeneralMapTypeOfAccountDTO.GeneralMapTypeOfAccountID = model.GeneralMapTypeOfAccountID;
                        //model.GeneralMapTypeOfAccountDTO.TemperatureType = model.TemperatureType;
                        //model.GeneralMapTypeOfAccountDTO.TemperatureFrom = model.TemperatureFrom;
                        //model.GeneralMapTypeOfAccountDTO.TemperatureUpto = model.TemperatureUpto;
                        //model.GeneralMapTypeOfAccountDTO.DefaultFlag = model.DefaultFlag;
                        model.GeneralMapTypeOfAccountDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<GeneralMapTypeOfAccount> response = _GeneralMapTypeOfAccountServiceAcess.UpdateGeneralMapTypeOfAccount(model.GeneralMapTypeOfAccountDTO);
                        model.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        return Json(model.errorMessage, JsonRequestBehavior.AllowGet);
                    }
                }
                //return Json(model.GeneralMapTypeOfAccountDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            GeneralMapTypeOfAccountViewModel model = new GeneralMapTypeOfAccountViewModel();
            try
            {
                model.GeneralMapTypeOfAccountDTO = new GeneralMapTypeOfAccount();
               // model.GeneralMapTypeOfAccountDTO.GeneralMapTypeOfAccountID = id;
                model.GeneralMapTypeOfAccountDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<GeneralMapTypeOfAccount> response = _GeneralMapTypeOfAccountServiceAcess.SelectByID(model.GeneralMapTypeOfAccountDTO);
                if (response != null && response.Entity != null)
                {
                    //model.GeneralMapTypeOfAccountDTO.TemperatureFrom = response.Entity.TemperatureFrom;
                    //model.GeneralMapTypeOfAccountDTO.TemperatureUpto = response.Entity.TemperatureUpto;
                    //model.GeneralMapTypeOfAccountDTO.TemperatureType = response.Entity.TemperatureType;
                    model.GeneralMapTypeOfAccountDTO.CreatedBy = response.Entity.CreatedBy;

                }

                return PartialView("/Views/Accounts/GeneralMapTypeOfAccount/Edit.cshtml", model);
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
        //        GeneralMapTypeOfAccountViewModel model = new GeneralMapTypeOfAccountViewModel();
        //        model.GeneralMapTypeOfAccountDTO = new GeneralMapTypeOfAccount();
        //        model.GeneralMapTypeOfAccountDTO.ID = Convert.ToInt16(ID);
        //        model.GeneralMapTypeOfAccountDTO.ConnectionString = _connectioString;

        //        IBaseEntityResponse<GeneralMapTypeOfAccount> response = _GeneralMapTypeOfAccountServiceAcess.SelectByID(model.GeneralMapTypeOfAccountDTO);
        //        if (response != null && response.Entity != null)
        //        {
        //            model.GeneralMapTypeOfAccountDTO.GroupDescription = response.Entity.GroupDescription;
        //            model.GeneralMapTypeOfAccountDTO.MarchandiseGroupCode = response.Entity.MarchandiseGroupCode;
        //        }

        //        List<SelectListItem> GroupCode = new List<SelectListItem>();
        //        ViewBag.GroupCode = new SelectList(GroupCode, "Value", "Text");
        //        List<SelectListItem> GroupCode_li = new List<SelectListItem>();
        //        GroupCode_li.Add(new SelectListItem { Text = "Manufacturing", Value = "1" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Sales", Value = "2" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Purchase", Value = "3" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Warehouse", Value = "4" });
        //        GroupCode_li.Add(new SelectListItem { Text = "Processing", Value = "5" });
        //        ViewData["GroupCode"] = new SelectList(GroupCode_li, "Value", "Text", model.GeneralMapTypeOfAccountDTO.GroupCode);


        //        //    foreach (GeneralServiceMaster item in GeneralServiceMaster)
        //        //    {
        //        //        GeneralServiceMasterList.Add(new SelectListItem { Text = item.ServiceName, Value = Convert.ToString(item.ID) });
        //        //    }
        //        //    ViewBag.GeneralServiceMasterList = new SelectList(GeneralServiceMasterList, "Value", "Text", model.GeneralMapTypeOfAccountDTO.GenServiceRequiredID);

        //        return PartialView("/Views/GeneralMapTypeOfAccount/ViewDetails.cshtml", model);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }

        //}

        public ActionResult Delete(string MenuCode)
        {

            GeneralMapTypeOfAccountViewModel model = new GeneralMapTypeOfAccountViewModel(); 
            var errorMessage = string.Empty;
            
                IBaseEntityResponse<GeneralMapTypeOfAccount> response = null;
                GeneralMapTypeOfAccount GeneralMapTypeOfAccountDTO = new GeneralMapTypeOfAccount();
                GeneralMapTypeOfAccountDTO.ConnectionString = _connectioString;
                GeneralMapTypeOfAccountDTO.MenuCode = Convert.ToString(MenuCode);
                GeneralMapTypeOfAccountDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _GeneralMapTypeOfAccountServiceAcess.DeleteGeneralMapTypeOfAccount(GeneralMapTypeOfAccountDTO);
                errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMenuByModuleName(string ModuleName)
        {

            var Menu = GetUserMainMenuMasterList(ModuleName);
            var result = (from s in Menu
                          select new
                          {
                              id = s.MenuCode,
                              name = s.MenuName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<GeneralMapTypeOfAccount> GetUserMainMenuMasterList(string ModuleName)
        {
            GeneralMapTypeOfAccountSearchRequest searchRequest = new GeneralMapTypeOfAccountSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralMapTypeOfAccount> listUserMainMenuMaster = new List<GeneralMapTypeOfAccount>();
            searchRequest.ModuleCode = ModuleName;
            IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> baseEntityCollectionResponse = _GeneralMapTypeOfAccountServiceAcess.GetByModuleCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMainMenuMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listUserMainMenuMaster;
        }

        protected List<GeneralTypeOfAccount> GetAccountType()
        {
            GeneralTypeOfAccountSearchRequest searchRequest = new GeneralTypeOfAccountSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralTypeOfAccount> ListGeneralTypeOfAccount = new List<GeneralTypeOfAccount>();
            IBaseEntityCollectionResponse<GeneralTypeOfAccount> baseEntityCollectionResponse = _GeneralTypeOfAccountBA.GetListAccountType(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralTypeOfAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralTypeOfAccount;
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<GeneralMapTypeOfAccountViewModel> GetGeneralMapTypeOfAccount(out int TotalRecords)
        {
            GeneralMapTypeOfAccountSearchRequest searchRequest = new GeneralMapTypeOfAccountSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate,A.MenuCode";
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
            List<GeneralMapTypeOfAccountViewModel> listGeneralMapTypeOfAccountViewModel = new List<GeneralMapTypeOfAccountViewModel>();
            List<GeneralMapTypeOfAccount> listGeneralMapTypeOfAccount = new List<GeneralMapTypeOfAccount>();
            IBaseEntityCollectionResponse<GeneralMapTypeOfAccount> baseEntityCollectionResponse = _GeneralMapTypeOfAccountServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralMapTypeOfAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (GeneralMapTypeOfAccount item in listGeneralMapTypeOfAccount)
                    {
                        GeneralMapTypeOfAccountViewModel GeneralMapTypeOfAccountViewModel = new GeneralMapTypeOfAccountViewModel();
                        GeneralMapTypeOfAccountViewModel.GeneralMapTypeOfAccountDTO = item;
                        listGeneralMapTypeOfAccountViewModel.Add(GeneralMapTypeOfAccountViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listGeneralMapTypeOfAccountViewModel;
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

                IEnumerable<GeneralMapTypeOfAccountViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CreatedDate,C.MenuName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.GroupDescription like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            // _searchBy = "A.GroupDescription Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Name Like '%" + param.sSearch + "%' or A.ControlName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "C.MenuName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Name Like '%" + param.sSearch + "%' or A.ControlName Like '%" + param.sSearch + "%'";
                           // _searchBy = "A.MenuCode Like '%" + param.sSearch + "%' or B.Name Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "A.ControlName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Name Like '%" + param.sSearch + "%' or A.ControlName Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "A.ControlName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            // _searchBy = "A.MarchandiseGroupCode like '%'";
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //  _searchBy = "A.MarchandiseGroupCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                            _searchBy = "B.Name Like '%" + param.sSearch + "%' or A.ControlName Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetGeneralMapTypeOfAccount(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.UserMainMenuMasterID), Convert.ToString(c.MenuName), Convert.ToString(c.MenuCode), Convert.ToString(c.AccName), Convert.ToString(c.DebitCreditStatus), Convert.ToString(c.ControlName) };

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