using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IEmpDesignationMasterViewModel
    {
        EmpDesignationMaster EmpDesignationMasterDTO
        {
            get;
            set;
        }

        int ID
        {
            get;
            set;
        }

        string Description
        {
            get;
            set;
        }

        int DesignationLevel
        {
            get;
            set;
        }

        int Grade
        {
            get;
            set;
        }

        string ShortCode
        {
            get;
            set;
        }

        int CollegeID
        {
            get;
            set;
        }

        string EmpDesigType
        {
            get;
            set;
        }

        string RelatedWith
        {
            get;
            set;
        }                
    }
}
