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
    public class OrganisationMasterController : BaseController
    {
        IOrganisationMasterBA _organisationMasterBA = null;
        private readonly ILogger _logException;
        OrganisationMasterBaseViewModel _organisationMasterBaseViewModel = null;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationMasterController()
        {
            _organisationMasterBA = new OrganisationMasterBA();
            _organisationMasterBaseViewModel = new OrganisationMasterBaseViewModel();
        }

        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/Organisation/OrganisationMaster/Index.cshtml");
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode)
        {
            try
            {
                OrganisationMasterViewModel model = new OrganisationMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationMaster/List.cshtml", model);

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
            OrganisationMasterViewModel model = new OrganisationMasterViewModel();
            try
            {
                List<GeneralLocationMaster> GeneralLocationMasterList = GetListGeneralLocationMaster();
                List<SelectListItem> GeneralLocationMaster = new List<SelectListItem>();
                foreach (GeneralLocationMaster item in GeneralLocationMasterList)
                {
                    GeneralLocationMaster.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }
                ViewBag.GeneralLocationMaster = new SelectList(GeneralLocationMaster, "Value", "Text");
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("/Views/Organisation/OrganisationMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationMasterDTO != null)
                    {
                        if (!string.IsNullOrEmpty(model.OfficeComment))
                        {
                            model.OrganisationMasterDTO.OfficeComment = model.OfficeComment;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficeComment = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.Address2))
                        {
                            model.OrganisationMasterDTO.Address2 = model.Address2;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.Address2 = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.MissionStatement))
                        {
                            model.OrganisationMasterDTO.MissionStatement = model.MissionStatement;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.MissionStatement = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.OfficePhone1))
                        {
                            model.OrganisationMasterDTO.OfficePhone1 = model.OfficePhone1;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficePhone1 = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.OfficePhone2))
                        {
                            model.OrganisationMasterDTO.OfficePhone2 = model.OfficePhone2;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficePhone2 = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.Pincode))
                        {
                            model.OrganisationMasterDTO.Pincode = model.Pincode;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.Pincode = string.Empty;
                        }
                        model.OrganisationMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationMasterDTO.OrgName = model.OrgName;
                        model.OrganisationMasterDTO.LocationID = Convert.ToInt32(model.SelectedLocationID);
                        model.OrganisationMasterDTO.FoundationDatetime = model.FoundationDatetime;
                        model.OrganisationMasterDTO.FounderMember = model.FounderMember;
                        model.OrganisationMasterDTO.Address1 = model.Address1;
                        model.OrganisationMasterDTO.Address2 = model.Address2;
                        model.OrganisationMasterDTO.PlotNumber = model.PlotNumber;
                        model.OrganisationMasterDTO.StreetNumber = model.StreetNumber;
                        model.OrganisationMasterDTO.Pincode = model.Pincode;
                        model.OrganisationMasterDTO.FaxNumber = model.FaxNumber;
                        model.OrganisationMasterDTO.OfficePhone1 = model.OfficePhone1;
                        model.OrganisationMasterDTO.OfficePhone2 = model.OfficePhone2;
                        model.OrganisationMasterDTO.MobileNumber = model.MobileNumber;
                        model.OrganisationMasterDTO.EmailID = model.EmailID;
                        model.OrganisationMasterDTO.Url = model.Url;
                        model.OrganisationMasterDTO.MissionStatement = model.MissionStatement;
                        model.OrganisationMasterDTO.PFNumber = model.PFNumber;
                        model.OrganisationMasterDTO.ESICNumber= model.ESICNumber;
                        model.OrganisationMasterDTO.OrgShortCode = model.OrgShortCode;

                        model.OrganisationMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationMaster> response = _organisationMasterBA.InsertOrganisationMaster(model.OrganisationMasterDTO);
                        model.OrganisationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

            OrganisationMasterViewModel model = new OrganisationMasterViewModel();
            try
            {
                List<GeneralLocationMaster> GeneralLocationMasterList = GetListGeneralLocationMaster();
                List<SelectListItem> GeneralLocationMaster = new List<SelectListItem>();
                foreach (GeneralLocationMaster item in GeneralLocationMasterList)
                {
                    GeneralLocationMaster.Add(new SelectListItem { Text = item.LocationAddress, Value = item.ID.ToString() });
                }
                model.OrganisationMasterDTO = new OrganisationMaster();
                model.OrganisationMasterDTO.ID = id;
                model.OrganisationMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationMaster> response = _organisationMasterBA.SelectByID(model.OrganisationMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.OrganisationMasterDTO.ID = response.Entity.ID;
                    model.OrganisationMasterDTO.OrgName = response.Entity.OrgName;
                    model.OrganisationMasterDTO.EstablishmentCode = response.Entity.EstablishmentCode;
                    model.OrganisationMasterDTO.FoundationDatetime = response.Entity.FoundationDatetime;
                    model.OrganisationMasterDTO.FounderMember = response.Entity.FounderMember;
                    model.OrganisationMasterDTO.Address1 = response.Entity.Address1;
                    model.OrganisationMasterDTO.Address2 = response.Entity.Address2;
                    model.OrganisationMasterDTO.PlotNumber = response.Entity.PlotNumber;
                    model.OrganisationMasterDTO.StreetNumber = response.Entity.StreetNumber;
                    model.OrganisationMasterDTO.Pincode = response.Entity.Pincode;
                    model.OrganisationMasterDTO.FaxNumber = response.Entity.FaxNumber;
                    model.OrganisationMasterDTO.OfficePhone1 = response.Entity.OfficePhone1;
                    model.OrganisationMasterDTO.OfficePhone2 = response.Entity.OfficePhone2;
                    model.OrganisationMasterDTO.MobileNumber = response.Entity.MobileNumber;
                    model.OrganisationMasterDTO.EmailID = response.Entity.EmailID;
                    model.OrganisationMasterDTO.Url = response.Entity.Url;
                    model.OrganisationMasterDTO.OfficeComment = response.Entity.OfficeComment;
                    model.OrganisationMasterDTO.MissionStatement = response.Entity.MissionStatement;
                    model.OrganisationMasterDTO.PFNumber = response.Entity.PFNumber;
                    model.OrganisationMasterDTO.ESICNumber = response.Entity.ESICNumber;
                    model.OrganisationMasterDTO.OrgShortCode = response.Entity.OrgShortCode;


                    ViewBag.GeneralLocationMaster = new SelectList(GeneralLocationMaster, "Value", "Text", response.Entity.LocationID.ToString());

                }
                return PartialView("/Views/Organisation/OrganisationMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationMasterDTO != null)
                    {
                        model.OrganisationMasterDTO.ConnectionString = _connectioString;

                        if (!string.IsNullOrEmpty(model.OfficeComment))
                        {
                            model.OrganisationMasterDTO.OfficeComment = model.OfficeComment;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficeComment = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(model.Address2))
                        {
                            model.OrganisationMasterDTO.Address2 = model.Address2;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.Address2 = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(model.MissionStatement))
                        {
                            model.OrganisationMasterDTO.MissionStatement = model.MissionStatement;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.MissionStatement = string.Empty;
                        }

                        if (!string.IsNullOrEmpty(model.OfficePhone1))
                        {
                            model.OrganisationMasterDTO.OfficePhone1 = model.OfficePhone1;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficePhone1 = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.OfficePhone2))
                        {
                            model.OrganisationMasterDTO.OfficePhone2 = model.OfficePhone2;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.OfficePhone2 = string.Empty;
                        }
                        if (!string.IsNullOrEmpty(model.Pincode))
                        {
                            model.OrganisationMasterDTO.Pincode = model.Pincode;
                        }
                        else
                        {
                            model.OrganisationMasterDTO.Pincode = string.Empty;
                        }
                        model.OrganisationMasterDTO.OrgName = model.OrgName;
                        model.OrganisationMasterDTO.LocationID = Convert.ToInt32(model.SelectedLocationID.ToString());
                        model.OrganisationMasterDTO.FoundationDatetime = model.FoundationDatetime;
                        model.OrganisationMasterDTO.FounderMember = model.FounderMember;
                        model.OrganisationMasterDTO.Address1 = model.Address1;
                        model.OrganisationMasterDTO.PlotNumber = model.PlotNumber;
                        model.OrganisationMasterDTO.StreetNumber = model.StreetNumber;
                        model.OrganisationMasterDTO.FaxNumber = model.FaxNumber;
                        model.OrganisationMasterDTO.MobileNumber = model.MobileNumber;
                        model.OrganisationMasterDTO.EmailID = model.EmailID;
                        model.OrganisationMasterDTO.PFNumber = model.PFNumber;
                        model.OrganisationMasterDTO.ESICNumber = model.ESICNumber;
                        model.OrganisationMasterDTO.OrgShortCode = model.OrgShortCode;

                        model.OrganisationMasterDTO.Url = model.Url;
                        model.OrganisationMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationMaster> response = _organisationMasterBA.UpdateOrganisationMaster(model.OrganisationMasterDTO);
                        model.OrganisationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.OrganisationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            OrganisationMasterViewModel model = new OrganisationMasterViewModel();
            try
            {

                if (ID > 0)
                {
                    //if (model != null && model.OrganisationMasterDTO != null)
                    //{
                    OrganisationMaster orgStreamMasterDTO = new OrganisationMaster();
                    orgStreamMasterDTO.ConnectionString = _connectioString;
                    orgStreamMasterDTO.ID = ID;
                    orgStreamMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<OrganisationMaster> response = _organisationMasterBA.DeleteOrganisationMaster(orgStreamMasterDTO);
                    model.OrganisationMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    //}
                    return Json(model.OrganisationMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }

                else
                {
                    return Json("Please review your form");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        // Non- Action Method
        #region Methods
        public IEnumerable<OrganisationMasterViewModel> GetOrganisationMaster(out int TotalRecords)
        {
            OrganisationMasterSearchRequest searchRequest = new OrganisationMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                        // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<OrganisationMasterViewModel> listOrganisationMasterViewModel = new List<OrganisationMasterViewModel>();
            List<OrganisationMaster> listOrganisationMaster = new List<OrganisationMaster>();
            IBaseEntityCollectionResponse<OrganisationMaster> baseEntityCollectionResponse = _organisationMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationMaster item in listOrganisationMaster)
                    {
                        OrganisationMasterViewModel generalRegionMasterViewModel = new OrganisationMasterViewModel();
                        generalRegionMasterViewModel.OrganisationMasterDTO = item;
                        listOrganisationMasterViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationMasterViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<OrganisationMasterViewModel> filteredOrganisationMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "OrgName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "OrgName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or FounderMember Like '%" + param.sSearch + "%' or FoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "EstablishmentCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "OrgName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or FounderMember Like '%" + param.sSearch + "%' or FoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "FounderMember";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "OrgName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or FounderMember Like '%" + param.sSearch + "%' or FoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "FoundationDatetime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "OrgName Like '%" + param.sSearch + "%' or EstablishmentCode Like '%" + param.sSearch + "%' or FounderMember Like '%" + param.sSearch + "%' or FoundationDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredOrganisationMaster = GetOrganisationMaster(out TotalRecords);
            var records = filteredOrganisationMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { c.OrgName.ToString(), c.EstablishmentCode.ToString(), c.FounderMember.ToString(), DateTime.Parse(c.FoundationDatetime.ToString()).ToString("dd-MMM-yyyy"), Convert.ToString(c.ID), c.TotalRecordsFound.ToString() };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}