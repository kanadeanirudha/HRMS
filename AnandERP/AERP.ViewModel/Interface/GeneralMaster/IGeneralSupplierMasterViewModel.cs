using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    interface IGeneralSupplierMasterViewModel
    {
        GeneralSupplierMaster GeneralSupplierMasterDTO
        {
            get;
            set;
        }
        int ID
        {
            get;
            set;
        }
        string Vender
        {
            get;
            set;
        }
        string FirstName
        {
            get;
            set;
        }
        string MiddleName
        {
            get;
            set;
        }
        string LastName
        {
            get;
            set;
        }
        string FullName
        {
            get;
            set;
        }
        string Sex
        {
            get;
            set;
        }
        string AddressFirst
        {
            get;
            set;
        }
        string AddressSecond
        {
            get;
            set;
        }
        string PlotNumber
        {
            get;
            set;
        }
        string StreetNumber
        {
            get;
            set;
        }
        Nullable<int> TahsilID
        {
            get;
            set;
        }
        Nullable<int> PinCode
        {
            get;
            set;
        }
        string PhoneNumber
        {
            get;
            set;
        }
        string ResiPhoneNumber
        {
            get;
            set;
        }
        string CellPhoneNumber
        {
            get;
            set;
        }
        string FaxNumber
        {
            get;
            set;
        }
        string Email
        {
            get;
            set;
        }
        string WebUrl
        {
            get;
            set;
        }
        string VenderDescription
        {
            get;
            set;
        }
        Nullable<int> CategoryId
        {
            get;
            set;
        }
        Nullable<int> AccountId
        {
            get;
            set;
        }
        string VAT
        {
            get;
            set;
        }
        string CST
        {
            get;
            set;
        }
        string Excise
        {
            get;
            set;
        }
        string StablishmentNumber
        {
            get;
            set;
        }
        string RefNumber
        {
            get;
            set;
        }
        Nullable<bool> IsActive
        {
            get;
            set;
        }
        Nullable<int> CreatedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> CreatedDate
        {
            get;
            set;
        }
        Nullable<int> ModifiedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> ModifiedDate
        {
            get;
            set;
        }
        Nullable<int> DeletedBy
        {
            get;
            set;
        }
        Nullable<System.DateTime> DeletedDate
        {
            get;
            set;
        }
        Nullable<bool> IsDeleted
        {
            get;
            set;
        }
    }
}
