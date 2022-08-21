﻿using System;
using AERP.Base.DTO;
using AERP.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralRunningNumbersForAccountDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountBySearch(GeneralRunningNumbersForAccountSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountGetBySearchList(GeneralRunningNumbersForAccountSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> GetGeneralRunningNumbersForAccountByID(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// data provider interface of insert new record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> InsertGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// data provider interface of update record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> UpdateGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        /// <summary>
        /// data provider interface of dalete record of GeneralRunningNumbersForAccount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralRunningNumbersForAccount> DeleteGeneralRunningNumbersForAccount(GeneralRunningNumbersForAccount item);

        //Get Auto generated Purchase Requirement Number
        IBaseEntityResponse<GeneralRunningNumbersForAccount> GetAutoGeneratedRequirementNumber(GeneralRunningNumbersForAccount item);
    }
}
