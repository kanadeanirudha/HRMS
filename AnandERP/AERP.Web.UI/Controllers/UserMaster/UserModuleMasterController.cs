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
    public class UserModuleMasterController : BaseController
    {
        IUserModuleMasterBA _userModuleMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        public UserModuleMasterController()
        {
            _userModuleMasterBA = new UserModuleMasterBA();

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
            UserModuleMasterViewModel model = new UserModuleMasterViewModel();  
            if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                 //_sortBy = "ModuleName";
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
        public ActionResult Create()
        {
            UserModuleMasterViewModel model = new UserModuleMasterViewModel();
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Create(UserModuleMasterViewModel model)
        {
          try
            { 

            if (ModelState.IsValid)
            {
                if (model != null && model.UserModuleMasterDTO != null)
                {
                    model.UserModuleMasterDTO.ConnectionString = _connectioString;
                    model.UserModuleMasterDTO.ModuleName = model.ModuleName;
                    model.UserModuleMasterDTO.ModuleCode = model.ModuleCode;
                    model.UserModuleMasterDTO.ModuleInstalledFlag = model.ModuleInstalledFlag;
                    model.UserModuleMasterDTO.ModuleActiveFlag = model.ModuleActiveFlag;
                    model.UserModuleMasterDTO.ModuleSeqNumber = model.ModuleSeqNumber;
                    model.UserModuleMasterDTO.ModuleRelatedWith = model.ModuleRelatedWith;
                    model.UserModuleMasterDTO.ModuleTooltip = model.ModuleTooltip;
                    model.UserModuleMasterDTO.ModuleIconName = model.ModuleIconName;
                    model.UserModuleMasterDTO.ModuleIconPath = model.ModuleIconPath;
                    model.UserModuleMasterDTO.ModuleFormName = model.ModuleFormName;
                    model.UserModuleMasterDTO.CreatedBy = Convert.ToInt32(Session["UserId"]); //model.CreatedBy;
                    IBaseEntityResponse<UserModuleMaster> response = _userModuleMasterBA.InsertUserModuleMaster(model.UserModuleMasterDTO);
                    model.UserModuleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                }
                // return Content(Boolean.TrueString);
                return Json(model.UserModuleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            UserModuleMasterViewModel model = new UserModuleMasterViewModel();
            try
            {
                model.UserModuleMasterDTO = new UserModuleMaster();
                model.UserModuleMasterDTO.ID = id;
                model.UserModuleMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<UserModuleMaster> response = _userModuleMasterBA.SelectByID(model.UserModuleMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.UserModuleMasterDTO.ID = response.Entity.ID;
                    model.UserModuleMasterDTO.ModuleName = response.Entity.ModuleName;
                    model.UserModuleMasterDTO.ModuleCode = response.Entity.ModuleCode;
                    model.UserModuleMasterDTO.ModuleInstalledFlag = response.Entity.ModuleInstalledFlag;
                    model.UserModuleMasterDTO.ModuleActiveFlag = response.Entity.ModuleActiveFlag;
                    model.UserModuleMasterDTO.ModuleSeqNumber = response.Entity.ModuleSeqNumber;
                    model.UserModuleMasterDTO.ModuleRelatedWith = response.Entity.ModuleRelatedWith;
                    model.UserModuleMasterDTO.ModuleTooltip = response.Entity.ModuleTooltip;
                    model.UserModuleMasterDTO.ModuleIconName = response.Entity.ModuleIconName;
                    model.UserModuleMasterDTO.ModuleIconPath = response.Entity.ModuleIconPath;
                    model.UserModuleMasterDTO.ModuleFormName = response.Entity.ModuleFormName;                   
                }
                return PartialView(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(UserModuleMasterViewModel model)
        {
          try
            {
            if (ModelState.IsValid)
            {
                if (model != null && model.UserModuleMasterDTO != null)
                {
                    if (model != null && model.UserModuleMasterDTO != null)
                    {
                        model.UserModuleMasterDTO.ConnectionString = _connectioString;
                        model.UserModuleMasterDTO.ModuleName = model.ModuleName;
                        model.UserModuleMasterDTO.ModuleCode = model.ModuleCode;
                        model.UserModuleMasterDTO.ModuleInstalledFlag = model.ModuleInstalledFlag;
                        model.UserModuleMasterDTO.ModuleActiveFlag = model.ModuleActiveFlag;
                        model.UserModuleMasterDTO.ModuleSeqNumber = model.ModuleSeqNumber;
                        model.UserModuleMasterDTO.ModuleRelatedWith = model.ModuleRelatedWith;
                        model.UserModuleMasterDTO.ModuleTooltip = model.ModuleTooltip;
                        model.UserModuleMasterDTO.ModuleIconName = model.ModuleIconName;
                        model.UserModuleMasterDTO.ModuleIconPath = model.ModuleIconPath;
                        model.UserModuleMasterDTO.ModuleFormName = model.ModuleFormName;
                        model.UserModuleMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<UserModuleMaster> response = _userModuleMasterBA.UpdateUserModuleMaster(model.UserModuleMasterDTO);
                        model.UserModuleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }

                return Json(model.UserModuleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        
        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            UserModuleMasterViewModel model = new UserModuleMasterViewModel();
            try
            {
                //if (!ModelState.IsValid)
                //{
                    if (ID > 0)
                    {
                        UserModuleMaster UserModuleMasterDTO = new UserModuleMaster();
                        UserModuleMasterDTO.ConnectionString = _connectioString;
                        UserModuleMasterDTO.ID = ID;
                        UserModuleMasterDTO.DeletedBy = Convert.ToInt32(Session["UserId"]);
                        IBaseEntityResponse<UserModuleMaster> response = _userModuleMasterBA.DeleteUserModuleMaster(UserModuleMasterDTO);
                        model.UserModuleMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    // return Content(Boolean.TrueString);
                    return Json(model.UserModuleMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public IEnumerable<UserModuleMasterViewModel> GetUserModuleMaster(out int TotalRecords)
        {
            UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
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
            List<UserModuleMasterViewModel> listUserModuleMasterViewModel = new List<UserModuleMasterViewModel>();
            List<UserModuleMaster> listUserModuleMaster = new List<UserModuleMaster>();
            IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listUserModuleMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (UserModuleMaster item in listUserModuleMaster)
                    {
                        UserModuleMasterViewModel UserModuleMasterViewModel = new UserModuleMasterViewModel();
                        UserModuleMasterViewModel.UserModuleMasterDTO = item;
                        listUserModuleMasterViewModel.Add(UserModuleMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listUserModuleMasterViewModel;
        }

        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc        
            IEnumerable<UserModuleMasterViewModel> filteredUserModuleMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ModuleName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ModuleName Like '%" + param.sSearch + "%' or ModuleCode Like '%" + param.sSearch + "%' or ModuleSeqNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ModuleCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ModuleName Like '%" + param.sSearch + "%' or ModuleCode Like '%" + param.sSearch + "%' or ModuleSeqNumber Like '%" + param.sSearch + "%'";     //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "ModuleSeqNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ModuleName Like '%" + param.sSearch + "%' or ModuleCode Like '%" + param.sSearch + "%' or ModuleSeqNumber Like '%" + param.sSearch + "%'";       //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ModuleName Like '%" + param.sSearch + "%' or ModuleCode Like '%" + param.sSearch + "%' or ModuleSeqNumber Like '%" + param.sSearch + "%'";    //this "if" block is added for search functionality
                    }
                    break;
               
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredUserModuleMaster = GetUserModuleMaster(out TotalRecords);                  
            var displayedPosts = filteredUserModuleMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.ModuleName.ToString(), c.ModuleCode.ToString(),c.ModuleSeqNumber.ToString(), Convert.ToString(c.ID) };
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