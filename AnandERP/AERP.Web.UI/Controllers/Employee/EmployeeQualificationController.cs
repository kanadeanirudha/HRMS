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
using AERP.DataProvider;

namespace AERP.Web.UI.Controllers
{
    public class EmployeeQualificationController : BaseController
    {
        IEmployeeQualificationBA _EmployeeQualificationBA = null;
        IGeneralEducationMasterBA _generalEducationMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeQualificationController()
        {
            _EmployeeQualificationBA = new EmployeeQualificationBA();
            _generalEducationMasterBA = new GeneralEducationMasterBA();

        }

        // Controller Methods
        public ActionResult Index(int EmployeeID, string EmployeeDetailsType)
        {
            ViewBag.EmployeeID = EmployeeID;
            ViewBag.EmployeeDetailsType = EmployeeDetailsType;

            return View("/Views/Employee/EmployeePersonal/QualificationIndex.cshtml");

        }


        public ActionResult EmployeeQualificationList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeQualificationViewModel model = new EmployeeQualificationViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeQualificationList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult EmployeeQualificationCreate(int EmployeeID)
        {
            EmployeeQualificationViewModel model = new EmployeeQualificationViewModel();
            model.EmployeeID = EmployeeID;

            //--------------------------------------For Education Type list---------------------------------//
            List<GeneralEducationTypeMaster> GeneralEducationTypeMasterList = GetListGeneralEducationTypeMaster();
            List<SelectListItem> GeneralEducationTypeMaster = new List<SelectListItem>();
            foreach (GeneralEducationTypeMaster item in GeneralEducationTypeMasterList)
            {
                GeneralEducationTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }
            ViewBag.GeneralEducationTypeMaster = new SelectList(GeneralEducationTypeMaster, "Value", "Text");


            //--------------------------------------For Education list---------------------------------//
            List<SelectListItem> generalEducationMaster = new List<SelectListItem>();
            ViewBag.GeneralEducationMaster = new SelectList(generalEducationMaster, "Value", "Text");


            //--------------------------------------For Board University list---------------------------------//
            //List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
            //List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
            //foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
            //{
            //    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
            //}
            //ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text");

            //--------------------------------------For Passing Division list---------------------------------//
            List<SelectListItem> EmployeeQualification_PassingDivision = new List<SelectListItem>();
            ViewBag.EmployeeQualification_PassingDivision = new SelectList(EmployeeQualification_PassingDivision, "Value", "Text");
            List<SelectListItem> li_EmployeeQualification_PassingDivision = new List<SelectListItem>();
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "AWARD", Value = "AWARD" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "DISTINCTION", Value = "DISTINCTION" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "FIRST", Value = "FIRST" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "PROMPT", Value = "PROMPT" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "SECOND", Value = "SECOND" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "THIRD", Value = "THIRD" });
            ViewData["PassingDivision"] = li_EmployeeQualification_PassingDivision;

            //List<SelectListItem> fromYear = new List<SelectListItem>();
            //ViewBag.FromYear = new SelectList(fromYear, "Value", "Text");

            //List<SelectListItem> uptoYear = new List<SelectListItem>();
            //ViewBag.UptoYear = new SelectList(uptoYear, "Value", "Text");

            //List<SelectListItem> yearOfPassing = new List<SelectListItem>();
            //ViewBag.YearOfPassing = new SelectList(yearOfPassing, "Value", "Text");


            //For Year
            int year = DateTime.Now.Year - 65;
            List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
            ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
            List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();

            li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "---Select Year---", Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            ViewData["FromYear"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text");

            List<SelectListItem> YearOfPassingAndFrom = new List<SelectListItem>();
            YearOfPassingAndFrom.Add(new SelectListItem { Text = "---Select Year---", Value = "0" });
            ViewData["UptoYear"] = new SelectList(YearOfPassingAndFrom, "Value", "Text");

            ViewData["YearOfPassing"] = new SelectList(YearOfPassingAndFrom, "Value", "Text");




            //   model.AggregatePercentage = Convert.ToDouble(0.00);
            model.FinalYearPercentage = Convert.ToDouble(String.Format("0.00", model.FinalYearPercentage));

            return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeQualificationCreate.cshtml", model);
        }

        [HttpPost]
        public ActionResult EmployeeQualificationCreate(EmployeeQualificationViewModel EmployeeQualificationViewModel)
        {
            try
            {
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EmployeeID = EmployeeQualificationViewModel.EmployeeID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationTypeID = EmployeeQualificationViewModel.EducationTypeID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationID = EmployeeQualificationViewModel.EducationID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationYear = EmployeeQualificationViewModel.EducationYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Unit = EmployeeQualificationViewModel.Unit;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.SpecailisationIn = EmployeeQualificationViewModel.SpecailisationIn;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.FromYear = EmployeeQualificationViewModel.FromYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.UptoYear = EmployeeQualificationViewModel.UptoYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.YearOfPassing = EmployeeQualificationViewModel.YearOfPassing;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.NameOfInstitution = EmployeeQualificationViewModel.NameOfInstitution;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.BoardUniversityID = EmployeeQualificationViewModel.BoardUniversityID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.PassingDivision = EmployeeQualificationViewModel.PassingDivision;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.NoOfAttempts = EmployeeQualificationViewModel.NoOfAttempts;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.AggregatePercentage = EmployeeQualificationViewModel.AggregatePercentage;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.FinalYearPercentage = EmployeeQualificationViewModel.FinalYearPercentage;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Rank = EmployeeQualificationViewModel.Rank;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Remark = EmployeeQualificationViewModel.Remark;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.CreatedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeQualificationViewModel.EmployeeQualificationDTO.ID = EmployeeQualificationViewModel.ID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeQualification> response = _EmployeeQualificationBA.InsertEmployeeQualification(EmployeeQualificationViewModel.EmployeeQualificationDTO);
                EmployeeQualificationViewModel.EmployeeQualificationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeQualificationViewModel.EmployeeQualificationDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeeQualificationViewModel);
        }

        [HttpGet]
        public ActionResult EmployeeQualificationEdit(int ID, string Mode)
        {
            //--------------------------------------For Education Type list---------------------------------//
            List<GeneralEducationTypeMaster> GeneralEducationTypeMasterList = GetListGeneralEducationTypeMaster();
            List<SelectListItem> GeneralEducationTypeMaster = new List<SelectListItem>();
            foreach (GeneralEducationTypeMaster item in GeneralEducationTypeMasterList)
            {
                GeneralEducationTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
            }

            //--------------------------------------For Passing Division list---------------------------------//
            List<SelectListItem> EmployeeQualification_PassingDivision = new List<SelectListItem>();

            List<SelectListItem> li_EmployeeQualification_PassingDivision = new List<SelectListItem>();
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = Resources.ddlHeaders_Select, });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "AWARD", Value = "AWARD" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "DISTINCTION", Value = "DISTINCTION" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "FIRST", Value = "FIRST" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "PROMPT", Value = "PROMPT" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "SECOND", Value = "SECOND" });
            li_EmployeeQualification_PassingDivision.Add(new SelectListItem { Text = "THIRD", Value = "THIRD" });
            ViewData["PassingDivision"] = li_EmployeeQualification_PassingDivision;


            EmployeeQualificationViewModel model = new EmployeeQualificationViewModel();
            EmployeeQualification EmployeeQualificationDTO = new EmployeeQualification();
            model.EmployeeQualificationDTO.ConnectionString = _connectioString;
            model.EmployeeQualificationDTO.ID = ID;
            IBaseEntityResponse<EmployeeQualification> response = _EmployeeQualificationBA.SelectByID(model.EmployeeQualificationDTO);
            if (response.Entity != null)
            {
                model.QualificationID = response.Entity.ID;
                model.EmployeeID = response.Entity.EmployeeID;
                model.FromYear = response.Entity.FromYear;
                model.UptoYear = response.Entity.UptoYear;
                model.YearOfPassing = response.Entity.YearOfPassing;
                model.PassingDivision = response.Entity.PassingDivision;
                model.NoOfAttempts = response.Entity.NoOfAttempts;
                model.NameOfInstitution = response.Entity.NameOfInstitution;
                model.EducationTypeID = response.Entity.EducationTypeID;
                model.EducationID = response.Entity.EducationID;
                model.SelectedEducationID = response.Entity.EducationID + "~" + response.Entity.EducationYear + "~" + "";
                model.EducationYear = response.Entity.EducationYear;
                model.Unit = response.Entity.Unit;
                model.BoardUniversityID = response.Entity.BoardUniversityID;
                model.AggregatePercentage = response.Entity.AggregatePercentage;
                model.FinalYearPercentage = response.Entity.FinalYearPercentage;
                model.Rank = response.Entity.Rank;
                model.Remark = response.Entity.Remark;
                model.SpecailisationIn = response.Entity.SpecailisationIn;

                string EducationTypeID = response.Entity.EducationTypeID.ToString();
                List<GeneralEducationMaster> generalEducationMasterList = GetListGeneralEducationMaster(EducationTypeID);
                List<SelectListItem> generalEducationMaster = new List<SelectListItem>();
                foreach (GeneralEducationMaster item in generalEducationMasterList)
                {
                    generalEducationMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() + "~" + item.NumberOfYears + "~" });
                }

                //--------------------------------------For Board University list---------------------------------//
                //List<GeneralBoardUniversityMaster> GeneralBoardUniversityMasterList = GetListGeneralBoardUniversityMaster();
                //List<SelectListItem> GeneralBoardUniversityMaster = new List<SelectListItem>();
                //foreach (GeneralBoardUniversityMaster item in GeneralBoardUniversityMasterList)
                //{
                //    GeneralBoardUniversityMaster.Add(new SelectListItem { Text = item.UniversityName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralBoardUniversityMaster = new SelectList(GeneralBoardUniversityMaster, "Value", "Text", response.Entity.BoardUniversityID.ToString());


                //--------------------------------------For Education list---------------------------------//
                List<SelectListItem> fromYear = new List<SelectListItem>();
                ViewBag.FromYear = new SelectList(fromYear, "Value", "Text", response.Entity.FromYear);

                List<SelectListItem> uptoYear = new List<SelectListItem>();
                ViewBag.UptoYear = new SelectList(uptoYear, "Value", "Text", response.Entity.UptoYear);

                List<SelectListItem> yearOfPassing = new List<SelectListItem>();
                ViewBag.YearOfPassing = new SelectList(yearOfPassing, "Value", "Text", response.Entity.YearOfPassing);

                //For Year
                int year = DateTime.Now.Year - 65;
                List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
                ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
                List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();


                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "---Select Year---", Value = "0" });
                for (int i = DateTime.Now.Year; year <= i; i--)
                {
                    li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewData["FromYear"] = new SelectList(li_Student_Qualification_General_YearOfPassing, "Value", "Text", model.FromYear);



                List<SelectListItem> YearOfPassingAndFrom = new List<SelectListItem>();
                YearOfPassingAndFrom.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
                for (int i = DateTime.Now.Year; Convert.ToInt32(model.FromYear) <= i; i--)
                {
                    YearOfPassingAndFrom.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
                }
                ViewBag.YearOfPassingAndFrom = new SelectList(YearOfPassingAndFrom, "Value", "Text");

                ViewData["YearOfPassing"] = new SelectList(YearOfPassingAndFrom, "Value", "Text", model.YearOfPassing);
                ViewData["UptoYear"] = new SelectList(YearOfPassingAndFrom, "Value", "Text", model.UptoYear);

                ViewBag.GeneralEducationTypeMaster = new SelectList(GeneralEducationTypeMaster, "Value", "Text", response.Entity.EducationTypeID.ToString());
                ViewBag.GeneralEducationMaster = new SelectList(generalEducationMaster, "Value", "Text", model.SelectedEducationID);


                ViewData["PassingDivision"] = new SelectList(li_EmployeeQualification_PassingDivision, "Text", "Value", response.Entity.PassingDivision);
            }
            return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeQualificationEdit.cshtml", model);
        }

        [HttpPost]
        public ActionResult EmployeeQualificationEdit(EmployeeQualificationViewModel EmployeeQualificationViewModel)
        {
            try
            {
                EmployeeQualificationViewModel.EmployeeQualificationDTO.ID = EmployeeQualificationViewModel.ID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EmployeeID = EmployeeQualificationViewModel.EmployeeID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationTypeID = EmployeeQualificationViewModel.EducationTypeID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationID = EmployeeQualificationViewModel.EducationID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.EducationYear = EmployeeQualificationViewModel.EducationYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Unit = EmployeeQualificationViewModel.Unit;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.SpecailisationIn = EmployeeQualificationViewModel.SpecailisationIn;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.FromYear = EmployeeQualificationViewModel.FromYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.UptoYear = EmployeeQualificationViewModel.UptoYear;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.YearOfPassing = EmployeeQualificationViewModel.YearOfPassing;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.NameOfInstitution = EmployeeQualificationViewModel.NameOfInstitution;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.BoardUniversityID = EmployeeQualificationViewModel.BoardUniversityID;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.PassingDivision = EmployeeQualificationViewModel.PassingDivision;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.NoOfAttempts = EmployeeQualificationViewModel.NoOfAttempts;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.AggregatePercentage = EmployeeQualificationViewModel.AggregatePercentage;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.FinalYearPercentage = EmployeeQualificationViewModel.FinalYearPercentage;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Rank = EmployeeQualificationViewModel.Rank;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.Remark = EmployeeQualificationViewModel.Remark;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.IsActive = true;
                EmployeeQualificationViewModel.EmployeeQualificationDTO.ModifiedBy = Convert.ToInt32(Session["UserId"]);
                EmployeeQualificationViewModel.EmployeeQualificationDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<EmployeeQualification> response = _EmployeeQualificationBA.UpdateEmployeeQualification(EmployeeQualificationViewModel.EmployeeQualificationDTO);
                EmployeeQualificationViewModel.EmployeeQualificationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                return Json(EmployeeQualificationViewModel.EmployeeQualificationDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
            //return Redirect("/EmployeeInformation/PersonalInformationHome/" + EmployeeQualificationViewModel);
        }


        public ActionResult EmployeePersonalList(string EmployeeID, string actionMode)
        {
            try
            {
                EmployeeQualificationViewModel model = new EmployeeQualificationViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Employee/EmployeeQualification/PersonalList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        // Non-Action Method
        #region Methods

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetEducationNameByEducationTypeID(string SelectedEducationTypeID)
        {
            if (String.IsNullOrEmpty(SelectedEducationTypeID))
            {
                throw new ArgumentNullException("SelectedEducationID");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedEducationTypeID, out id);
            var Education = GetListGeneralEducationMaster(SelectedEducationTypeID);
            var result = (from s in Education select new { id = s.ID + "~" + s.NumberOfYears + "~" + s.Unit, name = s.Description, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetUptoYearList(string SelectedFromYear)
        {
            if (String.IsNullOrEmpty(SelectedFromYear))
            {
                throw new ArgumentNullException("SelectedUptoYear");
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedFromYear, out id);
            var UptoYear = GetListUptoYear(SelectedFromYear);
            var result = (from s in UptoYear select new { id = s.Value, name = s.Text, }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected List<SelectListItem> GetListUptoYear(string FromYear)
        {
            //For Year
            int year = Convert.ToInt32(FromYear);
            List<SelectListItem> Student_Qualification_General_YearOfPassing = new List<SelectListItem>();
            ViewBag.Student_Qualification_General_YearOfPassing = new SelectList(Student_Qualification_General_YearOfPassing, "Value", "Text");
            List<SelectListItem> li_Student_Qualification_General_YearOfPassing = new List<SelectListItem>();

            li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = "-- Select Year --", Value = "0" });
            for (int i = DateTime.Now.Year; year <= i; i--)
            {
                li_Student_Qualification_General_YearOfPassing.Add(new SelectListItem { Text = Convert.ToString(i), Value = Convert.ToString(i) });
            }
            return li_Student_Qualification_General_YearOfPassing;
        }

        protected List<GeneralEducationMaster> GetListGeneralEducationMaster(string EducationTypeID)
        {
            GeneralEducationMasterSearchRequest searchRequest = new GeneralEducationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            int SelectedEducationTypeID = 0;
            bool isValid = Int32.TryParse(EducationTypeID, out SelectedEducationTypeID);
            searchRequest.EducationTypeID = Convert.ToInt32(EducationTypeID);
            //searchRequest.SearchType = 1;
            List<GeneralEducationMaster> listGeneralEducationMaster = new List<GeneralEducationMaster>();
            IBaseEntityCollectionResponse<GeneralEducationMaster> baseEntityCollectionResponse = _generalEducationMasterBA.GetByEducationTypeID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralEducationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralEducationMaster;
        }

        public IEnumerable<EmployeeQualificationViewModel> GetEmployeeQualification(int EmployeeID, out int TotalRecords)
        {
            EmployeeQualificationSearchRequest searchRequest = new EmployeeQualificationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.EmployeeID = EmployeeID;
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
            List<EmployeeQualificationViewModel> listEmployeeQualificationViewModel = new List<EmployeeQualificationViewModel>();
            List<EmployeeQualification> listEmployeeQualification = new List<EmployeeQualification>();
            IBaseEntityCollectionResponse<EmployeeQualification> baseEntityCollectionResponse = _EmployeeQualificationBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeQualification = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeQualification item in listEmployeeQualification)
                    {
                        EmployeeQualificationViewModel EmployeeQualificationViewModel = new EmployeeQualificationViewModel();
                        EmployeeQualificationViewModel.EmployeeQualificationDTO = item;
                        listEmployeeQualificationViewModel.Add(EmployeeQualificationViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeQualificationViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandlerEmployeeQualification(JQueryDataTableParamModel param, int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeQualificationViewModel> filteredEmployeeQualification;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AddressType Like '%" + param.sSearch + "%' or CityName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ID";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "AddressType Like '%" + param.sSearch + "%' or CityName Like '%" + param.sSearch + "%'";      //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeQualification = GetEmployeeQualification(EmployeeID, out TotalRecords);
            var records = filteredEmployeeQualification.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.EducationType), Convert.ToString(c.EducationName), Convert.ToString(c.SpecailisationIn), Convert.ToString(c.NameOfInstitution), Convert.ToString(c.UniversityName), Convert.ToString(c.ID), Convert.ToString(c.EmployeeID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}
