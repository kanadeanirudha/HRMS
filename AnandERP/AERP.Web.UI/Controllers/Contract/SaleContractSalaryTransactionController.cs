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

namespace AERP.Web.UI.Controllers
{
    public class SaleContractSalaryTransactionController : BaseController
    {
        ISaleContractSalaryTransactionBA _SaleContractSalaryTransactionBA = null;

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

        public SaleContractSalaryTransactionController()
        {
            _SaleContractSalaryTransactionBA = new SaleContractSalaryTransactionBA();
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
                SaleContractSalaryTransactionViewModel _SaleContractSalaryTransactionViewModel = new SaleContractSalaryTransactionViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    _SaleContractSalaryTransactionViewModel.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    _SaleContractSalaryTransactionViewModel.errorMessage = "NoMessage";
                }

                return View("/Views/Contract/SaleContractSalaryTransaction/Index.cshtml", _SaleContractSalaryTransactionViewModel);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        public ActionResult List(string actionMode, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
                model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                return PartialView("/Views/Contract/SaleContractSalaryTransaction/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult GenerateSalary(string SaleContractEmployeeMasterID, string SaleContractMasterID, string SaleContractBillingSpanID, string SaleContractManPowerItemID)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();

            model.SaleContractEmployeeMasterID = Convert.ToInt64(SaleContractEmployeeMasterID);
            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.SaleContractManPowerItemID = Convert.ToInt32(SaleContractManPowerItemID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.SaleContractSalaryTransactionList = GetSalaryTransactionForGeneration(SaleContractEmployeeMasterID, SaleContractMasterID, SaleContractBillingSpanID, SaleContractManPowerItemID);

            return PartialView("/Views/Contract/SaleContractSalaryTransaction/GenerateSalary.cshtml", model);
        }

        [HttpGet]
        public ActionResult GenerateBulkSalary(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();

            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.SaleContractSalaryTransactionList = GetSalaryTransactionForBulkGeneration(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractSalaryTransaction/GenerateBulkSalary.cshtml", model);
        }

        [HttpPost]
        public ActionResult GenerateSalary(SaleContractSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractSalaryTransactionDTO != null)
                {
                    model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterID = model.SaleContractEmployeeMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractManPowerItemID = model.SaleContractManPowerItemID;
                    model.SaleContractSalaryTransactionDTO.BasicSalayAmount = model.BasicSalayAmount;
                    model.SaleContractSalaryTransactionDTO.AdjustedBasicAmount = model.AdjustedBasicAmount;
                    model.SaleContractSalaryTransactionDTO.TotalAmount = model.TotalAmount;
                    model.SaleContractSalaryTransactionDTO.GrossAmount = model.GrossAmount;
                    model.SaleContractSalaryTransactionDTO.TotalEarnings = model.TotalEarnings;
                    model.SaleContractSalaryTransactionDTO.TotalDeduction = model.TotalDeduction;
                    model.SaleContractSalaryTransactionDTO.NetPayable = model.NetPayable;
                    model.SaleContractSalaryTransactionDTO.AdjustedNetPayable = model.AdjustedNetPayable;
                    model.SaleContractSalaryTransactionDTO.EmployerContributionTotal = model.EmployerContributionTotal;
                    model.SaleContractSalaryTransactionDTO.TotalSalary = model.TotalSalary;
                    model.SaleContractSalaryTransactionDTO.AdjustedTotalSalary = model.AdjustedTotalSalary;
                    model.SaleContractSalaryTransactionDTO.AdjustedTotalDays = model.AdjustedTotalDays;
                    model.SaleContractSalaryTransactionDTO.XMLStringSalaryTransaction = model.XMLStringSalaryTransaction;
                    model.SaleContractSalaryTransactionDTO.IsRemoveForAdjustment = model.IsRemoveForAdjustment;
                    model.SaleContractSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractSalaryTransaction> response = _SaleContractSalaryTransactionBA.GenerateSaleContractSalaryTransaction(model.SaleContractSalaryTransactionDTO);

                    model.SaleContractSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult SaveSalary(SaleContractSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractSalaryTransactionDTO != null)
                {
                    model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractSalaryTransactionDTO.SaleContractEmployeeMasterID = model.SaleContractEmployeeMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractManPowerItemID = model.SaleContractManPowerItemID;
                    model.SaleContractSalaryTransactionDTO.BasicSalayAmount = model.BasicSalayAmount;
                    model.SaleContractSalaryTransactionDTO.AdjustedBasicAmount = model.AdjustedBasicAmount;
                    model.SaleContractSalaryTransactionDTO.TotalAmount = model.TotalAmount;
                    model.SaleContractSalaryTransactionDTO.GrossAmount = model.GrossAmount;
                    model.SaleContractSalaryTransactionDTO.TotalEarnings = model.TotalEarnings;
                    model.SaleContractSalaryTransactionDTO.TotalDeduction = model.TotalDeduction;
                    model.SaleContractSalaryTransactionDTO.NetPayable = model.NetPayable;
                    model.SaleContractSalaryTransactionDTO.EmployerContributionTotal = model.EmployerContributionTotal;
                    model.SaleContractSalaryTransactionDTO.TotalSalary = model.TotalSalary;
                    model.SaleContractSalaryTransactionDTO.AdjustedTotalSalary = model.AdjustedTotalSalary;
                    model.SaleContractSalaryTransactionDTO.AdjustedTotalDays = model.AdjustedTotalDays;
                    model.SaleContractSalaryTransactionDTO.XMLStringSalaryTransaction = model.XMLStringSalaryTransaction;
                    model.SaleContractSalaryTransactionDTO.IsRemoveForAdjustment = model.IsRemoveForAdjustment;
                    model.SaleContractSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractSalaryTransaction> response = _SaleContractSalaryTransactionBA.SaveSaleContractSalaryTransaction(model.SaleContractSalaryTransactionDTO);

                    model.SaleContractSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult GenerateBulkSalary(SaleContractSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractSalaryTransactionDTO != null)
                {
                    model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractSalaryTransactionDTO.XMLStringBulkSalaryTransactionEmployee = model.XMLStringBulkSalaryTransactionEmployee;
                    model.SaleContractSalaryTransactionDTO.XMLStringBulkSalaryTransaction = model.XMLStringBulkSalaryTransaction;
                    model.SaleContractSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractSalaryTransaction> response = _SaleContractSalaryTransactionBA.GenerateSaleContractBulkSalaryTransaction(model.SaleContractSalaryTransactionDTO);

                    model.SaleContractSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult SaveBulkSalary(SaleContractSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractSalaryTransactionDTO != null)
                {
                    model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractSalaryTransactionDTO.XMLStringBulkSalaryTransactionEmployee = model.XMLStringBulkSalaryTransactionEmployee;
                    model.SaleContractSalaryTransactionDTO.XMLStringBulkSalaryTransaction = model.XMLStringBulkSalaryTransaction;
                    model.SaleContractSalaryTransactionDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractSalaryTransaction> response = _SaleContractSalaryTransactionBA.SaveSaleContractBulkSalaryTransaction(model.SaleContractSalaryTransactionDTO);

                    model.SaleContractSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult ViewSalaryDetails(string ID)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();

            model.ID = Convert.ToInt64(ID);
            model.SaleContractSalaryTransactionList = GetSalaryTransactionDetailsByID(ID);

            return PartialView("/Views/Contract/SaleContractSalaryTransaction/ViewSalaryDetails.cshtml", model);
        }

        [HttpGet]
        public ActionResult AddDeduction(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();

            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractSalaryTransaction> SaleContractSalaryTransaction = GetListSaleContractSalaryTransactionDeduction();
            List<SelectListItem> SaleContractSalaryTransactionDeductionList = new List<SelectListItem>();
            foreach (SaleContractSalaryTransaction item in SaleContractSalaryTransaction)
            {
                SaleContractSalaryTransactionDeductionList.Add(new SelectListItem { Text = item.HeadName, Value = Convert.ToString(item.HeadID) + "~" + Convert.ToString(item.SaleContractManPowerDeductionID) });
            }
            ViewBag.SaleContractSalaryTransactionDeductionList = new SelectList(SaleContractSalaryTransactionDeductionList, "Value", "Text");

            return PartialView("/Views/Contract/SaleContractSalaryTransaction/AddDeduction.cshtml", model);
        }

        [HttpPost]
        public ActionResult AddDeduction(SaleContractSalaryTransactionViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractSalaryTransactionDTO != null)
                {
                    model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                    model.SaleContractSalaryTransactionDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    string[] splitHeadName = model.HeadName.Split('~');
                    model.SaleContractSalaryTransactionDTO.HeadID = Convert.ToByte(splitHeadName[0]);
                    model.SaleContractSalaryTransactionDTO.SaleContractManPowerDeductionID = Convert.ToInt32(splitHeadName[1]);

                    model.SaleContractSalaryTransactionDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractSalaryTransaction> response = _SaleContractSalaryTransactionBA.AddSaleContractSalaryTransactionDeduction(model.SaleContractSalaryTransactionDTO);

                    model.SaleContractSalaryTransactionDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractSalaryTransactionDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
                SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
                model.SaleContractSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractSalaryTransaction/DownloadOption.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult NRDownloadOption(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
                model.SaleContractSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractSalaryTransaction/NRDownloadOption.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
        //[HttpGet]
        //public FileStreamResult Download(string ID)
        //{
        //    SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
        //    try
        //    {


        //        model.SaleContractSalaryTransactionDTO = new SaleContractSalaryTransaction();
        //        model.SaleContractSalaryTransactionDTO.ID = Convert.ToInt64(ID);
        //        model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
        //        //Code For Generate PDF
        //        model.SaleContractSalaryTransactionList = GetSalaryTransactionDetailsByID(ID);





        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //Link-http://www.c-sharpcorner.com/article/create-a-pdf-file-and-download-using-Asp-Net-mvc/
        //Link-https://stackoverflow.com/questions/5082631/how-do-i-insert-a-table-into-a-pdf-document-with-itextsharp
        [HttpGet]
        public ActionResult SalarySlipExcel(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
            model.SaleContractSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            model.SaleContractSalarySlipExcelList = GetSalaryTransactionForSalarySlipExcel(SaleContractMasterID, SaleContractBillingSpanID);

            return View("/Views/Contract/SaleContractSalaryTransaction/SalarySlipExcel.cshtml", model);
        }
        public void Download(string ID)
        {
            // MemoryStream workStream = new MemoryStream();

            StringBuilder status = new StringBuilder("");
            DateTime dTime = DateTime.Now;
            //file name to be created   
            Document doc = new Document();
            doc.SetMargins(0f, 0f, 0f, 0f);

            //Create PDF Table with 5 columns  
            PdfPTable tableLayoutHeader = new PdfPTable(3);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 4 columns  for Employee Information
            PdfPTable tableLayoutEmpDetails = new PdfPTable(4);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 3 columns for Employee Allowance
            PdfPTable tableLayoutAllowance = new PdfPTable(3);
            doc.SetMargins(20f, 20f, 20f, 20f);

            //Create PDF Table with 2 columns for Employee Allowance
            PdfPTable tableLayoutDeduction = new PdfPTable(2);
            doc.SetMargins(20f, 20f, 20f, 20f);
            //Create PDF Table with 4 columns for Employee Take Home Salary
            PdfPTable tableLayoutTakeHomeSal = new PdfPTable(4);
            doc.SetMargins(20f, 20f, 20f, 20f);
            //Create PDF Table with 1 columns for Company Signiture
            PdfPTable tableLayoutSigniture = new PdfPTable(1);
            doc.SetMargins(20f, 20f, 20f, 20f);


            //Create PDF Table  

            PdfWriter writer = PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            //Add Title to the PDF file at the top  
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();

            model.SaleContractSalaryTransactionDTO = new SaleContractSalaryTransaction();
            model.SaleContractSalaryTransactionDTO.ID = Convert.ToInt64(ID);
            model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
            model.SaleContractSalaryTransactionList = GetSalaryTransactionDetailsByID(ID);

            //Add Content to PDF 
            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headers = { 50, 30, 50 }; //Header Widths  
            tableLayoutHeader.SetWidths(headers); //Set the pdf headers  
            tableLayoutHeader.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutHeader.HeaderRows = 1;


            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersEmpDetails = { 50, 50, 50, 50 }; //Header Widths  
            tableLayoutEmpDetails.SetWidths(headersEmpDetails); //Set the pdf headers  
            tableLayoutEmpDetails.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutEmpDetails.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutEmpDetails.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersAllowance = { 70, 40, 40 }; //Header Widths  
            tableLayoutAllowance.SetWidths(headersAllowance); //Set the pdf headers  
            tableLayoutAllowance.TotalWidth = 340f; //Set the PDF File witdh percentage  
            tableLayoutAllowance.HorizontalAlignment = Element.ALIGN_LEFT;
            tableLayoutAllowance.HeaderRows = 1;


            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersDeduction = { 70, 40 }; //Header Widths  
            tableLayoutDeduction.SetWidths(headersDeduction); //Set the pdf headers  
            tableLayoutDeduction.TotalWidth = 215f; //Set the PDF File witdh percentage  
            tableLayoutDeduction.HorizontalAlignment = Element.ALIGN_RIGHT;
            tableLayoutDeduction.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersTakeHomeSal = { 69, 50, 50, 70 }; //Header Widths  
            tableLayoutTakeHomeSal.SetWidths(headersTakeHomeSal); //Set the pdf headers  
            tableLayoutTakeHomeSal.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutTakeHomeSal.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutTakeHomeSal.HeaderRows = 1;

            //doc.Add(Add_Content_To_PDF(tableLayout,ID));
            float[] headersSigniture = { 100 }; //Header Widths  
            tableLayoutSigniture.SetWidths(headersSigniture); //Set the pdf headers  
            tableLayoutSigniture.TotalWidth = 555f; //Set the PDF File witdh percentage  
            tableLayoutSigniture.HorizontalAlignment = Element.ALIGN_CENTER;
            tableLayoutSigniture.HeaderRows = 1;

            ////Add body  

            //FontFactory.Register("D:\\Project\\AnandERP\\AnandERP\\AERP.Web.UI\\Content\\Theme\\fonts\\Bahamas Bold.ttf", "Bahamas");
            //var titleFont = FontFactory.GetFont("Bahamas", 20f);

            //tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractSalaryTransactionList[0].CentreName, titleFont))
            tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractSalaryTransactionList[0].CentreName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SaleContractSalaryTransactionList[0].LogoPath));
            jpg.ScaleAbsolute(50f, 50f);
            tableLayoutHeader.AddCell(new PdfPCell(jpg) { PaddingTop = 5, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER, UseVariableBorders = true, BorderColorLeft = BaseColor.WHITE, BorderColorRight = BaseColor.WHITE });

            tableLayoutHeader.AddCell(new PdfPCell(new Phrase("Pay Slip For Span" + model.SaleContractSalaryTransactionList[0].SaleContractBillingSpanName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            tableLayoutHeader.WriteSelectedRows(0, -1, doc.Left, doc.Top, writer.DirectContent);
            // doc.Add(tableLayoutHeader);

            //For First Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Employee Code");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].EmployeeCode);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Bank Name");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + "SBI");
            //For Second Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Name");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Account No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].BankACNumber);

            //For Third Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Designation");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].SaleContractManPowerItemName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "PF No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].ProvidentFundNumber);

            //For Fourth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Location");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractSalaryTransactionList[0].City);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "UAN No.");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + "0");

            //For Fifth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Working Days");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.SaleContractSalaryTransactionList[0].TotalDays));
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Paid Days");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.SaleContractSalaryTransactionList[0].TotalAttendance));

            tableLayoutEmpDetails.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

            ///For Allowance
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Monthly Pay", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            decimal BasicAmount = Math.Round(model.SaleContractSalaryTransactionList[0].BasicSalayAmount);
            decimal TotalAttendance = model.SaleContractSalaryTransactionList[0].TotalAttendance;
            byte TotalDays = model.SaleContractSalaryTransactionList[0].TotalDays;
            decimal AdjustedTotalDays = model.SaleContractSalaryTransactionList[0].AdjustedTotalDays;
            decimal ActualBasicAmount = Math.Round((BasicAmount / TotalDays) * TotalAttendance);

            AddCellToBodyWithLeftBorder(tableLayoutAllowance, "Basic");
            AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(BasicAmount));
            AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(ActualBasicAmount));

            decimal TotalEarning = BasicAmount, ActualTotalEarning = ActualBasicAmount;
            decimal TotalDeduction = 0, ActualTotalDeduction = 0;

            foreach (var emp in model.SaleContractSalaryTransactionList)
            {
                if (emp.HeadType == "DA")
                {
                    decimal amount = 0;
                    if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                    }
                    else
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');
                            if (Convert.ToByte(ReferenceID[0]) == 0)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.SaleContractSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

                    }
                    emp.Amount = amount;
                    AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                    AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                    AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                    TotalEarning = TotalEarning + amount;
                    ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
                }
            }

            foreach (var emp in model.SaleContractSalaryTransactionList)
            {
                if (emp.RuleType == "Allowance" && emp.HeadType != "DA")
                {
                    decimal amount = 0;
                    if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                        emp.Amount = amount;
                        AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                        AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                        AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                        TotalEarning = TotalEarning + amount;
                        ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;

                    }
                    else if (emp.Percentage > 0)
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');
                            if (Convert.ToByte(ReferenceID[0]) == 0)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.SaleContractSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);
                        emp.Amount = amount;
                        AddCellToBodyWithLeftBorder(tableLayoutAllowance, emp.HeadName);
                        AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(amount));
                        AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(emp.ActualAmount));

                        TotalEarning = TotalEarning + amount;
                        ActualTotalEarning = ActualTotalEarning + emp.ActualAmount;
                    }

                }
            }

            ///For Deduction
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Actual", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            foreach (var emp in model.SaleContractSalaryTransactionList)
            {
                if (emp.RuleType == "Deduction" && emp.ContributionType == 1)
                {
                    decimal amount = 0;
                    if (emp.FixedAmount > 0)
                    {
                        amount = Math.Round(emp.FixedAmount);
                    }
                    else
                    {
                        var CalculateOnValue = emp.CalculateOnString.Replace(", ", ",").Split(',');
                        decimal CalculateOnAmount = 0;
                        foreach (var CalOn in CalculateOnValue)
                        {
                            var ReferenceID = CalOn.Split('~');
                            if (Convert.ToByte(ReferenceID[0]) == 0)
                            {
                                CalculateOnAmount = CalculateOnAmount + BasicAmount;
                            }
                            else
                            {
                                foreach (var itemSub in model.SaleContractSalaryTransactionList)
                                {
                                    if (itemSub.HeadID == Convert.ToByte(ReferenceID[0]) && ((itemSub.RuleType == "Allowance" && Convert.ToByte(ReferenceID[1]) == 2) || (itemSub.RuleType == "Deduction" && Convert.ToByte(ReferenceID[1]) == 3)))
                                    {
                                        CalculateOnAmount = CalculateOnAmount + itemSub.Amount;
                                    }
                                }
                            }
                        }
                        amount = Math.Round(CalculateOnAmount * emp.Percentage / 100);

                    }
                    emp.Amount = amount;
                    AddCellToBodyWithLeftBorder(tableLayoutDeduction, emp.HeadName);
                    AddCellToBodyWithRightBorder(tableLayoutDeduction, Convert.ToString(emp.ActualAmount));

                    TotalDeduction = TotalDeduction + amount;
                    ActualTotalDeduction = ActualTotalDeduction + emp.ActualAmount;
                }
            }

            if (tableLayoutAllowance.Rows.Count > tableLayoutDeduction.Rows.Count)
            {
                var count = tableLayoutAllowance.Rows.Count - tableLayoutDeduction.Rows.Count;
                for (int i = 0; i < count; i++)
                {

                    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });
                    tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });



                }

            }
            else
            {
                var count = tableLayoutDeduction.Rows.Count - tableLayoutAllowance.Rows.Count;
                for (int i = 0; i < count; i++)
                {
                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });
                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorRight = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });


                    tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(" ", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
                    {
                        HorizontalAlignment = Element.ALIGN_LEFT,
                        Padding = 5,
                        //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                        UseVariableBorders = true,
                        BorderColorLeft = BaseColor.WHITE,
                        BorderColorTop = BaseColor.WHITE,
                        BorderColorBottom = BaseColor.WHITE,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    });


                    //AddCellToBodyWithLeftBorder(tableLayoutAllowance, "");
                    //AddCellToBodyWithNoBorder(tableLayoutAllowance, "");
                    //AddCellToBodyWithRightBorder(tableLayoutAllowance, "");
                }
            }
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase("Total Earnings", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(TotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                //  BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutAllowance.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalEarning), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });

            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase("Total Deduction", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutDeduction.AddCell(new PdfPCell(new Phrase(Convert.ToString(ActualTotalDeduction), new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                // BackgroundColor = new iTextSharp.text.BaseColor(212, 212, 212),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });


            tableLayoutAllowance.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);

            tableLayoutDeduction.WriteSelectedRows(0, -1, doc.Left + 340, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights(), writer.DirectContent);


            var AmountInWords = ConvertToWords(Convert.ToString(model.SaleContractSalaryTransactionList[0].NetPayable));
            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "NetPay");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(model.SaleContractSalaryTransactionList[0].NetPayable));
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, "EMI Recovered");
            AddCellToBodyWithRightBorder(tableLayoutTakeHomeSal, "0");

            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "Take Home");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(model.SaleContractSalaryTransactionList[0].NetPayable));
            tableLayoutTakeHomeSal.AddCell(new PdfPCell(new Phrase("Rupees " + AmountInWords, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                Colspan = 2,
                //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorTop = BaseColor.WHITE,
                BorderColorLeft = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutTakeHomeSal.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights(), writer.DirectContent);


            tableLayoutSigniture.AddCell(new PdfPCell(new Phrase("This is system generated report & signature is not required.", new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                Colspan = 2,
                //  BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            tableLayoutSigniture.WriteSelectedRows(0, -1, doc.Left, doc.Top - tableLayoutEmpDetails.CalculateHeights() - tableLayoutHeader.CalculateHeights() - tableLayoutAllowance.CalculateHeights() - tableLayoutTakeHomeSal.CalculateHeights(), writer.DirectContent);


            // Closing the document  
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterName + " " + model.SaleContractSalaryTransactionList[0].SaleContractBillingSpanName + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();


        }

        // Method to add single cell to the Header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {

            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.YELLOW)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(128, 0, 0)
            });
        }

        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255)
            });
        }

        // Method to add single cell to the body with left Border  
        private static void AddCellToBodyWithLeftBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                BorderColorTop = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
        }
        // Method to add single cell to the body with Right Border
        private static void AddCellToBodyWithRightBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorLeft = BaseColor.WHITE,
                BorderColorTop = BaseColor.WHITE,
                BorderColorBottom = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });
        }
        // Method to add single cell to the body with no Border
        private static void AddCellToBodyWithNoBorder(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                Border = 0,
                VerticalAlignment = Element.ALIGN_MIDDLE
            });
        }

        [HttpPost]
        public ActionResult DownloadSalarySheet(SaleContractSalaryTransactionViewModel _model)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
            try
            {
                model.SaleContractSalaryTransactionDTO = new SaleContractSalaryTransaction();
                model.SaleContractSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(_model.SaleContractMasterID);
                model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(_model.SaleContractBillingSpanID);

                model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractSalaryTransactionList = GetSalaryTransactionDetailsForSalarySheet(_model.SaleContractMasterID, _model.SaleContractBillingSpanID, _model.SummaryFormat);

                if (model.SaleContractSalaryTransactionList.Count > 0)
                {

                    string SaleContractSalarySheetPDF = " ";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<table  width='100%' border='0'><tbody><tr><td style='font-size:5pt;text-align:left;'>M.W. From II</td><td style='font-size:8pt;text-align:center;'>Wage Sheet</td><td>" + model.SaleContractSalaryTransactionList[0].SaleContractBillingSpanName + "</td></tr><tr><td style='font-size:5pt;text-align:left;'>Factory F.No.17,29</td><td style='font-size:5pt;text-align:center;'>Factory Rules 122, 99 Rule 27 (1) </td><td style='font-size:8pt;text-align:right;'>Month - " + model.SaleContractSalaryTransactionList[0].SalaryMonth + "</td></tr><tr><td style='font-size:8pt;text-align:left;'>Name Of Establishment - " + model.SaleContractSalaryTransactionList[0].CentreName + "</td><td style='font-size:8pt;text-align:center;'>Name Of Employer - " + model.SaleContractSalaryTransactionList[0].CustomerBranchMasterName + "</td><td style='font-size:8pt;text-align:right;'>Year - " + model.SaleContractSalaryTransactionList[0].SalaryYear + "</td></tr></tbody></table>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<br><table width='100%' border='1' style='repeat-header: yes;'><thead><tr>";

                    string[] SaleContractEmployeeMasterIDList = model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });

                    string[] SaleContractManPowerItemIDList = model.SaleContractSalaryTransactionList[0].SaleContractManPowerItemIDList.Replace(", ", ",").Split(new char[] { ',' });

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' style='border: 1px  black;border-collapse: collapse; font-size:5pt;text-align:center;'>Sr. No.</th><th width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:left;'>Particulars</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Working Days</th><th width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Present Days</th>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.HeadType == "OT")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>OT Days</th>";
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Basic</th>";

                    bool HeadDisplayTotalAmount = false; bool HeadAdditionalInTotal = false;

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "DA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            HeadDisplayTotalAmount = true;
                        }
                    }

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "AddA" && item.ComplianceType == 1)
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "PF" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                                HeadDisplayTotalAmount = true;
                                HeadAdditionalInTotal = true;
                            }
                        }
                    }

                    if (HeadDisplayTotalAmount == true)
                    {
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total</th>";
                    }

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && HeadAdditionalInTotal == false) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "OT")
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            }
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Gross</th>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && HeadAdditionalInTotal == false) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == false)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "OT")
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == false)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && (item.HeadType == "AddA" && item.ComplianceType == 2))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Earnings</th>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Deduction</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Net Amount</th>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "RIA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Incl. Amount</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr></thead><tbody>";

                    decimal GrandAttendanceManPowerSum = 0; decimal GrandOverTimeManPowerSum = 0; decimal GrandDaysManPowerSum = 0; decimal GrandAdjustedBasicAmountManPowerSum = 0;

                    for (int manPowerID = 0, manPowerIDIndex = 1, manPowerListIndex = 0, j = 0; manPowerID < SaleContractManPowerItemIDList.Count(); manPowerID++, manPowerIDIndex++)
                    {
                        int v = j;
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + manPowerIDIndex + "</td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractSalaryTransactionList[j].SaleContractManPowerItemName + "</td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                            {
                                //manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                        bool ManDisplayTotalAmount = false; bool ManAdditionalInTotal = false;

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                                ManDisplayTotalAmount = true;
                            }
                        }

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "AddA" && item.ComplianceType == 1)
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "PF" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == true)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";
                                    ManDisplayTotalAmount = true;
                                    ManAdditionalInTotal = true;
                                }
                            }
                        }

                        if (ManDisplayTotalAmount == true)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        }

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && ManAdditionalInTotal == false) || (item.HeadType != "AddA")))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                        decimal TotalAttendanceManPowerSum = 0; decimal OverTimeManPowerSum = 0; decimal TotalDaysManPowerSum = 0; decimal AdjustedBasicAmountManPowerSum = 0;
                        for (int i = 0, k = 1; i < SaleContractEmployeeMasterIDList.Count(); i++)
                        {
                            if (model.SaleContractSalaryTransactionList[j].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[i]))
                            {
                                TotalAttendanceManPowerSum = TotalAttendanceManPowerSum + model.SaleContractSalaryTransactionList[j].TotalAttendance;
                                OverTimeManPowerSum = OverTimeManPowerSum + model.SaleContractSalaryTransactionList[j].OvertimeHours;
                                TotalDaysManPowerSum = TotalDaysManPowerSum + model.SaleContractSalaryTransactionList[j].TotalDays;
                                AdjustedBasicAmountManPowerSum = AdjustedBasicAmountManPowerSum + model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount;

                                GrandAttendanceManPowerSum = GrandAttendanceManPowerSum + model.SaleContractSalaryTransactionList[j].TotalAttendance;
                                GrandOverTimeManPowerSum = GrandOverTimeManPowerSum + model.SaleContractSalaryTransactionList[j].OvertimeHours;
                                GrandDaysManPowerSum = GrandDaysManPowerSum + model.SaleContractSalaryTransactionList[j].TotalDays;
                                GrandAdjustedBasicAmountManPowerSum = GrandAdjustedBasicAmountManPowerSum + model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount;

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + k + "</td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterName + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractSalaryTransactionList[j].TotalDays + "</td><td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractSalaryTransactionList[j].TotalAttendance + "</td>";
                                k++;
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.HeadType == "OT")
                                    {
                                        //j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'> " + item.OvertimeHours + "</td>";
                                    }
                                }

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount) + "</td>";

                                decimal TotalEarningEmpMaster = model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount; decimal TotalGrossEmpMaster = model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount; decimal TotalBasicDAEmpMaster = model.SaleContractSalaryTransactionList[j].AdjustedBasicAmount; decimal TotaldeductionEmpMaster = 0;
                                bool DisplayTotalAmount = false; bool AdditionalInTotal = false;

                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "DA")
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                        TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                        TotalBasicDAEmpMaster = TotalBasicDAEmpMaster + item.AdjustedAmount;
                                        DisplayTotalAmount = true;
                                    }
                                }

                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "AddA" && item.ComplianceType == 1)
                                    {
                                        bool IsGrossAllowance = false;
                                        foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                        {
                                            if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "PF" && checkitem.ComplianceType == 1)
                                            {
                                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                                foreach (var CalOn in CalculateOnValue)
                                                {
                                                    var ReferenceID = CalOn.Split('~');

                                                    if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                                    {
                                                        IsGrossAllowance = true;
                                                    }
                                                }
                                            }
                                        }

                                        if (IsGrossAllowance == true)
                                        {
                                            j++;
                                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                            TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                            TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                            TotalBasicDAEmpMaster = TotalBasicDAEmpMaster + item.AdjustedAmount;
                                            DisplayTotalAmount = true;
                                            AdditionalInTotal = true;
                                        }
                                    }
                                }

                                if (DisplayTotalAmount == true)
                                {
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalBasicDAEmpMaster) + "</td>";
                                }

                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && AdditionalInTotal == false) || (item.HeadType != "AddA")))
                                    {
                                        bool IsGrossAllowance = false;
                                        foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                        {
                                            if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                            {
                                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                                foreach (var CalOn in CalculateOnValue)
                                                {
                                                    var ReferenceID = CalOn.Split('~');

                                                    if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                                    {
                                                        IsGrossAllowance = true;
                                                    }
                                                }
                                            }
                                        }

                                        if (IsGrossAllowance == true)
                                        {
                                            j++;
                                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                            TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                            TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                        }
                                    }
                                }
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "OT")
                                    {
                                        bool IsGrossAllowance = false;
                                        foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                        {
                                            if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                            {
                                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                                foreach (var CalOn in CalculateOnValue)
                                                {
                                                    var ReferenceID = CalOn.Split('~');

                                                    if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                                    {
                                                        IsGrossAllowance = true;
                                                    }
                                                }
                                            }
                                        }

                                        if (IsGrossAllowance == true)
                                        {
                                            j++;
                                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                            TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                            TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                        }
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalGrossEmpMaster) + "</td>";
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && AdditionalInTotal == false) || (item.HeadType != "AddA")))
                                    {
                                        bool IsGrossAllowance = false;
                                        foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                        {
                                            if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                            {
                                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                                foreach (var CalOn in CalculateOnValue)
                                                {
                                                    var ReferenceID = CalOn.Split('~');

                                                    if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                                    {
                                                        IsGrossAllowance = true;
                                                    }
                                                }
                                            }
                                        }

                                        if (IsGrossAllowance == false)
                                        {
                                            j++;
                                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                            TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                        }
                                    }
                                }
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "OT")
                                    {
                                        bool IsGrossAllowance = false;
                                        foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                        {
                                            if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                            {
                                                var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                                foreach (var CalOn in CalculateOnValue)
                                                {
                                                    var ReferenceID = CalOn.Split('~');

                                                    if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                                    {
                                                        IsGrossAllowance = true;
                                                    }
                                                }
                                            }
                                        }

                                        if (IsGrossAllowance == false)
                                        {
                                            j++;
                                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                            TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                        }
                                    }
                                }
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && (item.HeadType == "AddA" && item.ComplianceType == 2))
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalEarningEmpMaster) + "</td>";
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == false)
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotaldeductionEmpMaster = TotaldeductionEmpMaster + item.AdjustedAmount;
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotaldeductionEmpMaster) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalEarningEmpMaster - TotaldeductionEmpMaster) + "</td>";
                                foreach (var item in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "RIA")
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round((TotalEarningEmpMaster - TotaldeductionEmpMaster) + item.AdjustedAmount) + "</td>";
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                            }

                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Sub Total</b></td>";


                        //for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                        //{

                        //    if (model.SaleContractSalaryTransactionList[v].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]))
                        //    {
                        //        bool DataAdded1 = false;
                        //        foreach (var item in model.SaleContractSalaryTransactionList)
                        //        {
                        //            if (model.SaleContractSalaryTransactionList[v].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                        //            {

                        //                DataAdded1 = true;
                        //            }
                        //        }
                        //    }
                        //}

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            foreach (var innerItem in model.SaleContractSalaryTransactionList)
                            {
                                if (item.SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractManPowerItemID == innerItem.SaleContractManPowerItemID && item.HeadID == innerItem.HeadID && item.HeadType == innerItem.HeadType)
                                {
                                    item.ActualAmount = item.ActualAmount + innerItem.AdjustedAmount;
                                }
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + TotalDaysManPowerSum + "</b></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + TotalAttendanceManPowerSum + "</b></td>";

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                            {
                                //manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + OverTimeManPowerSum + "</b></td>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(AdjustedBasicAmountManPowerSum) + "</b></td>";
                        decimal TotalEarningManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotalGrossManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotalBasicDAManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotaldeductionManPowerItem = 0;
                        bool SubDisplayTotalAmount = false; bool SubAdditionalInTotal = false; 
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                                TotalBasicDAManPowerItem = TotalBasicDAManPowerItem + item.ActualAmount;
                                SubDisplayTotalAmount = true;
                            }
                        }

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "AddA" && item.ComplianceType == 1)
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "PF" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == true)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                    TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                    TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                                    TotalBasicDAManPowerItem = TotalBasicDAManPowerItem + item.ActualAmount;
                                    SubDisplayTotalAmount = true;
                                    SubAdditionalInTotal = true;
                                }
                            }
                        }

                        if (SubDisplayTotalAmount == true)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalBasicDAManPowerItem) + "</b></td>";
                        }

                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && SubAdditionalInTotal == false) || (item.HeadType != "AddA")))
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == true)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                    TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                    TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                                }
                            }
                        }
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "OT")
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == true)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                    TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                    TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                                }
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalGrossManPowerItem) + "</b></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && SubAdditionalInTotal == false) || (item.HeadType != "AddA")))
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == false)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                    TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                }
                            }
                        }
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "OT")
                            {
                                bool IsGrossAllowance = false;
                                foreach (var checkitem in model.SaleContractSalaryTransactionList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                    {
                                        var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                        foreach (var CalOn in CalculateOnValue)
                                        {
                                            var ReferenceID = CalOn.Split('~');

                                            if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                            {
                                                IsGrossAllowance = true;
                                            }
                                        }
                                    }
                                }

                                if (IsGrossAllowance == false)
                                {
                                    manPowerListIndex++;
                                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                    TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                }
                            }
                        }
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "AddA" && item.ComplianceType == 2))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalEarningManPowerItem) + "</b></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                TotaldeductionManPowerItem = TotaldeductionManPowerItem + item.ActualAmount;
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotaldeductionManPowerItem) + "</b></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(TotalEarningManPowerItem - TotaldeductionManPowerItem) + "</b></td>";
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round((TotalEarningManPowerItem - TotaldeductionManPowerItem) + item.ActualAmount) + "</b></td>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tbody><tfoot>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Grand Total</b></td>";


                    //for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                    //{
                    //    bool DataAdded1 = false;
                    //    foreach (var item in model.SaleContractSalaryTransactionList)
                    //    {
                    //        if (item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                    //        {

                    //            DataAdded1 = true;
                    //        }
                    //    }
                    //}

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        item.ActualAmount = 0;
                        foreach (var innerItem in model.SaleContractSalaryTransactionList)
                        {
                            if (item.HeadID == innerItem.HeadID && item.HeadType == innerItem.HeadType)
                            {
                                item.ActualAmount = item.ActualAmount + innerItem.AdjustedAmount;
                            }
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + GrandDaysManPowerSum + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandAttendanceManPowerSum + "</b></td>";

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                        {
                            //manPowerListIndex++;
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandOverTimeManPowerSum + "</b></td>";
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(GrandAdjustedBasicAmountManPowerSum) + "</b></td>";
                    decimal GrandEarningManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GrandGrossManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GrandBasicDAManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GranddeductionManPowerItem = 0;

                    bool GrandDisplayTotalAmount = false;                     bool GrandAdditionalInTotal = false;

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                            GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                            GrandBasicDAManPowerItem = GrandBasicDAManPowerItem + item.ActualAmount;
                            GrandDisplayTotalAmount = true;
                        }
                    }

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "AddA" && item.ComplianceType == 1)
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "PF" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                                GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                                GrandBasicDAManPowerItem = GrandBasicDAManPowerItem + item.ActualAmount;
                                GrandDisplayTotalAmount = true;
                                GrandAdditionalInTotal = true;
                            }
                        }
                    }

                    if (GrandDisplayTotalAmount == true)
                    {
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandBasicDAManPowerItem) + "</b></td>";
                    }

                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && GrandAdditionalInTotal == false) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                                GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "OT")
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == true)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                                GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                            }
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandGrossManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1 && GrandAdditionalInTotal == false) || (item.HeadType != "AddA")))
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == false)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "OT")
                        {
                            bool IsGrossAllowance = false;
                            foreach (var checkitem in model.SaleContractSalaryTransactionList)
                            {
                                if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == checkitem.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[0]) == checkitem.SaleContractManPowerItemID && checkitem.RuleType == "Deduction" && checkitem.ContributionType == 1 && checkitem.HeadType == "ESIC" && checkitem.ComplianceType == 1)
                                {
                                    var CalculateOnValue = checkitem.CalculateOnString.Replace(", ", ",").Split(',');
                                    foreach (var CalOn in CalculateOnValue)
                                    {
                                        var ReferenceID = CalOn.Split('~');

                                        if (item.HeadID == Convert.ToByte(ReferenceID[0]))
                                        {
                                            IsGrossAllowance = true;
                                        }
                                    }
                                }
                            }

                            if (IsGrossAllowance == false)
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                                GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                            }
                        }
                    }
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "AddA" && item.ComplianceType == 2))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandEarningManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GranddeductionManPowerItem = GranddeductionManPowerItem + item.ActualAmount;
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GranddeductionManPowerItem) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandEarningManPowerItem - GranddeductionManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractSalaryTransactionList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round((GrandEarningManPowerItem - GranddeductionManPowerItem) + item.ActualAmount) + "</b></td>";
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tfoot></table>";

                    DownloadPDF(SaleContractSalarySheetPDF, Convert.ToString(_model.SaleContractMasterID), Convert.ToInt32(model.SaleContractSalaryTransactionList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "Salary is Not Generated";
                    return RedirectToAction("Index", "SaleContractSalaryTransaction");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public ActionResult DownloadNRSheet(SaleContractSalaryTransactionViewModel _model)
        {
            SaleContractSalaryTransactionViewModel model = new SaleContractSalaryTransactionViewModel();
            try
            {
                model.SaleContractSalaryTransactionDTO = new SaleContractSalaryTransaction();
                model.SaleContractSalaryTransactionDTO.SaleContractMasterID = Convert.ToInt64(_model.SaleContractMasterID);
                model.SaleContractSalaryTransactionDTO.SaleContractBillingSpanID = Convert.ToInt64(_model.SaleContractBillingSpanID);

                model.SaleContractSalaryTransactionDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractSalaryTransactionList = GetSalaryTransactionDetailsForNRSheet(_model.SaleContractMasterID, _model.SaleContractBillingSpanID, _model.SummaryFormat);

                if (model.SaleContractSalaryTransactionList.Count > 0)
                {

                    string SaleContractSalarySheetPDF = " ";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<table  width='100%' border='0'><tbody><tr><td style='font-size:5pt;text-align:left;'>M.W. From II</td><td style='font-size:8pt;text-align:center;'>Wage Sheet</td><td>" + model.SaleContractSalaryTransactionList[0].SaleContractBillingSpanName + "</td></tr><tr><td style='font-size:5pt;text-align:left;'>Factory F.No.17,29</td><td style='font-size:5pt;text-align:center;'>Factory Rules 122, 99 Rule 27 (1) </td><td style='font-size:8pt;text-align:right;'>Month - " + model.SaleContractSalaryTransactionList[0].SalaryMonth + "</td></tr><tr><td style='font-size:8pt;text-align:left;'>Name Of Establishment - " + model.SaleContractSalaryTransactionList[0].CentreName + "</td><td style='font-size:8pt;text-align:center;'>Name Of Employer - " + model.SaleContractSalaryTransactionList[0].CustomerBranchMasterName + "</td><td style='font-size:8pt;text-align:right;'>Year - " + model.SaleContractSalaryTransactionList[0].SalaryYear + "</td></tr></tbody></table>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<br><table width='100%' border='1' style='repeat-header:yes;'><thead><tr>";

                    string[] SaleContractEmployeeMasterIDList = model.SaleContractSalaryTransactionList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });

                    string[] SaleContractManPowerItemIDList = model.SaleContractSalaryTransactionList[0].SaleContractManPowerItemIDList.Replace(", ", ",").Split(new char[] { ',' });

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; font-size:5pt;text-align:center;'>Sr. No.</th><th bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:left;'>Name Of Employee</th><th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Gross Salary</th>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Working Days</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Absent Days</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Days (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Work Hrs (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Days (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Work Hrs (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>(+) Adjustments</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>(-) Adjustments</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Amt (10)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Extra Working Amt (8)</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Salary Deduct</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Net Salary</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='150%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Signature</th>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr></thead><tbody>";

                    for (int manPowerID = 0, manPowerIDIndex = 1, manPowerListIndex = 0, j = 0; manPowerID < SaleContractManPowerItemIDList.Count(); manPowerID++, manPowerIDIndex++)
                    {
                        int v = j;
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + manPowerIDIndex + "</td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractSalaryTransactionList[j].SaleContractManPowerItemName + "</td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                        for (int i = 0, k = 1; i < SaleContractEmployeeMasterIDList.Count(); i++)
                        {
                            if (model.SaleContractSalaryTransactionList[j].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[i]))
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + k + "</td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractSalaryTransactionList[j].SaleContractEmployeeMasterName + "</td><td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(model.SaleContractSalaryTransactionList[j].GrossAmount) + "</td><td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractSalaryTransactionList[j].TotalAttendance + "</td>";

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(model.SaleContractSalaryTransactionList[j].TotalDeduction) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(model.SaleContractSalaryTransactionList[j].TotalSalary) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                                j++;
                                k++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>Sub Total</td>";

                        decimal TotalAttendanceManPowerSum = 0; decimal GrossSalarySum = 0; decimal TotalSalarySum = 0; decimal TotalSalaryDeduction = 0;
                        for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                        {
                            bool DataAdded1 = false;
                            foreach (var item in model.SaleContractSalaryTransactionList)
                            {
                                if (item.SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                                {
                                    TotalAttendanceManPowerSum = TotalAttendanceManPowerSum + item.TotalAttendance;
                                    GrossSalarySum = GrossSalarySum + item.GrossAmount;
                                    TotalSalarySum = TotalSalarySum + item.TotalSalary;
                                    TotalSalaryDeduction = TotalSalaryDeduction + item.TotalDeduction;
                                    DataAdded1 = true;
                                }
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(GrossSalarySum) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + TotalAttendanceManPowerSum + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalaryDeduction) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalarySum) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tbody><tfoot>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Grand Total</b></td>";

                    decimal GrandAttendanceManPowerSum = 0; decimal GrandGrossSalarySum = 0; decimal GrandTotalSalarySum = 0; decimal GrandTotalSalaryDeduction = 0;
                    for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                    {
                        bool DataAdded1 = false;
                        foreach (var item in model.SaleContractSalaryTransactionList)
                        {
                            if (item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                            {
                                GrandAttendanceManPowerSum = GrandAttendanceManPowerSum + item.TotalAttendance;
                                GrandGrossSalarySum = GrandGrossSalarySum + item.GrossAmount;
                                GrandTotalSalarySum = GrandTotalSalarySum + item.TotalSalary;
                                GrandTotalSalaryDeduction = GrandTotalSalaryDeduction + item.TotalDeduction;
                                DataAdded1 = true;
                            }
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandGrossSalarySum) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandAttendanceManPowerSum + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandTotalSalaryDeduction) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandTotalSalarySum) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tfoot></table>";

                    DownloadNRPDF(SaleContractSalarySheetPDF,Convert.ToString(_model.SaleContractMasterID), Convert.ToInt32(model.SaleContractSalaryTransactionList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "NR Record Not Found for Selected Salary.";
                    return RedirectToAction("Index", "SaleContractSalaryTransaction");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public FileResult DownloadSalarySlipExcel(string GridHtml)
        {
            return File(Encoding.ASCII.GetBytes(GridHtml), "application/vnd.ms-excel", "SalarySlip.xls");
        }

        public void DownloadPDF(string SaleContractSalarySheetPDF, string CustomerInvoiceNumber, int SaleContractMasterID)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "SalarySheet" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDFDetails(SaleContractSalarySheetPDF));
            Response.End();
        }
        public void DownloadNRPDF(string SaleContractSalarySheetPDF, string CustomerInvoiceNumber, int SaleContractMasterID)
        {
            //string HTMLContent = "Hello <b>World</b>";

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=" + "NRSheet" + "_" + CustomerInvoiceNumber + ".pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(GetPDFDetails(SaleContractSalarySheetPDF));
            Response.End();
        }
        public byte[] GetPDFDetails(string pHTML)
        {
            byte[] bPDF = null;

            MemoryStream ms = new MemoryStream();
            TextReader txtReader = new StringReader(pHTML);

            // 1: create object of a itextsharp document class
            Document doc = new Document(PageSize.A4.Rotate(), 5, 5, 5, 5);

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

        protected List<SaleContractSalaryTransaction> GetSalaryTransactionForGeneration(string SaleContractEmployeeMasterID, string SaleContractMasterID, string SaleContractBillingSpanID, string SaleContractManPowerItemID)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractEmployeeMasterID = Convert.ToInt64(SaleContractEmployeeMasterID);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SaleContractManPowerItemID = Convert.ToInt32(SaleContractManPowerItemID);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionForGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }

        protected List<SaleContractSalaryTransaction> GetSalaryTransactionForBulkGeneration(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionForBulkGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }

        protected List<SaleContractSalaryTransaction> GetSalaryTransactionDetailsByID(string ID)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = Convert.ToInt64(ID);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }
        protected List<SaleContractSalaryTransaction> GetSalaryTransactionForSalarySlipExcel(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionDetailsForAllEmployeeinExcel(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }

        

        protected List<SaleContractSalaryTransaction> GetListSaleContractSalaryTransactionDeduction()
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetListSaleContractSalaryTransactionDeduction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }

        [NonAction]
        public IEnumerable<SaleContractSalaryTransactionViewModel> GetSaleContractSalaryTransaction(out int TotalRecords, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                _actionMode = Convert.ToString(TempData["ActionMode"]);

                searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

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

                List<SaleContractSalaryTransactionViewModel> listSaleContractMasterViewModel = new List<SaleContractSalaryTransactionViewModel>();
                List<SaleContractSalaryTransaction> listSaleContractMaster = new List<SaleContractSalaryTransaction>();
                IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSaleContractSalaryTransactionBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractSalaryTransaction item in listSaleContractMaster)
                        {
                            SaleContractSalaryTransactionViewModel SaleContractMasterViewModel = new SaleContractSalaryTransactionViewModel();
                            SaleContractMasterViewModel.SaleContractSalaryTransactionDTO = item;
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

        protected List<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(Int64 SaleContractMasterID, Int64 SaleContractBillingSpanID,byte SummaryFormat)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SummaryFormat = Convert.ToByte(SummaryFormat);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }

        protected List<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(Int64 SaleContractMasterID, Int64 SaleContractBillingSpanID,byte SummaryFormat)
        {

            SaleContractSalaryTransactionSearchRequest searchRequest = new SaleContractSalaryTransactionSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SummaryFormat = Convert.ToByte(SummaryFormat);

            List<SaleContractSalaryTransaction> listSaleContractSalaryTransaction = new List<SaleContractSalaryTransaction>();
            IBaseEntityCollectionResponse<SaleContractSalaryTransaction> baseEntityCollectionResponse = _SaleContractSalaryTransactionBA.GetSalaryTransactionDetailsForNRSheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractSalaryTransaction = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractSalaryTransaction;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractSalaryTransactionViewModel> filteredSaleContractSalaryTransaction;

            switch (Convert.ToInt32(sortColumnIndex))
            {
                case 0:
                    _sortBy = "SaleContractManPowerItemName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SaleContractEmployeeMasterName Like '%" + param.sSearch + "%' or SaleContractManPowerItemName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
                case 1:
                    _sortBy = "SaleContractEmployeeMasterName";
                    if (string.IsNullOrEmpty(param.sSearch))
                    {
                        _searchBy = string.Empty;
                    }
                    else
                    {
                        _searchBy = "SaleContractEmployeeMasterName Like '%" + param.sSearch + "%' or SaleContractManPowerItemName Like '%" + param.sSearch + "%'";        //this "if" block is added for search functionality
                    }
                    break;
            }

            _sortDirection = sortDirection;
            _rowLength = param.iDisplayLength;
            _startRow = param.iDisplayStart;

            filteredSaleContractSalaryTransaction = GetSaleContractSalaryTransaction(out TotalRecords, SaleContractMasterID, SaleContractBillingSpanID);

            var records = filteredSaleContractSalaryTransaction.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.SaleContractEmployeeMasterID), Convert.ToString(c.SaleContractEmployeeMasterName), Convert.ToString(c.TotalDays), Convert.ToString(c.TotalAttendance), Convert.ToString(c.TotalAmount), Convert.ToString(c.TotalSalary), Convert.ToString(c.SaleContractManPowerItemID), Convert.ToString(c.SaleContractManPowerItemName) };
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


