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
using AERP.Business.BusinessAction;
using System.Globalization;
namespace AERP.Web.UI.Controllers
{
    public class ContractPaymentPendingReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IContractPaymentPendingReportBA _ContractPaymentPendingReportBA = null;
        private readonly ILogger _logException;
        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public ContractPaymentPendingReportController()
        {
            _ContractPaymentPendingReportBA = new ContractPaymentPendingReportBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                ContractPaymentPendingReportViewModel model = new ContractPaymentPendingReportViewModel();

                return View("/Views/Contract/Report/ContractPaymentPendingReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(ContractPaymentPendingReportViewModel model)
        {
            return View("/Views/Contract/Report/ContractPaymentPendingReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<ContractPaymentPendingReport> GetContractPaymentPendingReportList()
        {
            try
            {
                List<ContractPaymentPendingReport> listContractPaymentPendingReport = new List<ContractPaymentPendingReport>();
                ContractPaymentPendingReportSearchRequest searchRequest = new ContractPaymentPendingReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                {
                    IBaseEntityCollectionResponse<ContractPaymentPendingReport> baseEntityCollectionResponse = _ContractPaymentPendingReportBA.GetContractPaymentPendingReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listContractPaymentPendingReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listContractPaymentPendingReport;
            }
            catch (Exception ex)
            {
                _logException.Error(ex.Message);
                throw;
            }
        }


        #endregion



    }
}
