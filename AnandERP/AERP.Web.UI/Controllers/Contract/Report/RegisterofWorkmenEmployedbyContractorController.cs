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
    public class RegisterofWorkmenEmployedbyContractorController : BaseController
    {
        #region ------------CONTROLLER CLASS VARIABLE------------
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IRegisterofWorkmenEmployedbyContractorBA _RegisterofWorkmenEmployedbyContractorBA = null;
        private readonly ILogger _logException;
        protected static string _centreCode = string.Empty;
        protected static string _centreName = string.Empty;
        protected static string _MonthYear = string.Empty;
        protected static string _MonthName = string.Empty;
        protected static int _SaleContractEmployeeMasterID = 0;
        protected static int _AccountSessionID = 0;

        #endregion

        #region ------------CONTROLLER CLASS CONSTRUCTOR------------
        public RegisterofWorkmenEmployedbyContractorController()
        {
            _RegisterofWorkmenEmployedbyContractorBA = new RegisterofWorkmenEmployedbyContractorBA();
        }
        #endregion

        #region ------------CONTROLLER ACTION METHODS------------
        public ActionResult Index()
        {
            bool IsApplied = CheckMenuApplicableOrNot(ControllerContext.RouteData.Values["Controller"].ToString());
            if (IsApplied == true)
            {
                RegisterofWorkmenEmployedbyContractorViewModel model = new RegisterofWorkmenEmployedbyContractorViewModel();

                return View("/Views/Contract/Report/RegisterofWorkmenEmployedbyContractor/Index.cshtml", model);
            }
            else
            {
                return RedirectToAction("UnauthorizedAccess", "Home");
            }
        }

        [HttpPost]
        public ActionResult Index(RegisterofWorkmenEmployedbyContractorViewModel model)
        {
            return View("/Views/Contract/Report/RegisterofWorkmenEmployedbyContractor/Index.cshtml", model);
        }

        #endregion

        #region ------------CONTROLLER NON ACTION METHODS------------



        public List<RegisterofWorkmenEmployedbyContractor> GetRegisterofWorkmenEmployedbyContractorList()
        {
            try
            {
                List<RegisterofWorkmenEmployedbyContractor> listRegisterofWorkmenEmployedbyContractor = new List<RegisterofWorkmenEmployedbyContractor>();
                RegisterofWorkmenEmployedbyContractorSearchRequest searchRequest = new RegisterofWorkmenEmployedbyContractorSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.CentreCode = _centreCode;
                if (_MonthYear != string.Empty)
                {
                    searchRequest.MonthYear = _MonthYear;
                    searchRequest.MonthName = Convert.ToString(_MonthName);
                    IBaseEntityCollectionResponse<RegisterofWorkmenEmployedbyContractor> baseEntityCollectionResponse = _RegisterofWorkmenEmployedbyContractorBA.GetRegisterofWorkmenEmployedbyContractorDataList(searchRequest);
                    if (baseEntityCollectionResponse != null)
                    {
                        if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                        {
                            listRegisterofWorkmenEmployedbyContractor = baseEntityCollectionResponse.CollectionResponse.ToList();
                        }
                    }
                }
                return listRegisterofWorkmenEmployedbyContractor;
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
