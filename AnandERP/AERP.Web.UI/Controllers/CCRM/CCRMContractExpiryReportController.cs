using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using AERP.Common;
using AERP.DataProvider;
using AERP.Business.BusinessActions;

namespace AERP.Web.UI.Controllers
{
    public class CCRMContractExpiryReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMContractExpiryReportBA _CCRMContractExpiryReportBA = null;
        private readonly ILogger _logException;
        protected static int _vendorID;
        protected string _centreCode = string.Empty;
        private short _VendorID;
        public string _ReportFor { get; set; }
        protected static string _ReportForPage;
        //public string ListAllVendor { get; set; }

        #endregion
        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public CCRMContractExpiryReportController()
        {
            _CCRMContractExpiryReportBA = new CCRMContractExpiryReportBA();
        }
        #endregion
        #region ------------CONTROLLER ACTION METHODS------------
        // GET: CCRMContractExpiryReport
        public ActionResult Index()
        {
            CCRMContractExpiryReportViewModel model = new CCRMContractExpiryReportViewModel();
            return View("/Views/CCRM/Report/CCRMContractExpiryReport/Index.cshtml", model);
        }
        [HttpPost]
        public ActionResult Index(CCRMContractExpiryReportViewModel model)
        {
          
            return View("/Views/CCRM/Report/CCRMContractExpiryReport/Index.cshtml", model);
        }


        #endregion
        #region ------------CONTROLLER NON ACTION METHODS------------

        public List<CCRMContractExpiryReport> GetContractExpiryList(string ReportFor)
        {
            try
            {
                List<CCRMContractExpiryReport> listCCRMContractExpiryReport = new List<CCRMContractExpiryReport>();
                CCRMContractExpiryReportSearchRequest searchRequest = new CCRMContractExpiryReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
               // searchRequest.ReportFor = ReportFor;
                IBaseEntityCollectionResponse<CCRMContractExpiryReport> baseEntityCollectionResponse = _CCRMContractExpiryReportBA.GetCCRMContractExpiryReportBySearch_AllContractExpiry(searchRequest);
                if (baseEntityCollectionResponse != null)
                {
                    if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                    {
                        listCCRMContractExpiryReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                    }
                }
                return listCCRMContractExpiryReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion
        public string ReportFor { get; set; }



        public List<CCRMContractExpiryReport> ListAllContractExpiry { get; set; }
    }
}