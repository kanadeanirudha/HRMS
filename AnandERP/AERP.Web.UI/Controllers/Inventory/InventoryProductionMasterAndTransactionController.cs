
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
    public class InventoryProductionMasterAndTransactionController : BaseController
    {
        IGeneralItemMasterServiceAccess _GeneralItemMasterServiceAcess = null;
        IInventoryProductionMasterAndTransactionServiceAccess _InventoryProductionMasterAndTransactionServiceAcess = null;
        IInventoryUoMMasterServiceAccess _InventoryUoMMasterServiceAccess = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public InventoryProductionMasterAndTransactionController()
        {
            _InventoryProductionMasterAndTransactionServiceAcess = new InventoryProductionMasterAndTransactionServiceAccess();
            _InventoryUoMMasterServiceAccess = new InventoryUoMMasterServiceAccess();
            _GeneralItemMasterServiceAcess = new GeneralItemMasterServiceAccess();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index(string StatusFlag)
        {
            InventoryProductionMasterAndTransactionViewModel model = new InventoryProductionMasterAndTransactionViewModel();
            model.StatusFlag = Convert.ToInt32(StatusFlag);
            return View("/Views/Inventory_1/InventoryProductionMasterAndTransaction/Index.cshtml",model);

        }

        public ActionResult List(string actionMode, string TransactionDate, string CheckInfo, string centerCode)
        {
            //try
            //{
            //    InventoryProductionMasterAndTransactionViewModel model = new InventoryProductionMasterAndTransactionViewModel();
            //    if (!string.IsNullOrEmpty(actionMode))
            //    {
            //        TempData["ActionMode"] = actionMode;
            //    }
            //    model.CheckInfo = Convert.ToBoolean(CheckInfo);
            //    model.TransactionDate = TransactionDate;
            //    return PartialView("/Views/Inventory_1/InventoryProductionMasterAndTransaction/List.cshtml", model);
            //}
            //catch (Exception ex)
            //{
            //    _logException.Error(ex.Message);
            //    throw;
            //}

            try
            {
                InventoryProductionMasterAndTransactionViewModel model = new InventoryProductionMasterAndTransactionViewModel();
                if (Convert.ToString(Session["UserType"]) == "A")
                {
                    List<OrganisationStudyCentreMaster> listAdminRoleApplicableDetails = GetListOrgStudyCentreMaster();
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {

                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":Centre";
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);

                    }
                }
                else
                {
                    int AdminRoleMasterID = 0;
                    if (Session["RoleID"] == null)
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                    }

                    else
                    {
                        AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                    }

                    List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentre(AdminRoleMasterID, 0);
                    AdminRoleApplicableDetails a = null;
                    foreach (var item in listAdminRoleApplicableDetails)
                    {
                        a = new AdminRoleApplicableDetails();
                        a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                        a.CentreName = item.CentreName;
                        // a.ScopeIdentity = item.ScopeIdentity;
                        model.ListGetAdminRoleApplicableCentre.Add(a);
                    }
                }

                if (!string.IsNullOrEmpty(centerCode))
                {
                    string[] splitCentreCode = centerCode.Split(':');
                    // model.ListGetOrganisationDepartmentCentreAndRoleWise= GetListOrganisationDepartmentMaster(splitCentreCode[0]);
                }
                model.SelectedCentreCode = centerCode;
                //model.SelectedDepartmentID = departmentID;
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.CheckInfo = Convert.ToBoolean(CheckInfo);
                model.TransactionDate = TransactionDate;

                return PartialView("/Views/Inventory_1/InventoryProductionMasterAndTransaction/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }


        [HttpGet]
        public ActionResult Create(string centerCode)
        {
         InventoryProductionMasterAndTransactionViewModel model = new InventoryProductionMasterAndTransactionViewModel();

         string[] accnmArray = centerCode.Split(':');
         model.CentreCode = Convert.ToString(accnmArray[0]);
         return PartialView("/Views/Inventory_1/InventoryProductionMasterAndTransaction/Create.cshtml", model);
          
        }

        [HttpPost]
        public ActionResult Create(InventoryProductionMasterAndTransactionViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.InventoryProductionMasterAndTransactionDTO != null)
                {
                    model.InventoryProductionMasterAndTransactionDTO.ConnectionString = _connectioString;
                    model.InventoryProductionMasterAndTransactionDTO.XMLstring = model.XMLstring;
                    model.InventoryProductionMasterAndTransactionDTO.TransactionDate = model.TransactionDate;
                    model.InventoryProductionMasterAndTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<InventoryProductionMasterAndTransaction> response = _InventoryProductionMasterAndTransactionServiceAcess.InsertInventoryProductionMasterAndTransaction(model.InventoryProductionMasterAndTransactionDTO);

                    model.InventoryProductionMasterAndTransactionDTO.errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.InventoryProductionMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }


          //  }
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
        public ActionResult ViewDetails(string IDs)
        {
            try
            {
                InventoryProductionMasterAndTransactionViewModel model = new InventoryProductionMasterAndTransactionViewModel();
                string[] IDsArray = IDs.Split('~');
                model.ID = Convert.ToInt16(IDsArray[0]);
                model.ProductionNumber = IDsArray[1];
                model.ViewItemList = GetLIstForItemDetails(model.ID);
                return PartialView("/Views/Inventory_1/InventoryProductionMasterAndTransaction/ViewDetails.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

     

        [HttpPost]
        public ActionResult Edit(InventoryProductionMasterAndTransactionViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null && model.InventoryProductionMasterAndTransactionDTO != null)
                {
                    if (model != null && model.InventoryProductionMasterAndTransactionDTO != null)
                    {
                        model.InventoryProductionMasterAndTransactionDTO.ConnectionString = _connectioString;
                        //model.InventoryProductionMasterAndTransactionDTO.GroupDescription = model.GroupDescription;
                        //// model.InventoryProductionMasterAndTransactionDTO.SeqNo = model.SeqNo;
                        //model.InventoryProductionMasterAndTransactionDTO.MarchandiseGroupCode = model.MarchandiseGroupCode;
                        //model.InventoryProductionMasterAndTransactionDTO.DefaultFlag = model.DefaultFlag;
                        model.InventoryProductionMasterAndTransactionDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                        IBaseEntityResponse<InventoryProductionMasterAndTransaction> response = _InventoryProductionMasterAndTransactionServiceAcess.UpdateInventoryProductionMasterAndTransaction(model.InventoryProductionMasterAndTransactionDTO);
                        model.InventoryProductionMasterAndTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                    }
                }
                return Json(model.InventoryProductionMasterAndTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }

       

        public ActionResult Delete(int ID)
        {
            var errorMessage = string.Empty;
            if (ID > 0)
            {
                IBaseEntityResponse<InventoryProductionMasterAndTransaction> response = null;
                InventoryProductionMasterAndTransaction InventoryProductionMasterAndTransactionDTO = new InventoryProductionMasterAndTransaction();
                InventoryProductionMasterAndTransactionDTO.ConnectionString = _connectioString;
                InventoryProductionMasterAndTransactionDTO.InventoryRecipeFormulaDetailsID = Convert.ToInt16(ID);
                InventoryProductionMasterAndTransactionDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                response = _InventoryProductionMasterAndTransactionServiceAcess.DeleteInventoryProductionMasterAndTransaction(InventoryProductionMasterAndTransactionDTO);
                errorMessage = CheckErrorV2((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);
            }

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetItemSearchList(string term,string CentreCode)
        {
           InventoryProductionMasterAndTransactionSearchRequest searchRequest = new InventoryProductionMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            searchRequest.CentreCode = CentreCode;
            List<InventoryProductionMasterAndTransaction> listFeeSubType = new List<InventoryProductionMasterAndTransaction>();
            IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> baseEntityCollectionResponse = _InventoryProductionMasterAndTransactionServiceAcess.GetInventoryProductionMasterAndTransactionSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listFeeSubType = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listFeeSubType
                          select new
                          {
                              id = r.GeneralItemMasterID,
                              name = r.ItemName,
                              ItemName = r.ItemDescription,
                              ItemNumber = r.ItemNumber,
                              GeneralUnitsID = r.GeneralUnitsID,
                              SalePrice = r.SalePrice,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.UomCode,
                              ConversionFactor = s.BaseQty,
                              BaseUomCode = s.LowerLevelUomCode,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<GeneralItemMaster> GetUoMCodeByItemNumberList(string ItemNumber)
        {

            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);

            List<GeneralItemMaster> listOrganisationDepartmentMaster = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterServiceAcess.GetUomDetailsForGeneralItemMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }

      
        protected List<InventoryProductionMasterAndTransaction> GetLIstForItemDetails(int ID)
        {
            InventoryProductionMasterAndTransactionSearchRequest searchRequest = new InventoryProductionMasterAndTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = ID;
            List<InventoryProductionMasterAndTransaction> ListInventoryProductionMasterAndTransaction = new List<InventoryProductionMasterAndTransaction>();
            IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> baseEntityCollectionResponse = _InventoryProductionMasterAndTransactionServiceAcess.SelectIngridentsByVarients(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListInventoryProductionMasterAndTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListInventoryProductionMasterAndTransaction;
        }
        #endregion

        // Non-Action Method
        #region Methods
        public IEnumerable<InventoryProductionMasterAndTransaction> GetInventoryProductionMasterAndTransaction(string TransactionDate, string centreCode, out int TotalRecords)
        {
            InventoryProductionMasterAndTransactionSearchRequest searchRequest = new InventoryProductionMasterAndTransactionSearchRequest();
           List<InventoryProductionMasterAndTransaction> listProductionMaster = new List<InventoryProductionMasterAndTransaction>();
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
                    searchRequest.TransactionDate = TransactionDate;
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = string.Empty;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.TransactionDate = TransactionDate;
                    string[] Centre_code = centreCode.Split(':');
                    searchRequest.CentreCode = Centre_code[0];

                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.TransactionDate = TransactionDate;
                string[] Centre_code = centreCode.Split(':');
                searchRequest.CentreCode = Centre_code[0];
            }
             IBaseEntityCollectionResponse<InventoryProductionMasterAndTransaction> baseEntityCollectionResponse = _InventoryProductionMasterAndTransactionServiceAcess.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listProductionMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listProductionMaster;
        }

        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string TransactionDate, string SelectedCentreCode)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<InventoryProductionMasterAndTransaction> filteredGroupDescription;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "ProductionNumber,InventoryProductionTransactionID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'or ProductionNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 1:
                        _sortBy = "ProductionNumber,InventoryProductionTransactionID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'or ProductionNumber Like '%" + param.sSearch + "%'";
                            // _searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'or ProductionNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 2:
                        _sortBy = "ProductionNumber,B.Quantity";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'or ProductionNumber Like '%" + param.sSearch + "%'";
                            //_searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'";
                        }
                        break;
                    case 3:
                        _sortBy = "ProductionNumber,B.UOMCode";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            //_searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'";
                            _searchBy = " C.ItemDescription Like '%" + param.sSearch + "%' or  B.Quantity Like '%" + param.sSearch + "%' or B.UOMCode Like '%" + param.sSearch + "%'or ProductionNumber Like '%" + param.sSearch + "%'";
                        }
                        break;
                }
               _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;

                if (!string.IsNullOrEmpty(TransactionDate))
                {
                    filteredGroupDescription = GetInventoryProductionMasterAndTransaction(TransactionDate, SelectedCentreCode,out TotalRecords);
                }
                else
                {
                    filteredGroupDescription = new List<InventoryProductionMasterAndTransaction>();
                    TotalRecords = 0;
                }

                if ((filteredGroupDescription.Count()) == 0)
                {
                    filteredGroupDescription = new List<InventoryProductionMasterAndTransaction>();
                    TotalRecords = 0;
                }


                var records = filteredGroupDescription.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ProductionMasterID), Convert.ToString(c.ProductionNumber),  Convert.ToString(c.ItemDescription), Convert.ToString(c.ItemNumber), Convert.ToString(c.Quantity), Convert.ToString(c.UoMCode), Convert.ToString(c.InventoryProductionTransactionID), };

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