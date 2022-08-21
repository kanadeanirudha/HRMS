﻿using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralTransactionMaster : BaseDTO
    {
        public Int16 ID
        {
            get;
            set;
        }
       
        public string TransactionType
        {
            get;
            set;
        }

        public bool IsActive
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
