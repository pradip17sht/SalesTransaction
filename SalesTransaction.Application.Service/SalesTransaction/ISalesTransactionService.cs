using SalesTransaction.Application.Model.SalesTransaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTransaction.Application.Service.SalesTransaction
{
    public interface ISalesTransactionService
    {
        dynamic GetAllSalesTransactionDetail();
        bool AddSalesTransaction(MvSalesTransaction salesTransaction);
        bool EditSalesTransaction(MvEditSalesTransaction salesTransaction);
    }
}
