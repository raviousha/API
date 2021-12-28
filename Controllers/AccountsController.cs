﻿using API.Models;
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
                        code = StatusCodes.Status401Unauthorized;
                        message = $"Incorrect Password";
                        break;
                    }
                case 3:
                    {
                        code = StatusCodes.Status404NotFound;
                        message = $"Account not found";
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

        [HttpPost("forgot")]
        public ActionResult ForgotPassword(ForgotVM forgotVM)
        {
            var code = 0;
            var message = "";
            var result = accountRepository.ForgotPassword(forgotVM);

            switch (result)
            {
                case 1:
                    {
                        code = StatusCodes.Status200OK;
                        accountRepository.SendMail(forgotVM);
                        message = $"Email sent to {forgotVM.email}, Please check your mailbox / spam folder";
                        break;
                    }
                case 2:
                    {
                        code = StatusCodes.Status404NotFound;
                        message = $"Account not found";
                        break;
                    }
                default:
                    {
                        code = StatusCodes.Status400BadRequest;
                        message = "Forgot Password Failed";
                        break;
                    }
            }

            return Ok(new { code, result, message });
        }

        [HttpPost("change")]
        public ActionResult ChangePassword(ChangePassVM changePassVM)
        {
            var code = 0;
            var message = "";
            var result = accountRepository.ChangePassword(changePassVM);

            switch (result)
            {
                case 1:
                    {
                        code = StatusCodes.Status200OK;
                        message = $"Password Succesfully Changed";
                        break;
                    }
                case 2:
                    {
                        code = StatusCodes.Status401Unauthorized;
                        message = $"OTP is Expired, please request new OTP";
                        break;
                    }
                case 3:
                    {
                        code = StatusCodes.Status401Unauthorized;
                        message = $"OTP is Incorrect";
                        break;
                    }
                case 4:
                    {
                        code = StatusCodes.Status404NotFound;
                        message = $"OTP is already used, please request new OTP";
                        break;
                    }
                case 5:
                    {
                        code = StatusCodes.Status404NotFound;
                        message = $"Account not found, please check the email you entered " +
                                  $"or register if you don't have an account";
                        break;
                    }
                default:
                    {
                        code = StatusCodes.Status400BadRequest;
                        message = "Forgot Password Failed";
                        break;
                    }
            }
            return Ok(new { code, result, message });
        }
    }
}
