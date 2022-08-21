
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
    public class SalesEnquiryMasterAndDetailsController : BaseController
    {
        ISalesEnquiryMasterAndDetailsBA _SalesEnquiryMasterAndDetailsBA = null;
        IGeneralCurrencyMasterBA _GeneralCurrencyMasterBA = null;
        IGeneralItemMasterBA _GeneralItemMasterBA = null;
        IInventoryUoMMasterBA _InventoryUoMMasterBA = null;

        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesEnquiryMasterAndDetailsController()
        {
            _SalesEnquiryMasterAndDetailsBA = new SalesEnquiryMasterAndDetailsBA();
            _GeneralCurrencyMasterBA = new GeneralCurrencyMasterBA();
            _GeneralItemMasterBA = new GeneralItemMasterBA();
            _InventoryUoMMasterBA = new InventoryUoMMasterBA();
        }

        // Controller Methods
        #region Controller Methods
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {
                SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();
                return View("/Views/Sales/SalesEnquiryMasterAndDetails/Index.cshtml",model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }

        }

        public ActionResult List(string actionMode)
        {
            SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();
            return PartialView("/Views/Sales/SalesEnquiryMasterAndDetails/List.cshtml", model);

        }


      


        [HttpGet]
        public ActionResult Create()
        {
            SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();

            List<SelectListItem> li2 = new List<SelectListItem>();
            //li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
            li2.Add(new SelectListItem { Text = "Email", Value = "1" });
            li2.Add(new SelectListItem { Text = "Phone", Value = "2" });
            li2.Add(new SelectListItem { Text = "LinkedIn", Value = "3" });
            li2.Add(new SelectListItem { Text = "Social Media", Value = "4" });
            li2.Add(new SelectListItem { Text = "Website", Value = "5" });

            ViewData["ReferenceBy"] = li2;

            List<AccountSessionMaster> AccountsessionMaster = GetAccountSessionMasterSelectList();
            List<SelectListItem> AccountSessionMasterList = new List<SelectListItem>();
            foreach (AccountSessionMaster item in AccountsessionMaster)
            {
                AccountSessionMasterList.Add(new SelectListItem { Text = item.SessionName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.AccountSessionMasterList = new SelectList(AccountSessionMasterList, "Value", "Text");

            return PartialView("/Views/Sales/SalesEnquiryMasterAndDetails/CreateSalesEnquiry.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalesEnquiryMasterAndDetailsViewModel model)
        {
            try
            {

                if (model != null && model.SalesEnquiryMasterAndDetailsDTO != null)
                {
                    model.SalesEnquiryMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesEnquiryMasterAndDetailsDTO.CreatedBy              = Convert.ToInt32(Session["UserID"]);
                    model.SalesEnquiryMasterAndDetailsDTO.XmlString              = model.XmlString;
                    model.SalesEnquiryMasterAndDetailsDTO.CustomerMasterID       = model.CustomerMasterID; 
                    model.SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesEnquiryMasterAndDetailsDTO.ContactPersonID        = model.ContactPersonID; 
                    model.SalesEnquiryMasterAndDetailsDTO.ReferenceBy            = model.ReferenceBy;
                    model.SalesEnquiryMasterAndDetailsDTO.TransactionDate        = model.TransactionDate;

                    IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = _SalesEnquiryMasterAndDetailsBA.InsertSalesEnquiryMasterAndDetails(model.SalesEnquiryMasterAndDetailsDTO);
                    model.SalesEnquiryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                }
                return Json(model.SalesEnquiryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);



            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }

        }

        [HttpGet]
        public ActionResult Edit(string  SalesEnquiryMasterID, string CustomerMasterID,string CustomerBranchMasterID,string ContactPersonID,string CustomerMasterName,string CustomerContactPersonName,string CustomerBranchMasterName,string TransactionDate,string ReferenceBy)
        {
            SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();
            SalesEnquiryMasterAndDetailsSearchRequest searchRequest = new SalesEnquiryMasterAndDetailsSearchRequest();
            try
            {
                model.SalesEnquiryMasterAndDetailsDTO = new SalesEnquiryMasterAndDetails();

                List<SelectListItem> li2 = new List<SelectListItem>();
                //li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li2.Add(new SelectListItem { Text = "Email", Value = "1" });
                li2.Add(new SelectListItem { Text = "Phone", Value = "2" });
                li2.Add(new SelectListItem { Text = "LinkedIn", Value = "3" });
                li2.Add(new SelectListItem { Text = "Social Media", Value = "4" });
                li2.Add(new SelectListItem { Text = "Website", Value = "5" });

                ViewData["ReferenceBy"] = li2;


                model.SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID = Convert.ToInt32(!string.IsNullOrEmpty(SalesEnquiryMasterID) ? SalesEnquiryMasterID : null); ;
                model.SalesEnquiryMasterAndDetailsDTO.CustomerMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerMasterID) ? CustomerMasterID : null);
                model.SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterID = Convert.ToInt32(!string.IsNullOrEmpty(CustomerBranchMasterID) ? CustomerBranchMasterID : null);
                model.SalesEnquiryMasterAndDetailsDTO.ContactPersonID = Convert.ToInt16(!string.IsNullOrEmpty(ContactPersonID) ? ContactPersonID : null);
                model.SalesEnquiryMasterAndDetailsDTO.CustomerMasterName = CustomerMasterName;
                model.SalesEnquiryMasterAndDetailsDTO.CustomerBranchMasterName = Convert.ToString(!string.IsNullOrEmpty(CustomerBranchMasterName) ? CustomerBranchMasterName : "-"); 
                model.SalesEnquiryMasterAndDetailsDTO.CustomerContactPersonName = CustomerContactPersonName;
               
                model.SalesEnquiryMasterAndDetailsDTO.ReferenceBy = Convert.ToByte(!string.IsNullOrEmpty(ReferenceBy) ? ReferenceBy : null); ;


                ViewData["ReferenceBy"] = new SelectList(li2, "Value", "Text", (model.ReferenceBy).ToString().Trim());
                searchRequest.ConnectionString = _connectioString;
                searchRequest.SalesEnquiryMasterAndDetailsID = Convert.ToInt32(!string.IsNullOrEmpty(SalesEnquiryMasterID) ? SalesEnquiryMasterID : null); 

                IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollectionResponse = _SalesEnquiryMasterAndDetailsBA.GetEnquiryDetailsByID(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.ContactDetailsBySalesEnquiryMasterAndDetailsID = baseEntityCollectionResponse.CollectionResponse.ToList();
                        model.TransactionDate = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].TransactionDate;
                    }
                }




                return PartialView("/Views/Sales/SalesEnquiryMasterAndDetails/EditSalesEnquiry.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(SalesEnquiryMasterAndDetailsViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            if (model != null && model.SalesEnquiryMasterAndDetailsDTO != null)
            {
                if (model != null && model.SalesEnquiryMasterAndDetailsDTO != null)
                {
                    model.SalesEnquiryMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID = model.SalesEnquiryMasterID;
                    model.SalesEnquiryMasterAndDetailsDTO.XmlString = model.XmlString;

                    model.SalesEnquiryMasterAndDetailsDTO.ModifiedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = _SalesEnquiryMasterAndDetailsBA.UpdateSalesEnquiryMasterAndDetails(model.SalesEnquiryMasterAndDetailsDTO);
                    model.SalesEnquiryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);
                }
                //}
                return Json(model.SalesEnquiryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Please review your form");
            }
        }



        [HttpGet]
        public ActionResult ViewDetails(string SalesEnquiryMasterID)
        {
            SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();
            SalesEnquiryMasterAndDetailsSearchRequest searchRequest = new SalesEnquiryMasterAndDetailsSearchRequest();
            try
            {
                model.SalesEnquiryMasterAndDetailsDTO = new SalesEnquiryMasterAndDetails();

                List<SelectListItem> li2 = new List<SelectListItem>();
                //li2.Add(new SelectListItem { Text = "--Select--", Value = " " });
                li2.Add(new SelectListItem { Text = "Email", Value = "1" });
                li2.Add(new SelectListItem { Text = "Phone", Value = "2" });
                li2.Add(new SelectListItem { Text = "LinkedIn", Value = "3" });
                li2.Add(new SelectListItem { Text = "Social Media", Value = "4" });
                li2.Add(new SelectListItem { Text = "Website", Value = "5" });

                ViewData["ReferenceBy"] = li2;
                model.SalesEnquiryMasterAndDetailsDTO.SalesEnquiryMasterID = Convert.ToInt32(!string.IsNullOrEmpty(SalesEnquiryMasterID) ? SalesEnquiryMasterID : null); ;
               
                searchRequest.ConnectionString = _connectioString;
                searchRequest.SalesEnquiryMasterAndDetailsID = Convert.ToInt32(!string.IsNullOrEmpty(SalesEnquiryMasterID) ? SalesEnquiryMasterID : null);

                IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollectionResponse = _SalesEnquiryMasterAndDetailsBA.GetEnquiryDetailsByID(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.ContactDetailsBySalesEnquiryMasterAndDetailsID = baseEntityCollectionResponse.CollectionResponse.ToList();
                        model.CustomerBranchMasterID = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].CustomerBranchMasterID;
                        model.CustomerMasterID = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].CustomerMasterID;
                        model.TransactionDate = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].TransactionDate;
                        model.ReferenceBy = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].ReferenceBy; ;
                        model.CustomerMasterName= model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].CustomerMasterName;
                        model.CustomerBranchMasterName = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].CustomerBranchMasterName;
                        model.CustomerContactPersonName = model.ContactDetailsBySalesEnquiryMasterAndDetailsID[0].CustomerContactPersonName;
                    }
                }
                ViewData["ReferenceBy"] = new SelectList(li2, "Value", "Text", (model.ReferenceBy).ToString().Trim());
                return PartialView("/Views/Sales/SalesEnquiryMasterAndDetails/ViewSalesEnquiry.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int ID)
        {
            SalesEnquiryMasterAndDetailsViewModel model = new SalesEnquiryMasterAndDetailsViewModel();
            //if (!ModelState.IsValid)
            //{
            if (ID > 0)
            {
                SalesEnquiryMasterAndDetails SalesEnquiryMasterAndDetailsDTO = new SalesEnquiryMasterAndDetails();
                SalesEnquiryMasterAndDetailsDTO.ConnectionString = _connectioString;
                // SalesEnquiryMasterAndDetailsDTO.ID = ID;
                SalesEnquiryMasterAndDetailsDTO.DeletedBy = Convert.ToInt32(Session["UserID"]);
                IBaseEntityResponse<SalesEnquiryMasterAndDetails> response = _SalesEnquiryMasterAndDetailsBA.DeleteSalesEnquiryMasterAndDetails(SalesEnquiryMasterAndDetailsDTO);
                model.SalesEnquiryMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Delete);

            }
            return Json(model.SalesEnquiryMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("Please review your form");
            //}
        }


        [HttpPost]
        public JsonResult GetItemNumberSearchList(string term)
        {
            GeneralItemMasterSearchRequest searchRequest = new GeneralItemMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<GeneralItemMaster> listFeeSubType = new List<GeneralItemMaster>();
            IBaseEntityCollectionResponse<GeneralItemMaster> baseEntityCollectionResponse = _GeneralItemMasterBA.GetGeneralItemMasterSearchList(searchRequest);
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
                              ItemNumber = r.ItemNumber,
                              ItemDescription = r.ItemDescription,
                              GenTaxGroupMasterID= r.GenTaxGroupMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetUoMCodeByItemNumber(string ItemNumber)
        {

            var UOMCodeDesc = GetUoMCodeByItemNumberList(ItemNumber);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              name = s.UomCode,
                              
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryUoMMaster> GetUoMCodeByItemNumberList(string ItemNumber)
        {

            InventoryUoMMasterSearchRequest searchRequest = new InventoryUoMMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ItemNumber = Convert.ToInt32(ItemNumber);

            List<InventoryUoMMaster> listOrganisationDepartmentMaster = new List<InventoryUoMMaster>();
            IBaseEntityCollectionResponse<InventoryUoMMaster> baseEntityCollectionResponse = _InventoryUoMMasterBA.GetInventoryUoMMasterDropDownforSaleUomCode(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listOrganisationDepartmentMaster = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listOrganisationDepartmentMaster;
        }


        #endregion

        // Non-Action Method
        #region Methods


        protected List<GeneralCurrencyMaster> GetListGeneralCurrencyMaster()
        {
            GeneralCurrencyMasterSearchRequest searchRequest = new GeneralCurrencyMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            List<GeneralCurrencyMaster> ListGeneralCurrencyMaster = new List<GeneralCurrencyMaster>();
            IBaseEntityCollectionResponse<GeneralCurrencyMaster> baseEntityCollectionResponse = _GeneralCurrencyMasterBA.GetBySearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralCurrencyMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralCurrencyMaster;
        }

        public IEnumerable<SalesEnquiryMasterAndDetailsViewModel> GetSalesEnquiryMasterAndDetails(out int TotalRecords,string TransactionDate )
        {
            SalesEnquiryMasterAndDetailsSearchRequest searchRequest = new SalesEnquiryMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TransactionDate = TransactionDate;
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
                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "A.ModifiedDate";
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
            List<SalesEnquiryMasterAndDetailsViewModel> listSalesEnquiryMasterAndDetailsViewModel = new List<SalesEnquiryMasterAndDetailsViewModel>();
            List<SalesEnquiryMasterAndDetails> listSalesEnquiryMasterAndDetails = new List<SalesEnquiryMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesEnquiryMasterAndDetails> baseEntityCollectionResponse = _SalesEnquiryMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesEnquiryMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesEnquiryMasterAndDetails item in listSalesEnquiryMasterAndDetails)
                    {
                        SalesEnquiryMasterAndDetailsViewModel SalesEnquiryMasterAndDetailsViewModel = new SalesEnquiryMasterAndDetailsViewModel();
                        SalesEnquiryMasterAndDetailsViewModel.SalesEnquiryMasterAndDetailsDTO = item;
                        listSalesEnquiryMasterAndDetailsViewModel.Add(SalesEnquiryMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesEnquiryMasterAndDetailsViewModel;
        }
        #endregion

        // AjaxHandler Method
        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string TransactionDate)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesEnquiryMasterAndDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.ID";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EnquiryNumber Like '%" + param.sSearch + "%' or EnquiryNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.EnquiryNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = string.Empty;
                        }
                        else
                        {
                            _searchBy = "EnquiryNumber Like '%" + param.sSearch + "%' or EnquiryNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                        }
                        break;
                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                filteredCountryMaster = GetSalesEnquiryMasterAndDetails(out TotalRecords, TransactionDate);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.SalesEnquiryMasterID), Convert.ToString(c.SaleEnquiryDetailsID), Convert.ToString(c.CustomerMasterID),Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.ContactPersonID), Convert.ToString(c.Status) , Convert.ToString(c.StatusMode) , Convert.ToString(c.ReferenceBy), Convert.ToString(c.EnquiryNumber),Convert.ToString(c.CustomerMasterName), Convert.ToString(c.CustomerBranchMasterName), Convert.ToString(c.CustomerContactPersonName),Convert.ToString(c.SalesQuotationMasterID) };

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