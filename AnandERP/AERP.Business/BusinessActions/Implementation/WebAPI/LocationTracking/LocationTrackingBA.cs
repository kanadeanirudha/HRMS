using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.DataProvider;
using AERP.Common;

namespace AERP.Business.BusinessAction
{
    public class LocationTrackingBA : ILocationTrackingBA
    {
        private ILogger _logException;
        private ILocationTrackingDataProvider _ILocationTrackingDataProvider;
        public LocationTrackingBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ILocationTrackingDataProvider = new LocationTrackingDataProvider();
        }
        public IBaseEntityCollectionResponse<LocationTracking> getCurrentLocation(LocationTracking item)
        {
            IBaseEntityCollectionResponse<LocationTracking> LocationTrackingCollection = new BaseEntityCollectionResponse<LocationTracking>();
            try
            {
                if (_ILocationTrackingDataProvider != null)
                    LocationTrackingCollection = _ILocationTrackingDataProvider.getCurrentLocation(item);
                else
                {
                    LocationTrackingCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LocationTrackingCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LocationTrackingCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LocationTrackingCollection;
        }

        public IBaseEntityResponse<LocationTracking> InsertLocations(LocationTracking item)
        {
            IBaseEntityResponse<LocationTracking> entityResponse = new BaseEntityResponse<LocationTracking>();
            try
            {
                entityResponse = _ILocationTrackingDataProvider.InsertLocations(item);
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
