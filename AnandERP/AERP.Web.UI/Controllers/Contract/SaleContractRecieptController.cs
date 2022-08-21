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
    public class SaleContractRecieptController : BaseController
    {
        ISaleContractRecieptBA _SaleContractRecieptBA = null;
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

        public SaleContractRecieptController()
        {
            _SaleContractRecieptBA = new SaleContractRecieptBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0) && IsApplied == true))
            {
                SaleContractRecieptViewModel model = new SaleContractRecieptViewModel();
                return View("/Views/Contract/SaleContractReciept/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string TransactionFromDate, string TransactionUptoDate, SaleContractRecieptViewModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/Contract/SaleContractReciept/List.cshtml", model);
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
            SaleContractRecieptViewModel model = new SaleContractRecieptViewModel();
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
            return PartialView("/Views/Contract/SaleContractReciept/Create.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(SaleContractRecieptViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                //if (ModelState.IsValid)
                {
                    model.SaleContractRecieptDTO.ConnectionString = _connectioString;
                    model.SaleContractRecieptDTO.PaidAmount = model.PaidAmount;
                    model.SaleContractRecieptDTO.XMLstring = model.XMLstring;
                    model.SaleContractRecieptDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SaleContractRecieptDTO.payementmode = model.payementmode;
                    model.SaleContractRecieptDTO.CentreCode = model.CentreCode;
                    model.SaleContractRecieptDTO.CreditAmount = model.CreditAmount;
                    model.SaleContractRecieptDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SaleContractRecieptDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SaleContractRecieptDTO.BankName = model.BankName;
                    model.SaleContractRecieptDTO.BranchName = model.BranchName;
                    model.SaleContractRecieptDTO.BankAddress = model.BankAddress;
                    model.SaleContractRecieptDTO.AccountNo = model.AccountNo;
                    model.SaleContractRecieptDTO.IFSCCode = model.IFSCCode;
                    model.SaleContractRecieptDTO.ChequeNumber = model.ChequeNumber;
                    model.SaleContractRecieptDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractReciept> response = _SaleContractRecieptBA.InsertSaleContractReciept(model.SaleContractRecieptDTO);
                    errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.SaleContractRecieptDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SaleContractRecieptDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
            SaleContractRecieptViewModel model = new SaleContractRecieptViewModel();
            SaleContractRecieptSearchRequest searchRequest = new SaleContractRecieptSearchRequest();
            try
            {
                model.SaleContractRecieptDTO = new SaleContractReciept();

                searchRequest.ConnectionString = _connectioString;
                searchRequest.InvoiceTrackingMasterID = Convert.ToInt32(!string.IsNullOrEmpty(InvoiceTrackingMasterID) ? InvoiceTrackingMasterID : null);

                IBaseEntityCollectionResponse<SaleContractReciept> baseEntityCollectionResponse = _SaleContractRecieptBA.GetRecordForPurchaseOrderPDF(searchRequest);

                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        model.ContactDetailsBySaleContractRecieptID = baseEntityCollectionResponse.CollectionResponse.ToList();
                        model.InvoiceTrackingMasterID = model.ContactDetailsBySaleContractRecieptID[0].InvoiceTrackingMasterID;
                        model.ChequeNumber = model.ContactDetailsBySaleContractRecieptID[0].ChequeNumber;
                        model.IFSCCode = model.ContactDetailsBySaleContractRecieptID[0].IFSCCode;
                        model.BankName = model.ContactDetailsBySaleContractRecieptID[0].BankName; ;
                        model.VoucherNumber = model.ContactDetailsBySaleContractRecieptID[0].VoucherNumber;
                        model.payementmode = model.ContactDetailsBySaleContractRecieptID[0].payementmode;
                        model.PaidInvoiceAmount = model.ContactDetailsBySaleContractRecieptID[0].PaidInvoiceAmount;
                        model.InvoiceNumber = model.ContactDetailsBySaleContractRecieptID[0].InvoiceNumber;
                        model.StatusFlag = model.ContactDetailsBySaleContractRecieptID[0].StatusFlag;
                        model.CustomerName = model.ContactDetailsBySaleContractRecieptID[0].CustomerName;
                        model.BranchName = model.ContactDetailsBySaleContractRecieptID[0].BranchName;
                        model.PaidAmount = model.ContactDetailsBySaleContractRecieptID[0].PaidAmount;
                        model.PayementModeType = model.ContactDetailsBySaleContractRecieptID[0].PayementModeType;

                    }
                }
                return PartialView("/Views/Contract/SaleContractReciept/ViewDetails.cshtml", model);
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

        public JsonResult GetCustomerWiseContractDetailsForReciept(int CustomerMasterID,int CustomerBranchMasterID,int ContractMasterID,int SaleContractBillingSpanID)
        {
            var data = GetCustomerWiseContractDetailsForRecieptList(CustomerMasterID, CustomerBranchMasterID, ContractMasterID, SaleContractBillingSpanID);
            var result = (from r in data
                          select new
                          {
                              ContractNumber = r.ContractNumber,
                              ContractBillingSpan = r.ContractBillingSpan,
                              SaleContractMasterID = r.SaleContractMasterID,
                              StatusFlag = r.StatusFlag,
                              ContractAmount = r.ContractAmount,
                              CreditAmount = r.CreditAmount,
                              SaleContractBillingSpanID = r.SaleContractBillingSpanID,
                              CreatedBy = Convert.ToInt32(Session["UserID"]),
                              InvoiceNumber=r.InvoiceNumber,
                              CustomerMainBranchMasterID=r.CustomerMainBranchMasterID
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<SaleContractReciept> GetCustomerWiseContractDetailsForRecieptList(int CustomerMasterID,int CustomerBranchMasterID,int ContractMasterID, int SaleContractBillingSpanID)
        {
            SaleContractRecieptSearchRequest searchRequest = new SaleContractRecieptSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CustomerMasterID = CustomerMasterID;
            searchRequest.CustomerBranchMasterID = CustomerBranchMasterID;
            searchRequest.ContractMasterID = ContractMasterID;
            searchRequest.SaleContractBillingSpanID = SaleContractBillingSpanID;
            List<SaleContractReciept> listAccount = new List<SaleContractReciept>();
            IBaseEntityCollectionResponse<SaleContractReciept> baseEntityCollectionResponse = _SaleContractRecieptBA.GetCustomerWiseContractDetailsForReciept(searchRequest);
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

        public IEnumerable<SaleContractRecieptViewModel> GetSaleContractReciept(string TransactionFromDate, string TransactionUptoDate, out int TotalRecords)
        {
            SaleContractRecieptSearchRequest searchRequest = new SaleContractRecieptSearchRequest();
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
            List<SaleContractRecieptViewModel> listSaleContractRecieptViewModel = new List<SaleContractRecieptViewModel>();
            List<SaleContractReciept> listSaleContractReciept = new List<SaleContractReciept>();
            IBaseEntityCollectionResponse<SaleContractReciept> baseEntityCollectionResponse = _SaleContractRecieptBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractReciept = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SaleContractReciept item in listSaleContractReciept)
                    {
                        SaleContractRecieptViewModel SaleContractRecieptViewModel = new SaleContractRecieptViewModel();
                        SaleContractRecieptViewModel.SaleContractRecieptDTO = item;
                        listSaleContractRecieptViewModel.Add(SaleContractRecieptViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSaleContractRecieptViewModel;
        }

        [NonAction]
        protected List<SaleContractReciept> GetRecordForPurchaseOrderPDF(int CustomerMasterID)
        {
            SaleContractRecieptSearchRequest searchRequest = new SaleContractRecieptSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CustomerMasterID = CustomerMasterID;
            List<SaleContractReciept> listSaleContractReciept = new List<SaleContractReciept>();
            IBaseEntityCollectionResponse<SaleContractReciept> baseEntityCollectionResponse = _SaleContractRecieptBA.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractReciept = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractReciept;
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

                IEnumerable<SaleContractRecieptViewModel> filteredCountryMaster;
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
                //filteredCountryMaster = new List<SaleContractRecieptViewModel>(); 

                if (!string.IsNullOrEmpty(TransactionFromDate))
                {
                    filteredCountryMaster = GetSaleContractReciept(TransactionFromDate, TransactionUptoDate, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<SaleContractRecieptViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.VoucherNumber),Convert.ToString(c.PaidAmount),Convert.ToString(c.payementmode), Convert.ToString(c.CustomerMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.CustomerName), Convert.ToString(c.BranchName), Convert.ToString(c.InvoiceTrackingMasterID), };

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