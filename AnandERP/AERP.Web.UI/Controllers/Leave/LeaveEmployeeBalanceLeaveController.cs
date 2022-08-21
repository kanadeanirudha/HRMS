using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using AERP.Common;
using AERP.DataProvider;
using System.Configuration;
using AERP.Business.BusinessAction;

namespace AERP.Web.UI.Controllers
{
    public class LeaveEmployeeBalanceLeaveController : BaseController
    {
        ILeaveApplicationBA _ILeaveApplicationBA = null;
        ILeaveApplicationViewModel _LeaveApplicationViewModel = null;
        ILeavePostBA _ILeavePostBA = null;

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

        public LeaveEmployeeBalanceLeaveController()
        {
            _ILeaveApplicationBA = new LeaveApplicationBA();
            _LeaveApplicationViewModel = new LeaveApplicationViewModel();
            _ILeavePostBA = new LeavePostBA();
        }

        //  Controller Methods.
        #region ------------------Controller Methods------------------

        public ActionResult Index()
        {
            try
            {
                //if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                //{
                    return View("/Views/Leave/LeaveEmployeeBalanceLeave/Index.cshtml");
                //}
                //else
                //{
                //    int AdminRoleMasterID = 0;
                //    if (Session["RoleID"] == null)
                //    {
                //        AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                //    }
                //    else
                //    {
                //        AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                //    }
                //    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID);
                //    if (listAdminRoleApplicableDetails.Count > 0)
                //    {
                //        return View("/Views/Leave/LeaveEmployeeBalanceLeave/Index.cshtml");
                //    }
                //    else
                //    {
                //        return RedirectToAction("UnauthorizedAccess", "Home");
                //    }                
                //}

            }
            catch(Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }            
        }

        public ActionResult List(string actionMode, string centerCode, string centreName, string departmentName, string deparmentID)
        {
            try
            {

                if (!string.IsNullOrEmpty(centerCode) && deparmentID != null)
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _LeaveApplicationViewModel.CentreCode = splitCentreCode[0];
                    _LeaveApplicationViewModel.DepartmentID = deparmentID;
                    if (splitCentreCode[1].ToString() == "SELF")
                    {
                        _LeaveApplicationViewModel.EmployeeID = Convert.ToInt32(Session["PersonID"]);
                    }
                    // _LeavePostViewModel.EntityLevel = splitCentreCode[1];
                    //centerCode = splitCentreCode[0];
                    IEnumerable<LeaveApplicationViewModel> filteredLeaveBalance = GetEmployeeBalanceLeave(_LeaveApplicationViewModel.CentreCode, _LeaveApplicationViewModel.DepartmentID, _LeaveApplicationViewModel.EmployeeID);

                    int numberOfColumn = 0;
                    List<String> listLeaveType = new List<String>();
                    if (filteredLeaveBalance.Count() > 0)
                    {
                        _LeaveApplicationViewModel.LeaveSessionID = filteredLeaveBalance.ElementAt(0).LeaveSessionID;
                        ViewBag.Data = 1;
                        ViewBag.ListLeavePost = filteredLeaveBalance;

                        foreach (var item in filteredLeaveBalance)
                        {
                            string[] splitedLeaveList = item.LeaveList.Split(',');
                            if (splitedLeaveList.Length > numberOfColumn)
                            {
                                numberOfColumn = splitedLeaveList.Length;
                                // numberOfColumn = numberOfColumn + 1;
                            }

                            foreach (var a in splitedLeaveList)
                            {
                                var b = a.Split('#');
                                if (!listLeaveType.Contains(b[0]))
                                {
                                    listLeaveType.Add(b[0]);
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Data = 0;
                    }
                    ViewBag.numberOfcolumn = numberOfColumn;
                    ViewBag.listLeaveType = listLeaveType;
                    ViewBag.listLeaveTypeCount = listLeaveType.Count;
                    ViewBag.TotalRecords = filteredLeaveBalance.Count();
                }
                else
                {
                    _LeaveApplicationViewModel.CentreCode = centerCode;
                    _LeaveApplicationViewModel.DepartmentID = deparmentID;
                    ViewBag.Data = 0;
                    ViewBag.ListLeavePost = "";
                    ViewBag.numberOfcolumn = 0;
                    ViewBag.listLeaveType = "";
                    ViewBag.TotalRecords = 0;
                    //_LeavePostViewModel.EntityLevel = null;
                }
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    //--------------------------------------For Centre Code list---------------------------------//
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveApplicationViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveApplicationViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveApplicationViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + "Centre";
                    }
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, Convert.ToInt32(Session["PersonID"]));
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveApplicationViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveApplicationViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode + ":" + b.ScopeIdentity;
                    }
                    //if (centerCode == null)
                    //{
                    //    _LeaveApplicationViewModel.ListOrganisationDepartmentMaster = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);// GetListOrganisationDepartmentMaster(Convert.ToString(_LeaveApplicationViewModel.ListGetAdminRoleApplicableCentre[0].CentreCode));
                    //}
                    //if (centerCode != null)
                    //{
                    //    _LeaveApplicationViewModel.ListOrganisationDepartmentMaster = GetListOrganisationDepartmentMaster(_LeaveApplicationViewModel.CentreCode);
                    //}
                    if (!string.IsNullOrEmpty(centerCode))
                    {
                        string[] splitCentreCode = centerCode.Split(':');
                        _LeaveApplicationViewModel.ListOrganisationDepartmentMaster = GetListOrganisationMasterCentreAndRoleWise(splitCentreCode[0], splitCentreCode[1], AdminRoleMasterID);
                    }
                    //foreach (var b in _LeaveApplicationViewModel.ListOrganisationDepartmentMaster)
                    //{
                    //    b.DeptID = b.ID + ":" + b.DepartmentName;
                    //}
                }

                _LeaveApplicationViewModel.CentreCode = centerCode;
                _LeaveApplicationViewModel.CentreName = centreName;
                _LeaveApplicationViewModel.DepartmentID = deparmentID;
                _LeaveApplicationViewModel.DepartmentName = departmentName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveEmployeeBalanceLeave/List.cshtml", _LeaveApplicationViewModel);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult GetDepartmentByCentreCode(string CentreCode)
        //{
        //    if (CentreCode.Contains(':'))
        //    {
        //        string[] splited;
        //        splited = CentreCode.Split(':');

        //        // _adminSnPostsBaseViewModel.SelectedCentreName = splited[1];
        //        CentreCode = splited[0];
        //    }

        //    if (String.IsNullOrEmpty(CentreCode))
        //    {
        //        throw new ArgumentNullException("CentreCode");
        //    }
        //    int id = 0;
        //    bool isValid = Int32.TryParse(CentreCode, out id);
        //    var departments = GetListOrganisationDepartmentMaster(CentreCode);
        //    var result = (from s in departments
        //                  select new
        //                  {
        //                      id = s.ID,
        //                      name = s.DepartmentName,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult GetDepartmentByCentreCode(string CentreCode)
        {
            int AdminRoleMasterID = 0;
            if (Convert.ToString(Session["UserType"]) == "A")
            {
                AdminRoleMasterID = 0;
            }
            else
            {
                if (Session["RoleID"] == null)
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["DefaultRoleID"]);
                }
                else
                {
                    AdminRoleMasterID = Convert.ToInt32(Session["RoleID"]);
                }
            }
            string[] splited = CentreCode.Split(':');
            if (String.IsNullOrEmpty(CentreCode))
            {
                throw new ArgumentNullException("CentreCode");
            }
            int id = 0;
            bool isValid = Int32.TryParse(CentreCode, out id);
            var department = GetListOrganisationMasterCentreAndRoleWise(splited[0], splited[1], AdminRoleMasterID);
            var result = (from s in department
                          select new
                          {
                              id = s.ID,
                              name = s.DepartmentName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion


        // Non-Action Methods
        #region Methods

        public IEnumerable<LeaveApplicationViewModel> GetEmployeeBalanceLeave(string CentreCode, string DepartmentID,int EmployeeID)
        {
            LeaveApplicationSearchRequest searchRequest = new LeaveApplicationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);                        
                
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
                searchRequest.DepartmentID = DepartmentID;
                searchRequest.EmployeeID = EmployeeID;
            
            List<LeaveApplicationViewModel> listLeaveApplicationViewModel = new List<LeaveApplicationViewModel>();
            List<LeaveApplication> listLeavePost = new List<LeaveApplication>();
            IBaseEntityCollectionResponse<LeaveApplication> baseEntityCollectionResponse = _ILeaveApplicationBA.GetEmployeeBalanceLeave(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeavePost = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveApplication item in listLeavePost)
                    {
                        LeaveApplicationViewModel _LeaveApplicationViewModel = new LeaveApplicationViewModel();
                        _LeaveApplicationViewModel.LeaveApplicationDTO = item;
                        listLeaveApplicationViewModel.Add(_LeaveApplicationViewModel);
                    }
                }
            }
            // TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveApplicationViewModel;
        }

        #endregion

    }
}
