using AERP.Base.DTO;
using AERP.Common;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    class AccountChequeBookMasterBR : IAccountChequeBookMasterBR
    {
        public AccountChequeBookMasterBR() { }


        /// <summary>
        /// Validate method to insert record from account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertAccountChequeBookMasterValidate(AccountChequeBookMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertAccountChequeBookMaster(item))
                {
                    businessResponse.Passed = false;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }

        /// <summary>
        /// Validate method to update record from account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateAccountChequeBookMasterValidate(AccountChequeBookMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateUpdateAccountChequeBookMaster(item))
                {
                    businessResponse.Passed = false;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }

        /// <summary>
        /// Validate method to delete record from account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteAccountChequeBookMasterValidate(AccountChequeBookMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateDeleteAccountChequeBookMaster(item))
                {
                    businessResponse.Passed = false;
                    businessResponse.Message.Add(new MessageDTO
                    {
                        MessageType = MessageTypeEnum.Error,
                        ErrorMessage = "pass error message"
                    });
                }
                else
                {
                    businessResponse.Passed = true;
                }
            }
            catch (Exception ex)
            {
                businessResponse.Message.Add(new MessageDTO
                {
                    MessageType = MessageTypeEnum.Error,
                    ErrorMessage = ex.Message
                });
            }
            return businessResponse;
        }

        /// <summary>
        /// Validation on insert account cheque book master property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertAccountChequeBookMaster(AccountChequeBookMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// <summary>
        /// Validation on update account cheque book master property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateAccountChequeBookMaster(AccountChequeBookMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// <summary>
        /// Validation on dalete account cheque book master property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteAccountChequeBookMaster(AccountChequeBookMaster request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.ID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
