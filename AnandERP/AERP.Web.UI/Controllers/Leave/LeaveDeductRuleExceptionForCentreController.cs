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
using AERP.Business.BusinessActions;

namespace AERP.Web.UI.Controllers
{
    public class LeaveDeductRuleExceptionForCentreController : BaseController
    {
        ILeaveDeductRuleExceptionForCentreBA _ILeaveDeductRuleExceptionForCentreBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public LeaveDeductRuleExceptionForCentreController()
        {
            _ILeaveDeductRuleExceptionForCentreBA = new LeaveDeductRuleExceptionForCentreBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            return View("/Views/Leave/LeaveDeductRuleExceptionForCentre/Index.cshtml");
        }

        public ActionResult List(string centerCode, string hoCoRoScFlag, string actionMode)
        {
            try
            {
                LeaveDeductRuleExceptionForCentreViewModel model = new LeaveDeductRuleExceptionForCentreViewModel();
                if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["SuperUser"]) > 0 || Convert.ToInt32(Session["EstMgr"]) > 0)
                {
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "------Select Center Type------", Value = "" });
                    li.Add(new SelectListItem { Text = "Comman For All Centre", Value = "1" });
                    li.Add(new SelectListItem { Text = "Centre Specific", Value = "2" });
                    ViewData["HoCoRoScFlag"] = li;

                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        //a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreCode = item.CentreCode;
                        a.CentreName = item.CentreName;                        
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                    model.CentreCode = centerCode;
                    model.HoCoRoScFlag = hoCoRoScFlag;
                    return PartialView("/Views/Leave/LeaveDeductRuleExceptionForCentre/List.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
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
            LeaveDeductRuleExceptionForCentreViewModel model = new LeaveDeductRuleExceptionForCentreViewModel();
            return PartialView("/Views/LeaveDeductRuleExceptionForCentre/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(LeaveDeductRuleExceptionForCentreViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.LeaveDeductRuleExceptionForCentreDTO != null)
                    {
                        model.LeaveDeductRuleExceptionForCentreDTO.ConnectionString = _connectioString;
                        //  model.LeaveDeductRuleExceptionForCentreDTO.TaxName = model.TaxName;
                        //    model.LeaveDeductRuleExceptionForCentreDTO.TaxRate = model.TaxRate;
                        model.LeaveDeductRuleExceptionForCentreDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = _ILeaveDeductRuleExceptionForCentreBA.InsertLeaveDeductRuleExceptionForCentre(model.LeaveDeductRuleExceptionForCentreDTO);
                        model.LeaveDeductRuleExceptionForCentreDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.LeaveDeductRuleExceptionForCentreDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            LeaveDeductRuleExceptionForCentreViewModel model = new LeaveDeductRuleExceptionForCentreViewModel();
            try
            {
                model.LeaveDeductRuleExceptionForCentreDTO = new LeaveDeductRuleExceptionForCentre();
                model.LeaveDeductRuleExceptionForCentreDTO.LeaveMasterID = id;
                model.LeaveDeductRuleExceptionForCentreDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = _ILeaveDeductRuleExceptionForCentreBA.SelectByID(model.LeaveDeductRuleExceptionForCentreDTO);
                if (response != null && response.Entity != null)
                {
                    model.LeaveDeductRuleExceptionForCentreDTO.LeaveMasterID = response.Entity.LeaveMasterID;
                    //  model.LeaveDeductRuleExceptionForCentreDTO.TaxName = response.Entity.TaxName;
                    // model.LeaveDeductRuleExceptionForCentreDTO.SeqNo = response.Entity.SeqNo;
                    //   model.LeaveDeductRuleExceptionForCentreDTO.TaxRate = response.Entity.TaxRate;
                    //  model.LeaveDeductRuleExceptionForCentreDTO.IsCompoundTax = response.Entity.IsCompoundTax;
                    model.LeaveDeductRuleExceptionForCentreDTO.CreatedBy = response.Entity.CreatedBy;
                }
                return PartialView(model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(LeaveDeductRuleExceptionForCentreViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.LeaveDeductRuleExceptionForCentreDTO != null)
                {
                    if (model != null && model.LeaveDeductRuleExceptionForCentreDTO != null)
                    {
                        model.LeaveDeductRuleExceptionForCentreDTO.ConnectionString = _connectioString;
                        //   model.LeaveDeductRuleExceptionForCentreDTO.TaxName = model.TaxName;
                        //    model.LeaveDeductRuleExceptionForCentreDTO.TaxRate = model.TaxRate;
                        model.LeaveDeductRuleExceptionForCentreDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = _ILeaveDeductRuleExceptionForCentreBA.UpdateLeaveDeductRuleExceptionForCentre(model.LeaveDeductRuleExceptionForCentreDTO);
                        model.LeaveDeductRuleExceptionForCentreDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.LeaveDeductRuleExceptionForCentreDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {
            LeaveDeductRuleExceptionForCentreViewModel model = new LeaveDeductRuleExceptionForCentreViewModel();
            model.LeaveDeductRuleExceptionForCentreDTO = new LeaveDeductRuleExceptionForCentre();
            model.LeaveDeductRuleExceptionForCentreDTO.LeaveMasterID = ID;
            return PartialView(model);
        }

        //[HttpPost]
        //public ActionResult Delete(LeaveDeductRuleExceptionForCentreViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        if (model.ID > 0)
        //        {
        //            LeaveDeductRuleExceptionForCentre LeaveDeductRuleExceptionForCentreDTO = new LeaveDeductRuleExceptionForCentre();
        //            LeaveDeductRuleExceptionForCentreDTO.ConnectionString = _connectioString;
        //            LeaveDeductRuleExceptionForCentreDTO.LeaveMasterIDID = model.LeaveMasterID;
        //            LeaveDeductRuleExceptionForCentreDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> response = _LeaveDeductRuleExceptionForCentreServiceAcess.DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentreDTO);
        //            model.LeaveDeductRuleExceptionForCentreDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

        //        }
        //        return Json(model.LeaveDeductRuleExceptionForCentreDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        return Json("Please review your form");
        //    }
        //}
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<LeaveDeductRuleExceptionForCentreViewModel> GetLeaveDeductRuleExceptionForCentre(string centerCode, out int TotalRecords)
        {           
            LeaveDeductRuleExceptionForCentreSearchRequest searchRequest = new LeaveDeductRuleExceptionForCentreSearchRequest();
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
                    searchRequest.CentreCode = centerCode;
                }
                //if (actionModeEnum == ActionModeEnum.Update)
                //{
                //    searchRequest.SortBy = "ModifiedDate";
                //    searchRequest.StartRow = 0;
                //    searchRequest.EndRow = 10;
                //    searchRequest.SearchBy = string.Empty;
                //    searchRequest.SortDirection = "Desc";
                //}
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.CentreCode = centerCode;
            }

            List<LeaveDeductRuleExceptionForCentreViewModel> listLeaveDeductRuleExceptionForCentre = new List<LeaveDeductRuleExceptionForCentreViewModel>();
            List<LeaveDeductRuleExceptionForCentre> listLeaveDeductRule = new List<LeaveDeductRuleExceptionForCentre>();
            IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> baseEntityCollectionResponse = _ILeaveDeductRuleExceptionForCentreBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLeaveDeductRule = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (LeaveDeductRuleExceptionForCentre data in listLeaveDeductRule)
                    {
                        LeaveDeductRuleExceptionForCentreViewModel item = new LeaveDeductRuleExceptionForCentreViewModel();
                        item.LeaveDeductRuleExceptionForCentreDTO = data;
                        listLeaveDeductRuleExceptionForCentre.Add(item);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listLeaveDeductRuleExceptionForCentre;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string centreCode, string hoCoRoScFlag)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<LeaveDeductRuleExceptionForCentreViewModel> filteredTaxMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "cte2.PrioritySequenceNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "cte2.LeaveCode Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            if (hoCoRoScFlag != "" || centreCode != "")
            {
                filteredTaxMaster = GetLeaveDeductRuleExceptionForCentre(centreCode, out TotalRecords);
            }
            else
            {
                filteredTaxMaster = new List<LeaveDeductRuleExceptionForCentreViewModel>();
                TotalRecords = 0;
            }
            
            var records = filteredTaxMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records
                         select new[] { Convert.ToString(c.LeaveDescription),
                                      Convert.ToString(c.PriorityLeaveDescription + "  " + c.PrioritySequenceNumber), 
                                      Convert.ToString(c.LeaveMasterID +"~"+ c.PriorityLeaveMasterID + "~" + c.LeaveDeductRuleID),
                                      Convert.ToString( c.LeaveCode)
                                     };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}