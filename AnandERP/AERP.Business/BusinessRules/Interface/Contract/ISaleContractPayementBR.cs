﻿using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractPayementBR
    {
        IValidateBusinessRuleResponse InsertSaleContractPayementValidate(SaleContractPayement item);
        IValidateBusinessRuleResponse UpdateSaleContractPayementValidate(SaleContractPayement item);
        IValidateBusinessRuleResponse DeleteSaleContractPayementValidate(SaleContractPayement item);
    }
}
