using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AERP.DTO;
using AERP.ViewModel;
using DotNetOpenAuth.AspNet;
//using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using System.Configuration;
using AERP.Business.BusinessAction;
using AERP.Base.DTO;
using System.Security.Principal;
using AERP.Common;

namespace AERP.Web.UI.Controllers
{
    public class _HeaderController : BaseController
    {
        //
        // GET: /Header/
        IAdminRoleApplicableDetailsBA _adminRoleApplicableDetailsBA = null;
        IUserMainMenuMasterBA _userMainMenuMasterBA = null;
        AdminRoleApplicableDetailsBaseViewModel _adminRoleApplicableDetailsBaseViewModel = null;
        IUserModuleMasterBA _userModuleMasterBA = null;
        UserModuleMasterBaseViewModel _userModuleMasterBaseViewModel = null;
        AdminRoleApplicableDetails _adminRoleApplicableDetails = null;
        AccountMasterViewModel _accountMasterViewModel = null;
        IAdminRoleCentreRightsBA _adminRoleCentreRightsBA = null;
        string DefaultRoleCode = null;
        int DefaultRoleID = 0;

        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public _HeaderController()
        {
            _adminRoleApplicableDetailsBA = new AdminRoleApplicableDetailsBA();
            _userMainMenuMasterBA = new UserMainMenuMasterBA();
            _adminRoleApplicableDetailsBaseViewModel = new AdminRoleApplicableDetailsBaseViewModel();
            _userModuleMasterBA = new UserModuleMasterBA();
            _userModuleMasterBaseViewModel = new UserModuleMasterBaseViewModel();
            _adminRoleApplicableDetails = new AdminRoleApplicableDetails();
            _accountMasterViewModel = new AccountMasterViewModel();
            _adminRoleCentreRightsBA = new AdminRoleCentreRightsBA();
        }

        #region ----------------------Controller Methods----------------------

        public ActionResult Index()
        {
            return View();
        }

        #region ---------------------------Role List in header section--------------------

        public ActionResult _RoleList(int? PersonID, string ModuleID, string ModuleCode, string RoleCode, string ModuleName, string BalancesheetName, string BalancesheetID)
        {
            if (Session["UserType"] != null && Session["UserType"].ToString() != "S" && Session["UserType"].ToString() != "A")
            {
                if (ModuleID != null)
                {
                    Session["DefaultModuleID"] = ModuleID;
                    Session["DefaultModuleCode"] = ModuleCode;
                    Session["RoleCode"] = RoleCode;
                    Session["ModuleName"] = ModuleName;
                    Session["BalancesheetName"] = BalancesheetName;
                    Session["BalancesheetID"] = BalancesheetID;
                }
                else if (ModuleID == null && Session["DefaultModuleCode"] == null)           // changes regarding login particularlly session
                {
                    Session["DefaultModuleID"] = null;
                    Session["DefaultModuleCode"] = null;
                }
                else if (Session["DefaultModuleCode"] != null)
                {
                    _adminRoleApplicableDetailsBaseViewModel.RoleList = GetRoleListByUserID();
                    if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count > 0)
                    {
                        // var cityList = (from p in entity.Citiesmasters where p.enabled == true select new { p.ID, p.city });

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
                                DefaultRoleCode = t.AdminRoleCode;
                                DefaultRoleID = t.AdminRoleMasterID;
                            }

                        }

                        //bind seleclistitems list to to viewBag 

                        ViewData["RoleList"] = items;
                        if (string.IsNullOrEmpty(Convert.ToString(Session["DefaultModuleCode"]).Trim()))
                        {
                            ViewData["DefaultRoleCode"] = DefaultRoleCode.ToString();
                        }
                        else
                        {
                            ViewData["DefaultRoleCode"] = Session["RoleCode"];
                        }
                        ViewData["DefaultRoleID"] = DefaultRoleID.ToString();
                        Session["DefaultRoleID"] = DefaultRoleID.ToString();
                        ViewData["UserType"] = "E";



                        return PartialView();
                    }
                }            //Get role appicable to the current user from the DB
                if (PersonID != 0)
                {
                    Session["PersonId"] = PersonID.ToString();
                }
                _adminRoleApplicableDetailsBaseViewModel.RoleList = GetRoleListByUserID();
                if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count > 0)
                {
                    // var cityList = (from p in entity.Citiesmasters where p.enabled == true select new { p.ID, p.city });

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
                            DefaultRoleCode = t.AdminRoleCode;
                            DefaultRoleID = t.AdminRoleMasterID;
                        }
                    }

                    //bind seleclistitems list to to viewBag 

                    ViewData["RoleList"] = items;
                    if (string.IsNullOrEmpty(Convert.ToString(Session["DefaultModuleCode"]).Trim()))
                    {
                        ViewData["DefaultRoleCode"] = DefaultRoleCode.ToString();
                    }
                    else
                    {
                        ViewData["DefaultRoleCode"] = Session["RoleCode"];
                    }
                    ViewData["DefaultRoleID"] = DefaultRoleID.ToString();
                    Session["DefaultRoleID"] = DefaultRoleID.ToString();
                    ViewData["UserType"] = "E";



                    return PartialView();
                }
                else if (_adminRoleApplicableDetailsBaseViewModel.RoleList.Count <= 0)
                {
                    // return RedirectToAction("LogOff", "Account");
                    //Session.Abandon();                  

                    return RedirectToAction("LogOff", new { LogoutType = "test" });
                }
                // RedirectToAction("_ModuleList", "_Header");
                //returning the partial view
                ViewData["UserType"] = "E";
                return PartialView();
            }
            else if (Session["UserType"] != null && Session["UserType"].ToString() == "S" && Session["UserType"].ToString() != "A")
            {
                ViewData["UserType"] = "S";
                Session["DefaultRoleID"] = 0;
                return PartialView();
            }
            else if (Session["UserType"] != null && Session["UserType"].ToString() == "A")
            {
                ViewData["UserType"] = "A";
                Session["DefaultRoleID"] = 0;
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Account");

                //  return PartialView("~/views/Account/Login.cshtml");
            }

        }
        #endregion

        #region ---------------------------Module list in header section--------------------

        public ActionResult _ModuleList(int AdminRoleMasterID)
        {
            if (Session["UserType"] != null && Session["UserType"].ToString() != "S")
            {
                if (AdminRoleMasterID == 0)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    Session["TempModuleID"] = "1";
                }
                if (AdminRoleMasterID != 0 && AdminRoleMasterID != null)
                {

                    Session["RoleID"] = AdminRoleMasterID;
                }
                //Get module accessible to the current user from the DB
                if (Session["UserType"].ToString() == "E")
                {
                    _userModuleMasterBaseViewModel.ListUserModuleMaster = GetModuleListByUserID(AdminRoleMasterID);
                    GetCentreLevelManagerRights(AdminRoleMasterID);                         // method to get centrelevelManagerRights for each form
                }
                else if (Session["UserType"].ToString() == "A")
                {
                    _userModuleMasterBaseViewModel.ListUserModuleMaster = GetModuleListForAdmin();
                }

                if (_userModuleMasterBaseViewModel.ListUserModuleMaster.Count > 0)
                {
                    //Create selectlistitem list 
                    ViewData["ModuleCountFlag"] = "1";
                    List<SelectListItem> items = new List<SelectListItem>();
                    SelectListItem s = null;

                    //add the empty selection
                    s = new SelectListItem();
                    s.Value = "";
                    s.Text = "";
                    items.Add(s);
                    foreach (var t in _userModuleMasterBaseViewModel.ListUserModuleMaster)
                    {
                        s = new SelectListItem();
                        //s.Value = t.ID.ToString();
                        s.Value = t.ModuleCode.ToString();
                        s.Text = Resources.ResourceManager.GetString("Module_" + t.ModuleCode.ToString()); //t.ModuleName.ToString();
                        items.Add(s);
                    }
                    ViewData["ModuleList"] = items;
                    //bind seleclistitems list to to viewBag 
                    if (!string.IsNullOrEmpty(Convert.ToString(Session["ModuleName"]).Trim()))
                    {
                        ViewData["ModuleName"] = Session["ModuleName"].ToString().Trim();
                        GetAccountBalancesheetMaster(Session["ModuleName"].ToString(), Convert.ToString(AdminRoleMasterID));
                    }
                    else
                    {
                        ViewData["ModuleName"] = ViewBag.ModuleList[1].Text;
                        GetAccountBalancesheetMaster(ViewBag.ModuleList[1].Text, Convert.ToString(AdminRoleMasterID));
                    }

                    if (Session["DefaultModuleCode"] == null)
                    {
                        Session["DefaultModuleID"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ID;
                        Session["DefaultModuleCode"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleCode;
                        Session["ModuleName"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleName;
                    }

                    if (Session["UserType"].ToString() == "E")
                    {
                        ViewData["UserType"] = "E";
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        ViewData["UserType"] = "A";
                    }
                    return PartialView();
                }
                else if (_userModuleMasterBaseViewModel.ListUserModuleMaster.Count <= 0)
                {
                    //  return PartialView("Login");
                    // return RedirectToAction("LogOff", "Account");
                    //return RedirectToAction("Login", "Account");
                    //string ProjectName = Session["ProjectName"].ToString();
                    //Session.Clear();
                    //Session.Abandon();
                    ViewData["ModuleCountFlag"] = "0";
                    return PartialView();

                }
                //returning the partial view
                if (Session["UserType"].ToString() == "E")
                {
                    ViewData["UserType"] = "E";
                }
                else if (Session["UserType"].ToString() == "A")
                {
                    ViewData["UserType"] = "A";
                }
                return PartialView();
            }
            else if (Session["UserType"] != null && Session["UserType"].ToString() == "S")
            {
                ViewData["UserType"] = "S";
                return PartialView();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Log1()
        {

            //throw new NullReferenceException("This is error");
            return RedirectToAction("Login", "Account");
        }
        #endregion

        #region ---------------------------_Balancesheet list in Header section--------------------

        public ActionResult _BalancesheetList(string ModuleName)
        {
            try
            {
                ViewBag.BalancesheetList = null;
                GetAccountBalancesheetMaster(string.IsNullOrEmpty(ModuleName) ? string.Empty : ModuleName, Convert.ToString(Session["RoleID"]));
                if (!string.IsNullOrEmpty(Convert.ToString(Session["BalancesheetName"])))
                {
                    ViewData["SelectedBalancesheetName"] = Session["BalancesheetName"];
                    ViewData["SelectedBalancesheetID"] = Session["BalancesheetID"];
                }
                else
                {
                    ViewData["SelectedBalancesheetName"] = ViewBag.BalanceSheetList != null ? ViewBag.BalanceSheetList[1].Text : null;
                    ViewData["SelectedBalancesheetID"] = ViewBag.BalanceSheetList != null ? ViewBag.BalanceSheetList[1].Value : null;
                    Session["BalancesheetName"] = ViewBag.BalanceSheetList != null ? ViewBag.BalanceSheetList[1].Text : null;
                    Session["BalancesheetID"] = ViewBag.BalanceSheetList != null ? ViewBag.BalanceSheetList[1].Value : null;
                }
                //returning the partial view
                return PartialView();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region ---------------------------Menu list in SideBar/Menu section--------------------

        public ActionResult _MenuList(string ModuleCode, string ModuleName)
        {
            int month = DateTime.Now.Month;
            ViewData["MonthName"] = ((MonthEnum)month).ToString();
            if (Session["UserType"] != null && Session["UserType"].ToString() != "S")
            {
                if (ModuleCode == "")
                {
                    int AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                    //Get module accessible to the current user from the DB
                    if (Session["UserType"].ToString() == "E")
                    {
                        _userModuleMasterBaseViewModel.ListUserModuleMaster = GetModuleListByUserID(AdminRoleMasterID);
                    }
                    else if (Session["UserType"].ToString() == "A")
                    {
                        _userModuleMasterBaseViewModel.ListUserModuleMaster = GetModuleListForAdmin();
                    }
                    // var cityList = (from p in entity.Citiesmasters where p.enabled == true select new { p.ID, p.city });
                    if (_userModuleMasterBaseViewModel.ListUserModuleMaster.Count > 0)
                    {
                        //Create selectlistitem list 
                        List<SelectListItem> items = new List<SelectListItem>();
                        SelectListItem s = null;

                        //add the empty selection
                        s = new SelectListItem();
                        s.Value = "";
                        s.Text = "";
                        items.Add(s);
                        foreach (var t in _userModuleMasterBaseViewModel.ListUserModuleMaster)
                        {
                            s = new SelectListItem();
                            //s.Value = t.ID.ToString();
                            s.Value = t.ModuleCode.ToString();
                            s.Text = t.ModuleName.ToString();
                            items.Add(s);
                        }

                        //bind seleclistitems list to to viewBag 
                        //  ViewData["ModuleList"] = items;
                        ////ViewData["DefaultModuleVal"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ID;
                        ViewData["DefaultModuleVal"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleCode;
                        ViewData["DefaultModuleVal"] = _userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleName;
                        //// ViewData["MenuList"] = BuildMenu(_userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleID, Convert.ToString(Session["DefaultRoleID"]));
                        ViewData["MenuList"] = BuildMenu(_userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleCode, Convert.ToString(Session["DefaultRoleID"]));
                        Session["ModuleID"] = "0";
                        Session["ModuleCode"] = "0";
                        Session["ModuleName"] = ModuleName;
                        GetAccountBalancesheetMaster(_userModuleMasterBaseViewModel.ListUserModuleMaster[0].ModuleName, Convert.ToString(Session["RoleID"]));
                        return PartialView("_Sidebar", ViewData["MenuList"]);
                    }
                    else if (_userModuleMasterBaseViewModel.ListUserModuleMaster.Count <= 0)
                    {
                        return PartialView("Login");
                        // return RedirectToAction("Login", "Account");
                    }

                    //returning the partial view

                }
                else
                {
                    ////Session["ModuleID"] = ModuleID;
                    Session["ModuleCode"] = ModuleCode;
                    //ViewData["MenuList"] = BuildMenu(ModuleID);
                    ////ViewData["MenuList"] = BuildMenu(ModuleID, Convert.ToString(Session["RoleID"] != null ? Session["RoleID"] : "0"));
                    ViewData["MenuList"] = BuildMenu(ModuleCode, Convert.ToString(Session["RoleID"] != null ? Session["RoleID"] : "0"));
                    Session["ModuleName"] = ModuleName;
                }

                return PartialView("_Sidebar", ViewData["MenuList"]);
            }
            else if (Session["UserType"] != null && Session["UserType"].ToString() == "S")
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                //StudentMaster student = new StudentMaster();
                //student = GetCentreFromStudentMasterByStudentID(PersonID);
                //ViewData["MenuList"] = BuildMenuForStudent("STUPORTAL", Convert.ToString(student.CentreCode));
                return PartialView("_StudentSidebar", ViewData["MenuList"]);
            }
            else if (Session["UserType"] != null && Session["UserType"].ToString() == "A")
            {
                int PersonID = Convert.ToInt32(Session["PersonID"]);

                ViewData["MenuList"] = BuildMenu(ModuleCode, "0");
                return PartialView("_Sidebar", ViewData["MenuList"]);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
        #endregion

        public ActionResult _MenuList_Student()
        {
            return PartialView("_MenuList_Student");
        }



        #endregion

        #region ----------------------Methods----------------------



        //protected List<UserModuleMaster> GetModuleListByUserID(int AdminRoleMasterID)
        //{
        //    UserModuleMasterSearchRequest searchRequest = new UserModuleMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.AdminRoleMasterID = AdminRoleMasterID;
        //    List<UserModuleMaster> ModuleList = new List<UserModuleMaster>();
        //    IBaseEntityCollectionResponse<UserModuleMaster> baseEntityCollectionResponse = _userModuleMasterBA.GetModuleListForLoginUserIDByRoleID(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            ModuleList = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    TempData["ModuleList"] = ModuleList;
        //    return ModuleList;
        //}

        public void GetAccountBalancesheetMaster(string ModuleName, string RoleID)
        {
            if ((ModuleName.Trim() == "ACCOUNTS" || ModuleName.Trim() == "INVENTORY" || ModuleName.Trim() == "PURCHASE") && Convert.ToString(Session["UserType"]) != "A")
            {

                _accountMasterViewModel.ListAccountBalancesheetMaster = GetListOfAccountBalancesheetMasterRoleWise(Convert.ToInt32(RoleID));
                if (_accountMasterViewModel.ListAccountBalancesheetMaster.Count > 0)
                {
                    List<SelectListItem> Balsheetitems = new List<SelectListItem>();
                    SelectListItem sl = null;

                    //add the empty selection
                    sl = new SelectListItem();
                    sl.Value = "";
                    sl.Text = "";
                    Balsheetitems.Add(sl);
                    foreach (var t in _accountMasterViewModel.ListAccountBalancesheetMaster)
                    {
                        sl = new SelectListItem();
                        sl.Value = t.ID.ToString();
                        sl.Text = t.AccBalsheetHeadDesc.ToString();
                        Balsheetitems.Add(sl);
                    }
                    ViewData["BalanceSheetList"] = Balsheetitems;
                }
            }
            else
            {
                ViewData["BalanceSheetList"] = null;
            }
        }

        //public ActionResult UpdateBalancesheetSession(string selectedBalsheetID, string selectedBalsheetName)
        //{
        //       Session["BalancesheetName"]  = selectedBalsheetName;
        //     Session["BalancesheetID"] = selectedBalsheetID;
        //    return null;
        //}

        public void GetCentreLevelManagerRights(int AdminRoleMasterID)
        {
            AdminRoleCentreRightsSearchRequest searchRequest = new AdminRoleCentreRightsSearchRequest();
            searchRequest.AdminRoleMasterID = AdminRoleMasterID;
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<AdminRoleCentreRights> listAdminRoleCentreRights = new List<AdminRoleCentreRights>();
            IBaseEntityCollectionResponse<AdminRoleCentreRights> baseEntityCollectionResponse = _adminRoleCentreRightsBA.GetCentreLevelManagerRights(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAdminRoleCentreRights = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }

            if (listAdminRoleCentreRights.Count > 0)
            {
                foreach (var t in listAdminRoleCentreRights)
                {
                    Session[t.RightName] = t.AdminRoleRightTypeID;
                }
            }
            //Session["SuperUser"] = response.Entity.SuperUser.ToString();
            //Session["AcadMgr"] = response.Entity.AcadMgr.ToString();
            //Session["EstMgr"] = response.Entity.EstMgr.ToString();
            //Session["FinMgr"] = response.Entity.FinMgr.ToString();
            //Session["AdmMgr"] = response.Entity.AdmMgr.ToString();
        }

        #endregion
    }

}
