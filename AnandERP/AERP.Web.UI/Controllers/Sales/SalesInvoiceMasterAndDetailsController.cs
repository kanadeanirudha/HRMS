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
using System.Globalization;

namespace AERP.Web.UI.Controllers
{
    public class SalesInvoiceMasterAndDetailsController : BaseController
    {
        ISalesInvoiceMasterAndDetailsBA _SalesInvoiceMasterAndDetailsBA = null;
        //ICRMCallTypeBA _CRMCallTypeBA = null;
        IGeneralUnitsBA _GeneralUnitsBA = null;
        IPurchaseRequisitionMasterBA _PurchaseRequisitionMasterBA = null;
        IGeneralTaxGroupMasterBA _GeneralTaxGroupMasterBA = null;

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

        public SalesInvoiceMasterAndDetailsController()
        {
            _SalesInvoiceMasterAndDetailsBA = new SalesInvoiceMasterAndDetailsBA();
            //_CRMCallTypeBA = new CRMCallTypeBA();
            _GeneralUnitsBA = new GeneralUnitsBA();
            _GeneralTaxGroupMasterBA = new GeneralTaxGroupMasterBA();
            _PurchaseRequisitionMasterBA = new PurchaseRequisitionMasterBA();


        }

        // Controller Methods
        #region ---------------Controller Methods------------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || ((Convert.ToInt32(Session["Sales Manager"]) > 0 || Convert.ToInt32(Session["Sales Manager:Entity"]) > 0 || Convert.ToInt32(Session["Store Manager"]) > 0) && IsApplied == true))
            {
                SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    model.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    model.errorMessage = "NoMessage";
                }
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Standard Requisition", Value = "5" });
                ViewData["PurchaseOrderType"] = li;
                return View("/Views/Sales/SalesInvoiceMasterAndDetails/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, SalesInvoiceMasterAndDetailsViewModel model)
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
                return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/List.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        public ActionResult ServiceInvoiceList(string actionMode, SalesInvoiceMasterAndDetailsViewModel model)
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
                return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/ServiceInvoiceList.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult Create(int SalesOrderMasterID)
        {
            SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
            model.SalesOrderMasterID = SalesOrderMasterID;

            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.SalesOrderMasterID = SalesOrderMasterID;

            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.SelectBySalesOrderMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.SalesinvoiceList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.CustomerName = model.SalesinvoiceList[0].CustomerName;
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.StorageLocationID = model.SalesinvoiceList[0].StorageLocationID;
            model.CustomerMasterID = model.SalesinvoiceList[0].CustomerMasterID;
            model.GeneralUnitsID = model.SalesinvoiceList[0].GeneralUnitsID;
            model.SalesOrderNumber = model.SalesinvoiceList[0].SalesOrderNumber;
            model.CustomerBranchMasterID = model.SalesinvoiceList[0].CustomerBranchMasterID;



            return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult ViewSalesInvoiceMasterAndDetails(int SalesInvoiceMasterID)
        {
            SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
            model.ID = SalesInvoiceMasterID;

            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.ID = SalesInvoiceMasterID;
            searchRequest.InvoiceType = 1;

            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.ViewDetailsBySalesInvoiceMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.SalesinvoiceList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.InvoiceType = 1;
            model.CustomerName = model.SalesinvoiceList[0].CustomerName;
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.StorageLocationID = model.SalesinvoiceList[0].StorageLocationID;
            model.CustomerMasterID = model.SalesinvoiceList[0].CustomerMasterID;
            model.CustomerBranchMasterID = model.SalesinvoiceList[0].CustomerBranchMasterID;
            model.GeneralUnitsID = model.SalesinvoiceList[0].GeneralUnitsID;
            model.CustomerInvoiceNumber = model.SalesinvoiceList[0].CustomerInvoiceNumber;
            model.SalesOrderMasterID = model.SalesinvoiceList[0].SalesOrderMasterID;
            model.BillAmount = model.SalesinvoiceList[0].TotalIInvoiceAmount;
            model.Amount = model.SalesinvoiceList[0].NetAmount;
            model.IsCanceled = model.SalesinvoiceList[0].IsCanceled;
            return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/ViewDetails.cshtml", model);
        }

        [HttpGet]
        public ActionResult ViewServiceInvoiceMasterAndDetails(int SalesInvoiceMasterID)
        {
            SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
            model.ID = SalesInvoiceMasterID;

            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = _connectioString;
            searchRequest.ID = SalesInvoiceMasterID;
            searchRequest.InvoiceType = 2;

            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.ViewDetailsBySalesInvoiceMasterID(searchRequest);

            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    model.SalesinvoiceList = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            model.InvoiceType = 2;
            model.CustomerName = model.SalesinvoiceList[0].CustomerName;
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.StorageLocationID = model.SalesinvoiceList[0].StorageLocationID;
            model.CustomerMasterID = model.SalesinvoiceList[0].CustomerMasterID;
            model.CustomerBranchMasterID = model.SalesinvoiceList[0].CustomerBranchMasterID;
            model.GeneralUnitsID = model.SalesinvoiceList[0].GeneralUnitsID;
            model.CustomerInvoiceNumber = model.SalesinvoiceList[0].CustomerInvoiceNumber;
            model.SalesOrderMasterID = model.SalesinvoiceList[0].SalesOrderMasterID;
            model.BillAmount = model.SalesinvoiceList[0].TotalIInvoiceAmount;
            model.Amount = model.SalesinvoiceList[0].NetAmount;
            model.IsCanceled = model.SalesinvoiceList[0].IsCanceled;
            model.ID = SalesInvoiceMasterID;
            return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/ViewDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult Create(SalesInvoiceMasterAndDetailsViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.SalesInvoiceMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesInvoiceMasterAndDetailsDTO.SalesOrderDeliveryMasterID = model.SalesOrderDeliveryMasterID;
                    model.SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID = model.SalesOrderMasterID;
                    model.SalesInvoiceMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesInvoiceMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesInvoiceMasterAndDetailsDTO.StorageLocationID = model.StorageLocationID;
                    model.SalesInvoiceMasterAndDetailsDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SalesInvoiceMasterAndDetailsDTO.XMLstring = model.XMLstring;
                    model.SalesInvoiceMasterAndDetailsDTO.XMLstringForInvoice = model.XMLstringForInvoice;
                    model.SalesInvoiceMasterAndDetailsDTO.IsServiceItem = model.IsServiceItem;
                    model.SalesInvoiceMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = _SalesInvoiceMasterAndDetailsBA.InsertSalesInvoiceMasterAndDetails(model.SalesInvoiceMasterAndDetailsDTO);
                    //errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);



                    //return Json(errorMessage, JsonRequestBehavior.AllowGet);
                    model.SalesInvoiceMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesInvoiceMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult CreateSalesInvoice()
        {
            SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
            string CentreCode = string.Empty;
            model.ListGeneralUnits = GetGeneralUnitsForItemmaster(CentreCode);
            return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/CreateDirectSaleInvoice.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateSalesInvoice(SalesInvoiceMasterAndDetailsViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.SalesInvoiceMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesInvoiceMasterAndDetailsDTO.CustomerMasterID = model.CustomerMasterID;
                    model.SalesInvoiceMasterAndDetailsDTO.CustomerBranchMasterID = model.CustomerBranchMasterID;
                    model.SalesInvoiceMasterAndDetailsDTO.GeneralUnitsID = model.GeneralUnitsID;
                    model.SalesInvoiceMasterAndDetailsDTO.Freight = model.Freight;
                    model.SalesInvoiceMasterAndDetailsDTO.ShippingHandling = model.ShippingHandling;
                    model.SalesInvoiceMasterAndDetailsDTO.Discount = model.Discount;
                    model.SalesInvoiceMasterAndDetailsDTO.NetAmount = model.Amount;
                    model.SalesInvoiceMasterAndDetailsDTO.TotalTaxAmount = model.TotalTaxAmount;
                    model.SalesInvoiceMasterAndDetailsDTO.TotalIInvoiceAmount = model.BillAmount;
                    model.SalesInvoiceMasterAndDetailsDTO.PurchaseOrderNumber = model.PurchaseOrderNumber;
                    model.SalesInvoiceMasterAndDetailsDTO.PurchaseOrderDate = model.PurchaseOrderDate;
                    model.SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionName = model.InvoiceDeductionName;
                    model.SalesInvoiceMasterAndDetailsDTO.InvoiceDeductionAmount = model.InvoiceDeductionAmount;
                    model.SalesInvoiceMasterAndDetailsDTO.BillingSpanEndDate = model.BillingSpanEndDate;

                    model.SalesInvoiceMasterAndDetailsDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SalesInvoiceMasterAndDetailsDTO.XMLstringForInvoice = model.XMLstringForInvoice;
                    model.SalesInvoiceMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = _SalesInvoiceMasterAndDetailsBA.InsertDirectSalesInvoiceMasterAndDetails(model.SalesInvoiceMasterAndDetailsDTO);
                    model.SalesInvoiceMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesInvoiceMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult CancelSalesInvoice(SalesInvoiceMasterAndDetailsViewModel model)
        {
            string errorMessage = string.Empty;
            try
            {
                if (ModelState.IsValid)
                {
                    model.SalesInvoiceMasterAndDetailsDTO.ConnectionString = _connectioString;
                    model.SalesInvoiceMasterAndDetailsDTO.ID = model.ID;
                    model.SalesInvoiceMasterAndDetailsDTO.XMLstringForVouchar = model.XMLstringForVouchar;
                    model.SalesInvoiceMasterAndDetailsDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SalesInvoiceMasterAndDetails> response = _SalesInvoiceMasterAndDetailsBA.CancelSalesInvoiceMasterAndDetails(model.SalesInvoiceMasterAndDetailsDTO);
                    model.SalesInvoiceMasterAndDetailsDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);
                    return Json(model.SalesInvoiceMasterAndDetailsDTO.errorMessage, JsonRequestBehavior.AllowGet);

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
        public ActionResult ErorMessage(int id, int SaleMstID, byte InvoiceType)
        {
            try
            {
                SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
                model.SalesInvoiceMasterAndDetailsDTO.ID = id;
                model.SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID = SaleMstID;
                model.SalesInvoiceMasterAndDetailsDTO.InvoiceType = InvoiceType;
                return PartialView("/Views/Sales/SalesInvoiceMasterAndDetails/ErrorMessage.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public FileStreamResult Download(SalesInvoiceMasterAndDetailsViewModel _model)
        {
            SalesInvoiceMasterAndDetailsViewModel model = new SalesInvoiceMasterAndDetailsViewModel();
            try
            {
                model.SalesInvoiceMasterAndDetailsDTO = new SalesInvoiceMasterAndDetails();
                model.SalesInvoiceMasterAndDetailsDTO.ID = _model.ID;
                model.SalesInvoiceMasterAndDetailsDTO.SalesOrderMasterID = _model.SalesOrderMasterID;
                model.SalesInvoiceMasterAndDetailsDTO.NoOfCopies = _model.NoOfCopies;
                model.SalesInvoiceMasterAndDetailsDTO.InvoiceType = _model.InvoiceType;
                model.SalesInvoiceMasterAndDetailsDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                decimal TotalAmount = 0; decimal TotalBillAmount = 0;
                if (model.SalesInvoiceMasterAndDetailsDTO.InvoiceType == 1)
                {
                    model.SalesinvoiceList = GetRecordForSalesInvoicePDF(_model.ID);
                }
                else
                {
                    model.SalesinvoiceList = GetRecordForServiceInvoicePDF(_model.ID);
                }
                string SalesInvoicePDF = " ";

                //model.SalesOrderNumber = model.SalesinvoiceList[0].SalesOrderNumber;
                model.CustomerInvoiceNumber = model.SalesinvoiceList[0].CustomerInvoiceNumber;
                model.IsOther = model.SalesinvoiceList[0].IsOther;
                model.IsTaxExempted = model.SalesinvoiceList[0].IsTaxExempted;
                model.ReasonForExemption = model.SalesinvoiceList[0].ReasonForExemption;
                model.TaxExemptionRemark = model.SalesinvoiceList[0].TaxExemptionRemark;

                if (model.SalesInvoiceMasterAndDetailsDTO.InvoiceType == 1)
                {
                    string FromDetailTable = "SaleContractInvoiceDetails";
                    model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOther, _model.ID, FromDetailTable);
                }
                else
                {
                    string FromDetailTable = "SaleContractInvoiceDetails";
                    model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOther, _model.ID, FromDetailTable);
                }

                SalesInvoicePDF = SalesInvoicePDF + "<html><body><span style='text-align:right;font-size:8pt'><b>" + _model.NoOfCopies + "</b><br></body></html>";
                SalesInvoicePDF = SalesInvoicePDF + "<table width='650'><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SalesinvoiceList[0].LogoPath) + "' height='70' width='70'><br><br><span style='font-size:7pt;text-align:left;'>" + model.SalesinvoiceList[0].PrintingLineBelowLogo + "<span></td>";

                SalesInvoicePDF = SalesInvoicePDF + " <td><table width='300' bgcolor='#fff;' color='black' style='font-size:7pt;'><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:10pt;text-align:left;font-family:'Century Gothic'><b>" + model.SalesinvoiceList[0].CentreName + "</b></td></tr></hr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:9pt;text-align:left;'><b><u>" + model.SalesinvoiceList[0].CentreSpecialization + "</u></b></td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesinvoiceList[0].CentreAddress1 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SalesinvoiceList[0].CentreAddress2 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Ph:" + model.SalesinvoiceList[0].PhoneNumberOffice + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Cell :" + model.SalesinvoiceList[0].CellPhone + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>E-mail :" + model.SalesinvoiceList[0].EmailID + "</td>< tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' >Website :" + model.SalesinvoiceList[0].Website + " </td ></tr></tr>";

                SalesInvoicePDF = SalesInvoicePDF + "</table></td></tr></table>";

                DateTime DateTimeOfSupply = Convert.ToDateTime(model.SalesinvoiceList[0].DateTimeOfSupply);

                SalesInvoicePDF = SalesInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td colspan='2'  bgcolor='#F7F2F2' style='padding:0 5px 5px;font-size:10pt;text-align:center;'><b><u>TAX INVOICE</u><b></td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>GSTIN Number</b>: " + model.SalesinvoiceList[0].GSTINNumber + "</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>Transportation Mode <b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>PAN Number</b>: " + model.SalesinvoiceList[0].PanNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Vehical Number </b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>CIN Number</b>: " + model.SalesinvoiceList[0].CINNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Date and Time of Supply: " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTimeOfSupply.Month) + " " + DateTimeOfSupply.Year + " </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Tax is payable on Reverse Charge</b> :(No)</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Place of Supply</b> :" + model.SalesinvoiceList[0].CustomerBranchAddress + " </td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Invoice Number</b> :" + model.SalesinvoiceList[0].CustomerInvoiceNumber + "</td>";

                //if (model.SalesinvoiceList[0].PurchaseOrderNumberClient == "" || model.SalesinvoiceList[0].PurchaseOrderNumberClient == null)
                //{
                SalesInvoicePDF = SalesInvoicePDF + "<td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '></td>";
                //}
                //else
                //{
                //    SalesInvoicePDF = SalesInvoicePDF + "<td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Purchase Order Number</b> :" + model.SalesinvoiceList[0].PurchaseOrderNumberClient + "</td>";
                //}

                SalesInvoicePDF = SalesInvoicePDF + "</tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Invoice Date</b> :" + model.SalesinvoiceList[0].TransactionDate + "</td>";

                if (model.SalesinvoiceList[0].DeliveryNumber != "" && model.SalesinvoiceList[0].DeliveryNumber != null)
                {
                    SalesInvoicePDF = SalesInvoicePDF + "<td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Delivery Memo No.</b> :" + model.SalesinvoiceList[0].DeliveryNumber + "</td> </tr></table>";
                }
                else
                {
                    SalesInvoicePDF = SalesInvoicePDF + "<td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '></td> </tr></table>";
                }

                SalesInvoicePDF = SalesInvoicePDF + "<br><table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:11pt;'><b>Sales Order</b><tr><td bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Receiver(Billed to)</b></td><td  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Consignee(Shipped to)</b></td></tr>";

                SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Customer Name :</b> " + model.SalesinvoiceList[0].CustomerName + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Branch Name: </b>" + model.SalesinvoiceList[0].BranchName + " </td ></tr>";

                SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Address:</b> " + model.SalesinvoiceList[0].CustomerAddress + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Address:</b> " + model.SalesinvoiceList[0].CustomerBranchAddress + " </td ></tr>";

                SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Country:</b> " + model.SalesinvoiceList[0].CountryName + " &nbsp;&nbsp;<b> State:</b> " + model.SalesinvoiceList[0].StateName + "&nbsp;&nbsp;<b> State Code:</b> " + model.SalesinvoiceList[0].StateCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' > <b>Country: </b>" + model.SalesinvoiceList[0].BranchCountryName + " &nbsp;&nbsp;<b> State: </b>" + model.SalesinvoiceList[0].BranchStateName + " &nbsp;&nbsp;<b> State Code:</b> " + model.SalesinvoiceList[0].BranchStateCode + "</td ></tr>";

                SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>City:</b> " + model.SalesinvoiceList[0].CityName + " <b>Pin Code:</b> " + model.SalesinvoiceList[0].CustomerPinCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>City:</b> " + model.SalesinvoiceList[0].BranchCityName + "  <b>Pin Code:</b> " + model.SalesinvoiceList[0].CustomerBranchPinCode + "</td ></tr><tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>GSTIN Number:</b> " + model.SalesinvoiceList[0].CustomerGSTNumber + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>GSTIN Number:</b> " + model.SalesinvoiceList[0].BranchGSTNumber + " </td ></tr>";

                if (model.SalesinvoiceList[0].PurchaseOrderNumber != null && model.SalesinvoiceList[0].PurchaseOrderNumber != "")
                {
                    SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Purchase Order Number:</b> " + model.SalesinvoiceList[0].PurchaseOrderNumber + "<b>   Purchase Order Date:</b> " + model.SalesinvoiceList[0].PurchaseOrderDate + "</td><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Purchase Order Number:</b> " + model.SalesinvoiceList[0].PurchaseOrderNumber + " <b>   Purchase Order Date:</b> " + model.SalesinvoiceList[0].PurchaseOrderDate + "</td ></tr></table>";
                }
                else if (model.SalesinvoiceList[0].PurchaseOrderNumberClient != null && model.SalesinvoiceList[0].PurchaseOrderNumberClient != "")
                {
                    SalesInvoicePDF = SalesInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Purchase Order Number:</b> " + model.SalesinvoiceList[0].PurchaseOrderNumberClient + "</td><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Purchase Order Number:</b> " + model.SalesinvoiceList[0].PurchaseOrderNumberClient + "</td ></tr></table>";
                }
                else
                {
                    SalesInvoicePDF = SalesInvoicePDF + " </table>";
                }

                SalesInvoicePDF = SalesInvoicePDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Sr. No.</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Description of goods/services</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>HSN / SAC Code</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>UOM</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Amount</th></tr>";
                if (model.SalesinvoiceList.Count > 0 && model.SalesinvoiceList != null)
                {
                    int i = 1; bool IsServiceItemAvailable = false;
                    foreach (var item in model.SalesinvoiceList)
                    {
                        if (item.IsServiceItem == false)
                        {
                            TotalAmount = TotalAmount + Math.Round(item.NetAmount, 2);

                            if (item.IsTaxExempted == true && item.ReasonForExemption == 1)
                            {
                                TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2);
                            }
                            else
                            {
                                TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2) + Math.Round(item.TaxAmount, 2);
                            }

                            decimal InvoiceDeductionTaxAmount = 0;

                            if (item.InvoiceDeductionAmount > 0)
                            {
                                InvoiceDeductionTaxAmount = Math.Round(item.InvoiceDeductionAmount * 18 / 100, 2);
                            }

                            SalesInvoicePDF = SalesInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + i + "</td><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.SaleUomCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + (Math.Round(item.Rate, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (Math.Round(item.NetAmount, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.TaxGroupName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : Math.Round(item.TaxAmount, 2) + InvoiceDeductionTaxAmount) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + ((item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : Math.Round(item.TaxAmount, 2) + InvoiceDeductionTaxAmount) + Math.Round(item.NetAmount, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td></tr>";

                            if (item.InvoiceDeductionAmount > 0)
                            {
                                SalesInvoicePDF = SalesInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.InvoiceDeductionName + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.InvoiceDeductionAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.InvoiceDeductionAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.TaxGroupName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : InvoiceDeductionTaxAmount) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + ((item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : InvoiceDeductionTaxAmount) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td></tr>";
                            }

                            i++;
                        }
                        else
                        {
                            IsServiceItemAvailable = true;
                        }
                    }
                    if (IsServiceItemAvailable == true)
                    {
                        SalesInvoicePDF = SalesInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Sub Total</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + TotalAmount + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td></tr>";

                        foreach (var item in model.SalesinvoiceList)
                        {
                            if (item.IsServiceItem == true)
                            {
                                TotalAmount = TotalAmount + Math.Round(item.NetAmount, 2);

                                if (item.IsTaxExempted == true && item.ReasonForExemption == 1)
                                {
                                    TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2);
                                }
                                else
                                {
                                    TotalBillAmount = TotalBillAmount + Math.Round(item.NetAmount, 2) + Math.Round(item.TaxAmount, 2);
                                }

                                SalesInvoicePDF = SalesInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='4%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + i + "</td><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.SaleUomCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + (Math.Round(item.Rate, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (Math.Round(item.NetAmount, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.TaxGroupName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + (item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : Math.Round(item.TaxAmount, 2)) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + ((item.IsTaxExempted == true && item.ReasonForExemption == 1 ? 0 : Math.Round(item.TaxAmount, 2)) + Math.Round(item.NetAmount, 2) + Math.Round(item.InvoiceDeductionAmount, 2)) + "</td></tr>";

                                i++;
                            }
                        }
                    }
                }

                if (model.IsTaxExempted == true)
                {
                    if ((model.ReasonForExemption == 1) && model.TaxExemptionRemark != "")
                    {
                        SalesInvoicePDF = SalesInvoicePDF + "<tr><td  bgcolor='#F7F2F2' colspan='10' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Note:- '" + model.TaxExemptionRemark + "'</td></tr>";
                    }
                }

                SalesInvoicePDF = SalesInvoicePDF + "</table>";
                SalesInvoicePDF = SalesInvoicePDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                SalesInvoicePDF = SalesInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";

                if (model.TaxSummaryList.Count > 0 && model.TaxSummaryList != null)
                {
                    foreach (var itemList in model.TaxSummaryList)
                    {
                        String[] TaxList = itemList.TaxList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxAmount = itemList.TaxAmountList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxableAmount = itemList.TaxableAmountList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int i = 0; i < TaxAmount.Count(); i++)
                        {
                            SalesInvoicePDF = SalesInvoicePDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxList[i] + "% on " + TaxableAmount[i] + "</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + Math.Round(Convert.ToDecimal(TaxAmount[i])) + "</td></tr>";
                        }
                    }
                }

                string Amountt = Convert.ToString(Math.Round(TotalBillAmount));
                var AmountInWords = ConvertToWords(Amountt);

                SalesInvoicePDF = SalesInvoicePDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Math.Round(TotalBillAmount) + "</td> </tr></table></td></tr></table>";

                SalesInvoicePDF = SalesInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Invoice Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";



                SalesInvoicePDF = SalesInvoicePDF + "<table><tr><td width='38%'>";
                SalesInvoicePDF = SalesInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                SalesInvoicePDF = SalesInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                SalesInvoicePDF = SalesInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";

                //SalesInvoicePDF = SalesInvoicePDF + "</table>";
                DownloadPDF1(SalesInvoicePDF, model.CustomerInvoiceNumber, model.SalesinvoiceList[0].CustomerMasterID, model.SalesinvoiceList[0].IsCanceled);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DownloadPDF1(string SalesInvoicePDF, string CustomerInvoiceNumber, int CustomerMasterID, bool IsCanceled)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Tax_Invoice" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(SalesInvoicePDF, IsCanceled));
            Response.End();
        }
        //Code For  Download PDF
        public byte[] GetPDF(string pHTML, bool IsCanceled)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4, 25, 25, 25, 25);

            // 2: we create a itextsharp pdfwriter that listens to the document and directs a XML-stream to a file
            PdfWriter oPdfWriter = PdfWriter.GetInstance(doc, ms);
            if (IsCanceled == true)
            {
                PdfWriterEvents writerEvent = new PdfWriterEvents("CANCELLED");
                oPdfWriter.PageEvent = writerEvent;
            }
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

        [HttpPost]
        public JsonResult GetInvoiceNumberSearchList(string term)
        {
            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SearchWord = term;
            List<SalesInvoiceMasterAndDetails> listFeeSubType = new List<SalesInvoiceMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.GetSalesInvoiceNumberSearchList(searchRequest);
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
                              SalesInvoiceMasterID = r.ID,
                              SalesInvoiceNumber = r.CustomerInvoiceNumber
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
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
        [NonAction]
        protected List<GeneralTaxGroupMaster> GetTaxSummaryForDisplay(bool IsOtherState, int FromMasterID, string FromDetailTable)
        {
            GeneralTaxGroupMasterSearchRequest searchRequest = new GeneralTaxGroupMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.IsOtherState = IsOtherState;
            searchRequest.FromMasterID = FromMasterID;
            searchRequest.FromDetailTable = FromDetailTable;

            List<GeneralTaxGroupMaster> listGeneralTaxMaster = new List<GeneralTaxGroupMaster>();
            IBaseEntityCollectionResponse<GeneralTaxGroupMaster> baseEntityCollectionResponse = _GeneralTaxGroupMasterBA.GetTaxSummaryForDisplay(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listGeneralTaxMaster = baseEntityCollectionResponse.CollectionResponse.OrderBy(x => x.TaxName).ToList();
                }
            }
            return listGeneralTaxMaster;
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
        #endregion


        #region ----------------------Methods----------------------

        public IEnumerable<SalesInvoiceMasterAndDetailsViewModel> GetSalesInvoiceMasterAndDetails(int AdminRoleID, out int TotalRecords)
        {
            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
            searchRequest.AdminRoleID = AdminRoleID;
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
            List<SalesInvoiceMasterAndDetailsViewModel> listSalesInvoiceMasterAndDetailsViewModel = new List<SalesInvoiceMasterAndDetailsViewModel>();
            List<SalesInvoiceMasterAndDetails> listSalesInvoiceMasterAndDetails = new List<SalesInvoiceMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.GetBySearch(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesInvoiceMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesInvoiceMasterAndDetails item in listSalesInvoiceMasterAndDetails)
                    {
                        SalesInvoiceMasterAndDetailsViewModel SalesInvoiceMasterAndDetailsViewModel = new SalesInvoiceMasterAndDetailsViewModel();
                        SalesInvoiceMasterAndDetailsViewModel.SalesInvoiceMasterAndDetailsDTO = item;
                        listSalesInvoiceMasterAndDetailsViewModel.Add(SalesInvoiceMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesInvoiceMasterAndDetailsViewModel;
        }
        public IEnumerable<SalesInvoiceMasterAndDetailsViewModel> GetServiceInvoiceMasterAndDetails(int AdminRoleID, out int TotalRecords)
        {
            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            //searchRequest.PurchaseOrderType = Convert.ToInt16(PurchaseOrderType);
            searchRequest.AdminRoleID = AdminRoleID;
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
            List<SalesInvoiceMasterAndDetailsViewModel> listSalesInvoiceMasterAndDetailsViewModel = new List<SalesInvoiceMasterAndDetailsViewModel>();
            List<SalesInvoiceMasterAndDetails> listSalesInvoiceMasterAndDetails = new List<SalesInvoiceMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.GetBySearchForServiceItem(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesInvoiceMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                    foreach (SalesInvoiceMasterAndDetails item in listSalesInvoiceMasterAndDetails)
                    {
                        SalesInvoiceMasterAndDetailsViewModel SalesInvoiceMasterAndDetailsViewModel = new SalesInvoiceMasterAndDetailsViewModel();
                        SalesInvoiceMasterAndDetailsViewModel.SalesInvoiceMasterAndDetailsDTO = item;
                        listSalesInvoiceMasterAndDetailsViewModel.Add(SalesInvoiceMasterAndDetailsViewModel);
                    }
                }
            }
            TotalRecords = baseEntityCollectionResponse.TotalRecords;
            return listSalesInvoiceMasterAndDetailsViewModel;
        }

        [NonAction]
        protected List<SalesInvoiceMasterAndDetails> GetRecordForSalesInvoicePDF(int id)
        {
            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<SalesInvoiceMasterAndDetails> listSalesInvoiceMasterAndDetails = new List<SalesInvoiceMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.GetRecordForSalesinvoiceOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesInvoiceMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalesInvoiceMasterAndDetails;
        }
        [NonAction]
        protected List<SalesInvoiceMasterAndDetails> GetRecordForServiceInvoicePDF(int id)
        {
            SalesInvoiceMasterAndDetailsSearchRequest searchRequest = new SalesInvoiceMasterAndDetailsSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.ID = id;
            List<SalesInvoiceMasterAndDetails> listSalesInvoiceMasterAndDetails = new List<SalesInvoiceMasterAndDetails>();
            IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> baseEntityCollectionResponse = _SalesInvoiceMasterAndDetailsBA.GetRecordForServiceinvoiceOrderPDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSalesInvoiceMasterAndDetails = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSalesInvoiceMasterAndDetails;
        }

        #endregion

        // AjaxHandler Method
        #region ------------------AjaxHandler----------------------
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, int AdminRoleID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesInvoiceMasterAndDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CustomerName " + sortDirection + " ,A.SalesOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.SalesOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%'or A.CustomerName Like '%" + param.sSearch + "%' ";      //this "if" block is added for search functionality

                        }
                        break;
                    case 1:
                        _sortBy = "A.CustomerName " + sortDirection + " ,A.SalesOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.SalesOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%'or A.CustomerName Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.SalesOrderNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.SalesOrderNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<SalesInvoiceMasterAndDetailsViewModel>(); 

                filteredCountryMaster = GetSalesInvoiceMasterAndDetails(AdminRoleID, out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CustomerMasterID), Convert.ToString(c.SalesOrderNumber), Convert.ToString(c.CustomerName), Convert.ToString(c.SalesOrderMasterID), Convert.ToString(c.ID), Convert.ToString(c.SalesOrderDeliveryMasterID), Convert.ToString(c.DeliveryNumber), Convert.ToString(c.CustomerInvoiceNumber), Convert.ToString(c.SalesQuotationMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.Isinvoiced) };

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
        public ActionResult ServiceInvoiceAjaxHandler(JQueryDataTableParamModel param, int AdminRoleID)
        {
            if (Session["UserType"] != null)
            {
                int TotalRecords;
                var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
                string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc

                IEnumerable<SalesInvoiceMasterAndDetailsViewModel> filteredCountryMaster;
                switch (Convert.ToInt32(sortColumnIndex))
                {
                    case 0:
                        _sortBy = "A.CustomerName " + sortDirection + " ,A.CustomerInvoiceNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.CustomerInvoiceNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.CustomerInvoiceNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%'or A.CustomerName Like '%" + param.sSearch + "%' ";      //this "if" block is added for search functionality

                        }
                        break;
                    case 1:
                        _sortBy = "A.CustomerName " + sortDirection + " ,A.CustomerInvoiceNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.CustomerInvoiceNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.CustomerInvoiceNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%'or A.CustomerName Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;
                    case 2:
                        _sortBy = "A.CustomerInvoiceNumber";
                        if (string.IsNullOrEmpty(param.sSearch))
                        {
                            _searchBy = "A.CustomerInvoiceNumber like '%'";
                        }
                        else
                        {
                            _searchBy = "A.CustomerInvoiceNumber Like '%" + param.sSearch + "%' or A.SalesOrderNumber Like '%" + param.sSearch + "%' or A.CustomerInvoiceNumber Like '%" + param.sSearch + "%' or A.CustomerName Like '%" + param.sSearch + "%'";         //this "if" block is added for search functionality
                        }
                        break;

                }
                _sortDirection = sortDirection;
                _rowLength = param.iDisplayLength;
                _startRow = param.iDisplayStart;
                //filteredCountryMaster = new List<SalesInvoiceMasterAndDetailsViewModel>(); 

                filteredCountryMaster = GetServiceInvoiceMasterAndDetails(AdminRoleID, out TotalRecords);
                var records = filteredCountryMaster.Skip(0).Take(param.iDisplayLength);
                var result = from c in records select new[] { Convert.ToString(c.CustomerMasterID), Convert.ToString(c.SalesOrderNumber), Convert.ToString(c.CustomerName), Convert.ToString(c.SalesOrderMasterID), Convert.ToString(c.ID), Convert.ToString(c.SalesOrderDeliveryMasterID), Convert.ToString(c.DeliveryNumber), Convert.ToString(c.CustomerInvoiceNumber), Convert.ToString(c.SalesQuotationMasterID), Convert.ToString(c.CustomerBranchMasterID), Convert.ToString(c.GeneralUnitsID), Convert.ToString(c.Isinvoiced) };

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