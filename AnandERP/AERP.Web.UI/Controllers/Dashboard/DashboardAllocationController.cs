using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class DashboardAllocationController : BaseController
    {
        IDashboardBA _DashboardBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;  
        string _sortBy = string.Empty;   
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public DashboardAllocationController()
        {
            _DashboardBA = new DashboardBA();
        }


        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Dashboard/DashboardAllocation/Index.cshtml");
        }

        [HttpPost]
        public ActionResult List(string actionMode, string ModuleCode, int AdminRoleMasterID = 0)
        {
            try
            {
                DashboardViewModel model = new DashboardViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode.Replace(@"\", string.Empty);
                }

                //Get Role.
                List<Dashboard> DashboardRoleCode = GetListDashboardRoleCode();
                List<SelectListItem> DashboardRoleCodelist = new List<SelectListItem>();
                foreach (Dashboard item in DashboardRoleCode)
                {
                    DashboardRoleCodelist.Add(new SelectListItem { Text = item.AdminRoleCode, Value = Convert.ToString(item.AdminRoleMasterID) });
                }
                ViewBag.AdminRoleCodeList = new SelectList(DashboardRoleCodelist, "Value", "Text", AdminRoleMasterID);

                //Get Module.
                List<UserModuleMaster> moduleList = GetModuleListForAdmin();
                List<SelectListItem> CRMModuleList = new List<SelectListItem>();
                foreach (UserModuleMaster item in moduleList)
                {
                    CRMModuleList.Add(new SelectListItem { Text = item.ModuleName, Value = item.ModuleCode });
                }
                ViewBag.ListUserModuleMaster = new SelectList(CRMModuleList, "Value", "Text", ModuleCode);
                model.DashboardDTO.AdminRoleMasterID = AdminRoleMasterID;
                return PartialView("/Views/Dashboard/DashboardAllocation/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        public ActionResult DeleteContaintAllocateStatus(string ID)
        {
            try
            {
                if (ID != string.Empty & ID != null)
                {
                    DashboardViewModel model = new DashboardViewModel();
                    string[] adminRole = ID.Split('~');

                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.DashboardContentDetailsID = Convert.ToInt32(adminRole[0]);
                    model.DashboardDTO.AdminRoleMasterID = Convert.ToInt32(adminRole[1]);

                    //model.DashboardDTO.PersonID = Convert.ToInt32(Session["PersonID"]);
                    model.DashboardDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.DeleteContaintAllocateStatus(model.DashboardDTO);
                    model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult InsertContaintAllocateStatus(string ID)
        {
            try
            {
                if (ID != string.Empty & ID != null)
                {
                    string[] adminRole = ID.Split('~');
                    DashboardViewModel model = new DashboardViewModel();
                    model.DashboardDTO.ConnectionString = _connectioString;
                    model.DashboardDTO.DashboardContentDetailsID = Convert.ToInt32(adminRole[0]);
                    model.DashboardDTO.AdminRoleMasterID = Convert.ToInt32(adminRole[1]);
                    //model.DashboardDTO.PersonID = Convert.ToInt32(Session["PersonID"]);

                    model.DashboardDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<Dashboard> response = _DashboardBA.InsertContaintAllocateStatus(model.DashboardDTO);
                    model.DashboardDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.DashboardDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion
        
        // Non-Action Method
        #region Methods
        public IEnumerable<DashboardViewModel> GetDeshboardAllocationList(int AdminRoleMasterID, string ModuleCode, out int TotalRecords)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                    searchRequest.ModuleCode = ModuleCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = String.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                    searchRequest.ModuleCode = ModuleCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.AdminRoleMasterID = AdminRoleMasterID;
                searchRequest.ModuleCode = ModuleCode;
            }
            List<DashboardViewModel> listDashboardViewModel = new List<DashboardViewModel>();
            List<Dashboard> listDashboard = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _DashboardBA.GetDeshboardAllocationBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listDashboard = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (Dashboard item in listDashboard)
                    {
                        DashboardViewModel dashboard = new DashboardViewModel();
                        dashboard.DashboardDTO = item;
                        listDashboardViewModel.Add(dashboard);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listDashboardViewModel;
        }

        #endregion


        // AjaxHandler Method
        #region

        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string ModuleCode, string AdminRoleMasterID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<DashboardViewModel> filteredDashboardModel;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        //_sortBy = "A.ModuleName";
                        _sortBy = "ContentStatus";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ModuleName Like '%" + param.sSearch + "%' or A.ContentTitle Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.ContentTitle";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "A.ModuleName Like '%" + param.sSearch + "%' or B.ContentTitle Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                if (AdminRoleMasterID != string.Empty && AdminRoleMasterID != null)
                {
                    filteredDashboardModel = GetDeshboardAllocationList(Convert.ToInt32(AdminRoleMasterID), ModuleCode, out TotalRecords);
                }
                else
                {
                    filteredDashboardModel = new List<DashboardViewModel>();
                    TotalRecords = 0;
                }

                var records = filteredDashboardModel.Skip(0).Take(param.iDisplayLength);
                var result = from c in records
                             select new[] 
                             {
                                 Convert.ToString(c.DashboardContentDetailsID), 
                                 Convert.ToString(c.ModuleName), 
                                 Convert.ToString(c.ContentTitle),
                                 Convert.ToString(c.DashboardAllocationID),
                                 Convert.ToString(c.ContentStatus),
                                 Convert.ToString(AdminRoleMasterID)
                             };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}
