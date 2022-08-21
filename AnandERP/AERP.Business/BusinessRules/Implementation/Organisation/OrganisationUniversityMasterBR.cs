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
    public class OrganisationUniversityMasterBR : IOrganisationUniversityMasterBR
    {
           public OrganisationUniversityMasterBR()
        {
        }
           /// <summary>
           /// Validate method to insert record from OrganisationUniversityMaster.
           /// </summary>
           /// <param name="item"></param>
           /// <returns></returns>
           public IValidateBusinessRuleResponse InsertOrganisationUniversityMasterValidate(OrganisationUniversityMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateInsertOrganisationUniversityMaster(item))
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
           /// Validate method to update record from OrganisationUniversityMaster.
           /// </summary>
           /// <param name="item"></param>
           /// <returns></returns>
           public IValidateBusinessRuleResponse UpdateOrganisationUniversityMasterValidate(OrganisationUniversityMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateUpdateOrganisationUniversityMaster(item))
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
           /// Validate method to delete record from OrganisationUniversityMaster.
           /// </summary>
           /// <param name="item"></param>
           /// <returns></returns>
           public IValidateBusinessRuleResponse DeleteOrganisationUniversityMasterValidate(OrganisationUniversityMaster item)
        {
            IValidateBusinessRuleResponse businessResponse = new ValidateBusinessRuleResponse();
            try
            {
                //Check null exception
                if (item == null)
                {
                    throw new ArgumentNullException(Resources.InvalidArgumentsError);
                }

                if (!ValidateDeleteOrganisationUniversityMaster(item))
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
           /// Validation on insert OrganisationUniversityMaster property.
           /// </summary>
           /// <param name="item"></param>
           /// <returns></returns>
        private bool ValidateInsertOrganisationUniversityMaster(OrganisationUniversityMaster request)
        {
            //We need to Implment this validation method properly
            return true;
        }

        /// <summary>
        /// Validation on update OrganisationUniversityMaster property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateUpdateOrganisationUniversityMaster(OrganisationUniversityMaster request)
        {
            //We need to Implment this validation method properly
            return (request.ID > 0);
        }

        /// <summary>
        /// Validation on dalete OrganisationUniversityMaster property.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool ValidateDeleteOrganisationUniversityMaster(OrganisationUniversityMaster request)
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
