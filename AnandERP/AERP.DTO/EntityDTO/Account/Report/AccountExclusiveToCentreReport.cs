using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace AERP.DTO
{
    public class AccountExclusiveToCentreReport : BaseDTO
    {
          
        public Int16 ID { get; set; }
        public string AccountName { get; set; }
        public string DebitCreditFlag { get; set; }
        public string CashBankFlag { get; set; }
        public bool ExclusivelyForCentre { get; set; }
      
     
        public string GroupDescription { get; set; }
        public string AlternetGroupName { get; set; }


    }

   

}
