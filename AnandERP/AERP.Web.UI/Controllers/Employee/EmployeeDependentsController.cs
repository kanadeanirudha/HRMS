using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.Business.BusinessAction;
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
    public class EmployeeDependentsController : BaseController
    {
        IEmployeeDependentsBA _employeeDependentsBA = null;
        IGeneralRelationshipTypeMasterBA _generalRelationshipTypeMasterBA=null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeDependentsController()
        {
            _employeeDependentsBA = new EmployeeDependentsBA();
            _generalRelationshipTypeMasterBA = new GeneralRelationshipTypeMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(int ID)
        {
            ViewBag.EmployeeID = ID;
            return View("~/Views/Employee/EmployeeDependents/Index.cshtml");
        }

        public ActionResult List(string actionMode, int EmployeeID)
        {
            try
            {
                EmployeeDependentsViewModel model = new EmployeeDependentsViewModel();
                model.EmployeeID = Convert.ToInt32(EmployeeID);
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeFamilyList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(int EmployeeID)
        {
            try
            {
                EmployeeDependentsViewModel model = new EmployeeDependentsViewModel();
                model.EmployeeID = EmployeeID;

                //--------------------------------------For Title---------------------------------//
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }
                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");


                ////--------------------------------------For Relationship---------------------------------//
                List<GeneralRelationshipTypeMaster> GeneralRelationshipTypeMasterList = GetListGeneralRelationshipTypeMaster();
                List<SelectListItem> GeneralRelationshipTypeMaster = new List<SelectListItem>();
                foreach (GeneralRelationshipTypeMaster item in GeneralRelationshipTypeMasterList)
                {
                    GeneralRelationshipTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralRelationshipTypeMaster = new SelectList(GeneralRelationshipTypeMaster, "Value", "Text");


                ////--------------------------------------For Mothertounge---------------------------------//
                //List<GeneralLanguageMaster> GeneralLanguageMasterList = GetListGeneralLanguageMaster();
                //List<SelectListItem> GeneralLanguageMaster = new List<SelectListItem>();
                //foreach (GeneralLanguageMaster item in GeneralLanguageMasterList)
                //{
                //    GeneralLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralLanguageMaster = new SelectList(GeneralLanguageMaster, "Value", "Text");


                //--------------------------------------For Nationality---------------------------------//
                List<GeneralNationalityMaster> listGeneralNationalityMaster = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in listGeneralNationalityMaster)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");

                ////--------------------------------------For Religion---------------------------------//
                //List<GeneralReligionMaster> listGeneralReligionMaster = GetListGeneralReligionMaster();
                //List<SelectListItem> GeneralReligionMaster = new List<SelectListItem>();
                //foreach (GeneralReligionMaster item in listGeneralReligionMaster)
                //{
                //    GeneralReligionMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralReligionMaster = new SelectList(GeneralReligionMaster, "Value", "Text");

                ////--------------------------------------For Category---------------------------------//
                //List<GeneralCategoryMaster> listGeneralCategoryMaster = GetListGeneralCategoryMaster();
                //List<SelectListItem> GeneralCategoryMaster = new List<SelectListItem>();
                //foreach (GeneralCategoryMaster item in listGeneralCategoryMaster)
                //{
                //    GeneralCategoryMaster.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralCategoryMaster = new SelectList(GeneralCategoryMaster, "Value", "Text");

                ////--------------------------------------For Cast---------------------------------//

                //List<GeneralCasteMaster> listGeneralCasteMaster = GetListGeneralCasteMaster(0);
                //List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                //foreach (GeneralCasteMaster item in listGeneralCasteMaster)
                //{
                //    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                //}
                //ViewBag.GeneralCasteMaster = new SelectList(GeneralCasteMaster, "Value", "Text");



                //--------------------------------------For Country---------------------------------//
                List<GeneralCountryMaster> genCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> genCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in genCountryMasterList)
                {
                    genCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }
                ViewBag.GeneralCountryList = new SelectList(genCountryMaster, "Value", "Text");
                //--------------------------------------For Region---------------------------------//


                //int CountryId = 0;
                //List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(CountryId));

                // generalRegionMaster.Add(new SelectListItem { Text = "-- Select Region--", Value = "" });
                // generalRegionMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //foreach (GeneralRegionMaster item in generalRegionMasterList)
                //{
                //    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName, Value = item.ID.ToString() });
                //}
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");

                //--------------------------------------For City---------------------------------//

                //    int CityID = 0;
                //    List<GeneralCityMaster> listGeneralCityMaster = GetListGeneralCityMaster(Convert.ToString(CityID));

                ////    GeneralCityMaster.Add(new SelectListItem { Text = "Other", Value = "Other" });
                //    foreach (GeneralCityMaster item in listGeneralCityMaster)
                //    {
                //        GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //    }
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
                ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text");


                //   return PartialView("/Views/Employee/EmployeeDependents/Create.cshtml", model);
                return PartialView("~/Views/Employee/EmployeePersonalDetails/EmployeeFamilyCreate.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpPost]
        public ActionResult Create(EmployeeDependentsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeDependentsDTO != null)
                    {
                        model.EmployeeDependentsDTO.ConnectionString = _connectioString;
                        model.EmployeeDependentsDTO.ID = model.ID;
                        model.EmployeeDependentsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeDependentsDTO.SequenceNumber = model.SequenceNumber;
                        model.EmployeeDependentsDTO.NameTitle = model.NameTitle; 
                        model.EmployeeDependentsDTO.DependentName = model.DependentName;
                        model.EmployeeDependentsDTO.Address1 = model.Address1;
                        model.EmployeeDependentsDTO.Address2 = model.Address2;
                        model.EmployeeDependentsDTO.AdharCardNumber = model.AdharCardNumber;
                        model.EmployeeDependentsDTO.CountryID = model.CountryID;
                        model.EmployeeDependentsDTO.RegionID = model.RegionID;
                        model.EmployeeDependentsDTO.CityID = model.CityID;
                        model.EmployeeDependentsDTO.PhoneNumber = model.PhoneNumber;
                        model.EmployeeDependentsDTO.MobileNumber = model.MobileNumber;
                        model.EmployeeDependentsDTO.EmployeeDependentQualification = model.EmployeeDependentQualification;
                        model.EmployeeDependentsDTO.EmployeeDependentDesignation = model.EmployeeDependentDesignation;
                        model.EmployeeDependentsDTO.GotAnyMedal = model.GotAnyMedal;
                        model.EmployeeDependentsDTO.MedalReceivedDate = model.MedalReceivedDate;
                        model.EmployeeDependentsDTO.MedalDescription = model.MedalDescription;
                        model.EmployeeDependentsDTO.IsScholarshipReceived = model.IsScholarshipReceived;
                        model.EmployeeDependentsDTO.ScholarshipAmount = model.ScholarshipAmount;
                        model.EmployeeDependentsDTO.ScholarshipStartDate = model.ScholarshipStartDate;
                        model.EmployeeDependentsDTO.ScholarshipUptoDate = model.ScholarshipUptoDate;
                        model.EmployeeDependentsDTO.ScholarshipDescription = model.ScholarshipDescription;
                        model.EmployeeDependentsDTO.Hobbies = model.Hobbies;
                        model.EmployeeDependentsDTO.CurriculumActivity = model.CurriculumActivity;
                        model.EmployeeDependentsDTO.DateOfBirth = model.DateOfBirth;
                        model.EmployeeDependentsDTO.PlaceOfBirth = model.PlaceOfBirth;
                        model.EmployeeDependentsDTO.GeneralRelationshipTypeMasterID = model.GeneralRelationshipTypeMasterID;
                        model.EmployeeDependentsDTO.MotherTongueID = model.MotherTongueID;
                        model.EmployeeDependentsDTO.LanguageKnown = model.LanguageKnown;
                        model.EmployeeDependentsDTO.NationalityID = model.NationalityID;
                        model.EmployeeDependentsDTO.ReligionID = model.ReligionID;
                        model.EmployeeDependentsDTO.CasteID = model.CasteID;
                        model.EmployeeDependentsDTO.CategoryID = model.CategoryID;
                        model.EmployeeDependentsDTO.WeddingAnniversaryDate = model.WeddingAnniversaryDate;
                        model.EmployeeDependentsDTO.IsActive = true;
                        model.EmployeeDependentsDTO.IsNominee = model.IsNominee;
                        model.EmployeeDependentsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeDependents> response = _employeeDependentsBA.InsertEmployeeDependents(model.EmployeeDependentsDTO);
                        model.EmployeeDependentsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.EmployeeDependentsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(int ID)
        {
            EmployeeDependentsViewModel model = new EmployeeDependentsViewModel();
            try
            {
                model.EmployeeDependentsDTO = new EmployeeDependents();           
                model.EmployeeDependentsDTO.ID = ID;              
                model.EmployeeDependentsDTO.ConnectionString = _connectioString;
                 //--------------------------------------For Title---------------------------------//
                List<GeneralTitleMaster> GeneralTitleMasterList = GetListGeneralTitleMaster();
                List<SelectListItem> ListGeneralTitleMaster = new List<SelectListItem>();
                foreach (GeneralTitleMaster item in GeneralTitleMasterList)
                {
                    ListGeneralTitleMaster.Add(new SelectListItem { Text = item.NameTitle, Value = item.NameTitle.ToString() });
                }



                //--------------------------------------For Relationship---------------------------------//
                List<GeneralRelationshipTypeMaster> GeneralRelationshipTypeMasterList = GetListGeneralRelationshipTypeMaster();
                List<SelectListItem> GeneralRelationshipTypeMaster = new List<SelectListItem>();
                foreach (GeneralRelationshipTypeMaster item in GeneralRelationshipTypeMasterList)
                {
                    GeneralRelationshipTypeMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }



                ////--------------------------------------For Mothertounge---------------------------------//
                //List<GeneralLanguageMaster> GeneralLanguageMasterList = GetListGeneralLanguageMaster();
                //List<SelectListItem> GeneralLanguageMaster = new List<SelectListItem>();
                //foreach (GeneralLanguageMaster item in GeneralLanguageMasterList)
                //{
                //    GeneralLanguageMaster.Add(new SelectListItem { Text = item.LanguageName, Value = item.ID.ToString() });
                //}



                //--------------------------------------For Nationality---------------------------------//
                List<GeneralNationalityMaster> listGeneralNationalityMaster = GetListGeneralNationalityMaster();
                List<SelectListItem> generalNationalityMaster = new List<SelectListItem>();
                foreach (GeneralNationalityMaster item in listGeneralNationalityMaster)
                {
                    generalNationalityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }
             

                ////--------------------------------------For Religion---------------------------------//
                //List<GeneralReligionMaster> listGeneralReligionMaster = GetListGeneralReligionMaster();
                //List<SelectListItem> GeneralReligionMaster = new List<SelectListItem>();
                //foreach (GeneralReligionMaster item in listGeneralReligionMaster)
                //{
                //    GeneralReligionMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                //}
              

                ////--------------------------------------For Category---------------------------------//
                //List<GeneralCategoryMaster> listGeneralCategoryMaster = GetListGeneralCategoryMaster();
                //List<SelectListItem> GeneralCategoryMaster = new List<SelectListItem>();
                //foreach (GeneralCategoryMaster item in listGeneralCategoryMaster)
                //{
                //    GeneralCategoryMaster.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                //}
               

                ////--------------------------------------For Cast---------------------------------//

                //List<GeneralCasteMaster> listGeneralCasteMaster = GetListGeneralCasteMaster(0);
                //List<SelectListItem> GeneralCasteMaster = new List<SelectListItem>();
                //foreach (GeneralCasteMaster item in listGeneralCasteMaster)
                //{
                //    GeneralCasteMaster.Add(new SelectListItem { Text = item.CasteName, Value = item.ID.ToString() });
                //}
              



                //--------------------------------------For Country---------------------------------//
                List<GeneralCountryMaster> GeneralCountryMasterList = GetListGeneralCountryMaster();
                List<SelectListItem> GeneralCountryMaster = new List<SelectListItem>();
                foreach (GeneralCountryMaster item in GeneralCountryMasterList)
                {
                    GeneralCountryMaster.Add(new SelectListItem { Text = item.CountryName, Value = item.ID.ToString() });
                }

              
                //--------------------------------------For Region---------------------------------//

                int CountryId = 0;
                List<GeneralRegionMaster> generalRegionMasterList = GetListGeneralRegionMaster(Convert.ToString(CountryId));
                List<SelectListItem> generalRegionMaster = new List<SelectListItem>();
             //    generalRegionMaster.Add(new SelectListItem { Text = "-- Select Region--", Value = "" });
            //    generalRegionMaster.Add(new SelectListItem { Text = Resources.DisplayName_Other, Value = "Other" });
                foreach (GeneralRegionMaster item in generalRegionMasterList)
                {
                    generalRegionMaster.Add(new SelectListItem { Text = item.RegionName , Value = item.ID.ToString() });
                }

             
                //--------------------------------------For City---------------------------------//

                int CityID = 0;
                List<GeneralCityMaster> listGeneralCityMaster = GetListGeneralCityMaster(Convert.ToString(CityID));
                List<SelectListItem> GeneralCityMaster = new List<SelectListItem>();
               // GeneralCityMaster.Add(new SelectListItem { Text = Resources.DisplayName_Other, Value = "Other" });
                foreach (GeneralCityMaster item in listGeneralCityMaster)
                {
                    GeneralCityMaster.Add(new SelectListItem { Text = item.Description, Value = item.ID.ToString() });
                }

              
                IBaseEntityResponse<EmployeeDependents> response = _employeeDependentsBA.SelectByID(model.EmployeeDependentsDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmployeeDependentsDTO.ConnectionString = _connectioString;
                    model.EmployeeDependentsDTO.EmployeeID = response.Entity.EmployeeID;
                    model.EmployeeDependentsDTO.SequenceNumber = response.Entity.SequenceNumber;
                    model.EmployeeDependentsDTO.NameTitle = response.Entity.NameTitle; 
                    model.EmployeeDependentsDTO.DependentName = response.Entity.DependentName;
                    model.EmployeeDependentsDTO.Address1 = response.Entity.Address1;
                    model.EmployeeDependentsDTO.Address2 = response.Entity.Address2;
                    model.EmployeeDependentsDTO.AdharCardNumber = response.Entity.AdharCardNumber;

                    model.EmployeeDependentsDTO.CountryID = response.Entity.CountryID;
                    model.EmployeeDependentsDTO.RegionID = response.Entity.RegionID;

                    model.EmployeeDependentsDTO.CityID = response.Entity.CityID;
                    model.EmployeeDependentsDTO.PhoneNumber = response.Entity.PhoneNumber;
                    model.EmployeeDependentsDTO.MobileNumber = response.Entity.MobileNumber;
                    model.EmployeeDependentsDTO.EmployeeDependentQualification = response.Entity.EmployeeDependentQualification;
                    model.EmployeeDependentsDTO.EmployeeDependentDesignation = response.Entity.EmployeeDependentDesignation;
                    model.EmployeeDependentsDTO.GotAnyMedal = response.Entity.GotAnyMedal;
                    //model.EmployeeDependentsDTO.MedalReceivedDate = response.Entity.MedalReceivedDate;
                    model.EmployeeDependentsDTO.MedalReceivedDate = Convert.ToDateTime(response.Entity.MedalReceivedDate).ToString("d MMM yyyy");
                    model.EmployeeDependentsDTO.MedalDescription = response.Entity.MedalDescription;
                    model.EmployeeDependentsDTO.IsScholarshipReceived = response.Entity.IsScholarshipReceived;
                    model.EmployeeDependentsDTO.ScholarshipAmount = response.Entity.ScholarshipAmount;
                    //model.EmployeeDependentsDTO.ScholarshipStartDate = response.Entity.ScholarshipStartDate;
                    model.EmployeeDependentsDTO.ScholarshipStartDate = Convert.ToDateTime(response.Entity.ScholarshipStartDate).ToString("d MMM yyyy");
                    //model.EmployeeDependentsDTO.ScholarshipUptoDate = response.Entity.ScholarshipUptoDate;
                    model.EmployeeDependentsDTO.ScholarshipUptoDate = Convert.ToDateTime(response.Entity.ScholarshipUptoDate).ToString("d MMM yyyy");
                    model.EmployeeDependentsDTO.ScholarshipDescription = response.Entity.ScholarshipDescription;
                    model.EmployeeDependentsDTO.Hobbies = response.Entity.Hobbies;
                    model.EmployeeDependentsDTO.CurriculumActivity = response.Entity.CurriculumActivity;
                    //model.EmployeeDependentsDTO.DateOfBirth = response.Entity.DateOfBirth;
                    model.EmployeeDependentsDTO.DateOfBirth = Convert.ToDateTime(response.Entity.DateOfBirth).ToString("d MMM yyyy");
                    model.EmployeeDependentsDTO.PlaceOfBirth = response.Entity.PlaceOfBirth;
                    model.EmployeeDependentsDTO.GeneralRelationshipTypeMasterID = response.Entity.GeneralRelationshipTypeMasterID;
                    model.EmployeeDependentsDTO.MotherTongueID = response.Entity.MotherTongueID;
                    model.EmployeeDependentsDTO.LanguageKnown = response.Entity.LanguageKnown;
                    model.EmployeeDependentsDTO.NationalityID = response.Entity.NationalityID;
                    model.EmployeeDependentsDTO.ReligionID = response.Entity.ReligionID;
                    model.EmployeeDependentsDTO.CasteID = response.Entity.CasteID;
                    model.EmployeeDependentsDTO.CategoryID = response.Entity.CategoryID;
                    model.EmployeeDependentsDTO.IsNominee = response.Entity.IsNominee;
                    model.EmployeeDependentsDTO.WeddingAnniversaryDate = Convert.ToDateTime(response.Entity.WeddingAnniversaryDate).ToString("d MMM yyyy");
                    model.EmployeeDependentsDTO.IsActive = true;
                }

                ViewBag.GeneralTitleMasterList = new SelectList(ListGeneralTitleMaster, "Value", "Text");
                ViewBag.GeneralRelationshipTypeMaster = new SelectList(GeneralRelationshipTypeMaster, "Value", "Text");
                //ViewBag.GeneralLanguageMaster = new SelectList(GeneralLanguageMaster, "Value", "Text");
                ViewBag.GeneralNationalityMaster = new SelectList(generalNationalityMaster, "Value", "Text");
                //ViewBag.GeneralReligionMaster = new SelectList(GeneralReligionMaster, "Value", "Text");
                //ViewBag.GeneralCasteMaster = new SelectList(GeneralCasteMaster, "Value", "Text");
                //ViewBag.GeneralCategoryMaster = new SelectList(GeneralCategoryMaster, "Value", "Text");
                ViewBag.GeneralCountryList = new SelectList(GeneralCountryMaster, "Value", "Text");
                ViewBag.GeneralRegionMaster = new SelectList(generalRegionMaster, "Value", "Text");
                ViewBag.GeneralCityMaster = new SelectList(GeneralCityMaster, "Value", "Text");
                return PartialView("/Views/Employee/EmployeePersonalDetails/EmployeeFamilyEdit.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(EmployeeDependentsViewModel model)
        {
            try
            {
               // if (ModelState.IsValid)
                {
                    if (model != null && model.EmployeeDependentsDTO != null)
                    {

                        model.EmployeeDependentsDTO.ConnectionString = _connectioString;
                        model.EmployeeDependentsDTO.ID = model.ID;
                        model.EmployeeDependentsDTO.EmployeeID = model.EmployeeID;
                        model.EmployeeDependentsDTO.SequenceNumber = model.SequenceNumber;
                        model.EmployeeDependentsDTO.NameTitle = model.NameTitle; 
                        model.EmployeeDependentsDTO.DependentName = model.DependentName;
                        model.EmployeeDependentsDTO.Address1 = model.Address1;
                        model.EmployeeDependentsDTO.Address2 = model.Address2;
                        model.EmployeeDependentsDTO.AdharCardNumber = model.AdharCardNumber;
                        model.EmployeeDependentsDTO.RegionID = model.RegionID;
                        model.EmployeeDependentsDTO.CountryID = model.CountryID;
                        model.EmployeeDependentsDTO.CityID = model.CityID;
                        model.EmployeeDependentsDTO.PhoneNumber = model.PhoneNumber;
                        model.EmployeeDependentsDTO.MobileNumber = model.MobileNumber;
                        model.EmployeeDependentsDTO.EmployeeDependentQualification = model.EmployeeDependentQualification;
                        model.EmployeeDependentsDTO.EmployeeDependentDesignation = model.EmployeeDependentDesignation;
                        model.EmployeeDependentsDTO.GotAnyMedal = model.GotAnyMedal;
                        model.EmployeeDependentsDTO.MedalReceivedDate = model.MedalReceivedDate;
                        model.EmployeeDependentsDTO.MedalDescription = model.MedalDescription;
                        model.EmployeeDependentsDTO.IsScholarshipReceived = model.IsScholarshipReceived;
                        model.EmployeeDependentsDTO.ScholarshipAmount = model.ScholarshipAmount;
                        model.EmployeeDependentsDTO.ScholarshipStartDate = model.ScholarshipStartDate;
                        model.EmployeeDependentsDTO.ScholarshipUptoDate = model.ScholarshipUptoDate;
                        model.EmployeeDependentsDTO.ScholarshipDescription = model.ScholarshipDescription;
                        model.EmployeeDependentsDTO.Hobbies = model.Hobbies;
                        model.EmployeeDependentsDTO.CurriculumActivity = model.CurriculumActivity;
                        model.EmployeeDependentsDTO.DateOfBirth = model.DateOfBirth;
                        model.EmployeeDependentsDTO.PlaceOfBirth = model.PlaceOfBirth;
                        model.EmployeeDependentsDTO.GeneralRelationshipTypeMasterID = model.GeneralRelationshipTypeMasterID;
                        model.EmployeeDependentsDTO.MotherTongueID = model.MotherTongueID;
                        model.EmployeeDependentsDTO.LanguageKnown = model.LanguageKnown;
                        model.EmployeeDependentsDTO.NationalityID = model.NationalityID;
                        model.EmployeeDependentsDTO.ReligionID = model.ReligionID;
                        model.EmployeeDependentsDTO.CasteID = model.CasteID;
                        model.EmployeeDependentsDTO.CategoryID = model.CategoryID;
                        model.EmployeeDependentsDTO.WeddingAnniversaryDate = model.WeddingAnniversaryDate;
                        model.EmployeeDependentsDTO.IsActive = true;
                        model.EmployeeDependentsDTO.IsNominee = model.IsNominee;
                        model.EmployeeDependentsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeDependents> response = _employeeDependentsBA.UpdateEmployeeDependents(model.EmployeeDependentsDTO);
                        model.EmployeeDependentsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                    return Json(model.EmployeeDependentsDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                //else
                //{
                //    return Json("Please review your form");
                //}
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        //[HttpGet]
        //public ActionResult Delete(int ID)
        //{
        //    EmployeeDependentsViewModel model = new EmployeeDependentsViewModel();
        //    model.EmployeeDependentsDTO = new EmployeeDependents();
        //    model.EmployeeDependentsDTO.ID = ID;
        //    return PartialView("~/Views/Employee/EmployeeDependents/Delete.cshtml", model);
        //}

        //[HttpPost]
        //public ActionResult Delete(EmployeeDependentsViewModel model)
        //{
        //    try
        //    {

        //        if (model.ID > 0)
        //        {
        //            if (model != null && model.EmployeeDependentsDTO != null)
        //            {
        //                EmployeeDependents EmployeeDependentsDTO = new EmployeeDependents();
        //                EmployeeDependentsDTO.ConnectionString = _connectioString;
        //                EmployeeDependentsDTO.ID = model.ID;
        //                EmployeeDependentsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
        //                IBaseEntityResponse<EmployeeDependents> response = _employeeDependentsBA.DeleteEmployeeDependents(EmployeeDependentsDTO);
        //                model.EmployeeDependentsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
        //            }
        //            return Json(model.EmployeeDependentsDTO.errorMessage, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json("Please review your form");
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        _logException.Error(ex.Message);
        //        throw;
        //    }
        //}

        //[HttpPost]
        public ActionResult Delete(int ID)
        {
            try
            {
                EmployeeDependentsViewModel model = new EmployeeDependentsViewModel();

                if (ID > 0)
                {
                    
                        EmployeeDependents EmployeeDependentsDTO = new EmployeeDependents();
                        EmployeeDependentsDTO.ConnectionString = _connectioString;
                        EmployeeDependentsDTO.ID = ID;
                        EmployeeDependentsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<EmployeeDependents> response = _employeeDependentsBA.DeleteEmployeeDependents(EmployeeDependentsDTO);
                        model.EmployeeDependentsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    
                    return Json(model.EmployeeDependentsDTO.errorMessage, JsonRequestBehavior.AllowGet);
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



        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<EmployeeDependentsViewModel> GetEmployeeDependents( int EmployeeID, out int TotalRecords)
        {
            EmployeeDependentsSearchRequest searchRequest = new EmployeeDependentsSearchRequest();
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
                    searchRequest.EmployeeID = EmployeeID;
                  
                    
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.EmployeeID = EmployeeID;
                    
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.EmployeeID = EmployeeID;
               
            }








            List<EmployeeDependentsViewModel> listEmployeeDependentsViewModel = new List<EmployeeDependentsViewModel>();
            List<EmployeeDependents> listEmployeeDependents = new List<EmployeeDependents>();
            IBaseEntityCollectionResponse<EmployeeDependents> baseEntityCollectionResponse = _employeeDependentsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployeeDependents = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (EmployeeDependents item in listEmployeeDependents)
                    {
                        EmployeeDependentsViewModel EmployeeDependentsViewModel = new EmployeeDependentsViewModel();
                        EmployeeDependentsViewModel.EmployeeDependentsDTO = item;
                        listEmployeeDependentsViewModel.Add(EmployeeDependentsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listEmployeeDependentsViewModel;
        }


        protected List<GeneralRelationshipTypeMaster> GetListGeneralRelationshipTypeMaster()
        {
            GeneralRelationshipTypeMasterSearchRequest searchRequest = new GeneralRelationshipTypeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<GeneralRelationshipTypeMaster> listGeneralRelationshipTypeMaster = new List<GeneralRelationshipTypeMaster>();
            IBaseEntityCollectionResponse<GeneralRelationshipTypeMaster> baseEntityCollectionResponse = _generalRelationshipTypeMasterBA.GetGeneralRelationshipTypeMasterGetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralRelationshipTypeMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listGeneralRelationshipTypeMaster;
        }


        //[HttpGet]
        //public ActionResult GetCastByCategoryID(string SelectedCategoryID)
        //{

        //    int id = 0;
        //    bool isValid = Int32.TryParse(SelectedCategoryID, out id);
        //    var GeneralCasteDetails = GetListGeneralCasteMaster(Convert.ToInt32(SelectedCategoryID));
        //    var result = (from s in GeneralCasteDetails
        //                  select new
        //                  {
        //                      id = s.ID,
        //                      name = s.CasteName,
        //                  }).ToList();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult GetGeneralRegionDetailByCountryID(string SelectedCountryID)
        {

            int id = 0;
            bool isValid = Int32.TryParse(SelectedCountryID, out id);
            var GeneralRegionDetails = GetListGeneralRegionMaster(SelectedCountryID);
            var result = (from s in GeneralRegionDetails
                          select new
                          {
                              id = s.ID,
                              name = s.RegionName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // For CitynDetailByCountry
        [HttpGet]
        public ActionResult GetGeneralCityByRegionID(string SelectedRegionID)
        {
            if (SelectedRegionID == "Other")
            {
                SelectedRegionID = "0";
            }
            int id = 0;
            bool isValid = Int32.TryParse(SelectedRegionID, out id);
            var GeneralCityDetails = GetListGeneralCityMaster(SelectedRegionID);
            var result = (from s in GeneralCityDetails
                          select new
                          {
                              id = s.ID,
                              name = s.Description,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }





        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param,  int EmployeeID)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

            IEnumerable<EmployeeDependentsViewModel> filteredEmployeeDependents;
            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "NameTitle";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or DependentName Like '%" + param.sSearch + "%' or B.Description Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;

                //case 1:
                //    _sortBy = "Name";
                //    if (string.IsNullOrEmpty(param.sSearch))
                //    {
                //        _searchBy = string.Empty;
                //    }
                //    else
                //    {
                //        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or DependentName Like '%" + param.sSearch + "%' or B.Description Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                //    }
                //    break;
               
                case 1:
                    _sortBy = "B.Description";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "NameTitle Like '%" + param.sSearch + "%' or DependentName Like '%" + param.sSearch + "%' or B.Description Like'%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredEmployeeDependents = GetEmployeeDependents( EmployeeID, out TotalRecords);
            var records = filteredEmployeeDependents.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.NameTitle) + " " + Convert.ToString(c.DependentName), Convert.ToString(c.RelationshipType),Convert.ToString(c.EmployeeID), Convert.ToString(c.ID) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}