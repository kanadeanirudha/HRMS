using AMS.Base.DTO;
using AMS.DTO;
using AMS.ServiceAccess;
using AMS.ExceptionManager;
using AMS.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AMS.Common;
using AMS.DataProvider;
namespace AMS.Web.UI.Controllers
{
    public class EmployeePaperPresentController : BaseController
    {
        IEmployeePaperPresentServiceAccess _employeePaperPresentServiceAcess = null;
        IGeneralLevelMasterServiceAccess _generalLevelMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeePaperPresentController()
        {
            _employeePaperPresentServiceAcess = new EmployeePaperPresentServiceAccess();
            _generalLevelMasterServiceAccess = new GeneralLevelMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods

        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("/Views/Employee/EmployeePaperPresent/Index.cshtml");
        }

        public ActionResult List(int EmployeeID, string actionMode)
        {
            try
            {
                EmployeePaperPresentViewModel model = new EmployeePaperPresentViewModel();
                model.EmployeeID = EmployeeID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return View("/Views/Employee/EmployeePaperPresent/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Create(string EmployeeID)
        {
            //For MaritalStatus
            List<SelectListItem> EmployeePaperPresent_PublishMedium = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_PublishMedium, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_PublishMedium = new List<SelectListItem>();
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectPublishMedium , });
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.DisplayName_Conference, Value = "Conference" });
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.DisplayName_Journal, Value = "Journal" });
            ViewData["PublishMedium"] = li_EmployeePaperPresent_PublishMedium;

            //For MaritalStatus
            List<SelectListItem> EmployeePaperPresent_PaperType = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_PaperType, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_PaperType = new List<SelectListItem>();
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectPaperType, });
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.DisplayName_Technical, Value = "Technical" });
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.DisplayName_NonTechnical, Value = "Non-Technical" });
            ViewData["PaperType"] = li_EmployeePaperPresent_PaperType;

            //For Self Group
            List<SelectListItem> EmployeePaperPresent_SelfGroupPresenter = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_SelfGroupPresenter, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_SelfGroupPresenter = new List<SelectListItem>();
            li_EmployeePaperPresent_SelfGroupPresenter.Add(new SelectListItem { Text = Resources.DisplayName_Self, Value = "true" });
            li_EmployeePaperPresent_SelfGroupPresenter.Add(new SelectListItem { Text = Resources.DisplayName_Group, Value = "false" });
            ViewData["SelfGroupPresenter"] = li_EmployeePaperPresent_SelfGroupPresenter;

            //--------------------------------------For General Level Master list---------------------------------//
            List<GeneralLevelMaster> GeneralLevelMasterList = GetListGeneralLevelMaster();
            List<SelectListItem> GeneralLevelMaster = new List<SelectListItem>();
            foreach (GeneralLevelMaster item in GeneralLevelMasterList)
            {
                GeneralLevelMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            ViewBag.GeneralLevelMasterForPprPresent = new SelectList(GeneralLevelMaster, "Value", "Text");

            //For Year
            int year = DateTime.Now.Year - 65;
            List<SelectListItem> EmployeePaperPresent_EmployeeYear = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_EmployeeYear = new SelectList(EmployeePaperPresent_EmployeeYear, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_EmployeeYear = new List<SelectListItem>();

            li_EmployeePaperPresent_EmployeeYear.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectYear, Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_EmployeePaperPresent_EmployeeYear.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            ViewData["EmployeeYear"] = new SelectList(li_EmployeePaperPresent_EmployeeYear, "Value", "Text");
            ViewData["FromYear"] = new SelectList(li_EmployeePaperPresent_EmployeeYear, "Value", "Text");
            ViewData["UptoYear"] = new SelectList(li_EmployeePaperPresent_EmployeeYear, "Value", "Text");

            //For EmployeeParticipationRole
            List<SelectListItem> EmployeePaperPresenter_EmployeeParticipationRole = new List<SelectListItem>();
            ViewBag.EmployeePaperPresenter_EmployeeParticipationRole = new SelectList(EmployeePaperPresenter_EmployeeParticipationRole, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresenter_EmployeeParticipationRole = new List<SelectListItem>();
            //  li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = "-- Select Participation Role -- ", });
            li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = Resources.DisplayName_MainAuthor, Value = "Main Author" });
            li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = Resources.DisplayName_CoAuthor, Value = "Co-Author" });
            ViewData["EmployeeParticipationRole"] = li_EmployeePaperPresenter_EmployeeParticipationRole;


            EmployeePaperPresentViewModel model = new EmployeePaperPresentViewModel();
            model.EmployeeID = Convert.ToInt32(EmployeeID);

            return View("/Views/Employee/EmployeePaperPresent/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(EmployeePaperPresentViewModel EmployeePaperPresentViewModel)
        {
            try
            {
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeID = EmployeePaperPresentViewModel.EmployeeID;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.PaperTopic = EmployeePaperPresentViewModel.PaperTopic;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.JournalName = EmployeePaperPresentViewModel.JournalName;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.SelfGroupPresenter = EmployeePaperPresentViewModel.SelfGroupPresenter;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.JournalVolumeNumber = EmployeePaperPresentViewModel.JournalVolumeNumber;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.JournalPageNumber = EmployeePaperPresentViewModel.JournalPageNumber;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeYear = EmployeePaperPresentViewModel.EmployeeYear;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.PaperType = EmployeePaperPresentViewModel.PaperType;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.GeneralLevelMasterID = EmployeePaperPresentViewModel.GeneralLevelMasterIDForPprPresent;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeBookReview = EmployeePaperPresentViewModel.EmployeeBookReview;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeArticleReview = EmployeePaperPresentViewModel.EmployeeArticleReview;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.PublishMedium = EmployeePaperPresentViewModel.PublishMedium;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeConferenceDateFrom = EmployeePaperPresentViewModel.EmployeeConferenceDateFrom;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeConferenceDateTo = EmployeePaperPresentViewModel.EmployeeConferenceDateTo;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ConferenceName = EmployeePaperPresentViewModel.ConferenceName;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeConferenceVenue = EmployeePaperPresentViewModel.EmployeeConferenceVenue;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.PublishDate = EmployeePaperPresentViewModel.PublishDate;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeProceedingPageNumber = EmployeePaperPresentViewModel.EmployeeProceedingPageNumber;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeConferenceProceeding = EmployeePaperPresentViewModel.EmployeeConferenceProceeding;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeProceedingPageNumber = EmployeePaperPresentViewModel.EmployeeProceedingPageNumber;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeePaperPresenterID = EmployeePaperPresentViewModel.EmployeePaperPresenterID;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeParticipationRole = EmployeePaperPresentViewModel.EmployeeParticipationRole;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.IsActive = EmployeePaperPresentViewModel.IsActive;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ID = EmployeePaperPresentViewModel.ID;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeePaperPresent> response = _employeePaperPresentServiceAcess.InsertEmployeePaperPresent(EmployeePaperPresentViewModel.EmployeePaperPresentDTO);
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                return Json(EmployeePaperPresentViewModel.EmployeePaperPresentDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeePaperPresentViewModel);
        }
        #endregion


        [HttpGet]
        public ActionResult Edit(string ID, string Mode)
        {


            //--------------------------------------For General Level Master list---------------------------------//
            List<GeneralLevelMaster> GeneralLevelMasterList = GetListGeneralLevelMaster();
            List<SelectListItem> GeneralLevelMaster = new List<SelectListItem>();
            foreach (GeneralLevelMaster item in GeneralLevelMasterList)
            {
                GeneralLevelMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }

            //For MaritalStatus
            List<SelectListItem> EmployeePaperPresent_PublishMedium = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_PublishMedium, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_PublishMedium = new List<SelectListItem>();
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectPublishMedium, });
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.DisplayName_Conference, Value = "Conference" });
            li_EmployeePaperPresent_PublishMedium.Add(new SelectListItem { Text = Resources.DisplayName_Journal, Value = "Journal" });
            ViewData["PublishMedium"] = li_EmployeePaperPresent_PublishMedium;

            //For MaritalStatus
            List<SelectListItem> EmployeePaperPresent_PaperType = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_PaperType, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_PaperType = new List<SelectListItem>();
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectPaperType, });
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.DisplayName_Technical, Value = "Technical" });
            li_EmployeePaperPresent_PaperType.Add(new SelectListItem { Text = Resources.DisplayName_NonTechnical, Value = "Non-Technical" });
            ViewData["PaperType"] = li_EmployeePaperPresent_PaperType;
            //For Self Group
            List<SelectListItem> EmployeePaperPresent_SelfGroupPresenter = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_PublishMedium = new SelectList(EmployeePaperPresent_SelfGroupPresenter, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_SelfGroupPresenter = new List<SelectListItem>();
            li_EmployeePaperPresent_SelfGroupPresenter.Add(new SelectListItem { Text = Resources.DisplayName_Self, Value = "true" });
            li_EmployeePaperPresent_SelfGroupPresenter.Add(new SelectListItem { Text = Resources.DisplayName_Group, Value = "false" });
            ViewData["SelfGroupPresenter"] = li_EmployeePaperPresent_SelfGroupPresenter;

            //For EmployeeParticipationRole
            List<SelectListItem> EmployeePaperPresenter_EmployeeParticipationRole = new List<SelectListItem>();
         //   ViewBag.EmployeePaperPresenter_EmployeeParticipationRole = new SelectList(EmployeePaperPresenter_EmployeeParticipationRole, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresenter_EmployeeParticipationRole = new List<SelectListItem>();
           // li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = "-- Select Participation Role -- ", Value = "" });
            li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = Resources.DisplayName_MainAuthor, Value = "Main Author" });
            li_EmployeePaperPresenter_EmployeeParticipationRole.Add(new SelectListItem { Text = Resources.DisplayName_CoAuthor, Value = "Co-Author" });
            //  ViewData["EmployeeParticipationRole"] = li_EmployeePaperPresenter_EmployeeParticipationRole;



            //For Year
            int year = DateTime.Now.Year - 65;
            List<SelectListItem> EmployeePaperPresent_EmployeeYear = new List<SelectListItem>();
            ViewBag.EmployeePaperPresent_EmployeeYear = new SelectList(EmployeePaperPresent_EmployeeYear, "Value", "Text");
            List<SelectListItem> li_EmployeePaperPresent_EmployeeYear = new List<SelectListItem>();

            li_EmployeePaperPresent_EmployeeYear.Add(new SelectListItem { Text = Resources.ddlHeaders_SelectYear, Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_EmployeePaperPresent_EmployeeYear.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            ViewData["EmployeeYear"] = new SelectList(li_EmployeePaperPresent_EmployeeYear, "Value", "Text");
          

            string[] splitID = ID.Split('~');

            EmployeePaperPresentViewModel model = new EmployeePaperPresentViewModel();
            EmployeePaperPresent EmployeePaperPresentDTO = new EmployeePaperPresent();
            model.EmployeePaperPresentDTO.ConnectionString = _connectioString;
            model.EmployeePaperPresentDTO.ID = Convert.ToInt32(splitID[0]);
            model.EmployeePaperPresentDTO.EmployeeID = Convert.ToInt32(splitID[1]);
            model.EmployeePaperPresentDTO.EmployeePaperPresenterID = Convert.ToInt32(splitID[2]);
            IBaseEntityResponse<EmployeePaperPresent> response = _employeePaperPresentServiceAcess.SelectByID(model.EmployeePaperPresentDTO);
            if (response.Entity != null)
            {
                model.ID = Convert.ToInt32(splitID[0]);
                ViewBag.ID = Convert.ToInt32(splitID[0]);
                model.EmployeeID = response.Entity.EmployeeID;
                model.PaperTopic = response.Entity.PaperTopic;
                model.JournalName = response.Entity.JournalName;
                model.JournalVolumeNumber = response.Entity.JournalVolumeNumber;
                model.JournalPageNumber = response.Entity.JournalPageNumber;
                model.EmployeeYear = response.Entity.EmployeeYear;
                model.PaperType = response.Entity.PaperType;
                model.GeneralLevelMasterIDForPprPresent = response.Entity.GeneralLevelMasterID;
                model.EmployeeBookReview = response.Entity.EmployeeBookReview;
                model.EmployeeArticleReview = response.Entity.EmployeeArticleReview;
                model.SelfGroupPresenter = response.Entity.SelfGroupPresenter;
                //model.EmployeeConferenceDateFrom = response.Entity.EmployeeConferenceDateFrom;
                model.EmployeeConferenceDateFrom = Convert.ToDateTime(response.Entity.EmployeeConferenceDateFrom).ToString("d MMM YYYY");
                //model.EmployeeConferenceDateTo = response.Entity.EmployeeConferenceDateTo;
                model.EmployeeConferenceDateTo = Convert.ToDateTime(response.Entity.EmployeeConferenceDateTo).ToString("d MMM YYYY");
                model.ConferenceName = response.Entity.ConferenceName;
                model.EmployeeConferenceVenue = response.Entity.EmployeeConferenceVenue;
                
                model.PublishDate = Convert.ToDateTime(response.Entity.PublishDate).ToString("d MMM YYYY");
                
                model.EmployeeProceedingPageNumber = response.Entity.EmployeeProceedingPageNumber;
                model.EmployeeConferenceProceeding = response.Entity.EmployeeConferenceProceeding;
                model.EmployeePaperPresenterID = response.Entity.EmployeePaperPresenterID;
                model.EmployeeParticipationRole = response.Entity.EmployeeParticipationRole;
                model.IsActive = response.Entity.IsActive;

            }
            ViewData["EmployeeYear"] = new SelectList(li_EmployeePaperPresent_EmployeeYear, "Value", "Text", model.EmployeeYear);
            ViewData["SelfGroupPresenter"] = new SelectList(li_EmployeePaperPresent_SelfGroupPresenter, "Value", "Text", model.SelfGroupPresenter);
            ViewBag.GeneralLevelMasterForPprPresent = new SelectList(GeneralLevelMaster, "Value", "Text", response.Entity.GeneralLevelMasterID.ToString());
            ViewData["PublishMedium"] = new SelectList(li_EmployeePaperPresent_PublishMedium, "Value", "Text", response.Entity.PublishMedium);
            ViewData["PaperType"] = new SelectList(li_EmployeePaperPresent_PaperType, "Text", "Value", response.Entity.PaperType);
            ViewData["EmployeeParticipationRole"] = new SelectList(li_EmployeePaperPresenter_EmployeeParticipationRole, "Value", "Text", response.Entity.EmployeeParticipationRole);

            return PartialView("~/Views/Employee/EmployeePaperPresent/Edit.cshtml", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeePaperPresentViewModel EmployeePaperPresentViewModel)
        {
            try
            {
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ID = EmployeePaperPresentViewModel.ID;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.EmployeeParticipationRole = EmployeePaperPresentViewModel.EmployeeParticipationRole;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.IsActive = EmployeePaperPresentViewModel.IsActive;
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeePaperPresent> response = _employeePaperPresentServiceAcess.InsertEmployeePaperPresent(EmployeePaperPresentViewModel.EmployeePaperPresentDTO);
                EmployeePaperPresentViewModel.EmployeePaperPresentDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeePaperPresentViewModel.EmployeePaperPresentDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeePaperPresentViewModel);
        }


        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeePaperPresentViewModel> GetEmployeePaperPresent(string EmployeeID, out int TotalRecords)
        {
            EmployeePaperPresentSearchRequest searchRequest = new EmployeePaperPresentSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = Convert.ToInt32(EmployeeID);
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
            List<EmployeePaperPresentViewModel> listEmployeePaperPresentViewModel = new List<EmployeePaperPresentViewModel>();
            List<EmployeePaperPresent> listEmployeePaperPresent = new List<EmployeePaperPresent>();
            IBaseEntityCollectionResponse<EmployeePaperPresent> baseEntityCollectionResponse = _employeePaperPresentServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeePaperPresent = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeePaperPresent item in listEmployeePaperPresent)
                    {
                        EmployeePaperPresentViewModel EmployeePaperPresentViewModel = new EmployeePaperPresentViewModel();
                        EmployeePaperPresentViewModel.EmployeePaperPresentDTO = item;
                        listEmployeePaperPresentViewModel.Add(EmployeePaperPresentViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeePaperPresentViewModel;
        }

        protected List<GeneralLevelMaster> GetListGeneralLevelMaster()
        {
            GeneralLevelMasterSearchRequest searchRequest = new GeneralLevelMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralLevelMaster> listGeneralLevelMaster = new List<GeneralLevelMaster>();
            IBaseEntityCollectionResponse<GeneralLevelMaster> baseEntityCollectionResponse = _generalLevelMasterServiceAccess.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralLevelMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralLevelMaster;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(string EmployeeID, JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeePaperPresentViewModel> filteredCountryMaster;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "PaperTopic";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PaperTopic Like '%" + param.sSearch + "%' or JournalName Like '%" + param.sSearch + "%' or GeneralLevel Like '%" + param.sSearch + "%' or GeneralLevelMasterID Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "JournalName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PaperTopic Like '%" + param.sSearch + "%' or JournalName Like '%" + param.sSearch + "%' or GeneralLevel Like '%" + param.sSearch + "%' or GeneralLevelMasterID Like '%" + param.sSearch + "%' ";      //this "if" block is added for search functionality
                    }
                    break;
                case 2:
                    _sortBy = "GeneralLevel";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PaperTopic Like '%" + param.sSearch + "%' or JournalName Like '%" + param.sSearch + "%' or GeneralLevel Like '%" + param.sSearch + "%' or GeneralLevelMasterID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
                case 3:
                    _sortBy = "GeneralLevelMasterID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "PaperTopic Like '%" + param.sSearch + "%' or JournalName Like '%" + param.sSearch + "%' or GeneralLevel Like '%" + param.sSearch + "%' or GeneralLevelMasterID Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCountryMaster = GetEmployeePaperPresent(EmployeeID, out TotalRecords);
            var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.PaperTopic), Convert.ToString(c.JournalName), Convert.ToString(c.GeneralLevel), Convert.ToString(c.IsActive), Convert.ToString(c.ID + "~" + c.EmployeeID + "~" + c.EmployeePaperPresenterID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }


        #endregion
    }
}
