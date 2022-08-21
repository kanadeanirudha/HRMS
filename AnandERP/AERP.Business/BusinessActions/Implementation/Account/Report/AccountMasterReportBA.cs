using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public class AccountMasterReportBA: IAccountMasterReportBA
    {
        IAccountMasterReportDataProvider _accountMasterDataProvider;
      
        private ILogger _logException;

        public AccountMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _accountMasterDataProvider = new AccountMasterReportDataProvider();
        }

        /// <summary>
        /// Select all record from Account Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountMasterReport> GetBySearch(AccountMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountMasterReport> AccBalsheetMasterCollection = new BaseEntityCollectionResponse<AccountMasterReport>();
            try
            {
                if (_accountMasterDataProvider != null)
                {
                    AccBalsheetMasterCollection = _accountMasterDataProvider.GetAccountMasterBySearch(searchRequest);
                }
                else
                {
                    AccBalsheetMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccBalsheetMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccBalsheetMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccBalsheetMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccBalsheetMasterCollection;
        }
     }

   

}
