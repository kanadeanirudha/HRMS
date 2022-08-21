using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{
    public class ConsumerMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }

        public int EngineerID
        {
            get;
            set;
        }

        public int StayLine
        {
            get;
            set;
        }

        public long ConsumerNumber
        {
            get;
            set;
        }

        public string ConsumerName
        {
            get;
            set;
        }

        public string SourceName
        {
            get;
            set;
        }

        public string DestinationName
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public int CityID
        {
            get;
            set;
        }

        public int SectionID
        {
            get;
            set;
        }
        public Int16 ISAdd
        {
            get;
            set;
        }

        public Int16 WorkStatus
        {
            get;
            set;
        }

        public int Phase
        {
            get;
            set;
        }

        

        public decimal Latitude
        {
            get;
            set;
        }

        public decimal Longitude
        {
            get;
            set;
        }

        public string MobileNumber
        {
            get;
            set;
        }

        public string AdharCardNumber
        {
            get;
            set;
        }

        public decimal ActualSurvey_In_Meters
        {
            get;
            set;
        }

        public string DTCNumber
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Section
        {
            get;
            set;
        }

        public string Reason
        {
            get;
            set;
        }

       
        public bool isCommunicateWithFarmer
        {
            get;
            set;
        }

        public bool IsPreviousDateAllowed
        {
            get;
            set;
        }

        public bool BillingStatus
        {
            get;
            set;
        }

        public int ReasonStatus
        {
            get;
            set;
        }

        public string FarmerCommunication
        {
            get;
            set;
        }

        public string PresentCrop
        {
            get;
            set;
        }

        public string FutureCrop
        {
            get;
            set;
        }

        public DateTime? PresentCropCuttingDate
        {
            get;
            set;
        }

        public DateTime? FutureCropPlantationDate
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string VersionNumber { get; set; }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }

        //ConsumerRequirement
        public string ConsumersGroup
        {
            get; set;
        }

        public decimal ActualSurvey_In_KMeters
        {
            get;
            set;
        }

        public bool ServiceConnection
        {
            get;
            set;
        }

        public bool ExtensionOfServiceConnection
        {
            get;
            set;
        }

        public string TappingLocationDetails
        {
            get; set;
        }

        public int No_Of_Poles
        {
            get;
            set;
        }
        public int No_Of_CutPoints
        {
            get;
            set;
        }
        public int TappingFrom_ActivityID
        {
            get;
            set;
        }
        public int GaurdingSpanNeeded
        {
            get;
            set;
        }

        public String OtherIssues
        {
            get;
            set;
        }

        public String TappingMaterials
        {
            get;
            set;
        }

        public String GaurdingNeeded
        {
            get;
            set;
        }

        public int Source
        {
            get;
            set;
        }

        public int Destination
        {
            get;
            set;
        }

        public double Distance
        {
            get;
            set;
        }


    }
}
