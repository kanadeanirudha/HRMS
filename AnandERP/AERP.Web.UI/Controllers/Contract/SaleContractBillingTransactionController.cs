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
using System.Text;
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
    public class SaleContractBillingTransactionController : BaseController
    {
        ISaleContractBillingTransactionBA _SaleContractBillingTransactionBA = null;
        IInventoryLocationMasterBA _InventoryLocationMasterBA = null;

        string _centreCode = string.Empty;
        string _designationId = string.Empty;
        private readonly ILogger _logException;
        ActionModeEnum actionModeEnum;
        string _actionMode = string.Empty;
        string _sortBy = string.Empty;
        string _searchBy = string.Empty;
        string _sortDirection = string.Empty;
        int _startRow;
        int _rowLength;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public SaleContractBillingTransactionController()
        {
            _SaleContractBillingTransactionBA = new SaleContractBillingTransactionBA();
            _InventoryLocationMasterBA = new InventoryLocationMasterBA();
        }

        #region Controller Methods

        /// <summary>
        /// First Load When controller call List Method
        /// </summary>
        /// <returns>view</returns>
        [HttpGet]
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["Sales Manager"]) > 0 && IsApplied == true))
            {
                SaleContractBillingTransactionViewModel _SaleContractBillingTransactionViewModel = new SaleContractBillingTransactionViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    _SaleContractBillingTransactionViewModel.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    _SaleContractBillingTransactionViewModel.errorMessage = "NoMessage";
                }

                return View("/Views/Contract/SaleContractBillingTransaction/Index.cshtml", _SaleContractBillingTransactionViewModel);
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
                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Contract/SaleContractBillingTransaction/List.cshtml");

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult CreateInvoice(string SaleContractMasterID, string SaleContractBillingSpanID, string BillingType)
        {
            SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();

            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.BillingType = Convert.ToByte(BillingType);
            model.SaleContractBillingTransactionList = GetBillingTransactionForGeneration(SaleContractMasterID, SaleContractBillingSpanID, BillingType);

            if (model.SaleContractBillingTransactionList.Count > 0)
            {
                model.ContractNumber = model.SaleContractBillingTransactionList[0].ContractNumber;
                model.SaleContractBillingSpanName = model.SaleContractBillingTransactionList[0].SaleContractBillingSpanName;
                model.CustomerMasterName = model.SaleContractBillingTransactionList[0].CustomerMasterName;
                model.CustomerMasterID = model.SaleContractBillingTransactionList[0].CustomerMasterID;
                model.CustomerBranchMasterID = model.SaleContractBillingTransactionList[0].CustomerBranchMasterID;
                model.CustomerBranchMasterName = model.SaleContractBillingTransactionList[0].CustomerBranchMasterName;
                model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            }

            int AdminRoleID = 0;
            if (Session["RoleID"] == null)
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["DefaultRoleID"])) ? Convert.ToInt32(Session["DefaultRoleID"]) : 0;
            }

            else
            {
                AdminRoleID = !string.IsNullOrEmpty(Convert.ToString(Session["RoleID"])) ? Convert.ToInt32(Session["RoleID"]) : 0;
            }
            List<InventoryLocationMaster> locationMasterList = GetInventoryIssueLocationMasterList(AdminRoleID);
            List<SelectListItem> listLocationMaster = new List<SelectListItem>();
            foreach (InventoryLocationMaster item in locationMasterList)
            {
                listLocationMaster.Add(new SelectListItem { Text = item.LocationName, Value = Convert.ToString(item.ID) });
            }
            ViewBag.GeneralLocationList = new SelectList(listLocationMaster, "Value", "Text");

            return PartialView("/Views/Contract/SaleContractBillingTransaction/CreateInvoice.cshtml", model);
        }

        [HttpPost]
        public ActionResult CreateInvoice(SaleContractBillingTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractBillingTransactionDTO != null)
                {
                    model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractBillingTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractBillingTransactionDTO.TotalBillAmount = model.TotalBillAmount;
                    model.SaleContractBillingTransactionDTO.TaxableAmount = model.TaxableAmount;
                    model.SaleContractBillingTransactionDTO.TaxAmount = model.TaxAmount;
                    model.SaleContractBillingTransactionDTO.RoundOffAmount = model.RoundOffAmount;
                    model.SaleContractBillingTransactionDTO.LocationID = model.LocationID;
                    model.SaleContractBillingTransactionDTO.XMLStringBillingTransaction = model.XMLStringBillingTransaction;
                    model.SaleContractBillingTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractBillingTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractBillingTransaction> response = _SaleContractBillingTransactionBA.GenerateSaleContractInvoiceTransaction(model.SaleContractBillingTransactionDTO);

                    model.SaleContractBillingTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SaleContractBillingTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
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
        public ActionResult ViewInvoiceDetails(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();

            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.SaleContractBillingTransactionList = GetBillingTransactionDetailsByID(SaleContractMasterID, SaleContractBillingSpanID);

            if (model.SaleContractBillingTransactionList.Count > 0)
            {
                model.ContractNumber = model.SaleContractBillingTransactionList[0].ContractNumber;
                model.SaleContractBillingSpanName = model.SaleContractBillingTransactionList[0].SaleContractBillingSpanName;
                model.CustomerMasterName = model.SaleContractBillingTransactionList[0].CustomerMasterName;
                model.CustomerBranchMasterName = model.SaleContractBillingTransactionList[0].CustomerBranchMasterName;
                model.SalesInvoiceMasterID = model.SaleContractBillingTransactionList[0].SalesInvoiceMasterID;
                model.CustomerInvoiceNumber = model.SaleContractBillingTransactionList[0].CustomerInvoiceNumber;
                model.LocationName = model.SaleContractBillingTransactionList[0].LocationName;
                model.CustomerBranchMasterID = model.SaleContractBillingTransactionList[0].CustomerBranchMasterID;
                model.IsCanceled = model.SaleContractBillingTransactionList[0].IsCanceled;
                model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            }

            return PartialView("/Views/Contract/SaleContractBillingTransaction/ViewInvoiceDetails.cshtml", model);
        }

        [HttpPost]
        public ActionResult CancelInvoice(SaleContractBillingTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractBillingTransactionDTO != null)
                {
                    model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractBillingTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractBillingTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractBillingTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractBillingTransaction> response = _SaleContractBillingTransactionBA.CancelSaleContractInvoiceTransaction(model.SaleContractBillingTransactionDTO);

                    model.SaleContractBillingTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Update);

                    return Json(model.SaleContractBillingTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
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
        public ActionResult DownloadOption(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();
                model.SaleContractBillingTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractBillingTransaction/DownloadOption.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        [HttpPost]
        public ActionResult DownloadOption(SaleContractBillingTransactionViewModel _model)
        {
            try
            {
                if (_model.SummaryFormat == 1)
                {
                    return RedirectToAction("DownloadSummery", new { SaleContractMasterID = _model.SaleContractMasterID, SaleContractBillingSpanID = _model.SaleContractBillingSpanID, SummaryFormat = _model.SummaryFormat });
                }
                else if (_model.SummaryFormat == 2)
                {
                    return RedirectToAction("DownloadSummerySecond", new { SaleContractMasterID = _model.SaleContractMasterID, SaleContractBillingSpanID = _model.SaleContractBillingSpanID, SummaryFormat = _model.SummaryFormat });
                }
                else
                {
                    TempData["_errorMsg"] = "Salary Format Not Selected.";
                    return RedirectToAction("Index", "SaleContractBillingTransaction");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //public void Download(string SaleContractMasterID,string SaleContractBillingSpanID)
        //{
        //    // MemoryStream workStream = new MemoryStream();

        //    StringBuilder status = new StringBuilder("");
        //    DateTime dTime = DateTime.Now;
        //    //file name to be created   
        //    Document doc = new Document();
        //    doc.SetMargins(0f, 0f, 0f, 0f);

        //    //Create PDF Table with 2 columns  
        //    PdfPTable tableLayoutHeader = new PdfPTable(2);
        //    doc.SetMargins(20f, 20f, 20f, 20f);

        //    //Create PDF Table with 2 columns  for Invoice Information
        //    PdfPTable tableLayoutInvoiceDetails = new PdfPTable(2);
        //    doc.SetMargins(20f, 20f, 20f, 20f);

        //    //Create PDF Table with 2 columns for Shipping Details
        //    PdfPTable tableLayoutShippingDetails = new PdfPTable(2);
        //    doc.SetMargins(20f, 20f, 20f, 20f);

        //    //Create PDF Table  

        //    PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
        //    doc.Open();

        //    //Add Title to the PDF file at the top  
        //    SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();

        //    model.SaleContractBillingTransactionDTO = new SaleContractBillingTransaction();
        //    model.SaleContractBillingTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
        //    model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
        //    model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
        //    model.SaleContractBillingTransactionList = GetBillingTransactionDetailsByIDForInvoicePDF(SaleContractMasterID, SaleContractBillingSpanID);

        //    //Add Content to PDF 
        //    //doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    float[] headers = { 60, 40 }; //Header Widths  
        //    tableLayoutHeader.SetWidths(headers); //Set the pdf headers  
        //    tableLayoutHeader.TotalWidth = 555f; //Set the PDF File witdh percentage  
        //    tableLayoutHeader.HorizontalAlignment = Element.ALIGN_CENTER;
        //    tableLayoutHeader.HeaderRows = 1;


        //    ////doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    //float[] headersEmpDetails = { 50, 50, 50, 50 }; //Header Widths  
        //    //tableLayoutEmpDetails.SetWidths(headersEmpDetails); //Set the pdf headers  
        //    //tableLayoutEmpDetails.TotalWidth = 555f; //Set the PDF File witdh percentage  
        //    //tableLayoutEmpDetails.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //tableLayoutEmpDetails.HeaderRows = 1;

        //    ////doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    //float[] headersAllowance = { 70, 40, 40 }; //Header Widths  
        //    //tableLayoutAllowance.SetWidths(headersAllowance); //Set the pdf headers  
        //    //tableLayoutAllowance.TotalWidth = 340f; //Set the PDF File witdh percentage  
        //    //tableLayoutAllowance.HorizontalAlignment = Element.ALIGN_LEFT;
        //    //tableLayoutAllowance.HeaderRows = 1;


        //    ////doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    //float[] headersDeduction = { 70, 40 }; //Header Widths  
        //    //tableLayoutDeduction.SetWidths(headersDeduction); //Set the pdf headers  
        //    //tableLayoutDeduction.TotalWidth = 215f; //Set the PDF File witdh percentage  
        //    //tableLayoutDeduction.HorizontalAlignment = Element.ALIGN_RIGHT;
        //    //tableLayoutDeduction.HeaderRows = 1;

        //    ////doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    //float[] headersTakeHomeSal = { 69, 50, 50, 70 }; //Header Widths  
        //    //tableLayoutTakeHomeSal.SetWidths(headersTakeHomeSal); //Set the pdf headers  
        //    //tableLayoutTakeHomeSal.TotalWidth = 555f; //Set the PDF File witdh percentage  
        //    //tableLayoutTakeHomeSal.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //tableLayoutTakeHomeSal.HeaderRows = 1;

        //    ////doc.Add(Add_Content_To_PDF(tableLayout,ID));
        //    //float[] headersSigniture = { 100 }; //Header Widths  
        //    //tableLayoutSigniture.SetWidths(headersSigniture); //Set the pdf headers  
        //    //tableLayoutSigniture.TotalWidth = 555f; //Set the PDF File witdh percentage  
        //    //tableLayoutSigniture.HorizontalAlignment = Element.ALIGN_CENTER;
        //    //tableLayoutSigniture.HeaderRows = 1;

        //    ////Add body  

        //    //FontFactory.Register("D:\\Project\\AnandERP\\AnandERP\\AERP.Web.UI\\Content\\Theme\\fonts\\Bahamas Bold.ttf", "Bahamas");
        //    //var titleFont = FontFactory.GetFont("Bahamas", 20f);

        //    //tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractSalaryTransactionList[0].CentreName, titleFont))
        //    tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractBillingTransactionList[0].CentreName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SaleContractBillingTransactionList[0].LogoPath));
        //    jpg.ScaleAbsolute(50f, 50f);
        //    tableLayoutHeader.AddCell(new PdfPCell(jpg) { PaddingTop = 5, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER, UseVariableBorders = true, BorderColorLeft = BaseColor.WHITE, BorderColorRight = BaseColor.WHITE });

        //    tableLayoutHeader.AddCell(new PdfPCell(new Phrase("Pay Slip For Span" + model.SaleContractBillingTransactionList[0].SaleContractBillingSpanName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
        //        UseVariableBorders = true,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });

        //    tableLayoutHeader.WriteSelectedRows(0, -1, doc.Left, doc.Top, writer.DirectContent);
        //    // doc.Add(tableLayoutHeader);


        //    tableLayoutEmpDetails.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

        //    ///For Allowance
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Monthly Pay", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });

        //    decimal BasicAmount = Math.Round(model.SaleContractSalaryTransactionList[0].BasicSalayAmount);
        //    decimal TotalAttendance = model.SaleContractSalaryTransactionList[0].TotalAttendance;
        //    byte TotalDays = model.SaleContractSalaryTransactionList[0].TotalDays;
        //    decimal AdjustedTotalDays = model.SaleContractSalaryTransactionList[0].AdjustedTotalDays;
        //    decimal ActualBasicAmount = Math.Round((BasicAmount / TotalDays) * TotalAttendance);



        //    decimal TotalEarning = BasicAmount, ActualTotalEarning = ActualBasicAmount;
        //    decimal TotalDeduction = 0, ActualTotalDeduction = 0;

        //    foreach (var emp in model.SaleContractSalaryTransactionList)
        //    {
        //        if (emp.HeadType == "DA")
        //        {
        //            decimal amount = 0;
        //            if (emp.FixedAmount > 0)
        //            {
        //                amount = Math.Round(emp.FixedAmount);
        //            }
        //            else
        //            {
        //                var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
        //                decimal CalculateOnAmount = 0;
        //                foreach (var CalOn in CalculateOnValue)
        //                {
        //                    var ReferenceID = CalOn.Split('~');
        //                    if (Convert.ToByte(ReferenceID[0]) == 0)
        //                    {
        //                        CalculateOnAmount = CalculateOnAmount + BasicAmount;
        //                    }
        //                    else
        //                    {
        //                        foreach (var itemSub in model.SaleContractSalaryTransactionList)
        //                        {
        //                            if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
        //                            {
        //                                CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
        //                            }
        //                        }
        //                    }
        //                }
        //                amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

        //            }
        //            emp.Amount = amount;


        //            TotalEarning = TotalEarning + amount;
        //            ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
        //        }
        //    }

        //    foreach (var emp in model.SaleContractSalaryTransactionList)
        //    {
        //        if (emp.RuleType == "Allowance" && emp.HeadType != "DA")
        //        {
        //            decimal amount = 0;
        //            if (emp.FixedAmount > 0)
        //            {
        //                amount = Math.Round(emp.FixedAmount);
        //                emp.Amount = amount;


        //                TotalEarning = TotalEarning + amount;
        //                ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;

        //            }
        //            else if (emp.Percentage > 0)
        //            {
        //                var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
        //                decimal CalculateOnAmount = 0;
        //                foreach (var CalOn in CalculateOnValue)
        //                {
        //                    var ReferenceID = CalOn.Split('~');
        //                    if (Convert.ToByte(ReferenceID[0]) == 0)
        //                    {
        //                        CalculateOnAmount = CalculateOnAmount + BasicAmount;
        //                    }
        //                    else
        //                    {
        //                        foreach (var itemSub in model.SaleContractSalaryTransactionList)
        //                        {
        //                            if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
        //                            {
        //                                CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
        //                            }
        //                        }
        //                    }
        //                }
        //                amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);
        //                emp.Amount = amount;


        //                TotalEarning = TotalEarning + amount;
        //                ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
        //            }

        //        }
        //    }

        //    ///For Deduction
        //    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });

        //    foreach (var emp in model.SaleContractSalaryTransactionList)
        //    {
        //        if (emp.RuleType == "Deduction" && emp.ContributionType == 1)
        //        {
        //            decimal amount = 0;
        //            if (emp.FixedAmount > 0)
        //            {
        //                amount = Math.Round(emp.FixedAmount);
        //            }
        //            else
        //            {
        //                var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
        //                decimal CalculateOnAmount = 0;
        //                foreach (var CalOn in CalculateOnValue)
        //                {
        //                    var ReferenceID = CalOn.Split('~');
        //                    if (Convert.ToByte(ReferenceID[0]) == 0)
        //                    {
        //                        CalculateOnAmount = CalculateOnAmount + BasicAmount;
        //                    }
        //                    else
        //                    {
        //                        foreach (var itemSub in model.SaleContractSalaryTransactionList)
        //                        {
        //                            if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
        //                            {
        //                                CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
        //                            }
        //                        }
        //                    }
        //                }
        //                amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

        //            }
        //            emp.Amount = amount;


        //            TotalDeduction = TotalDeduction + amount;
        //            ActualTotalDeduction = ActualTotalDeduction + emp.ActualAmount;
        //        }
        //    }

        //    if (tableLayoutAllowance.Rows.Count > tableLayoutDeduction.Rows.Count)
        //    {
        //        var count = tableLayoutAllowance.Rows.Count - tableLayoutDeduction.Rows.Count;
        //        for (int i = 0; i < count; i++)
        //        {

        //            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //            {
        //                HorizontalAlignment = Element.ALIGN_LEFT,
        //                Padding = 5,
        //                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //                UseVariableBorders = true,
        //                BorderColorRight = BaseColor.WHITE,
        //                BorderColorTop = BaseColor.WHITE,
        //                BorderColorBottom = BaseColor.WHITE,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            });
        //            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //            {
        //                HorizontalAlignment = Element.ALIGN_LEFT,
        //                Padding = 5,
        //                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //                UseVariableBorders = true,
        //                BorderColorLeft = BaseColor.WHITE,
        //                BorderColorTop = BaseColor.WHITE,
        //                BorderColorBottom = BaseColor.WHITE,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            });



        //        }

        //    }
        //    else
        //    {
        //        var count = tableLayoutDeduction.Rows.Count - tableLayoutAllowance.Rows.Count;
        //        for (int i = 0; i < count; i++)
        //        {
        //            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //            {
        //                HorizontalAlignment = Element.ALIGN_LEFT,
        //                Padding = 5,
        //                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //                UseVariableBorders = true,
        //                BorderColorRight = BaseColor.WHITE,
        //                BorderColorTop = BaseColor.WHITE,
        //                BorderColorBottom = BaseColor.WHITE,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            });
        //            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //            {
        //                HorizontalAlignment = Element.ALIGN_LEFT,
        //                Padding = 5,
        //                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //                UseVariableBorders = true,
        //                BorderColorLeft = BaseColor.WHITE,
        //                BorderColorRight = BaseColor.WHITE,
        //                BorderColorTop = BaseColor.WHITE,
        //                BorderColorBottom = BaseColor.WHITE,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            });


        //            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //            {
        //                HorizontalAlignment = Element.ALIGN_LEFT,
        //                Padding = 5,
        //                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //                UseVariableBorders = true,
        //                BorderColorLeft = BaseColor.WHITE,
        //                BorderColorTop = BaseColor.WHITE,
        //                BorderColorBottom = BaseColor.WHITE,
        //                VerticalAlignment = Element.ALIGN_MIDDLE
        //            });


        //            //AddCellToBodyWithLeftBorder(tableLayoutAllowance, "");
        //            //AddCellToBodyWithNoBorder(tableLayoutAllowance, "");
        //            //AddCellToBodyWithRightBorder(tableLayoutAllowance, "");
        //        }
        //    }
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Total Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(TotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });

        //    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Total Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorRight = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalDeduction), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
        //        UseVariableBorders = true,
        //        BorderColorLeft = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });


        //    tableLayoutAllowance.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

        //    tableLayoutDeduction.WriteSelectedRows(0, -1, doc.Left + 340, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);


        //    var AmountInWords = ConvertToWords(Convert.ToString(model.SaleContractSalaryTransactionList[0].NetPayable));

        //    tableLayoutTakeHomeSal.AddCell(new PdfPCell(new Phrase("Rupees " + AmountInWords, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_LEFT,
        //        Padding = 5,
        //        Colspan = 2,
        //        //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
        //        UseVariableBorders = true,
        //        BorderColorTop = BaseColor.WHITE,
        //        BorderColorLeft = BaseColor.WHITE,
        //        BorderColorBottom = BaseColor.WHITE,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutTakeHomeSal.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights(), writer.DirectContent);


        //    tableLayoutSigniture.AddCell(new PdfPCell(new Phrase("This is system generated report & signature is not required.", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
        //    {
        //        HorizontalAlignment = Element.ALIGN_CENTER,
        //        Padding = 5,
        //        Colspan = 2,
        //        //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
        //        UseVariableBorders = true,
        //        VerticalAlignment = Element.ALIGN_MIDDLE

        //    });
        //    tableLayoutSigniture.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights() - tableLayoutTakeHomeSal.CalculateHeights(), writer.DirectContent);


        //    // Closing the document  
        //    doc.Close();
        //    Response.ContentType = "application/pdf";
        //    Response.AddHeader("content-disposition", "attachment;" + "filename=" + model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterName + " " + model.SaleContractSalaryTransactionList[0].SaleContractBillingSpanName + ".pdf");
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.Write(doc);
        //    Response.End();


        //}

        [HttpGet]
        public FileStreamResult Download(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();
            try
            {
                List<string> ShortExtraPostingList = new List<string>();

                model.SaleContractBillingTransactionDTO = new SaleContractBillingTransaction();
                model.SaleContractBillingTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                decimal TotalAmount = 0; decimal TotalBillAmount = 0;
                model.SaleContractBillingTransactionList = GetBillingTransactionDetailsByIDForInvoicePDF(SaleContractMasterID, SaleContractBillingSpanID);
                string SaleContractInvoicePDF = " ";
                model.ContractNumber = model.SaleContractBillingTransactionList[0].ContractNumber;
                model.CustomerInvoiceNumber = model.SaleContractBillingTransactionList[0].CustomerInvoiceNumber;
                model.SalesInvoiceMasterID = model.SaleContractBillingTransactionList[0].SalesInvoiceMasterID;

                model.IsOtherState = model.SaleContractBillingTransactionList[0].IsOtherState;

                model.IsTaxExempted = model.SaleContractBillingTransactionList[0].IsTaxExempted;
                model.ReasonForExemption = model.SaleContractBillingTransactionList[0].ReasonForExemption;
                model.TaxExemptionRemark = model.SaleContractBillingTransactionList[0].TaxExemptionRemark;

                string FromDetailTable = "SaleContractInvoiceDetails";
                model.TaxSummaryList = GetTaxSummaryForDisplay(model.IsOtherState, model.SalesInvoiceMasterID, FromDetailTable);

                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table width='650'><tr><td style='text-align:left;'><img src='" + Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SaleContractBillingTransactionList[0].LogoPath) + "' height='70' width='70'><br><br><span style='font-size:7pt;text-align:left;'>" + model.SaleContractBillingTransactionList[0].PrintingLineBelowLogo + "<span></td>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + " <td><table width='300' bgcolor='#fff;' color='black' style='font-size:7pt;'><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:10pt;text-align:left;font-family:'Century Gothic'><b>" + model.SaleContractBillingTransactionList[0].CentreName + "</b></td></tr></hr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:9pt;text-align:left;'><b><u>" + model.SaleContractBillingTransactionList[0].CentreSpecialization + "</u></b></td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SaleContractBillingTransactionList[0].CentreAddress1 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>" + model.SaleContractBillingTransactionList[0].CentreAddress2 + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Ph:" + model.SaleContractBillingTransactionList[0].PhoneNumberOffice + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>Cell :" + model.SaleContractBillingTransactionList[0].CellPhone + "</td></tr><tr><td style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'>E-mail :" + model.SaleContractBillingTransactionList[0].EmailID + "</td>< tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' >Website :" + model.SaleContractBillingTransactionList[0].Website + " </td ></tr></tr>";

                DateTime DateTimeOfSupply = Convert.ToDateTime(model.SaleContractBillingTransactionList[0].DateTimeOfSupply);

                SaleContractInvoicePDF = SaleContractInvoicePDF + "</table></td></tr></table>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:7pt;'><b>PurchaseOrder</b><tr><td colspan='2'  bgcolor='#F7F2F2' style='padding:0 5px 5px;font-size:10pt;text-align:center;'><b><u>Tax Invoice</u><b></td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>GSTIN Number</b>: " + model.SaleContractBillingTransactionList[0].GSTINNumber + "</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>Transportation Mode <b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>PAN Number</b>: " + model.SaleContractBillingTransactionList[0].PanNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Vehical Number </b>: </td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;'><b>CIN Number</b>: " + model.SaleContractBillingTransactionList[0].CINNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '>Date and Time of Supply: " + CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(DateTimeOfSupply.Month) + " " + DateTimeOfSupply.Year + "</td></tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Tax is payable on Reverse Charge</b> :(No)</td><td  bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '><b>Place of Supply</b> : " + model.SaleContractBillingTransactionList[0].CustomerBranchAddress + " </td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Invoice Number</b> :" + model.SaleContractBillingTransactionList[0].CustomerInvoiceNumber + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '></td> </tr><tr><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;text-align:left; '><b>Invoice Date</b> :" + model.SaleContractBillingTransactionList[0].InvoiceTransactionDate + "</td><td bgcolor='#F7F2F2' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; '></td> </tr></table>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + "<br><table border= '1' bgcolor='#fff;' color='black' style=' border-collapse:collapse;font-size:11pt;'><b>Sales Order</b><tr><td bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Receiver(Billed)</b></td><td  bgcolor='#D3D3D3' color='black' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:11pt;text-align:Center;'><b>Details of Consinees(Shipped to)</b></td></tr>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Customer Name :</b> " + model.SaleContractBillingTransactionList[0].CustomerMasterName + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Branch Name: </b>" + model.SaleContractBillingTransactionList[0].CustomerBranchMasterName + " </td ></tr>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Address:</b> " + model.SaleContractBillingTransactionList[0].CustomerAddress + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Address:</b> " + model.SaleContractBillingTransactionList[0].CustomerBranchAddress + " </td ></tr>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Country:</b> " + model.SaleContractBillingTransactionList[0].CountryName + " &nbsp;&nbsp;<b> State:</b> " + model.SaleContractBillingTransactionList[0].StateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SaleContractBillingTransactionList[0].StateCode + " </td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' > <b>Country: </b>" + model.SaleContractBillingTransactionList[0].BranchCountryName + " &nbsp;&nbsp;<b> State: </b>" + model.SaleContractBillingTransactionList[0].BranchStateName + " &nbsp; &nbsp;<b> State Code:</b> " + model.SaleContractBillingTransactionList[0].BranchStateCode + " </td ></tr>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>City:</b> " + model.SaleContractBillingTransactionList[0].CityName + "<b>  Pin Code:</b> " + model.SaleContractBillingTransactionList[0].CustomerPinCode + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>City:</b> " + model.SaleContractBillingTransactionList[0].BranchCityName + " <b> Pin Code:</b> " + model.SaleContractBillingTransactionList[0].CustomerBranchPinCode + "</td ></tr><tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>GSTIN Number:</b> " + model.SaleContractBillingTransactionList[0].CustomerGSTNumber + "</td ><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>GSTIN Number:</b> " + model.SaleContractBillingTransactionList[0].BranchGSTNumber + " </td ></tr>";

                if (model.SaleContractBillingTransactionList[0].IsDisplayPurchaseDetails == true)
                {
                    SaleContractInvoicePDF = SaleContractInvoicePDF + " <tr><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left;' > <b>Purchase Order Number:</b> " + model.SaleContractBillingTransactionList[0].PurchaseOrderNumber + "<b>   Purchase Order Date:</b> " + model.SaleContractBillingTransactionList[0].PurchaseOrderDate + "</td><td style = 'border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:7pt;text-align:left; ' ><b>Purchase Order Number:</b> " + model.SaleContractBillingTransactionList[0].PurchaseOrderNumber + " <b>   Purchase Order Date:</b> " + model.SaleContractBillingTransactionList[0].PurchaseOrderDate + "</td ></tr></table>";
                }
                else
                {
                    SaleContractInvoicePDF = SaleContractInvoicePDF + " </table>";
                }

                SaleContractInvoicePDF = SaleContractInvoicePDF + "<br><table border= '1' bgcolor='#fff;' color='black'><tr><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Description of goods/services</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>HSN/SAC Code</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Quantity</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 0px;font-size:7pt'>UOM</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Rate</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Total</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Tax Amount</th><th  bgcolor='#D3D3D3' color='black' style='border: 1px solid black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt'>Amount</th></tr>";

                decimal TotalTaxableManPowerAmountAmount = 0;

                if (model.SaleContractBillingTransactionList.Count > 0 && model.SaleContractBillingTransactionList != null)
                {
                    foreach (var item in model.SaleContractBillingTransactionList)
                    {
                        if (item.SaleContractRequiredTypeID != 6 && item.SaleContractRequiredTypeID != 8 && item.Quantity > 0)
                        {
                            TotalAmount = TotalAmount + Math.Round(item.TaxableAmount, 2);
                            TotalTaxableManPowerAmountAmount = TotalTaxableManPowerAmountAmount + Math.Round(item.TaxableAmount, 2);
                            TotalBillAmount = TotalBillAmount + Math.Round(item.TaxableAmount, 2) + Math.Round(item.TaxAmount, 2);

                            decimal OriginalTaxableAmount = 0; decimal OriginalTaxAmount = 0; decimal OriginalNetAmount = 0;

                            if (item.BillingType == 2 && (item.FixedQuantity != item.OriginalQuantity))
                            {
                                OriginalTaxableAmount = item.Quantity * item.Rate;
                                if (model.IsTaxExempted == false)
                                {
                                    OriginalTaxAmount = Math.Round((OriginalTaxableAmount * item.TaxRate) / 100, 2);
                                }
                                OriginalNetAmount = OriginalTaxableAmount + OriginalTaxAmount;
                            }


                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td>";

                            //if (item.BillingType == 2 && (item.Quantity != item.OriginalQuantity))
                            //{
                            //    SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>1</td>";
                            //}
                            //else
                            //{
                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td>";
                            //}

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.UOMCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td>";

                            if (item.BillingType == 2 && (item.FixedQuantity != item.OriginalQuantity))
                            {
                                SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(OriginalTaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(OriginalTaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(OriginalNetAmount, 2) + "</td></tr>";
                            }
                            else
                            {
                                SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td></tr>";
                            }

                            if (item.BillingType == 2 && (item.FixedQuantity != item.OriginalQuantity))
                            {
                                decimal DiffQuantity = Math.Abs(item.FixedQuantity - item.OriginalQuantity);
                                byte DiffQuantityIsPositive = (item.FixedQuantity > item.OriginalQuantity) ? Convert.ToByte(1) : Convert.ToByte(0);
                                decimal DiffTaxableAmount = Math.Round(DiffQuantity * item.ShortExtraRate, 2);
                                decimal DiffTaxAmount = 0;
                                if (model.IsTaxExempted == false)
                                {
                                    DiffTaxAmount = Math.Round((DiffTaxableAmount * item.TaxRate) / 100, 2);
                                }
                                decimal DiffNetAmount = DiffTaxableAmount + DiffTaxAmount;

                                ShortExtraPostingList.Add(Convert.ToString(item.GeneralTaxGroupMasterID));
                                ShortExtraPostingList.Add(Convert.ToString(DiffTaxableAmount));
                                ShortExtraPostingList.Add(Convert.ToString(DiffQuantityIsPositive));

                                if (DiffQuantityIsPositive == 1)
                                {
                                    if (item.SaleContractRequiredTypeID == 5 && item.FixedBillingType == 3)
                                    {
                                        TotalTaxableManPowerAmountAmount = TotalTaxableManPowerAmountAmount - DiffTaxableAmount;
                                    }
                                    SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Short Posting</td>";
                                }
                                else
                                {
                                    if (item.SaleContractRequiredTypeID == 5 && item.FixedBillingType == 3)
                                    {
                                        TotalTaxableManPowerAmountAmount = TotalTaxableManPowerAmountAmount + DiffTaxableAmount;
                                    }
                                    SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Extra Posting</td>";
                                }
                                SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(DiffQuantity, 3) + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>Pstgs</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.ShortExtraRate, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(DiffTaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(DiffTaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(DiffNetAmount, 2) + "</td></tr>";
                            }
                        }
                    }
                    foreach (var item in model.SaleContractBillingTransactionList)
                    {
                        if (item.SaleContractRequiredTypeID == 8 && item.IsServiceChargesAppliedToServiceItem == true)
                        {
                            TotalAmount = TotalAmount + Math.Round(item.TaxableAmount, 2);
                            TotalTaxableManPowerAmountAmount = TotalTaxableManPowerAmountAmount + Math.Round(item.TaxableAmount, 2);
                            TotalBillAmount = TotalBillAmount + Math.Round(item.TaxableAmount, 2) + Math.Round(item.TaxAmount, 2);

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.UOMCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td></tr>";

                        }
                    }
                    foreach (var item in model.SaleContractBillingTransactionList)
                    {
                        if (item.SaleContractRequiredTypeID == 6)
                        {
                            TotalAmount = TotalAmount + Math.Round(item.TaxableAmount, 2);
                            TotalBillAmount = TotalBillAmount + Math.Round(item.TaxableAmount, 2) + Math.Round(item.TaxAmount, 2);

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Sub Total</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(TotalTaxableManPowerAmountAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'></td></tr>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.UOMCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td></tr>";

                        }
                    }
                    foreach (var item in model.SaleContractBillingTransactionList)
                    {
                        if (item.SaleContractRequiredTypeID == 8 && item.IsServiceChargesAppliedToServiceItem == false)
                        {
                            TotalAmount = TotalAmount + Math.Round(item.TaxableAmount, 2);
                            TotalBillAmount = TotalBillAmount + Math.Round(item.TaxableAmount, 2) + Math.Round(item.TaxAmount, 2);

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' width='27%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.ItemDescription + "</td><td  bgcolor='#F7F2F2' width='7%' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>" + item.HSNCode + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='5%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + Math.Round(item.Quantity, 3) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2' width='7%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;'>" + item.UOMCode + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt;text-align:right '>" + Math.Round(item.Rate, 2) + "</td>";

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxableAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + item.GeneralTaxGroupMasterName + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.TaxAmount, 2) + "</td><td  bgcolor='#F7F2F2'  width='8%' color='black' style='border: 1px black; border-collapse: collapse; text-align: center; padding: 5px;font-size:7pt; text-align:right'>" + Math.Round(item.NetAmount, 2) + "</td></tr>";

                        }
                    }
                    //if (model.IsTaxExempted == true)
                    //{
                    //    if ((model.ReasonForExemption == 1) && model.TaxExemptionRemark != "")
                    if (model.TaxExemptionRemark != "")
                    {
                        SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td  bgcolor='#F7F2F2' colspan='9' color='black' style='border-collapse: collapse; text-align: left; padding: 5px;font-size:7pt;'>Note:- '" + model.TaxExemptionRemark + "'</td></tr>";
                    }
                    //}
                }

                SaleContractInvoicePDF = SaleContractInvoicePDF + "</table>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<br><table style='width:100%;'><tr><td width='40%'>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right;'>Net Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + TotalAmount + "</td></tr></tr>";

                if (model.TaxSummaryList.Count > 0 && model.TaxSummaryList != null)
                {
                    foreach (var itemList in model.TaxSummaryList)
                    {
                        String[] TaxList = itemList.TaxList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxAmount = itemList.TaxAmountList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxRate = itemList.TaxRateList.Replace(", ", ",").Split(new char[] { ',' });
                        String[] TaxableAmountList = itemList.TaxableAmountList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int i = 0; i < TaxAmount.Count(); i++)
                        {
                            decimal TotalTaxAmount = Convert.ToDecimal(TaxAmount[i]);
                            decimal TotalTaxableAmount = Convert.ToDecimal(TaxableAmountList[i]);
                            for (int k = 0; k < ShortExtraPostingList.Count(); k = k + 3)
                            {
                                if (itemList.ID == Convert.ToByte(ShortExtraPostingList[k]) && model.IsTaxExempted == false)
                                {
                                    decimal taxAmount = Math.Round(Convert.ToDecimal(ShortExtraPostingList[k + 1]) * Convert.ToDecimal(TaxRate[i]) / 100, 2);
                                    if (Convert.ToByte(ShortExtraPostingList[k + 2]) == 1)
                                    {
                                        TotalTaxAmount = TotalTaxAmount - taxAmount;
                                        TotalTaxableAmount = TotalTaxableAmount - Convert.ToDecimal(ShortExtraPostingList[k + 1]);
                                    }
                                    else
                                    {
                                        TotalTaxAmount = TotalTaxAmount + taxAmount;
                                        TotalTaxableAmount = TotalTaxableAmount + Convert.ToDecimal(ShortExtraPostingList[k + 1]);
                                    }
                                }
                            }

                            SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px solid black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TaxList[i] + "% on " + TotalTaxableAmount + "</td><td style='border: 1px black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right;'>" + TotalTaxAmount + "</td></tr>";
                        }
                    }
                }

                string Amountt = Convert.ToString(Math.Round(TotalBillAmount));
                var AmountInWords = ConvertToWords(Amountt);

                SaleContractInvoicePDF = SaleContractInvoicePDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:right; '> Total Amount</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:right; '>" + Math.Round(TotalBillAmount) + "</td> </tr></table></td></tr></table>";

                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table border= '1' bgcolor='#fff;' color='black'><tr><td bgcolor='#D3D3D3' style='border: 1px;font-size:8pt; solid black;border-collapse: collapse; padding: 5px;text-align:left;'><b>Invoice Value (In Words) Rs. :</b>" + AmountInWords + " </td></tr></table>";



                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table><tr><td width='38%'>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Prepared By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='38%'>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Checked By</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table><td width='37%'>";
                SaleContractInvoicePDF = SaleContractInvoicePDF + "<table style='width:38%' ><tr><th style='font-size:8pt;text-align:left'>Authorised Signatory</th></tr><tr><td style='text-align:left'> ___________________</td></tr></table></td></tr></table>";
                //SaleContractInvoicePDF = SaleContractInvoicePDF + "</table>";
                DownloadPDF1(SaleContractInvoicePDF, model.CustomerInvoiceNumber, Convert.ToInt32(model.SaleContractBillingTransactionList[0].SaleContractMasterID), model.SaleContractBillingTransactionList[0].IsCanceled);
                MemoryStream workStream = new MemoryStream();
                return new FileStreamResult(workStream, "application/pdf");


            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DownloadPDF1(string SaleContractInvoicePDF, string CustomerInvoiceNumber, int SaleContractMasterID, bool IsCanceled)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "Contract" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDF(SaleContractInvoicePDF, IsCanceled));
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

        //Summery sheet
        [HttpGet]
        public ActionResult DownloadSummery(string SaleContractMasterID, string SaleContractBillingSpanID, string SummaryFormat)
        {
            SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();
            try
            {
                model.SaleContractBillingTransactionDTO = new SaleContractBillingTransaction();
                model.SaleContractBillingTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractBillingTransactionList = GetBillingTransactionDetailsForSummerySheet(SaleContractMasterID, SaleContractBillingSpanID, SummaryFormat);

                if (model.SaleContractBillingTransactionList.Count > 0)
                {

                    string SaleContractBillingSummeryyPDF = " ";
                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<html><body><span style='text-align:left'><b>" + model.SaleContractBillingTransactionList[0].CustomerMasterName + "</b><br></body></html>";
                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><br><html><body><u><span style='text-align:left'>" + model.SaleContractBillingTransactionList[0].SaleContractBillingSpanName + "  BILLING DETAILED SHEET </u><br></body></html>";
                    string[] SaleContractManPowerItemList = model.SaleContractBillingTransactionList[0].SaleContractManPowerItemList.Replace(", ", ",").Split(new char[] { ',' });
                    if (SaleContractManPowerItemList.Count() > 0)
                    {
                        for (int i = 0, j = 0, k = 0; i < SaleContractManPowerItemList.Count(); i++)
                        {
                            decimal TotalOverTime = model.SaleContractBillingTransactionList[j].TotalOverTime;
                            decimal OverTimeRate = model.SaleContractBillingTransactionList[j].OverTimeRate;
                            decimal OverTimeAmount = model.SaleContractBillingTransactionList[j].OverTimeAmount;
                            decimal AdditionalAmount = model.SaleContractBillingTransactionList[j].AdditionalAmount;
                            string CategoryName = model.SaleContractBillingTransactionList[j].SaleContractManPowerItemName;
                            decimal TotalBillAmount = 0;

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                            if (Convert.ToInt32(SaleContractManPowerItemList[i]) == model.SaleContractBillingTransactionList[j].SaleContractManPowerItemID)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total wkg days</b></td>";
                            }
                            bool IsDAAdded = false;
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType == "DA")
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Basic + DA</b></td>";
                                    IsDAAdded = true;
                                }
                            }
                            if (IsDAAdded == false)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Basic</b></td>";
                            }
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType != "DA" && item.HeadType != "OT" && item.IsAllowance == true && item.ComplianceType == 1)
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + item.HeadType + "</b></td>";
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Gross</b></td>";
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + item.HeadType + "</b></td>";
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total</b></td>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</tr>";

                            if (Convert.ToInt32(SaleContractManPowerItemList[i]) == model.SaleContractBillingTransactionList[k].SaleContractManPowerItemID)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + model.SaleContractBillingTransactionList[k].SaleContractManPowerItemName + "</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + model.SaleContractBillingTransactionList[k].TotalDaysSum + "</td>";
                            }
                            bool IsDAValueAdded = false; decimal BasicAmount = model.SaleContractBillingTransactionList[k].BasicAmount;
                            decimal GrossAmount = 0;
                            decimal TotalSalary = 0;
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType == "DA")
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(BasicAmount + item.AllowanceDeductionAmount) + "</td>";
                                    IsDAValueAdded = true;
                                    GrossAmount += (BasicAmount + item.AllowanceDeductionAmount);
                                    TotalSalary += (BasicAmount + item.AllowanceDeductionAmount);
                                }
                            }
                            if (IsDAValueAdded == false)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + BasicAmount + "</td>";
                                GrossAmount += BasicAmount;
                                TotalSalary += BasicAmount;
                            }
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType != "DA" && item.HeadType != "OT" && item.IsAllowance == true)
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AllowanceDeductionAmount) + "</td>";
                                    GrossAmount += item.AllowanceDeductionAmount;
                                    TotalSalary += item.AllowanceDeductionAmount;
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(GrossAmount) + "</td>";
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AllowanceDeductionAmount) + "</td>";
                                    TotalSalary += item.AllowanceDeductionAmount;
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalary) + "</td>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</tr>";

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</table>";

                            TotalBillAmount = TotalBillAmount + TotalSalary;

                            if (TotalOverTime > 0)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>No of OT</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Rate/Day</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + CategoryName + " OT</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + TotalOverTime + "</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(OverTimeRate, 2) + "</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(OverTimeAmount) + "</b></td></tr></table>";
                                TotalBillAmount = TotalBillAmount + OverTimeAmount;

                            }
                            if (AdditionalAmount > 0)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + CategoryName + " ONE PERSON ADDT.AMOUNT SERVICE CHARGES</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(AdditionalAmount) + "</b></td></tr></table>";
                                TotalBillAmount = TotalBillAmount + AdditionalAmount;
                            }

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalBillAmount) + "</b></td></tr></table>";
                        }
                    }

                    DownloadPDF(SaleContractBillingSummeryyPDF, SaleContractMasterID, Convert.ToInt32(model.SaleContractBillingTransactionList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "Salary is Not Generated";
                    return RedirectToAction("Index", "SaleContractBillingTransaction");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult DownloadSummerySecond(string SaleContractMasterID, string SaleContractBillingSpanID, string SummaryFormat)
        {
            SaleContractBillingTransactionViewModel model = new SaleContractBillingTransactionViewModel();
            try
            {
                model.SaleContractBillingTransactionDTO = new SaleContractBillingTransaction();
                model.SaleContractBillingTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                model.SaleContractBillingTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractBillingTransactionList = GetBillingTransactionDetailsForSummerySheet(SaleContractMasterID, SaleContractBillingSpanID, SummaryFormat);

                if (model.SaleContractBillingTransactionList.Count > 0)
                {

                    string SaleContractBillingSummeryyPDF = " ";
                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<html><body><span style='text-align:left'><b>" + model.SaleContractBillingTransactionList[0].CustomerMasterName + "</b><br></body></html>";
                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><br><html><body><u><span style='text-align:left'>" + model.SaleContractBillingTransactionList[0].SaleContractBillingSpanName + "  BILLING DETAILED SHEET </u><br></body></html>";
                    string[] SaleContractManPowerItemList = model.SaleContractBillingTransactionList[0].SaleContractManPowerItemList.Replace(", ", ",").Split(new char[] { ',' });
                    if (SaleContractManPowerItemList.Count() > 0)
                    {
                        for (int i = 0, j = 0, k = 0; i < SaleContractManPowerItemList.Count(); i++)
                        {
                            decimal TotalOverTime = model.SaleContractBillingTransactionList[j].TotalOverTime;
                            decimal OverTimeRate = model.SaleContractBillingTransactionList[j].OverTimeRate;
                            decimal OverTimeAmount = model.SaleContractBillingTransactionList[j].OverTimeAmount;
                            decimal AdditionalAmount = model.SaleContractBillingTransactionList[j].AdditionalAmount;
                            string CategoryName = model.SaleContractBillingTransactionList[j].SaleContractManPowerItemName;
                            decimal TotalBillAmount = 0;

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                            if (Convert.ToInt32(SaleContractManPowerItemList[i]) == model.SaleContractBillingTransactionList[j].SaleContractManPowerItemID)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total wkg days</b></td>";
                            }
                            bool IsDAAdded = false;
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType == "DA")
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Basic + DA</b></td>";
                                    IsDAAdded = true;
                                }
                            }
                            if (IsDAAdded == false)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Basic</b></td>";
                            }
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType != "DA" && item.HeadType != "OT" && item.IsAllowance == true && item.ComplianceType == 1)
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + item.HeadType + "</b></td>";
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Gross</b></td>";
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                                {
                                    j++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + item.HeadType + "</b></td>";
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total</b></td>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</tr>";

                            if (Convert.ToInt32(SaleContractManPowerItemList[i]) == model.SaleContractBillingTransactionList[k].SaleContractManPowerItemID)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + model.SaleContractBillingTransactionList[k].SaleContractManPowerItemName + "</td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + model.SaleContractBillingTransactionList[k].TotalDaysSum + "</td>";
                            }
                            bool IsDAValueAdded = false; decimal BasicAmount = model.SaleContractBillingTransactionList[k].BasicAmount;
                            decimal GrossAmount = 0;
                            decimal TotalSalary = 0;
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType == "DA")
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(BasicAmount + item.AllowanceDeductionAmount) + "</td>";
                                    IsDAValueAdded = true;
                                    GrossAmount += (BasicAmount + item.AllowanceDeductionAmount);
                                    TotalSalary += (BasicAmount + item.AllowanceDeductionAmount);
                                }
                            }
                            if (IsDAValueAdded == false)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + BasicAmount + "</td>";
                                GrossAmount += BasicAmount;
                                TotalSalary += BasicAmount;
                            }
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.HeadType != "DA" && item.HeadType != "OT" && item.IsAllowance == true)
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AllowanceDeductionAmount) + "</td>";
                                    GrossAmount += item.AllowanceDeductionAmount;
                                    TotalSalary += item.AllowanceDeductionAmount;
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(GrossAmount) + "</td>";
                            foreach (var item in model.SaleContractBillingTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractManPowerItemList[i]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                                {
                                    k++;
                                    SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AllowanceDeductionAmount) + "</td>";
                                    TotalSalary += item.AllowanceDeductionAmount;
                                }
                            }
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalary) + "</td>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</tr>";

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "</table>";

                            TotalBillAmount = TotalBillAmount + TotalSalary;

                            if (TotalOverTime > 0)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>No of OT</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Rate/Day</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + CategoryName + " OT</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + TotalOverTime + "</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(OverTimeRate, 2) + "</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(OverTimeAmount) + "</b></td></tr></table>";
                                TotalBillAmount = TotalBillAmount + OverTimeAmount;

                            }
                            if (AdditionalAmount > 0)
                            {
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                                SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + CategoryName + " ONE PERSON ADDT.AMOUNT SERVICE CHARGES</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(AdditionalAmount) + "</b></td></tr></table>";
                                TotalBillAmount = TotalBillAmount + AdditionalAmount;
                            }

                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<br><table width='100%' style='margin-bottom:150px;' border= '1'>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>CATEGORY</b></td><td bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total Amount</b></td></tr>";
                            SaleContractBillingSummeryyPDF = SaleContractBillingSummeryyPDF + "<tr><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>Total</b></td><td style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalBillAmount) + "</b></td></tr></table>";
                        }
                    }

                    DownloadPDF(SaleContractBillingSummeryyPDF, SaleContractMasterID, Convert.ToInt32(model.SaleContractBillingTransactionList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "Salary is Not Generated";
                    return RedirectToAction("Index", "SaleContractBillingTransaction");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DownloadPDF(string SaleContractCillingSummeryyPDF, string CustomerInvoiceNumber, int SaleContractMasterID)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "BillingSummery" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDFDetails(SaleContractCillingSummeryyPDF));
            Response.End();
        }
        public byte[] GetPDFDetails(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

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

        #endregion

        #region Methods

        protected List<InventoryLocationMaster> GetInventoryIssueLocationMasterList(int AdminRoleID)
        {
            InventoryLocationMasterSearchRequest searchRequest = new InventoryLocationMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.AdminRoleID = AdminRoleID;
            List<InventoryLocationMaster> listLocationMaster = new List<InventoryLocationMaster>();
            IBaseEntityCollectionResponse<InventoryLocationMaster> baseEntityCollectionResponse = _InventoryLocationMasterBA.GetInventoryLocationMasterlistByAdminRole(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listLocationMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listLocationMaster;
        }

        protected List<SaleContractBillingTransaction> GetBillingTransactionForGeneration(string SaleContractMasterID, string SaleContractBillingSpanID, string BillingType)
        {

            SaleContractBillingTransactionSearchRequest searchRequest = new SaleContractBillingTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.BillingType = Convert.ToByte(BillingType);

            List<SaleContractBillingTransaction> listSaleContractBillingTransaction = new List<SaleContractBillingTransaction>();
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetBillingTransactionForGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractBillingTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractBillingTransaction;
        }

        protected List<SaleContractBillingTransaction> GetBillingTransactionDetailsByID(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractBillingTransactionSearchRequest searchRequest = new SaleContractBillingTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractBillingTransaction> listSaleContractBillingTransaction = new List<SaleContractBillingTransaction>();
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetBillingTransactionDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractBillingTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractBillingTransaction;
        }
        protected List<SaleContractBillingTransaction> GetBillingTransactionDetailsByIDForInvoicePDF(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractBillingTransactionSearchRequest searchRequest = new SaleContractBillingTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractBillingTransaction> listSaleContractBillingTransaction = new List<SaleContractBillingTransaction>();
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetBillingTransactionDetailsByIDForInvoicePDF(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractBillingTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractBillingTransaction;
        }
        protected List<SaleContractBillingTransaction> GetBillingTransactionDetailsForSummerySheet(string SaleContractMasterID, string SaleContractBillingSpanID, string SummaryFormat)
        {

            SaleContractBillingTransactionSearchRequest searchRequest = new SaleContractBillingTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SummaryFormat = Convert.ToByte(SummaryFormat);

            List<SaleContractBillingTransaction> listSaleContractBillingTransaction = new List<SaleContractBillingTransaction>();
            IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollectionResponse = null;
            if (searchRequest.SummaryFormat == 1)
            {
                baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetSummerySheetForBillingTransactionDetails(searchRequest);
            }
            else
            {
                baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetSummerySheetForBillingTransactionDetails(searchRequest);
            }
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractBillingTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractBillingTransaction;
        }


        [NonAction]
        public IEnumerable<SaleContractBillingTransactionViewModel> GetSaleContractBillingTransaction(out int TotalRecords)
        {
            try
            {
                SaleContractBillingTransactionSearchRequest searchRequest = new SaleContractBillingTransactionSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);

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
                    searchRequest.SortBy = _sortBy;                     // parameters for SelectAll procedures under normal condition(Procedure Name : USP_AdminPostApplicableToRole_SelectAll)
                    searchRequest.StartRow = _startRow;
                    searchRequest.EndRow = _startRow + _rowLength;
                    searchRequest.SearchBy = _searchBy;
                    searchRequest.SortDirection = _sortDirection;
                }

                List<SaleContractBillingTransactionViewModel> listSaleContractMasterViewModel = new List<SaleContractBillingTransactionViewModel>();
                List<SaleContractBillingTransaction> listSaleContractMaster = new List<SaleContractBillingTransaction>();
                IBaseEntityCollectionResponse<SaleContractBillingTransaction> baseEntityCollectionResponse = _SaleContractBillingTransactionBA.GetSaleContractBillingTransactionBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractBillingTransaction item in listSaleContractMaster)
                        {
                            SaleContractBillingTransactionViewModel SaleContractMasterViewModel = new SaleContractBillingTransactionViewModel();
                            SaleContractMasterViewModel.SaleContractBillingTransactionDTO = item;
                            listSaleContractMasterViewModel.Add(SaleContractMasterViewModel);
                        }
                    }
                }
                TotalRecords = baseEntityCollectionResponse.TotalRecords;

                return listSaleContractMasterViewModel;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractBillingTransactionViewModel> filteredSaleContractBillingTransaction;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "ContractNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ContractNumber Like '%" + param.sSearch + "%' or CustomerInvoiceNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "ContractNumber";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "ContractNumber Like '%" + param.sSearch + "%' or CustomerInvoiceNumber Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSaleContractBillingTransaction = GetSaleContractBillingTransaction(out TotalRecords);

            var records = filteredSaleContractBillingTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.IsBillGenerated), Convert.ToString(c.SaleContractMasterID), Convert.ToString(c.ContractNumber), Convert.ToString(c.SaleContractBillingSpanID), Convert.ToString(c.SaleContractBillingSpanName), Convert.ToString(c.TotalBillAmount), Convert.ToString(c.RoundOffAmount), Convert.ToString(c.BillingType), Convert.ToString(c.CustomerInvoiceNumber) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


