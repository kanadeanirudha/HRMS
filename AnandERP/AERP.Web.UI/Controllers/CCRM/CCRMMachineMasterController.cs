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

namespace AERP.Web.UI.Controllers.CCRM
{
    public class CCRMMachineMasterController : BaseController
    {
        ICCRMMachineMasterBA _CCRMMachineMasterBA = null;
        ICCRMMachineFamilyMasterBA _CCRMMachineFamilyMasterBA = null;
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

        public CCRMMachineMasterController()
        {
            _CCRMMachineMasterBA = new CCRMMachineMasterBA();
            _CCRMMachineFamilyMasterBA = new CCRMMachineFamilyMasterBA();
        }
        #region Controller Methods
        // GET: CCRMMachineMaster
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Admin Manager"]) > 0)
            {
                return View("/Views/CCRM/CCRMMachineMaster/Index.cshtml");
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
                CCRMMachineMasterViewModel model = new CCRMMachineMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMMachineMaster/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult Create(string ITMNumber, string ITMDescription)
        {
            CCRMMachineMasterViewModel model = new CCRMMachineMasterViewModel();
            
            model.ItemNumber = Convert.ToInt32(ITMNumber);
            model.ItemDescription = ITMDescription;

            //model.ItemNumber = Convert.ToInt32(IDsArray[1]);
            //*********************MachineType*********************//
            List<SelectListItem> MachineType = new List<SelectListItem>();
            ViewBag.MachineType = new SelectList(MachineType, "Value", "Text");
            List<SelectListItem> li_MachineType = new List<SelectListItem>();

            if (model.CCRMMachineMasterDTO.MachineType > 0)
            {
                li_MachineType.Add(new SelectListItem { Text = "ANALOG", Value = "1" });
                li_MachineType.Add(new SelectListItem { Text = "DIGITAL", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["MachineType"] = new SelectList(li_MachineType, "Value", "Text", (model.CCRMMachineMasterDTO.MachineType).ToString().Trim());
            }
            else
            {

                li_MachineType.Add(new SelectListItem { Text = "ANALOG", Value = "1" });
                li_MachineType.Add(new SelectListItem { Text = "DIGITAL", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["MachineType"] = li_MachineType;
            }
            //*********************ColorMono*********************//
            List<SelectListItem> ColorMono = new List<SelectListItem>();
            ViewBag.ColorMono = new SelectList(ColorMono, "Value", "Text");
            List<SelectListItem> li_ColorMono = new List<SelectListItem>();

            if (model.CCRMMachineMasterDTO.ColorMono > 0)
            {
                li_ColorMono.Add(new SelectListItem { Text = "MONO", Value = "1" });
                li_ColorMono.Add(new SelectListItem { Text = "COLOR", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ColorMono"] = new SelectList(li_ColorMono, "Value", "Text", (model.CCRMMachineMasterDTO.ColorMono).ToString().Trim());
            }
            else
            {

                li_ColorMono.Add(new SelectListItem { Text = "MONO", Value = "1" });
                li_ColorMono.Add(new SelectListItem { Text = "COLOR", Value = "2" });
                // li_LocationType.Add(new SelectListItem { Text = "None", Value = "3" });
                ViewData["ColorMono"] = li_ColorMono;
            }
            //*********************Frequency*********************//
            List<SelectListItem> Frequency = new List<SelectListItem>();
            ViewBag.Frequency = new SelectList(Frequency, "Value", "Text");
            List<SelectListItem> li_Frequency = new List<SelectListItem>();

            if (model.CCRMMachineMasterDTO.Frequency > 0)
            {
                li_Frequency.Add(new SelectListItem { Text = "Daily", Value = "1" });
                li_Frequency.Add(new SelectListItem { Text = "High", Value = "2" });
                li_Frequency.Add(new SelectListItem { Text = "Moderate", Value = "3" });
                li_Frequency.Add(new SelectListItem { Text = "Low", Value = "4" });
                li_Frequency.Add(new SelectListItem { Text = "Never", Value = "5" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["Frequency"] = new SelectList(li_Frequency, "Value", "Text", (model.CCRMMachineMasterDTO.Frequency).ToString().Trim());
            }
            else
            {

                li_Frequency.Add(new SelectListItem { Text = "Daily", Value = "1" });
                li_Frequency.Add(new SelectListItem { Text = "High", Value = "2" });
                li_Frequency.Add(new SelectListItem { Text = "Moderate", Value = "3" });
                li_Frequency.Add(new SelectListItem { Text = "Low", Value = "3" });
                li_Frequency.Add(new SelectListItem { Text = "Never", Value = "3" });
                ViewData["Frequency"] = li_Frequency;
            }
            //*********************MachineFamily*********************//
            List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
            List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
            foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
            {
                CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyMasterID);

            return PartialView("/Views/CCRM/CCRMMachineMaster/Create.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(CCRMMachineMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMMachineMasterDTO != null)
                    {
                        model.CCRMMachineMasterDTO.ConnectionString = _connectioString;
                        model.CCRMMachineMasterDTO.ItemNumber = model.ItemNumber;
                        model.CCRMMachineMasterDTO.MachineFamilyMasterID = model.MachineFamilyMasterID;
                        model.CCRMMachineMasterDTO.MachineType = model.MachineType;
                        model.CCRMMachineMasterDTO.ColorMono = model.ColorMono;
                        model.CCRMMachineMasterDTO.PaperSize = model.PaperSize;
                        model.CCRMMachineMasterDTO.Warrenty = model.Warrenty;
                        model.CCRMMachineMasterDTO.LifeInYears = model.LifeInYears;
                        model.CCRMMachineMasterDTO.lifeInCopies = model.lifeInCopies;
                        model.CCRMMachineMasterDTO.PMPeriods = model.PMPeriods;
                        model.CCRMMachineMasterDTO.Isreturnable = model.Isreturnable;
                        model.CCRMMachineMasterDTO.Frequency = model.Frequency;
                        model.CCRMMachineMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMMachineMaster> response = _CCRMMachineMasterBA.InsertCCRMMachineMaster(model.CCRMMachineMasterDTO);
                        model.CCRMMachineMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Edit(Int32 id)
        {
            CCRMMachineMasterViewModel model = new CCRMMachineMasterViewModel();
            //*********************MachineFamily*********************//
            List<CCRMMachineFamilyMaster> CCRMMachineFamilyMaster = GetCCRMMachineFamilyMaster();
            List<SelectListItem> CCRMMachineFamilyMasterList = new List<SelectListItem>();
            foreach (CCRMMachineFamilyMaster item in CCRMMachineFamilyMaster)
            {
                CCRMMachineFamilyMasterList.Add(new SelectListItem { Text = item.MachineFamilyName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.CCRMMachineFamilyMasterList = new SelectList(CCRMMachineFamilyMasterList, "Value", "Text", model.MachineFamilyMasterID);
            //*********************MachineType*********************//
            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "ANALOG", Value = "1" });
            li.Add(new SelectListItem { Text = "DIGITAL", Value = "2" });
            ViewData["MachineType"] = li;
            //*********************ColorMono*********************//
            List<SelectListItem> li1 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            
            li1.Add(new SelectListItem { Text = "MONO", Value = "1" });
            li1.Add(new SelectListItem { Text = "COLOR", Value = "2" });
            ViewData["ColorMono"] = li1;
            //*********************Frequency*********************//
            List<SelectListItem> li2 = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });

            li2.Add(new SelectListItem { Text = "Daily", Value = "1" });
            li2.Add(new SelectListItem { Text = "High", Value = "2" });
            li2.Add(new SelectListItem { Text = "Moderate", Value = "3" });
            li2.Add(new SelectListItem { Text = "Low", Value = "4" });
            li2.Add(new SelectListItem { Text = "Never", Value = "5" });
            ViewData["Frequency"] = li2;



            try
            {



                model.CCRMMachineMasterDTO = new CCRMMachineMaster();
                model.CCRMMachineMasterDTO.ID = id;
                model.CCRMMachineMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMMachineMaster> response = _CCRMMachineMasterBA.SelectByID(model.CCRMMachineMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMMachineMasterDTO.ID = response.Entity.ID;
                    model.CCRMMachineMasterDTO.ItemNumber = response.Entity.ItemNumber;
                    model.CCRMMachineMasterDTO.MachineFamilyMasterID = response.Entity.MachineFamilyMasterID;
                    model.CCRMMachineMasterDTO.MachineType = response.Entity.MachineType;
                    model.CCRMMachineMasterDTO.ColorMono = response.Entity.ColorMono;
                    model.CCRMMachineMasterDTO.PaperSize = response.Entity.PaperSize;
                    model.CCRMMachineMasterDTO.Warrenty = response.Entity.Warrenty;
                    model.CCRMMachineMasterDTO.LifeInYears = response.Entity.LifeInYears;
                    model.CCRMMachineMasterDTO.lifeInCopies = response.Entity.lifeInCopies;
                    model.CCRMMachineMasterDTO.PMPeriods = response.Entity.PMPeriods;
                    model.CCRMMachineMasterDTO.Isreturnable = response.Entity.Isreturnable;
                    model.CCRMMachineMasterDTO.Frequency = response.Entity.Frequency;


                }
                ViewData["MachineType"] = new SelectList(li, "Value", "Text", (model.MachineType).ToString().Trim());
                ViewData["ColorMono"] = new SelectList(li1, "Value", "Text", (model.ColorMono).ToString().Trim());
                ViewData["Frequency"] = new SelectList(li2, "Value", "Text", (model.Frequency).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMMachineMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMMachineMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMMachineMasterDTO != null)
                    {
                        if (model != null && model.CCRMMachineMasterDTO != null)
                        {
                            model.CCRMMachineMasterDTO.ConnectionString = _connectioString;
                            model.CCRMMachineMasterDTO.ItemNumber = model.ItemNumber;
                            model.CCRMMachineMasterDTO.MachineFamilyMasterID = model.MachineFamilyMasterID;
                            model.CCRMMachineMasterDTO.MachineType = model.MachineType;
                            model.CCRMMachineMasterDTO.ColorMono = model.ColorMono;
                            model.CCRMMachineMasterDTO.PaperSize = model.PaperSize;
                            model.CCRMMachineMasterDTO.Warrenty = model.Warrenty;
                            model.CCRMMachineMasterDTO.LifeInYears = model.LifeInYears;
                            model.CCRMMachineMasterDTO.lifeInCopies = model.lifeInCopies;
                            model.CCRMMachineMasterDTO.PMPeriods = model.PMPeriods;
                            model.CCRMMachineMasterDTO.Isreturnable = model.Isreturnable;
                            model.CCRMMachineMasterDTO.Frequency = model.Frequency;

                            model.CCRMMachineMasterDTO.ID = model.ID;
                            model.CCRMMachineMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMMachineMaster> response = _CCRMMachineMasterBA.UpdateCCRMMachineMaster(model.CCRMMachineMasterDTO);
                            model.CCRMMachineMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMMachineMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        // Non-Action Method
        #region Methods
        public IEnumerable<CCRMMachineMasterViewModel> GetCCRMMachineMaster(out int TotalRecords)
        {
            CCRMMachineMasterSearchRequest searchRequest = new CCRMMachineMasterSearchRequest();
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
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
            }
            List<CCRMMachineMasterViewModel> listCCRMMachineMasterViewModel = new List<CCRMMachineMasterViewModel>();
            List<CCRMMachineMaster> listCCRMMachineMaster = new List<CCRMMachineMaster>();
            IBaseEntityCollectionResponse<CCRMMachineMaster> baseEntityCollectionResponse = _CCRMMachineMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMachineMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMMachineMaster item in listCCRMMachineMaster)
                    {
                        CCRMMachineMasterViewModel CCRMMachineMasterViewModel = new CCRMMachineMasterViewModel();
                        CCRMMachineMasterViewModel.CCRMMachineMasterDTO = item;
                        listCCRMMachineMasterViewModel.Add(CCRMMachineMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMMachineMasterViewModel;
        }
        protected List<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMaster()
        {
            CCRMMachineFamilyMasterSearchRequest searchRequest = new CCRMMachineFamilyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<CCRMMachineFamilyMaster> listCCRMMachineFamilyMaster = new List<CCRMMachineFamilyMaster>();
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> baseEntityCollectionResponse = _CCRMMachineFamilyMasterBA.GetCCRMMachineFamilyMasterList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMMachineFamilyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMMachineFamilyMaster;
        }
        #endregion
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            int TotalRecords;
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            IEnumerable<CCRMMachineMasterViewModel> filteredCCRMMachineMasterViewModel;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ItemDescription";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " ItemDescription Like '%" + param.sSearch + "%' or MachineFamilyName Like '%" + param.sSearch + "%'";
                        //_searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "MachineFamilyName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = " ItemDescription Like '%" + param.sSearch + "%' or MachineFamilyName Like '%" + param.sSearch + "%'";
                        // _searchBy = "ID Like '%" + param.sSearch + "%' or FeedbackPoints Like '%" + param.sSearch + "%'";
                        //this "if" block is added for search functionality
                    }
                    break;
                
               

            }
            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;
            filteredCCRMMachineMasterViewModel = GetCCRMMachineMaster(out TotalRecords);
            var records = filteredCCRMMachineMasterViewModel.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ItemNumber), Convert.ToString(c.ID), Convert.ToString(c.ItemDescription), Convert.ToString(c.MachineFamilyName), Convert.ToString(c.MachineFamilyMasterID), Convert.ToString(c.MachineType), Convert.ToString(c.ColorMono), Convert.ToString(c.PaperSize), Convert.ToString(c.Warrenty), Convert.ToString(c.LifeInYears), Convert.ToString(c.lifeInCopies), Convert.ToString(c.PMPeriods), Convert.ToString(c.Isreturnable), Convert.ToString(c.Frequency) };

            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}