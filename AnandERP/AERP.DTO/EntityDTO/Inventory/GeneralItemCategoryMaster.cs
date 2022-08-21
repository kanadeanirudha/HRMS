using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class GeneralItemCategoryMaster : BaseDTO
	{
		public Int16 ID
		{
			get;
			set;
		}
        public Int32 CCRMContractTypeDetailsID
        {
            get;
            set;
        }
        public string ItemCategoryDescription
		{
			get;
			set;
		}
        public string ItemCategoryCode
		{
			get;
			set;
		}
        public string errorMessage { get; set; }
        public string XMLstring
        {
            get;
            set;
        }
        public Int16 MarchandiseGroupID
        {
            get;
            set;
        }
        public Int16 MerchandiseDepartmentID
        {
            get;
            set;
        }
        public Int16 MerchandiseCategoryID
        {
            get;
            set;
        }
        public Int16 MarchandiseSubCategoryID
        {
            get;
            set;
        }
        public Int16 MarchandiseBaseCatgoryID
        {
            get;
            set;
        }

        public string MarchandiseGroupCode
        {
            get;
            set;
        }
        public string MarchandiseBaseCatgoryCode
        {
            get;
            set;
        }
        public string MerchantiseDepartmentCode
        {
            get;
            set;
        }
        public string MerchantiseSubCategoryCode
        {
            get;
            set;
        }
        public string MerchantiseCategoryCode
        {
            get;
            set;
        }


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
      // For Group
        public string GroupDescription
        {
            get;
            set;
        }

        // For Department
        public string MerchantiseDepartmentName
        {
            get;
            set;
        }
        //For Category
        public string MerchantiseCategoryName
        {
            get;
            set;
        }
        //For Subcategory
        public string MarchantiseSubCategoryName
        {
            get;
            set;
        }

        //For Base Category
        public string MarchandiseBaseCategoryName
        {
            get;
            set;
        }

        public string selectedGroupDescription
        {
            get;
            set;
        }
        public string GroupCode
        {
            get;
            set;
        }
        public bool IsConsumable
        {
            get;
            set;
        }
        public bool IsMachine
        {
            get;
            set;
        }
        public bool IsToner
        {
            get;
            set;
        }
        public string StatusFlag
        {
            get;
            set;

        }
        public bool IsActive
            {
            get;
            set;

        }
}
}
