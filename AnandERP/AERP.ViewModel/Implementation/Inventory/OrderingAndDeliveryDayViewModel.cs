using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class OrderingAndDeliveryDayViewModel : IOrderingAndDeliveryDayViewModel
    {

        public OrderingAndDeliveryDayViewModel()
        {
            OrderingAndDeliveryDayDTO = new OrderingAndDeliveryDay();

        }



        public OrderingAndDeliveryDay OrderingAndDeliveryDayDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null && OrderingAndDeliveryDayDTO.ID > 0) ? OrderingAndDeliveryDayDTO.ID : new Int16();
            }
            set
            {
                OrderingAndDeliveryDayDTO.ID = value;
            }
        }
         [Display(Name = "Code")]
        public string code
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.code : string.Empty;
            }
            set
            {
                OrderingAndDeliveryDayDTO.code = value;
            }
        }
         public string ParameterXml
         {
             get
             {
                 return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.ParameterXml : string.Empty;
             }
             set
             {
                 OrderingAndDeliveryDayDTO.ParameterXml = value;
             }
         }
        [Display(Name = "Ordering Code")]
         public string OrderingCode
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.OrderingCode : string.Empty;
            }
            set
            {
                OrderingAndDeliveryDayDTO.OrderingCode = value;
            }
        }


       
         [Display(Name = "Sunday")]
        public bool sunday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.sunday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.sunday = value;
            }
        }



         [Display(Name = "Monday")]
        public bool monday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.monday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.monday = value;
            }
        }
         [Display(Name = "Tuesday")]
        public bool tuesday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.tuesday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.tuesday = value;
            }
        }



         [Display(Name = "Wednesday")]
        public bool wednesday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.wednesday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.wednesday = value;
            }
        }
         [Display(Name = "Thursday")]
        public bool thursday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.thursday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.thursday = value;
            }
        }



         [Display(Name = "Friday")]
        public bool friday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.friday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.friday = value;
            }
        }
         [Display(Name = "Saturday")]
        public bool saturday
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.saturday : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.saturday = value;
            }
        }




        
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.IsDeleted : false;
            }
            set
            {
                OrderingAndDeliveryDayDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null && OrderingAndDeliveryDayDTO.CreatedBy > 0) ? OrderingAndDeliveryDayDTO.CreatedBy : new int();
            }
            set
            {
                OrderingAndDeliveryDayDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                OrderingAndDeliveryDayDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.ModifiedBy : new int();
            }
            set
            {
                OrderingAndDeliveryDayDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                OrderingAndDeliveryDayDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.DeletedBy : new int();
            }
            set
            {
                OrderingAndDeliveryDayDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (OrderingAndDeliveryDayDTO != null) ? OrderingAndDeliveryDayDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                OrderingAndDeliveryDayDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

