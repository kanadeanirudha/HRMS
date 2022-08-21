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
    public class PurchaseInvoiceController : BaseController
    {
        IPurchaseInvoiceBA _PurchaseInvoiceBA = null;
        //ICRMCallTypeBA _CRMCallTypeBA = null;
        IPurchaseRequisitionMasterBA _PurchaseRequisitionMasterBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
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

        public PurchaseInvoiceController()
        {
            _PurchaseInvoiceBA = new PurchaseInvoiceBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();
             _GeneralUnitsBA = new GeneralUnitsBA();
             _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            if (Convert.ToString(Session["UserType"]) == "A" || Convert.ToInt32(Session["Purchase Manager"]) > 0 || Convert.ToInt32(Session["Purchase Manager:Entity"]) > 0)
            {
                PurchaseInvoiceViewModel model = new PurchaseInvoiceViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                List<SelectListItem> li = new List<SelectListItem>();
                //li.Add(new SelectListItem { Text = "--Select--", Value = " " });
                //li.Add(new SelectListItem { Text = "Sub Contracting Requisition", Value = "1" });
                //li.Add(new SelectListItem { Text = "Consignment Requision", Value = "2" });\
                li.Add(new SelectListItem { Text = "Standard Requisition", Value = "5" });
                //li.Add(new SelectListItem { Text = "Stock Transfer Order", Value = "3" });
                //li.Add(new SelectListItem { Text = "Service Requisition", Value = "4" });


                ViewData["PurchaseOrderType"] = li;
                return View("/Views/Purchase/PurchaseInvoice/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string PurchaseOrderType, PurchaseInvoiceViewModel model)
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
                model.AdminRoleID = AdminRoleID;
                return PartialView("/Views/Purchase/PurchaseInvoice/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int PurchaseGRNMasterID, string Vendor, string PurchaseOrderTypeDescription, int VendorID, Int16 PurchaseOrderType, int PurchaseOrderMasterID)
        {
            PurchaseInvoiceViewModel model = new PurchaseInvoiceViewModel();
            model.PurchaseGRNMasterID = PurchaseGRNMasterID;
            //model.Vendor = Vendor;
            model.PurchaseOrderTypeDescription = PurchaseOrderTypeDescription;
            model.VendorID = VendorID;
            model.PurchaseOrderType = PurchaseOrderType;
            //model.VendorName = Vendor;
            model.PurchaseOrderMasterID = PurchaseOrderMasterID;
            PurchaseInvoiceSearchRequest searchRequest = new PurchaseInvoiceSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.PurchaseGRNMasterID = PurchaseGRNMasterID;
            searchRequest.PurchaseOrderType = PurchaseOrderType;
            searchRequest.PurchaseOrderMasterID = PurchaseOrderMasterID;
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollectionResponse = _PurchaseInvoiceBA.SelectByPurchaseGRNMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.PurchaseRequisitionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.VendorName = model.PurchaseRequisitionList[0].VendorName;
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.StorageLocationID = model.PurchaseRequisitionList[0].StorageLocationID;

            return PartialView("/Views/Purchase/PurchaseInvoice/Create.cshtml", model);
        }
        [HttpGet]
        public ActionResult CreatePurchaseInvoice(string CentreCode, string GeneralUnitsID)
        {
            PurchaseInvoiceViewModel model = new PurchaseInvoiceViewModel();
            
            model.GeneralUnitsID = Convert.ToInt16(GeneralUnitsID);
            model.SelectedCentreCode = CentreCode;
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
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
                    a.CentreCode = item.CentreCode + ":" + item.ScopeIdentity;
                    a.CentreName = item.CentreName;
                    // a.ScopeIdentity = item.ScopeIdentity;
                    model.ListGetAdminRoleApplicableCentre.Add(a);
                }
            }
            if (!string.IsNullOrEmpty(CentreCode))
            {
                string[] splitCentreCode = CentreCode.Split(':');
                model.SelectedCentreCode = splitCentreCode[0];
            }
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(model.SelectedCentreCode);
            model.ListInventoryLocationMaster = GetInventoryStorageLocationMasterList(model.SelectedCentreCode,Convert.ToString(model.GeneralUnitsID));
            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
          
            return PartialView("/Views/Purchase/PurchaseInvoice/CreatePurchaseInvoice.cshtml", model);
        }


        [HttpGet]
        public ActionResult ViewPurchaseInvoice(int PurchaseGRNMasterID, string Vendor, string PurchaseOrderTypeDescription, int VendorID, Int16 PurchaseOrderType, int PurchaseOrderMasterID)
        {
            PurchaseInvoiceViewModel model = new PurchaseInvoiceViewModel();
            model.PurchaseGRNMasterID = PurchaseGRNMasterID;
            //model.Vendor = Vendor;
            model.PurchaseOrderTypeDescription = PurchaseOrderTypeDescription;
            model.VendorID = VendorID;
            model.PurchaseOrderType = PurchaseOrderType;
            //  model.VendorName = Vendor;
            model.PurchaseOrderMasterID = PurchaseOrderMasterID;
            PurchaseInvoiceSearchRequest searchRequest = new PurchaseInvoiceSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.PurchaseGRNMasterID = PurchaseGRNMasterID;
            searchRequest.PurchaseOrderType = PurchaseOrderType;
            searchRequest.PurchaseOrderMasterID = PurchaseOrderMasterID;
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollectionResponse = _PurchaseInvoiceBA.SelectByPurchaseGRNMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.PurchaseRequisitionList = baseEntityCollectionResponse.CollectionResponse.ToList();
                    model.VendorName = model.PurchaseRequisitionList[0].VendorName;
                    model.VendorInvoiceNo = model.PurchaseRequisitionList[0].VendorInvoiceNo;
                }
            }

            return PartialView("/Views/Purchase/PurchaseInvoice/ViewPurchaseInvoice.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(PurchaseInvoiceViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.PurchaseInvoiceDTO.ConnectionString = _connectioString;
                    model.PurchaseInvoiceDTO.PurchaseGRNMasterID = model.PurchaseGRNMasterID;
                    model.PurchaseInvoiceDTO.PurchaseOrderMasterID = model.PurchaseOrderMasterID;
                    model.PurchaseInvoiceDTO.PurchaseOrderType = model.PurchaseOrderType;
                    model.PurchaseInvoiceDTO.VendorID = model.VendorID;
                    model.PurchaseInvoiceDTO.VendorInvoiceNo = model.VendorInvoiceNo;
                    model.PurchaseInvoiceDTO.StorageLocationID = model.StorageLocationID;
                    model.PurchaseInvoiceDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.PurchaseInvoiceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseInvoice> response = _PurchaseInvoiceBA.InsertPurchaseInvoice(model.PurchaseInvoiceDTO);
                    //errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    //return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.PurchaseInvoiceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseInvoiceDTO.errorMessage, JsonRequestBehavior.AllowGet);

                }
                return Json("Please review your form");
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult CreateManualInvoice(PurchaseInvoiceViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.PurchaseInvoiceDTO.ConnectionString = _connectioString;
                    model.PurchaseInvoiceDTO.VendorID = model.VendorID;
                    model.PurchaseInvoiceDTO.StorageLocationID = model.StorageLocationID;
                    model.PurchaseInvoiceDTO.Freight = model.Freight;
                    model.PurchaseInvoiceDTO.ShippingHandling = model.ShippingHandling;
                    model.PurchaseInvoiceDTO.Discount = model.Discount;
                    model.PurchaseInvoiceDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.PurchaseInvoiceDTO.TotalInvoiceAmount = model.TotalInvoiceAmount;
                    model.PurchaseInvoiceDTO.Amount = model.Amount;
                    model.PurchaseInvoiceDTO.XmlStringForDirectinvoiceVoucher = model.XmlStringForDirectinvoiceVoucher;
                    model.PurchaseInvoiceDTO.PurchaseDetailsXML = model.PurchaseDetailsXML;
                    model.PurchaseInvoiceDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<PurchaseInvoice> response = _PurchaseInvoiceBA.InsertManualPurchaseInvoice(model.PurchaseInvoiceDTO);
                    model.PurchaseInvoiceDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.PurchaseInvoiceDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
            PurchaseInvoiceViewModel model = new PurchaseInvoiceViewModel();
            try
            {
                model.PurchaseInvoiceDTO = new PurchaseInvoice();
                model.PurchaseInvoiceDTO.ID = id;
                model.PurchaseInvoiceDTO.ConnectionString = _connectioString;
                decimal amount1 = 0; int itemcount = 0; decimal taxamount1 = 0; decimal totalamount = 0; decimal Grossamount = 0;
                //Code For Generate PDF
                model.PurchaseOrderList = GetRecordForPurchaseOrderPDF(id);
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
        protected List<GeneralUnits> GetGeneralUnitsForItemmaster(string CentreCode)
        {
            GeneralUnitsSearchRequest searchRequest = new GeneralUnitsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            List<GeneralUnits> ListGeneralUnits = new List<GeneralUnits>();
            IBaseEntityCollectionResponse<GeneralUnits> baseEntityCollectionResponse = new BaseEntityCollectionResponse<GeneralUnits>();

            if (Convert.ToInt32(Session["Store Manager"]) > 0 || Convert.ToString(Session["UserType"]) == "A")
            {
                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchList(searchRequest);
            }
            else if (Convert.ToInt32(Session["Store Manager:Entity"]) > 0)
            {
                if (Session["RoleID"] == null)
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
                }

                else
                {
                    searchRequest.AdminRoleMasterID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
                }

                baseEntityCollectionResponse = _GeneralUnitsBA.GetGeneralUnitsSearchListByAdminRoleIDAndCentre(searchRequest);
            }

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    ListGeneralUnits = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return ListGeneralUnits;
        }

        //Drop down of Location Depends on Its Centre and units
        public ActionResult GetInventoryStorageLocationMasterListByCentreCodeandUnitsID(string CentreCode,string GeneralUnitsID)
        {

            string[] accnmArray = CentreCode.Split(':');
            CentreCode = Convert.ToString(accnmArray[0]);
            var UOMCodeDesc = GetInventoryStorageLocationMasterList(CentreCode, GeneralUnitsID);
            var result = (from s in UOMCodeDesc
                          select new
                          {
                              id = s.ID,
                              name = s.LocationName,
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected List<InventoryLocationMaster> GetInventoryStorageLocationMasterList(string CentreCode,string GeneralUnitsID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.GeneralUnitsID = Convert.ToInt16(GeneralUnitsID);
            searchRequest.CentreCode = CentreCode;
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryStorageLocationByCentreCodeAndUnitsID(searchRequest);
            //IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        //Drop down code ends here


        //DropDown List For Location
        [NonAction]
        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = Convert.ToInt16(AdminRoleID);
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            //IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterSearchList(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }
        #endregion


        #region ----------------------Methods----------------------

        public IEnumerable<PurchaseInvoiceViewModel> GetPurchaseInvoice(string PurchaseOrderType, int AdminRoleID, out int TotalRecords)
        {
            PurchaseInvoiceSearchRequest searchRequest = new PurchaseInvoiceSearchRequest();
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
                    searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                    searchRequest.AdminRoleID = AdminRoleID;

                }
                if (actionModeEnum == ActionModeEnum.Update)
                {
                    searchRequest.SortBy = "C.ModifiedDate";
                    searchRequest.StartRow = 0;
                    searchRequest.EndRow = 10;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = "Desc";
                    searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                    searchRequest.AdminRoleID = AdminRoleID;
                }
            }
            else
            {
                searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition
                searchRequest.StartRow = _startRow;
                searchRequest.EndRow = _startRow + _rowLength;
                searchRequest.SearchBy = _searchBy;
                searchRequest.SortDirection = _sortDirection;
                searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
                searchRequest.AdminRoleID = AdminRoleID;
            }
            List<PurchaseInvoiceViewModel> listPurchaseInvoiceViewModel = new List<PurchaseInvoiceViewModel>();
            List<PurchaseInvoice> listPurchaseInvoice = new List<PurchaseInvoice>();
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollectionResponse = _PurchaseInvoiceBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseInvoice = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (PurchaseInvoice item in listPurchaseInvoice)
                    {
                        PurchaseInvoiceViewModel PurchaseInvoiceViewModel = new PurchaseInvoiceViewModel();
                        PurchaseInvoiceViewModel.PurchaseInvoiceDTO = item;
                        listPurchaseInvoiceViewModel.Add(PurchaseInvoiceViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listPurchaseInvoiceViewModel;
        }

        [NonAction]
        protected List<PurchaseInvoice> GetRecordForPurchaseOrderPDF(int id)
        {
            PurchaseInvoiceSearchRequest searchRequest = new PurchaseInvoiceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<PurchaseInvoice> listPurchaseInvoice = new List<PurchaseInvoice>();
            IBaseEntityCollectionResponse<PurchaseInvoice> baseEntityCollectionResponse = _PurchaseInvoiceBA.GetRecordForPurchaseOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listPurchaseInvoice = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listPurchaseInvoice;
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

                IEnumerable<PurchaseInvoiceViewModel> filteredCountryMaster;
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
                //filteredCountryMaster = new List<PurchaseInvoiceViewModel>(); 

                if (!string.IsNullOrEmpty(PurchaseOrderType))
                {
                    filteredCountryMaster = GetPurchaseInvoice(PurchaseOrderType, AdminRoleID, out TotalRecords);
                }
                else
                {
                    filteredCountryMaster = new List<PurchaseInvoiceViewModel>();
                    TotalRecords = 0;
                }


                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.VendorID), Convert.ToString(c.PurchaseOrderNumber), Convert.ToString(c.VendorName), Convert.ToString(c.PurchaseOrderMasterID), Convert.ToString(c.ID), Convert.ToString(c.PurchaseGRNMasterID), Convert.ToString(c.GRNNumber), Convert.ToString(c.VendorInvoiceNo), Convert.ToString(c.PurchaseRequisitionMasterID) };

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