
using System;
using System.Collections.Generic;
using AMS.Base.DTO;
using AMS.Common;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AMS.Business.BusinessRules.Interface.OnlineExam;

namespace AMS.Business.BusinessRules
{
    public class ECommerceSystemSettingsBR : IECommerceSystemSettingsBR
    {
        public ECommerceSystemSettingsBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from ECommerceSystemSettings.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertECommerceSystemSettingsValidate(ECommerceSystemSettings item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertECommerceSystemSettings(item))
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
        //
     
       
        /// <summary>
        /// Validation on insert ECommerceSystemSettingsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        
        /// <summary>
        /// Validation on insert ECommerceSystemSettingsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertECommerceSystemSettings(ECommerceSystemSettings request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update ECommerceSystemSettingsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateECommerceSystemSettings(ECommerceSystemSettings request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete ECommerceSystemSettingsproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteECommerceSystemSettings(ECommerceSystemSettings request)
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

