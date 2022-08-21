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
using System.IO;
using System.Web.Hosting;
using System.Data;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf.parser;
using System.Web;
using iTextSharp.text.html;

namespace AERP.Web.UI.Controllers
{
    public class SalesCustomerRecieptController : BaseController
    {
        ISalesCustomerRecieptBA _SalesCustomerRecieptBA = null;
        //ICRMCallTypeBA _CRMCallTypeBA = null;
        IPurchaseRequisitionMasterBA _PurchaseRequisitionMasterBA = null;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        static string xmlParameter = null;
        static bool IsExcelValid = true;
        static string errorMessage = null;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SalesCustomerRecieptController()
        {
            _SalesCustomerRecieptBA = new SalesCustomerRecieptBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {
                SalesCustomerRecieptViewModel model = new SalesCustomerRecieptViewModel();
                return View("/Views/Sales/SalesCustomerReciept/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string TransactionFromDate, string TransactionUptoDate, SalesCustomerRecieptViewModel model)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/Sales/SalesCustomerReciept/List.cshtml", model);
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
            SalesCustomerRecieptViewModel model = new SalesCustomerRecieptViewModel();
            //Dropdown for centre
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

                List<AdminRoleApplicableDetails> listAdminRoleApplicableDetails = GetAdminRoleApplicableCentreByPurchaseManager(AdminRoleMasterID);
                AdminRoleApplicableDetails a = null;
                foreach (var item in listAdminRoleApplicableDetails)
                {
                    a = new AdminRoleApplicableDetails();
                    a.CentreCode = item.CentreCode;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
            }
            return PartialView("/Views/Sales/SalesCustomerReciept/Create.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(SalesCustomerRecieptViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                //if (ModelState.IsValid)
                {
                    model.SalesCustomerRecieptDTO.ConnectionString = _connectioString;
                    model.SalesCustomerRecieptDTO.PaidAmount = model.PaidAmount;
                    model.SalesCustomerRecieptDTO.XMLstring = model.XMLstring;
                    model.SalesCustomerRecieptDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SalesCustomerRecieptDTO.payementmode = model.payementmode;
                    model.SalesCustomerRecieptDTO.CentreCode = model.CentreCode;
                    model.SalesCustomerRecieptDTO.CreditAmount = model.CreditAmount;
                    model.SalesCustomerRecieptDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesCustomerRecieptDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesCustomerRecieptDTO.BankName = model.BankName;
                    model.SalesCustomerRecieptDTO.BranchName = model.BranchName;
                    model.SalesCustomerRecieptDTO.BankAddress = model.BankAddress;
                    model.SalesCustomerRecieptDTO.AccountNo = model.AccountNo;
                    model.SalesCustomerRecieptDTO.IFSCCode = model.IFSCCode;
                    model.SalesCustomerRecieptDTO.ChequeNumber = model.ChequeNumber;
                    model.SalesCustomerRecieptDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesCustomerReciept> response = _SalesCustomerRecieptBA.InsertSalesCustomerReciept(model.SalesCustomerRecieptDTO);
                    errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.SalesCustomerRecieptDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesCustomerRecieptDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpGet]
        public ActionResult ViewDetails(string InvoiceTrackingMasterID)
        {
            SalesCustomerRecieptViewModel model = new SalesCustomerRecieptViewModel();
            SalesCustomerRecieptSearchRequest searchRequest = new SalesCustomerRecieptSearchRequest();
            try
            {
                model.SalesCustomerRecieptDTO = new SalesCustomerReciept();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.InvoiceTrackingMasterID = Convert.ToInt32(!string.IsNullOrEmpty(InvoiceTrackingMasterID) ? InvoiceTrackingMasterID : null);

                IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollectionResponse = _SalesCustomerRecieptBA.GetRecordForPurchaseOrderPDF(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.ContactDetailsBySalesCustomerRecieptID = baseEntityCollectionResponse.CollectionResponse.ToList();
                        model.InvoiceTrackingMasterID = model.ContactDetailsBySalesCustomerRecieptID[0].InvoiceTrackingMasterID;
                        model.ChequeNumber = model.ContactDetailsBySalesCustomerRecieptID[0].ChequeNumber;
                        model.IFSCCode = model.ContactDetailsBySalesCustomerRecieptID[0].IFSCCode;
                        model.BankName = model.ContactDetailsBySalesCustomerRecieptID[0].BankName; ;
                        model.VoucherNumber = model.ContactDetailsBySalesCustomerRecieptID[0].VoucherNumber;
                        model.payementmode = model.ContactDetailsBySalesCustomerRecieptID[0].payementmode;
                        model.PaidInvoiceAmount = model.ContactDetailsBySalesCustomerRecieptID[0].PaidInvoiceAmount;
                        model.InvoiceNumber = model.ContactDetailsBySalesCustomerRecieptID[0].InvoiceNumber;
                        model.StatusFlag = model.ContactDetailsBySalesCustomerRecieptID[0].StatusFlag;
                        model.CustomerName = model.ContactDetailsBySalesCustomerRecieptID[0].CustomerName;
                        model.BranchName = model.ContactDetailsBySalesCustomerRecieptID[0].BranchName;
                        model.PaidAmount = model.ContactDetailsBySalesCustomerRecieptID[0].PaidAmount;
                        model.PayementModeType = model.ContactDetailsBySalesCustomerRecieptID[0].PayementModeType;

                    }
                }
                return PartialView("/Views/Sales/SalesCustomerReciept/ViewDetails.cshtml", model);
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected List<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(int id)
        {
            PurchaseRequisitionMasterSearchRequest searchRequest = new PurchaseRequisitionMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseRequisitionMaster> listPurchaseRequirementMaster = new List<PurchaseRequisitionMaster>();
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> baseEntityCollectionResponse = _PurchaseRequisitionMasterBA.GetPurchaseRequisitionMasterDetailLists(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseRequirementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseRequirementMaster;
        }

        public JsonResult GetCustomerWiseInvoiceDetailsForCustomerReciept(int CustomerMasterID, int CustomerBranchMasterID)
        {
            var data = GetCustomerWiseInvoiceDetailsForCustomerRecieptList(CustomerMasterID, CustomerBranchMasterID);
            var result = (from r in data
                          select new
                          {
                              InvoiceDate = r.InvoiceDate,
                              InvoiceNumber = r.InvoiceNumber,
                              SalesInvoiceMasterID = r.SalesInvoiceMasterID,
                              StatusFlag = r.StatusFlag,
                              InvoiceAmount = r.InvoiceAmount,
                              CreditAmount = r.CreditAmount,
                              CreatedBy= Convert.ToInt32(Session["UserID"])
        }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<SalesCustomerReciept> GetCustomerWiseInvoiceDetailsForCustomerRecieptList(int CustomerMasterID, int CustomerBranchMasterID)
        {
            SalesCustomerRecieptSearchRequest searchRequest = new SalesCustomerRecieptSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CustomerMasterID = CustomerMasterID;
            searchRequest.CustomerBranchMasterID = CustomerBranchMasterID;
            List<SalesCustomerReciept> listAccount = new List<SalesCustomerReciept>();
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollectionResponse = _SalesCustomerRecieptBA.GetCustomerWiseInvoiceDetailsForCustomerRecieptList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }
        #endregion


        #region ----------------------Methods----------------------

        public IEnumerable<SalesCustomerRecieptViewModel> GetSalesCustomerReciept(string TransactionFromDate, string TransactionUptoDate, out int TotalRecords)
        {
            SalesCustomerRecieptSearchRequest searchRequest = new SalesCustomerRecieptSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.TransactionFromDate = TransactionFromDate;
            searchRequest.TransactionUptoDate = TransactionUptoDate;

            _actionMode = Convert.ToString(TempData["ActionMode"]);
            if (Enum.TryParse(_actionMode, out actionModeEnum))     // checks actionMode i.e. Insert or Update // 
            {
                if (actionModeEnum == ActionModeEnum.Insert)        // parameters for SelectAll procedures under Insert or Update mode condition
                {
                    searchRequest.SortBy = "A.CreatedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";


                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "C.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
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
            List<SalesCustomerRecieptViewModel> listSalesCustomerRecieptViewModel = new List<SalesCustomerRecieptViewModel>();
            List<SalesCustomerReciept> listSalesCustomerReciept = new List<SalesCustomerReciept>();
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollectionResponse = _SalesCustomerRecieptBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesCustomerReciept = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesCustomerReciept item in listSalesCustomerReciept)
                    {
                        SalesCustomerRecieptViewModel SalesCustomerRecieptViewModel = new SalesCustomerRecieptViewModel();
                        SalesCustomerRecieptViewModel.SalesCustomerRecieptDTO = item;
                        listSalesCustomerRecieptViewModel.Add(SalesCustomerRecieptViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesCustomerRecieptViewModel;
        }

        [NonAction]
        protected List<SalesCustomerReciept> GetRecordForPurchaseOrderPDF(int CustomerMasterID)
        {
            SalesCustomerRecieptSearchRequest searchRequest = new SalesCustomerRecieptSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CustomerMasterID = CustomerMasterID;
            List<SalesCustomerReciept> listSalesCustomerReciept = new List<SalesCustomerReciept>();
            IBaseEntityCollectionResponse<SalesCustomerReciept> baseEntityCollectionResponse = _SalesCustomerRecieptBA.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesCustomerReciept = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalesCustomerReciept;
        }

        #endregion

        // AjaxHandler Method
        #region ------------------AjaxHandler----------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string TransactionFromDate, string TransactionUptoDate)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesCustomerRecieptViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "Concat(C.FirstName,' ',C.MiddleName,' ',C.LastName) " + sortDirection + " ,D.BranchName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "Concat(C.FirstName,' ',C.MiddleName,' ',C.LastName) like '%'";
                        }
                        else
                        {
                            _searchBy = "Concat(C.FirstName,' ',C.MiddleName,' ',C.LastName) Like '%" + param.sSearch + "%' or C.CustomerName Like '%" + param.sSearch + "%' or D.BranchName Like '%" + param.sSearch + "%' ";
                        }
                        break;
                    case 1:
                        _sortBy = "Concat(C.FirstName,' ',C.MiddleName,' ',C.LastName) " + sortDirection + " ,D.BranchName";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.VoucherNumber like '%'";
                        }
                        else
                        {

                            _searchBy = "A.VoucherNumber Like '%" + param.sSearch + "%' or Concat(C.FirstName,' ',C.MiddleName,' ',C.LastName) Like Like '%" + param.sSearch + "%' or D.BranchName Like '%" + param.sSearch + "%' ";
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<SalesCustomerRecieptViewModel>(); 

                if (!string.IsNullOrEmpty(TransactionFromDate))
                {
                    filteredCountryMaster = GetSalesCustomerReciept(TransactionFromDate, TransactionUptoDate, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<SalesCustomerRecieptViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.VoucherNumber), Convert.ToString(c.PaidAmount), Convert.ToString(c.payementmode), Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.CustomerName).Trim().Replace(",", "#"), Convert.ToString(c.BranchName).Trim().Replace(",", "#"), Convert.ToString(c.InvoiceTrackingMasterID), };

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