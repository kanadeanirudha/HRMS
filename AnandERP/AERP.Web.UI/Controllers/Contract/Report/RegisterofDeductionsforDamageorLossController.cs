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
    public class RegisterofDeductionsforDamageorLossController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRegisterofDeductionsforDamageorLossBA _RegisterofDeductionsforDamageorLossBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public RegisterofDeductionsforDamageorLossController()
        {
            _RegisterofDeductionsforDamageorLossBA = new RegisterofDeductionsforDamageorLossBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                RegisterofDeductionsforDamageorLossViewModel model = new RegisterofDeductionsforDamageorLossViewModel();

                return View("/Views/Contract/Report/RegisterofDeductionsforDamageorLoss/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(RegisterofDeductionsforDamageorLossViewModel model)
        {
            return View("/Views/Contract/Report/RegisterofDeductionsforDamageorLoss/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<RegisterofDeductionsforDamageorLoss> GetRegisterofDeductionsforDamageorLossList()
        {
            try
            {
                List<RegisterofDeductionsforDamageorLoss> listRegisterofDeductionsforDamageorLoss = new List<RegisterofDeductionsforDamageorLoss>();
                RegisterofDeductionsforDamageorLossSearchRequest searchRequest = new RegisterofDeductionsforDamageorLossSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<RegisterofDeductionsforDamageorLoss> baseEntityCollectionResponse = _RegisterofDeductionsforDamageorLossBA.GetRegisterofDeductionsforDamageorLossDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listRegisterofDeductionsforDamageorLoss = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listRegisterofDeductionsforDamageorLoss;
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
