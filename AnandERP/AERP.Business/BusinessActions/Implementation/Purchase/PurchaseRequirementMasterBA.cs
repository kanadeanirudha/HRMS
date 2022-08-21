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
	public class PurchaseRequirementMasterBA : IPurchaseRequirementMasterBA
	{
		IPurchaseRequirementMasterDataProvider _purchaseRequirementMasterDataProvider;
		IPurchaseRequirementMasterBR _purchaseRequirementMasterBR;
		private ILogger _logException;
		public PurchaseRequirementMasterBA()
		{
			_logException = new ExceptionManager.ExceptionManager(); //This need to change later
			_purchaseRequirementMasterBR = new PurchaseRequirementMasterBR();
			_purchaseRequirementMasterDataProvider = new PurchaseRequirementMasterDataProvider();
		}
		/// <summary>
		/// Create new record of PurchaseRequirementMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _purchaseRequirementMasterBR.InsertPurchaseRequirementMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _purchaseRequirementMasterDataProvider.InsertPurchaseRequirementMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Update a specific record  of PurchaseRequirementMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
        public IBaseEntityResponse<PurchaseRequirementMaster> InsertApprovedPurchaseRequirementRecord(PurchaseRequirementMaster item)
		{
			IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _purchaseRequirementMasterBR.InsertPurchaseRequirementMasterValidate(item);
				if (brResponse.Passed)
				{
                    entityResponse = _purchaseRequirementMasterDataProvider.InsertApprovedPurchaseRequirementRecord(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		public IBaseEntityResponse<PurchaseRequirementMaster> UpdatePurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _purchaseRequirementMasterBR.UpdatePurchaseRequirementMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _purchaseRequirementMasterDataProvider.UpdatePurchaseRequirementMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Delete a selected record from PurchaseRequirementMaster.
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<PurchaseRequirementMaster> DeletePurchaseRequirementMaster(PurchaseRequirementMaster item)
		{
			IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
			try
			{
				IValidateBusinessRuleResponse brResponse = _purchaseRequirementMasterBR.DeletePurchaseRequirementMasterValidate(item);
				if (brResponse.Passed)
				{
					entityResponse = _purchaseRequirementMasterDataProvider.DeletePurchaseRequirementMaster(item);
				}
				else
				{
					entityResponse.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					entityResponse.Entity = null;;
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
		/// Select all record from PurchaseRequirementMaster table with search parameters.
		/// <summary>
		/// <param name="searchRequest"></param>
		/// <returns></returns>
		public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetBySearch(PurchaseRequirementMasterSearchRequest searchRequest)
		{
			IBaseEntityCollectionResponse<PurchaseRequirementMaster> PurchaseRequirementMasterCollection = new BaseEntityCollectionResponse<PurchaseRequirementMaster>();
			try
			{
				if (_purchaseRequirementMasterDataProvider != null)
				PurchaseRequirementMasterCollection = _purchaseRequirementMasterDataProvider.GetPurchaseRequirementMasterBySearch(searchRequest);
				else
				{
					PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
					{
						ErrorMessage = Resources.Null_Object_Exception,
						MessageType = MessageTypeEnum.Error
					});
					PurchaseRequirementMasterCollection.CollectionResponse = null;
				}
			}
			catch (Exception ex)
			{
				PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
				{
					ErrorMessage = ex.Message,
					 MessageType = MessageTypeEnum.Error
				});
				PurchaseRequirementMasterCollection.CollectionResponse = null;
				if (_logException != null)
				{
					_logException.Error(ex.Message);
				}
			}
			return PurchaseRequirementMasterCollection;
		}
		/// <summary>
		/// Select a record from PurchaseRequirementMaster table by ID
		/// <summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public IBaseEntityResponse<PurchaseRequirementMaster> SelectByID(PurchaseRequirementMaster item)
		{
			IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
			try
			{
				 entityResponse = _purchaseRequirementMasterDataProvider.GetPurchaseRequirementMasterByID(item);
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

        public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterDetailList(PurchaseRequirementMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequirementMaster> PurchaseRequirementMasterCollection = new BaseEntityCollectionResponse<PurchaseRequirementMaster>();
            try
            {
                if (_purchaseRequirementMasterDataProvider != null)
                    PurchaseRequirementMasterCollection = _purchaseRequirementMasterDataProvider.GetPurchaseRequirementMasterDetailList(searchRequest);
                else
                {
                    PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequirementMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequirementMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequirementMasterCollection;
        }


        public IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMasterByExcel(PurchaseRequirementMaster item)
        {
            IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _purchaseRequirementMasterBR.InsertPurchaseRequirementMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _purchaseRequirementMasterDataProvider.InsertPurchaseRequirementMasterByExcel(item);
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

        public IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementForApproval(PurchaseRequirementMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequirementMaster> PurchaseRequirementMasterCollection = new BaseEntityCollectionResponse<PurchaseRequirementMaster>();
            try
            {
                if (_purchaseRequirementMasterDataProvider != null)
                    PurchaseRequirementMasterCollection = _purchaseRequirementMasterDataProvider.GetPurchaseRequirementForApproval(searchRequest);
                else
                {
                    PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequirementMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequirementMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequirementMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequirementMasterCollection;
        }

        public IBaseEntityResponse<PurchaseRequirementMaster> GetBlockForProcurementByLocationID(PurchaseRequirementMaster item)
        {
            IBaseEntityResponse<PurchaseRequirementMaster> entityResponse = new BaseEntityResponse<PurchaseRequirementMaster>();
            try
            {
                entityResponse = _purchaseRequirementMasterDataProvider.GetBlockForProcurementByLocationID(item);
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
