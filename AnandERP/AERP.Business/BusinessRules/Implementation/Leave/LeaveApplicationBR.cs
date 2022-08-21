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
    public class LeaveApplicationBR : ILeaveApplicationBR
    {
        public LeaveApplicationBR()
        {
        }
        /// <summary>
        /// Validate method to insert record from LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse InsertLeaveApplicationValidate(LeaveApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateInsertLeaveApplication(item))
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
        /// Validate method to update record from LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse UpdateLeaveApplicationValidate(LeaveApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateUpdateLeaveApplication(item))
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
        /// Validate method to delete record from LeaveApplication.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IValidateBusinessRuleResponse DeleteLeaveApplicationValidate(LeaveApplication item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }
                if (!ValidateDeleteLeaveApplication(item))
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
        /// Validation on insert LeaveApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateInsertLeaveApplication(LeaveApplication request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on update LeaveApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateLeaveApplication(LeaveApplication request)
        {
            //We need to Implment this validation method properly
            return true;
        }
        /// <summary>
        /// Validation on delete LeaveApplicationproperty.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteLeaveApplication(LeaveApplication request)
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

        //--------------- LeaveApplicationCancel ---------------------
      
        //public IValidateBusinessRuleResponse InsertLeaveApplicationCancel(LeaveApplication item)
        //{
        //    IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
        //    try
        //    {
        //        //Check null exception
        //        if (item == null)
        //        {
        //            throw new ArgumentNullException(Resources.InvalidArgumentsError);
        //        }
        //        if (!ValidateInsertLeaveCancelApplication(item))
        //        {
        //            businessResponse.Passed = false;
        //            businessResponse.Message.Add(new MessageDTO
        //            {
        //                MessageType = MessageTypeEnum.Error,
        //                ErrorMessage = "pass error message"
        //            });
        //        }
        //        else
        //        {
        //            businessResponse.Passed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        businessResponse.Message.Add(new MessageDTO
        //        {
        //            MessageType = MessageTypeEnum.Error,
        //            ErrorMessage = ex.Message
        //        });
        //    }
        //    return businessResponse;
        //}
        ///// <summary>
        ///// Validate method to update record from LeaveApplication.
        ///// <summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IValidateBusinessRuleResponse UpdateLeaveApplicationCancel(LeaveApplication item)
        //{
        //    IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
        //    try
        //    {
        //        //Check null exception
        //        if (item == null)
        //        {
        //            throw new ArgumentNullException(Resources.InvalidArgumentsError);
        //        }
        //        if (!ValidateUpdateLeaveCancelApplication(item))
        //        {
        //            businessResponse.Passed = false;
        //            businessResponse.Message.Add(new MessageDTO
        //            {
        //                MessageType = MessageTypeEnum.Error,
        //                ErrorMessage = "pass error message"
        //            });
        //        }
        //        else
        //        {
        //            businessResponse.Passed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        businessResponse.Message.Add(new MessageDTO
        //        {
        //            MessageType = MessageTypeEnum.Error,
        //            ErrorMessage = ex.Message
        //        });
        //    }
        //    return businessResponse;
        //}
        ///// <summary>
        ///// Validate method to delete record from LeaveApplication.
        ///// <summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //public IValidateBusinessRuleResponse DeleteLeaveApplicationCancel(LeaveApplication item)
        //{
        //    IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
        //    try
        //    {
        //        //Check null exception
        //        if (item == null)
        //        {
        //            throw new ArgumentNullException(Resources.InvalidArgumentsError);
        //        }
        //        if (!ValidateDeleteLeaveCancelApplication(item))
        //        {
        //            businessResponse.Passed = false;
        //            businessResponse.Message.Add(new MessageDTO
        //            {
        //                MessageType = MessageTypeEnum.Error,
        //                ErrorMessage = "pass error message"
        //            });
        //        }
        //        else
        //        {
        //            businessResponse.Passed = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        businessResponse.Message.Add(new MessageDTO
        //        {
        //            MessageType = MessageTypeEnum.Error,
        //            ErrorMessage = ex.Message
        //        });
        //    }
        //    return businessResponse;
        //}
        ///// <summary>
        ///// Validation on insert LeaveApplicationproperty.
        ///// <summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //private bool ValidateInsertLeaveCancelApplication(LeaveApplication request)
        //{
        //    //We need to Implment this validation method properly
        //    return true;
        //}
        ///// <summary>
        ///// Validation on update LeaveApplicationproperty.
        ///// <summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //private bool ValidateUpdateLeaveCancelApplication(LeaveApplication request)
        //{
        //    //We need to Implment this validation method properly
        //    return true;
        //}
        ///// <summary>
        ///// Validation on delete LeaveApplicationproperty.
        ///// <summary>
        ///// <param name="item"></param>
        ///// <returns></returns>
        //private bool ValidateDeleteLeaveCancelApplication(LeaveApplication request)
        //{
        //    try
        //    {
        //        return (!string.IsNullOrEmpty(Convert.ToString(request.ID)));
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
    }
}
