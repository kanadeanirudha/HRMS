using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralMovementType : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
        public string MovementType
        {
            get;
            set;
        }

        public string MovementCode
        {
            get;
            set;
        }
        public byte Action
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }
        public int TransactionType
        {
            get;
            set;
        }
        public int Direction
        {
            get;
            set;
        }
        public string Behaviour
        {
            get;
            set;
        }
        public int MovementTypeRulesID
        {
            get;
            set;
        }
        public byte MovementTypeID
        {
            get;
            set;
        }
        //Feilds from GeneralUnitType//



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
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
    }
}
