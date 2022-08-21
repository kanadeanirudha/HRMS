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
namespace AERP.Business.BusinessActions
{
    public class LeaveDeductRuleExceptionForCentreBA : ILeaveDeductRuleExceptionForCentreBA
    {
        ILeaveDeductRuleExceptionForCentreDataProvider _LeaveDeductRuleExceptionForCentreDataProvider;
        ILeaveDeductRuleExceptionForCentreBR _LeaveDeductRuleExceptionForCentreBR;
        private ILogger _logException;

        public LeaveDeductRuleExceptionForCentreBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _LeaveDeductRuleExceptionForCentreBR = new LeaveDeductRuleExceptionForCentreBR();
            _LeaveDeductRuleExceptionForCentreDataProvider = new LeaveDeductRuleExceptionForCentreDataProvider();
        }

        /// <summary>
        /// Create new record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> InsertLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> entityResponse = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeaveDeductRuleExceptionForCentreBR.InsertLeaveDeductRuleExceptionForCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeaveDeductRuleExceptionForCentreDataProvider.InsertLeaveDeductRuleExceptionForCentre(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// <summary>
        /// Update a specific record of LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> UpdateLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> entityResponse = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeaveDeductRuleExceptionForCentreBR.UpdateLeaveDeductRuleExceptionForCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeaveDeductRuleExceptionForCentreDataProvider.UpdateLeaveDeductRuleExceptionForCentre(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// <summary>
        /// Delete a selected record from LeaveDeductRuleExceptionForCentre.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> DeleteLeaveDeductRuleExceptionForCentre(LeaveDeductRuleExceptionForCentre item)
        {
            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> entityResponse = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _LeaveDeductRuleExceptionForCentreBR.DeleteLeaveDeductRuleExceptionForCentreValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _LeaveDeductRuleExceptionForCentreDataProvider.DeleteLeaveDeductRuleExceptionForCentre(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }

        /// <summary>
        /// Select all record from LeaveDeductRuleExceptionForCentre table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearch(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> categoryMasterCollection = new BaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                if (_LeaveDeductRuleExceptionForCentreDataProvider != null)
                {
                    categoryMasterCollection = _LeaveDeductRuleExceptionForCentreDataProvider.GetLeaveDeductRuleExceptionForCentreBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from LeaveDeductRuleExceptionForCentre table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> GetBySearchList(LeaveDeductRuleExceptionForCentreSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre> categoryMasterCollection = new BaseEntityCollectionResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                if (_LeaveDeductRuleExceptionForCentreDataProvider != null)
                {
                    categoryMasterCollection = _LeaveDeductRuleExceptionForCentreDataProvider.GetLeaveDeductRuleExceptionForCentreGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from LeaveDeductRuleExceptionForCentre table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> SelectByID(LeaveDeductRuleExceptionForCentre item)
        {

            IBaseEntityResponse<LeaveDeductRuleExceptionForCentre> entityResponse = new BaseEntityResponse<LeaveDeductRuleExceptionForCentre>();
            try
            {
                entityResponse = _LeaveDeductRuleExceptionForCentreDataProvider.GetLeaveDeductRuleExceptionForCentreByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                entityResponse.Entity = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}