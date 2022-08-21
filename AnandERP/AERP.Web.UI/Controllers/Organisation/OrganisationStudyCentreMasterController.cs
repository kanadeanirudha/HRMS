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
    public class OrganisationStudyCentreMasterController : BaseController
    {

        IOrganisationStudyCentreMasterBA _organisationStudyCentreMasterBA = null;
        private readonly ILogger _logException;
        OrganisationStudyCentreMasterBaseViewModel _organisationStudyCentreMasterBaseViewModel = null;
        
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public OrganisationStudyCentreMasterController()
        {
            _organisationStudyCentreMasterBA = new OrganisationStudyCentreMasterBA();
            _organisationStudyCentreMasterBaseViewModel = new OrganisationStudyCentreMasterBaseViewModel();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/Organisation/OrganisationStudyCentreMaster/Index.cshtml");
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
                OrganisationStudyCentreMasterViewModel model = new OrganisationStudyCentreMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Organisation/OrganisationStudyCentreMaster/List.cshtml", model);
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
            string CenterCode = string.Empty;
            OrganisationStudyCentreMasterViewModel model = new OrganisationStudyCentreMasterViewModel();
            try
            {
                model.OrganisationStudyCentreMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<OrganisationStudyCentreMaster> response = _organisationStudyCentreMasterBA.SelectHOROCount(model.OrganisationStudyCentreMasterDTO);

                List<SelectListItem> organisationStudyCentreMaster = new List<SelectListItem>();
                ViewBag.OrganisationStudyCentreMaster = new SelectList(organisationStudyCentreMaster, "Value", "Text");

                List<SelectListItem> li = new List<SelectListItem>();
                //li.Add(new SelectListItem { Text = "--------------------Select---------------------", Value = "" });
                if (response != null && response.Entity != null && response.Entity.HoCount == 0)
                {
                    li.Add(new SelectListItem { Text = "Head Office", Value = "HO" });
                }
                li.Add(new SelectListItem { Text = Resources.DropdownMessage_RegionalOffice, Value = "RO" });
                li.Add(new SelectListItem { Text = Resources.DropdownMessage_StudyCentre, Value = "SC" });
                ViewData["HoCoRoScFlag"] = li;

                string SelectedCity = string.Empty;
                List<GeneralCityMaster> ListGeneralCityMaster = GetListGeneralCityMaster(SelectedCity);
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in ListGeneralCityMaster)
                {
                    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text");

                List<OrganisationMaster> ListOrganisationMaster = GetListOrganisationMaster();
                List<SelectListItem> OrganisationMaster = new List<SelectListItem>();
                foreach (OrganisationMaster item in ListOrganisationMaster)
                {
                    OrganisationMaster.Add(new SelectListItem { Text = item.OrgName, Value = item.ID.ToString() });
                }
                ViewBag.OrganisationMaster = new SelectList(OrganisationMaster, "Value", "Text");

                //model.OrganisationUniversityMasterList = GetListOrganisationUniversityMaster(CenterCode);
                //foreach (var b in model.OrganisationUniversityMasterList)
                //{
                //    if (b.universityFlag == true)
                //    {
                //        model.SelectedUniversityID = "selected";
                //    }
                //    else
                //    {
                //        model.SelectedUniversityID = string.Empty;
                //    }
                //}
            }
            catch (Exception)
            {
                throw;
            }
            return PartialView("/Views/Organisation/OrganisationStudyCentreMaster/Create.cshtml",model);
        }

        [HttpPost]
        public ActionResult Create(OrganisationStudyCentreMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationStudyCentreMasterDTO != null)
                    {
                        model.OrganisationStudyCentreMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationStudyCentreMasterDTO.CentreName = model.CentreName;
                        model.OrganisationStudyCentreMasterDTO.IDs = model.IDs;
                        model.OrganisationStudyCentreMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID);
                        model.OrganisationStudyCentreMasterDTO.OrganisationID = Convert.ToInt32(model.SelectedOrganisationID);
                        model.OrganisationStudyCentreMasterDTO.CentreCode = model.CentreCode;
                        model.OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime = model.CentreEstablishmentDatetime;
                        model.OrganisationStudyCentreMasterDTO.HoCoRoScFlag = model.HoCoRoScFlag;
                        model.OrganisationStudyCentreMasterDTO.HoID = model.HoID;
                        model.OrganisationStudyCentreMasterDTO.CoID = model.CoID;
                        model.OrganisationStudyCentreMasterDTO.RoID = model.RoID;
                        model.OrganisationStudyCentreMasterDTO.CentreSpecialization = model.CentreSpecialization;
                        model.OrganisationStudyCentreMasterDTO.Pincode = model.Pincode;
                        model.OrganisationStudyCentreMasterDTO.CentreAddress = model.CentreAddress;
                        model.OrganisationStudyCentreMasterDTO.EmailID = model.EmailID;
                        model.OrganisationStudyCentreMasterDTO.Url = model.Url;
                        if (model.CentreLoginNumber > 0)
                        {
                            model.OrganisationStudyCentreMasterDTO.CentreLoginNumber = model.CentreLoginNumber;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.CentreLoginNumber = 0;
                        }
                        if (string.IsNullOrEmpty(model.PlotNo))
                        {
                            model.OrganisationStudyCentreMasterDTO.PlotNo = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.PlotNo = model.PlotNo;
                        }
                        if (string.IsNullOrEmpty(model.StreetName))
                        {
                            model.OrganisationStudyCentreMasterDTO.StreetName = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.StreetName = model.StreetName;
                        }
                        if (string.IsNullOrEmpty(model.FaxNumber))
                        {
                            model.OrganisationStudyCentreMasterDTO.FaxNumber = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.FaxNumber = model.FaxNumber;
                        }
                        if (string.IsNullOrEmpty(model.PhoneNumberOffice))
                        {
                            model.OrganisationStudyCentreMasterDTO.PhoneNumberOffice = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.PhoneNumberOffice = model.PhoneNumberOffice;
                        }
                        if (string.IsNullOrEmpty(model.CellPhone))
                        {
                            model.OrganisationStudyCentreMasterDTO.CellPhone = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.CellPhone = model.CellPhone;
                        }
                        if (string.IsNullOrEmpty(model.InstituteCode))
                        {
                            model.OrganisationStudyCentreMasterDTO.InstituteCode = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.InstituteCode = model.InstituteCode;
                        }
                        
                        model.OrganisationStudyCentreMasterDTO.TimeZone = model.TimeZone;
                        model.OrganisationStudyCentreMasterDTO.Longitude = model.Longitude;
                        model.OrganisationStudyCentreMasterDTO.Latitude = model.Latitude;
                        model.OrganisationStudyCentreMasterDTO.CampusArea = model.CampusArea;
                        
                        model.OrganisationStudyCentreMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationStudyCentreMaster> response = _organisationStudyCentreMasterBA.InsertOrganisationStudyCentreMaster(model.OrganisationStudyCentreMasterDTO);
                        model.OrganisationStudyCentreMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    }
                    return Json(model.OrganisationStudyCentreMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult Edit(string ids)
        {
            OrganisationStudyCentreMasterViewModel model = new OrganisationStudyCentreMasterViewModel();
            try
            {
                string[] Arrays = ids.Split('~');
                int StydyCenterID = Convert.ToInt32(Arrays[0]);
                string CenterCode = Arrays[1].ToString();



                string SelectedCity = "";
                List<GeneralCityMaster> ListGeneralCityMaster = GetListGeneralCityMaster(SelectedCity);
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                foreach (GeneralCityMaster item in ListGeneralCityMaster)
                {
                    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

                List<OrganisationMaster> ListOrganisationMaster = GetListOrganisationMaster();
                List<SelectListItem> OrganisationMaster = new List<SelectListItem>();
                foreach (OrganisationMaster item in ListOrganisationMaster)
                {
                    OrganisationMaster.Add(new SelectListItem { Text = item.OrgName, Value = item.ID.ToString() });
                }

                //model.OrganisationUniversityMasterList = GetListOrganisationUniversityMaster(CenterCode);
                //foreach (var b in model.OrganisationUniversityMasterList)
                //{
                //    if (b.universityFlag == true)
                //    {
                //        model.SelectedUniversityID = "selected";
                //    }
                //    else
                //    {
                //        model.SelectedUniversityID = string.Empty;
                //    }
                //}

                model.OrganisationStudyCentreMasterDTO = new OrganisationStudyCentreMaster();
                model.OrganisationStudyCentreMasterDTO.ID = StydyCenterID;
                model.OrganisationStudyCentreMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<OrganisationStudyCentreMaster> response = _organisationStudyCentreMasterBA.SelectByID(model.OrganisationStudyCentreMasterDTO);

                if (response.Entity.HoCoRoScFlag == "SC")
                {
                    List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = GetListStudyCentreHORO();
                    List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
                    foreach (OrganisationStudyCentreMaster item in listOrganisationStudyCentreMaster)
                    {
                        OrganisationStudyCentreMaster.Add(new SelectListItem { Text = item.CentreName, Value = item.ID.ToString() });
                    }
                    ViewBag.OrganisationStudyCentreMaster = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");
                }
                else
                {
                    List<SelectListItem> OrganisationStudyCentreMaster = new List<SelectListItem>();
                    ViewBag.OrganisationStudyCentreMaster = new SelectList(OrganisationStudyCentreMaster, "Value", "Text");
                }

                if (response != null && response.Entity != null)
                {
                    // model.OrganisationStudyCentreMasterDTO.ID = response.Entity.ID;
                    model.OrganisationStudyCentreMasterDTO.CentreName = response.Entity.CentreName;
                    model.OrganisationStudyCentreMasterDTO.CentreCode = response.Entity.CentreCode;
                    model.OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime = response.Entity.CentreEstablishmentDatetime;
                    model.OrganisationStudyCentreMasterDTO.CentreLoginNumber = response.Entity.CentreLoginNumber;
                    model.OrganisationStudyCentreMasterDTO.InstituteCode = response.Entity.InstituteCode;
                    model.OrganisationStudyCentreMasterDTO.HoCoRoScFlag = response.Entity.HoCoRoScFlag;
                    model.OrganisationStudyCentreMasterDTO.HoID = response.Entity.HoID;
                    model.OrganisationStudyCentreMasterDTO.CoID = response.Entity.CoID;
                    model.OrganisationStudyCentreMasterDTO.RoID = response.Entity.RoID;
                    model.OrganisationStudyCentreMasterDTO.CentreSpecialization = response.Entity.CentreSpecialization;
                    model.OrganisationStudyCentreMasterDTO.Pincode = response.Entity.Pincode;
                    model.OrganisationStudyCentreMasterDTO.FaxNumber = response.Entity.FaxNumber;
                    model.OrganisationStudyCentreMasterDTO.CentreAddress = response.Entity.CentreAddress;
                    model.OrganisationStudyCentreMasterDTO.PlotNo = response.Entity.PlotNo;
                    model.OrganisationStudyCentreMasterDTO.StreetName = response.Entity.StreetName;
                    model.OrganisationStudyCentreMasterDTO.EmailID = response.Entity.EmailID;
                    model.OrganisationStudyCentreMasterDTO.Url = response.Entity.Url;
                    model.OrganisationStudyCentreMasterDTO.CellPhone = response.Entity.CellPhone;
                    model.OrganisationStudyCentreMasterDTO.PhoneNumberOffice = response.Entity.PhoneNumberOffice;
                    model.OrganisationStudyCentreMasterDTO.TimeZone = response.Entity.TimeZone;
                    model.OrganisationStudyCentreMasterDTO.Longitude = response.Entity.Longitude;
                    model.OrganisationStudyCentreMasterDTO.Latitude = response.Entity.Latitude;
                    model.OrganisationStudyCentreMasterDTO.CampusArea = response.Entity.CampusArea;
                    List<SelectListItem> li = new List<SelectListItem>();
                    if (response.Entity.HoCoRoScFlag == "HO")
                    {
                        li.Add(new SelectListItem { Text = "Head Office", Value = "HO" });
                    }
                    else if (response.Entity.HoCoRoScFlag == "RO")
                    {
                        li.Add(new SelectListItem { Text = "Regional Office", Value = "RO" });
                    }
                    else if (response.Entity.HoCoRoScFlag == "SC")
                    {
                        li.Add(new SelectListItem { Text = "Study Centre", Value = "SC" });
                    }
                    ViewData["HoCoRoScFlag"] = new SelectList(li, "Value", "Text", response.Entity.HoCoRoScFlag);
                    ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text", response.Entity.CityID.ToString());
                    ViewBag.OrganisationMaster = new SelectList(OrganisationMaster, "Value", "Text", response.Entity.OrganisationID.ToString());
                }
                return PartialView("/Views/Organisation/OrganisationStudyCentreMaster/Edit.cshtml",model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(OrganisationStudyCentreMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.OrganisationStudyCentreMasterDTO != null)
                    {
                        model.OrganisationStudyCentreMasterDTO.ConnectionString = _connectioString;
                        model.OrganisationStudyCentreMasterDTO.ID = model.ID;
                        model.OrganisationStudyCentreMasterDTO.IDs = model.IDs;
                        model.OrganisationStudyCentreMasterDTO.CentreName = model.CentreName;
                        model.OrganisationStudyCentreMasterDTO.CityID = Convert.ToInt32(model.SelectedCityID.ToString());
                        model.OrganisationStudyCentreMasterDTO.OrganisationID = Convert.ToInt32(model.SelectedOrganisationID.ToString());
                        model.OrganisationStudyCentreMasterDTO.CentreCode = model.CentreCode;
                        model.OrganisationStudyCentreMasterDTO.CentreEstablishmentDatetime = model.CentreEstablishmentDatetime;
                        model.OrganisationStudyCentreMasterDTO.HoCoRoScFlag = model.HoCoRoScFlag;
                        model.OrganisationStudyCentreMasterDTO.HoID = model.HoID;
                        model.OrganisationStudyCentreMasterDTO.CoID = model.CoID;
                        model.OrganisationStudyCentreMasterDTO.RoID = model.RoID;
                        model.OrganisationStudyCentreMasterDTO.CentreSpecialization = model.CentreSpecialization;
                        model.OrganisationStudyCentreMasterDTO.Pincode = model.Pincode;
                        model.OrganisationStudyCentreMasterDTO.CentreAddress = model.CentreAddress;
                        model.OrganisationStudyCentreMasterDTO.EmailID = model.EmailID;
                        model.OrganisationStudyCentreMasterDTO.Url = model.Url;
                        if (model.CentreLoginNumber > 0)
                        {
                            model.OrganisationStudyCentreMasterDTO.CentreLoginNumber = model.CentreLoginNumber;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.CentreLoginNumber = 0;
                        }
                        if (string.IsNullOrEmpty(model.PlotNo))
                        {
                            model.OrganisationStudyCentreMasterDTO.PlotNo = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.PlotNo = model.PlotNo;
                        }
                        if (string.IsNullOrEmpty(model.StreetName))
                        {
                            model.OrganisationStudyCentreMasterDTO.StreetName = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.StreetName = model.StreetName;
                        }
                        if (string.IsNullOrEmpty(model.FaxNumber))
                        {
                            model.OrganisationStudyCentreMasterDTO.FaxNumber = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.FaxNumber = model.FaxNumber;
                        }
                        if (string.IsNullOrEmpty(model.PhoneNumberOffice))
                        {
                            model.OrganisationStudyCentreMasterDTO.PhoneNumberOffice = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.PhoneNumberOffice = model.PhoneNumberOffice;
                        }
                        if (string.IsNullOrEmpty(model.InstituteCode))
                        {
                            model.OrganisationStudyCentreMasterDTO.InstituteCode = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.InstituteCode = model.InstituteCode;
                        }
                        if (string.IsNullOrEmpty(model.CellPhone))
                        {
                            model.OrganisationStudyCentreMasterDTO.CellPhone = string.Empty;
                        }
                        else
                        {
                            model.OrganisationStudyCentreMasterDTO.CellPhone = model.CellPhone;
                        }
                        
                        model.OrganisationStudyCentreMasterDTO.TimeZone = model.TimeZone;
                        model.OrganisationStudyCentreMasterDTO.Longitude = model.Longitude;
                        model.OrganisationStudyCentreMasterDTO.Latitude = model.Latitude;
                        model.OrganisationStudyCentreMasterDTO.CampusArea = model.CampusArea;
                       
                        model.OrganisationStudyCentreMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<OrganisationStudyCentreMaster> response = _organisationStudyCentreMasterBA.UpdateOrganisationStudyCentreMaster(model.OrganisationStudyCentreMasterDTO);
                        model.OrganisationStudyCentreMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.OrganisationStudyCentreMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(string ID)
        {
            OrganisationStudyCentreMasterViewModel model = new OrganisationStudyCentreMasterViewModel();

            string[] Arrays = ID.Split('~');
            int IDs = Convert.ToInt32(Arrays[0]);

            IBaseEntityResponse<OrganisationStudyCentreMaster> response = null;
            try
            {
                if (IDs > 0)
                {
                    OrganisationStudyCentreMaster OrganisationStudyCentreMasterDTO = new OrganisationStudyCentreMaster();
                    OrganisationStudyCentreMasterDTO.ConnectionString = _connectioString;
                    OrganisationStudyCentreMasterDTO.ID = IDs;
                    OrganisationStudyCentreMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                    response = _organisationStudyCentreMasterBA.DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMasterDTO);
                    model.OrganisationStudyCentreMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                }
                if (response.Message.Count == 0)
                {
                    return Json(model.OrganisationStudyCentreMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        // Non-Action Methods
        #region Methods
        public IEnumerable<OrganisationStudyCentreMasterViewModel> GetOrganisationStudyCentreMaster(out int TotalRecords)
        {
            OrganisationStudyCentreMasterSearchRequest searchRequest = new OrganisationStudyCentreMasterSearchRequest();
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
            List<OrganisationStudyCentreMasterViewModel> listOrganisationStudyCentreMasterViewModel = new List<OrganisationStudyCentreMasterViewModel>();
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> baseEntityCollectionResponse = _organisationStudyCentreMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationStudyCentreMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (OrganisationStudyCentreMaster item in listOrganisationStudyCentreMaster)
                    {
                        OrganisationStudyCentreMasterViewModel generalRegionMasterViewModel = new OrganisationStudyCentreMasterViewModel();
                        generalRegionMasterViewModel.OrganisationStudyCentreMasterDTO = item;
                        listOrganisationStudyCentreMasterViewModel.Add(generalRegionMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listOrganisationStudyCentreMasterViewModel;
        }

        //protected List<OrganisationUniversityMaster> GetListOrganisationUniversityMaster(string CenterCode)
        //{
        //    OrganisationUniversityMasterSearchRequest searchRequest = new OrganisationUniversityMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.CentreCode = CenterCode;
        //    List<OrganisationUniversityMaster> listOrganisationUniversityMaster = new List<OrganisationUniversityMaster>();
        //    IBaseEntityCollectionResponse<OrganisationUniversityMaster> baseEntityCollectionResponse = _organisationUniversityMasterServiceAccess.GetBySearchList(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listOrganisationUniversityMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    return listOrganisationUniversityMaster;
        //}
        //////Non-Action method to fetch list of items
        //[HttpPost]
        //public JsonResult GetGeneralTimeZoneMasterSearchlist(string term)
        //{
        //    GeneralTimeSlotMasterSearchRequest searchRequest = new GeneralTimeSlotMasterSearchRequest();
        //    searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        //    searchRequest.SearchWord = term;
        //    List<GeneralTimeSlotMaster> listFeeSubType = new List<GeneralTimeSlotMaster>();
        //    IBaseEntityCollectionResponse<GeneralTimeSlotMaster> baseEntityCollectionResponse = _GeneralTimeSlotMasterServiceAccess.GetGeneralTimeZoneMasterSearchlist(searchRequest);
        //    if (baseEntityCollectionResponse != null)
        //    {
        //        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
        //        {
        //            listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
        //        }
        //    }
        //    var result = (from r in listFeeSubType
        //                  select new
        //                  {
        //                      TimeZoneID = r.TimeZoneID,
        //                      TimeZone = r.TimeZone,
        //                      UTCoffset = r.UTCoffset,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public ActionResult GetStudyCentreHORO()
        {
            var data = GetListStudyCentreHORO();
            var result = (from s in data select new { id = s.ID, name = s.CentreName, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion

        //  AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<OrganisationStudyCentreMasterViewModel> filteredOrganisationStudyCentreMaster;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "CentreName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreCode Like '%" + param.sSearch + "%' or HoCoRoScFlag Like '%" + param.sSearch + "%' or CentreEstablishmentDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "CentreCode";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreCode Like '%" + param.sSearch + "%' or HoCoRoScFlag Like '%" + param.sSearch + "%' or CentreEstablishmentDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "HoCoRoScFlag";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreCode Like '%" + param.sSearch + "%' or HoCoRoScFlag Like '%" + param.sSearch + "%' or CentreEstablishmentDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "CentreEstablishmentDatetime";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "CentreName Like '%" + param.sSearch + "%' or CentreCode Like '%" + param.sSearch + "%' or HoCoRoScFlag Like '%" + param.sSearch + "%' or CentreEstablishmentDatetime Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredOrganisationStudyCentreMaster = GetOrganisationStudyCentreMaster(out TotalRecords);
            var displayedPosts = filteredOrganisationStudyCentreMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in displayedPosts select new[] { c.CentreName.ToString(), c.CentreCode.ToString(), c.HoCoRoScFlag.ToString(), c.CentreEstablishmentDatetime.ToString(), Convert.ToString(c.ID) + "~" + c.CentreCode + "~" + Session["UserType"] + "~" + Session["SuperUser"] };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}