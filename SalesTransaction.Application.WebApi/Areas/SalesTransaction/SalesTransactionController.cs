using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.Model.SalesTransaction;
using SalesTransaction.Application.Service.SalesTransaction;
using SalesTransaction.Application.WebApi.Areas.Base;

namespace SalesTransaction.Application.WebApi.Areas.SalesTransaction
{
    public class SalesTransactionController : BaseController
    {
        private ISalesTransactionService _salesTransactionService;
        public SalesTransactionController(ISalesTransactionService salesTransactionService)
        {
            _salesTransactionService = salesTransactionService;
        }


        [HttpPost]
        public IActionResult AddSalesTransaction([FromBody] MvSalesTransaction salesTransaction)
        {
            try
            {
                var added = _salesTransactionService.AddSalesTransaction(salesTransaction);
                if (!added)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public IActionResult UpdateSalesTransaction([FromBody] MvEditSalesTransaction salesTransaction)
        {
            try
            {
                var edited = _salesTransactionService.EditSalesTransaction(salesTransaction);
                if (!edited)
                {
                    return BadRequest();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public IActionResult AllSalesTransactionDetail()
        {
            try
            {
                dynamic jsonString = _salesTransactionService.GetAllSalesTransactionDetail();
                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
