using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IEmployeeSalaryRulesDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesBySearch(EmployeeSalaryRulesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesGetBySearchList(EmployeeSalaryRulesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesByID(EmployeeSalaryRules item);

        /// <summary>
        /// data provider interface of insert new record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> InsertEmployeeSalaryRules(EmployeeSalaryRules item);

        /// <summary>
        /// data provider interface of update record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> UpdateEmployeeSalaryRules(EmployeeSalaryRules item);

        /// <summary>
        /// data provider interface of dalete record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRules(EmployeeSalaryRules item);
        
        IBaseEntityResponse<EmployeeSalaryRules> ViewEmployeeSalaryRulesRules(EmployeeSalaryRules item);
        IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRulesRules(EmployeeSalaryRules item);
        
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRules(EmployeeSalaryRulesSearchRequest searchRequest);

        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesAllowancesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest);
    }
}
