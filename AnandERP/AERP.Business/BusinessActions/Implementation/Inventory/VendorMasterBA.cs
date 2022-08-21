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
    public class VendorMasterBA : IVendorMasterBA
    {
        IVendorMasterDataProvider _VendorMasterDataProvider;
        IVendorMasterBR _VendorMasterBR;
        private ILogger _logException;
        public VendorMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _VendorMasterBR = new VendorMasterBR();
            _VendorMasterDataProvider = new VendorMasterDataProvider();
        }
        /// <summary>
        /// Create new record of VendorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> InsertVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _VendorMasterBR.InsertVendorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _VendorMasterDataProvider.InsertVendorMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Update a specific record  of VendorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> UpdateVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _VendorMasterBR.UpdateVendorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _VendorMasterDataProvider.UpdateVendorMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Delete a selected record from VendorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> DeleteVendorMaster(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _VendorMasterBR.DeleteVendorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _VendorMasterDataProvider.DeleteVendorMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Select all record from VendorMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<VendorMaster> GetBySearch(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> VendorMasterCollection = new BaseEntityCollectionResponse<VendorMaster>();
            try
            {
                if (_VendorMasterDataProvider != null)
                    VendorMasterCollection = _VendorMasterDataProvider.GetVendorMasterBySearch(searchRequest);
                else
                {
                    VendorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterCollection;
        }

       


        public IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterSearchList(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> VendorMasterCollection = new BaseEntityCollectionResponse<VendorMaster>();
            try
            {
                if (_VendorMasterDataProvider != null)
                    VendorMasterCollection = _VendorMasterDataProvider.GetVendorMasterSearchList(searchRequest);
                else
                {
                    VendorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterCollection;
        }
        /// <summary>
        /// Select a record from VendorMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<VendorMaster> SelectByID(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                entityResponse = _VendorMasterDataProvider.GetVendorMasterByID(item);
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
        public IBaseEntityResponse<VendorMaster> GetLeadTimeByVendorID(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                entityResponse = _VendorMasterDataProvider.GetLeadTimeByVendorID(item);
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
        //public IBaseEntityResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMaster item)
        //{
        //    IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
        //    try
        //    {
        //        entityResponse = _VendorMasterDataProvider.GetReplenishmentDataByVendorNumber(item);
        //    }
        //    catch (Exception ex)
        //    {
        //        entityResponse.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        entityResponse.Entity = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return entityResponse;
        //}
        public IBaseEntityResponse<VendorMaster> GetGeneralDataByVendorNumber(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                entityResponse = _VendorMasterDataProvider.GetGeneralDataByVendorNumber(item);
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

        public IBaseEntityResponse<VendorMaster> GetFinanceDataByVendorNumber(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                entityResponse = _VendorMasterDataProvider.GetFinanceDataByVendorNumber(item);
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

        public IBaseEntityResponse<VendorMaster> InsertVendorMasterExcel(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _VendorMasterBR.InsertVendorMasterExcelValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _VendorMasterDataProvider.InsertVendorMasterExcel(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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

        public IBaseEntityCollectionResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> VendorMasterCollection = new BaseEntityCollectionResponse<VendorMaster>();
            try
            {
                if (_VendorMasterDataProvider != null)
                    VendorMasterCollection = _VendorMasterDataProvider.GetReplenishmentDataByVendorNumber(searchRequest);
                else
                {
                    VendorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterCollection;
        }

        public IBaseEntityCollectionResponse<VendorMaster> GetContactPersonDetailsForVendorMaster(VendorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<VendorMaster> VendorMasterCollection = new BaseEntityCollectionResponse<VendorMaster>();
            try
            {
                if (_VendorMasterDataProvider != null)
                    VendorMasterCollection = _VendorMasterDataProvider.GetContactPersonDetailsForVendorMaster(searchRequest);
                else
                {
                    VendorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    VendorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                VendorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                VendorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return VendorMasterCollection;
        }

        public IBaseEntityResponse<VendorMaster> GetDataValidationListsForExcel(VendorMaster item)
        {
            IBaseEntityResponse<VendorMaster> entityResponse = new BaseEntityResponse<VendorMaster>();
            try
            {
                //IValidateBusinessRuleResponse brResponse = _VendorMasterBR.InsertVendorMasterExcelValidate(item);
                if (_VendorMasterDataProvider != null)
                {
                    entityResponse = _VendorMasterDataProvider.GetDataValidationListsForExcel(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
    
    }
}
