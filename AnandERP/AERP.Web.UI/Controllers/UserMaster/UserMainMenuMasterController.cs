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
    public class UserMainMenuMasterController : BaseController
    {
        IUserMainMenuMasterBA _userMainMenuMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public UserMainMenuMasterController()
        {
            _userMainMenuMasterBA = new UserMainMenuMasterBA();

        }

        #region Controller Methods

        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0)
            {
                return View();
            }
            else
            {
                int AdminRoleMasterID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                if (listAdminRoleApplicableDetails.Count > 0)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }    
        }

         public ActionResult List(string actionMode)
        {
            try
            {
             UserMainMenuMasterViewModel model = new UserMainMenuMasterViewModel();
            if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                //_sortBy = "ModuleID";
                return PartialView("List", model);
            }
            
            //System.Threading.Thread.Sleep(1000);                
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Create(string ModuleCode)
        {
            UserMainMenuMasterViewModel model = new UserMainMenuMasterViewModel();
            try
            {
                List<UserMainMenuMaster> ParentMenuList = GetParentMenuList(ModuleCode);
                List<SelectListItem> userParentMenu = new List<SelectListItem>();
                foreach (UserMainMenuMaster item in ParentMenuList)
                {
                    if (item.ParentMenuName != null && item.ModuleCode!=null)
                    {
                        userParentMenu.Add(new SelectListItem { Text = item.ParentMenuName, Value = item.ModuleID.ToString() });
                        model.UserMainMenuMasterDTO.ModuleCode = ParentMenuList[0].ModuleCode;
                        model.UserMainMenuMasterDTO.ModuleID = ParentMenuList[0].ModuleID;
                        model.UserMainMenuMasterDTO.ParentMenuID = ParentMenuList[0].ParentMenuID;
                    }
                }
                ViewBag.UserParentMenuList = new SelectList(userParentMenu, "Value", "Text");
                model.UserMainMenuMasterDTO.ModuleCode = ModuleCode;
                
            }
            catch (Exception)
            {

                throw;
            }

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(UserMainMenuMasterViewModel model)
        {
          try
            { 
            if (ModelState.IsValid)
            {
                if (model != null && model.UserMainMenuMasterDTO != null)
                {
                    model.UserMainMenuMasterDTO.ConnectionString = _connectioString;
                    model.UserMainMenuMasterDTO.ModuleID = model.ModuleID;
                    model.UserMainMenuMasterDTO.ModuleCode = model.ModuleCode;
                    model.UserMainMenuMasterDTO.MenuName = model.MenuName;
                    model.UserMainMenuMasterDTO.MenuCode = model.MenuCode;
                    model.UserMainMenuMasterDTO.MenuInnerLevel = model.MenuInnerLevel;
                    model.UserMainMenuMasterDTO.MenuDisplaySeqNo = model.MenuDisplaySeqNo;
                    if (model.IsParent == false)   //NO
                    {
                        model.UserMainMenuMasterDTO.ParentMenuID = model.ParentMenuID;   
                    
                    }
                    else if (model.IsParent == true)    //YES
                    {
                        model.UserMainMenuMasterDTO.ParentMenuID = 0;
                        model.UserMainMenuMasterDTO.ParentMenuName = model.MenuName.ToUpper();
                        model.UserMainMenuMasterDTO.ParentMenuName = model.MenuCode.ToUpper();                  
                    }
                        model.UserMainMenuMasterDTO.MenuLink = model.MenuLink;                   
                        model.UserMainMenuMasterDTO.DisableDate = model.DisableDate;
                        model.UserMainMenuMasterDTO.RemarkAboutDisable = model.RemarkAboutDisable;
                        model.UserMainMenuMasterDTO.MenuToolTip = model.MenuToolTip;
                        model.UserMainMenuMasterDTO.MenuIconName = model.MenuIconName;
                        model.UserMainMenuMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]); //model.CreatedBy;
                    IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.InsertUserMainMenuMaster(model.UserMainMenuMasterDTO);
                    model.UserMainMenuMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                return Json(model.UserMainMenuMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Edit(int id)
        {
            UserMainMenuMasterViewModel model = new UserMainMenuMasterViewModel();
            try
            {
                model.UserMainMenuMasterDTO = new UserMainMenuMaster();
                model.UserMainMenuMasterDTO.ID = id;
                model.UserMainMenuMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.SelectByID(model.UserMainMenuMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.UserMainMenuMasterDTO.ID = response.Entity.ID;
                    model.UserMainMenuMasterDTO.ModuleID = response.Entity.ModuleID;
                    model.UserMainMenuMasterDTO.ModuleCode = response.Entity.ModuleCode;
                    model.UserMainMenuMasterDTO.MenuName = response.Entity.MenuName;
                    model.UserMainMenuMasterDTO.MenuCode = response.Entity.MenuCode;
                    model.UserMainMenuMasterDTO.MenuInnerLevel = response.Entity.MenuInnerLevel;
                    model.UserMainMenuMasterDTO.ParentMenuName = response.Entity.ParentMenuName;
                    if (response.Entity.ParentMenuName != null)
                    {
                        model.UserMainMenuMasterDTO.IsParent = true;
                    }
                    else
                    {
                        model.UserMainMenuMasterDTO.IsParent = false;
                    }
                    model.UserMainMenuMasterDTO.ParentMenuID = response.Entity.ParentMenuID;
                    model.UserMainMenuMasterDTO.MenuLink = response.Entity.MenuLink;
                    model.UserMainMenuMasterDTO.MenuToolTip = response.Entity.MenuToolTip;
                    model.UserMainMenuMasterDTO.DisableDate = response.Entity.DisableDate;
                    model.UserMainMenuMasterDTO.RemarkAboutDisable = response.Entity.RemarkAboutDisable;
                    model.UserMainMenuMasterDTO.MenuIconName = response.Entity.MenuIconName;
                    model.UserMainMenuMasterDTO.IsEnable = response.Entity.IsEnable;
                  List<UserMainMenuMaster> ParentMenuList = GetParentMenuList(response.Entity.ModuleCode);
                    List<SelectListItem> userParentMenu = new List<SelectListItem>();
                    foreach (UserMainMenuMaster item in ParentMenuList)
                    {
                        if (item.ParentMenuName != null && item.ModuleCode != null)
                        {
                            userParentMenu.Add(new SelectListItem { Text = item.ParentMenuName, Value = item.ModuleID.ToString() });
                            model.UserMainMenuMasterDTO.ModuleCode = ParentMenuList[0].ModuleCode;
                        }
                    }
                    ViewBag.UserParentMenuList = new SelectList(userParentMenu, "Value", "Text");

                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserMainMenuMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.UserMainMenuMasterDTO != null)
                {
                    model.UserMainMenuMasterDTO.ConnectionString = _connectioString;
                    model.UserMainMenuMasterDTO.ModuleID = model.ModuleID;
                    model.UserMainMenuMasterDTO.ModuleCode = model.ModuleCode;
                    model.UserMainMenuMasterDTO.MenuName = model.MenuName;
                    model.UserMainMenuMasterDTO.MenuCode = model.MenuCode;
                    model.UserMainMenuMasterDTO.MenuInnerLevel = model.MenuInnerLevel;

                    if (model.IsParent == false)   //NO
                    {
                        model.UserMainMenuMasterDTO.ParentMenuID = model.ParentMenuID;
                    }
                    else if (model.IsParent == true)    //YES
                    {
                        model.UserMainMenuMasterDTO.ParentMenuID = 0;
                        model.UserMainMenuMasterDTO.ParentMenuName = model.MenuName.ToUpper();
                        model.UserMainMenuMasterDTO.ParentMenuCode = model.MenuCode.ToUpper();
                    }
                    model.UserMainMenuMasterDTO.MenuLink = model.MenuLink;                   
                    model.UserMainMenuMasterDTO.DisableDate = model.DisableDate;
                    model.UserMainMenuMasterDTO.RemarkAboutDisable = model.RemarkAboutDisable;                   
                    model.UserMainMenuMasterDTO.IsEnable = model.IsEnable;
                    model.UserMainMenuMasterDTO.MenuToolTip = model.MenuToolTip;
                    model.UserMainMenuMasterDTO.MenuIconName = model.MenuIconName;
                    model.UserMainMenuMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]); //model.CreatedBy;
                    IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.UpdateUserMainMenuMaster(model.UserMainMenuMasterDTO);
                    model.UserMainMenuMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                return Json(model.UserMainMenuMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        //public ActionResult Delete(int ID)
        //{
        //    UserMainMenuMasterViewModel model = new UserMainMenuMasterViewModel();

        //    model.UserMainMenuMasterDTO = new UserMainMenuMaster();
        //    model.UserMainMenuMasterDTO.ID = ID;
        //    model.UserMainMenuMasterDTO.ConnectionString = _connectioString;

        //    IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.SelectByID(model.UserMainMenuMasterDTO);

        //    if (response != null && response.Entity != null)
        //    {
        //        model.UserMainMenuMasterDTO.ID = response.Entity.ID;
        //    }

        //    return PartialView(model);
        //}

        //[HttpPost]
        //public ActionResult Delete(UserMainMenuMasterViewModel model)
        //{
        //  try
        //    { 
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            UserMainMenuMaster UserMainMenuMasterDTO = new UserMainMenuMaster();
        //            UserMainMenuMasterDTO.ConnectionString = _connectioString;
        //            UserMainMenuMasterDTO.ID = model.ID;
        //            UserMainMenuMasterDTO.DeletedBy = Convert.ToInt32(Session["UserId"]);
        //            IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.DeleteUserMainMenuMaster(UserMainMenuMasterDTO);
        //            model.UserMainMenuMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        }
        //        // return Content(Boolean.TrueString);
        //        return Json(model.UserMainMenuMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }

        //    }
        //  catch (Exception ex)
        //  {
        //      _logException.Error(ex.Message);
        //      throw;
        //  }

        //}


        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            UserMainMenuMasterViewModel model = new UserMainMenuMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                    if (ID > 0)
                    {
                        UserMainMenuMaster UserMainMenuMasterDTO = new UserMainMenuMaster();
                        UserMainMenuMasterDTO.ConnectionString = _connectioString;
                        UserMainMenuMasterDTO.ID = ID;
                        UserMainMenuMasterDTO.DeletedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<UserMainMenuMaster> response = _userMainMenuMasterBA.DeleteUserMainMenuMaster(UserMainMenuMasterDTO);
                        model.UserMainMenuMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    // return Content(Boolean.TrueString);
                    return Json(model.UserMainMenuMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                //}
                //else
                //{
                //    return Json("Please review your form");
                //}

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        #endregion

        #region Methods

        public IEnumerable<UserMainMenuMasterViewModel> GetUserMainMenuMaster(out int TotalRecords)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<UserMainMenuMasterViewModel> listUserMainMenuMasterViewModel = new List<UserMainMenuMasterViewModel>();
            List<UserMainMenuMaster> listUserMainMenuMaster = new List<UserMainMenuMaster>();
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserMainMenuMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (UserMainMenuMaster item in listUserMainMenuMaster)
                    {
                        UserMainMenuMasterViewModel UserMainMenuMasterViewModel = new UserMainMenuMasterViewModel();
                        UserMainMenuMasterViewModel.UserMainMenuMasterDTO = item;
                        listUserMainMenuMasterViewModel.Add(UserMainMenuMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listUserMainMenuMasterViewModel;
        }

        protected List<UserMainMenuMaster> GetParentMenuList(string ModuleCode)
        {
            UserMainMenuMasterSearchRequest searchRequest = new UserMainMenuMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
          
            //searchRequest.ModuleID = Convert.ToInt32(ModuleID);
            searchRequest.ModuleCode = ModuleCode;
            //searchRequest.SearchType = 1;
            List<UserMainMenuMaster> parentMenuList = new List<UserMainMenuMaster>();
            IBaseEntityCollectionResponse<UserMainMenuMaster> baseEntityCollectionResponse = _userMainMenuMasterBA.GetParentMenuByModuleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    parentMenuList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return parentMenuList;
        }


        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc        
            IEnumerable<UserMainMenuMasterViewModel> filteredUserMainMenuMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "B.MenuName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.MenuName Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or B.MenuDisplaySeqNo Like '%" + param.sSearch + "%' or A.ModuleName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "A.ModuleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.MenuName Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or B.MenuDisplaySeqNo Like '%" + param.sSearch + "%' or A.ModuleName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "A.ModuleID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.MenuName Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or B.MenuDisplaySeqNo Like '%" + param.sSearch + "%'or A.ModuleName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "A.ModuleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.MenuName Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or B.MenuDisplaySeqNo Like '%" + param.sSearch + "%'or A.ModuleName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 4:
                    _sortBy = "B.MenuDisplaySeqNo";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "B.MenuName Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or A.ModuleCode Like '%" + param.sSearch + "%' or B.MenuDisplaySeqNo Like '%" + param.sSearch + "%'or A.ModuleName Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            ////_startRow = 0;
            ////_rowLength = 10;
            ////_sortBy = "CountryName";
            ////Check whether the companies should be filtered by keyword
            //if (!string.IsNullOrEmpty(param.sSearch))
            //{
            //    //Used if particulare columns are filtered             
            //    var ModuleNameFilter = Convert.ToString(Request["sSearch_0"]);
            //    var ModuleCodeFilter = Convert.ToString(Request["sSearch_1"]);
            //    var ModuleSeqNumberFilter = Convert.ToString(Request["sSearch_1"]);
            //    var IDFilter = Convert.ToString(Request["sSearch_1"]);


            //    //Optionally check whether the columns are searchable at all                
            //    var isModuleNameSearchable = Convert.ToBoolean(Request["bSearchable_0"]);
            //    var isModuleCodeSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
            //    var isModuleSeqNumberFilter = Convert.ToString(Request["sSearch_1"]);
            //    var isIDFilter = Convert.ToString(Request["sSearch_1"]);


            filteredUserMainMenuMaster = GetUserMainMenuMaster(out TotalRecords);                
            var displayedPosts = filteredUserMainMenuMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { Convert.ToString(c.MenuName), Convert.ToString(c.ModuleName), Convert.ToString(c.ModuleCode), Convert.ToString(c.MenuCode), Convert.ToString(c.MenuDisplaySeqNo), Convert.ToString(c.IsEnable), Convert.ToString(c.ID), Convert.ToString(c.MenuCode), Convert.ToString(c.ModuleCode) };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = TotalRecords,
                iTotalDisplayRecords = TotalRecords,
                aaData = result
            },
           JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}