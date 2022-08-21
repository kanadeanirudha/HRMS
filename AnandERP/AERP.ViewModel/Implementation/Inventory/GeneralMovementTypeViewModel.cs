using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralMovementTypeViewModel : IGeneralMovementTypeViewModel
    {

        public GeneralMovementTypeViewModel()
        {
            GeneralMovementTypeDTO = new GeneralMovementType();

        }



        public GeneralMovementType GeneralMovementTypeDTO
        {
            get;
            set;
        }
        [Display(Name = "Action")]
        public byte Action
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.Action : new byte();
            }
            set
            {
                GeneralMovementTypeDTO.Action = value;
            }
        }
        public Int16 ID
        {
            get
            {
                return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.ID > 0) ? GeneralMovementTypeDTO.ID : new Int16();
            }
            set
            {
                GeneralMovementTypeDTO.ID = value;
            }
        }

        public int MovementTypeRulesID
        {
            get
            {
                return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.MovementTypeRulesID > 0) ? GeneralMovementTypeDTO.MovementTypeRulesID : new int();
            }
            set
            {
                GeneralMovementTypeDTO.MovementTypeRulesID = value;
            }
        }
        public byte MovementTypeID
        {
            get
            {
                return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.MovementTypeID > 0) ? GeneralMovementTypeDTO.MovementTypeID : new byte();
            }
            set
            {
                GeneralMovementTypeDTO.MovementTypeID = value;
            }
        }

        [Required(ErrorMessage = "Movement Type should not be blank.")]
        [Display(Name = "Movement Type")]
        public string MovementType
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.MovementType : string.Empty;
            }
            set
            {
                GeneralMovementTypeDTO.MovementType = value;
            }
        }

        [Required(ErrorMessage = "Movement Code should not be blank.")]
        [Display(Name = "Movement Code")]
        public string MovementCode
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.MovementCode : string.Empty;
            }
            set
            {
                GeneralMovementTypeDTO.MovementCode = value;
            }
        }
          [Display(Name = "Is Active")]
        public bool IsActive
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.IsActive : false;
            }
            set
            {
                GeneralMovementTypeDTO.IsActive = value;
            }
        }

          [Display(Name = "Transaction Type")]
          public int TransactionType
          {
              get
              {
                  return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.TransactionType > 0) ? GeneralMovementTypeDTO.TransactionType : new int();
              }
              set
              {
                  GeneralMovementTypeDTO.TransactionType = value;
              }
          }
          [Display(Name = "Direction")]
          public int Direction
          {
              get
              {
                  return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.Direction > 0) ? GeneralMovementTypeDTO.Direction : new int();
              }
              set
              {
                  GeneralMovementTypeDTO.Direction = value;
              }
          }
          [Display(Name = "Behaviour")]
          public string Behaviour
          {
              get
              {
                  return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.Behaviour : string.Empty;
              }
              set
              {
                  GeneralMovementTypeDTO.Behaviour = value;
              }
          }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.IsDeleted : false;
            }
            set
            {
                GeneralMovementTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralMovementTypeDTO != null && GeneralMovementTypeDTO.CreatedBy > 0) ? GeneralMovementTypeDTO.CreatedBy : new int();
            }
            set
            {
                GeneralMovementTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralMovementTypeDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralMovementTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralMovementTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.DeletedBy : new int();
            }
            set
            {
                GeneralMovementTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralMovementTypeDTO != null) ? GeneralMovementTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralMovementTypeDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

