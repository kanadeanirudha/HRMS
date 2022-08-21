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
    public class SaleContractPayementController : BaseController
    {
        ISaleContractPayementBA _SaleContractPayementBA = null;
        //ICRMCallTypeBA _CRMCallTypeBA = null;
        ISaleContractMasterBA _SaleContractMasterBA = null;
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

        public SaleContractPayementController()
        {
            _SaleContractPayementBA = new SaleContractPayementBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _SaleContractMasterBA = new SaleContractMasterBA();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0) && IsApplied == true))
            {
                SaleContractPayementViewModel model = new SaleContractPayementViewModel();
                return View("/Views/Contract/SaleContractPayement/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string PurchaseOrderType, SaleContractPayementViewModel model)
        {
            try
            {
                int AdminRoleID = 0;
                if (Session["RoleID"] == null)
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }

                return PartialView("/Views/Contract/SaleContractPayement/List.cshtml", model);
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
            SaleContractPayementViewModel model = new SaleContractPayementViewModel();
            return PartialView("/Views/Contract/SaleContractPayement/Create.cshtml", model);
        }


        [HttpPost]
        public ActionResult Create(SaleContractPayementViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
               // if (ModelState.IsValid)
                {
                    model.SaleContractPayementDTO.ConnectionString = _connectioString;
                    model.SaleContractPayementDTO.PaidAmount = model.PaidAmount;
                    model.SaleContractPayementDTO.XMLstring = model.XMLstring;
                    model.SaleContractPayementDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SaleContractPayementDTO.payementmode = model.payementmode;
                    model.SaleContractPayementDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SaleContractPayementDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SaleContractPayementDTO.ContractMasterID = model.ContractMasterID;
                    model.SaleContractPayementDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;

                    model.SaleContractPayementDTO.BankName = model.BankName;
                    model.SaleContractPayementDTO.BranchName = model.BranchName;
                    model.SaleContractPayementDTO.BankAddress = model.BankAddress;
                    model.SaleContractPayementDTO.AccountNo = model.AccountNo;
                    model.SaleContractPayementDTO.IFSCCode = model.IFSCCode;
                    model.SaleContractPayementDTO.ChequeNumber = model.ChequeNumber;
                    model.SaleContractPayementDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractPayement> response = _SaleContractPayementBA.InsertSaleContractPayement(model.SaleContractPayementDTO);
                    errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.SaleContractPayementDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SaleContractPayementDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      

        public JsonResult GetSaleContractEmployeeByBillingSpanForPayement(int SaleContractBillingSpanID)
        {
            var data = GetSaleContractEmployeeByBillingSpanForPayementList(SaleContractBillingSpanID);
            var result = (from r in data
                          select new
                          {
                              SaleContractEmployeeMasterID = r.SaleContractEmployeeMasterID,
                              NetPayable = r.NetPayable,
                              SaleContractBillingSpanID = r.SaleContractBillingSpanID,
                              ContractEmployeeName=r.ContractEmployeeName,
                              CreatedBy=Convert.ToInt32(Session["UserID"]),
                              BankAccountFlag=r.BankAccountFlag
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<SaleContractPayement> GetSaleContractEmployeeByBillingSpanForPayementList(int SaleContractBillingSpanID)
        {
            SaleContractPayementSearchRequest searchRequest = new SaleContractPayementSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractBillingSpanID = SaleContractBillingSpanID;
            List<SaleContractPayement> listAccount = new List<SaleContractPayement>();
            IBaseEntityCollectionResponse<SaleContractPayement> baseEntityCollectionResponse = _SaleContractPayementBA.GetSaleContractEmployeeByBillingSpanForPayement(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listAccount = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listAccount;
        }

        //Sale contract Number Searchlist

        [HttpPost]
        public JsonResult GetContractNumberSearchListByCustomer(string term,int CustomerMasterID,int CustomerBranchMasterID)
        {
            SaleContractMasterSearchRequest searchRequest = new SaleContractMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            searchRequest.CustomerMasterID = CustomerMasterID;
            searchRequest.CustomerBranchMasterID = CustomerBranchMasterID;
            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }
            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            searchRequest.AdminRoleID = AdminRoleID;
            List<SaleContractMaster> listCustomerMaster = new List<SaleContractMaster>();
            IBaseEntityCollectionResponse<SaleContractMaster> baseEntityCollectionResponse = _SaleContractMasterBA.GetContractNumberSearchListByCustomer(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCustomerMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            var result = (from r in listCustomerMaster
                          select new
                          {
                              ContractMasterID= r.ID,
                              ContractNumber = r.ContractNumber,
                             

                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion


        #region ----------------------Methods----------------------

        public IEnumerable<SaleContractPayementViewModel> GetSaleContractPayement(string PurchaseOrderType, int AdminRoleID, out int TotalRecords)
        {
            SaleContractPayementSearchRequest searchRequest = new SaleContractPayementSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
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
            List<SaleContractPayementViewModel> listSaleContractPayementViewModel = new List<SaleContractPayementViewModel>();
            List<SaleContractPayement> listSaleContractPayement = new List<SaleContractPayement>();
            IBaseEntityCollectionResponse<SaleContractPayement> baseEntityCollectionResponse = _SaleContractPayementBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractPayement = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SaleContractPayement item in listSaleContractPayement)
                    {
                        SaleContractPayementViewModel SaleContractPayementViewModel = new SaleContractPayementViewModel();
                        SaleContractPayementViewModel.SaleContractPayementDTO = item;
                        listSaleContractPayementViewModel.Add(SaleContractPayementViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSaleContractPayementViewModel;
        }

        [NonAction]
        protected List<SaleContractPayement> GetRecordForPurchaseOrderPDF(int CustomerMasterID)
        {
            SaleContractPayementSearchRequest searchRequest = new SaleContractPayementSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CustomerMasterID = CustomerMasterID;
            List<SaleContractPayement> listSaleContractPayement = new List<SaleContractPayement>();
            IBaseEntityCollectionResponse<SaleContractPayement> baseEntityCollectionResponse = _SaleContractPayementBA.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractPayement = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractPayement;
        }

        #endregion

        // AjaxHandler Method
        #region ------------------AjaxHandler----------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string PurchaseOrderType, int AdminRoleID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SaleContractPayementViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.Vender " + sortDirection + " ,A.PurchaseOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.VendorInvoiceNumber Like '%" + param.sSearch + "%'or A.Vender Like '%" + param.sSearch + "%' ";      //this "if" block is added for search functionality
                            //_searchBy = "A.PurchaseRequisitionNumber like Like '%" + param.sSearch + "%' or A.PurchaseRequisitionNumber Like '%" + param.sSearch + "%' or A.Vendor Like '%'";        //this "if" block is added for search functionality
                        }
                        break;
                    case 1:
                        _sortBy = "A.Vender " + sortDirection + " ,A.PurchaseOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.VendorInvoiceNumber Like '%" + param.sSearch + "%'or A.Vender Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.PurchaseOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.PurchaseOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.PurchaseOrderNumber Like '%" + param.sSearch + "%' or A.VendorInvoiceNumber Like '%" + param.sSearch + "%' or A.Vender Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<SaleContractPayementViewModel>(); 

                if (!string.IsNullOrEmpty(PurchaseOrderType))
                {
                    filteredCountryMaster = GetSaleContractPayement(PurchaseOrderType, AdminRoleID, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<SaleContractPayementViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID) };

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