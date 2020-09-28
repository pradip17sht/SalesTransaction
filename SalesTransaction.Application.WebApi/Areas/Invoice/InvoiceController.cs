using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.Model.Invoice;
using SalesTransaction.Application.Service.Invoice;
using SalesTransaction.Application.WebApi.Areas.Base;

namespace SalesTransaction.Application.WebApi.Areas.Invoice
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public IActionResult GetAllInvoice()
        {
            try
            {
                var jsonString = _invoiceService.GetAllInvoice();
                return Ok(jsonString);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult GenerateInvoice([FromBody] IEnumerable<MvGenerateInvoice> salesTransaction)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var added = _invoiceService.GenerateInvoice(salesTransaction);
                if (!added)
                {
                    return BadRequest();
                }
                return Ok();


            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult GetInvoiceDetail(MvInvoice invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var jsonString = _invoiceService.GetInvoiceDetail(invoice);
                return Ok(jsonString);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
