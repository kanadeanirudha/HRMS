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
    public class PurchaseReturnBA : IPurchaseReturnBA
    {
        IPurchaseReturnDataProvider _PurchaseReturnDataProvider;
        IPurchaseReturnBR _PurchaseReturnBR;
        private ILogger _logException;
        public PurchaseReturnBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseReturnBR = new PurchaseReturnBR();
            _PurchaseReturnDataProvider = new PurchaseReturnDataProvider();
        }
        /// <summary>
        /// Create new record of PurchaseReturn.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> InsertPurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> entityResponse = new BaseEntityResponse<PurchaseReturn>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReturnBR.InsertPurchaseReturnValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReturnDataProvider.InsertPurchaseReturn(item);
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
        /// Update a specific record  of PurchaseReturn.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> UpdatePurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> entityResponse = new BaseEntityResponse<PurchaseReturn>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReturnBR.UpdatePurchaseReturnValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReturnDataProvider.UpdatePurchaseReturn(item);
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
        /// Delete a selected record from PurchaseReturn.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReturn> DeletePurchaseReturn(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> entityResponse = new BaseEntityResponse<PurchaseReturn>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReturnBR.DeletePurchaseReturnValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReturnDataProvider.DeletePurchaseReturn(item);
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
        /// Select all record from PurchaseReturn table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseReturn> GetBySearch(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> PurchaseReturnCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
            try
            {
                if (_PurchaseReturnDataProvider != null)
                    PurchaseReturnCollection = _PurchaseReturnDataProvider.GetBySearch(searchRequest);
                else
                {
                    PurchaseReturnCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReturnCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReturnCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReturnCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReturnCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReturn> GetPurchaseReturnDetailLists(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> PurchaseReturnCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
            try
            {
                if (_PurchaseReturnDataProvider != null)
                    PurchaseReturnCollection = _PurchaseReturnDataProvider.GetPurchaseReturnDetailLists(searchRequest);
                else
                {
                    PurchaseReturnCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReturnCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReturnCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReturnCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReturnCollection;
        }


        public IBaseEntityResponse<PurchaseReturn> SelectByID(PurchaseReturn item)
        {
            IBaseEntityResponse<PurchaseReturn> entityResponse = new BaseEntityResponse<PurchaseReturn>();
            try
            {
                entityResponse = _PurchaseReturnDataProvider.SelectByID(item);
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

        public IBaseEntityCollectionResponse<PurchaseReturn> GetVendorSearchList(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> PurchaseReturnCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
            try
            {
                if (_PurchaseReturnDataProvider != null)
                    PurchaseReturnCollection = _PurchaseReturnDataProvider.GetVendorSearchList(searchRequest);
                else
                {
                    PurchaseReturnCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReturnCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReturnCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReturnCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReturnCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseReturn> GetUomWisePurchasePrice(PurchaseReturnSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReturn> PurchaseReturnCollection = new BaseEntityCollectionResponse<PurchaseReturn>();
            try
            {
                if (_PurchaseReturnDataProvider != null)
                    PurchaseReturnCollection = _PurchaseReturnDataProvider.GetUomWisePurchasePrice(searchRequest);
                else
                {
                    PurchaseReturnCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReturnCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReturnCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReturnCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReturnCollection;
        }

    }
}

