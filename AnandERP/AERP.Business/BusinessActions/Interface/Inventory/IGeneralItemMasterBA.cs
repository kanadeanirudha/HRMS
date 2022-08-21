using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralItemMasterBA
    {
        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> UpdateGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMaster(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetBySearch(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetCCRMPartNoSearchList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> SelectByID(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> SearchListForGeneralPackingTypeInfo(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumber(GeneralItemMaster item);
        //IBaseEntityResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSalesDataByItemNumber(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemGeneralDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemServiceDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemStockDataByItemNumber(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemDetailsForSupliersDataSearchList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetUomDetailsForGeneralItemMaster(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> GetRestaurantDataByItemNumber(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetVariantDetailsForGeneralItemMasters(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeDataByItemNumber(GeneralItemMasterSearchRequest searchRequest);

        //********************************Barcodes insert and select method declaration***********
        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemBarcodes(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemBarcodes(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetBarcodesBySearch(GeneralItemMasterSearchRequest searchRequest);

        //***************************Store specific Information methods ****************
        IBaseEntityResponse<GeneralItemMaster> InsertInventoryStoreSpecificInformation(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> SelectOneInventoryStoreSpecificInformation(GeneralItemMaster item);

        IBaseEntityResponse<GeneralItemMaster> CheckFocusOnAction(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemStoreData(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemAttributeData(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> InsertGeneralitemMasterExcel(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> GetDataValidationListsForExcel(GeneralItemMaster item);

        IBaseEntityCollectionResponse<GeneralItemMaster> GetItemSearchListForVarientsMenu(GeneralItemMasterSearchRequest searchRequest);

        //******************************** Reports searchlist **********
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterSearchListForReport(GeneralItemMasterSearchRequest searchRequest);

        //****************Vendor specific item search list
        IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListForRequisition(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> InsertGeneralItemSupplierDataForVendorDetails(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetMultipleVendorListItemWise(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemSupliersDataByItemNumberandVendorID(GeneralItemMasterSearchRequest searchRequest);

        IBaseEntityResponse<GeneralItemMaster> GetGeneralItemEcommerceDataByItemNumber(GeneralItemMaster item);
        IBaseEntityResponse<GeneralItemMaster> DeleteGeneralItemMasterEComImages(GeneralItemMaster item);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetVendorWiseItemSearchListWithCompoundTax(GeneralItemMasterSearchRequest searchRequest);

        //***************Sale Contract*************

        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralServiceItemList(GeneralItemMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<GeneralItemMaster> GetGeneralItemMasterForSaleUOMBySearchWord(GeneralItemMasterSearchRequest searchRequest); 
    }
}

