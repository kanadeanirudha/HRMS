using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeeSalaryRulesBA
    {
        /// <summary>
        /// business action interface of insert new record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> InsertEmployeeSalaryRules(EmployeeSalaryRules item);

        /// <summary>
        /// business action interface of update record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> UpdateEmployeeSalaryRules(EmployeeSalaryRules item);

        /// <summary>
        /// business action interface of dalete record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRules(EmployeeSalaryRules item);

        /// <summary>
        /// business action interface of select all record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetBySearch(EmployeeSalaryRulesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetBySearchList(EmployeeSalaryRulesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of EmployeeSalaryRules.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<EmployeeSalaryRules> SelectByID(EmployeeSalaryRules item);
        
        IBaseEntityResponse<EmployeeSalaryRules> ViewEmployeeSalaryRulesRules(EmployeeSalaryRules item);
        IBaseEntityResponse<EmployeeSalaryRules> DeleteEmployeeSalaryRulesRules(EmployeeSalaryRules item);
         
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRules(EmployeeSalaryRulesSearchRequest searchRequest); 

        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryRules> GetEmployeeSalaryRulesAllowancesBySearchWord(EmployeeSalaryRulesSearchRequest searchRequest); 
    }
}
