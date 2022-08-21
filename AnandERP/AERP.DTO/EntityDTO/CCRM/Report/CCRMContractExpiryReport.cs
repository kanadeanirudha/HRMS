using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
   public class CCRMContractExpiryReport :BaseDTO
    {
        public Int32 ID
        {
            get;
            set;
        }
        public String MIFName
        {
            get;
            set;
        }
        public String SerialNo
        {
            get;
            set;
        }
        public String Contarct
        {
            get;
            set;
        }
        public String ExpiryDate
        {
            get;
            set;
        }
        public bool Close
        {
            get;
            set;
        }
        public Int32 ContractTypeId
        {
            get;
            set;
        }
    }
}
