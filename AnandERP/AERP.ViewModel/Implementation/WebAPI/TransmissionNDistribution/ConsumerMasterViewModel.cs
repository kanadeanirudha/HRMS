using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.ViewModel
{
    public class ConsumerMasterViewModel
    {
        public ConsumerMasterViewModel()
        {
            ConsumerMasterDTO = new ConsumerMaster();
        }

        public ConsumerMaster ConsumerMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.ID > 0) ? ConsumerMasterDTO.ID : new int();
            }
            set
            {
                ConsumerMasterDTO.ID = value;
            }
        }

        public int StayLine
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.StayLine > 0) ? ConsumerMasterDTO.StayLine : new int();
            }
            set
            {
                ConsumerMasterDTO.StayLine = value;
            }
        }

        public int EngineerID
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.EngineerID > 0) ? ConsumerMasterDTO.EngineerID : new int();
            }
            set
            {
                ConsumerMasterDTO.EngineerID = value;
            }
        }

        public long ConsumerNumber
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.ConsumerNumber > 0) ? ConsumerMasterDTO.ConsumerNumber : new long();
            }
            set
            {
                ConsumerMasterDTO.ConsumerNumber = value;
            }
        }

        public string ConsumerName
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ConsumerName : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.ConsumerName = value;
            }
        }

        public string AdharCardNumber
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.AdharCardNumber : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.AdharCardNumber = value;
            }
        }

        public string SourceName
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.SourceName : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.SourceName = value;
            }
        }

        public string DestinationName
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.DestinationName : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.DestinationName = value;
            }
        }
        public string Address
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Address : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.Address = value;
            }
        }

        public int CityID
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.CityID > 0) ? ConsumerMasterDTO.CityID : new int();
            }
            set
            {
                ConsumerMasterDTO.CityID = value;
            }
        }

        public int SectionID
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.SectionID > 0) ? ConsumerMasterDTO.SectionID : new int();
            }
            set
            {
                ConsumerMasterDTO.SectionID = value;
            }
        }

        public int Phase
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.Phase > 0) ? ConsumerMasterDTO.Phase : new int();
            }
            set
            {
                ConsumerMasterDTO.Phase = value;
            }
        }
        
        public decimal Latitude
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Latitude : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.Latitude = value;
            }
        }

        public decimal Longitude
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Longitude : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.Longitude = value;
            }
        }

        public decimal Latitude_TappingPoint 
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Latitude : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.Latitude = value;
            }
        }

        public decimal Longitude_TappingPoint
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Longitude : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.Longitude = value;
            }
        }

        


        public string MobileNumber
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.MobileNumber : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.MobileNumber = value;
            }
        }

        public string Reason
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Reason : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.Reason = value;
            }
        }

        public decimal ActualSurvey_In_Meters
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ActualSurvey_In_Meters : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.ActualSurvey_In_Meters = value;
            }
        }

        public string DTCNumber
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.DTCNumber : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.DTCNumber = value;
            }
        }

        public string Remark
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Remark : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.Remark = value;
            }
        }

        public string City
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.City : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.City = value;
            }
        }

        public string Section
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Section : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.Section = value;
            }
        }

        public bool isCommunicateWithFarmer
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.isCommunicateWithFarmer : false;
            }
            set
            {
                ConsumerMasterDTO.isCommunicateWithFarmer = value;
            }
        }

        public string FarmerCommunication
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.FarmerCommunication : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.FarmerCommunication = value;
            }
        }

        public string PresentCrop
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.PresentCrop : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.PresentCrop = value;
            }
        }

        public string FutureCrop
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.FutureCrop : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.FutureCrop = value;
            }
        }

        public DateTime? PresentCropCuttingDate
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.PresentCropCuttingDate.HasValue) ? ConsumerMasterDTO.PresentCropCuttingDate : null;
            }
            set
            {
                ConsumerMasterDTO.PresentCropCuttingDate = value;
            }
        }

        public DateTime? FutureCropPlantationDate
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.FutureCropPlantationDate.HasValue) ? ConsumerMasterDTO.FutureCropPlantationDate : null;
            }
            set
            {
                ConsumerMasterDTO.FutureCropPlantationDate = value;
            }
        }


        [Display(Name = "Is Deleted")]
        public bool IsDeleted
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.IsDeleted : false;
            }
            set
            {
                ConsumerMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.CreatedBy > 0) ? ConsumerMasterDTO.CreatedBy : new int();
            }
            set
            {
                ConsumerMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                ConsumerMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.ModifiedBy > 0) ? ConsumerMasterDTO.ModifiedBy : new int();
            }
            set
            {
                ConsumerMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.ModifiedDate.HasValue) ? ConsumerMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                ConsumerMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.DeletedBy > 0) ? ConsumerMasterDTO.DeletedBy : new int();
            }
            set
            {
                ConsumerMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.DeletedDate.HasValue) ? ConsumerMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                ConsumerMasterDTO.DeletedDate = value;
            }
        }

        public string VersionNumber
        {

            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.VersionNumber = value;
            }
        }
        public DateTime? LastSyncDate
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.LastSyncDate.HasValue) ? ConsumerMasterDTO.LastSyncDate : null;
            }
            set
            {
                ConsumerMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.SyncType : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.Entity : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.Entity = value;
            }
        }


        //ConsumerRequirement
        public string ConsumersGroup
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ConsumersGroup : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.ConsumersGroup = value;
            }
        }

        public decimal ActualSurvey_In_KMeters
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ActualSurvey_In_KMeters : new Decimal();
            }
            set
            {
                ConsumerMasterDTO.ActualSurvey_In_KMeters = value;
            }
        }

        public bool ServiceConnection
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ServiceConnection : false;
            }
            set
            {
                ConsumerMasterDTO.ServiceConnection = value;
            }
        }

        public bool ExtensionOfServiceConnection
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.ExtensionOfServiceConnection : false;
            }
            set
            {
                ConsumerMasterDTO.ExtensionOfServiceConnection = value;
            }
        }

        public string TappingLocationDetails
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.TappingLocationDetails : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.TappingLocationDetails = value;
            }
        }

        public int No_Of_Poles
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.No_Of_Poles > 0) ? ConsumerMasterDTO.No_Of_Poles : new int();
            }
            set
            {
                ConsumerMasterDTO.No_Of_Poles = value;
            }
        }
        public int No_Of_CutPoints
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.No_Of_CutPoints > 0) ? ConsumerMasterDTO.No_Of_CutPoints : new int();
            }
            set
            {
                ConsumerMasterDTO.No_Of_CutPoints = value;
            }
        }
        public int TappingFrom_ActivityID
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.TappingFrom_ActivityID > 0) ? ConsumerMasterDTO.TappingFrom_ActivityID : new int();
            }
            set
            {
                ConsumerMasterDTO.TappingFrom_ActivityID = value;
            }
        }
        public int GaurdingSpanNeeded
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.GaurdingSpanNeeded > 0) ? ConsumerMasterDTO.GaurdingSpanNeeded : new int();
            }
            set
            {
                ConsumerMasterDTO.GaurdingSpanNeeded = value;
            }
        }

        public String GaurdingNeeded
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.GaurdingNeeded : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.GaurdingNeeded = value;
            }
        }

        public String OtherIssues
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.OtherIssues : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.OtherIssues = value;
            }
        }

        public String TappingMaterials
        {
            get
            {
                return (ConsumerMasterDTO != null) ? ConsumerMasterDTO.TappingMaterials : string.Empty;
            }
            set
            {
                ConsumerMasterDTO.TappingMaterials = value;
            }
        }

        public int Source
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.Source > 0) ? ConsumerMasterDTO.Source : new int();
            }
            set
            {
                ConsumerMasterDTO.ID = value;
            }
        }

        public int Destination
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.Destination > 0) ? ConsumerMasterDTO.Destination : new int();
            }
            set
            {
                ConsumerMasterDTO.Destination = value;
            }
        }

        public double Distance
        {
            get
            {
                return (ConsumerMasterDTO != null && ConsumerMasterDTO.Distance > 0) ? ConsumerMasterDTO.Distance : new double();
            }
            set
            {
                ConsumerMasterDTO.Distance = value;
            }
        }
    }
}
