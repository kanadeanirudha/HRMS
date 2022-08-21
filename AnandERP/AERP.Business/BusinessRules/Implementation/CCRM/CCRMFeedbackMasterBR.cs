using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.Common;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
    class CCRMFeedbackMasterBR : ICCRMFeedbackMasterBR
    {
        public CCRMFeedbackMasterBR()
        {
        }

        /// <summary>
        /// Validate method to insert record from General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IValidateBusinessRuleResponse InsertCCRMFeedbackMasterValidate(CCRMFeedbackMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertCCRMFeedbackMaster(item))
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
        /// Validate method to update record from General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateCCRMFeedbackMasterValidate(CCRMFeedbackMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateUpdateCCRMFeedbackMaster(item))
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
        /// Validate method to delete record from General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteCCRMFeedbackMasterValidate(CCRMFeedbackMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateDeleteCCRMFeedbackMaster(item))
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
        /// Validation on insert General City Master property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertCCRMFeedbackMaster(CCRMFeedbackMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        private bool ValidateUpdateCCRMFeedbackMaster(CCRMFeedbackMaster request)
        {
            //We need to Implment this validation method properly
            return (request.ID > 0);
        }

        /// <summary>
        /// Validation on dalete General City Master property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteCCRMFeedbackMaster(CCRMFeedbackMaster request)
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
    }
}
