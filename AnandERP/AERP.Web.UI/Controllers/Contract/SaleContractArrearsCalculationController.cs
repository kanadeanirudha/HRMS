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
    public class SaleContractArrearsCalculationController : BaseController
    {
        ISaleContractArrearsCalculationBA _SaleContractArrearsCalculationBA = null;
        ISaleContractAttendanceBA _SaleContractAttendanceBA = null;

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

        public SaleContractArrearsCalculationController()
        {
            _SaleContractArrearsCalculationBA = new SaleContractArrearsCalculationBA();
            _SaleContractAttendanceBA = new SaleContractAttendanceBA();
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
            if (Convert.ToString(Session["UserType"]) == "A" || (Convert.ToInt32(Session["HR Manager"]) > 0 && IsApplied == true))
            {
                SaleContractArrearsCalculationViewModel _SaleContractArrearsCalculationViewModel = new SaleContractArrearsCalculationViewModel();

                if (TempData["_errorMsg"] != null)
                {
                    _SaleContractArrearsCalculationViewModel.errorMessage = Convert.ToString(TempData["_errorMsg"]);
                }
                else
                {
                    _SaleContractArrearsCalculationViewModel.errorMessage = "NoMessage";
                }
                return View("/Views/Contract/SaleContractArrearsCalculation/Index.cshtml", _SaleContractArrearsCalculationViewModel);
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
                SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();
                model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                if (!string.IsNullOrEmpty(actionMode))
                {
                    TempData["ActionMode"] = actionMode;
                }
                model.SaleContractArrearsCalculationList = GetSaleContractArrearsAttendanceSpanWise(SaleContractMasterID, SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractArrearsCalculation/List.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public ActionResult AddAttendance(string SaleContractMasterID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractAttendanceList = GetSpanListBySaleContractMaster(SaleContractMasterID);

            return PartialView("/Views/Contract/SaleContractArrearsCalculation/AddAttendance.cshtml", model);
        }

        [HttpGet]
        public ActionResult GetAttendanceForMonthWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.SaleContractArrearsCalculationList = GetAttendanceListForSpanWise(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractArrearsCalculation/GetAttendanceForMonthWise.cshtml", model);
        }

        [HttpGet]
        public ActionResult DownloadOption(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();
                model.SaleContractArrearsCalculationDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
                return PartialView("/Views/Contract/SaleContractArrearsCalculation/DownloadOption.cshtml", model);
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public ActionResult GetAttendanceForMonthWise(SaleContractArrearsCalculationViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractArrearsCalculationDTO != null)
                {
                    model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                    model.SaleContractArrearsCalculationDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractArrearsCalculationDTO.XMLstringForAttendance = model.XMLstringForAttendance;

                    model.SaleContractArrearsCalculationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractArrearsCalculation> response = _SaleContractArrearsCalculationBA.AddSaleContractArrearsAttendance(model.SaleContractArrearsCalculationDTO);

                    model.SaleContractArrearsCalculationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractArrearsCalculationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult AddAttendance(SaleContractArrearsCalculationViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractArrearsCalculationDTO != null)
                {
                    model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                    model.SaleContractArrearsCalculationDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractArrearsCalculationDTO.XMLstringForAttendance = model.XMLstringForAttendance;
                    
                    model.SaleContractArrearsCalculationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractArrearsCalculation> response = _SaleContractArrearsCalculationBA.AddSaleContractArrearsAttendance(model.SaleContractArrearsCalculationDTO);

                    model.SaleContractArrearsCalculationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractArrearsCalculationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.SaleContractArrearsCalculationDTO = new SaleContractArrearsCalculation();
            model.SaleContractArrearsCalculationDTO.ID = Convert.ToInt64(ID);
            model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
            model.SaleContractArrearsCalculationList = GetSalaryTransactionDetailsByID(ID);

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

            //tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractArrearsCalculationList[0].CentreName, titleFont))
               tableLayoutHeader.AddCell(new PdfPCell(new Phrase(model.SaleContractArrearsCalculationList[0].CentreName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
               {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 5,
                BackgroundColor = new iTextSharp.text.BaseColor(255, 255, 255),
                UseVariableBorders = true,
                BorderColorRight = BaseColor.WHITE,
                VerticalAlignment = Element.ALIGN_MIDDLE

            });
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Path.Combine(Server.MapPath("~") + "Content\\UploadedFiles\\Inventory\\Logo\\" + model.SaleContractArrearsCalculationList[0].LogoPath));
            jpg.ScaleAbsolute(50f, 50f);
            tableLayoutHeader.AddCell(new PdfPCell(jpg) { PaddingTop = 5, PaddingBottom = 5, HorizontalAlignment = Element.ALIGN_CENTER, UseVariableBorders = true, BorderColorLeft = BaseColor.WHITE, BorderColorRight = BaseColor.WHITE });

            tableLayoutHeader.AddCell(new PdfPCell(new Phrase("Pay Slip For Span" + model.SaleContractArrearsCalculationList[0].SaleContractBillingSpanName, new Font(Font.FontFamily.HELVETICA, 8, 1, iTextSharp.text.BaseColor.BLACK)))
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
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].EmployeeCode);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Bank Name");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + "SBI");
            //For Second Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Name");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Account No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].BankACNumber);

            //For Third Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Designation");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].SaleContractManPowerItemName);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "PF No");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].ProvidentFundNumber);

            //For Fourth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Location");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + model.SaleContractArrearsCalculationList[0].City);
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "UAN No.");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + "0");

            //For Fifth Row
            AddCellToBodyWithLeftBorder(tableLayoutEmpDetails, "Working Days");
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.SaleContractArrearsCalculationList[0].TotalDays));
            AddCellToBodyWithNoBorder(tableLayoutEmpDetails, "Paid Days");
            AddCellToBodyWithRightBorder(tableLayoutEmpDetails, ":" + Convert.ToString(model.SaleContractArrearsCalculationList[0].TotalAttendance));

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

            decimal BasicAmount = Math.Round(model.SaleContractArrearsCalculationList[0].BasicSalayAmount);
            decimal TotalAttendance = model.SaleContractArrearsCalculationList[0].TotalAttendance;
            byte TotalDays = model.SaleContractArrearsCalculationList[0].TotalDays;
            decimal AdjustedTotalDays = model.SaleContractArrearsCalculationList[0].AdjustedTotalDays;
            decimal ActualBasicAmount = Math.Round((BasicAmount / TotalDays) * TotalAttendance);

            AddCellToBodyWithLeftBorder(tableLayoutAllowance, "Basic");
            AddCellToBodyWithNoBorder(tableLayoutAllowance, Convert.ToString(BasicAmount));
            AddCellToBodyWithRightBorder(tableLayoutAllowance, Convert.ToString(ActualBasicAmount));

            decimal TotalEarning = BasicAmount, ActualTotalEarning = ActualBasicAmount;
            decimal TotalDeduction = 0, ActualTotalDeduction = 0;

            foreach (var emp in model.SaleContractArrearsCalculationList)
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
                                foreach (var itemSub in model.SaleContractArrearsCalculationList)
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

            foreach (var emp in model.SaleContractArrearsCalculationList)
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
                                foreach (var itemSub in model.SaleContractArrearsCalculationList)
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

            foreach (var emp in model.SaleContractArrearsCalculationList)
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
                                foreach (var itemSub in model.SaleContractArrearsCalculationList)
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


            var AmountInWords = ConvertToWords(Convert.ToString(model.SaleContractArrearsCalculationList[0].NetPayable));
            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "NetPay");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(model.SaleContractArrearsCalculationList[0].NetPayable));
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, "EMI Recovered");
            AddCellToBodyWithRightBorder(tableLayoutTakeHomeSal, "0");

            AddCellToBodyWithLeftBorder(tableLayoutTakeHomeSal, "Take Home");
            AddCellToBodyWithNoBorder(tableLayoutTakeHomeSal, Convert.ToString(model.SaleContractArrearsCalculationList[0].NetPayable));
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
            Response.AddHeader("content-disposition", "attachment;" + "filename=" + model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterName + " " + model.SaleContractArrearsCalculationList[0].SaleContractBillingSpanName + ".pdf");
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
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();
            try
            {
                model.SaleContractArrearsCalculationDTO = new SaleContractArrearsCalculation();
                model.SaleContractArrearsCalculationDTO.SaleContractMasterID = Convert.ToInt64(_model.SaleContractMasterID);
                model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = Convert.ToInt64(_model.SaleContractBillingSpanID);

                model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractArrearsCalculationList = GetSalaryTransactionDetailsForSalarySheet(_model.SaleContractMasterID, _model.SaleContractBillingSpanID, _model.SummaryFormat);

                if (model.SaleContractArrearsCalculationList.Count > 0)
                {

                    string SaleContractSalarySheetPDF = " ";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<table  width='100%' border='0'><tbody><tr><td style='font-size:5pt;text-align:left;'>M.W. From II</td><td style='font-size:8pt;text-align:center;'>Arrears Sheet</td><td>" + model.SaleContractArrearsCalculationList[0].SaleContractBillingSpanName + "</td></tr><tr><td style='font-size:5pt;text-align:left;'>Factory F.No.17,29</td><td style='font-size:5pt;text-align:center;'>Factory Rules 122, 99 Rule 27 (1) </td><td style='font-size:8pt;text-align:right;'>Month - " + model.SaleContractArrearsCalculationList[0].SalaryMonth + "</td></tr><tr><td style='font-size:8pt;text-align:left;'>Name Of Establishment - " + model.SaleContractArrearsCalculationList[0].CentreName + "</td><td style='font-size:8pt;text-align:center;'>Name Of Employer - " + model.SaleContractArrearsCalculationList[0].CustomerBranchMasterName + "</td><td style='font-size:8pt;text-align:right;'>Year - " + model.SaleContractArrearsCalculationList[0].SalaryYear + "</td></tr></tbody></table>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<br><table width='100%' border='1' style='repeat-header: yes;'><thead><tr>";

                    string[] SaleContractEmployeeMasterIDList = model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });

                    string[] SaleContractManPowerItemIDList = model.SaleContractArrearsCalculationList[0].SaleContractManPowerItemIDList.Replace(", ", ",").Split(new char[] { ',' });

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; font-size:5pt;text-align:center;'>Sr. No.</th><th bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:left;'>Particulars</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Working Days</th><th bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Present Days</th>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>OT Days</th>";
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Basic</th>";

                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total</th>";
                        }
                    }

                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Gross</th>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Earnings</th>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Deduction</th>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Net Amount</th>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractEmployeeMasterIDList[0]) == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>" + item.HeadName + "</th>";
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<th bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:5pt;text-align:center;'>Total Incl. Amount</th>";
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr></thead><tbody>";

                    decimal GrandAttendanceManPowerSum = 0; decimal GrandOverTimeManPowerSum = 0; decimal GrandDaysManPowerSum = 0; decimal GrandAdjustedBasicAmountManPowerSum = 0;

                    for (int manPowerID = 0, manPowerIDIndex = 1, manPowerListIndex = 0, j = 0; manPowerID < SaleContractManPowerItemIDList.Count(); manPowerID++, manPowerIDIndex++)
                    {
                        int v = j;
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + manPowerIDIndex + "</td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractArrearsCalculationList[j].SaleContractManPowerItemName + "</td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                            {
                                //manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }
                        
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";

                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '></td>";
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
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
                            if (model.SaleContractArrearsCalculationList[j].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[i]))
                            {
                                TotalAttendanceManPowerSum = TotalAttendanceManPowerSum + model.SaleContractArrearsCalculationList[j].TotalAttendance;
                                OverTimeManPowerSum = OverTimeManPowerSum + model.SaleContractArrearsCalculationList[j].OvertimeHours;
                                TotalDaysManPowerSum = TotalDaysManPowerSum + model.SaleContractArrearsCalculationList[j].TotalDays;
                                AdjustedBasicAmountManPowerSum = AdjustedBasicAmountManPowerSum + model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount;

                                GrandAttendanceManPowerSum = GrandAttendanceManPowerSum + model.SaleContractArrearsCalculationList[j].TotalAttendance;
                                GrandOverTimeManPowerSum = GrandOverTimeManPowerSum + model.SaleContractArrearsCalculationList[j].OvertimeHours;
                                GrandDaysManPowerSum = GrandDaysManPowerSum + model.SaleContractArrearsCalculationList[j].TotalDays;
                                GrandAdjustedBasicAmountManPowerSum = GrandAdjustedBasicAmountManPowerSum + model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount;

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + k + "</td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterName + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractArrearsCalculationList[j].TotalDays + "</td><td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractArrearsCalculationList[j].TotalAttendance + "</td>";
                                k++;
                                foreach (var item in model.SaleContractArrearsCalculationList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.HeadType == "OT")
                                    {
                                        //j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'> " + item.OvertimeHours + "</td>";
                                    }
                                }

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount) + "</td>";

                                decimal TotalEarningEmpMaster = model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount; decimal TotalGrossEmpMaster = model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount; decimal TotalBasicDAEmpMaster = model.SaleContractArrearsCalculationList[j].AdjustedBasicAmount; decimal TotaldeductionEmpMaster = 0;

                                foreach (var item in model.SaleContractArrearsCalculationList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType == "DA")
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                        TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                        TotalBasicDAEmpMaster = TotalBasicDAEmpMaster + item.AdjustedAmount;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalBasicDAEmpMaster) + "</td>";
                                    }
                                }

                                foreach (var item in model.SaleContractArrearsCalculationList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                        TotalGrossEmpMaster = TotalGrossEmpMaster + item.AdjustedAmount;
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalGrossEmpMaster) + "</td>";
                                foreach (var item in model.SaleContractArrearsCalculationList)
                                {
                                    if (Convert.ToInt32(SaleContractEmployeeMasterIDList[i]) == item.SaleContractEmployeeMasterID && Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                                    {
                                        j++;
                                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.AdjustedAmount) + "</td>";
                                        TotalEarningEmpMaster = TotalEarningEmpMaster + item.AdjustedAmount;
                                    }
                                }
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalEarningEmpMaster) + "</td>";
                                foreach (var item in model.SaleContractArrearsCalculationList)
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
                                foreach (var item in model.SaleContractArrearsCalculationList)
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

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>Sub Total</td>";


                        //for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                        //{

                        //    if (model.SaleContractArrearsCalculationList[v].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]))
                        //    {
                        //        bool DataAdded1 = false;
                        //        foreach (var item in model.SaleContractArrearsCalculationList)
                        //        {
                        //            if (model.SaleContractArrearsCalculationList[v].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                        //            {

                        //                DataAdded1 = true;
                        //            }
                        //        }
                        //    }
                        //}

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            foreach (var innerItem in model.SaleContractArrearsCalculationList)
                            {
                                if (item.SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractManPowerItemID == innerItem.SaleContractManPowerItemID && item.HeadID == innerItem.HeadID && item.HeadType == innerItem.HeadType)
                                {
                                    item.ActualAmount = item.ActualAmount + innerItem.AdjustedAmount;
                                }
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + TotalDaysManPowerSum + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + TotalAttendanceManPowerSum + "</td>";

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                            {
                                //manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + OverTimeManPowerSum + "</td>";
                            }
                        }
                        
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(AdjustedBasicAmountManPowerSum) + "</td>";
                        decimal TotalEarningManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotalGrossManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotalBasicDAManPowerItem = AdjustedBasicAmountManPowerSum; decimal TotaldeductionManPowerItem = 0;
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.ActualAmount) + "</td>";
                                TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                                TotalBasicDAManPowerItem = TotalBasicDAManPowerItem + item.ActualAmount;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalBasicDAManPowerItem) + "</td>";
                            }
                        }

                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.ActualAmount) + "</td>";
                                TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                                TotalGrossManPowerItem = TotalGrossManPowerItem + item.ActualAmount;
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalGrossManPowerItem) + "</td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(item.ActualAmount) + "</td>";
                                TotalEarningManPowerItem = TotalEarningManPowerItem + item.ActualAmount;
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalEarningManPowerItem) + "</td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.ActualAmount) + "</td>";
                                TotaldeductionManPowerItem = TotaldeductionManPowerItem + item.ActualAmount;
                            }
                        }
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotaldeductionManPowerItem) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalEarningManPowerItem - TotaldeductionManPowerItem) + "</td>";
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[v].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                            {
                                manPowerListIndex++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(item.ActualAmount) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round((TotalEarningManPowerItem - TotaldeductionManPowerItem) + item.ActualAmount) + "</td>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tbody><tfoot>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Grand Total</b></td>";


                    //for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                    //{
                    //    bool DataAdded1 = false;
                    //    foreach (var item in model.SaleContractArrearsCalculationList)
                    //    {
                    //        if (item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                    //        {

                    //            DataAdded1 = true;
                    //        }
                    //    }
                    //}

                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        item.ActualAmount = 0;
                        foreach (var innerItem in model.SaleContractArrearsCalculationList)
                        {
                            if (item.HeadID == innerItem.HeadID && item.HeadType == innerItem.HeadType)
                            {
                                item.ActualAmount = item.ActualAmount + innerItem.AdjustedAmount;
                            }
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + GrandDaysManPowerSum + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandAttendanceManPowerSum + "</b></td>";

                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.HeadType == "OT")
                        {
                            //manPowerListIndex++;
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + GrandOverTimeManPowerSum + "</b></td>";
                        }
                    }
                   
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(GrandAdjustedBasicAmountManPowerSum) + "</b></td>";
                    decimal GrandEarningManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GrandGrossManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GrandBasicDAManPowerItem = GrandAdjustedBasicAmountManPowerSum; decimal GranddeductionManPowerItem = 0;
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "DA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                            GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                            GrandBasicDAManPowerItem = GrandBasicDAManPowerItem + item.ActualAmount;
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandBasicDAManPowerItem) + "</b></td>";
                        }
                    }

                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType != "DA" && item.HeadType != "RIA" && item.HeadType != "OT" && ((item.HeadType == "AddA" && item.ComplianceType == 1) || (item.HeadType != "AddA")))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                            GrandGrossManPowerItem = GrandGrossManPowerItem + item.ActualAmount;
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandGrossManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && (item.HeadType == "OT" || (item.HeadType == "AddA" && item.ComplianceType == 2)))
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GrandEarningManPowerItem = GrandEarningManPowerItem + item.ActualAmount;
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandEarningManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == false)
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            GranddeductionManPowerItem = GranddeductionManPowerItem + item.ActualAmount;
                        }
                    }
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GranddeductionManPowerItem) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandEarningManPowerItem - GranddeductionManPowerItem) + "</b></td>";
                    foreach (var item in model.SaleContractArrearsCalculationList)
                    {
                        if (Convert.ToInt32(SaleContractManPowerItemIDList[0]) == item.SaleContractManPowerItemID && model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterID == item.SaleContractEmployeeMasterID && item.IsAllowance == true && item.HeadType == "RIA")
                        {
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(item.ActualAmount) + "</b></td>";
                            SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round((GrandEarningManPowerItem - GranddeductionManPowerItem) + item.ActualAmount) + "</b></td>";
                        }
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tfoot></table>";

                    DownloadPDF(SaleContractSalarySheetPDF, Convert.ToString(_model.SaleContractMasterID), Convert.ToInt32(model.SaleContractArrearsCalculationList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "Salary is Not Generated";
                    return RedirectToAction("Index", "SaleContractArrearsCalculation");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult ViewSalaryDetails(string ID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.ID = Convert.ToInt64(ID);
            model.SaleContractArrearsCalculationList = GetSalaryTransactionDetailsByID(ID);

            return PartialView("/Views/Contract/SaleContractArrearsCalculation/ViewSalaryDetails.cshtml", model);
        }

        [HttpGet]
        public ActionResult GenerateSalary(string SaleContractEmployeeMasterID, string SaleContractMasterID, string SaleContractBillingSpanID, string SaleContractManPowerItemID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.SaleContractEmployeeMasterID = Convert.ToInt64(SaleContractEmployeeMasterID);
            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.SaleContractManPowerItemID = Convert.ToInt32(SaleContractManPowerItemID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.SaleContractArrearsCalculationList = GetSalaryTransactionForGeneration(SaleContractEmployeeMasterID, SaleContractMasterID, SaleContractBillingSpanID, SaleContractManPowerItemID);

            return PartialView("/Views/Contract/SaleContractArrearsCalculation/GenerateSalary.cshtml", model);
        }

          [HttpPost]
         public ActionResult GenerateSalary(SaleContractArrearsCalculationViewModel model)
         {
            try
             {
                 if (model != null && model.SaleContractArrearsCalculationDTO != null)
                 {
                     model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                     model.SaleContractArrearsCalculationDTO.SaleContractMasterID = model.SaleContractMasterID;
                     model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                     model.SaleContractArrearsCalculationDTO.SaleContractEmployeeMasterID = model.SaleContractEmployeeMasterID;
                     model.SaleContractArrearsCalculationDTO.SaleContractManPowerItemID = model.SaleContractManPowerItemID;
                     model.SaleContractArrearsCalculationDTO.BasicSalayAmount = model.BasicSalayAmount;
                     model.SaleContractArrearsCalculationDTO.AdjustedBasicAmount = model.AdjustedBasicAmount;
                     model.SaleContractArrearsCalculationDTO.TotalAmount = model.TotalAmount;
                     model.SaleContractArrearsCalculationDTO.GrossAmount = model.GrossAmount;
                     model.SaleContractArrearsCalculationDTO.TotalEarnings = model.TotalEarnings;
                     model.SaleContractArrearsCalculationDTO.TotalDeduction = model.TotalDeduction;
                     model.SaleContractArrearsCalculationDTO.NetPayable = model.NetPayable;
                     model.SaleContractArrearsCalculationDTO.EmployerContributionTotal = model.EmployerContributionTotal;
                     model.SaleContractArrearsCalculationDTO.TotalSalary = model.TotalSalary;
                     model.SaleContractArrearsCalculationDTO.AdjustedTotalSalary = model.AdjustedTotalSalary;
                     model.SaleContractArrearsCalculationDTO.AdjustedTotalDays = model.AdjustedTotalDays;
                     model.SaleContractArrearsCalculationDTO.XMLStringSalaryTransaction = model.XMLStringSalaryTransaction;
                     model.SaleContractArrearsCalculationDTO.IsRemoveForAdjustment = model.IsRemoveForAdjustment;
                     model.SaleContractArrearsCalculationDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                     model.SaleContractArrearsCalculationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                     IBaseEntityResponse<SaleContractArrearsCalculation> response = _SaleContractArrearsCalculationBA.GenerateSaleContractArrearsCalculation(model.SaleContractArrearsCalculationDTO);

                     model.SaleContractArrearsCalculationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                     return Json(model.SaleContractArrearsCalculationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult GenerateBulkSalary(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();

            model.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            model.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            model.CreatedBy = Convert.ToInt32(Session["UserID"]);
            model.SaleContractArrearsCalculationList = GetSalaryTransactionForBulkGeneration(SaleContractMasterID, SaleContractBillingSpanID);

            return PartialView("/Views/Contract/SaleContractArrearsCalculation/GenerateBulkSalary.cshtml", model);
        }

        [HttpPost]
        public ActionResult GenerateBulkSalary(SaleContractArrearsCalculationViewModel model)
        {
            try
            {
                if (model != null && model.SaleContractArrearsCalculationDTO != null)
                {
                    model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                    model.SaleContractArrearsCalculationDTO.SaleContractMasterID = model.SaleContractMasterID;
                    model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = model.SaleContractBillingSpanID;
                    model.SaleContractArrearsCalculationDTO.XMLStringBulkSalaryTransactionEmployee = model.XMLStringBulkSalaryTransactionEmployee;
                    model.SaleContractArrearsCalculationDTO.XMLStringBulkSalaryTransaction = model.XMLStringBulkSalaryTransaction;
                    model.SaleContractArrearsCalculationDTO.XMLstringForVouchar = model.XMLstringForVouchar;

                    model.SaleContractArrearsCalculationDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    IBaseEntityResponse<SaleContractArrearsCalculation> response = _SaleContractArrearsCalculationBA.GenerateSaleContractBulkSalaryTransaction(model.SaleContractArrearsCalculationDTO);

                    model.SaleContractArrearsCalculationDTO.errorMessage = CheckError((response.Entity != null) ? response.Entity.ErrorCode : 20, ActionModeEnum.Insert);

                    return Json(model.SaleContractArrearsCalculationDTO.errorMessage, JsonRequestBehavior.AllowGet);
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
        public ActionResult DownloadNRSheet(string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            SaleContractArrearsCalculationViewModel model = new SaleContractArrearsCalculationViewModel();
            try
            {
                model.SaleContractArrearsCalculationDTO = new SaleContractArrearsCalculation();
                model.SaleContractArrearsCalculationDTO.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
                model.SaleContractArrearsCalculationDTO.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

                model.SaleContractArrearsCalculationDTO.ConnectionString = _connectioString;
                //Code For Generate PDF
                model.SaleContractArrearsCalculationList = GetSalaryTransactionDetailsForNRSheet(SaleContractMasterID, SaleContractBillingSpanID);

                if (model.SaleContractArrearsCalculationList.Count > 0)
                {

                    string SaleContractSalarySheetPDF = " ";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<table  width='100%' border='0'><tbody><tr><td style='font-size:5pt;text-align:left;'>M.W. From II</td><td style='font-size:8pt;text-align:center;'>Wage Sheet</td><td>" + model.SaleContractArrearsCalculationList[0].SaleContractBillingSpanName + "</td></tr><tr><td style='font-size:5pt;text-align:left;'>Factory F.No.17,29</td><td style='font-size:5pt;text-align:center;'>Factory Rules 122, 99 Rule 27 (1) </td><td style='font-size:8pt;text-align:right;'>Month - " + model.SaleContractArrearsCalculationList[0].SalaryMonth + "</td></tr><tr><td style='font-size:8pt;text-align:left;'>Name Of Establishment - " + model.SaleContractArrearsCalculationList[0].CentreName + "</td><td style='font-size:8pt;text-align:center;'>Name Of Employer - " + model.SaleContractArrearsCalculationList[0].CustomerBranchMasterName + "</td><td style='font-size:8pt;text-align:right;'>Year - " + model.SaleContractArrearsCalculationList[0].SalaryYear + "</td></tr></tbody></table>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<br><table width='100%' border='1' style='repeat-header:yes;'><thead><tr>";

                    string[] SaleContractEmployeeMasterIDList = model.SaleContractArrearsCalculationList[0].SaleContractEmployeeMasterIDList.Replace(", ", ",").Split(new char[] { ',' });

                    string[] SaleContractManPowerItemIDList = model.SaleContractArrearsCalculationList[0].SaleContractManPowerItemIDList.Replace(", ", ",").Split(new char[] { ',' });

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
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + manPowerIDIndex + "</td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractArrearsCalculationList[j].SaleContractManPowerItemName + "</td>";

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
                            if (model.SaleContractArrearsCalculationList[j].SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[i]))
                            {
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'>" + k + "</td><td width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>" + model.SaleContractArrearsCalculationList[j].SaleContractEmployeeMasterName + "</td><td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + Math.Round(model.SaleContractArrearsCalculationList[j].GrossAmount) + "</td><td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center; '>" + model.SaleContractArrearsCalculationList[j].TotalAttendance + "</td>";

                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='35%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>0</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(model.SaleContractArrearsCalculationList[j].TotalSalary) + "</td>";
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                                j++;
                                k++;
                                SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                            }
                        }

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'>Sub Total</td>";

                        decimal TotalAttendanceManPowerSum = 0; decimal GrossSalarySum = 0; decimal TotalSalarySum = 0;
                        for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                        {
                            bool DataAdded1 = false;
                            foreach (var item in model.SaleContractArrearsCalculationList)
                            {
                                if (item.SaleContractManPowerItemID == Convert.ToInt32(SaleContractManPowerItemIDList[manPowerID]) && item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                                {
                                    TotalAttendanceManPowerSum = TotalAttendanceManPowerSum + item.TotalAttendance;
                                    GrossSalarySum = GrossSalarySum + item.GrossAmount;
                                    TotalSalarySum = TotalSalarySum + item.TotalSalary;
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
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'>" + Math.Round(TotalSalarySum) + "</td>";
                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'></td>";

                        SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";
                    }

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tbody><tfoot>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<tr><td width='35%' bgcolor='#D3D3D3' style='border: 1px  black;border-collapse: collapse; font-size:8pt;text-align:center;'></td><td bgcolor='#D3D3D3' width='250%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:left;'><b>Grand Total</b></td>";

                    decimal GrandAttendanceManPowerSum = 0; decimal GrandGrossSalarySum = 0; decimal GrandTotalSalarySum = 0;
                    for (int bhu = 0; bhu < SaleContractEmployeeMasterIDList.Count(); bhu++)
                    {
                        bool DataAdded1 = false;
                        foreach (var item in model.SaleContractArrearsCalculationList)
                        {
                            if (item.SaleContractEmployeeMasterID == Convert.ToInt32(SaleContractEmployeeMasterIDList[bhu]) && DataAdded1 == false)
                            {
                                GrandAttendanceManPowerSum = GrandAttendanceManPowerSum + item.TotalAttendance;
                                GrandGrossSalarySum = GrandGrossSalarySum + item.GrossAmount;
                                GrandTotalSalarySum = GrandTotalSalarySum + item.TotalSalary;
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
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='70%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b>" + Math.Round(GrandTotalSalarySum) + "</b></td>";
                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "<td bgcolor='#D3D3D3' width='150%' style='border: 1px  black;border-collapse: collapse; padding: 5px;font-size:8pt;text-align:center;'><b></b></td>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tr>";

                    SaleContractSalarySheetPDF = SaleContractSalarySheetPDF + "</tfoot></table>";

                    DownloadNRPDF(SaleContractSalarySheetPDF, SaleContractMasterID, Convert.ToInt32(model.SaleContractArrearsCalculationList[0].SaleContractMasterID));

                    MemoryStream workStream = new MemoryStream();
                    return new FileStreamResult(workStream, "application/pdf");

                }
                else
                {
                    TempData["_errorMsg"] = "NR Record Not Found for Selected Salary.";
                    return RedirectToAction("Index", "SaleContractArrearsCalculation");
                }
            }
            catch (Exception)
            {
                throw;
            }
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

        protected List<SaleContractArrearsCalculation> GetSalaryTransactionForGeneration(string SaleContractEmployeeMasterID, string SaleContractMasterID, string SaleContractBillingSpanID, string SaleContractManPowerItemID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractEmployeeMasterID = Convert.ToInt64(SaleContractEmployeeMasterID);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SaleContractManPowerItemID = Convert.ToInt32(SaleContractManPowerItemID);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSalaryTransactionForGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        protected List<SaleContractArrearsCalculation> GetSalaryTransactionForBulkGeneration(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSalaryTransactionForBulkGeneration(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        protected List<SaleContractArrearsCalculation> GetSalaryTransactionDetailsByID(string ID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.ID = Convert.ToInt64(ID);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSalaryTransactionDetailsByID(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        protected List<SaleContractArrearsCalculation> GetListSaleContractArrearsCalculationDeduction()
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetListSaleContractArrearsCalculationDeduction(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        [NonAction]
        public IEnumerable<SaleContractArrearsCalculationViewModel> GetSaleContractArrearsCalculation(out int TotalRecords, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            try
            {
                SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
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

                List<SaleContractArrearsCalculationViewModel> listSaleContractMasterViewModel = new List<SaleContractArrearsCalculationViewModel>();
                List<SaleContractArrearsCalculation> listSaleContractMaster = new List<SaleContractArrearsCalculation>();
                IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSaleContractArrearsCalculationBySearch(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listSaleContractMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                        foreach (SaleContractArrearsCalculation item in listSaleContractMaster)
                        {
                            SaleContractArrearsCalculationViewModel SaleContractMasterViewModel = new SaleContractArrearsCalculationViewModel();
                            SaleContractMasterViewModel.SaleContractArrearsCalculationDTO = item;
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

        protected List<SaleContractAttendance> GetSpanListBySaleContractMaster(string SaleContractMasterID)
        {

            SaleContractAttendanceSearchRequest searchRequest = new SaleContractAttendanceSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);

            List<SaleContractAttendance> listSaleContractAttendance = new List<SaleContractAttendance>();
            IBaseEntityCollectionResponse<SaleContractAttendance> baseEntityCollectionResponse = _SaleContractAttendanceBA.GetSpanListBySaleContractMaster(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractArrearsCalculation> GetAttendanceListForSpanWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractArrearsCalculation> listSaleContractAttendance = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetAttendanceListForSpanWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractAttendance;
        }

        protected List<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForSalarySheet(Int64 SaleContractMasterID, Int64 SaleContractBillingSpanID,byte SummaryFormat)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);
            searchRequest.SummaryFormat = Convert.ToByte(SummaryFormat);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSalaryTransactionDetailsForSalarySheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        protected List<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForNRSheet(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractArrearsCalculation> listSaleContractArrearsCalculation = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSalaryTransactionDetailsForNRSheet(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractArrearsCalculation = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listSaleContractArrearsCalculation;
        }

        protected List<SaleContractArrearsCalculation> GetSaleContractArrearsAttendanceSpanWise(string SaleContractMasterID, string SaleContractBillingSpanID)
        {

            SaleContractArrearsCalculationSearchRequest searchRequest = new SaleContractArrearsCalculationSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.SaleContractMasterID = Convert.ToInt64(SaleContractMasterID);
            searchRequest.SaleContractBillingSpanID = Convert.ToInt64(SaleContractBillingSpanID);

            List<SaleContractArrearsCalculation> listSaleContractAttendance = new List<SaleContractArrearsCalculation>();
            IBaseEntityCollectionResponse<SaleContractArrearsCalculation> baseEntityCollectionResponse = _SaleContractArrearsCalculationBA.GetSaleContractArrearsAttendanceSpanWise(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listSaleContractAttendance = baseEntityCollectionResponse.CollectionResponse.ToList();

                }
            }
            return listSaleContractAttendance;
        }
        #endregion

        #region AjaxHandler
        public ActionResult AjaxHandler(JQueryDataTableParamModel param, string SaleContractMasterID, string SaleContractBillingSpanID)
        {
            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            string sortDirection = Convert.ToString(Request["sSortDir_0"]); // asc or desc
            int TotalRecords;
            IEnumerable<SaleContractArrearsCalculationViewModel> filteredSaleContractArrearsCalculation;

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

            filteredSaleContractArrearsCalculation = GetSaleContractArrearsCalculation(out TotalRecords, SaleContractMasterID, SaleContractBillingSpanID);

            var records = filteredSaleContractArrearsCalculation.Skip(0).Take(param.iDisplayLength);
            var result = from c in records select new[] { Convert.ToString(c.ID), Convert.ToString(c.SaleContractEmployeeMasterID), Convert.ToString(c.SaleContractEmployeeMasterName), Convert.ToString(c.TotalDays), Convert.ToString(c.TotalAttendance), Convert.ToString(c.BasicSalayAmount), Convert.ToString(c.TotalSalary), Convert.ToString(c.SaleContractManPowerItemID), Convert.ToString(c.SaleContractManPowerItemName)};
            return Json(new { sEcho = param.sEcho, iTotalRecords = TotalRecords, iTotalDisplayRecords = TotalRecords, aaData = result }, JsonRequestBehavior.AllowGet);

        }
        #endregion
    }
}


