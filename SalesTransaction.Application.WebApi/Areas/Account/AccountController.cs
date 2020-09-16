using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesTransaction.Application.Model;
using SalesTransaction.Application.Service.Account;
using SalesTransaction.Application.WebApi.Areas.Base;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesTransaction.Application.WebApi.Areas.Account
{
    /*[Route("api/[controller]")]
    [ApiController]
*/
    public class AccountController : BaseController
    {
        private IAccountService _accountService;
        
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] MvLogin login)
        {
            try
            {
                dynamic jsonString = _accountService.GetLogin(login);
                return Ok(jsonString);
            }catch(Exception e)
            {
                throw e;
            }
        }

        // PUT api/<AccountController>/5
        [HttpGet]
        public IActionResult UserDetail (string json)
        {
            try
            {
                dynamic jsonString = _accountService.GetUserDetail(json);
                return Ok(jsonString);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
