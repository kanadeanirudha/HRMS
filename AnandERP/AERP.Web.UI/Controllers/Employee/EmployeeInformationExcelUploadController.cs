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
using System.Web;
using System.IO;
using System.Net;
using System.Data;
using System.Web.Hosting;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Text.RegularExpressions;
using System.Collections;
using DocumentFormat.OpenXml.Validation;
using System.Web.Helpers;

namespace AERP.Web.UI.Controllers
{
    public class EmployeeInformationExcelUploadController : BaseController
    {
        IEmpEmployeeMasterBA _empEmployeeMasterBA = null;
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
        int EmpCodeFlag;
        int FirstNameFlag;
        int LastNameFlag; int CentreCodeFlag;
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

        public EmployeeInformationExcelUploadController()
        {
            _empEmployeeMasterBA = new EmpEmployeeMasterBA();
        }

        // Controller Methods
        #region Controller Methods

        //-----Code Releated to Export Excel file with data------
        public FileResult DownloadExcel(string CentreCode, string DepartmentID)
        {

            string FileName = CentreCode+"_EmployeeMasterExcelUpload.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            InsertExcelFile(filePath, CentreCode, DepartmentID);
            //InsertExcelFileForFamilyDetails(filePath, CentreCode, DepartmentID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public FileResult DownloadEmployeeExcelFamilyDetails(string CentreCode, string DepartmentID)
        {

            string FileName = CentreCode+"_EmployeeMasterExcelFamilyDetails.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            //InsertExcelFile(filePath, CentreCode, DepartmentID);
            InsertExcelFileForFamilyDetails(filePath, CentreCode, DepartmentID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public FileResult DownloadEmployeeExcelEducationDetails(string CentreCode, string DepartmentID)
        {

            string FileName = CentreCode + "_EmployeeMasterExcelEducationDetails.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            //InsertExcelFile(filePath, CentreCode, DepartmentID);
            InsertExcelFileForEducationDetails(filePath, CentreCode, DepartmentID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public FileResult DownloadEmployeeExcelExperinceDetails(string CentreCode, string DepartmentID)
        {

            string FileName = CentreCode + "_EmployeeMasterExcelExperinceDetails.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            //InsertExcelFile(filePath, CentreCode, DepartmentID);
            InsertExcelFileForExperinceDetails(filePath, CentreCode, DepartmentID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public FileResult DownloadEmployeeExcelContactDetails(string CentreCode, string DepartmentID)
        {

            string FileName = CentreCode + "_EmployeeMasterExcelContactDetails.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateExcelFile(filePath);
            //InsertExcelFile(filePath, CentreCode, DepartmentID);
            InsertExcelFileForContactDetails(filePath, CentreCode, DepartmentID);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }
        public FileResult DownloadEmployeeMasterExcel(string CentreCode)
        {

            string FileName = CentreCode + "_EmployeeMasterPersonalDataExcel.xlsx";
            string filePath = Path.Combine(Server.MapPath("~") + "Content\\DownloadFiles\\", FileName);
            System.IO.File.Delete(filePath);
            CreateEmployeeExcel(filePath);
            InsertExcelFile(filePath, CentreCode);
            string contentType = "application/vnd.ms-excel";
            return File(filePath, contentType, FileName);
        }

        public void CreateEmployeeExcel(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employee Excel" };

                EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
                model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                model.EmpEmployeeMasterDTO.ExcelSheetName = "EmployeeMasterPersonalDataExcel";

                IBaseEntityResponse<EmpEmployeeMaster> response = _empEmployeeMasterBA.GetDataValidationListsForEmployeeMasterExcel(model.EmpEmployeeMasterDTO);
                if (response != null && response.Entity != null)
                {
                    model.EmpEmployeeMasterDTO.NameTitle = response.Entity.NameTitle;
                }


                DataValidation dataValidation1 = new DataValidation()
                {
                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "A3:A100" },
                    Formula1 = new Formula1(string.Concat("\"", model.EmpEmployeeMasterDTO.NameTitle, "\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs1 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs1 != null)
                {
                    dvs1.Count = dvs1.Count + 1;
                    dvs1.Append(dataValidation1);
                }
                else
                {
                    DataValidations newDVs1 = new DataValidations();
                    newDVs1.Append(dataValidation1);
                    newDVs1.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs1);
                }

                DataValidation dataValidation3 = new DataValidation()
                {

                    Type = DataValidationValues.List,
                    AllowBlank = true,
                    SequenceOfReferences = new ListValue<StringValue>() { InnerText = "E3:E500" },
                    Formula1 = new Formula1(string.Concat("\"M,F\"")),
                    ShowErrorMessage = true,
                    ErrorStyle = DataValidationErrorStyleValues.Stop,
                    ErrorTitle = new StringValue("Incorrect Value"),
                    Error = new StringValue("Please select value from list.")
                };
                DataValidations dvs3 = worksheetPart.Worksheet.GetFirstChild<DataValidations>(); //worksheet type => Worksheet
                if (dvs3 != null)
                {
                    dvs3.Count = dvs3.Count + 1;
                    dvs3.Append(dataValidation3);
                }
                else
                {
                    DataValidations newDVs3 = new DataValidations();
                    newDVs3.Append(dataValidation3);
                    newDVs3.Count = 1;
                    worksheetPart.Worksheet.Append(newDVs3);
                }

                sheets.Append(sheet);

                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void CreateExcelFile(string fileName)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employee Details" };

                MergeCells mergeCells = new MergeCells();
                mergeCells.Append(new MergeCell() { Reference = new StringValue("Z1:AD1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("A1:Y1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AE1:AJ1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AK1:AP1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AQ1:AV1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("AW1:BB1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("BC1:BH1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("BI1:BN1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("BO1:BT1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("BU1:BZ1") });

                mergeCells.Append(new MergeCell() { Reference = new StringValue("CA1:CA1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CB1:CD1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CE1:CG1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CH1:CJ1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CK1:CM1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CN1:CP1") });
                mergeCells.Append(new MergeCell() { Reference = new StringValue("CQ1:CS1") });

                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements<SheetData>().First());
                EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
                model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                model.EmpEmployeeMasterDTO.ExcelSheetName = "Employee Details";
                sheets.Append(sheet);
                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = GenerateStyleSheet();
                stylesPart.Stylesheet.Save();

                workbookPart.Workbook.Save();
                document.Close();
            }
        }

        public void InsertExcelFile(string fileName, string CentreCode)
        {
            string[] HeaderData = new string[] { "Title", "First Name", "Middle Name", "Last Name", "Gender", "Employee Code", "Email Address", "Designation", "Birth Date" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I" };

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        public void InsertExcelFileForFamilyDetails(string fileName, string CentreCode)
        {
            string[] HeaderData = new string[] {  "Employee Code" , "Relation","Name", "DOB" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D" };

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        public void InsertExcelFileForEducationDetails(string fileName, string CentreCode)
        {
            string[] HeaderData = new string[] { "Employee Code", "From Year", "Upto Year", "Year Of Passing", "Passing Division", "Name Of Institution", "Education Type", "Board University", "Aggregate Percentage", "Specailisation In" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D","E","F","G","H","I","J" };

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        public void InsertExcelFileForExperinceDetails(string fileName, string CentreCode)
        {
            string[] HeaderData = new string[] { "Employee Code", "Date from", "Date to", "Employer", "Position", "Employer category", "Relevent Experience", };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G" };

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        public void InsertExcelFileForContactDetails(string fileName, string CentreCode)
        {
            string[] HeaderData = new string[] { "Employee Code", "Address Type", "Employee Address1", "Employee Address2", "Plot Number", "Street Name", "Country", "Region", "City", "Pincode", "Telephone Number", "Mobile Number" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G","H","I","J","K","L" };

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 1);
            }
        }
        public void InsertExcelFile(string fileName, string CentreCode, string DepartmentID)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.", "Name", "Working field", "Location", " Qualification", "Designation", "Re Designation", "Dept", "Cader", "Gross  Earnings", "DOJ", "DOT", "DOL", "DOB", "Mobile No. ", "A/c No.", "BANK IFSC CODE", "PAN", "ADHAR", "ESIC", "PF", "UAN", "Marital Status", "Gender", "Date from", "Date To", "Education type", "Institute", "Major",
              "Date from", "Date to", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation"};

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS" };

            InsertTextInExcel(fileName, "Highest Qualification details ", "Z", 1);
            InsertTextInExcel(fileName, "Experience Detail 1 ", "AE", 1);
            InsertTextInExcel(fileName, "Experience Detail 2 ", "AK", 1);
            InsertTextInExcel(fileName, "Experience Detail 3 ", "AQ", 1);
            InsertTextInExcel(fileName, "Experience Detail 4 ", "AW", 1);
            InsertTextInExcel(fileName, "Experience Detail 5 ", "BC", 1);
            InsertTextInExcel(fileName, "Experience Detail 6 ", "BI", 1);
            InsertTextInExcel(fileName, "Experience Detail 7 ", "BO", 1);
            InsertTextInExcel(fileName, "Experience Detail 8 ", "BU", 1);
            InsertTextInExcel(fileName, "NOMINEE ", "CA", 1);
            InsertTextInExcel(fileName, "Family Details 1 ", "CB", 1);
            InsertTextInExcel(fileName, "Family Details 2 ", "CE", 1);
            InsertTextInExcel(fileName, "Family Details 3 ", "CH", 1);
            InsertTextInExcel(fileName, "Family Details 4 ", "CK", 1);
            InsertTextInExcel(fileName, "Family Details 5 ", "CN", 1);
            InsertTextInExcel(fileName, "Family Details 6 ", "CQ", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
            }
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            uint index = 3;
            model.EmpEmployeeMasterListForImportExcel = GetEmployeeDetailsForImportExcel(CentreCode, DepartmentID);
            if (model.EmpEmployeeMasterListForImportExcel.Count > 0)
            {

                for (int i = 0; i < model.EmpEmployeeMasterListForImportExcel.Count; i++)
                {
                    InsertTextInExcel(fileName, Convert.ToString(i + 1), "A", index);  //Sr.No
                    InsertTextInExcel(fileName, model.EmpEmployeeMasterListForImportExcel[i].EmployeeCode, "B", index);//EmployeeCode
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeName), "C", index); //Name
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "D", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "F", index);//Qualification

                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeDesignation), "G", index);//EmployeeDesignation
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DepartmentName), "I", index);//DepartmentName
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].JoiningDate), "L", index);//joining date  
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].TerminationDate), "M", index);//TerminationDate
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfLeaving), "N", index);//Date of Leaving
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfBirth), "O", index);//Date of Birth


                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].MobileNumber), "P", index);//Mobilenumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].BankACNumber), "Q", index);//BankACNumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].PanNumber), "S", index);//PanNumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].AdharCardNumber), "T", index);//AdharCardNumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].ESINumber), "U", index);//ESINumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].ProvidentFundNumber), "V", index);//ProvidentFundNumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].UANNumber), "W", index);//AdharCardNumber
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].MarritalStaus), "X", index);//MarritalStaus
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].GenderCode), "Y", index);//GenderCode
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].FromYear), "Z", index);//DateFrom
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].UptoYear), "AA", index);//DateTO
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "AB", index);//Educationtype
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AC", index);//Institute
                    InsertTextInExcel(fileName, string.Empty, "AD", index);//Major


                    if (model.EmpEmployeeMasterListForImportExcel[i].EmplyeeExperienceList != null)
                    {
                        String[] EmplyeeExperienceList = model.EmpEmployeeMasterListForImportExcel[i].EmplyeeExperienceList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int x = 0; x < EmplyeeExperienceList.Count(); x++)
                        {
                            String[] A = EmplyeeExperienceList[x].Split(new char[] { '~' });
                            switch (x)
                            {

                                case 0:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AE", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AF", index);//date To
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AG", index);//Employer
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AH", index);//Position
                                    InsertTextInExcel(fileName, string.Empty, "AI", index);//Employer category
                                    InsertTextInExcel(fileName, string.Empty, "AJ", index);//Relevent Exp
                                    break;
                                case 1:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AK", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AL", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AM", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AN", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AO", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AP", index);//GenderCode
                                    break;
                                case 2:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AQ", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AR", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AS", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AT", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AU", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AV", index);//GenderCode
                                    break;
                                case 3:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AW", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AX", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AY", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AZ", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BA", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BB", index);//GenderCode
                                    break;
                                case 4:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "BC", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "BD", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "BE", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "BF", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BG", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BH", index);//GenderCode
                                    break;
                                case 5:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "BI", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "BJ", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "BK", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "BL", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BM", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BN", index);//GenderCode
                                    break;
                                case 6:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "BO", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "BP", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "BQ", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "BR", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BS", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BT", index);//GenderCode
                                    break;
                                case 7:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "BU", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "BV", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "BW", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "BX", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BY", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "BZ", index);//GenderCode
                                    break;

                            }


                        }
                    }
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NomineeName), "CA", index);//GenderCode
                    if (model.EmpEmployeeMasterListForImportExcel[i].EmployeeFamilyList != null)
                    {
                        String[] EmployeeFamilyList = model.EmpEmployeeMasterListForImportExcel[i].EmployeeFamilyList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int y = 0; y < EmployeeFamilyList.Count(); y++)
                        {
                            String[] B = EmployeeFamilyList[y].Split(new char[] { '~' });
                            switch (y)
                            {

                                case 0:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CB", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CC", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CD", index);//Relationship
                                    break;
                                case 1:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CE", index);//Name 
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CF", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CG", index);//Relationship
                                    break;
                                case 2:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CH", index);//Name 
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CI", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CJ", index);//Relationship
                                    break;
                                case 3:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CK", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CL", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CM", index);//Relationship
                                    break;
                                case 4:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CN", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CO", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CP", index);//Relationship
                                    break;
                                case 5:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "CQ", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "CR", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "CS", index);//Relationship
                                    break;
                            }


                        }
                    }
                    index++;
                }
            }
        }
        public void InsertExcelFileForFamilyDetails(string fileName, string CentreCode, string DepartmentID)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.", 
              "Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB","Relation","Name","DOB"};

            string[] ColumnsData = new string[] { "A", "B" , "C", "D", "E", "F", "G", "H", "I", "J", "K", "L",  "M", "N", "O", "P", "Q", "R", "S","T" };

           
            InsertTextInExcel(fileName, "Family Details 1 ", "C", 1);
            InsertTextInExcel(fileName, "Family Details 2 ", "F", 1);
            InsertTextInExcel(fileName, "Family Details 3 ", "I", 1);
            InsertTextInExcel(fileName, "Family Details 4 ", "L", 1);
           
            InsertTextInExcel(fileName, "Family Details 5 ", "O", 1);
            InsertTextInExcel(fileName, "Family Details 6 ", "R", 1);
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
            }
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            uint index = 3;
            model.EmpEmployeeMasterListForImportExcel = GetEmployeeDetailsForImportExcel(CentreCode, DepartmentID);
            if (model.EmpEmployeeMasterListForImportExcel.Count > 0)
            {

                for (int i = 0; i < model.EmpEmployeeMasterListForImportExcel.Count; i++)
                {
                    InsertTextInExcel(fileName, Convert.ToString(i + 1), "A", index);  //Sr.No
                    InsertTextInExcel(fileName, model.EmpEmployeeMasterListForImportExcel[i].EmployeeCode, "B", index);//EmployeeCode
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeName), "C", index); //Name
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "D", index);//Working field
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "E", index);//Working field
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "F", index);//Qualification

                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeDesignation), "G", index);//EmployeeDesignation
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "H", index);//Working field
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DepartmentName), "I", index);//DepartmentName
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "J", index);//Working field
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "K", index);//Working field
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].JoiningDate), "L", index);//joining date  
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].TerminationDate), "M", index);//TerminationDate
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfLeaving), "N", index);//Date of Leaving
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfBirth), "O", index);//Date of Birth


                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].MobileNumber), "P", index);//Mobilenumber
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].BankACNumber), "Q", index);//BankACNumber
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "R", index);//Working field
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].PanNumber), "S", index);//PanNumber
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].AdharCardNumber), "T", index);//AdharCardNumber
                  //  InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NomineeName), "CA", index);//GenderCode
                    if (model.EmpEmployeeMasterListForImportExcel[i].EmployeeFamilyList != null)
                    {
                        String[] EmployeeFamilyList = model.EmpEmployeeMasterListForImportExcel[i].EmployeeFamilyList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int y = 0; y < EmployeeFamilyList.Count(); y++)
                        {
                            String[] B = EmployeeFamilyList[y].Split(new char[] { '~' });
                            switch (y)
                            {

                                case 0:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "C", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "D", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "E", index);//Relationship
                                    break;
                                case 1:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "F", index);//Name 
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "G", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "H", index);//Relationship
                                    break;
                                case 2:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "I", index);//Name 
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "J", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "K", index);//Relationship
                                    break;
                                case 3:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "L", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "M", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "N", index);//Relationship
                                    break;
                                case 4:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "O", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "P", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "Q", index);//Relationship
                                    break;
                                case 5:
                                    InsertTextInExcel(fileName, Convert.ToString(B[0]), "R", index);//Name
                                    InsertTextInExcel(fileName, Convert.ToString(B[1]), "S", index);//date of Birth
                                    InsertTextInExcel(fileName, Convert.ToString(B[2]), "T", index);//Relationship
                                    break;
                            }


                        }
                    }
                    index++;
                }
            }
        }
        public void InsertExcelFileForEducationDetails(string fileName, string CentreCode, string DepartmentID)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.",
               "From Year", "Upto Year", "Year Of Passing", "Passing Division", "Name Of Institution", "Education Type", "Board University", "Aggregate Percentage", "Specailisation In" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            InsertTextInExcel(fileName, " Qualification details ", "A", 1);
            //InsertTextInExcel(fileName, "Experience Detail 1 ", "AE", 1);
            //InsertTextInExcel(fileName, "Experience Detail 2 ", "AK", 1);
            //InsertTextInExcel(fileName, "Experience Detail 3 ", "AQ", 1);
            //InsertTextInExcel(fileName, "Experience Detail 4 ", "AW", 1);
            //InsertTextInExcel(fileName, "Experience Detail 5 ", "BC", 1);
            //InsertTextInExcel(fileName, "Experience Detail 6 ", "BI", 1);
            //InsertTextInExcel(fileName, "Experience Detail 7 ", "BO", 1);
            //InsertTextInExcel(fileName, "Experience Detail 8 ", "BU", 1);
            // InsertTextInExcel(fileName, "NOMINEE ", "C", 1);
           
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
            }
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            uint index = 3;
            model.EmpEmployeeMasterListForImportExcel = GetEmployeeDetailsForImportExcel(CentreCode, DepartmentID);
            if (model.EmpEmployeeMasterListForImportExcel.Count > 0)
            {

                for (int i = 0; i < model.EmpEmployeeMasterListForImportExcel.Count; i++)
                {
                    InsertTextInExcel(fileName, Convert.ToString(i + 1), "A", index);  //Sr.No
                    InsertTextInExcel(fileName, model.EmpEmployeeMasterListForImportExcel[i].EmployeeCode, "B", index);//EmployeeCode
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeName), "C", index); //Name
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "D", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "E", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "F", index);//Qualification

                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeDesignation), "G", index);//EmployeeDesignation
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "H", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DepartmentName), "I", index);//DepartmentName
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "J", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "K", index);
                    
                    index++;
                }
            }
        }
        public void InsertExcelFileForExperinceDetails(string fileName, string CentreCode, string DepartmentID)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.",
              "Date from", "Date to", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To","Employer", "Position", "Employer category", "Relevent Experience",
              "Date from", "Date To", "Employer", "Position", "Employer category", "Relevent Experience",};

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX"};

            //InsertTextInExcel(fileName, "Highest Qualification details ", "Z", 1);
            InsertTextInExcel(fileName, "Experience Detail 1 ", "C", 2);
            InsertTextInExcel(fileName, "Experience Detail 2 ", "I", 2);
            InsertTextInExcel(fileName, "Experience Detail 3 ", "O", 2);
            InsertTextInExcel(fileName, "Experience Detail 4 ", "U", 2);
            InsertTextInExcel(fileName, "Experience Detail 5 ", "AA", 2);
            InsertTextInExcel(fileName, "Experience Detail 6 ", "AG", 2);
            InsertTextInExcel(fileName, "Experience Detail 7 ", "AM", 2);
            InsertTextInExcel(fileName, "Experience Detail 8 ", "AS", 2);
            // InsertTextInExcel(fileName, "NOMINEE ", "C", 1);

            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 3);
            }
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            uint index = 4;
            model.EmpEmployeeMasterListForImportExcel = GetEmployeeDetailsForImportExcel(CentreCode, DepartmentID);
            if (model.EmpEmployeeMasterListForImportExcel.Count > 0)
            {

                for (int i = 0; i < model.EmpEmployeeMasterListForImportExcel.Count; i++)
                {
                    InsertTextInExcel(fileName, Convert.ToString(i + 1), "A", index);  //Sr.No
                    InsertTextInExcel(fileName, model.EmpEmployeeMasterListForImportExcel[i].EmployeeCode, "B", index);//EmployeeCode
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeName), "C", index); //Name
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "D", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "E", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "F", index);//Qualification

                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeDesignation), "G", index);//EmployeeDesignation
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "H", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DepartmentName), "I", index);//DepartmentName
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "J", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "K", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].JoiningDate), "L", index);//joining date  
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].TerminationDate), "M", index);//TerminationDate
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfLeaving), "N", index);//Date of Leaving
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfBirth), "O", index);//Date of Birth


                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].MobileNumber), "P", index);//Mobilenumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].BankACNumber), "Q", index);//BankACNumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "R", index);//Working field
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].PanNumber), "S", index);//PanNumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].AdharCardNumber), "T", index);//AdharCardNumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].ESINumber), "U", index);//ESINumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].ProvidentFundNumber), "V", index);//ProvidentFundNumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].UANNumber), "W", index);//AdharCardNumber
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].MarritalStaus), "X", index);//MarritalStaus
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].GenderCode), "Y", index);//GenderCode
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].FromYear), "Z", index);//DateFrom
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].UptoYear), "AA", index);//DateTO
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "AB", index);//Educationtype
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AC", index);//Institute
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AD", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AE", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AF", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AG", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AH", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AI", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AJ", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AK", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AL", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AM", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AN", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AO", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AP", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AQ", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AR", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AS", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AT", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AU", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AW", index);
                    //InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].NameOfInstitution), "AX", index);
                    if (model.EmpEmployeeMasterListForImportExcel[i].EmplyeeExperienceList != null)
                    {
                        String[] EmplyeeExperienceList = model.EmpEmployeeMasterListForImportExcel[i].EmplyeeExperienceList.Replace(", ", ",").Split(new char[] { ',' });
                        for (int x = 0; x < EmplyeeExperienceList.Count(); x++)
                        {
                            String[] A = EmplyeeExperienceList[x].Split(new char[] { '~' });
                            switch (x)
                            {

                                case 0:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "C", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "D", index);//date To
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "E", index);//Employer
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "F", index);//Position
                                    InsertTextInExcel(fileName, string.Empty, "G", index);//Employer category
                                    InsertTextInExcel(fileName, string.Empty, "H", index);//Relevent Exp
                                    break;
                                case 1:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "I", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "J", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "K", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "L", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "M", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "N", index);//GenderCode
                                    break;
                                case 2:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "O", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "P", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "Q", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "R", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "S", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "T", index);//GenderCode
                                    break;
                                case 3:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "U", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "V", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "W", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "X", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "Y", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "Z", index);//GenderCode
                                    break;
                                case 4:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AA", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AB", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AC", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AD", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AE", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AF", index);//GenderCode
                                    break;
                                case 5:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AG", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AH", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AI", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AJ", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AK", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AL", index);//GenderCode
                                    break;
                                case 6:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AM", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AN", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AO", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AP", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AQ", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AR", index);//GenderCode
                                    break;
                                case 7:
                                    InsertTextInExcel(fileName, Convert.ToString(A[0]), "AS", index);//Date from 
                                    InsertTextInExcel(fileName, Convert.ToString(A[1]), "AT", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[2]), "AU", index);//GenderCode
                                    InsertTextInExcel(fileName, Convert.ToString(A[3]), "AV", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AW", index);//GenderCode
                                    InsertTextInExcel(fileName, string.Empty, "AX", index);//GenderCode
                                    break;

                            }


                        }
                    }
                    index++;
                }
            }
        }
        public void InsertExcelFileForContactDetails(string fileName, string CentreCode, string DepartmentID)
        {
            string[] HeaderData = new string[] { "Sr. No.", "Employee ID No.",
              "Address Type", "Employee Address1", "Employee Address2", "Plot Number", "Street Name", "Country", "Region", "City", "Pincode", "Telephone Number", "Mobile Number" };

            string[] ColumnsData = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };

            InsertTextInExcel(fileName, "ContactDetails ", "A", 1);
            
           
            for (uint i = 0; i < HeaderData.Length; i++)
            {
                InsertTextInExcel(fileName, HeaderData[i], ColumnsData[i], 2);
            }
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            uint index = 3;
            model.EmpEmployeeMasterListForImportExcel = GetEmployeeDetailsForImportExcel(CentreCode, DepartmentID);
            if (model.EmpEmployeeMasterListForImportExcel.Count > 0)
            {

                for (int i = 0; i < model.EmpEmployeeMasterListForImportExcel.Count; i++)
                {
                    InsertTextInExcel(fileName, Convert.ToString(i + 1), "A", index);  //Sr.No
                    InsertTextInExcel(fileName, model.EmpEmployeeMasterListForImportExcel[i].EmployeeCode, "B", index);//EmployeeCode
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeName), "C", index); //Name
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "D", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "E", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].SpecailisationIn), "F", index);//Qualification

                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].EmployeeDesignation), "G", index);//EmployeeDesignation
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "H", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DepartmentName), "I", index);//DepartmentName
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "J", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].CentreCode), "K", index);//Working field
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].JoiningDate), "L", index);//joining date  
                    InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].TerminationDate), "M", index);//TerminationDate
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfLeaving), "N", index);//Date of Leaving
                   // InsertTextInExcel(fileName, Convert.ToString(model.EmpEmployeeMasterListForImportExcel[i].DateOfBirth), "O", index);//Date of Birth


                   
                    index++;
                }
            }
        }
        public static void InsertTextInExcel(string docName, string text, string Columns, uint rowID)
        {
            // Open the document for editing.
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(docName, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }

                // Insert the text into the SharedStringTablePart.
                int index = InsertSharedStringItem(text, shareStringPart);

                // Insert a new worksheet.
                //WorksheetPart worksheetPart = InsertWorksheet(spreadSheet.WorkbookPart);

                Sheet sheet = spreadSheet.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();

                //Get the Worksheet instance.
                WorksheetPart worksheetPart = spreadSheet.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart;

                // Insert cell A1 into the new worksheet.
                Cell cell = InsertCellInWorksheet(Columns, rowID, worksheetPart);

                // Set the value of cell A1.
                cell.CellValue = new CellValue(index.ToString());
                cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                if (cell.CellReference.Value == "A1")
                {
                    cell.StyleIndex = 4;
                }
                else if (cell.CellReference.Value == "Z1" || cell.CellReference.Value == "AA1" || cell.CellReference.Value == "AB1" || cell.CellReference.Value == "AC1" || cell.CellReference.Value == "AD1")
                {
                    cell.StyleIndex = 6;
                }
                else if (cell.CellReference.Value == "A2" || cell.CellReference.Value == "B2" || cell.CellReference.Value == "C2" || cell.CellReference.Value == "D2" || cell.CellReference.Value == "E2" || cell.CellReference.Value == "F2" || cell.CellReference.Value == "G2" || cell.CellReference.Value == "H2" || cell.CellReference.Value == "I2" || cell.CellReference.Value == "J2" || cell.CellReference.Value == "K2" || cell.CellReference.Value == "L2" || cell.CellReference.Value == "M2" || cell.CellReference.Value == "N2" || cell.CellReference.Value == "O2" || cell.CellReference.Value == "P2" || cell.CellReference.Value == "T2" || cell.CellReference.Value == "S2" || cell.CellReference.Value == "R2" || cell.CellReference.Value == "Q2" || cell.CellReference.Value == "S2" || cell.CellReference.Value == "T2" || cell.CellReference.Value == "U2" || cell.CellReference.Value == "V2" || cell.CellReference.Value == "W2" || cell.CellReference.Value == "X2" || cell.CellReference.Value == "Y2" || cell.CellReference.Value == "Z2" || cell.CellReference.Value == "AA2" || cell.CellReference.Value == "AB2" || cell.CellReference.Value == "AC2" || cell.CellReference.Value == "AD2" || cell.CellReference.Value == "AE2" || cell.CellReference.Value == "AF2" || cell.CellReference.Value == "AG2" || cell.CellReference.Value == "AH2" || cell.CellReference.Value == "AI2" || cell.CellReference.Value == "AJ2" || cell.CellReference.Value == "AQ2" || cell.CellReference.Value == "AR2" || cell.CellReference.Value == "AS2" || cell.CellReference.Value == "AT2" || cell.CellReference.Value == "AU2" || cell.CellReference.Value == "AV2" || cell.CellReference.Value == "BC2" || cell.CellReference.Value == "BD2" || cell.CellReference.Value == "BE2" || cell.CellReference.Value == "BF2" || cell.CellReference.Value == "BG2" || cell.CellReference.Value == "BH2" || cell.CellReference.Value == "BO2" || cell.CellReference.Value == "BP2" || cell.CellReference.Value == "BQ2" || cell.CellReference.Value == "BR2" || cell.CellReference.Value == "BS2" || cell.CellReference.Value == "BT2" ||
                  cell.CellReference.Value == "AK2" || cell.CellReference.Value == "AL2" || cell.CellReference.Value == "AM2" || cell.CellReference.Value == "AN2" || cell.CellReference.Value == "AO2" || cell.CellReference.Value == "AP2" || cell.CellReference.Value == "AW2" || cell.CellReference.Value == "AX2" || cell.CellReference.Value == "AY2" || cell.CellReference.Value == "AZ2" || cell.CellReference.Value == "BA2" || cell.CellReference.Value == "BB2" || cell.CellReference.Value == "BI2" || cell.CellReference.Value == "BJ2" || cell.CellReference.Value == "BK2" || cell.CellReference.Value == "BL2" || cell.CellReference.Value == "BM2" || cell.CellReference.Value == "BN2" || cell.CellReference.Value == "BU2" || cell.CellReference.Value == "BV2" || cell.CellReference.Value == "BW2" || cell.CellReference.Value == "BX2" || cell.CellReference.Value == "BY2" || cell.CellReference.Value == "BZ2" || cell.CellReference.Value == "CA2" || cell.CellReference.Value == "CB2" || cell.CellReference.Value == "CC2" || cell.CellReference.Value == "CD2" || cell.CellReference.Value == "CE2" || cell.CellReference.Value == "CF2" || cell.CellReference.Value == "CG2" || cell.CellReference.Value == "CH2" || cell.CellReference.Value == "CI2" || cell.CellReference.Value == "CJ2" || cell.CellReference.Value == "CK2" || cell.CellReference.Value == "CL2" || cell.CellReference.Value == "CM2" || cell.CellReference.Value == "CN2" || cell.CellReference.Value == "CO2" || cell.CellReference.Value == "CP2" || cell.CellReference.Value == "CQ2" || cell.CellReference.Value == "CR2" || cell.CellReference.Value == "CS2")
                {
                    cell.StyleIndex = 5;
                }
                else if (cell.CellReference.Value == "AE1" || cell.CellReference.Value == "AF1" || cell.CellReference.Value == "AG1" || cell.CellReference.Value == "AH1" || cell.CellReference.Value == "AI1" || cell.CellReference.Value == "AJ1" || cell.CellReference.Value == "AQ1" || cell.CellReference.Value == "AR1" || cell.CellReference.Value == "AS1" || cell.CellReference.Value == "AT1" || cell.CellReference.Value == "AU1" || cell.CellReference.Value == "AV1" || cell.CellReference.Value == "BC1" || cell.CellReference.Value == "BD1" || cell.CellReference.Value == "BE1" || cell.CellReference.Value == "BF1" || cell.CellReference.Value == "BG1" || cell.CellReference.Value == "BH1" || cell.CellReference.Value == "BO1" || cell.CellReference.Value == "BP1" || cell.CellReference.Value == "BQ1" || cell.CellReference.Value == "BR1" || cell.CellReference.Value == "BS1" || cell.CellReference.Value == "BT1")
                {
                    cell.StyleIndex = 7;
                }
                else if (cell.CellReference.Value == "AK1" || cell.CellReference.Value == "AL1" || cell.CellReference.Value == "AM1" || cell.CellReference.Value == "AN1" || cell.CellReference.Value == "AO1" || cell.CellReference.Value == "AP1" || cell.CellReference.Value == "AW1" || cell.CellReference.Value == "AX1" || cell.CellReference.Value == "AY1" || cell.CellReference.Value == "AZ1" || cell.CellReference.Value == "BA1" || cell.CellReference.Value == "BB1" || cell.CellReference.Value == "BI1" || cell.CellReference.Value == "BJ1" || cell.CellReference.Value == "BK1" || cell.CellReference.Value == "BL1" || cell.CellReference.Value == "BM1" || cell.CellReference.Value == "BN1" || cell.CellReference.Value == "BU1" || cell.CellReference.Value == "BV1" || cell.CellReference.Value == "BW1" || cell.CellReference.Value == "BX1" || cell.CellReference.Value == "BY1" || cell.CellReference.Value == "BZ1")
                {
                    cell.StyleIndex = 8;
                }
                else if (cell.CellReference.Value == "CA1" || cell.CellReference.Value == "CB1" || cell.CellReference.Value == "CC1" || cell.CellReference.Value == "CD1" || cell.CellReference.Value == "CE1" || cell.CellReference.Value == "CF1" || cell.CellReference.Value == "CG1" || cell.CellReference.Value == "CH1" || cell.CellReference.Value == "CI1" || cell.CellReference.Value == "CJ1" || cell.CellReference.Value == "CK1" || cell.CellReference.Value == "CL1" || cell.CellReference.Value == "CM1" || cell.CellReference.Value == "CN1" || cell.CellReference.Value == "CO1" || cell.CellReference.Value == "CP1" || cell.CellReference.Value == "CQ1" || cell.CellReference.Value == "CR1" || cell.CellReference.Value == "CS1")
                {
                    cell.StyleIndex = 9;
                }
                else
                    cell.StyleIndex = 2;
                // Save the new worksheet.
                worksheetPart.Worksheet.Save();
            }
        }

        private Stylesheet GenerateStyleSheet()
        {
            return new Stylesheet(
                new Fonts(
                    new Font(                                                               // Index 0 – The default font.
                        new FontSize() { Val = 10 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 1 – The bold font.
                        new Bold(),
                        new FontSize() { Val = 11 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "ffffff" } }, //white
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 – The Italic font.
                        new Italic(),
                        new FontSize() { Val = 10 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Calibri" }),
                    new Font(                                                               // Index 2 – The Times Roman font. with 16 size
                        new FontSize() { Val = 16 },
                        new Color() { Rgb = new HexBinaryValue() { Value = "000000" } },
                        new FontName() { Val = "Times New Roman" })
                ),
                new Fills(
                    new Fill(                                                           // Index 0 – The default fill.
                        new PatternFill() { PatternType = PatternValues.None }),
                    new Fill(                                                           // Index 1 – The default fill of gray 125 (required)
                        new PatternFill() { PatternType = PatternValues.Gray125 }),
                    new Fill(                                                           // Index 2 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "CFD2D4" } }
                        )
                        { PatternType = PatternValues.Solid }),
                   new Fill(                                                           // Index 3 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "C6EFCE" } }
                        )
                        { PatternType = PatternValues.Solid }),
                   new Fill(                                                           // Index 4 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "D99795" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 5 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "F2DDC7" } }
                        )
                        { PatternType = PatternValues.Solid }),
                    new Fill(                                                           // Index 6 – The yellow fill.
                        new PatternFill(
                            new ForegroundColor() { Rgb = new HexBinaryValue() { Value = "20b2aa" } }
                        )
                        { PatternType = PatternValues.Solid })
                ),
                new Borders(
                    new Border(                                                         // Index 0 – The default border.
                        new LeftBorder(),
                        new RightBorder(),
                        new TopBorder(),
                        new BottomBorder(),
                        new DiagonalBorder()),
                    new Border(                                                         // Index 1 – Applies a Left, Right, Top, Bottom border to a cell
                        new LeftBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new RightBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new TopBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new BottomBorder(
                            new Color() { Auto = true }
                        )
                        { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                ),
                new CellFormats(
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 },                          // Index 0 – The default cell style.  If a cell does not have a style index applied it will use this style combination instead
                    new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 1 – Bold 
                    new CellFormat() { FontId = 2, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 2 – Italic
                    new CellFormat() { FontId = 3, FillId = 0, BorderId = 0, ApplyFont = true },       // Index 3 – Times Roman
                    new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, ApplyFill = true },       // Index 4 – Yellow Fill
                    new CellFormat(                                                                   // Index 5 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center, WrapText = true }
                    )
                    { FontId = 0, FillId = 2, BorderId = 1, ApplyAlignment = true },
                     new CellFormat(                                                                   // Index 6 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                     { FontId = 1, FillId = 3, BorderId = 1, ApplyAlignment = true },
                      new CellFormat(                                                                   // Index 7 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                      { FontId = 1, FillId = 4, BorderId = 1, ApplyAlignment = true },
                     new CellFormat(                                                                   // Index 8 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                     { FontId = 1, FillId = 5, BorderId = 1, ApplyAlignment = true },
                      new CellFormat(                                                                   // Index 8 – Alignment
                        new Alignment() { Horizontal = HorizontalAlignmentValues.Center, Vertical = VerticalAlignmentValues.Center }
                    )
                      { FontId = 1, FillId = 6, BorderId = 1, ApplyAlignment = true }
                )
            ); // return
        }

       



        // Non-Action Method
        #region Methods

        [NonAction]
        protected List<EmpEmployeeMaster> GetEmployeeDetailsForImportExcel(string CentreCode, string DepartmentID)
        {
            EmpEmployeeMasterSearchRequest searchRequest = new EmpEmployeeMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
            searchRequest.CentreCode = CentreCode;
            searchRequest.DepartmentID = Convert.ToInt32(DepartmentID);

            List<EmpEmployeeMaster> listEmployees = new List<EmpEmployeeMaster>();
            IBaseEntityCollectionResponse<EmpEmployeeMaster> baseEntityCollectionResponse = _empEmployeeMasterBA.GetEmployeeDetailsForImportExcel(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listEmployees = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listEmployees;
        }




        #endregion
        [HttpGet]
        public ActionResult DownloadEmployeeExcel(string centreCode)
        {
            EmpEmployeeMasterViewModel model = new EmpEmployeeMasterViewModel();
            List<SelectListItem> Details = new List<SelectListItem>();
            ViewBag.Details = new SelectList(Details, "Value", "Text");
            List<SelectListItem> li_Details = new List<SelectListItem>();

            li_Details.Add(new SelectListItem { Text = "Basic Details", Value = "0" });
            li_Details.Add(new SelectListItem { Text = "Family Details", Value = "1" });
            li_Details.Add(new SelectListItem { Text = "Education Details", Value = "2" });
            li_Details.Add(new SelectListItem { Text = "Experince Details", Value = "3" });
            li_Details.Add(new SelectListItem { Text = "Contact Details", Value = "4" });
            ViewData["Details"] = li_Details;

            model.CentreCode = centreCode;
            
            return PartialView("/Views/Employee/EmployeeInformation/DownloadEmployeeMasterExcel.cshtml", model);
        }
        [HttpPost]
        public FileResult DownloadEmployeeExcel(EmpEmployeeMasterViewModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                // {
                if (model != null && model.EmpEmployeeMasterDTO != null)
                {
                   // UploadExcelForEmployeeAttendence();

                    model.EmpEmployeeMasterDTO.ConnectionString = _connectioString;
                    model.EmpEmployeeMasterDTO.CentreCode = model.CentreCode;
                    model.EmpEmployeeMasterDTO.DepartmentID = model.DepartmentID;
                    model.EmpEmployeeMasterDTO.Details = model.Details;
                    //model.EmpEmployeeMasterDTO.XMLString = xmlParameter;
                    model.EmpEmployeeMasterDTO.CreatedBy = Convert.ToInt32(Session["UserID"]);
                    if (!String.IsNullOrEmpty(model.Details) && model.Details.Equals("0"))
                    {
                        return DownloadExcel(model.CentreCode, Convert.ToString(model.DepartmentID));
                    }
                   else if (!String.IsNullOrEmpty(model.Details) && model.Details.Equals("1"))
                    {
                       return DownloadEmployeeExcelFamilyDetails(model.CentreCode,Convert.ToString(model.DepartmentID));
                    }
                   else if (!String.IsNullOrEmpty(model.Details) && model.Details.Equals("2"))
                    {
                        return DownloadEmployeeExcelEducationDetails(model.CentreCode, Convert.ToString(model.DepartmentID));
                    }
                    else if (!String.IsNullOrEmpty(model.Details) && model.Details.Equals("3"))
                    {
                        return DownloadEmployeeExcelExperinceDetails(model.CentreCode, Convert.ToString(model.DepartmentID));
                    }
                    else if (!String.IsNullOrEmpty(model.Details) && model.Details.Equals("4"))
                    {
                        return DownloadEmployeeExcelContactDetails(model.CentreCode, Convert.ToString(model.DepartmentID));
                    }
                   

                    TempData["_errorMsg"] = model.EmpEmployeeMasterDTO.errorMessage;
                    //  xmlParameter = null;
                    //   IsExcelValid = true;
                    errorMessage = null;
                    return null;
                    //return Json(model.VendorMasterDTO.errorMessage, JsonRequestBehavior.AllowGet);
                }
                //  }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string[] arrayList = { ex.Message, "danger", null };
                TempData["_errorMsg"] = string.Join(",", arrayList);
                errorMessage = null;
                return null;
            }
        }
        #endregion


    }
}