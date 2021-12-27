using API.Models;
using API.Repository;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        private readonly AccountRepository accountRepository;
        public AccountsController(AccountRepository accountRepository) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        //[Route("login")]
        [HttpPost("login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var code = 0;
            var message = "";
            var result = accountRepository.Login(loginVM);

            switch (result)
            {
                case 1:
                    {
                        code = StatusCodes.Status200OK;
                        message = $"Login Success";
                        break;

                    }
                case 2:
                    {
                        code = StatusCodes.Status400BadRequest;
                        message = $"Incorrect Password";
                        break;
                    }
                case 3:
                    {
                        code = StatusCodes.Status404NotFound;
                        message = $"Email not found";
                        break;
                    }
                default:
                    {
                        code = StatusCodes.Status400BadRequest;
                        message = "Login failed";
                        break;
                    }
            }
            return Ok(new { code, result, message });
        }
    }
}
