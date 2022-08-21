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
    class SaleContractEmployeeMasterBR : ISaleContractEmployeeMasterBR
    {
        public SaleContractEmployeeMasterBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertSaleContractEmployeeMaster(item))
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
        /// Validate method to update record from SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateUpdateSaleContractEmployeeMaster(item))
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
        /// Validate method to delete record from SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteSaleContractEmployeeMasterValidate(SaleContractEmployeeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateDeleteSaleContractEmployeeMaster(item))
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
        /// Validation on insert SaleContractEmployeeMaster property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertSaleContractEmployeeMaster(SaleContractEmployeeMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// <summary>
        /// Validation on update SaleContractEmployeeMaster property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateSaleContractEmployeeMaster(SaleContractEmployeeMaster request)
        {
            //We need to Implment this validation method properly
            return (request.ID > 0);
        }

        /// <summary>
        /// Validation on dalete SaleContractEmployeeMaster property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteSaleContractEmployeeMaster(SaleContractEmployeeMaster request)
        {
            try
            {
                return (request.ID > 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IValidateBusinessRuleResponse InsertSaleContractEmployeeMasterExcelUploadValidate(SaleContractEmployeeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertSaleContractEmployeeMaster(item))
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

    }
}





