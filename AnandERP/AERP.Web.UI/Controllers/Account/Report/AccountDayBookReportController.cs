using AERP.Base.DTO;
using AERP.DTO;
using AERP.Business.BusinessAction;
using AERP.ViewModel;
using System;
using AERP.ExceptionManager;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using System.IO;
using System.Xml;

namespace AERP.Web.UI.Controllers
{
    public class AccountDayBookReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAccountDayBookReportBA _accountDayBookReportBA = null;

        private readonly ILogger _logException;
        protected static string _sessionFromDate = string.Empty;
        protected static string _sessionUptoDate = string.Empty;
        protected static string _accountIdXml = string.Empty;
        protected static string _balanesheetMstIDXml = string.Empty;
        protected static Int16 _balanesheetMstID;
        protected static string _transactionTypeXml = string.Empty;
        protected static Int16    _accountSessionID ;
        protected static string _modeCode = string.Empty;
        protected static string _pattern = string.Empty;
        protected static string _patternType = string.Empty;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public AccountDayBookReportController()
        {
            _accountDayBookReportBA = new AccountDayBookReportBA();
          
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            try
            {
                if (Convert.ToInt32(Session["Account Manager"]) > 0 || Convert.ToInt32(Session["Admin Manager"]) > 0)
                {
                    AccountDayBookReportViewModel model = new AccountDayBookReportViewModel();
                    model.ListAccountSessionMasterReport = GetAllAccountSession();
                    model.ListAccountMasterReport = GetAccountList(string.Empty, string.Empty);
                    //model.SessionFromDate = model.ListAccountSessionMasterReport.Count > 0 ? model.ListAccountSessionMasterReport[0].SessionName.Split('-')[0] : string.Empty;
                    //model.SessionUptoDate = model.ListAccountSessionMasterReport.Count > 0 ? model.ListAccountSessionMasterReport[0].SessionName.Split('-')[1] : string.Empty;
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "Detailed", Value = "DETAILED" });
                    li.Add(new SelectListItem { Text = "Daywise", Value = "DAYWISE" });
                    li.Add(new SelectListItem { Text = "Spanwise", Value = "SPANWISE" });
                    li.Add(new SelectListItem { Text = "Voucher", Value = "VOUCHER" });
                    ViewData["Pattern"] = li;

                    List<SelectListItem> li1 = new List<SelectListItem>();
                    li1.Add(new SelectListItem { Text = "All", Value = "ALL" });
                    li1.Add(new SelectListItem { Text = "Fee", Value = "FEE" });
                    li1.Add(new SelectListItem { Text = "Modulewise", Value = "MODULEWISE" });
                    ViewData["PatternType"] = li1;

                    List<SelectListItem> li2 = new List<SelectListItem>();
                    li2.Add(new SelectListItem { Text = "Receipt", Value = "R" });
                    li2.Add(new SelectListItem { Text = "Payment", Value = "P" });
                    li2.Add(new SelectListItem { Text = "Journal", Value = "J" });
                    li2.Add(new SelectListItem { Text = "Purchase", Value = "H" });
                    li2.Add(new SelectListItem { Text = "Sale", Value = "S" });

                    for (int i = 0; i < li2.Count; i++)
                    {
                        AccountTransactionTypeMaster list = new AccountTransactionTypeMaster();
                        list.TransactionTypeName = li2[i].Text;
                        list.TransactionTypeCode = li2[i].Value;
                        model.ListTransactionTypeMasterReport.Add(list);
                    }

                    return View("/Views/Accounts/Report/AccountDayBookReport/Index.cshtml", model);
                }
                else
                {
                    return RedirectToAction("UnauthorizedAccess", "Home");
                }
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }

        
        [HttpPost]
        public ActionResult Index(AccountDayBookReportViewModel model)//string SelectedHeadID, string SelectedCategoryID)
        {
            try
            {
                model.ListAccountSessionMasterReport = GetAllAccountSession();
                List<AccountMaster> AccountList = GetAccountList(string.Empty, string.Empty);
                string xpath = "rows/row/ID";
                string emptypath = "<rows><row><ID></ID></row></rows>";
                XmlDocument xmlDocAccountIDs = new XmlDocument();
                XmlDocument xmlDocTransactionTypes = new XmlDocument();

                List<SelectListItem> li2 = new List<SelectListItem>();
                li2.Add(new SelectListItem { Text = "Receipt", Value = "R" });
                li2.Add(new SelectListItem { Text = "Payment", Value = "P" });
                li2.Add(new SelectListItem { Text = "Journal", Value = "J" });
                li2.Add(new SelectListItem { Text = "Purchase", Value = "H" });
                li2.Add(new SelectListItem { Text = "Sale", Value = "S" });

                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem { Text = "Detailed", Value = "DETAILED" });
                li.Add(new SelectListItem { Text = "Daywise", Value = "DAYWISE" });
                li.Add(new SelectListItem { Text = "Spanwise", Value = "SPANWISE" });
                li.Add(new SelectListItem { Text = "Voucher", Value = "VOUCHER" });
                ViewData["Pattern"] = new SelectList(li, "Value", "Text", model.Pattern);


                List<SelectListItem> li1 = new List<SelectListItem>();
                li1.Add(new SelectListItem { Text = "All", Value = "ALL" });
                li1.Add(new SelectListItem { Text = "Fee", Value = "FEE" });
                li1.Add(new SelectListItem { Text = "Modulewise", Value = "MODULEWISE" });
                ViewData["PatternType"] = new SelectList(li1, "Value", "Text", model.PatternType);

                if (model.IsPosted == true)
                {
                    xmlDocAccountIDs.LoadXml(!string.IsNullOrEmpty(model.AccountIDsXmlString) ? model.AccountIDsXmlString : emptypath);
                    var AccountXmlNodes = xmlDocAccountIDs.SelectNodes(xpath);
                    foreach (var item in AccountList)
                    {
                        AccountMaster list = new AccountMaster();
                        list.AccountName = item.AccountName;
                        list.ID = item.ID;
                        foreach (XmlNode childrenNode in AccountXmlNodes)
                        {
                            if (item.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListAccountMasterReport.Add(list);
                    }

                  
                    xmlDocTransactionTypes.LoadXml(!string.IsNullOrEmpty(model.TransactionTypeXmlString) ? model.TransactionTypeXmlString : emptypath);
                    var TransactionTypeXmlNodes = xmlDocTransactionTypes.SelectNodes(xpath);
                    foreach (var item in li2)
                    {
                        AccountTransactionTypeMaster list = new AccountTransactionTypeMaster();
                        list.TransactionTypeName = item.Text;
                        list.TransactionTypeCode = item.Value;
                        foreach (XmlNode childrenNode in TransactionTypeXmlNodes)
                        {
                            if (item.Value == childrenNode.InnerText)
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListTransactionTypeMasterReport.Add(list);
                    }

                    /// Allocate parameters to local variable
                    _sessionFromDate = model.SessionFromDate;
                    _sessionUptoDate = model.SessionUptoDate;
                    _accountIdXml = model.AccountIDsXmlString;
                    _transactionTypeXml = model.TransactionTypeXmlString;
                    _balanesheetMstIDXml = "<rows><row><ID>" + model.AccBalsheetMstID + "</ID></row></rows>";
                    _balanesheetMstID = model.AccBalsheetMstID;
                    _accountSessionID =Convert.ToInt16(model.SelectedAccountSessionID);
                    _modeCode = string.Empty;
                    _pattern = model.Pattern;
                    _patternType = model.PatternType;

                    model.IsPosted = false;
                }
                else
                {
                    xmlDocAccountIDs.LoadXml(!string.IsNullOrEmpty(_accountIdXml) ? _accountIdXml : emptypath);
                    var AccountXmlNodes = xmlDocAccountIDs.SelectNodes(xpath);
                    foreach (var item in AccountList)
                    {
                        AccountMaster list = new AccountMaster();
                        list.AccountName = item.AccountName;
                        list.ID = item.ID;
                        foreach (XmlNode childrenNode in AccountXmlNodes)
                        {
                            if (item.ID == (!string.IsNullOrEmpty(childrenNode.InnerText) ? Convert.ToInt32(childrenNode.InnerText) : 0))
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListAccountMasterReport.Add(list);
                    }


                    xmlDocTransactionTypes.LoadXml(!string.IsNullOrEmpty(_transactionTypeXml) ? _transactionTypeXml : emptypath);
                    var TransactionTypeXmlNodes = xmlDocTransactionTypes.SelectNodes(xpath);
                    foreach (var item in li2)
                    {
                        AccountTransactionTypeMaster list = new AccountTransactionTypeMaster();
                        list.TransactionTypeName = item.Text;
                        list.TransactionTypeCode = item.Value;
                        foreach (XmlNode childrenNode in TransactionTypeXmlNodes)
                        {
                            if (item.Value == childrenNode.InnerText)
                            {
                                list.IsActive = true;
                                break;
                            }
                        }
                        model.ListTransactionTypeMasterReport.Add(list);
                    }
                    /// Allocate value from local variable to model properties 
                    model.SessionFromDate= _sessionFromDate ;
                    model.SessionUptoDate =_sessionUptoDate;
                    model.AccountIDsXmlString =_accountIdXml;
                    model.TransactionTypeXmlString =_transactionTypeXml  ;
                    model.AccBalsheetMstID = _balanesheetMstID;
                    model.SelectedAccountSessionID =Convert.ToString(_accountSessionID);
                    model.Pattern =_pattern;
                    model.PatternType =_patternType;
                }

                return View("/Views/Accounts/Report/AccountDayBookReport/Index.cshtml", model);

            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }
      
        #endregion

         #region ------------CONTROLLER NON ACTION METHODS------------

        public List<OrganisationStudyCentreMaster> GetReportHeader()
        {
            List<OrganisationStudyCentreMaster> listOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            listOrganisationStudyCentreMaster = GetStudyCentreDetailsForReports(string.Empty, _balanesheetMstID);
            return listOrganisationStudyCentreMaster;
        }

        public List<AccountDayBookReport> GetDayBookReportData(string centreCode)
         {
             try
             {
                 List<AccountDayBookReport> listaccountDayBookReport =  new List<AccountDayBookReport>();
                 if (_balanesheetMstID > 0)
                 {
                     AccountDayBookReportSearchRequest searchRequest = new AccountDayBookReportSearchRequest();
                     searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                     searchRequest.SessionFromDate = _sessionFromDate;
                     searchRequest.SessionUptoDate = _sessionUptoDate;
                     searchRequest.AccountIDsXmlString = _accountIdXml;
                     searchRequest.TransactionTypeXmlString = _transactionTypeXml;
                     searchRequest.AccBalsheetIDsXmlString = _balanesheetMstIDXml;
                     searchRequest.AccSessionID = _accountSessionID;
                     searchRequest.CentreCode = centreCode;
                     searchRequest.ModeCode = _modeCode;
                     searchRequest.Pattern = _pattern;
                     searchRequest.PatternType = _patternType;
                    
                     IBaseEntityCollectionResponse<AccountDayBookReport> baseEntityCollectionResponse = _accountDayBookReportBA.GetBySearch(searchRequest);
                     if (baseEntityCollectionResponse != null)
                     {
                         if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                         {
                             listaccountDayBookReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                         }
                     }
                     return listaccountDayBookReport;
                 }
                 else
                 {
                     return listaccountDayBookReport;
                 }
             }
             catch (Exception ex)
             {
                 _logException.Error(ex.Message);
                 throw;
             }
             finally
             {
                  //_sessionFromDate = null;
                  //_sessionUptoDate = null;
                  //_accountIdXml = null;
                  //_transactionTypeXml = null;
                  //_balanesheetMstIDXml = null;
                  //_accountSessionID = 0;
                  //_balanesheetMstID = 0;
                  //_modeCode = null;
                  //_pattern = null;
                  //_patternType = null;
             }
         }
         #endregion
    }
}