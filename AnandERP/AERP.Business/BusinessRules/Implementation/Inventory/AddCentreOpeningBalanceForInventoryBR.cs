using System;
using System.Collections.Generic;
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
    public class AddCentreOpeningBalanceForInventoryBR : IAddCentreOpeningBalanceForInventoryBR
    {
        public AddCentreOpeningBalanceForInventoryBR()
        {
        }

        /// Validate method to insert record from AddCentreOpeningBalanceForInventory.
        public IValidateBusinessRuleResponse InsertAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertAddCentreOpeningBalanceForInventory(item))
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

        /// Validate method to update record from AddCentreOpeningBalanceForInventory.
        public IValidateBusinessRuleResponse UpdateAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateAddCentreOpeningBalanceForInventory(item))
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

        /// Validate method to delete record from AddCentreOpeningBalanceForInventory.
        public IValidateBusinessRuleResponse DeleteAddCentreOpeningBalanceForInventoryValidate(AddCentreOpeningBalanceForInventory item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteAddCentreOpeningBalanceForInventory(item))
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

        /// Validation on insert AddCentreOpeningBalanceForInventory.
        private bool ValidateInsertAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on update AddCentreOpeningBalanceForInventory.
        private bool ValidateUpdateAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// Validation on delete AddCentreOpeningBalanceForInventory.
        private bool ValidateDeleteAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory request)
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
