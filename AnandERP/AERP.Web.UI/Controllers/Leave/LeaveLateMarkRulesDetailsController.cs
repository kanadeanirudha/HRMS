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
    public class LeaveLateMarkRulesDetailsController : BaseController
    {
        ILeaveLateMarkRulesDetailsBA _ILeaveLateMarkRulesDetailsBA = null;
        ILeaveLateMarkRulesDetailsViewModel _LeaveLateMarkRulesDetailsViewModel = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveLateMarkRulesDetailsController()
        {
            _ILeaveLateMarkRulesDetailsBA = new LeaveLateMarkRulesDetailsBA();
            _LeaveLateMarkRulesDetailsViewModel = new LeaveLateMarkRulesDetailsViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    return View("/Views/Leave/LeaveLateMarkRulesDetails/Index.cshtml");
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    if (listAdminRoleApplicableDetails.Count > 0)
                    {
                        return View("/Views/Leave/LeaveLateMarkRulesDetails/Index.cshtml");
                    }
                    else
                    {
                        return RedirectToAction("UnauthorizedAccess", "Home");
                    }
                }
                    
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        public ActionResult List(string actionMode, string centerCode, string centreName)
        {
            try
            {
                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    _LeaveLateMarkRulesDetailsViewModel.CentreCode = splitCentreCode[0];
                }
                else
                {
                    _LeaveLateMarkRulesDetailsViewModel.CentreCode = centerCode;
                    //_LeaveLateMarkRulesDetailsViewModel.EntityLevel = null;
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
                        _LeaveLateMarkRulesDetailsViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    _LeaveLateMarkRulesDetailsViewModel.EntityLevel = "Centre";

                    foreach (var b in _LeaveLateMarkRulesDetailsViewModel.ListGetAdminRoleApplicableCentre)
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
                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByHRManager(AdminRoleMasterID);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        _LeaveLateMarkRulesDetailsViewModel.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                    foreach (var b in _LeaveLateMarkRulesDetailsViewModel.ListGetAdminRoleApplicableCentre)
                    {
                        b.CentreCode = b.CentreCode;
                    }
                }

                _LeaveLateMarkRulesDetailsViewModel.CentreCode = centerCode;
                _LeaveLateMarkRulesDetailsViewModel.CentreName = centreName;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Leave/LeaveLateMarkRulesDetails/List.cshtml", _LeaveLateMarkRulesDetailsViewModel);
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
            LeaveLateMarkRulesDetailsViewModel model = new LeaveLateMarkRulesDetailsViewModel();
            List<LeaveMaster> LeaveMasterList = GetListLeaveMaster();
            List<SelectListItem> leaveMaster = new List<SelectListItem>();
            leaveMaster.Add(new SelectListItem { Text = "-----Select Leave Type-----", Value = "" });
            foreach (LeaveMaster item in LeaveMasterList)
            {
                leaveMaster.Add(new SelectListItem { Text = item.LeaveDescription, Value = (item.ID).ToString().Trim() });
            }

            ViewBag.LeaveMaster = new SelectList(leaveMaster, "Value", "Text");

            //For LateMark Count
            List<SelectListItem> LeaveLateMarkRulesDetails_LateMarkCount = new List<SelectListItem>();
            ViewBag.LeaveLateMarkRulesDetails_LateMarkCount = new SelectList(LeaveLateMarkRulesDetails_LateMarkCount, "Value", "Text");
            List<SelectListItem> li_LeaveLateMarkRulesDetails_LateMarkCount = new List<SelectListItem>();
            for (int i = 1; i <= 10; i++)
            {
                li_LeaveLateMarkRulesDetails_LateMarkCount.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            ViewData["LateMarkCount"] = li_LeaveLateMarkRulesDetails_LateMarkCount;

            //For LateMark Count
            List<SelectListItem> LeaveLateMarkRulesDetails_NumberLeaveDeducted = new List<SelectListItem>();
            ViewBag.LeaveLateMarkRulesDetails_NumberLeaveDeducted = new SelectList(LeaveLateMarkRulesDetails_NumberLeaveDeducted, "Value", "Text");
            List<SelectListItem> li_LeaveLateMarkRulesDetails_NumberLeaveDeducted = new List<SelectListItem>();
            //  float j = 0.5f;
            for (float i = 0.5f; i <= 10; i = i + 0.5f)
            {
                li_LeaveLateMarkRulesDetails_NumberLeaveDeducted.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                //  j = j + 0.5f;
            }
            ViewData["NumberLeaveDeducted"] = li_LeaveLateMarkRulesDetails_NumberLeaveDeducted;
            return PartialView("/Views/Leave/LeaveLateMarkRulesDetails/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(LeaveLateMarkRulesDetailsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveLateMarkRulesDetailsDTO != null)
                    {
                        model.LeaveLateMarkRulesDetailsDTO.ConnectionString = _connectioString;
                        model.LeaveLateMarkRulesDetailsDTO.LateMarkRuleName = model.LateMarkRuleName;
                        model.LeaveLateMarkRulesDetailsDTO.LateMarkCount = model.LateMarkCount; ;
                        model.LeaveLateMarkRulesDetailsDTO.NumberLeaveDeducted = model.NumberLeaveDeducted;
                        model.LeaveLateMarkRulesDetailsDTO.LeaveID1 = model.LeaveID1;

                        if (model.LeaveID2 != null)
                        {
                            model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = model.LeaveID2;
                        }
                        else
                        {
                            if (model.LeaveID3 != null)
                            {
                                model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = model.LeaveID3;
                                model.LeaveID3 = null;
                            }
                            else
                            {
                                if (model.LeaveID4 != null)
                                {
                                    model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = model.LeaveID4;
                                    model.LeaveID4 = null;
                                }
                                else
                                {
                                    if (model.LeaveID5 != null)
                                    {
                                        model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = model.LeaveID5;
                                        model.LeaveID5 = null;
                                    }
                                    else
                                    {
                                        model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = model.LeaveID2;
                                    }
                                }
                            }
                        }

                        if (model.LeaveID3 != null)
                        {
                            model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = model.LeaveID3;
                        }
                        else
                        {
                            if (model.LeaveID4 != null)
                            {
                                model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = model.LeaveID4;
                                model.LeaveID4 = null;
                            }
                            else
                            {
                                if (model.LeaveID5 != null)
                                {
                                    model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = model.LeaveID5;
                                    model.LeaveID5 = null;
                                }
                                else
                                {
                                    model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = model.LeaveID3;
                                }
                            }
                        }
                        if (model.LeaveID4 != null)
                        {
                            model.LeaveLateMarkRulesDetailsDTO.LeaveID4 = model.LeaveID4;
                        }
                        else
                        {
                            if (model.LeaveID5 != null)
                            {
                                model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = model.LeaveID5;
                                model.LeaveID5 = null;
                            }
                            else
                            {
                                model.LeaveLateMarkRulesDetailsDTO.LeaveID4 = model.LeaveID4;
                            }
                        }

                        model.LeaveLateMarkRulesDetailsDTO.LeaveID5 = model.LeaveID5;
                        if (Convert.ToString(Session["UserType"]) == "A")
                        {
                            string[] CentreCodeArray =  model.CentreCode.Split(':');
                            model.LeaveLateMarkRulesDetailsDTO.CentreCode = CentreCodeArray[0];
                        }
                        else
                        {
                            model.LeaveLateMarkRulesDetailsDTO.CentreCode = model.CentreCode;
                        }
                        model.LeaveLateMarkRulesDetailsDTO.IsActive = true;
                        model.LeaveLateMarkRulesDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveLateMarkRulesDetails> response = _ILeaveLateMarkRulesDetailsBA.InsertLeaveLateMarkRulesDetails(model.LeaveLateMarkRulesDetailsDTO);
                        if ((response.Entity != null) && response.Entity.ErrorCode == 25)
                        {

                            string errorMessage = "Please deactivate previous late mark rule.";
                            string colorCode = "warning";
                            string  mode = string.Empty;
                            string[] arrayList = { errorMessage, colorCode, mode };
                            model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = string.Join(",", arrayList);
                        }
                        else
                        {
                            model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                        }
                    }
                    return Json(model.LeaveLateMarkRulesDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            LeaveLateMarkRulesDetailsViewModel model = new LeaveLateMarkRulesDetailsViewModel();
            try
            {
                List<LeaveMaster> LeaveMasterList = GetListLeaveMaster();
                List<SelectListItem> leaveMaster = new List<SelectListItem>();
                leaveMaster.Add(new SelectListItem { Text =Resources.ddlHeader_LeaveType , Value = "" });
                foreach (LeaveMaster item in LeaveMasterList)
                {
                    leaveMaster.Add(new SelectListItem { Text = item.LeaveDescription, Value = (item.ID).ToString().Trim() });
                }

                ViewBag.LeaveMaster = new SelectList(leaveMaster, "Value", "Text" );

                //For LateMark Count
                List<SelectListItem> LeaveLateMarkRulesDetails_LateMarkCount = new List<SelectListItem>();
                ViewBag.LeaveLateMarkRulesDetails_LateMarkCount = new SelectList(LeaveLateMarkRulesDetails_LateMarkCount, "Value", "Text");
                List<SelectListItem> li_LeaveLateMarkRulesDetails_LateMarkCount = new List<SelectListItem>();
                for (int i = 1; i <= 10; i++)
                {
                    li_LeaveLateMarkRulesDetails_LateMarkCount.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
             

                //For LateMark Count
                List<SelectListItem> LeaveLateMarkRulesDetails_NumberLeaveDeducted = new List<SelectListItem>();
                ViewBag.LeaveLateMarkRulesDetails_NumberLeaveDeducted = new SelectList(LeaveLateMarkRulesDetails_NumberLeaveDeducted, "Value", "Text");
                List<SelectListItem> li_LeaveLateMarkRulesDetails_NumberLeaveDeducted = new List<SelectListItem>();
                float j = 0.5f;
                for (decimal i = 0.5M; i <= 10; i = i + 0.5M)
                {
                    li_LeaveLateMarkRulesDetails_NumberLeaveDeducted.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                    j = j + 0.5f;
                }
              

                model.LeaveLateMarkRulesDetailsDTO = new LeaveLateMarkRulesDetails();
                model.LeaveLateMarkRulesDetailsDTO.ID = id;
                model.LeaveLateMarkRulesDetailsDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<LeaveLateMarkRulesDetails> response = _ILeaveLateMarkRulesDetailsBA.SelectByID(model.LeaveLateMarkRulesDetailsDTO);
                if (response != null && response.Entity != null)
                {
                    model.LeaveLateMarkRulesDetailsDTO.LateMarkRuleName = response.Entity.LateMarkRuleName;
                    model.LeaveLateMarkRulesDetailsDTO.LateMarkCount = response.Entity.LateMarkCount; 
                    model.LeaveLateMarkRulesDetailsDTO.NumberLeaveDeducted = response.Entity.NumberLeaveDeducted;
                    model.LeaveLateMarkRulesDetailsDTO.LeaveID1 = response.Entity.LeaveID1;
                    model.LeaveLateMarkRulesDetailsDTO.LeaveID2 = response.Entity.LeaveID2;
                    model.LeaveLateMarkRulesDetailsDTO.LeaveID3 = response.Entity.LeaveID3;
                    model.LeaveLateMarkRulesDetailsDTO.LeaveID4 = response.Entity.LeaveID4;
                    model.LeaveLateMarkRulesDetailsDTO.LeaveID5 = response.Entity.LeaveID5;
                    model.LeaveLateMarkRulesDetailsDTO.CentreCode = response.Entity.CentreCode;
                    model.LeaveLateMarkRulesDetailsDTO.IsActive = response.Entity.IsActive;
                }
                ViewData["LateMarkCount"] = new SelectList(li_LeaveLateMarkRulesDetails_LateMarkCount,"Text","Value", response.Entity.LateMarkCount);
                ViewData["NumberLeaveDeducted"] = new SelectList(li_LeaveLateMarkRulesDetails_NumberLeaveDeducted,"Text","Value",  response.Entity.NumberLeaveDeducted); ;


                return PartialView("/Views/Leave/LeaveLateMarkRulesDetails/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveLateMarkRulesDetailsViewModel model)
        {

            if (model != null && model.LeaveLateMarkRulesDetailsDTO != null)
            {
                model.LeaveLateMarkRulesDetailsDTO.ConnectionString = _connectioString;
                model.LeaveLateMarkRulesDetailsDTO.ID = model.ID;
                model.LeaveLateMarkRulesDetailsDTO.IsActive = model.IsActive;
                model.LeaveLateMarkRulesDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<LeaveLateMarkRulesDetails> response = _ILeaveLateMarkRulesDetailsBA.UpdateLeaveLateMarkRulesDetails(model.LeaveLateMarkRulesDetailsDTO);
                model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(model.LeaveLateMarkRulesDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    LeaveLateMarkRulesDetailsViewModel model = new LeaveLateMarkRulesDetailsViewModel();
        //    model.LeaveLateMarkRulesDetailsDTO = new LeaveLateMarkRulesDetails();
        //    model.LeaveLateMarkRulesDetailsDTO.ID = ID;
        //    return PartialView("/Views/Leave/LeaveLateMarkRulesDetails/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(LeaveLateMarkRulesDetailsViewModel model)
        //{

        //    if (model.ID > 0)
        //    {
        //        LeaveLateMarkRulesDetails LeaveLateMarkRulesDetailsDTO = new LeaveLateMarkRulesDetails();
        //        LeaveLateMarkRulesDetailsDTO.ConnectionString = _connectioString;
        //        LeaveLateMarkRulesDetailsDTO.ID = model.ID;
        //        LeaveLateMarkRulesDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //        IBaseEntityResponse<LeaveLateMarkRulesDetails> response = _LeaveLateMarkRulesDetailsServiceAccess.DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetailsDTO);
        //        model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //        return Json(model.LeaveLateMarkRulesDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
        //    }

        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            LeaveLateMarkRulesDetailsViewModel model = new LeaveLateMarkRulesDetailsViewModel();

            if (ID != null)
            {
                LeaveLateMarkRulesDetails LeaveLateMarkRulesDetailsDTO = new LeaveLateMarkRulesDetails();
                LeaveLateMarkRulesDetailsDTO.ConnectionString = _connectioString;
                LeaveLateMarkRulesDetailsDTO.ID = ID;
                LeaveLateMarkRulesDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<LeaveLateMarkRulesDetails> response = _ILeaveLateMarkRulesDetailsBA.DeleteLeaveLateMarkRulesDetails(LeaveLateMarkRulesDetailsDTO);
                //model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                model.LeaveLateMarkRulesDetailsDTO.ErrorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                return Json(model.LeaveLateMarkRulesDetailsDTO.ErrorMessage, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json("Please review your form");
            }
        }

        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<LeaveLateMarkRulesDetailsViewModel> GetLeaveLateMarkRulesDetailsRecords(out int TotalRecords, string CentreCode)
        {
            LeaveLateMarkRulesDetailsSearchRequest searchRequest = new LeaveLateMarkRulesDetailsSearchRequest();
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
                    searchRequest.CentreCode = CentreCode;
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.CentreCode = CentreCode;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = CentreCode;
            }
            List<LeaveLateMarkRulesDetailsViewModel> listLeaveLateMarkRulesDetailsViewModel = new List<LeaveLateMarkRulesDetailsViewModel>();
            List<LeaveLateMarkRulesDetails> listLeaveLateMarkRulesDetails = new List<LeaveLateMarkRulesDetails>();
            IBaseEntityCollectionResponse<LeaveLateMarkRulesDetails> baseEntityCollectionResponse = _ILeaveLateMarkRulesDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveLateMarkRulesDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveLateMarkRulesDetails item in listLeaveLateMarkRulesDetails)
                    {
                        LeaveLateMarkRulesDetailsViewModel _LeaveLateMarkRulesDetailsViewModel = new LeaveLateMarkRulesDetailsViewModel();
                        _LeaveLateMarkRulesDetailsViewModel.LeaveLateMarkRulesDetailsDTO = item;
                        listLeaveLateMarkRulesDetailsViewModel.Add(_LeaveLateMarkRulesDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveLateMarkRulesDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string CentreCode)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveLateMarkRulesDetailsViewModel> filteredLeaveLateMarkRulesDetails;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "LateMarkRuleName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LateMarkRuleName Like '%" + param.sSearch + "%' or LateMarkCount Like '%" + param.sSearch + "%' or NumberLeaveDeducted Like '%" + param.sSearch + "%' or B.LeaveCode Like '%" + param.sSearch + "%' or C.LeaveCode Like '%" + param.sSearch + "%' or D.LeaveCode Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                    }
                    break;

                case 1:
                    _sortBy = "LateMarkCount";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LateMarkRuleName Like '%" + param.sSearch + "%' or LateMarkCount Like '%" + param.sSearch + "%' or NumberLeaveDeducted Like '%" + param.sSearch + "%' or B.LeaveCode Like '%" + param.sSearch + "%' or C.LeaveCode Like '%" + param.sSearch + "%' or D.LeaveCode Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;

                case 2:
                    _sortBy = "NumberLeaveDeducted";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LateMarkRuleName Like '%" + param.sSearch + "%' or LateMarkCount Like '%" + param.sSearch + "%' or NumberLeaveDeducted Like '%" + param.sSearch + "%' or B.LeaveCode Like '%" + param.sSearch + "%' or C.LeaveCode Like '%" + param.sSearch + "%' or D.LeaveCode Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "IsActive";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "LateMarkRuleName Like '%" + param.sSearch + "%' or LateMarkCount Like '%" + param.sSearch + "%' or NumberLeaveDeducted Like '%" + param.sSearch + "%' or B.LeaveCode Like '%" + param.sSearch + "%' or C.LeaveCode Like '%" + param.sSearch + "%' or D.LeaveCode Like '%" + param.sSearch + "%'";           //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            if (!string.IsNullOrEmpty(CentreCode))
            {

                string[] splitCentreCode = CentreCode.Split(':');
                var centreCode = splitCentreCode[0];
                var RoleID = "";
                if (Session["UserType"].ToString() == "A")
                {
                    RoleID = Convert.ToString(0);
                }
                else
                {
                    RoleID = Session["RoleID"].ToString();
                }


                filteredLeaveLateMarkRulesDetails = GetLeaveLateMarkRulesDetailsRecords(out TotalRecords, centreCode);
            }
            else
            {
                filteredLeaveLateMarkRulesDetails = new List<LeaveLateMarkRulesDetailsViewModel>();
                TotalRecords = 0;
            }
            var records = filteredLeaveLateMarkRulesDetails.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.LateMarkRuleName), Convert.ToString(c.LateMarkCount), Convert.ToString(c.NumberLeaveDeducted), Convert.ToString(c.LeaveDetails), Convert.ToString(c.IsActive), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}