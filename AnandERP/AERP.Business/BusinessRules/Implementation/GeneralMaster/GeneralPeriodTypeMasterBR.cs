using AMS.Base.DTO;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public class GeneralPeriodTypeMasterBR : IGeneralPeriodTypeMasterBR
    {
        public GeneralPeriodTypeMasterBR()
        {
        }

        /// Validate method to insert record from GeneralPeriodTypeMaster.
        public IValidateBusinessRuleResponse InsertGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertGeneralPeriodTypeMaster(item))
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

        /// Validate method to update record from GeneralPeriodTypeMaster.
        public IValidateBusinessRuleResponse UpdateGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateGeneralPeriodTypeMaster(item))
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

        /// Validate method to delete record from GeneralPeriodTypeMaster.

        public IValidateBusinessRuleResponse DeleteGeneralPeriodTypeMasterValidate(GeneralPeriodTypeMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteGeneralPeriodTypeMaster(item))
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

        /// Validation on insert GeneralPeriodTypeMaster.
        private bool ValidateInsertGeneralPeriodTypeMaster(GeneralPeriodTypeMaster request)
        {
            //We need to Implment this validation method properly
            return false;
        }

        /// Validation on update GeneralPeriodTypeMaster.
        private bool ValidateUpdateGeneralPeriodTypeMaster(GeneralPeriodTypeMaster request)
        {
            //We need to Implment this validation method properly
            return false;
        }

        /// Validation on delete GeneralPeriodTypeMaster.
        private bool ValidateDeleteGeneralPeriodTypeMaster(GeneralPeriodTypeMaster request)
        {
            try
            {
                return (!string.IsNullOrEmpty(Convert.ToString(request.GeneralPeriodTypeMasterID)));
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
