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
    public class CCRMContractTypesMasterController : BaseController
    {
        ICCRMContractTypesMasterBA _CCRMContractTypesMasterBA = null;
        IGeneralItemCategoryMasterBA _GeneralItemCategoryMasterBA = null;
      
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public CCRMContractTypesMasterController()
        {
            _CCRMContractTypesMasterBA = new CCRMContractTypesMasterBA();
            _GeneralItemCategoryMasterBA = new GeneralItemCategoryMasterBA();
            //_empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }
        // GET: CCRMContractTypesMaster
        #region Controller Methods
        public ActionResult Index()
        {
            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                return View("/Views/CCRM/CCRMContractTypesMaster/Index.cshtml");
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
                CCRMContractTypesMasterViewModel model = new CCRMContractTypesMasterViewModel();
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/CCRM/CCRMContractTypesMaster/List.cshtml", model);
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
            int ID = 0;
            
            CCRMContractTypesMasterViewModel model = new CCRMContractTypesMasterViewModel();
            model.GetGeneralCategoryMasterList = GetListGeneralItemCategoryMaster(ID);

            List<SelectListItem> ContractType = new List<SelectListItem>();
            ViewBag.ContractType = new SelectList(ContractType, "Value", "Text");
            List<SelectListItem> li_ContractType = new List<SelectListItem>();

            if (model.CCRMContractTypesMasterDTO.ContractType > 0)
            {
                li_ContractType.Add(new SelectListItem { Text = "TOTALGUARANTEE", Value = "1" });
                li_ContractType.Add(new SelectListItem { Text = "WARRANTY", Value = "2" });
                li_ContractType.Add(new SelectListItem { Text = "AMC", Value = "3" });
                li_ContractType.Add(new SelectListItem { Text = "C&M", Value = "4" });
                li_ContractType.Add(new SelectListItem { Text = "RENTAL", Value = "5" });
                //ViewData["SerialAndBatchManagedBy"] = li_SerialAndBatchManagedBy;
                ViewData["ContractType"] = new SelectList(li_ContractType, "Value", "Text", (model.CCRMContractTypesMasterDTO.ContractType).ToString().Trim());
            }
            else
            {

                li_ContractType.Add(new SelectListItem { Text = "TOTALGUARANTEE", Value = "1" });
                li_ContractType.Add(new SelectListItem { Text = "WARRANTY", Value = "2" });
                li_ContractType.Add(new SelectListItem { Text = "AMC", Value = "3" });
                li_ContractType.Add(new SelectListItem { Text = "C&M", Value = "4" });
                li_ContractType.Add(new SelectListItem { Text = "RENTAL", Value = "5" });
                ViewData["ContractType"] = li_ContractType;
            }
            return PartialView("/Views/CCRM/CCRMContractTypesMaster/Create.cshtml", model);
        }
        [HttpPost]
        public ActionResult Create(CCRMContractTypesMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMContractTypesMasterDTO != null)
                    {
                        model.CCRMContractTypesMasterDTO.ConnectionString = _connectioString;

                        model.CCRMContractTypesMasterDTO.ContractCode = model.ContractCode;
                        model.CCRMContractTypesMasterDTO.ContractName = model.ContractName;
                        model.CCRMContractTypesMasterDTO.ContractType = model.ContractType;
                        model.CCRMContractTypesMasterDTO.IsSpares = model.IsSpares;
                        model.CCRMContractTypesMasterDTO.IsConsumables = model.IsConsumables;
                        model.CCRMContractTypesMasterDTO.ISService = model.ISService;
                        model.CCRMContractTypesMasterDTO.IsRentMachine = model.IsRentMachine;
                        model.CCRMContractTypesMasterDTO.SelectedCategoryMasterIDs = model.SelectedCategoryMasterIDs;
                        model.CCRMContractTypesMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMContractTypesMaster> response = _CCRMContractTypesMasterBA.InsertCCRMContractTypesMaster(model.CCRMContractTypesMasterDTO);
                        model.CCRMContractTypesMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    }
                    return Json(model.CCRMContractTypesMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            CCRMContractTypesMasterViewModel model = new CCRMContractTypesMasterViewModel();

            List<SelectListItem> li = new List<SelectListItem>();
            // li1.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li.Add(new SelectListItem { Text = "TOTALGUARANTEE", Value = "1" });
            li.Add(new SelectListItem { Text = "WARRANTY", Value = "2" });
            li.Add(new SelectListItem { Text = "AMC", Value = "3" });
            li.Add(new SelectListItem { Text = "C&M", Value = "4" });
            li.Add(new SelectListItem { Text = "RENTAL", Value = "5" });
            ViewData["ContractType"] = li;
            try
            {



                model.CCRMContractTypesMasterDTO = new CCRMContractTypesMaster();
                model.CCRMContractTypesMasterDTO.ID = id;
                model.CCRMContractTypesMasterDTO.ConnectionString = _connectioString;
                model.GetGeneralCategoryMasterList = GetListGeneralItemCategoryMaster(id);
               
                IBaseEntityResponse<CCRMContractTypesMaster> response = _CCRMContractTypesMasterBA.SelectByID(model.CCRMContractTypesMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.CCRMContractTypesMasterDTO.ID = response.Entity.ID;
                    model.CCRMContractTypesMasterDTO.ContractCode = response.Entity.ContractCode;
                    model.CCRMContractTypesMasterDTO.ContractName = response.Entity.ContractName;
                    model.CCRMContractTypesMasterDTO.ContractType = response.Entity.ContractType;
                    model.CCRMContractTypesMasterDTO.IsSpares = response.Entity.IsSpares;
                    model.CCRMContractTypesMasterDTO.IsConsumables = response.Entity.IsConsumables;
                    model.CCRMContractTypesMasterDTO.ISService = response.Entity.ISService;
                    model.CCRMContractTypesMasterDTO.IsRentMachine = response.Entity.IsRentMachine;
                }
                ViewData["ContractType"] = new SelectList(li, "Value", "Text", (model.ContractType).ToString().Trim());
                return PartialView("/Views/CCRM/CCRMContractTypesMaster/Edit.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(CCRMContractTypesMasterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model != null && model.CCRMContractTypesMasterDTO != null)
                    {
                        if (model != null && model.CCRMContractTypesMasterDTO != null)
                        {
                            model.CCRMContractTypesMasterDTO.ConnectionString = _connectioString;
                            model.CCRMContractTypesMasterDTO.ContractCode = model.ContractCode;
                            model.CCRMContractTypesMasterDTO.ContractName = model.ContractName;
                            model.CCRMContractTypesMasterDTO.ContractType = model.ContractType;
                            model.CCRMContractTypesMasterDTO.IsSpares = model.IsSpares;
                            model.CCRMContractTypesMasterDTO.IsConsumables = model.IsConsumables;
                            model.CCRMContractTypesMasterDTO.ISService = model.ISService;
                            model.CCRMContractTypesMasterDTO.IsRentMachine = model.IsRentMachine;
                            model.CCRMContractTypesMasterDTO.ID = model.ID;
                            model.CCRMContractTypesMasterDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                            IBaseEntityResponse<CCRMContractTypesMaster> response = _CCRMContractTypesMasterBA.UpdateCCRMContractTypesMaster(model.CCRMContractTypesMasterDTO);
                            model.CCRMContractTypesMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                        }
                    }
                    return Json(model.CCRMContractTypesMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult Delete(Int32 ID)
        {
            CCRMContractTypesMasterViewModel model = new CCRMContractTypesMasterViewModel();
            try
            {
                if (ID > 0)
                {
                    if (ID > 0)
                    {
                        CCRMContractTypesMaster CCRMContractTypesMasterDTO = new CCRMContractTypesMaster();
                        CCRMContractTypesMasterDTO.ConnectionString = _connectioString;
                        CCRMContractTypesMasterDTO.ID = ID;
                        CCRMContractTypesMasterDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<CCRMContractTypesMaster> response = _CCRMContractTypesMasterBA.DeleteCCRMContractTypesMaster(CCRMContractTypesMasterDTO);
                        model.CCRMContractTypesMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
                    }
                    return Json(model.CCRMContractTypesMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public IEnumerable<CCRMContractTypesMasterViewModel> GetCCRMContractTypesMaster(out int TotalRecords)
        {
            CCRMContractTypesMasterSearchRequest searchRequest = new CCRMContractTypesMasterSearchRequest();
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
            List<CCRMContractTypesMasterViewModel> listCCRMContractTypesMasterViewModel = new List<CCRMContractTypesMasterViewModel>();
            List<CCRMContractTypesMaster> listCCRMContractTypesMaster = new List<CCRMContractTypesMaster>();
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> baseEntityCollectionResponse = _CCRMContractTypesMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMContractTypesMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (CCRMContractTypesMaster item in listCCRMContractTypesMaster)
                    {
                        CCRMContractTypesMasterViewModel CCRMContractTypesMasterViewModel = new CCRMContractTypesMasterViewModel();
                        CCRMContractTypesMasterViewModel.CCRMContractTypesMasterDTO = item;
                        listCCRMContractTypesMasterViewModel.Add(CCRMContractTypesMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listCCRMContractTypesMasterViewModel;
        }
        #endregion
     
        protected List<GeneralItemCategoryMaster> GetListGeneralItemCategoryMaster(int ID)
        {
            GeneralItemCategoryMasterSearchRequest searchRequest = new GeneralItemCategoryMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
           
            List<GeneralItemCategoryMaster> listGeneralItemCategoryMaster = new List<GeneralItemCategoryMaster>();
            IBaseEntityCollectionResponse<GeneralItemCategoryMaster> baseEntityCollectionResponse = _GeneralItemCategoryMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralItemCategoryMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.ItemCategoryCode).ToList();
                }
            }
            return listGeneralItemCategoryMaster;
        }
        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<CCRMContractTypesMasterViewModel> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ContractCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {

                            _searchBy = string.Empty;
                        }
                        else
                        {

                            _searchBy = " A.ContractCode Like '%" + param.sSearch + "%' or A.ContractName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "ContractName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " A.ContractCode Like '%" + param.sSearch + "%' or A.ContractName Like '%" + param.sSearch + "%'";
                        }
                        break;
                   

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredGroupDescription = GetCCRMContractTypesMaster(out TotalRecords);


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ContractCode), Convert.ToString(c.ID), Convert.ToString(c.ContractName), Convert.ToString(c.ItemCategoryMasterID), Convert.ToString(c.ContractType),  Convert.ToString(c.CCRMContractTypeDetailsID), Convert.ToString(c.IsSpares), Convert.ToString(c.IsConsumables), Convert.ToString(c.ISService), Convert.ToString(c.IsRentMachine) };

                return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);
            }
            else
            {

                //return View("Login","Account");
                //return RedirectToAction("Login", "Account");
                var result = 0;
                return Json(new { aaData = result }, JsonRequestBehavior.AllowGet);
                // return PartialView("Login");
            }
        }
        #endregion
    }
}