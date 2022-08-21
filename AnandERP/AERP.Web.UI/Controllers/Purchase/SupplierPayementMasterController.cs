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
    public class SupplierPayementMasterController : BaseController
    {
        ISupplierPayementMasterBA _SupplierPayementMasterBA = null;
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

        public SupplierPayementMasterController()
        {
            _SupplierPayementMasterBA = new SupplierPayementMasterBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                SupplierPayementMasterViewModel model = new SupplierPayementMasterViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
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
                return View("/Views/Purchase/SupplierPayementMaster/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string PurchaseOrderType, SupplierPayementMasterViewModel model)
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
               
                return PartialView("/Views/Purchase/SupplierPayementMaster/List.cshtml", model);
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
            SupplierPayementMasterViewModel model = new SupplierPayementMasterViewModel();
            

          

            return PartialView("/Views/Purchase/SupplierPayementMaster/Create.cshtml", model);
        }

    
        [HttpPost]
        public ActionResult Create(SupplierPayementMasterViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                //if (ModelState.IsValid)
                {
                    model.SupplierPayementMasterDTO.ConnectionString = _connectioString;
                    model.SupplierPayementMasterDTO.PaidAmount = model.PaidAmount;
                    model.SupplierPayementMasterDTO.XMLstring = model.XMLstring;
                    model.SupplierPayementMasterDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SupplierPayementMasterDTO.payementmode = model.payementmode;
                    model.SupplierPayementMasterDTO.CentreCode = model.CentreCode;
                    model.SupplierPayementMasterDTO.CreditAmount = model.CreditAmount;
                    model.SupplierPayementMasterDTO.VendorId = model.VendorId;
                    model.SupplierPayementMasterDTO.BankName = model.BankName;
                    model.SupplierPayementMasterDTO.BranchName = model.BranchName;
                    model.SupplierPayementMasterDTO.BankAddress = model.BankAddress;
                    model.SupplierPayementMasterDTO.AccountNo = model.AccountNo;
                    model.SupplierPayementMasterDTO.IFSCCode = model.IFSCCode;
                    model.SupplierPayementMasterDTO.ChequeNumber = model.ChequeNumber;

                    model.SupplierPayementMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SupplierPayementMaster> response = _SupplierPayementMasterBA.InsertSupplierPayementMaster(model.SupplierPayementMasterDTO);
                    errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.SupplierPayementMasterDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SupplierPayementMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public FileStreamResult Download(int id)
        {
            SupplierPayementMasterViewModel model = new SupplierPayementMasterViewModel();
            try
            {
                model.SupplierPayementMasterDTO = new SupplierPayementMaster();
                model.SupplierPayementMasterDTO.ID = id;
                model.SupplierPayementMasterDTO.ConnectionString = _connectioString;
                decimal amount1 = 0; int itemcount = 0; decimal taxamount1 = 0; decimal totalamount = 0; decimal Grossamount = 0;
                //Code For Generate PDF
                //model.PurchaseOrderList = GetRecordForPurchaseOrderPDF(id);
                string PurchasePDF = " ";
                PurchasePDF = PurchasePDF + "<html><body><h1 style='text-align:center;' ><b> Purchase Order</b></h1><br></body></html>";

                PurchasePDF = PurchasePDF + "<table><tr><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%' ><tr><th>Authorized By</th></tr><tr><td> ___________________</td></tr></table><td width='50%'>";
                PurchasePDF = PurchasePDF + "<table style='width:50%' ><tr><th>Date</th></tr><tr><td> ___________________</td></tr></table></td></tr></table>";
                DownloadPDF1(PurchasePDF);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DownloadPDF1(string PurchasePDF)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "Purchase-OrderPDF.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(PurchasePDF));
            Response.End();
        }
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);

            // 3: we create a worker parse the document
            HTMLWorker htmlWorker = new HTMLWorker(doc);

            // 4: we open document and start the worker on the document
            doc.Open();
            htmlWorker.StartDocument();

            // 5: parse the html into the document
            htmlWorker.Parse(txtReader);

            // 6: close the document and the worker
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();

            bPDF = ms.ToArray();

            return bPDF;
        }
        public FileResult Download()
        {
            string FileName = "CallEnquiryExcelFile.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
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

        public JsonResult GetVendorWiseInvoiceDetails(int VendorID)
        {
            var data = GetVendorWiseInvoiceDetailsList(VendorID);
            var result = (from r in data
                          select new
                          {
                              InvoiceNumber = r.InvoiceNumber,
                              InvoiceDate=r.InvoiceDate,
                              PurchaseInvoiceMasterID=r.PurchaseInvoiceMasterID,
                              StatusFlag= r.StatusFlag,
                              InvoiceAmount=r.InvoiceAmount,
                              CreatedBy= Convert.ToInt32(Session["UserID"]),
                              BankAddress=r.BankAddress,
                              BankName=r.BankName,
                              IFSCCode=r.IFSCCode,
                              BranchName=r.BranchName,
                              AccountNo=r.AccountNo
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public List<SupplierPayementMaster> GetVendorWiseInvoiceDetailsList(int VendorID)
        {
            SupplierPayementMasterSearchRequest searchRequest = new SupplierPayementMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.VendorId = VendorID;
            List<SupplierPayementMaster> listAccount = new List<SupplierPayementMaster>();
            IBaseEntityCollectionResponse<SupplierPayementMaster> baseEntityCollectionResponse = _SupplierPayementMasterBA.GetVendorWiseInvoiceDetailsForPayement(searchRequest);
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

        public IEnumerable<SupplierPayementMasterViewModel> GetSupplierPayementMaster(string PurchaseOrderType, int AdminRoleID, out int TotalRecords)
        {
            SupplierPayementMasterSearchRequest searchRequest = new SupplierPayementMasterSearchRequest();
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
            List<SupplierPayementMasterViewModel> listSupplierPayementMasterViewModel = new List<SupplierPayementMasterViewModel>();
            List<SupplierPayementMaster> listSupplierPayementMaster = new List<SupplierPayementMaster>();
            IBaseEntityCollectionResponse<SupplierPayementMaster> baseEntityCollectionResponse = _SupplierPayementMasterBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSupplierPayementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SupplierPayementMaster item in listSupplierPayementMaster)
                    {
                        SupplierPayementMasterViewModel SupplierPayementMasterViewModel = new SupplierPayementMasterViewModel();
                        SupplierPayementMasterViewModel.SupplierPayementMasterDTO = item;
                        listSupplierPayementMasterViewModel.Add(SupplierPayementMasterViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSupplierPayementMasterViewModel;
        }

        [NonAction]
        protected List<SupplierPayementMaster> GetRecordForPurchaseOrderPDF(int id)
        {
            SupplierPayementMasterSearchRequest searchRequest = new SupplierPayementMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<SupplierPayementMaster> listSupplierPayementMaster = new List<SupplierPayementMaster>();
            IBaseEntityCollectionResponse<SupplierPayementMaster> baseEntityCollectionResponse = _SupplierPayementMasterBA.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSupplierPayementMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSupplierPayementMaster;
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

                IEnumerable<SupplierPayementMasterViewModel> filteredCountryMaster;
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
                //filteredCountryMaster = new List<SupplierPayementMasterViewModel>(); 

                if (!string.IsNullOrEmpty(PurchaseOrderType))
                {
                    filteredCountryMaster = GetSupplierPayementMaster(PurchaseOrderType, AdminRoleID, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<SupplierPayementMasterViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.ID)};

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