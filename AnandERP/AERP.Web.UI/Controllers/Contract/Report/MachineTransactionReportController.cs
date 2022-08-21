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
namespace AERP.Web.UI.Controllers
{
    public class MachineTransactionReportController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISaleContractMachineMasterBA _SaleContractMachineMasterBA = null;
        IMachineTransactionReportBA _MachineTransactionReportBA = null;
        private readonly ILogger _logException;
        protected static string _MachineMasterName = string.Empty;
        protected static int _MachineMasterID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public MachineTransactionReportController()
        {
            _MachineTransactionReportBA = new MachineTransactionReportBA();
            _SaleContractMachineMasterBA = new SaleContractMachineMasterBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                MachineTransactionReportViewModel model = new MachineTransactionReportViewModel();
                
                return View("/Views/Contract/Report/MachineTransactionReport/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(MachineTransactionReportViewModel model)
        {
            
            if (model.IsPosted == true)
            {
                _MachineMasterName = model.MachineMasterName;
                _MachineMasterID = model.MachineMasterID;
                model.IsPosted = false;
            }
            else
            {
                model.MachineMasterName = _MachineMasterName;
                model.MachineMasterID = _MachineMasterID;
            }

            return View("/Views/Contract/Report/MachineTransactionReport/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------

        [HttpPost]
        public JsonResult GetMachineMasterSearchList(string term)
        {
            SaleContractMachineMasterSearchRequest searchRequest = new SaleContractMachineMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            searchRequest.SearchWord = term;
            List<SaleContractMachineMaster> listFeeSubType = new List<SaleContractMachineMaster>();
            IBaseEntityCollectionResponse<SaleContractMachineMaster> baseEntityCollectionResponse = _SaleContractMachineMasterBA.GetMachineMasterBySearchWordAll(searchRequest);
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
                              MachineMasterID = r.ID,
                              MachineMasterName = r.Name,
                              MachineMasterSerialNumber = r.SerialNumber
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<MachineTransactionReport> GetMachineTransactionReportList()
        {
            try
            {
                List<MachineTransactionReport> listMachineTransactionReport = new List<MachineTransactionReport>();
                MachineTransactionReportSearchRequest searchRequest = new MachineTransactionReportSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

                if (_MachineMasterID != 0)
                {
                    searchRequest.MachineMasterID = _MachineMasterID;
                    searchRequest.MachineMasterName = _MachineMasterName;
                    IBaseEntityCollectionResponse<MachineTransactionReport> baseEntityCollectionResponse = _MachineTransactionReportBA.GetMachineTransactionReportDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listMachineTransactionReport = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listMachineTransactionReport;
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
