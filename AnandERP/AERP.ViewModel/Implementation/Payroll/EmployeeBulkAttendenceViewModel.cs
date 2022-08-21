using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.DTO;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
    public class EmployeeBulkAttendenceViewModel:IEmployeeBulkAttendenceViewModel
    {
        public EmployeeBulkAttendenceViewModel()
        {
            EmployeeBulkAttendenceDTO = new EmployeeBulkAttendenceMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
            ListGetOrganisationDepartmentCentreAndDepartmentWise = new List<EmployeeBulkAttendenceMaster>();
            ListGetSalarySpan = new List<EmployeeBulkAttendenceMaster>();
        }

        public HttpPostedFileBase ExcelFile { get; set; }

        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }

        public List<EmployeeBulkAttendenceMaster> ListGetSalarySpan
        {
            get;
            set;
        }
        public List<EmployeeBulkAttendenceMaster> ListGetOrganisationDepartmentCentreAndDepartmentWise
        {
            get;
            set;
        }

        public EmployeeBulkAttendenceMaster EmployeeBulkAttendenceDTO
        {
            get;
            set;
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }

        public IEnumerable<SelectListItem> ListGetEmployeeSalarySpan
        {
            get
            {
                return new SelectList(ListGetSalarySpan, "SpanID", "Span");
            }
        }

        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndDepartmentWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndDepartmentWise, "CentreCode", "DepartmentID");
            }
        }

        public int ID
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.ID > 0) ? EmployeeBulkAttendenceDTO.ID : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.EmployeeID > 0) ? EmployeeBulkAttendenceDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.EmployeeID = value;
            }
        }

        public string EmployeeCode
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null) ? EmployeeBulkAttendenceDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeBulkAttendenceDTO.EmployeeCode = value;
            }
        }

        [Display(Name = "Employee Name")]
        public string EmployeeName
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null) ? EmployeeBulkAttendenceDTO.EmployeeName :string.Empty;
            }
            set
            {
                EmployeeBulkAttendenceDTO.EmployeeName = value;
            }
        }

        [Display(Name = "Total Attendence")]
        public int TotalAttendence
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.TotalAttendence > 0) ? EmployeeBulkAttendenceDTO.TotalAttendence : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.TotalAttendence = value;
            }
        }

        [Display(Name = "Total Overtime")]
        public int TotalOvertime
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.TotalOvertime > 0) ? EmployeeBulkAttendenceDTO.TotalOvertime : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.TotalOvertime = value;
            }
        }

        [Display(Name = "Total Days")]
        public int TotalDays
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.TotalDays > 0) ? EmployeeBulkAttendenceDTO.TotalDays : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.TotalDays = value;
            }
        }

        [Display(Name = "Centre Code")]
        public string CentreCode
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null) ? EmployeeBulkAttendenceDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeBulkAttendenceDTO.CentreCode = value;
            }
        }

        [Display(Name = "Created By")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.CreatedBy > 0) ? EmployeeBulkAttendenceDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created Date")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null) ? EmployeeBulkAttendenceDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeBulkAttendenceDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified By")]
        public int ModifiedBy
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.ModifiedBy > 0) ? EmployeeBulkAttendenceDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.ModifiedDate.HasValue) ? EmployeeBulkAttendenceDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeBulkAttendenceDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted By")]
        public int DeletedBy
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.DeletedBy > 0) ? EmployeeBulkAttendenceDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.DeletedDate.HasValue) ? EmployeeBulkAttendenceDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeBulkAttendenceDTO.DeletedDate = value;
            }
        }

        public string errorMessage { get; set; }

        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public string SelectedDepartmentIDs
        {
            get;
            set;
        }

        public string EntityLevel { get; set; }

        public int SpanID
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null && EmployeeBulkAttendenceDTO.SpanID > 0) ? EmployeeBulkAttendenceDTO.SpanID : new int();
            }
            set
            {
                EmployeeBulkAttendenceDTO.SpanID = value;
            }
        }

        public string Span
        {
            get
            {
                return (EmployeeBulkAttendenceDTO != null) ? EmployeeBulkAttendenceDTO.Span : string.Empty;
            }
            set
            {
                EmployeeBulkAttendenceDTO.Span = value;
            }
        }
    }
}
