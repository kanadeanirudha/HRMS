using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{ 
    public class EmployeeSalarySpanViewModel : IEmployeeSalarySpanViewModel
    {
        public EmployeeSalarySpanViewModel()
        {
            EmployeeSalarySpanDTO = new EmployeeSalarySpan();
        }

        public EmployeeSalarySpan EmployeeSalarySpanDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.ID > 0) ? EmployeeSalarySpanDTO.ID : new Int16();
            }
            set
            {
                EmployeeSalarySpanDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "From Date should not be blank.")]
        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.FromDate : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.FromDate = value;
            }
        }

        [Required(ErrorMessage = "Upto Date should not be blank.")]
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.UptoDate : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.UptoDate = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.IsActive : false;
            }
            set
            {
                EmployeeSalarySpanDTO.IsActive = value;
            }
        }

        public bool IsSalaryGenerated
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.IsSalaryGenerated : false;
            }
            set
            {
                EmployeeSalarySpanDTO.IsSalaryGenerated = value;
            }
        }

        [Display(Name = "Completion Date")]
        public string CompletionDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.CompletionDate : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.CompletionDate = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.CreatedBy > 0) ? EmployeeSalarySpanDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeSalarySpanDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalarySpanDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.ModifiedBy > 0) ? EmployeeSalarySpanDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeSalarySpanDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.ModifiedDate.HasValue) ? EmployeeSalarySpanDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalarySpanDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.DeletedBy > 0) ? EmployeeSalarySpanDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeSalarySpanDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.DeletedDate.HasValue) ? EmployeeSalarySpanDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeSalarySpanDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        public int SpanID
        {
            get
            {
                return (EmployeeSalarySpanDTO != null && EmployeeSalarySpanDTO.SpanID > 0) ? EmployeeSalarySpanDTO.SpanID : new Int16();
            }
            set
            {
                EmployeeSalarySpanDTO.SpanID = value;
            }
        }

        public string Span
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.Span : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.Span = value;
            }
        }

        public string CentreCode
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.CentreCode = value;
            }
        }

        public string DepartmentID
        {
            get
            {
                return (EmployeeSalarySpanDTO != null) ? EmployeeSalarySpanDTO.DepartmentID : string.Empty;
            }
            set
            {
                EmployeeSalarySpanDTO.DepartmentID = value;
            }
        }
    }

}
