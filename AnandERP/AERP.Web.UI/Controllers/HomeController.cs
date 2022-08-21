using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Common;
using AERP.DataProvider;
using System.Configuration;
using AERP.Web.UI;
using AERP.Web.UI.HtmlHelperExtensions;
using AERP.Web.UI.Models;

namespace AERP.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        IDashboardBA _dashboardBA = null;
        AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortOrder = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public HomeController()
        {
            _dashboardBA = new DashboardBA();
            _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();
        }

        #region --------------------- Controller Method ----------------------
        public ActionResult Index(string ReturnUrl)
        {
            IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
            if (Session["UserType"] != null)
            {
                ViewBag.ReturnUrl = ReturnUrl;
                if (Session["UserType"].ToString() == "E")
                {
                    _adminRoleApplicableDetailsBaseViewModel.RoleList = GetRoleListByUserID();
                    if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count > 0)
                    {

                        //Create selectlistitem list 
                        List<SelectListItem> items = new List<SelectListItem>();
                        SelectListItem s = null;

                        //add the empty selection
                        s = new SelectListItem();
                        //s.Value = "";
                        //s.Text = "";
                        //items.Add(s);
                        foreach (var t in _adminRoleApplicableDetailsBaseViewModel.RoleList)
                        {
                            s = new SelectListItem();
                            s.Text = t.AdminRoleMasterID.ToString();
                            s.Value = t.AdminRoleCode.ToString();
                            items.Add(s);

                            if (t.RoleType == "Regular")
                            {
                                //DefaultRoleCode = t.AdminRoleCode;
                                Session["DefaultRoleID"] = t.AdminRoleMasterID;
                            }

                        }

                        //bind seleclistitems list to to viewBag 
                        ViewData["UserType"] = "E";

                    }

                    _dashboardViewModel.DashboardContentList = GetDashboardContentListByAdminRoleID(Convert.ToInt32(Session["DefaultRoleID"]));
                    if (_dashboardViewModel.DashboardContentList.Count > 0)
                    {
                        return View("/Views/Dashboard/DashboardIndex.cshtml", _dashboardViewModel);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult List(string actionMode, string TaskCode)
        {
            try
            {

                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                if (TaskCode == null)
                {
                    _dashboardViewModel.TaskCode = "LA";

                }
                else
                {
                    _dashboardViewModel.TaskCode = TaskCode;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                    // ViewData["ModuleRowCount"] = _dashboardViewModel.ModuleList.Count()/4;
                }

                //return PartialView("List", _dashboardViewModel);

                return PartialView("/Views/Home/List.cshtml", _dashboardViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult UnauthorizedAccess()
        {
            if (Session["UserType"] != null)
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult NotificationList(string actionMode, string TaskCode)
        {
            try
            {
                IDashboardViewModel _dashboardViewModel = new DashboardViewModel();
                _dashboardViewModel.PersonID = Convert.ToInt32(Session["PersonID"]);
                _dashboardViewModel.TaskCodeList = GetTaskCodeList(_dashboardViewModel.PersonID);
                if (TaskCode != null)
                {
                    _dashboardViewModel.TaskCode = TaskCode;

                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                var AdminRoleMasterID = 0;
                if ((Session["UserType"] != null))
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                    if (Session["UserType"].ToString() == "E")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _dashboardViewModel.ModuleList = GetModuleListForAdmin();
                    }
                }
                return PartialView("/Views/TaskNotification/NotificationList.cshtml", _dashboardViewModel);


            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region --------------------- Non Controller Method ----------------------
        protected List<Dashboard> GetDashboardContentListByAdminRoleID(int AdminRoleMasterID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            List<Dashboard> ModuleList = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardBA.GetDashboardContentListByAdminRoleID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            //  TempData["ModuleList"] = ModuleList;
            return ModuleList;
        }
        protected List<Dashboard> GetTaskCodeList(int PersonID)
        {
            DashboardSearchRequest searchRequest = new DashboardSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.PersonID = PersonID;
            List<Dashboard> listTaskCode = new List<Dashboard>();
            IBaseEntityCollectionResponse<Dashboard> baseEntityCollectionResponse = _dashboardBA.GetGeneralTaskModelListByPersonID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listTaskCode = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listTaskCode;
        }
        #endregion
    }
}